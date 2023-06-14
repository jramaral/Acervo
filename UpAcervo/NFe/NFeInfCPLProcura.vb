Imports System.Data.OleDb
Public Class NFeInfCPLProcura


    Private Sub BuscarInfCPL()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "Select * From NFeInfCPL"


        Dim da = New OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub Fechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TelaProcura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarInfCPL()
    End Sub

    Private Sub Lista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lista.CellDoubleClick
        Dim vDesc As String
        vDesc = Me.Lista.CurrentRow.Cells("cDescricao").Value


        If My.Forms.NFeValidarDados.Visible = True Then
            My.Forms.NFeValidarDados.infCpl.Text = vDesc
        End If

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub Lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Lista.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim vDesc As String
            vDesc = Me.Lista.CurrentRow.Cells("cDescricao").Value


            If My.Forms.NFeValidarDados.Visible = True Then
                My.Forms.NFeValidarDados.infCpl.Text = vDesc
            End If

            Me.Close()
            Me.Dispose()

        End If
    End Sub

    Private Sub Lista_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lista.SelectionChanged
        Try
            Dim vDesc As String
            vDesc = Me.Lista.CurrentRow.Cells("cDescricao").Value


            Me.Descricao.Text = vDesc
            
        Catch ex As Exception
        End Try
    End Sub


End Class