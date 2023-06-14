Imports System.Data.OleDb
Public Class LocacaoCancelar
    Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        If Len(CaixaAtivo) <> 4 Then
            MessageBox.Show("O usuario deve selecionar um caixa antes de prosseguir com o documento. Verifique", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Me.idlocacao.Text = "" Then
            MessageBox.Show("Não foi informado o numero da Locação, Verifique", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim Autorizado As Boolean = PedirPermissao(Me.Text, Me.idlocacao.Text)
        Autorizado = varAutorizado
        If Autorizado = False Then
            Exit Sub
        End If

        'Tratamento de cone~xao
        If CNN.State = ConnectionState.Closed Then
            CNN.Open()
        End If

        Dim Transacao As OleDbTransaction = CNN.BeginTransaction()

        Dim CmdLocacao As OleDbCommand = CNN.CreateCommand()
        Dim CmdLocacaoItens As OleDbCommand = CNN.CreateCommand()
        Dim CmdReceber As OleDbCommand = CNN.CreateCommand()
        Dim CmdEstoque As OleDbCommand = CNN.CreateCommand()
        Dim CmdEstProd As OleDbCommand = CNN.CreateCommand
        Dim CmdCaixa As OleDbCommand = CNN.CreateCommand
        Dim CmdBanco As OleDbCommand = CNN.CreateCommand
    
        CmdLocacao.Transaction = Transacao
        CmdLocacaoItens.Transaction = Transacao
        CmdReceber.Transaction = Transacao
        CmdEstoque.Transaction = Transacao
        CmdEstProd.Transaction = Transacao
        CmdCaixa.Transaction = Transacao
        CmdBanco.Transaction = Transacao




        Dim Sql As String = "Select * from Locacao where  idloc = " & Me.idlocacao.Text & " AND StatusLoc IN ('LOCADO','DEVOLVIDO','INICIAL');"
        CmdLocacao.CommandText = Sql
        Dim DR As OleDb.OleDbDataReader

        DR = CmdLocacao.ExecuteReader
        DR.Read()

        Dim StatusLoc As String = String.Empty

        Try
            'tem dados então executa 
            If DR.HasRows = True Then

                Dim ds As New DataSet
                Sql = "SELECT * from LocacaoItens Where IdLocacao  = " & Me.idlocacao.Text
                Dim cmdItemLoc As New OleDb.OleDbCommand(Sql, CNN, Transacao)

                Dim DAItemLocacao As New OleDb.OleDbDataAdapter(cmdItemLoc)
                DAItemLocacao.Fill(ds, "ItemLo")

                'Excluindo os itens de locação
                Sql = "Delete * From LocacaoItens where IdLocacao=" & Me.idlocacao.Text
                CmdLocacaoItens.CommandText = Sql
                CmdLocacaoItens.ExecuteNonQuery()

                'Extornando valores do caixa
                Sql = "INSERT INTO LancamentoBanco ( DataLancamento, TipoLancamento, ContaCorrente, Tipo, Favorecido, Documento, ValorDocumento, IdLancamento, IdProcura, ContaBalancete, CaiuBanco, ConfirmadoLancamento, Historico, DataDocumento, Empresa )" _
                    & " SELECT #" & Format(CDate(DataDia), "MM/dd/yyyy") & "#, LancamentoBanco.TipoLancamento, LancamentoBanco.ContaCorrente, LancamentoBanco.Tipo, LancamentoBanco.Favorecido, LancamentoBanco.Documento, [LancamentoBanco.ValorDocumento] * -1 AS Expr1, LancamentoBanco.IdLancamento, LancamentoBanco.IdProcura, LancamentoBanco.ContaBalancete, LancamentoBanco.CaiuBanco, LancamentoBanco.ConfirmadoLancamento, 'Extorno ' & [LancamentoBanco.Historico] AS Expr2, LancamentoBanco.DataDocumento, LancamentoBanco.Empresa " _
                    & " FROM LancamentoBanco INNER JOIN Receber ON LancamentoBanco.IdProcura = Receber.ID WHERE (((LancamentoBanco.Tipo)='CAIXA') AND ((LancamentoBanco.IdLancamento)='RECEBER') AND ((Receber.PedidoProdutos)=" & Me.idlocacao.Text & "));"

                CmdCaixa.CommandText = Sql
                CmdCaixa.ExecuteNonQuery()


                'Removendo do banco
                Sql = "Delete  l.*  from LancamentoBanco As l, Receber As r Where r.id=l.idprocura AND l.Tipo='BANCO' AND r.PedidoProdutos = " & Me.idlocacao.Text
                CmdBanco.CommandText = Sql
                CmdBanco.ExecuteNonQuery()

                'Excluindo o recebimento
                Sql = "Delete * from Receber Where PedidoProdutos = " & Me.idlocacao.Text & " AND Baixado=False;"
                CmdReceber.CommandText = Sql
                CmdReceber.ExecuteNonQuery()

                'Atualizando estoque
                Sql = "Delete * from EstoqueUP Where PedidoOrdem = " & Me.idlocacao.Text & " AND Tipo IN('L','R');"
                CmdEstoque.CommandText = Sql
                CmdEstoque.ExecuteNonQuery()

                'Atualiza os produtos
                'loop em cada item da lista 
                For Each row As DataRow In ds.Tables("ItemLo").Rows

                    CmdEstProd.CommandText = "SELECT Sum(EstoqueUP.Qtd) AS Estoque  FROM EstoqueUP WHERE (((EstoqueUP.CodigoProduto)=" & row.Item("Produto") & ") AND ((EstoqueUP.Tipo) NOT IN('E','S'))) GROUP BY EstoqueUP.CodigoProduto;"

                    Dim dEmLocacao As Double = FormatNumber(nzNUM(CmdEstProd.ExecuteScalar), 3)



                    CmdEstProd.CommandText = "SELECT Count(Qtd) AS QtdLoc FROM EstoqueUP GROUP BY EstoqueUP.CodigoProduto, EstoqueUP.Tipo HAVING (((EstoqueUP.[CodigoProduto])=" & row.Item("Produto") & ") AND ((EstoqueUP.Tipo)='L'));"
                    Dim tQTDLocacao As Double = FormatNumber(NzZero(CmdEstProd.ExecuteScalar), 3)


                    CmdEstProd.CommandText = "Update Produtos set EmLocacao = @1, QtdeLocado = @2 Where CodigoProduto = " & row.Item("Produto")
                    CmdEstProd.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUM(dEmLocacao)))
                    CmdEstProd.Parameters.Add(New OleDb.OleDbParameter("@2", nzNUM(tQTDLocacao)))
                    CmdEstProd.ExecuteNonQuery()
                    CmdEstProd.Parameters.Clear()

                Next
                'fim da rotina de atualização de estoque e tabela de produtos


                'Atualiza o estatus da locacao
                Sql = "Update Locacao set StatusLoc = 'CANCELADO' Where IDLOC = " & Me.idlocacao.Text

                CmdLocacao = New OleDbCommand(Sql, CNN, Transacao)

                CmdLocacao.ExecuteNonQuery()




                Transacao.Commit()
                CNN.Close()

                MessageBox.Show("Locação cancelada....Verifique se não existe erro no caixa.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                'Atualiza o estatus da locacao
                Sql = "Update Locacao set StatusLoc = 'CANCELADO' Where IDLOC = " & Me.idlocacao.Text

                CmdLocacao = New OleDbCommand(Sql, CNN, Transacao)

                CmdLocacao.ExecuteNonQuery()
                Transacao.Commit()
                CNN.Close()
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
End Class