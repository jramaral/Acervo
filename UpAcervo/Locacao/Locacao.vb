Imports System.Data.OleDb
Public Class Locacao

    Public IdSeletor
    Dim Autorizado As Boolean
    Public Property IniciarPeloSeletor() As Integer
        Get
            Return IdSeletor
        End Get
        Set(ByVal Value As Integer)
            IdSeletor = Value
        End Set
    End Property



    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub NovoLimpar()
        Me.IdLoc.Text = "AUTO"
        Me.DataLoc.Clear()
        Me.Cliente.Clear()
        Me.ClienteNome.Clear()
        Me.CPFCNPJ.Clear()
        Me.Telefone.Clear()
        Me.ObsLoc.Clear()
        Me.StatusLoc.Text = ""

        Dim I As Integer
        For I = 0 To Me.Lista.Rows.Count - 1
            Me.Lista.Rows.RemoveAt(0)
        Next
        Me.IdLoc.Focus()

    End Sub

    Private Sub btNovo_Click(sender As Object, e As EventArgs) Handles btNovo.Click
        NovoLimpar()
        My.Forms.LocacaoClientesProcura.ShowDialog()
        AcharCliente()
        SalvarDadosIncial()
        Me.CodBarra.Enabled = True
        Me.DataLoc.Focus()
    End Sub

    Private Sub AcharCliente()

        If Me.Cliente.Text = "" Then
            Exit Sub
        End If



        Dim CnnFind As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CnnFind.Open()

        Dim Sql As String = "Select * from Clientes where Codigo = " & Me.Cliente.Text
        Dim CMD As New OleDbCommand(Sql, CnnFind)
        Dim DR As OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then

            If DR.Item("Bloqueado") = True Then
                MessageBox.Show("Este cliente esta bloqueado, Favor verificar", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NovoLimpar()
            End If

            Me.CPFCNPJ.Text = DR.Item("CpfCgc") & ""
            Me.ClienteNome.Text = DR.Item("Nome") & ""
            Me.Telefone.Text = DR.Item("Telefone") & ""
            Me.Decorador.Text = DR.Item("Decorador") & ""
            Me.StatusLoc.Text = "INICIAL"

        Else
            MessageBox.Show("Cliente não localizado, Verifique.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cliente.Clear()
            Me.CPFCNPJ.Clear()
            Me.ClienteNome.Clear()
            Me.Telefone.Clear()
            Me.Decorador.Clear()
        End If

        DR.Close()
        CnnFind.Close()
    End Sub

    Private Sub btObterEndereço_Click(sender As Object, e As EventArgs) Handles btObterEndereço.Click

        If Me.Cliente.Text = "" Then
            Exit Sub
        End If

        Dim CnnFind As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CnnFind.Open()

        Dim Sql As String = "SELECT Clientes.*, Municipio.NomeMunic, UF.NomeUF, Clientes.Codigo FROM (Clientes INNER JOIN Municipio ON Clientes.cMun = Municipio.CodMunicipio) INNER JOIN UF ON Clientes.cUF = UF.CodigoUF WHERE (((Clientes.Codigo)=" & Me.Cliente.Text & "))"

        Dim CMD As New OleDbCommand(Sql, CnnFind)
        Dim DR As OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then

            If DR.Item("Bloqueado") = True Then
                MessageBox.Show("Este cliente esta bloqueado, Favor verificar", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NovoLimpar()
            End If

            Me.ObsLoc.Text = DR.Item("Endereço") & ", " & DR.Item("Nro") & vbCrLf
            Me.ObsLoc.Text &= DR.Item("Bairro") & vbCrLf
            Me.ObsLoc.Text &= DR.Item("NomeMunic") & " - " & DR.Item("NomeUF") & vbCrLf
            SalvarDadosIncial()

        Else
            MessageBox.Show("Cliente não localizado, Verifique.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ObsLoc.Clear()
        End If

        DR.Close()
        CnnFind.Close()


    End Sub

    Private Sub SalvarDadosIncial()

        If Me.Cliente.Text = "" Then
            Exit Sub
        End If


        Dim Sql As String = String.Empty

        Dim ds As New DataSet

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim VarCod As Integer = IIf(Me.IdLoc.Text = "AUTO", -1, Me.IdLoc.Text)
        Sql = "Select * From Locacao where IdLoc = " & VarCod

        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim Da As New OleDbDataAdapter(Cmd)
        Da.Fill(ds, "Locacao")


        'Verifica se esta cadastrando pela tela de locação
        If ds.Tables("Locacao").Rows.Count = 0 Then

            Dim DRnovo As DataRow
            DRnovo = ds.Tables("Locacao").NewRow

            DRnovo("DataLoc") = nzDAT(Me.DataLoc.Text)
            DRnovo("StatusLoc") = nzNUL(Me.StatusLoc.Text)
            DRnovo("Cliente") = nzINT(Me.Cliente.Text)
            DRnovo("ObsLoc") = nzNUL(Me.ObsLoc.Text)
            DRnovo("TotalLoc") = nzNUM(Me.TotalLoc.Text)
            DRnovo("Empresa") = nzINT(CodEmpresa)
            DRnovo("OutrosAjustes") = nzNUM(Me.txtOutrosAjustes.Text)
            ds.Tables("Locacao").Rows.Add(DRnovo)


            Try
                Dim ObjADD As New OleDbCommandBuilder(Da)
                Da.Update(ds, "Locacao")

                Cmd.CommandText = "SELECT @@IDENTITY"
                Dim ID As Integer = Cmd.ExecuteScalar.ToString
                Me.IdLoc.Text = ID

                MessageBox.Show("Registro salvo com sucesso", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cnn.Close()
            Catch ex As Exception
                Cnn.Close()
                MessageBox.Show(ex.Message)
            End Try

        Else 'senão atualiza os dados que já foram inseridos

            ds.Tables("Locacao").Rows(0).BeginEdit()

            ds.Tables("Locacao").Rows(0)("DataLoc") = nzDAT(Me.DataLoc.Text)
            ds.Tables("Locacao").Rows(0)("HoraLoc") = nzNUL(Me.HoraLoc.Text)
            ds.Tables("Locacao").Rows(0)("DataRetorno") = nzDAT(Me.DataRetorno.Text)
            ds.Tables("Locacao").Rows(0)("HoraRetorno") = nzNUL(Me.HoraRetorno.Text)
            ds.Tables("Locacao").Rows(0)("DiariaAmais") = nzINT(Me.DiariaAmais.Text)
            ds.Tables("Locacao").Rows(0)("Frete") = nzNUL(Me.Frete.SelectedValue)
            ds.Tables("Locacao").Rows(0)("ValorFrete") = nzNUM(Me.ValorFrete.Text)
            ds.Tables("Locacao").Rows(0)("StatusLoc") = nzNUL(Me.StatusLoc.Text)
            ds.Tables("Locacao").Rows(0)("Cliente") = nzINT(Me.Cliente.Text)
            ds.Tables("Locacao").Rows(0)("ObsLoc") = nzNUL(Me.ObsLoc.Text)

            ds.Tables("Locacao").Rows(0)("TotalDiarias") = nzNUM(Me.tDiariaAmais.Text)
            ds.Tables("Locacao").Rows(0)("TotalItens") = nzNUM(Me.tItens.Text)
            ds.Tables("Locacao").Rows(0)("TotalDesconto") = nzNUM(Me.tDesconto.Text)
            ds.Tables("Locacao").Rows(0)("TotalLoc") = nzNUM(Me.TotalLoc.Text)
            'informações inseridas pelo jose roberto
            ds.Tables("Locacao").Rows(0)("OutrosAjustes") = nzNUM(Me.txtOutrosAjustes.Text)
            ds.Tables("Locacao").Rows(0)("Entrega") = nzNUL(Me.cboEntrega.Text)
            ds.Tables("Locacao").Rows(0)("Devolve") = nzNUL(Me.cboDevolve.Text)
            ds.Tables("Locacao").Rows(0)("NomeTransportadora") = nzNUL(Me.cboTransportadora.Text)
            ds.Tables("Locacao").Rows(0)("CodigoTransportadora") = nzNUM(Me.cboTransportadora.SelectedValue)
            ds.Tables("Locacao").Rows(0)("placa") = nzNUL(Me.txtPlaca.Text)
            ds.Tables("Locacao").Rows(0)("LocalEntrega") = nzNUL(Me.txtLocalEntrega.Text)
            ds.Tables("Locacao").Rows(0)("Contato") = nzNUL(Me.txtcontato.Text)
            ds.Tables("Locacao").Rows(0)("NomeVendedor") = nzNUL(Me.cboVendedor.Text)
            ds.Tables("Locacao").Rows(0)("CodigoVendedor") = nzNUM(Me.cboVendedor.SelectedValue)




            ds.Tables("Locacao").Rows(0).EndEdit()


            Try
                Dim ObjEDD As New OleDbCommandBuilder(Da)
                Da.Update(ds, "Locacao")
                Cnn.Close()
                If Me.StatusLoc.Text = "INICIAL" Then
                    Me.CodBarra.Focus()
                End If

            Catch ex As Exception
                Cnn.Close()
                MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Private Sub Frete_Leave(sender As Object, e As EventArgs) Handles Frete.Leave
        If Me.Frete.Text <> "" Then
            AchaValorFrete()
        Else
            Me.ValorFrete.Text = FormatNumber(0, 2)

        End If


        Dim dValor As Double = FormatNumber(((nzNUM(tItens.Text) + nzNUM(tDiariaAmais.Text) + nzNUM(ValorFrete.Text)) - nzNUM(Me.tDesconto.Text)), 2)
        Dim dDesc As Double = Me.txtOutrosAjustes.Text

        Me.TotalLoc.Text = FormatCurrency((dValor - dDesc), 2)





    End Sub

    Private Sub AchaValorFrete()
        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT Frete.*  FROM Frete WHERE Frete.Empresa =" & CodEmpresa & " and DescricaoFrete = '" & Me.Frete.SelectedValue & "'"


        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        If ds.Tables("Table").Rows.Count = 1 Then
            Me.ValorFrete.Text = FormatNumber(ds.Tables("Table").Rows(0)("ValorFrete"), 2)
        End If

        da.Dispose()
        Cnn.Close()


    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If Me.StatusLoc.Text <> "INICIAL" Then
            MessageBox.Show("Somete pode alterar o cliente da locação com Status de [INICIAL]")
            Exit Sub
        Else

            My.Forms.LocacaoClientesProcura.ShowDialog()
            AcharCliente()
            SalvarDadosIncial()

        End If



    End Sub

    Private Sub btProcuraLocacao_Click(sender As Object, e As EventArgs) Handles btProcuraLocacao.Click
        NovoLimpar()
        My.Forms.LocacaoProcurar.ShowDialog()
        AcharLocacao()

        Select Case StatusLoc.Text
            Case "LOCADO"
                Me.btnEntregar.Enabled = True
                Me.btnImprimir.Enabled = True
            Case "DEVOLVIDO"
                Me.btnEntregar.Enabled = False
                Me.btnImprimir.Enabled = True

            Case Else
                Me.btnEntregar.Enabled = False
                Me.btnImprimir.Enabled = False


        End Select

        If chkProdutosEntregue.Checked = False And Me.StatusLoc.Text = "LOCADO" Then
            Me.btnEntregar.Enabled = True
        Else

            Me.btnEntregar.Enabled = False
        End If

    End Sub

    Private Sub AcharLocacao()

        If Me.IdLoc.Text = "" Then Exit Sub
        If Me.IdLoc.Text = "AUTO" Then Exit Sub

        Dim Sql As String = String.Empty

        Dim ds As New DataSet

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim VarCod As Integer = Me.IdLoc.Text
        Sql = "SELECT Locacao.*, Locacao.IdLoc, Clientes.Nome, Clientes.CpfCgc, Clientes.Telefone, Clientes.Decorador FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Locacao.IdLoc)=" & VarCod & "))"


        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim Da As New OleDbDataAdapter(Cmd)
        Da.Fill(ds, "Locacao")


        If ds.Tables("Locacao").Rows.Count = 1 Then

            Me.DataLoc.Text = ds.Tables("Locacao").Rows(0)("DataLoc") & ""
            Me.HoraLoc.Text = ds.Tables("Locacao").Rows(0)("HoraLoc") & ""
            Me.DataRetorno.Text = ds.Tables("Locacao").Rows(0)("DataRetorno") & ""
            Me.HoraRetorno.Text = ds.Tables("Locacao").Rows(0)("HoraRetorno") & ""
            Me.DiariaAmais.Text = NzZero(ds.Tables("Locacao").Rows(0)("DiariaAmais"))
            Me.Frete.SelectedValue = ds.Tables("Locacao").Rows(0)("Frete")
            Me.ValorFrete.Text = NzZero(ds.Tables("Locacao").Rows(0)("ValorFrete"))
            Me.StatusLoc.Text = ds.Tables("Locacao").Rows(0)("StatusLoc") & ""
            Me.Cliente.Text = ds.Tables("Locacao").Rows(0)("Cliente") & ""
            Me.ClienteNome.Text = ds.Tables("Locacao").Rows(0)("Nome") & ""
            Me.CPFCNPJ.Text = ds.Tables("Locacao").Rows(0)("CpfCgc") & ""
            Me.Telefone.Text = ds.Tables("Locacao").Rows(0)("Telefone") & ""
            Me.Decorador.Text = ds.Tables("Locacao").Rows(0)("Decorador") & ""
            Me.ObsLoc.Text = ds.Tables("Locacao").Rows(0)("ObsLoc") & ""
            Me.TotalLoc.Text = FormatNumber(NzZero(ds.Tables("Locacao").Rows(0)("TotalLoc")), 2)
            Me.txtOutrosAjustes.Text = FormatNumber(NzZero(ds.Tables("Locacao").Rows(0)("OutrosAjustes")), 2)

            'adicionado por jose roberto
            Me.cboVendedor.SelectedValue = ds.Tables("Locacao").Rows(0)("CodigoVendedor")
            Me.cboTransportadora.SelectedValue = ds.Tables("Locacao").Rows(0)("CodigoTransportadora")
            Me.txtLocalEntrega.Text = ds.Tables("Locacao").Rows(0)("LocalEntrega") & ""
            Me.txtPlaca.Text = ds.Tables("Locacao").Rows(0)("placa") & ""
            Me.cboEntrega.Text = ds.Tables("Locacao").Rows(0)("Entrega") & ""
            Me.cboDevolve.Text = ds.Tables("Locacao").Rows(0)("Devolve") & ""
            Me.txtcontato.Text = ds.Tables("Locacao").Rows(0)("Contato") & ""
            Me.chkProdutosEntregue.Checked = ds.Tables("Locacao").Rows(0)("ProdutosEntregue")



            If Me.StatusLoc.Text = "INICIAL" Then
                Me.CodBarra.Focus()
                Me.btConfirmarLocacao.Enabled = True
            End If

            If Me.StatusLoc.Text = "LOCADO" Or StatusLoc.Text = "CANCELADO" Then
                Me.btConfirmarLocacao.Enabled = False
                Me.btObterEndereço.Enabled = False
                Me.CodBarra.Enabled = False
                Me.btNovo.Enabled = True
            End If


        End If

        Cnn.Close()

        EncheListaItens()


    End Sub

    Private Sub CodBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles CodBarra.KeyDown

        If e.KeyCode = Keys.F5 Then
            My.Forms.LocacaoProdutoProcura.ShowDialog()

            If String.IsNullOrEmpty(Me.CodBarra.Text) Then
                Exit Sub
            End If

            AddProduto()
            Me.CodBarra.Focus()

        End If

    End Sub

    Private Sub AddProduto()

        If String.IsNullOrEmpty(Me.CodBarra.Text) Then
            Me.CodBarra.Focus()
            Exit Sub
        End If

        If Me.Qtd.Text = "" Then
            Me.Qtd.Text = FormatNumber(1, 2)
        End If

        Dim Sql As String = String.Empty

        Dim ds As New DataSet

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Sql = "Select * From Produtos where CodigoBarra = '" & Me.CodBarra.Text & "' and Inativo = False"
        Dim CmdProd As New OleDbCommand(Sql, Cnn)
        Dim DaProd As New OleDbDataAdapter(CmdProd)
        DaProd.Fill(ds, "Produtos")

        If ds.Tables("Produtos").Rows.Count = 0 Then
            MessageBox.Show("Produto não encontrado, forvor verificar.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CodBarra.Clear()
            Me.CodBarra.Focus()
            Exit Sub
            Cnn.Close()
        End If

        Dim EstoqueAgora As Double = nzNUM(ds.Tables("Produtos").Rows(0)("QuantidadeEstoque"))

        If FormatNumber(CDbl(NzZero(Me.Qtd.Text)), 2) > FormatNumber(CDbl(EstoqueAgora), 2) Then
            MessageBox.Show("Quantidade sendo locada maior que a disponivel, verifique..." & Chr(13) & "Qauntidade Disponivel: " & FormatNumber(CDbl(EstoqueAgora), 2), "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cnn.Close()
            Me.CodBarra.Clear()
            Exit Sub
        End If



        Sql = "Select * From LocacaoItens where IdItem = -1"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim Da As New OleDbDataAdapter(Cmd)
        Da.Fill(ds, "LocacaoItens")


        If ds.Tables("LocacaoItens").Rows.Count = 0 Then

            Dim DRnovo As DataRow
            DRnovo = ds.Tables("LocacaoItens").NewRow

            DRnovo("IdLocacao") = nzINT(Me.IdLoc.Text)
            DRnovo("Produto") = nzINT(Me.CodBarra.Text)
            DRnovo("Qtd") = nzNUM(Me.Qtd.Text)

            'Pegar o valor unitario da locação definindo se o cliente é decorador ou se o produto esta na promoção
            Dim VlrLocUnitario As Double = nzNUM(ds.Tables("Produtos").Rows(0)("ValorVenda"))
            Dim VlrDesconto As Double = 0
            Dim VlrPromocao As Double = 0

            Dim tDesconto As Double = 0

            If Me.Decorador.Text = "S" Then
                VlrDesconto = nzNUM(ds.Tables("Produtos").Rows(0)("ValorVenda1"))
                If VlrDesconto > 0 Then
                    tDesconto = CDbl(VlrLocUnitario) - CDbl(VlrDesconto)
                End If

            Else
                VlrDesconto = nzNUM(0)
            End If

            If ds.Tables("Produtos").Rows(0)("ProdutoNaPromocao") = "S" Then
                VlrPromocao = nzNUM(ds.Tables("Produtos").Rows(0)("ValorPromocao"))
                tDesconto = CDbl(VlrLocUnitario) - CDbl(VlrPromocao)
            End If
            'Fim do processo descrito no comentario acima
            Dim VLocTotal As Double = FormatNumber((nzNUM(VlrLocUnitario) - nzNUM(tDesconto)) * nzNUM(Me.Qtd.Text), 2) 'Calcula o total da Locação

            DRnovo("ValorUnitarioLoc") = nzNUM(VlrLocUnitario)
            DRnovo("ValorDescontoLoc") = nzNUM(tDesconto)
            DRnovo("TotalLoc") = nzNUM(VLocTotal)
            DRnovo("DiariaAmais") = nzINT(NzZero(Me.DiariaAmais.Text))
            DRnovo("TotalDiarias") = nzNUM(CDbl(NzZero(VLocTotal)) * CDbl(NzZero(Me.DiariaAmais.Text)))
            DRnovo("QtdDev") = nzNUM(0)
            DRnovo("QtdAvarias") = nzNUM(0)
            DRnovo("ValorUnitarioAvarias") = nzNUM(0)
            DRnovo("TotalAvarias") = nzNUM(0)

            ds.Tables("LocacaoItens").Rows.Add(DRnovo)

            Try
                Dim ObjADD As New OleDbCommandBuilder(Da)
                Da.Update(ds, "LocacaoItens")
            Catch ex As Exception
                Cnn.Close()
                MessageBox.Show(ex.Message)
            End Try

        End If

        Cnn.Close()
        EncheListaItens()
        Me.CodBarra.Clear()
        Me.Qtd.Text = 1
        Me.CodBarra.Focus()


    End Sub

    Private Sub EncheListaItens()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT LocacaoItens.IdItem, LocacaoItens.IdLocacao, LocacaoItens.Produto, Produtos.Descrição, LocacaoItens.Qtd, LocacaoItens.ValorUnitarioLoc, LocacaoItens.ValorDescontoLoc, LocacaoItens.TotalDiarias,LocacaoItens.TotalLoc, LocacaoItens.QtdDev, LocacaoItens.QtdAvarias, LocacaoItens.ValorUnitarioAvarias, LocacaoItens.TotalAvarias FROM LocacaoItens INNER JOIN Produtos ON LocacaoItens.Produto = Produtos.CodigoProduto WHERE (((LocacaoItens.IdLocacao)=" & Me.IdLoc.Text & "))"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.tItens.Text = FormatNumber(NzZero(ds.Tables("Table").Compute("sum(TotalLoc)", "")), 2)
        Me.tDiariaAmais.Text = FormatNumber(NzZero(ds.Tables("Table").Compute("sum(TotalDiarias)", "")), 2)
        Me.tDesconto.Text = FormatNumber(NzZero(ds.Tables("Table").Compute("sum(ValorDescontoLoc)", "")), 2)
        If Me.StatusLoc.Text <> "LOCADO" Then
            Me.TotalLoc.Text = FormatNumber(CDbl(CDbl(NzZero(Me.tItens.Text)) + CDbl(NzZero(Me.tDiariaAmais.Text)) + CDbl(NzZero(Me.ValorFrete.Text)) - CDbl(NzZero(Me.tDesconto.Text))), 2)
        End If
        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub Lista_KeyDown(sender As Object, e As KeyEventArgs) Handles Lista.KeyDown

        If e.KeyCode = Keys.Delete Then

            If Me.StatusLoc.Text = "INICIAL" Then

                Dim Linha As Integer = Me.Lista.CurrentRow.Index

                'Deletar a Linha do banco de Dados


                'Fim da Area destinada para as validacoes

                Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
                CNN.Open()

                Dim ItemExcluir As Integer = Me.Lista.Rows(Linha).Cells("cIdItem").Value

                Dim Sql As String = "Delete From LocacaoItens Where IdItem = " & ItemExcluir
                Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

                Try
                    cmd.ExecuteNonQuery()
                    MsgBox("Registro Excluido com sucesso", 64, "Validação de Dados")
                    CNN.Close()
                    EncheListaItens()
                    Me.CodBarra.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message, 64, "Validação de Dados")
                End Try

            End If

        End If

    End Sub

    Private Sub CodBarra_Leave(sender As Object, e As EventArgs) Handles CodBarra.Leave

        If String.IsNullOrEmpty(Me.CodBarra.Text) Then
            Exit Sub
        End If

        AddProduto()
        Me.CodBarra.Focus()
    End Sub

    Private Sub Locacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FreteEncheLista()


        If CInt(IdSeletor) > 0 Then
            Me.IdLoc.Text = CInt(IdSeletor)
            AcharLocacao()

            Select Case StatusLoc.Text
                Case "LOCADO"
                    Me.btnEntregar.Enabled = True
                    Me.btnImprimir.Enabled = True
                Case "DEVOLVIDO"
                    Me.btnEntregar.Enabled = False
                    Me.btnImprimir.Enabled = True

                Case Else
                    Me.btnEntregar.Enabled = False
                    Me.btnImprimir.Enabled = False


            End Select


            If chkProdutosEntregue.Checked = False And Me.StatusLoc.Text = "LOCADO" Then
                Me.btnEntregar.Enabled = True
            Else

                Me.btnEntregar.Enabled = False
            End If


        Else
            Me.IdLoc.Text = "AUTO"
        End If
    End Sub

    Private Sub FreteEncheLista()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT Frete.*  FROM Frete WHERE Frete.Empresa =" & CodEmpresa


        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Frete.DataSource = ds.Tables("Table").DefaultView
        Me.Frete.DisplayMember = "DescricaoFrete"
        Me.Frete.ValueMember = "DescricaoFrete"
        Me.Frete.SelectedValue = -1

        'Carrega os dados da transportadora
        Sql = "SELECT *  FROM Transportadora WHERE Empresa =" & CodEmpresa
        da = New OleDbDataAdapter(Sql, Cnn)
        da.Fill(ds, "Transport")

        Me.cboTransportadora.DataSource = ds.Tables("Transport").DefaultView
        Me.cboTransportadora.DisplayMember = "RazãoTransportadora"
        Me.cboTransportadora.ValueMember = "codigo"
        Me.cboTransportadora.SelectedValue = -1

        'Carrega os dados vendedor
        Sql = "SELECT *  FROM Funcionários WHERE AdicionarEmVendas = True And Empresa =" & CodEmpresa
        da = New OleDbDataAdapter(Sql, Cnn)
        da.Fill(ds, "Vendedor")

        Me.cboVendedor.DataSource = ds.Tables("Vendedor").DefaultView
        Me.cboVendedor.DisplayMember = "Nome"
        Me.cboVendedor.ValueMember = "CódigoFuncionário"
        Me.cboVendedor.SelectedValue = -1



        da.Dispose()
        Cnn.Close()
    End Sub

    Private Sub Qtd_Leave(sender As Object, e As EventArgs) Handles Qtd.Leave

    End Sub

    Private Sub btConfirmarLocacao_Click(sender As Object, e As EventArgs) Handles btConfirmarLocacao.Click


        If String.IsNullOrEmpty(HoraLoc.Text) Or String.IsNullOrEmpty(HoraRetorno.Text) Then
            MessageBox.Show("Hora de Locação ou Hora de Retorno não podem ser nulos, favor verificar.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If Me.Lista.Rows.Count = 0 Then
            MessageBox.Show("Não ha itens locado para confirmar a locação, favor verificar", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If CDbl(NzZero(Me.TotalLoc.Text)) = 0 Then
            MessageBox.Show("Não pode confirmar uma locação com valor zero, favor verificar", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Me.StatusLoc.Text = "LOCADO" Then
            MessageBox.Show("Esta locação ja foi confirmada e não pode ser alterada, favor verificar", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Me.StatusLoc.Text = "DEVOLVIDO" Then
            MessageBox.Show("Esta locação ja foi devolvida e não pode ser alterada, favor verificar", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SalvarDadosIncial()

        'verificar se o caixa está ativo
        Dim cxFechado As New CaixaFechado
        cxFechado.CaixaEstaFechado()


        If Len(CaixaAtivo) <> 4 Then
            MessageBox.Show("O usuário deve selecionar um caixa antes de baixar o documento", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If MsgBox("Deseja Ativar o caixa agora", 36, "Validação de Dados") = 6 Then
                TRVDados(UserAtivo, "CaixaAtivarDesativar")
                If Ina = True Then
                    MsgBox("O usuário não esta autorizado a usar esta opção do sistema.", 64, "Validação de Dados")
                    Exit Sub
                Else
                    My.Forms.CaixaAtivarDesativar.ShowDialog()

                End If
            End If
            Exit Sub
        End If

        My.Forms.LocacaoConfirmar.ShowDialog()

    End Sub

    Private Sub Lista_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Lista.CellClick
        If (Me.Lista.Rows(e.RowIndex).Cells("cbtExcluir").Selected) Then

            If Me.StatusLoc.Text = "INICIAL" Then

                Dim Linha As Integer = Me.Lista.CurrentRow.Index

                'Deletar a Linha do banco de Dados


                'Fim da Area destinada para as validacoes

                Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
                CNN.Open()

                Dim ItemExcluir As Integer = Me.Lista.Rows(Linha).Cells("cIdItem").Value

                Dim Sql As String = "Delete From LocacaoItens Where IdItem = " & ItemExcluir
                Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

                Try
                    cmd.ExecuteNonQuery()
                    MsgBox("Registro Excluido com sucesso", 64, "Validação de Dados")
                    CNN.Close()
                    EncheListaItens()
                    Me.CodBarra.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message, 64, "Validação de Dados")
                End Try

            End If

        End If
    End Sub

    Private Sub DataLoc_Leave(sender As Object, e As EventArgs) Handles DataLoc.Leave, HoraLoc.Leave, DataRetorno.Leave, HoraRetorno.Leave, DiariaAmais.Leave, Frete.Leave, ValorFrete.Leave
        SalvarDadosIncial()
    End Sub


    Private Sub txtOutrosAjustes_Validated(sender As Object, e As EventArgs) Handles txtOutrosAjustes.Validated
        Dim dValor As Double = FormatNumber(((nzNUM(tItens.Text) + nzNUM(tDiariaAmais.Text) + nzNUM(ValorFrete.Text)) - nzNUM(Me.tDesconto.Text)), 2)
        Dim iValor As Double = dValor
        Dim dDesc As Double = Me.txtOutrosAjustes.Text
        Dim dRes As Double
        iValor = Decimal.Floor(dValor)

        dRes = (dDesc * 100) / dValor

        If (dRes > 10) Then
            'chamar a tela de permissão
            Autorizado = PedirPermissao(Me.Text, Me.IdLoc.Text)
            Autorizado = varAutorizado
            If Autorizado = False Then
                Me.txtOutrosAjustes.Text = "0,00"
                dDesc = 0
                Me.TotalLoc.Text = FormatCurrency((dValor - dDesc), 2)
                Exit Sub
            End If
            Me.TotalLoc.Text = FormatCurrency((dValor - dDesc), 2)
        Else
            Me.TotalLoc.Text = FormatCurrency((dValor - dDesc), 2)
        End If

        'If Convert.ToDouble(nzNUM(txtOutrosAjustes.Text)) = 0 Then
        '    Me.txtOutrosAjustes.Text = dValor - iValor
        '    Me.TotalLoc.Text = FormatCurrency(iValor, 2)
        'End If
    End Sub

    Private Sub txtOutrosAjustes_Leave(sender As Object, e As EventArgs) Handles txtOutrosAjustes.Leave

    End Sub

    Private Sub btnEntregar_Click(sender As Object, e As EventArgs) Handles btnEntregar.Click
        'controla a execução do estoque
        If chkProdutosEntregue.Checked = False And Me.StatusLoc.Text = "LOCADO" Then

            Me.Cursor = Cursors.WaitCursor

            Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()

            Dim Transacao As OleDbTransaction = CNN.BeginTransaction()

            Dim CmdLoc As OleDbCommand = CNN.CreateCommand

            Dim CmdEstoque As OleDbCommand = CNN.CreateCommand
            Dim CmdEstProd As OleDbCommand = CNN.CreateCommand
            Dim cmdAtualizaFechamento As OleDbCommand = CNN.CreateCommand()

            CmdLoc.Transaction = Transacao

            CmdEstoque.Transaction = Transacao
            CmdEstProd.Transaction = Transacao
            cmdAtualizaFechamento.Transaction = Transacao

            Try



                'Fazer o Lancamento na tabela EstoqueUP e atualização na tabela de Produtos
                CmdEstoque.CommandText = "INSERT INTO EstoqueUP (CodigoProduto, Qtd, Tipo, IdLancamento, DataLancamento, PedidoOrdem, Prg, ClienteFornecedor, NFDoc) SELECT LocacaoItens.Produto, [Qtd]*-1 AS QtdEst, 'L' AS Expr1, 0 AS Expr2, #" & CDate(DataDia) & "#, Locacao.IdLoc, 'LOCACAO' AS Expr3,'" & Me.ClienteNome.Text & "' AS Expr4, '" & Me.IdLoc.Text & "' As Expr5 FROM (LocacaoItens INNER JOIN Locacao ON LocacaoItens.IdLocacao = Locacao.IdLoc) INNER JOIN Produtos ON LocacaoItens.Produto = Produtos.CodigoProduto WHERE (((LocacaoItens.IdLocacao)=" & Me.IdLoc.Text & ") AND ((Locacao.Empresa)=" & CodEmpresa & ") AND ((Produtos.ControlaEstoque)='SIM'));"
                CmdEstoque.ExecuteNonQuery()


                'loop em cada item da lista 
                For Each row As DataGridViewRow In Me.Lista.Rows



                    CmdEstProd.CommandText = "SELECT Sum(EstoqueUP.Qtd) AS Estoque  FROM EstoqueUP WHERE (((EstoqueUP.CodigoProduto)=" & row.Cells("cProduto").Value & ") AND ((EstoqueUP.Tipo) NOT IN('E','S'))) GROUP BY EstoqueUP.CodigoProduto;"




                    Dim dEmLocacao As Double = FormatNumber(nzNUM(CmdEstProd.ExecuteScalar), 3)



                    CmdEstProd.CommandText = "SELECT Count(Qtd) AS QtdLoc FROM EstoqueUP GROUP BY EstoqueUP.CodigoProduto, EstoqueUP.Tipo HAVING (((EstoqueUP.[CodigoProduto])=" & row.Cells("cProduto").Value & ") AND ((EstoqueUP.Tipo)='L'));"
                    Dim tQTDLocacao As Double = FormatNumber(NzZero(CmdEstProd.ExecuteScalar), 3)


                    CmdEstProd.CommandText = "Update Produtos set EmLocacao = @1, QtdeLocado = @2 Where CodigoProduto = " & row.Cells("cProduto").Value
                    CmdEstProd.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUM(dEmLocacao)))
                    CmdEstProd.Parameters.Add(New OleDb.OleDbParameter("@2", nzNUM(tQTDLocacao)))
                    CmdEstProd.ExecuteNonQuery()
                    CmdEstProd.Parameters.Clear()

                Next
                'fim da rotina de atualização de estoque e tabela de produtos

                'Atualiza a loc para entrega
                CmdLoc.CommandText = "Update Locacao SET ProdutosEntregue = @ProdutosEntregue WHERE IdLoc = " & Me.IdLoc.Text
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@ProdutosEntregue", True))
                CmdLoc.ExecuteNonQuery()



                Transacao.Commit()
                Me.chkProdutosEntregue.Checked = True
                CNN.Close()

                'Fazer impressao de Documento aqui
                System.Threading.Thread.Sleep(2000)
                'RelatorioCarregar = "LocacaoContrato"
                'My.Forms.VisualizadorRelatorio.ShowDialog()
                'Fim
                Me.Cursor = Cursors.Default
                MessageBox.Show("Locação pronta para ser entregue", "Validação de dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Me.Dispose()

            Catch ex As Exception
                Transacao.Rollback()
                If ConnectionState.Open Then
                    CNN.Close()
                End If
                MsgBox("Erro ao salvar dados da locação.", 64, "Validação de Dados")
                MsgBox(ex.Message, 64, "Validação de Dados")
            End Try

        End If




    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        RelatorioCarregar = "LocacaoContratoCopia"
        My.Forms.VisualizadorRelatorio.ShowDialog()
    End Sub
End Class