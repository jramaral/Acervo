Imports System.Data.OleDb
Imports System.Linq
Imports controls.Locacao

Public Class LocacaoOrcamento


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByRef COD As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.IdLoc.Text = COD
        FreteEncheLista()
        AcharOrcamento(COD)


        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Dim vEstoque As Integer = 0
    Dim vDisponivel As Integer = 0
    Dim TotalDisponivel As Integer = 0
    Public Shared m_instace As LocacaoOrcamento
    Public sCod As String
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

    Private Sub AcharOrcamento(ByVal paramType As String)

        If Me.IdLoc.Text = "" Then Exit Sub

        Dim Sql As String = String.Empty

        Dim ds As New DataSet

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim VarCod As Integer = Me.IdLoc.Text
        Sql = "SELECT * FROM LocacaoOrcamento  WHERE (((LocacaoOrcamento.IdLoc)=" & paramType & "))"


        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim Da As New OleDbDataAdapter(Cmd)
        Da.Fill(ds, "LocacaoOrcamento")


        If ds.Tables("LocacaoOrcamento").Rows.Count = 1 Then

            Me.DataLoc.Text = ds.Tables("LocacaoOrcamento").Rows(0)("DataLoc") & ""
            Me.HoraLoc.Text = ds.Tables("LocacaoOrcamento").Rows(0)("HoraLoc") & ""
            Me.DataRetorno.Text = ds.Tables("LocacaoOrcamento").Rows(0)("DataRetorno") & ""
            Me.HoraRetorno.Text = ds.Tables("LocacaoOrcamento").Rows(0)("HoraRetorno") & ""

            Me.Frete.SelectedValue = ds.Tables("LocacaoOrcamento").Rows(0)("Frete")
            Me.ValorFrete.Text = NzZero(ds.Tables("LocacaoOrcamento").Rows(0)("ValorFrete"))

            Me.Cliente.Text = ds.Tables("LocacaoOrcamento").Rows(0)("Cliente") & ""
            Me.ClienteNome.Text = ds.Tables("LocacaoOrcamento").Rows(0)("NomeCliente") & ""

            Me.Telefone.Text = ds.Tables("LocacaoOrcamento").Rows(0)("Telefone") & ""

            Me.ObsLoc.Text = ds.Tables("LocacaoOrcamento").Rows(0)("ObsLoc") & ""
            Me.TotalLoc.Text = FormatNumber(NzZero(ds.Tables("LocacaoOrcamento").Rows(0)("TotalLoc")), 2)

            'adicionado por jose roberto
            Me.cboVendedor.SelectedValue = ds.Tables("LocacaoOrcamento").Rows(0)("CodigoVendedor")

            Me.txtcontato.Text = ds.Tables("LocacaoOrcamento").Rows(0)("Contato") & ""
            Me.chkTransformadoEmLocacao.Checked = ds.Tables("LocacaoOrcamento").Rows(0)("TransformadoEmLocacao")

        End If

        If (chkTransformadoEmLocacao.Checked = False) Then
            Me.btnCheckDisponibilidade.Enabled = True
        End If

        Cnn.Close()

        EncheListaItens()


    End Sub
    Private Sub EncheListaItens()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT LocacaoItensOrcamento.IdItem, LocacaoItensOrcamento.IdLocacao, LocacaoItensOrcamento.Produto, Produtos.Descrição, LocacaoItensOrcamento.Qtd, LocacaoItensOrcamento.ValorUnitarioLoc, LocacaoItensOrcamento.ValorDescontoLoc, LocacaoItensOrcamento.TotalDiarias,LocacaoItensOrcamento.TotalLoc, LocacaoItensOrcamento.Disponibilidade FROM LocacaoItensOrcamento INNER JOIN Produtos ON LocacaoItensOrcamento.Produto = Produtos.CodigoProduto WHERE (((LocacaoItensOrcamento.IdLocacao)=" & Me.IdLoc.Text & "))"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.tItens.Text = FormatNumber(NzZero(ds.Tables("Table").Compute("sum(TotalLoc)", "")), 2)
        Me.tDiariaAmais.Text = FormatNumber(NzZero(ds.Tables("Table").Compute("sum(TotalDiarias)", "")), 2)
        Me.tDesconto.Text = FormatNumber(NzZero(ds.Tables("Table").Compute("sum(ValorDescontoLoc)", "")), 2)
        Me.TotalLoc.Text = FormatNumber(CDbl(CDbl(NzZero(Me.tItens.Text)) + CDbl(NzZero(Me.tDiariaAmais.Text)) + CDbl(NzZero(Me.ValorFrete.Text)) - CDbl(NzZero(Me.tDesconto.Text))), 2)
        Me.Lista.DataSource = ds.Tables("Table").DefaultView



        da.Dispose()
        Cnn.Close()
        btnChangeToLocacao.Enabled = False
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

    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.DestroyHandle()
    End Sub

    Private Sub SalvarDadosIncial()


        Dim Sql As String = String.Empty

        Dim ds As New DataSet

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim VarCod As Integer = IIf(Me.IdLoc.Text = "AUTO", -1, Me.IdLoc.Text)
        Sql = "Select * From LocacaoOrcamento where IdLoc = " & VarCod

        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim Da As New OleDbDataAdapter(Cmd)
        Da.Fill(ds, "LocacaoOrcamento")


        'Verifica se esta cadastrando pela tela de locação
        If ds.Tables("LocacaoOrcamento").Rows.Count = 0 Then

            Dim DRnovo As DataRow
            DRnovo = ds.Tables("LocacaoOrcamento").NewRow

            DRnovo("DataLoc") = nzDAT(Me.DataLoc.Text)

            DRnovo("Cliente") = nzINT(Me.Cliente.Text)
            DRnovo("ObsLoc") = nzNUL(Me.ObsLoc.Text)
            DRnovo("TotalLoc") = nzNUM(Me.TotalLoc.Text)
            DRnovo("Empresa") = nzINT(CodEmpresa)
            ds.Tables("LocacaoOrcamento").Rows.Add(DRnovo)


            Try
                Dim ObjADD As New OleDbCommandBuilder(Da)
                Da.Update(ds, "LocacaoOrcamento")

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

            ds.Tables("LocacaoOrcamento").Rows(0).BeginEdit()

            ds.Tables("LocacaoOrcamento").Rows(0)("DataLoc") = nzDAT(Me.DataLoc.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("HoraLoc") = nzNUL(Me.HoraLoc.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("DataRetorno") = nzDAT(Me.DataRetorno.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("HoraRetorno") = nzNUL(Me.HoraRetorno.Text)

            ds.Tables("LocacaoOrcamento").Rows(0)("Frete") = nzNUL(Me.Frete.SelectedValue)
            ds.Tables("LocacaoOrcamento").Rows(0)("ValorFrete") = nzNUM(Me.ValorFrete.Text)

            ds.Tables("LocacaoOrcamento").Rows(0)("Cliente") = nzINT(Me.Cliente.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("NomeCliente") = nzNUL(Me.ClienteNome.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("ObsLoc") = nzNUL(Me.ObsLoc.Text)

            ds.Tables("LocacaoOrcamento").Rows(0)("TotalDiarias") = nzNUM(Me.tDiariaAmais.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("TotalItens") = nzNUM(Me.tItens.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("TotalDesconto") = nzNUM(Me.tDesconto.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("TotalLoc") = nzNUM(Me.TotalLoc.Text)
            'informações inseridas pelo jose roberto

            ds.Tables("LocacaoOrcamento").Rows(0)("Contato") = nzNUL(Me.txtcontato.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("NomeVendedor") = nzNUL(Me.cboVendedor.Text)
            ds.Tables("LocacaoOrcamento").Rows(0)("CodigoVendedor") = nzNUM(Me.cboVendedor.SelectedValue)

            If Not ds.Tables("LocacaoOrcamento").Rows(0)("StatusLoc").Equals("IMPRESS") Then
                ds.Tables("LocacaoOrcamento").Rows(0)("StatusLoc") = "IMPRESS"
                ds.Tables("LocacaoOrcamento").Rows(0)("DataFechamento") = nzDAT(DataDia)
            End If

            ds.Tables("LocacaoOrcamento").Rows(0).EndEdit()


            Try
                Dim ObjEDD As New OleDbCommandBuilder(Da)
                Da.Update(ds, "LocacaoOrcamento")
                Cnn.Close()


            Catch ex As Exception
                Cnn.Close()
                MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Private Sub BtConfirmarLocacao_Click(sender As Object, e As EventArgs) Handles btConfirmarLocacao.Click
        SalvarDadosIncial()
        RelatorioCarregar = "LocacaoOrcamento"
        Dim f As New VisualizadorRelatorio(Me.IdLoc.Text)
        f.ShowDialog()
    End Sub

    Private Sub BtnCheckDisponibilidade_Click(sender As Object, e As EventArgs) Handles btnCheckDisponibilidade.Click
        If CDate(DataRetorno.Text) <= DataDia Or CDate(DataLoc.Text) < DataDia Then
            MessageBox.Show("Este Orçamento não pode ser transformado, pois  as datas divergem com a data do dia!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        End If
        VerLocacoes()
        btnChangeToLocacao.Enabled = True
    End Sub


    Private Sub VerLocacoes()






        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim consultaEstoque As New ControlsEstoque(Cnn)

        Dim res As List(Of ControlsLocacao)

        ' Me.Lista.DataSource = res

        'Cnn.Close()

        Dim icount As Integer = Lista.RowCount
        Dim iNaoDisponivel As Integer = 0
        Dim cDisponivel As Integer = 0
        Dim i As Integer = 0
        Dim Estoque As Integer = 0
        For Each row As DataGridViewRow In Me.Lista.Rows


            res = consultaEstoque.VerLocacoes(row.Cells("cProduto").Value)

            If res.Count > 0 Then


                Estoque = res(0).QuantidadeEstoque 'Pega o estoque atual do produto pesquisado
                i = 0
                iNaoDisponivel = 0
                cDisponivel = 0

                While i < res.Count 'Enquanto i for menor que a quantidade de objetos, faça!

                    If (CDate(Me.DataLoc.Text) < CDate(res(i).DataLoc) And CDate(Me.DataRetorno.Text) < CDate(res(i).DataLoc)) Then
                        'disponibiliza
                        cDisponivel = res(i).Qtd
                    Else
                        If (CDate(Me.DataLoc.Text) < CDate(CDate(res(i).DataLoc)) And (CDate(Me.DataRetorno.Text) >= CDate(res(i).DataRetorno))) Then
                            'não disponibiliza
                            cDisponivel = 0

                            iNaoDisponivel += res(i).Qtd
                        Else
                            If (CDate(Me.DataLoc.Text) >= CDate(res(i).DataLoc) And (CDate(Me.DataLoc.Text) <= CDate(res(i).DataRetorno))) Then
                                'não disponibiliza
                                cDisponivel = 0
                                iNaoDisponivel += res(i).Qtd
                            Else
                                If (CDate(Me.DataLoc.Text) < CDate(res(i).DataLoc) And (CDate(Me.DataRetorno.Text) <= CDate(res(i).DataRetorno))) Then
                                    'não disponibiliza
                                    cDisponivel = 0
                                    iNaoDisponivel += res(i).Qtd
                                Else
                                    cDisponivel = res(i).Qtd

                                End If

                            End If

                        End If
                    End If


                    i = i + 1
                End While

                TotalDisponivel = CInt(Estoque) - iNaoDisponivel

                If (TotalDisponivel <= 0 Or TotalDisponivel < row.Cells("cQtd").Value) Then
                    'Marcar a coluna "Disponivel" como N
                    row.Cells("cDisponibilidade").Value = "N"

                    row.DefaultCellStyle.Font = New Font(Lista.Font, FontStyle.Strikeout)
                    consultaEstoque.MarcarDisponibilidade("N", row.Cells("cIdItem").Value)
                    consultaEstoque.AtualizarRegistro(DataLoc.Text, DataRetorno.Text, IdLoc.Text)
                'Else
                '    row.Cells("cDisponibilidade").Value = ""

                '    row.DefaultCellStyle.Font = New Font(Lista.Font, FontStyle.Regular)
                '    consultaEstoque.MarcarDisponibilidade("", row.Cells("cIdItem").Value)
                '    consultaEstoque.AtualizarRegistro(DataLoc.Text, DataRetorno.Text, IdLoc.Text)
                End If
            End If
        Next

    End Sub


    Private Sub LocacaoOrcamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_instace = Me
        Me.Qtd.Enabled = True

        For Each row As DataGridViewRow In Lista.Rows
            If Convert.ToString(row.Cells("cDisponibilidade").Value) = "N" Then
                row.DefaultCellStyle.Font = New Font(Lista.Font, FontStyle.Strikeout)
            End If
        Next

    End Sub

    Private Sub BtnChangeToLocacao_Click(sender As Object, e As EventArgs) Handles btnChangeToLocacao.Click


        If String.IsNullOrEmpty(Me.Cliente.Text) Or Me.Cliente.Text = 0 Then
            MessageBox.Show("Este cliente não está cadastrado." _
                            & Microsoft.VisualBasic.ControlChars.CrLf & "Cadastre o cliente em Menul Geral -> Clientes.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
        End If

        'checar disponibilidade dos produtos
        VerLocacoes()


        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()


        Dim Transacao As OleDbTransaction = CNN.BeginTransaction()

        Dim CmdLoc As OleDbCommand = CNN.CreateCommand
        Dim CmdItem As OleDbCommand = CNN.CreateCommand
        Dim cmdOrc As OleDbCommand = CNN.CreateCommand()

        Dim consultaEstoque As New ControlsEstoque(CNN)

        CmdLoc.Transaction = Transacao
        CmdItem.Transaction = Transacao
        cmdOrc.Transaction = Transacao

        Try

            cmdOrc.CommandText = String.Format("Update LocacaoOrcamento SET TransformadoEmLocacao={0}, Cliente={1}, NomeCliente='{2}' Where IdLoc={3}", True, Me.Cliente.Text, Me.ClienteNome.Text, Me.IdLoc.Text)
            cmdOrc.ExecuteNonQuery()

            'Salva Dados Adicionais do Pedido de Locação e muda o Status para locado


            CmdLoc.CommandText = "INSERT INTO Locacao ( DataLoc, HoraLoc, DataRetorno, HoraRetorno, Frete, Cliente, ValorFrete, TotalItens, TotalDesconto, TotalDiarias, TotalAvarias, TotalLoc, Empresa, Contato, CodigoVendedor, NumeroOrcamento )" _
                                & "SELECT LocacaoOrcamento.DataLoc, LocacaoOrcamento.HoraLoc, LocacaoOrcamento.DataRetorno, LocacaoOrcamento.HoraRetorno, LocacaoOrcamento.Frete, LocacaoOrcamento.Cliente, LocacaoOrcamento.ValorFrete, LocacaoOrcamento.TotalItens, " _
                                & "LocacaoOrcamento.TotalDesconto, LocacaoOrcamento.TotalDiarias, LocacaoOrcamento.TotalAvarias, LocacaoOrcamento.TotalLoc, LocacaoOrcamento.Empresa, LocacaoOrcamento.Contato, LocacaoOrcamento.CodigoVendedor, LocacaoOrcamento.IdLoc" _
                                & " FROM LocacaoOrcamento" _
                                & " WHERE (((LocacaoOrcamento.IdLoc)=" & Me.IdLoc.Text & "));"




            CmdLoc.ExecuteNonQuery()

            CmdLoc.CommandText = "SELECT idLoc From Locacao Where NumeroOrcamento=" & Me.IdLoc.Text
            Dim IDLoc As Integer = CmdLoc.ExecuteScalar.ToString

            If (consultaEstoque.ValidarItemOrcamento(Me.IdLoc.Text, Transacao) > 0) Then



                CmdItem.CommandText = "INSERT INTO LocacaoItens ( Produto, Qtd, DiariaAmais, ValorUnitarioLoc, ValorDescontoLoc, TotalDiarias, TotalLoc, QtdDev, QtdAvarias, ValorUnitarioAvarias, TotalAvarias, IdLocacao )" _
                                 & " SELECT LocacaoItensOrcamento.Produto, LocacaoItensOrcamento.Qtd, LocacaoItensOrcamento.DiariaAmais, LocacaoItensOrcamento.ValorUnitarioLoc, LocacaoItensOrcamento.ValorDescontoLoc, LocacaoItensOrcamento.TotalDiarias, LocacaoItensOrcamento.TotalLoc, LocacaoItensOrcamento.QtdDev," _
                                 & " LocacaoItensOrcamento.QtdAvarias, LocacaoItensOrcamento.ValorUnitarioAvarias, LocacaoItensOrcamento.TotalAvarias, " & IDLoc & "" _
                                 & " FROM LocacaoItensOrcamento" _
                                 & " WHERE (((LocacaoItensOrcamento.IdLocacao)=" & Me.IdLoc.Text & ") AND ((LocacaoItensOrcamento.Disponibilidade) Is Null));"
                CmdItem.ExecuteNonQuery()


                Transacao.Commit()
                CNN.Close()

                Me.chkTransformadoEmLocacao.Checked = True
                Me.btnChangeToLocacao.Enabled = False

                My.Forms.Locacao.IniciarPeloSeletor = IDLoc
                My.Forms.Locacao.ShowDialog()

                Me.Close()
                Me.Dispose()


            Else
                Transacao.Rollback()

                MessageBox.Show("Não há item com disponibilidade para ser locado", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If



        Catch ex As Exception
            Transacao.Rollback()
            If ConnectionState.Open Then
                CNN.Close()
            End If
            MsgBox("Erro ao salvar dados da locação.", 64, "Validação de Dados")
            MsgBox(ex.Message, 64, "Validação de Dados")
        End Try


    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim f As New LocacaoClientesProcura
        If Me.chkTransformadoEmLocacao.Checked = True Then
            MessageBox.Show("Este orçamento já foi transformado em Locação, não pode ser alterado")
            Exit Sub
        Else
            f.ShowDialog()
            'My.Forms.LocacaoClientesProcura.ShowDialog()
            ' AcharCliente()
            Me.ClienteNome.Text = f.xCliente.Text
            Me.Telefone.Text = f.xTelefone.Text
            Me.Cliente.Text = f.ID.Text

        End If
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

            Me.ClienteNome.Text = DR.Item("Nome") & ""
            Me.Telefone.Text = DR.Item("Telefone") & ""



        End If

        DR.Close()
        CnnFind.Close()
    End Sub

    Private Sub Lista_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Lista.CellClick
        If (Me.Lista.Rows(e.RowIndex).Cells("cbtExcluir").Selected) Then



            Dim Linha As Integer = Me.Lista.CurrentRow.Index

            'Deletar a Linha do banco de Dados


            'Fim da Area destinada para as validacoes

            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()

            Dim ItemExcluir As Integer = Me.Lista.Rows(Linha).Cells("cIdItem").Value

            Dim Sql As String = "Delete From LocacaoItensOrcamento Where IdItem = " & ItemExcluir
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro Excluido com sucesso", 64, "Validação de Dados")
                btnChangeToLocacao.Enabled = False
                CNN.Close()
                EncheListaItens()
                Me.CodBarra.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Validação de Dados")
            End Try

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



        'verificar se já foi inserido o produto nos itens selecionados
        For Each r As DataGridViewRow In Lista.Rows
            If r.Cells("cProduto").Value = Me.CodBarra.Text Then
                MessageBox.Show("Este produto já foi selecionado. Remova-o da lista para adicionar novamente", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next




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

        If CDbl(NzZero(Me.Qtd.Text)) > CDbl(EstoqueAgora) Then
            MessageBox.Show("Quantidade sendo locada maior que a disponivel, verifique..." & Chr(13) & "Qauntidade Disponivel: " & FormatNumber(CDbl(EstoqueAgora), 2), "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cnn.Close()
            Me.Qtd.Clear()
            Me.CodBarra.Focus()

            Exit Sub
        End If


        Sql = "Select * From LocacaoItensOrcamento where IdItem = -1"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim Da As New OleDbDataAdapter(Cmd)
        Da.Fill(ds, "LocacaoItensOrcamento")


        If ds.Tables("LocacaoItensOrcamento").Rows.Count = 0 Then

            Dim DRnovo As DataRow
            DRnovo = ds.Tables("LocacaoItensOrcamento").NewRow

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
                tDesconto = CDbl(VlrLocUnitario) - CDbl(VlrDesconto)
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
            'DRnovo("DiariaAmais") = nzINT(NzZero(Me.DiariaAmais.Text))
            'DRnovo("TotalDiarias") = nzNUM(CDbl(NzZero(VLocTotal)) * CDbl(NzZero(Me.DiariaAmais.Text)))
            DRnovo("QtdDev") = nzNUM(0)
            DRnovo("QtdAvarias") = nzNUM(0)
            DRnovo("ValorUnitarioAvarias") = nzNUM(0)
            DRnovo("TotalAvarias") = nzNUM(0)

            ds.Tables("LocacaoItensOrcamento").Rows.Add(DRnovo)

            Try
                Dim ObjADD As New OleDbCommandBuilder(Da)
                Da.Update(ds, "LocacaoItensOrcamento")
            Catch ex As Exception
                Cnn.Close()
                MessageBox.Show(ex.Message)
            End Try

        End If

        Cnn.Close()
        Me.CodBarra.Clear()
        Me.Qtd.Clear()
        Me.CodBarra.Focus()
        EncheListaItens()


    End Sub
    Private Sub CodBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles CodBarra.KeyDown
        Dim f As New LocacaoProdutoProcura(Me.Name)

        If e.KeyCode = Keys.F5 Then
            f.ShowDialog()

            If String.IsNullOrEmpty(Me.CodBarra.Text) Then
                Exit Sub
            End If
            'Me.CodBarra.Focus()
        End If


        'Dim f1 As New LocacaoSeletor

        ''desabilita botoes
        'f1.Panel1.Enabled=False
        'f1.btnCriarOrcamento.Enabled=false
        'f1.btCriarLocacao.Enabled=false
        'f1.ListaSelecionados.Enabled=false

        ''envia os dados do orcamento
        'f1.CodVendedor.Text=cboVendedor.SelectedValue
        'f1.VendedorNome.Text=cboVendedor.Text
        'f1.DataLoc.Text=DataLoc.Text
        'f1.HoraLoc.Text=HoraLoc.Text
        'f1.DataRetorno.Text=DataRetorno.Text
        'f1.HoraRetorno.Text=HoraRetorno.Text
        'f1.ShowDialog()

    End Sub

    Private Sub CodBarra_Leave(sender As Object, e As EventArgs) Handles CodBarra.Leave
        btnChangeToLocacao.Enabled = False


    End Sub

    Private Sub Qtd_Leave(sender As Object, e As EventArgs) Handles Qtd.Leave
        AddProduto()
    End Sub

    Private Sub DataLoc_Validated(sender As Object, e As EventArgs) Handles DataLoc.Validated
        If String.IsNullOrEmpty(DataLoc.Text) Then
            DataLoc.Text = DataDia
        End If

    End Sub

    Private Sub DataLoc_Leave(sender As Object, e As EventArgs) Handles DataLoc.Leave
        If IsDate(Me.DataLoc.Text) Then
            btnChangeToLocacao.Enabled = False
            Me.DataRetorno.Text = CDate(Me.DataLoc.Text).AddDays(2)
        End If
    End Sub

    Private Sub DataRetorno_Validated(sender As Object, e As EventArgs) Handles DataRetorno.Validated
        If CDate(Me.DataRetorno.Text) < CDate(Me.DataLoc.Text) Then
            MessageBox.Show("A data de retorno não pode ser menor que a data de locação, verifique...", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DataRetorno.Text = CDate(Me.DataLoc.Text).AddDays(2)
        End If
        If CDate(Me.DataLoc.Text) < CDate(DataDia) Then
            MessageBox.Show("A data de Locacao não pode ser menor que a data do dia, verifique...", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Me.DataRetorno.Text = CDate(Me.DataLoc.Text).AddDays(2)
        End If

    End Sub

    Private Sub DataLoc_TextChanged(sender As Object, e As EventArgs) Handles DataLoc.TextChanged

    End Sub

    Private Sub Frete_Leave(sender As Object, e As EventArgs) Handles Frete.Leave
        If Me.Frete.Text <> "" Then
            AchaValorFrete()
        Else
            Me.ValorFrete.Text = FormatNumber(0, 2)

        End If


        Dim dValor As Double = FormatNumber(((nzNUM(tItens.Text) + nzNUM(tDiariaAmais.Text) + nzNUM(ValorFrete.Text)) - nzNUM(Me.tDesconto.Text)), 2)
       ' Dim dDesc As Double = Me.txtOutrosAjustes.Text

        Me.TotalLoc.Text = FormatCurrency((dValor), 2)


    End Sub
End Class