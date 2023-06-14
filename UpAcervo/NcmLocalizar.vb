﻿Public Class NcmLocalizar

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        DestroyHandle()
    End Sub

    Private Sub txtProcura_Leave(sender As Object, e As EventArgs) Handles txtProcura.Leave
        Try
            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))


            CNN.Open()


            Dim Sql As String = ""
            If Me.A1.Checked = True Then
                Sql = "SELECT * FROM NcmTabela WHERE codNcm = '" & Me.txtProcura.Text & "'"
            End If
            If Me.A2.Checked = True Then
                Sql = "SELECT * FROM NcmTabela WHERE nomeNcm Like '%" & Me.txtProcura.Text & "%'"
            End If

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

    Private Sub NcmLocalizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.A2.Checked = True
        Me.txtProcura.Focus()
    End Sub
    Private Sub A1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A1.CheckedChanged, A2.CheckedChanged
        If Me.A1.Checked = True Then
            Me.txtProcura.Clear()
            Me.txtProcura.Focus()
        End If
        If Me.A2.Checked = True Then
            Me.txtProcura.Clear()
            Me.txtProcura.Focus()
        End If
    End Sub
    Private Sub A3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A3.CheckedChanged
        If Me.A3.Checked = True Then
            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()


            Dim sql As String = "SELECT * FROM NcmTabela"

            Dim CMD As New OleDb.OleDbCommand(sql, CNN)
            Dim Da As New OleDb.OleDbDataAdapter(CMD)

            Dim ds As New DataSet
            Da.Fill(ds, "Table")

            Me.DgvItem.DataSource = ds.Tables("Table").DefaultView

            Da.Dispose()
            CNN.Close()
        End If
    End Sub
    Private Sub DgvItem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvItem.CellDoubleClick
        My.Forms.Ncm.codigo.Text = Me.DgvItem.CurrentRow.Cells(0).Value
        My.Forms.Ncm.descricao.Text = Me.DgvItem.CurrentRow.Cells(1).Value

        Me.Close()
        Me.Dispose()
    End Sub
End Class