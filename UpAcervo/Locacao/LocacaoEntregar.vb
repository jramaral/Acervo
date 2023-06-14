Imports System.Data.OleDb
Public Class LocacaoEntregar
    Private Sub BuscarLocacao()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE Locacao.StatusLoc='LOCADO' AND Locacao.ProdutosEntregue=False"


        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()

    End Sub
    Private Sub LocacaoEntregar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarLocacao()
    End Sub

    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Lista_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Lista.CellClick

        If Me.Lista.Columns(e.ColumnIndex).Name = "gEntregar" Then

            Dim numLoc As String = Lista.Rows(e.RowIndex).Cells(1).Value

            My.Forms.Locacao.IdSeletor = numLoc
            My.Forms.Locacao.ShowDialog()
            BuscarLocacao()

        End If

    End Sub
End Class