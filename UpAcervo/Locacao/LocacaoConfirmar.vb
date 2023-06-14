Imports System.Data.OleDb
Imports Agendamento

Public Class LocacaoConfirmar

    Dim _f As Devolucao
    Dim _isDev As Boolean
    Dim dValorEntrada, dValorFaturar, dTotalLocacao As Double

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(paramForm As Devolucao, trueFalse As Boolean, valor As Double)
        InitializeComponent()
        _f = paramForm
        _isDev = trueFalse

        _f._localPgto = Me.LocalPgto.SelectedValue
        _f._qtdParcela = Me.QtdParcelas.Text
        Me.DataRetorno.Text = nzDAT(DataDia)
        Me.Label1.Text = "Total de avarias"
        Me.TotalLocacao.Text = FormatNumber(valor, 2)
        Me.txtValorEntrada.Enabled = False

    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub CarregaLocalPgto()

        Dim Cnn As OleDbConnection = New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim ds As New DataSet

        Dim Sql As String = "Select * From LocalPagamento Where Empresa = " & CodEmpresa
        Dim daLocalPgto As OleDbDataAdapter

        daLocalPgto = New OleDbDataAdapter(Sql, Cnn)
        daLocalPgto.Fill(ds, "LocalPgto")

        Me.LocalPgto.DataSource = ds.Tables("LocalPgto")
        Me.LocalPgto.ValueMember = "LocalPgto"
        Me.LocalPgto.DisplayMember = "LocalPgto"
        Cnn.Close()

    End Sub

    Private Sub LocacaoConfirmar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Forms.Locacao.Visible = True Then
            Me.TotalLocacao.Text = FormatNumber(My.Forms.Locacao.TotalLoc.Text, 2)
            Me.DataRetorno.Text = My.Forms.Locacao.DataRetorno.Text & ""
        End If

        CarregaLocalPgto()

        dTotalLocacao = FormatNumber(Convert.ToDouble(Me.TotalLocacao.Text), 2)
        txtValorEntrada.Text = "0,00"
    End Sub

    Private Sub LocalPgto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LocalPgto.SelectedIndexChanged
        If Me.LocalPgto.Text = "CARTEIRA" Then
            Me.QtdParcelas.Value = 1
            Me.QtdParcelas.Enabled = False
            txtValorEntrada.Text = "0,00"
        Else
            If nzNUM(txtValorEntrada.Text) > 0 Then
                Me.QtdParcelas.Value = 2
                Me.QtdParcelas.Enabled = False
            Else
                Me.QtdParcelas.Value = 0
                Me.QtdParcelas.Enabled = True
            End If

        End If
    End Sub

    Private Sub txtValorEntrada_Validated(sender As Object, e As EventArgs) Handles txtValorEntrada.Validated
        If txtValorEntrada.Text = String.Empty Or nzNUM(txtValorEntrada.Text) >= dTotalLocacao Or nzNUM(txtValorEntrada.Text) < 0 Then
            txtValorEntrada.Text = "0,00"
            Me.LocalPgto.FindStringExact("BANCO")
            QtdParcelas.Enabled = True
            QtdParcelas.Value = 0
        Else
            If nzNUM(txtValorEntrada.Text > 0) Then
                QtdParcelas.Value = 2
                QtdParcelas.Enabled = False
                FormaPgto.Text = "BANCO"
            Else

                QtdParcelas.Value = 0
                QtdParcelas.Enabled = True
            End If
        End If
    End Sub

    Private Sub btConfirmar_Click(sender As Object, e As EventArgs) Handles btConfirmar.Click


        If String.IsNullOrEmpty(txtValorEntrada.Text) Then
            dValorFaturar = TotalLocacao.Text
        End If

        If CInt(Me.QtdParcelas.Value) = 0 Then
            MessageBox.Show("Favor informar a Quantidade de parcelas.", "Validação da Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Me.DataRetorno.Text = "" Then
            MessageBox.Show("Favor informar a data de retorno da locação", "Validação da Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If _isDev = False Then

            Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()

            Dim Transacao As OleDbTransaction = CNN.BeginTransaction()

            Dim CmdLoc As OleDbCommand = CNN.CreateCommand
            Dim CmdReceber As OleDbCommand = CNN.CreateCommand
            Dim CmdCaixa As OleDbCommand = CNN.CreateCommand
            Dim CmdEstoque As OleDbCommand = CNN.CreateCommand
            Dim CmdEstProd As OleDbCommand = CNN.CreateCommand
            Dim cmdAtualizaFechamento As OleDbCommand = CNN.CreateCommand()

            CmdLoc.Transaction = Transacao
            CmdReceber.Transaction = Transacao
            CmdCaixa.Transaction = Transacao
            CmdEstoque.Transaction = Transacao
            CmdEstProd.Transaction = Transacao
            cmdAtualizaFechamento.Transaction = Transacao

            Try

                'Salva Dados Adicionais do Pedido de Locação e muda o Status para locado

                CmdLoc.CommandText = "Update Locacao set StatusLoc = @1, LocalPgto = @2, QtdParcelas = @3, DataRetorno = @4, ValorEntrada = @5 Where IdLoc = " & My.Forms.Locacao.IdLoc.Text
                CmdLoc.Parameters.Add(New OleDbParameter("@1", nzNUL("LOCADO")))
                CmdLoc.Parameters.Add(New OleDbParameter("@2", nzNUL(LocalPgto.SelectedValue)))
                CmdLoc.Parameters.Add(New OleDbParameter("@3", nzINT(QtdParcelas.Value)))
                CmdLoc.Parameters.Add(New OleDbParameter("@4", nzDAT(DataRetorno.Text)))
                CmdLoc.Parameters.Add(New OleDbParameter("@5", nzNUM(txtValorEntrada.Text)))
                CmdLoc.ExecuteNonQuery()

                'Gerar o recebimento 
                Dim IdAVista As Integer 'Variavel usada para pegar o id do Recebimento a Vista
                Dim Parcela As String = String.Empty
                Dim DtVencimento As Date
                Dim Contar As Integer

                For Contar = 1 To Me.QtdParcelas.Value

                    CmdReceber.CommandText = "INSERT INTO Receber (Cliente, CodCliente, DataDocumento, Documento, Empresa, ValorDocumento, Vencimento, LocalPgto, PedidoProdutos, NotaFiscal, OriginalParcial, VinculoBXPARCIAL, Vendedor, MediaDescontoPedido, ControlePedido, PercentComissao, ContaValorBaixado, Virtual, Baixado, Recebimento, ValorLiquido) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20,@21)"

                    Parcela = My.Forms.Locacao.IdLoc.Text & "-" & Contar & "/" & Me.QtdParcelas.Value
                    Dim Dividido As Double = 0

                    If nzNUM(txtValorEntrada.Text) = 0 Then
                        Dividido = FormatNumber(CDbl(NzZero(Me.TotalLocacao.Text)) / CInt(NzZero(Me.QtdParcelas.Value)), 2)
                        Dim Resto As Double = FormatNumber(FormatNumber(CDbl(NzZero(Me.TotalLocacao.Text)), 2) - FormatNumber(Dividido * CInt(QtdParcelas.Value), 2), 2)
                        If Contar = Me.QtdParcelas.Value Then Dividido += Resto
                    Else
                        If Contar = 1 Then
                            Dividido = FormatNumber(CDbl(NzZero(Me.txtValorEntrada.Text)), 2)
                        Else
                            Dividido = dTotalLocacao - nzNUM(txtValorEntrada.Text)
                        End If
                    End If




                    DtVencimento = IIf(Contar = 1, CDate(DataDia).AddDays(CInt(30)), CDate(DtVencimento).AddDays(CInt(30)))


                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUL(My.Forms.Locacao.ClienteNome.Text)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@2", nzINT(My.Forms.Locacao.Cliente.Text)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@3", nzDAT(DataDia)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@4", nzNUL(Parcela)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@5", nzINT(CodEmpresa)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@6", nzNUM(Dividido)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@7", nzDAT(DtVencimento)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@8", nzNUL(Me.LocalPgto.SelectedValue)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@9", nzINT(My.Forms.Locacao.IdLoc.Text)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@10", nzINT(0)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@11", nzNUL("O")))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@12", nzNUL(System.DBNull.Value)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@13", nzINT(VarCodFunc)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@14", nzINT(0)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@15", nzINT(0)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@16", nzINT(0)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@17", nzNUL(CodLancamentoReceber)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@18", nzBOL(False)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@19", nzBOL(IIf(Me.LocalPgto.SelectedValue = "CARTEIRA", True, False))))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@20", nzDAT(IIf(Me.LocalPgto.SelectedValue = "CARTEIRA", DataDia, System.DBNull.Value))))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@21", nzNUM(IIf(Me.LocalPgto.SelectedValue = "CARTEIRA", Dividido, 0))))

                    CmdReceber.ExecuteNonQuery()
                    If Me.LocalPgto.SelectedValue = "CARTEIRA" Then
                        CmdReceber.CommandText = "SELECT @@IDENTITY"
                        IdAVista = CmdReceber.ExecuteScalar.ToString
                    End If
                    CmdReceber.Parameters.Clear()

                Next

                'Fazer Lancamento no Caixa para Lancamento em Carteira

                If Me.LocalPgto.SelectedValue = "CARTEIRA" Then

                    CmdCaixa.CommandText = "INSERT INTO LancamentoBanco (DataLancamento, PreDatado, DataPreDatado, Documento, DataDocumento, TipoLancamento, Favorecido, Historico, CaiuBanco, ConfirmadoLancamento, Empresa, ValorDocumento, ContaCorrente, EmitirCheque, ContaBalancete, Tipo, IdLancamento, IdProcura) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18)"

                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@1", DataDia))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@2", False))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@3", System.DBNull.Value))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Parcela, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@5", DataDia))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@6", Nz("C", 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(My.Forms.Locacao.ClienteNome.Text, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@8", Nz("RECEB. AVISTA LOC. " & My.Forms.Locacao.IdLoc.Text, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@9", Nz("S", 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@10", True)) 'Confirmado Lancamento como true
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@11", CodEmpresa))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@12", nzNUM(Me.TotalLocacao.Text)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(CaixaAtivo, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@14", "N"))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(CodLancamentoReceber, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@16", "CAIXA"))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@17", "RECEBER"))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@18", nzINT(IdAVista)))
                    CmdCaixa.ExecuteNonQuery()
                End If


                ''Fazer o Lancamento na tabela EstoqueUP e atualização na tabela de Produtos
                'CmdEstoque.CommandText = "INSERT INTO EstoqueUP (CodigoProduto, Qtd, Tipo, IdLancamento, DataLancamento, PedidoOrdem, Prg, ClienteFornecedor, NFDoc) SELECT LocacaoItens.Produto, [Qtd]*-1 AS QtdEst, 'L' AS Expr1, 0 AS Expr2, #" & CDate(DataDia) & "#, Locacao.IdLoc, 'LOCACAO' AS Expr3,'" & My.Forms.Locacao.ClienteNome.Text & "' AS Expr4, '" & My.Forms.Locacao.IdLoc.Text & "' As Expr5 FROM (LocacaoItens INNER JOIN Locacao ON LocacaoItens.IdLocacao = Locacao.IdLoc) INNER JOIN Produtos ON LocacaoItens.Produto = Produtos.CodigoProduto WHERE (((LocacaoItens.IdLocacao)=" & My.Forms.Locacao.IdLoc.Text & ") AND ((Locacao.Empresa)=" & CodEmpresa & ") AND ((Produtos.ControlaEstoque)='SIM'));"
                'CmdEstoque.ExecuteNonQuery()

                'For Each row As DataGridViewRow In My.Forms.Locacao.Lista.Rows

                '    CmdEstProd.CommandText = "SELECT SUM(Qtd) AS Estoque FROM EstoqueUP GROUP BY CodigoProduto HAVING CodigoProduto = " & row.Cells("cProduto").Value
                '    Dim Testoque As Double = FormatNumber(CmdEstProd.ExecuteScalar, 3)

                '    'CmdEstProd.CommandText = "SELECT Count(Qtd) AS QtdLoc FROM EstoqueUP GROUP BY CodigoProduto HAVING CodigoProduto = " & row.Cells("cProduto").Value
                '    CmdEstProd.CommandText = "SELECT Count(Qtd) AS QtdLoc FROM EstoqueUP GROUP BY EstoqueUP.CodigoProduto, EstoqueUP.Tipo HAVING (((EstoqueUP.[CodigoProduto])=" & row.Cells("cProduto").Value & ") AND ((EstoqueUP.Tipo)='L'));"
                '    Dim tQTDLocacao As Double = FormatNumber(NzZero(CmdEstProd.ExecuteScalar), 3)


                '    CmdEstProd.CommandText = "Update Produtos set QuantidadeEstoque = @1, QtdeLocado = @2 Where CodigoProduto = " & row.Cells("cProduto").Value
                '    CmdEstProd.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUM(Testoque)))
                '    CmdEstProd.Parameters.Add(New OleDb.OleDbParameter("@2", nzNUM(tQTDLocacao)))
                '    CmdEstProd.ExecuteNonQuery()
                '    CmdEstProd.Parameters.Clear()

                'Next
                ''fim da rotina de atualização de estoque e tabela de produtos

                'Atualiza a data de fechamento
                cmdAtualizaFechamento.CommandText = "Update Locacao set DataFechamento = @DataFechamento WHERE IdLoc = " & My.Forms.Locacao.IdLoc.Text
                cmdAtualizaFechamento.Parameters.Add(New OleDb.OleDbParameter("@DataFechamento", nzDAT(DataDia)))
                cmdAtualizaFechamento.ExecuteNonQuery()


                


                Transacao.Commit()
                If Not (My.Forms.Locacao.Frete.SelectedIndex) = -1 Then
                    SalvarDadosAgenda()
                End If



                My.Forms.Locacao.StatusLoc.Text = "LOCADO"
                CNN.Close()

                'Fazer impressao de Documento aqui
                System.Threading.Thread.Sleep(2000)
                RelatorioCarregar = "LocacaoContrato"
                My.Forms.VisualizadorRelatorio.ShowDialog()
                'Fim

                MessageBox.Show("Locação confirmada com sucesso", "Validação de dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Else
            'Devolução da locação
            _f._localPgto = Me.LocalPgto.SelectedValue
            _f._qtdParcela = Me.QtdParcelas.Text
            Me.Close()
            Me.Dispose()
        End If

    End Sub

    Private Sub SalvarDadosAgenda()

        Dim app = New Compromisso
        Dim c = New CompromissoProperts()
        Dim r = New CompromissoProperts()
      
        'Entregar
        c.DataCompromisso=My.Forms.Locacao.DataLoc.Text
        c.HoraCompromisso=My.Forms.Locacao.HoraLoc.Text
        c.Tag=c.DataCompromisso.ToString("dddd").Replace("-feira","").ToUpper()
        c.Descricao= My.Forms.Locacao.ClienteNome.Text
        c.Subject="LOC. Nº "& My.Forms.Locacao.IdLoc.Text 
        c.Observacao=My.Forms.Locacao.ObsLoc.text

        'Retirar
        r.DataCompromisso=My.Forms.Locacao.DataRetorno.Text
        r.HoraCompromisso=My.Forms.Locacao.HoraRetorno.Text
        r.Tag=r.DataCompromisso.ToString("dddd").Replace("-feira","").ToUpper()
        r.Descricao= My.Forms.Locacao.ClienteNome.Text
        r.Subject="LOC. Nº "& My.Forms.Locacao.IdLoc.Text 
        r.Observacao=My.Forms.Locacao.ObsLoc.text
        r.Status="Retirar"



        Try
            'Entregar
            app.AddNewCompromisso(c)
            'Retirar
            app.AddNewCompromisso(r)

        Catch ex As Exception

        End Try



        'DAQUI PARA BAIXAO - CODIGO ANTIGO -


        'Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        'CNN.Open()


       
        'Dim Sql As String = String.Empty

        'Sql = "SELECT * from AgendaServico where Id =0"
        'Dim daAgendaServico As New OleDbDataAdapter(Sql, cnn)
        
        'Dim ds As New DataSet
        'daAgendaServico.Fill(ds, "AgendaServico")
        


        ''daAgendaServico.InsertCommand.Transaction = tran



        'Try
        '    If ds.Tables("AgendaServico").Rows.Count = 0 Then

        '        'If CDate(Me.DataAgenda.Text) < CDate(DataDia) Then
        '        '    MessageBox.Show("A data de Agendamento não pode ser menor que a data do dia Atual", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        '    Exit Sub
        '        'End If

        '        Dim dRnovo As DataRow
        '        dRnovo = ds.Tables("AgendaServico").NewRow
        '        dRnovo("Cliente") = My.Forms.Locacao.Cliente.Text
        '        dRnovo("ClienteDesc") = My.Forms.Locacao.ClienteNome.Text
        '        dRnovo("DataLancamento") = DataDia
        '        dRnovo("Compromisso") = "LOCAÇÃO Nº." & My.Forms.Locacao.IdLoc.Text & vbCrLf & My.Forms.Locacao.ObsLoc.Text
        '        dRnovo("DataAgenda") = My.Forms.Locacao.DataLoc.Text
        '        dRnovo("HorasCompromisso") = My.Forms.Locacao.HoraLoc.Text
        '        dRnovo("DiasAntecipadoAvisar") = 0
        '        dRnovo("IdLancTodos") = 0
        '        dRnovo("Status") = "AGENDADO"
        '        dRnovo("Usuario") = UserAtivo
        '        ds.Tables("AgendaServico").Rows.Add(dRnovo)

                
        '    End If


        '    Dim objBuilder As New OleDb.OleDbCommandBuilder(daAgendaServico)
        '    daAgendaServico.Update(ds, "AgendaServico")
        '    CNN.Close()
        '    'If Me.Id.Text = "" Then
        '    '    Dim cmd As New OleDb.OleDbCommand("SELECT @@IDENTITY", CNN)
        '    '    Me.Id.Text = cmd.ExecuteScalar()
        '    'End If

        '    'MessageBox.Show("Registro salvo com sucesso", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Catch ex As Exception
        '    ' MsgBox(ex.Message)
        '    CNN.Close()
        '    ' Exit Sub
        'End Try

    End Sub


End Class