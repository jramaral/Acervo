Imports System.Data.OleDb

Public Class NFeSalvarInfCPL

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub NFeSalvarInfCPL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Forms.NFeValidarDados.Visible = True Then
            If My.Forms.NFeValidarDados.infCpl.Text <> "" Then
                Me.Descricao.Text = My.Forms.NFeValidarDados.infCpl.Text
            End If
        End If
    End Sub

    Private Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click


        Dim Ds As New DataSet
        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "SELECT * From NFeInfCPL Where xNome = '" & Me.xNome.Text & "'"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim Da As New OleDbDataAdapter(Cmd)
        Da.Fill(Ds, "NFeInfCpl")

        If Ds.Tables("NFeInfCpl").Rows.Count = 0 Then

            Dim DRnovo As DataRow
            DRnovo = Ds.Tables("NFeInfCpl").NewRow

            DRnovo("xNome") = nzNUL(Me.xNome.Text)
            DRnovo("Descricao") = nzNUL(Me.Descricao.Text)
            Ds.Tables("NFeInfCpl").Rows.Add(DRnovo)

            Try
                Dim ObjADD As New OleDbCommandBuilder(Da)
                Da.Update(Ds, "NFeInfCpl")
                MessageBox.Show("Registro saldo com sucesso.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cnn.Close()
            End Try
            
        Else

            Ds.Tables("NFeInfCpl").Rows(0).BeginEdit()
            Ds.Tables("NFeInfCpl").Rows(0)("Descricao") = nzNUL(Me.Descricao.Text)
            Ds.Tables("NFeInfCpl").Rows(0).EndEdit()

            Try
                Dim ObjADD As New OleDbCommandBuilder(Da)
                Da.Update(Ds, "NFeInfCpl")
                MessageBox.Show("Registro saldo com sucesso.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cnn.Close()
            End Try
            
        End If

        Cnn.Close()


    End Sub

End Class