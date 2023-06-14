Public Class TabelaGen

    Private Sub TabelaGen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()


        Dim sql As String = "SELECT * FROM TabelaGen"

        Dim CMD As New OleDb.OleDbCommand(sql, CNN)
        Dim Da As New OleDb.OleDbDataAdapter(CMD)

        Dim ds As New DataSet
        Da.Fill(ds, "Table")

        Me.DgvItem.DataSource = ds.Tables("Table").DefaultView

        Da.Dispose()
        CNN.Close()
    End Sub

    Private Sub txtProcura_Leave(sender As Object, e As EventArgs) Handles txtProcura.Leave
        Try
            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))


            CNN.Open()


            Dim Sql As String = ""
           
            Sql = "SELECT * FROM TabelaGen WHERE descricaogen Like '%" & Me.txtProcura.Text & "%'"


            Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
            Dim Da As New OleDb.OleDbDataAdapter(CMD)

            Dim ds As New DataSet
            Da.Fill(ds, "Table")

            Me.DgvItem.DataSource = ds.Tables("Table").DefaultView


            Da.Dispose()
            CNN.Close()
        Catch oE As System.Exception
            Select Case Err.Number
                Case 5
                    MsgBox("Registro não encontrado ou critério incorreto para a consulta", 48, "Atenção")
                Case Else
                    MsgBox(oE.Message)
            End Select
        End Try
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.DestroyHandle()

    End Sub

    Private Sub DgvItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvItem.CellContentClick
        Try
           
        Catch ex As Exception

        End Try
    End Sub

End Class