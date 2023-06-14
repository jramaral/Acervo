
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ExportJson
Public Class Devolucao
    Public _localPgto As String
    Public _qtdParcela As Integer


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Close()
        Dispose()
    End Sub
    Private Sub EncheListaItens(valor As Integer)

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT LocacaoItens.IdItem, LocacaoItens.IdLocacao, LocacaoItens.Produto, Produtos.Descrição, LocacaoItens.Qtd, LocacaoItens.ValorUnitarioLoc, LocacaoItens.ValorDescontoLoc, LocacaoItens.TotalDiarias,LocacaoItens.TotalLoc, LocacaoItens.QtdDev, LocacaoItens.QtdAvarias, LocacaoItens.ValorUnitarioAvarias, LocacaoItens.TotalAvarias FROM LocacaoItens INNER JOIN Produtos ON LocacaoItens.Produto = Produtos.CodigoProduto WHERE (((LocacaoItens.IdLocacao)=" & valor & "))"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")


        Me.txtValorReposicao.Text = FormatNumber(NzZero(ds.Tables("Table").Compute("sum(TotalAvarias)", "")), 2)
        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()

    End Sub
    Private Sub AcharLocacao()

        If Me.txtNumeroLocacao.Text = "" Then Exit Sub

        Dim Sql As String = String.Empty

        Dim ds As New DataSet

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim VarCod As Integer = nzNUM(txtNumeroLocacao.Text)
        Sql = "SELECT Locacao.*, Locacao.IdLoc, Clientes.Nome, Clientes.CpfCgc, Clientes.Telefone, Clientes.Decorador FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Locacao.IdLoc)=" & VarCod & ") AND ((STATUSLOC) LIKE 'LOCADO') AND ((Locacao.ProdutosEntregue)=true))"


        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim Da As New OleDbDataAdapter(Cmd)
        Da.Fill(ds, "Locacao")


        If ds.Tables("Locacao").Rows.Count = 1 Then

            'atualizar os valores de reposição
            dim comando as New oledbcommand("UPDATE Locacao INNER JOIN (Produtos INNER JOIN LocacaoItens ON Produtos.CodigoProduto = LocacaoItens.Produto) ON Locacao.IdLoc = LocacaoItens.IdLocacao SET LocacaoItens.ValorUnitarioAvarias = [Produtos].[ValorVenda2] WHERE (((Locacao.StatusLoc)='LOCADO') AND ((Locacao.IdLoc)="& VarCod &"));",cnn)
            comando.ExecuteNonQuery()



            Me.DataLoc.Text = ds.Tables("Locacao").Rows(0)("DataLoc") & ""
            Me.DataRetorno.Text = ds.Tables("Locacao").Rows(0)("DataRetorno") & ""
            Me.ClienteNome.Text = ds.Tables("Locacao").Rows(0)("Nome") & ""
            Me.Cliente.Text = ds.Tables("Locacao").Rows(0)("cliente") & ""
            Me.Telefone.Text = ds.Tables("Locacao").Rows(0)("Telefone") & ""
            Me.txtNomeVendedor.Text = ds.Tables("Locacao").Rows(0)("NomeVendedor") & ""
            Cnn.Close()
            EncheListaItens(CInt(Me.txtNumeroLocacao.Text))
            ErroLivre = "Selecionou uma locação para ser feito devolução"
            GerarLog(Me.Text, AçãoTP.Livre, Me.txtNumeroLocacao.Text)
            'GerarLog(Me.Text, AçãoTP.Editou, Me.locacao.Text)

        Else
            MessageBox.Show("Esta Locação não está marcada como [Entregue]", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EncheListaItens(0)
            Cnn.Close()
            Exit Sub
           
        End If

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim f As New LocacaoProcurar()
        f.ShowDialog()
        AcharLocacao()
        txtDataEfetiva.Text = DataDia
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click

        For Each row As DataGridViewRow In Me.Lista.Rows

            'Devolve todos os itens para devolver
            row.Cells("cQtdDev").Value = row.Cells("cQtd").Value
            row.Cells("cTotalAvarias").Value = 0
            row.Cells("cQtdAvarias").Value = 0

        Next
        Me.txtValorReposicao.Text = FormatNumber(0, 2)

        ErroLivre = "Selecionou todos para devolução"
        GerarLog(Me.Text, AçãoTP.Livre, Me.txtNumeroLocacao.Text)
        'GerarLog(Me.Text, AçãoTP.Editou, Me.txtNumeroLocacao.Text)
    End Sub

    Private Sub btConfirmarLocacao_Click(sender As Object, e As EventArgs) Handles btConfirmarLocacao.Click

        If String.IsNullOrEmpty(txtDataEfetiva.Text) Then
            MessageBox.Show("Data do Retorno não pode ser nula", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        'verifica se tem algum item sem devolver
        Dim count As Integer = 0
        For Each row As DataGridViewRow In Me.Lista.Rows

            If row.Cells("cQtdDev").Value = 0 And row.Cells("cTotalAvarias").Value = 0 Then
                count = count + 1
            End If
        Next

        If count > 0 Then
            MessageBox.Show(String.Format("Existe(m) {0} produto(s) sem devolver. Verifique!", count), "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If(string.IsNullOrEmpty(txtNumeroLocacao.text)) Then
            MessageBox.Show("Não foi informado o código da locação. Verifique!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNumeroLocacao.Focus()
            Exit Sub
        End If

        btConfirmar.Enabled=false


        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Transacao As OleDbTransaction = CNN.BeginTransaction()


        Dim CmdItem As OleDbCommand = CNN.CreateCommand
        Dim CmdReceber As OleDbCommand = CNN.CreateCommand
        Dim CmdCaixa As OleDbCommand = CNN.CreateCommand
        Dim CmdEstoque As OleDbCommand = CNN.CreateCommand
        Dim CmdEstProd As OleDbCommand = CNN.CreateCommand
        Dim cmdAtualizaFechamento As OleDbCommand = CNN.CreateCommand()

        CmdItem.Transaction = Transacao
        CmdReceber.Transaction = Transacao
        CmdCaixa.Transaction = Transacao
        CmdEstoque.Transaction = Transacao
        CmdEstProd.Transaction = Transacao
        cmdAtualizaFechamento.Transaction = Transacao

        Try

            Me.Cursor = cursors.WaitCursor

            If nzNUL(txtValorReposicao.Text) > 0 Then

                Dim _f As New LocacaoConfirmar(Me, True, Me.txtValorReposicao.Text)
                _f.ShowDialog()

                If IsNothing(_localPgto) Then Exit Sub


                'Gerar o recebimento 
                Dim IdAVista As Integer 'Variavel usada para pegar o id do Recebimento a Vista
                Dim Parcela As String = String.Empty
                Dim DtVencimento As Date
                Dim Contar As Integer
                For Contar = 1 To _qtdParcela

                    CmdReceber.CommandText = "INSERT INTO Receber (Cliente, CodCliente, DataDocumento, Documento, Empresa, ValorDocumento, Vencimento, LocalPgto, PedidoProdutos, NotaFiscal, OriginalParcial, VinculoBXPARCIAL, Vendedor, MediaDescontoPedido, ControlePedido, PercentComissao, ContaValorBaixado, Virtual, Baixado, Recebimento) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20)"

                    Parcela = txtNumeroLocacao.Text & "-" & Contar & "DEV/" & _qtdParcela
                    Dim Dividido As Double = 0
                    Dividido = FormatNumber(CDbl(NzZero(Me.txtValorReposicao.Text)) / CInt(NzZero(_qtdParcela)), 2)
                    Dim Resto As Double = FormatNumber(FormatNumber(CDbl(NzZero(txtValorReposicao.Text)), 2) - FormatNumber(Dividido * CInt(_qtdParcela), 2), 2)
                    If Contar = _qtdParcela Then Dividido += Resto

                    DtVencimento = IIf(Contar = 1, CDate(DataDia).AddDays(CInt(30)), CDate(DtVencimento).AddDays(CInt(30)))


                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUL(ClienteNome.Text)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@2", nzINT(Cliente.Text)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@3", nzDAT(DataDia)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@4", nzNUL(Parcela)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@5", nzINT(CodEmpresa)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@6", nzNUM(Dividido)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@7", nzDAT(DtVencimento)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@8", nzNUL(_localPgto)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@9", nzINT(txtNumeroLocacao.Text)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@10", nzINT(0)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@11", nzNUL("O")))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@12", nzNUL(System.DBNull.Value)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@13", nzINT(VarCodFunc)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@14", nzINT(0)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@15", nzINT(0)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@16", nzINT(0)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@17", nzNUL(CodLancamentoReceber)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@18", nzBOL(False)))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@19", nzBOL(IIf(_localPgto = "CARTEIRA", True, False))))
                    CmdReceber.Parameters.Add(New OleDb.OleDbParameter("@20", nzDAT(IIf(_localPgto = "CARTEIRA", DataDia, System.DBNull.Value))))

                    CmdReceber.ExecuteNonQuery()
                    If _localPgto = "CARTEIRA" Then
                        CmdReceber.CommandText = "SELECT @@IDENTITY"
                        IdAVista = CmdReceber.ExecuteScalar.ToString
                    End If
                    CmdReceber.Parameters.Clear()

                Next

                'Fazer Lancamento no Caixa para Lancamento em Carteira

                If _localPgto = "CARTEIRA" Then

                    CmdCaixa.CommandText = "INSERT INTO LancamentoBanco (DataLancamento, PreDatado, DataPreDatado, Documento, DataDocumento, TipoLancamento, Favorecido, Historico, CaiuBanco, ConfirmadoLancamento, Empresa, ValorDocumento, ContaCorrente, EmitirCheque, ContaBalancete, Tipo, IdLancamento, IdProcura) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18)"

                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@1", DataDia))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@2", False))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@3", System.DBNull.Value))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Parcela, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@5", DataDia))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@6", Nz("C", 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(ClienteNome.Text, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@8", Nz("RECEB. AVISTA AVARIAS DEV. " & txtNumeroLocacao.Text, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@9", Nz("S", 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@10", True)) 'Confirmado Lancamento como true
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@11", CodEmpresa))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@12", nzNUM(txtValorReposicao.Text)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(CaixaAtivo, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@14", "N"))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(CodLancamentoReceber, 1)))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@16", "CAIXA"))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@17", "RECEBER"))
                    CmdCaixa.Parameters.Add(New OleDb.OleDbParameter("@18", nzINT(IdAVista)))
                    CmdCaixa.ExecuteNonQuery()
                End If


            End If


            'Atualiza os valores do grid do datagridview

            For Each row As DataGridViewRow In Me.Lista.Rows
                CmdItem.CommandText = String.Format("Update LocacaoItens set QtdDev={0}, TotalAvarias='{1}', QtdAvarias='{2}' where idItem={3}", row.Cells("cQtdDev").Value, row.Cells("cTotalAvarias").Value, row.Cells("cQtdAvarias").Value, row.Cells("cIdItem").Value)
                CmdItem.ExecuteNonQuery()
            Next




            'Fazer o Lancamento na tabela EstoqueUP e atualização na tabela de Produtos
            CmdEstoque.CommandText = "INSERT INTO EstoqueUP (CodigoProduto, Qtd, Tipo, IdLancamento, DataLancamento, PedidoOrdem, Prg, ClienteFornecedor, NFDoc) " _
                                   & "SELECT LocacaoItens.Produto, [QtdDev] AS QtdEst, 'R' AS Expr1, 0 AS Expr2, #" & CDate(DataDia) & "#, Locacao.IdLoc, 'RETORNO' AS Expr6,'" & Me.ClienteNome.Text & "' AS Expr4, '" & Me.txtNumeroLocacao.Text & "' As Expr5 FROM (LocacaoItens INNER JOIN Locacao ON LocacaoItens.IdLocacao = Locacao.IdLoc) INNER JOIN Produtos ON LocacaoItens.Produto = Produtos.CodigoProduto WHERE (((LocacaoItens.IdLocacao)=" & Me.txtNumeroLocacao.Text & ") AND ((Locacao.Empresa)=" & CodEmpresa & ") AND ((Produtos.ControlaEstoque)='SIM'));"

            CmdEstoque.ExecuteNonQuery()

            For Each row As DataGridViewRow In Lista.Rows

                CmdEstProd.CommandText = "SELECT Sum(EstoqueUP.Qtd) AS Estoque  FROM EstoqueUP WHERE (((EstoqueUP.CodigoProduto)=" & row.Cells("cProduto").Value & ") AND ((EstoqueUP.Tipo) NOT IN ('E','S'))) GROUP BY EstoqueUP.CodigoProduto;"
                Dim Testoque As Double = FormatNumber(nzNUM(CmdEstProd.ExecuteScalar), 3)


                CmdEstProd.CommandText = "Update Produtos set EmLocacao = @1 Where CodigoProduto = " & row.Cells("cProduto").Value
                CmdEstProd.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUM(Testoque)))

                CmdEstProd.ExecuteNonQuery()
                CmdEstProd.Parameters.Clear()

            Next
            'fim da rotina de atualização de estoque e tabela de produtos

            'Atualiza a data de fechamento
            cmdAtualizaFechamento.CommandText = "Update Locacao set DataEfetivaRetorno = @DataEfetivaRetorno, StatusLoc =@StatusLoc WHERE IdLoc = " & Me.txtNumeroLocacao.Text
            cmdAtualizaFechamento.Parameters.Add(New OleDb.OleDbParameter("@DataEfetivaRetorno", nzDAT(DataDia)))
            cmdAtualizaFechamento.Parameters.Add(New OleDb.OleDbParameter("@StatusLoc", "DEVOLVIDO"))
            cmdAtualizaFechamento.ExecuteNonQuery()


            Transacao.Commit()

            CNN.Close()



            ''gerar p arquivo pdf
            Dim rpt As New ReportDocument()
            rpt.Load(DirRelat & "RelDevolucao.rpt")

            Dim Crypto As New ClCrypto 'Para descriptografar a senha do banco de dados

            Dim logOnInfo As New TableLogOnInfo()
            Dim i As Integer
            For i = 0 To rpt.Database.Tables.Count - 1
                logOnInfo.ConnectionInfo.ServerName = LocalBD & Nome_BD
                logOnInfo.ConnectionInfo.DatabaseName = LocalBD & Nome_BD
                logOnInfo.ConnectionInfo.UserID = ""
                logOnInfo.ConnectionInfo.Password = Crypto.clsCrypto(SenhaBancoDados, False)
                rpt.Database.Tables.Item(i).ApplyLogOnInfo(logOnInfo)
            Next i


            rpt.RecordSelectionFormula = "{Locacao.IdLoc} = " & txtNumeroLocacao.Text

            'dim path = IO.Path.GetDirectoryName(system.Reflection.Assembly.GetExecutingAssembly().Location)
            'path = path & "\Pdf\"& txtNumeroLocacao.Text & ".pdf"

            'rpt.ExportToDisk(ExportFormatType.PortableDocFormat, path)

            'Process.Start(path)
            Cursor = Cursors.Default


            MessageBox.Show("Locação Devolvida com sucesso", "Validação de dados", MessageBoxButtons.OK, MessageBoxIcon.Information)

           
            GerarLog(Me.Text, AçãoTP.Confirmou, Me.txtNumeroLocacao.Text)

            'gravando informações no log de eventos
            Dim log As New Log With {
                .Locacao = txtNumeroLocacao.Text,
                .DataAcao = DateTime.Now,
                .User = UserAtivo
            }

            Dim app As New SerializarJson()
            app.GravarJSON(log)
            'fim da log de enventose 
            btConfirmar.Enabled = True

            txtNumeroLocacao.Clear()
            txtDataEfetiva.Clear()
            Cliente.Clear()
            ClienteNome.Clear()
            txtNomeVendedor.Clear()
            DataLoc.Clear()
            DataRetorno.Clear()
            Telefone.Clear()
            txtValorReposicao.Clear()
            EncheListaItens(0)





        Catch ex As Exception
            If Not IsNothing(Transacao) Then
                Transacao.Rollback()
            End If

            btConfirmar.Enabled=true
            cursor = Cursors.Default
            If ConnectionState.Open Then
                CNN.Close()
            End If
            MsgBox("Erro ao salvar dados da locação.", 64, "Validação de Dados")
            
        End Try
    End Sub

    Private Sub Devolucao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtDataEfetiva.Text = DataDia
    End Sub

    Private Sub txtNumeroLocacao_Enter(sender As Object, e As EventArgs) Handles txtNumeroLocacao.Enter
        Me.txtNumeroLocacao.Clear()
        Me.ClienteNome.Clear()
        Me.txtNomeVendedor.Clear()
        Me.DataRetorno.Clear()
        Me.DataLoc.Clear()
        Me.Telefone.Clear()
        EncheListaItens(0)
    End Sub

    Private Sub Lista_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Lista.CellClick

        If (e.ColumnIndex = 0) Then
            Me.painelRetorno.Enabled = True
            Me.txtQuantidadeRetorno.Focus()
            ErroLivre = "Devolução parcial de produto"
            GerarLog(Me.Text, AçãoTP.Livre, Me.txtNumeroLocacao.Text)
        End If
    End Sub

    Private Sub btConfirmar_Click(sender As Object, e As EventArgs) Handles btConfirmar.Click
        Dim falta As Integer
        Dim vReposicao As Double = 0
        If String.IsNullOrEmpty(Me.txtQuantidadeRetorno.Text) Then
            MessageBox.Show("O valor não pode ser nulo", "Validação de dados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Lista.Focus()
            Me.painelRetorno.Enabled = False
            Exit Sub
        Else
            Try


                If (Me.txtQuantidadeRetorno.Text <= Me.Lista.CurrentRow.Cells("cQtd").Value And Me.txtQuantidadeRetorno.Text >= 0) Then
                    Me.Lista.CurrentRow.Cells("cQtdDev").Value = Me.txtQuantidadeRetorno.Text
                    falta = Me.Lista.CurrentRow.Cells("cQtd").Value - CInt(Me.txtQuantidadeRetorno.Text)
                    Me.Lista.CurrentRow.Cells("cQtdAvarias").Value = falta
                    Dim res As Double = FormatNumber(falta * nzNUM(Me.Lista.CurrentRow.Cells("cValorUnitarioAvarias").Value), 2)
                    Me.Lista.CurrentRow.Cells("cTotalAvarias").Value = res.ToString()
                    ErroLivre = "Devolução parcial"
                    GerarLog(Me.Text, AçãoTP.Livre, Me.txtQuantidadeRetorno.Text)
                    Me.txtQuantidadeRetorno.Clear()

                    For Each row As DataGridViewRow In Me.Lista.Rows

                        'Devolve todos os itens para devolver
                        vReposicao = vReposicao + row.Cells("cTotalAvarias").Value

                    Next

                    Me.txtValorReposicao.Text = FormatNumber(vReposicao, 2)
                    Me.Lista.Focus()
                    Me.painelRetorno.Enabled = False
                Else
                    MessageBox.Show("O valor não pode ser maior que a quantidade locada ou menor que zero (0)", "Validação de dados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtQuantidadeRetorno.Clear()
                    Me.Lista.Focus()
                    Me.painelRetorno.Enabled = False
                    Exit Sub
                End If
            Catch ex As Exception

            End Try
          
        End If

    End Sub

    Private Sub txtNumeroLocacao_Leave(sender As Object, e As EventArgs) Handles txtNumeroLocacao.Leave
        AcharLocacao()
    End Sub
End Class