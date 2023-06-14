Imports System.Data.OleDb
Imports controls.Locacao
Imports DevComponents.DotNetBar

Public Class LocacaoSeletor
    'Dim _f as LocacaoOrcamento
    'Public Sub New(ByRef frm As LocacaoOrcamento)
    '    InitializeComponent()
    '    _f=frm
    'End Sub

    Public Selecionados As New DataTable
    Public ValorReposicao As Double = 0
    Public iNdisponivel As Integer = 0

    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub LocacaoSeletor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        
        
        'ao iniciar a tela criar colunas no datatable selecionados
        Selecionados.Columns.Add("LinhaId", Type.GetType("System.Int32"))
        Selecionados.Columns("LinhaId").AutoIncrement = True
        Selecionados.Columns("LinhaId").AutoIncrementSeed = 1

        Selecionados.Columns.Add("ProdutoCod", Type.GetType("System.Int32"))
        Selecionados.Columns.Add("ProdutoNome", Type.GetType("System.String"))
        Selecionados.Columns.Add("ProdutoQtd", Type.GetType("System.Double"))
        Selecionados.Columns.Add("ProdutoUnitario", Type.GetType("System.Double"))
        Selecionados.Columns.Add("ProdutoTotal", Type.GetType("System.Double"))
        Selecionados.Columns.Add("ProdutoTotalDiaria", Type.GetType("System.Double"))
        Selecionados.Columns.Add("ProdutoUnitarioDecorador", Type.GetType("System.Double"))
        Selecionados.Columns.Add("ProdutoUnitarioPromocao", Type.GetType("System.Double"))
        Selecionados.Columns.Add("ValorVenda2", Type.GetType("System.Double"))

        Dim keys(1) As DataColumn
        keys(0) = Selecionados.Columns("LinhaId")
        Selecionados.PrimaryKey = keys

        Me.ListaSelecionados.DataSource = Selecionados

        FreteEncheLista()
        'fim
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

        da.Dispose()
        Cnn.Close()
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

    Private Sub AcharCliente()

        If String.IsNullOrEmpty(Me.CodCliente.Text) Then
            Exit Sub
        End If

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT *  FROM Clientes WHERE Codigo = " & CInt(Me.CodCliente.Text)


        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        If ds.Tables("Table").Rows.Count = 1 Then
            Me.Decorador.Text = ds.Tables("Table").Rows(0)("Decorador")
        End If

        da.Dispose()
        Cnn.Close()

    End Sub


    Private Sub VendedorFind()

        If Me.CodVendedor.Text = "" Then Exit Sub

        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Cmd As New OleDbCommand()
        Dim DR As OleDbDataReader
        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "Select * From Funcionários Where CódigoFuncionário = " & Me.CodVendedor.Text & " And AdicionarEmVendas = True"
            .CommandType = CommandType.Text
        End With

        Try
            DR = Cmd.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                Me.VendedorNome.Text = DR.Item("Nome") & ""
            Else
                MessageBox.Show("Não foi encontrado este vendedor, favor informar outro", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CodVendedor.Clear()
                Me.VendedorNome.Clear()
                Me.CodVendedor.Focus()
                Exit Sub
            End If
            DR.Close()

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
        End Try

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        My.Forms.PedidoVendaFindVendedores.ShowDialog()
        Me.CodVendedor.Focus()
        VendedorFind()

    End Sub

    Private Sub CodVendedor_Leave(sender As Object, e As EventArgs) Handles CodVendedor.Leave
        If String.CompareOrdinal(Me.CodVendedor.Text, Me.CodVendedor.TextoAntigo) Then
            VendedorFind()
        End If
    End Sub

    Private Sub CodProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles CodProduto.KeyDown
        Dim f As New LocacaoProdutoProcura(Me)
        If e.KeyCode = Keys.F5 Then
            If Me.CodProduto.Text = "" Then
                f.ShowDialog()
                LocalizaProduto()
            End If
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.CodProduto.Clear()
        Me.ProdutoNome.Clear()
        Dim f As New LocacaoProdutoProcura(Me)
        f.ShowDialog()
        LocalizaProduto()

    End Sub


    Public Sub LocalizaProduto()
        ValorReposicao = 0

        If Me.CodProduto.Text = "" Then
            Exit Sub
        End If


        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "Select * from Produtos where CodigoProduto = " & Me.CodProduto.Text & " And Inativo = False and Tipo=1 and Empresa = " & CodEmpresa
        Dim CMD As New OleDbCommand(Sql, CNN)
        Dim DR As OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows = True Then
            Me.ProdutoNome.Text = DR.Item("Descrição") & ""
            Me.UnitarioLoc.Text = FormatNumber(NzZero(DR.Item("ValorVenda")), 2)
            Me.UnitarioLocDecorador.Text = FormatNumber(NzZero(DR.Item("ValorVenda1")), 2)
            Me.Promocao.Text = DR.Item("ProdutoNaPromocao") & ""
            Me.UnitarioLocPromocao.Text = FormatNumber(NzZero(DR.Item("ValorPromocao")), 2)
            ValorReposicao = FormatNumber(NzZero(DR.Item("ValorVenda2")), 2)
            Me.Em_Estoque.Text = nzNUM(DR.Item("QuantidadeEstoque"))
            iNdisponivel = nzNUM(DR.Item("EmLocacao"))
            SerLiberado.Text = iNdisponivel
        Else
            MsgBox("Item não encontrado, verifique....", 64, "Validação de Dados")
            ValorReposicao = 0
            Me.CodProduto.Focus()
            CNN.Close()
            Exit Sub
        End If
        CNN.Close()

        'verEmEstoque()
        VerLocacoes(CodProduto.Text)

    End Sub

    Private Sub CodProduto_Leave(sender As Object, e As EventArgs) Handles CodProduto.Leave

        If not string.IsNullOrEmpty(DataLoc.text) And not string.IsNullOrEmpty(DataRetorno.Text) And Not String.IsNullOrEmpty(CodVendedor.Text) Then
            LocalizaProduto()
        End If
       
    End Sub

    Private Sub VerEmEstoque()


        If Me.CodProduto.Text = "" Then Exit Sub


        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim consultaEstoque As New ControlsEstoque(Cnn)

        consultaEstoque.VerEmEstoque(Me.CodProduto.Text)

        Cnn.Close()

        Me.Em_Estoque.Text = consultaEstoque.QtdEstoque

    End Sub

    Public Sub VerLocacoes(codP As String)

        If String.IsNullOrEmpty(codP) Then
            codP = 0
        End If
        'If Me.DataLoc.Text = "" Then Exit Sub

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim consultaEstoque As New ControlsEstoque(Cnn)

        Dim res As Object = consultaEstoque.VerLocacoes(codP)

        Me.Lista.DataSource = res

        Cnn.Close()

        Dim icount As Integer = Me.Lista.RowCount
        Dim iNaoDisponivel As Integer = 0

        For Each row As DataGridViewRow In Me.Lista.Rows


            If (CDate(Me.DataLoc.Text) < CDate(row.Cells("cDataLoc").Value) And CDate(Me.DataRetorno.Text) < CDate(row.Cells("cDataLoc").Value)) Then
                'disponibiliza
                row.Cells("cDisponivel").Value = row.Cells("cQtd").Value
                row.Cells("cStatus").Value = "LIVRE"
                row.DefaultCellStyle.ForeColor = Color.Green
                'row.Cells("cDisponivel").Value = 0
                'row.Cells("cStatus").Value = "OCUPADO"
                'row.DefaultCellStyle.ForeColor = Color.Red
            Else
                If (CDate(Me.DataLoc.Text) < CDate(row.Cells("cDataLoc").Value) And (CDate(Me.DataRetorno.Text) >= CDate(row.Cells("cDataRetorno").Value))) Then
                    'não disponibiliza
                    row.Cells("cDisponivel").Value = 0
                    row.Cells("cStatus").Value = "OCUPADO"
                    row.DefaultCellStyle.ForeColor = Color.Red
                    iNaoDisponivel += row.Cells("cQtd").Value
                Else
                    If (CDate(Me.DataLoc.Text) >= CDate(row.Cells("cDataLoc").Value) And (CDate(Me.DataLoc.Text) <= CDate(row.Cells("cDataRetorno").Value))) Then
                        'não disponibiliza
                        row.Cells("cDisponivel").Value = 0
                        row.Cells("cStatus").Value = "OCUPADO"
                        row.DefaultCellStyle.ForeColor = Color.Red
                        iNaoDisponivel += row.Cells("cQtd").Value
                    Else
                        If (CDate(Me.DataLoc.Text) < CDate(row.Cells("cDataLoc").Value) And (CDate(Me.DataRetorno.Text) <= CDate(row.Cells("cDataRetorno").Value))) Then
                            'não disponibiliza
                            row.Cells("cDisponivel").Value = 0
                            row.Cells("cStatus").Value = "OCUPADO"
                            row.DefaultCellStyle.ForeColor = Color.Red
                            iNaoDisponivel += row.Cells("cQtd").Value
                        Else
                            row.Cells("cDisponivel").Value = row.Cells("cQtd").Value
                            row.Cells("cStatus").Value = "LIVRE"
                            row.DefaultCellStyle.ForeColor = Color.Green
                        End If

                    End If

                End If
            End If



        Next

        Dim TotalDisponivel As Double
        For Each Linha As DataGridViewRow In Me.Lista.Rows
            TotalDisponivel += Linha.Cells("cDisponivel").Value
        Next

        Dim Estoque As Integer = CInt(Me.Em_Estoque.Text)


        If TotalDisponivel > Estoque Then
            Total_Disponivel.Text = 0
        Else
            Total_Disponivel.Text = CInt(Estoque) - CInt(iNaoDisponivel)
        End If

        Me.SerLiberado.Text = CInt(iNaoDisponivel)
        If (CInt(Estoque) - CInt(iNaoDisponivel) < 0) Then
            Total_Disponivel.Text = 0
        Else
            Me.Total_Disponivel.Text = CInt(Estoque) - CInt(iNaoDisponivel)
        End If

        'Me.Total_Disponivel.Text = CInt(Estoque) - CInt(iNaoDisponivel)

    End Sub



    Private Sub HoraLoc_Leave(sender As Object, e As EventArgs) Handles HoraLoc.Leave
        If Not String.IsNullOrEmpty(Me.HoraLoc.Text) Then
            If Not IsDate(Me.HoraLoc.Text) Then
                MessageBox.Show("Favor digitar uma hora valida no formato, 00:00:00", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.HoraLoc.Focus()
            Else
                If Me.HoraRetorno.Text = "" Then
                    Me.HoraRetorno.Text = Me.HoraLoc.Text
                End If
            End If
        End If
    End Sub

    Private Sub HoraRetorno_Leave(sender As Object, e As EventArgs) Handles HoraRetorno.Leave
        If Not String.IsNullOrEmpty(Me.HoraRetorno.Text) Then
            If Not IsDate(Me.HoraRetorno.Text) Then
                MessageBox.Show("Favor digitar uma hora valida no formato, 00:00:00", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.HoraRetorno.Focus()
            End If
        End If
    End Sub

    Private Sub BtAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click

        If Me.CodProduto.Text = "" Then
            MessageBox.Show("Digite o código do produto.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        If CInt(Me.Total_Disponivel.Text) <= CInt(0) Then
            MessageBox.Show("O usuario não pode adicionar um produto com disponiblidade menor ou igual a ZERO.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'verificar se já foi inserido o produto nos itens selecionados
        For Each r As DataGridViewRow In ListaSelecionados.Rows
            If r.Cells("cProdutoCod").Value = Me.CodProduto.Text Then
                MessageBox.Show("Este produto já foi selecionado. Remova-o da lista de selecionados para adicionar novamente", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next



        Dim f As New SeletorAddItem(CInt(Total_Disponivel.Text))
        f.ShowDialog()

        Me.ListaSelecionados.Update()



        Dim Total_dos_ItensLocado As Double = 0
        Dim Total_Diaria As Double = 0

        For Each Linha As DataGridViewRow In Me.ListaSelecionados.Rows
            Total_dos_ItensLocado += Linha.Cells("cProdutoTotal").Value
            Total_Diaria += Linha.Cells("cProdutoTotalDiaria").Value
        Next
        Me.TotalOrcado.Text = FormatNumber(Total_dos_ItensLocado + Total_Diaria + CDbl(NzZero(Me.ValorFrete.Text)), 2)

        Me.CodProduto.Focus()
        CodProduto.Clear()
        ProdutoNome.Clear()
        Em_Estoque.Text = 0
        SerLiberado.Text = 0
        Total_Disponivel.Text = 0

        If ListaSelecionados.RowCount > 0 Then
            panelDatas.Enabled = False
        Else
            panelDatas.Enabled = True
        End If
        
        VerLocacoes(CodProduto.text)



    End Sub

    Private Sub DataLoc_Validated(sender As Object, e As EventArgs) Handles DataLoc.Validated
        If Not String.IsNullOrEmpty(Me.DataLoc.Text) Then
            If CDate(Me.DataLoc.Text) < CDate(DataDia) Then
                MessageBox.Show("A data de locação não pode ser menor que a data do dia, verifique...", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DataLoc.Clear()
                Me.DataLoc.Focus()
            End If
        End If

    End Sub

    Private Sub DataRetorno_Validated(sender As Object, e As EventArgs) Handles DataRetorno.Validated
        If String.IsNullOrEmpty(Me.DataRetorno.Text) Then Exit Sub

        If CDate(Me.DataRetorno.Text) < CDate(Me.DataLoc.Text) Then
            MessageBox.Show("A data de retorno não pode ser menor que a data de locação, verifique...", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DataRetorno.Clear()
            Me.DataRetorno.Focus()
        End If
    End Sub

    Private Sub BtCriarLocacao_Click(sender As Object, e As EventArgs) Handles btCriarLocacao.Click

        If String.IsNullOrEmpty(Me.CodCliente.Text) Then
            Dim f As New LocacaoClientesProcura(Me)
            f.ShowDialog()
            Me.CodCliente.Text = f.ID.Text
            AcharCliente()
            If String.IsNullOrEmpty(Me.CodCliente.Text) Then
                MessageBox.Show("O Usuário deve informar um cliente para fazer a Locação", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If


        If String.IsNullOrEmpty(Me.CodVendedor.Text) Then
            MessageBox.Show("O usuário deve informar um vendedor para gerar a Locação.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.DataLoc.Text) Then
            MessageBox.Show("O usuário deve informar a data de Locação.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.HoraLoc.Text) Then
            MessageBox.Show("O usuário deve informar a hora de Locação.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.DataRetorno.Text) Then
            MessageBox.Show("O usuário deve informar a data de Retorno.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.HoraRetorno.Text) Then
            MessageBox.Show("O usuário deve informar a hora de retorno.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Me.ListaSelecionados.RowCount = 0 Then
            MessageBox.Show("Não foi informado nenhum item para ser locado, favor verificar...", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Transacao As OleDbTransaction = CNN.BeginTransaction()

        Dim CmdLoc As OleDbCommand = CNN.CreateCommand
        Dim CmdItem As OleDbCommand = CNN.CreateCommand

        CmdLoc.Transaction = Transacao
        CmdItem.Transaction = Transacao

        Try

            'Salva Dados Adicionais do Pedido de Locação e muda o Status para locado


            CmdLoc.CommandText = "Insert Into Locacao (DataLoc,HoraLoc,DataRetorno,HoraRetorno,StatusLoc,Cliente,ObsLoc,Empresa,Frete,ValorFrete,DiariaAmais,CodigoVendedor,NomeVendedor) Values (@DataLoc,@HoraLoc,@DataRetorno,@HoraRetorno,@StatusLoc,@Cliente,@ObsLoc,@Empresa,@Frete,@ValorFrete,@DiariaAmais,@CodigoVendedor,@NomeVendedor)"

            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@DataLoc", nzDAT(Me.DataLoc.Text)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@HoraLoc", nzNUL(Me.HoraLoc.Text)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@DataRetorno", nzDAT(Me.DataRetorno.Text)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@HoraRetorno", nzNUL(Me.HoraRetorno.Text)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@StatusLoc", nzNUL("INICIAL")))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@Cliente", nzINT(Me.CodCliente.Text)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@ObsLoc", nzNUL(System.DBNull.Value)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@Empresa", nzINT(CodEmpresa)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@Frete", nzNUL(Me.Frete.SelectedValue)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@ValorFrete", nzNUM(Me.ValorFrete.Text)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@DiariaAmais", nzINT(Me.DiariaAmais.Text)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@CodigoVendedor", nzINT(Me.CodVendedor.Text)))
            CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@NomeVendedor", nzINT(Me.VendedorNome.Text)))

            CmdLoc.ExecuteNonQuery()

            CmdLoc.CommandText = "SELECT @@IDENTITY"
            Dim IDLoc As Integer = CmdLoc.ExecuteScalar.ToString


            For Each row As DataGridViewRow In Me.ListaSelecionados.Rows


                CmdItem.CommandText = "Insert Into LocacaoItens (IdLocacao,Produto,Qtd,DiariaAmais,ValorUnitarioLoc,ValorDescontoLoc,TotalDiarias,TotalLoc,QtdDev,QtdAvarias,ValorUnitarioAvarias,TotalAvarias) Values (@IdLocacao,@Produto,@Qtd,@DiariaAmais,@ValorUnitarioLoc,@ValorDescontoLoc,@TotalDiarias,@TotalLoc,@QtdDev,@QtdAvarias,@ValorUnitarioAvarias,@TotalAvarias)"

                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@IdLocacao", nzINT(IDLoc)))
                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@Produto", nzINT(row.Cells("cProdutoCod").Value)))
                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@Qtd", nzNUM(row.Cells("cProdutoQtd").Value)))
                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@DiariaAmais", nzNUM(Me.DiariaAmais.Text)))

                Dim Valor_Unitario As Double = nzNUM(row.Cells("cProdutoUnitario").Value)
                Dim Valor_Desconto As Double = 0

                If Me.Decorador.Text = "S" Then
                    Valor_Desconto = (CDbl(nzNUM(row.Cells("cProdutoUnitario").Value)) - CDbl(nzNUM(row.Cells("cProdutoUnitarioDecorador").Value))) * CDbl(nzNUM(row.Cells("cProdutoQtd").Value))
                End If

                If Me.Promocao.Text = "S" Then
                    Valor_Desconto = CDbl(nzNUM(row.Cells("cProdutoUnitario").Value)) - CDbl(nzNUM(row.Cells("cValorPromocao").Value))
                End If

                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@ValorUnitarioLoc", nzNUM(Valor_Unitario)))
                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@ValorDescontoLoc", nzNUM(Valor_Desconto)))

                Dim Total_Diarias As Double = (CDbl(NzZero(Valor_Unitario)) * CDbl(nzNUM(row.Cells("cProdutoQtd").Value))) * CDbl(NzZero(Me.DiariaAmais.Text))
                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@TotalDiarias", nzNUM(Total_Diarias)))

                Dim Total_Locação As Double = CDbl(NzZero(Valor_Unitario) * CDbl(nzNUM(row.Cells("cProdutoQtd").Value)))
                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@TotalLoc", nzNUM(Total_Locação)))

                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@QtdDev", nzINT(0)))
                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@QtdAvarias", nzINT(0)))
                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@ValorUnitarioAvarias", CDbl(nzNUM(row.Cells("cValorReposicao").Value))))
                CmdItem.Parameters.Add(New OleDb.OleDbParameter("@TotalAvarias", nzNUM(0)))

                CmdItem.ExecuteNonQuery()
                CmdItem.Parameters.Clear()

            Next


            Transacao.Commit()
            CNN.Close()

            My.Forms.Locacao.IniciarPeloSeletor = IDLoc
            My.Forms.Locacao.ShowDialog()

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

    End Sub

    Private Sub DataLoc_Leave(sender As Object, e As EventArgs) Handles DataLoc.Leave
        If Not String.IsNullOrEmpty(Me.DataLoc.Text) Then
            If IsDate(Me.DataLoc.Text) Then

                Me.DataRetorno.Text = CDate(Me.DataLoc.Text).AddDays(2)

            End If
        End If

        If Lista.RowCount > 0 Then
            VerLocacoes(CodProduto.Text)
        End If


    End Sub

    Private Sub DiariaAmais_Validated(sender As Object, e As EventArgs) Handles DiariaAmais.Validated
        If String.IsNullOrEmpty(Me.DiariaAmais.Text) Then
            Me.DiariaAmais.Text = 0
        End If
    End Sub


    Private Sub Frete_Leave(sender As Object, e As EventArgs) Handles Frete.Leave
        If Me.Frete.Text <> "" Then
            AchaValorFrete()
        Else
            Me.ValorFrete.Text = FormatNumber(0, 2)
        End If
    End Sub

    Private Sub ListaSelecionados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaSelecionados.CellClick

        If (Me.ListaSelecionados.Rows(e.RowIndex).Cells("cbtExcluir").Selected) Then

            Dim Linha As Integer = Me.ListaSelecionados.CurrentRow.Index
            Dim IdRow() As DataRow
            IdRow = Selecionados.Select("LinhaId = " & Me.ListaSelecionados.Rows(Linha).Cells("cLinhaId").Value)

            For Each row As DataRow In IdRow
                row.Delete()
            Next

        End If

        If ListaSelecionados.RowCount=0 then
            panelDatas.Enabled=true
        End If

    End Sub

    Private Sub BtnCriarOrcamento_Click(sender As Object, e As EventArgs) Handles btnCriarOrcamento.Click

        'verificar algumas validações
        If String.IsNullOrEmpty(Me.CodVendedor.Text) Then
            MessageBox.Show("O usuário deve informar um vendedor para gerar a Locação.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.DataLoc.Text) Then
            MessageBox.Show("O usuário deve informar a data de Locação.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.HoraLoc.Text) Then
            MessageBox.Show("O usuário deve informar a hora de Locação.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.DataRetorno.Text) Then
            MessageBox.Show("O usuário deve informar a data de Retorno.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.HoraRetorno.Text) Then
            MessageBox.Show("O usuário deve informar a hora de retorno.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Me.ListaSelecionados.RowCount = 0 Then
            MessageBox.Show("Não foi informado nenhum item para ser locado, favor verificar...", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Dim f As New IniciarOrcamento

        f.ShowDialog()



        If f.Check1.Checked Then
            Me.CodCliente.Text = f.txtID.Text
            AcharCliente()

            Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()

            Dim Transacao As OleDbTransaction = CNN.BeginTransaction()

            Dim CmdLoc As OleDbCommand = CNN.CreateCommand
            Dim CmdItem As OleDbCommand = CNN.CreateCommand

            CmdLoc.Transaction = Transacao
            CmdItem.Transaction = Transacao

            Try

                'Salva Dados Adicionais do Pedido de Locação e muda o Status para locado


                CmdLoc.CommandText = "Insert Into LocacaoOrcamento (DataLoc,HoraLoc,DataRetorno,HoraRetorno,StatusLoc,Cliente,ObsLoc,Empresa,Frete,ValorFrete,DiariaAmais,CodigoVendedor,NomeVendedor, NomeCliente, Telefone, Cidade, uf, DataOrcamento) Values (@DataLoc,@HoraLoc,@DataRetorno,@HoraRetorno,@StatusLoc,@Cliente,@ObsLoc,@Empresa,@Frete,@ValorFrete,@DiariaAmais,@CodigoVendedor,@NomeVendedor, @NomeCliente, @Telefone, @Cidade, @Estado,@DataOrcamento)"

                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@DataLoc", nzDAT(Me.DataLoc.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@HoraLoc", nzNUL(Me.HoraLoc.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@DataRetorno", nzDAT(Me.DataRetorno.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@HoraRetorno", nzNUL(Me.HoraRetorno.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@StatusLoc", nzNUL("INICIAL")))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@Cliente", nzINT(f.txtID.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@ObsLoc", nzNUL(System.DBNull.Value)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@Empresa", nzINT(CodEmpresa)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@Frete", nzNUL(Me.Frete.SelectedValue)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@ValorFrete", nzNUM(Me.ValorFrete.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@DiariaAmais", nzINT(Me.DiariaAmais.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@CodigoVendedor", nzINT(Me.CodVendedor.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@NomeVendedor", nzNUL(Me.VendedorNome.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@NomeCliente", nzNUL(f.txtNomeCliente.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@Telefone", nzNUL(f.txtTelefone.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@Cidade", nzNUL(f.txtCidade.Text)))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@Estado", ""))
                CmdLoc.Parameters.Add(New OleDb.OleDbParameter("@DataOrcamento", DataDia))

                CmdLoc.ExecuteNonQuery()

                CmdLoc.CommandText = "SELECT @@IDENTITY"
                Dim IDLoc As Integer = CmdLoc.ExecuteScalar.ToString


                For Each row As DataGridViewRow In Me.ListaSelecionados.Rows


                    CmdItem.CommandText = "Insert Into LocacaoItensOrcamento (IdLocacao,Produto,Qtd,DiariaAmais,ValorUnitarioLoc,ValorDescontoLoc,TotalDiarias,TotalLoc,QtdDev,QtdAvarias,ValorUnitarioAvarias,TotalAvarias) Values (@IdLocacao,@Produto,@Qtd,@DiariaAmais,@ValorUnitarioLoc,@ValorDescontoLoc,@TotalDiarias,@TotalLoc,@QtdDev,@QtdAvarias,@ValorUnitarioAvarias,@TotalAvarias)"

                    CmdItem.Parameters.Add(New OleDbParameter("@IdLocacao", nzINT(IDLoc)))
                    CmdItem.Parameters.Add(New OleDbParameter("@Produto", nzINT(row.Cells("cProdutoCod").Value)))
                    CmdItem.Parameters.Add(New OleDbParameter("@Qtd", nzNUM(row.Cells("cProdutoQtd").Value)))
                    CmdItem.Parameters.Add(New OleDbParameter("@DiariaAmais", nzNUM(Me.DiariaAmais.Text)))

                    Dim Valor_Unitario As Double = nzNUM(row.Cells("cProdutoUnitario").Value)
                    Dim Valor_Desconto As Double = 0

                    If Me.Decorador.Text = "S" Then
                        Valor_Desconto = (CDbl(nzNUM(row.Cells("cProdutoUnitario").Value)) - CDbl(nzNUM(row.Cells("cProdutoUnitarioDecorador").Value))) * CDbl(nzNUM(row.Cells("cProdutoQtd").Value))
                    End If



                    If Me.Promocao.Text = "S" Then
                        Valor_Desconto = CDbl(nzNUM(row.Cells("cProdutoUnitario").Value)) - CDbl(nzNUM(row.Cells("cValorPromocao").Value))
                    End If

                    CmdItem.Parameters.Add(New OleDb.OleDbParameter("@ValorUnitarioLoc", nzNUM(Valor_Unitario)))
                    CmdItem.Parameters.Add(New OleDb.OleDbParameter("@ValorDescontoLoc", nzNUM(Valor_Desconto)))

                    Dim Total_Diarias As Double = (CDbl(NzZero(Valor_Unitario)) * CDbl(nzNUM(row.Cells("cProdutoQtd").Value))) * CDbl(NzZero(Me.DiariaAmais.Text))
                    CmdItem.Parameters.Add(New OleDb.OleDbParameter("@TotalDiarias", nzNUM(Total_Diarias)))

                    Dim Total_Locação As Double = CDbl(NzZero(Valor_Unitario) * CDbl(nzNUM(row.Cells("cProdutoQtd").Value)))
                    CmdItem.Parameters.Add(New OleDb.OleDbParameter("@TotalLoc", nzNUM(Total_Locação)))

                    CmdItem.Parameters.Add(New OleDb.OleDbParameter("@QtdDev", nzINT(0)))
                    CmdItem.Parameters.Add(New OleDb.OleDbParameter("@QtdAvarias", nzINT(0)))
                    CmdItem.Parameters.Add(New OleDb.OleDbParameter("@ValorUnitarioAvarias", nzNUM(0)))
                    CmdItem.Parameters.Add(New OleDb.OleDbParameter("@TotalAvarias", nzNUM(0)))

                    CmdItem.ExecuteNonQuery()
                    CmdItem.Parameters.Clear()

                Next


                Transacao.Commit()
                CNN.Close()

                f.Dispose()

                Dim f1 As New LocacaoOrcamento(IDLoc)
                f1.ShowDialog()

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

    Private Sub HoraLoc_Enter(sender As Object, e As EventArgs) Handles HoraLoc.Enter
        If String.IsNullOrEmpty(Me.HoraLoc.Text) Then
            Me.HoraLoc.Text = Date.Now.ToLongTimeString
        End If
    End Sub

    Private Sub DataLoc_TextChanged(sender As Object, e As EventArgs) Handles DataLoc.TextChanged
        If String.IsNullOrEmpty(Me.DataLoc.Text) Then
            Me.HoraLoc.Clear()
            Me.HoraRetorno.Clear()
            Me.DataRetorno.Clear()
        End If
    End Sub
End Class