Imports System.Data.OleDb
Imports controls.Locacao
Public Class RelatorioProduto
    Public tot as Decimal=0
    Public totAnt as Decimal=0
    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Dispose()
    End Sub

    Private Sub Visualizar_Click(sender As Object, e As EventArgs) Handles Visualizar.Click

        dim d as long = DateDiff(DateInterval.Day , CDate(DataInicial.text),CDate(DataFinal.Text))

        If(d<30) Then
            MessageBox.Show("Intervalo deverá ser de no mínimo 30 dias","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning)
            exit sub
        End If


        Try

            Me.Cursor = Cursors.WaitCursor

            Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            Cnn.Open()

            Dim consultaEstoque As New ControlsEstoque(Cnn)

            Dim res = consultaEstoque.ValorDoEstoque(CDate(DataInicial.Text), CDate(DataFinal.Text))

            Dim cmd As New OleDbCommand("Select * from ValorEstoque", Cnn)
            Dim adp As New OleDbDataAdapter(cmd)
            Dim ds As New DataSet
            adp.Fill(ds, "ValorEstoque")

            Dim builder As New OleDbCommandBuilder(adp)


            For Each produto As Produto In res
                produto.VeProduto = produto.Qtde * produto.Custo

                Dim row = ds.Tables("ValorEstoque").NewRow()

                row("CodigoProduto") = produto.Codigo
                row("Qtd") = produto.Qtde
                row("Tipo") = produto.Tipo
                row("CodigoGrupo") = produto.CodigoGrupo
                row("NomeGrupo") = produto.NomeGrupo
                row("NomeProduto") = produto.NomeProduto
                row("Custo") = produto.Custo

                ds.Tables("ValorEstoque").Rows().Add(row)

            Next

            adp.Update(ds.Tables(0))
            'fim da inserção na tabela valor estoque


            'Inserir o valor do estoque anterior
            Dim ant = consultaEstoque.ValorDoEstoqueAnterior(CDate(DataInicial.Text))

            For Each produto As Produto In ant
                produto.VeProduto = produto.Qtde * produto.Custo
            Next

            cmd = New OleDbCommand("Select * from ValorEstoqueAnterior", Cnn)
            adp = New OleDbDataAdapter(cmd)
            ds = New DataSet()
            adp.Fill(ds, "ValorEstoqueAnterior")

            builder = New OleDbCommandBuilder(adp)
            

            tot = ant.Sum(Function(item) item.VeProduto)

            Dim row1 = ds.Tables("ValorEstoqueAnterior").NewRow()
            row1("ValorEstoqueAnterior") = tot
            ds.Tables("ValorEstoqueAnterior").Rows().Add(row1)
            adp.Update(ds.Tables("ValorEstoqueAnterior"))

           
            Me.Cursor = Cursors.Default
            RelatorioCarregar = "ValorDoEstoque"
            My.Forms.VisualizadorRelatorio.ShowDialog()

            Me.Cursor = Cursors.WaitCursor
            'remove os registro inseridos
            Dim c1 as new OleDbCommand("Delete * from ValorEstoque",cnn)
            c1.ExecuteNonQuery()

            Dim c2 as New OleDbCommand("Delete * from ValorEstoqueAnterior",cnn)
            c2.ExecuteNonQuery()
            Me.Cursor = Cursors.Default
            Cnn.Close()
            


        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try


    End Sub
End Class