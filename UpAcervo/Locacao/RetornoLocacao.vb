Imports System.Data.OleDb
Imports System.Text
Imports ExportJson


Public Class RetornoLocacao
    Dim nome_cli As String
    Dim numloc As String
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        'busca por Data de Locação
        Dim sb As New StringBuilder
        sb.Append("SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno ")
        sb.Append("From Locacao INNER Join Clientes On Locacao.Cliente = Clientes.Codigo ")
        sb.Append("Where(((Locacao.DataLoc) Between #" & Format(CDate(Me.txtDataInicial.Text), "dd/MM/yyyy") & "# And #" & Format(CDate(Me.txtDataFinal.Text), "dd/MM/yyy") & "#) And ((Locacao.StatusLoc)='LOCADO'))  ORDER BY DataLoc")
        Sql = sb.ToString()

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()
    End Sub
    Private Sub EncheListaItens(valor As Integer)

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT LocacaoItens.IdItem, LocacaoItens.IdLocacao, LocacaoItens.Produto, Produtos.Descrição, LocacaoItens.Qtd, LocacaoItens.ValorUnitarioLoc, LocacaoItens.ValorDescontoLoc, LocacaoItens.TotalDiarias,LocacaoItens.TotalLoc, LocacaoItens.QtdDev, LocacaoItens.QtdAvarias, LocacaoItens.ValorUnitarioAvarias, LocacaoItens.TotalAvarias FROM LocacaoItens INNER JOIN Produtos ON LocacaoItens.Produto = Produtos.CodigoProduto WHERE (((LocacaoItens.IdLocacao)=" & valor & "))"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")


        'Me.txtValorReposicao.Text = FormatNumber(NzZero(ds.Tables("Table").Compute("sum(TotalAvarias)", "")), 2)
        Me.Lista1.DataSource = ds.Tables("Table").DefaultView
        da.Dispose()

        For Each row As DataGridViewRow In Me.Lista1.Rows

            'Devolve todos os itens para devolver
            row.Cells("cQtdDev").Value = row.Cells("cQtd").Value
            row.Cells("cTotalAvarias").Value = 0
            row.Cells("cQtdAvarias").Value = 0

        Next

        Cnn.Close()

    End Sub

    Private Sub lista_Click(sender As Object, e As EventArgs) Handles lista.Click
        Dim i As Integer = 0
        i = lista.CurrentRow.Cells("cIdLoc").Value
        nome_cli = lista.CurrentRow.Cells("cNome").Value
        numloc = i
        EncheListaItens(i)

    End Sub

    Private Sub btnRetornar_Click(sender As Object, e As EventArgs) Handles btnRetornar.Click
        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Transacao As OleDbTransaction = CNN.BeginTransaction()

        Dim CmdItem As OleDbCommand = CNN.CreateCommand

        Dim CmdEstoque As OleDbCommand = CNN.CreateCommand
        Dim CmdEstProd As OleDbCommand = CNN.CreateCommand
        Dim cmdAtualizaFechamento As OleDbCommand = CNN.CreateCommand()

        CmdItem.Transaction = Transacao

        CmdEstoque.Transaction = Transacao
        CmdEstProd.Transaction = Transacao
        cmdAtualizaFechamento.Transaction = Transacao

        Try

            For Each rowLista As DataGridViewRow In lista.Rows

                Dim i As Integer = 0
                i = rowLista.Cells("cIdLoc").Value 'lista.CurrentRow.Cells("cIdLoc").Value
                nome_cli = rowLista.Cells("cNome").Value
                numloc = i
                EncheListaItens(i)

                ' lista_Click(sender, e)



                'Atualiza os valores do grid do datagridview

                For Each row As DataGridViewRow In Me.Lista1.Rows
                    CmdItem.CommandText = String.Format("Update LocacaoItens set QtdDev={0}, TotalAvarias='{1}' where idItem={2}", row.Cells("cQtdDev").Value, row.Cells("cTotalAvarias").Value, row.Cells("cIdItem").Value)
                    CmdItem.ExecuteNonQuery()
                Next




                'Fazer o Lancamento na tabela EstoqueUP e atualização na tabela de Produtos
                CmdEstoque.CommandText = "INSERT INTO EstoqueUP (CodigoProduto, Qtd, Tipo, IdLancamento, DataLancamento, PedidoOrdem, Prg, ClienteFornecedor, NFDoc) " _
                                       & "SELECT LocacaoItens.Produto, [QtdDev] AS QtdEst, 'R' AS Expr1, 0 AS Expr2, #" & CDate(DataDia) & "#, Locacao.IdLoc, 'RETORNO' AS Expr6,'" & nome_cli & "' AS Expr4, '" & numloc & "' As Expr5 FROM (LocacaoItens INNER JOIN Locacao ON LocacaoItens.IdLocacao = Locacao.IdLoc) INNER JOIN Produtos ON LocacaoItens.Produto = Produtos.CodigoProduto WHERE (((LocacaoItens.IdLocacao)=" & numloc & ") AND ((Locacao.Empresa)=" & CodEmpresa & ") AND ((Produtos.ControlaEstoque)='SIM'));"

                CmdEstoque.ExecuteNonQuery()

                For Each row As DataGridViewRow In Lista1.Rows

                    CmdEstProd.CommandText = "SELECT Sum(EstoqueUP.Qtd) AS Estoque  FROM EstoqueUP WHERE (((EstoqueUP.CodigoProduto)=" & row.Cells("cProduto").Value & ") AND ((EstoqueUP.Tipo) NOT IN ('E','S'))) GROUP BY EstoqueUP.CodigoProduto;"
                    Dim Testoque As Double = FormatNumber(nzNUM(CmdEstProd.ExecuteScalar), 3)


                    CmdEstProd.CommandText = "Update Produtos set EmLocacao = @1 Where CodigoProduto = " & row.Cells("cProduto").Value
                    CmdEstProd.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUM(Testoque)))

                    CmdEstProd.ExecuteNonQuery()
                    CmdEstProd.Parameters.Clear()

                Next
                'fim da rotina de atualização de estoque e tabela de produtos

                'Atualiza a data de fechamento
                cmdAtualizaFechamento.CommandText = "Update Locacao set DataEfetivaRetorno = @DataEfetivaRetorno, StatusLoc =@StatusLoc WHERE IdLoc = " & numloc
                cmdAtualizaFechamento.Parameters.Add(New OleDb.OleDbParameter("@DataEfetivaRetorno", nzDAT(DataDia)))
                cmdAtualizaFechamento.Parameters.Add(New OleDb.OleDbParameter("@StatusLoc", "DEVOLVIDO"))
                cmdAtualizaFechamento.ExecuteNonQuery()
                ' btnBuscar_Click(sender, e)
            Next

            Transacao.Commit()

            CNN.Close()

            'Fazer impressao de Documento aqui
            'System.Threading.Thread.Sleep(2000)
            'RelatorioCarregar = "LocacaoContrato"
            'My.Forms.VisualizadorRelatorio.ShowDialog()
            'Fim

            MessageBox.Show("Locação Devolvida com sucesso", "Validação de dados", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'gravando informações no log de eventos
            Dim log As New Log With {
                .Locacao = numloc,
                .DataAcao = DateTime.Now,
                .User = UserAtivo
            }

            Dim app As New SerializarJson()
            app.GravarJSON(log)
            'fim da log de enventose 

            EncheListaItens(0)



        Catch ex As Exception
            Transacao.Rollback()
            If ConnectionState.Open Then
                CNN.Close()
            End If
            MsgBox("Erro ao salvar dados da locação.", 64, "Validação de Dados")
            MsgBox(ex.Message, 64, "Validação de Dados")
        End Try
    End Sub
End Class