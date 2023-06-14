Imports Agendamento

Public Class AddCompromisso
    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Close()
        Dispose()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click


        If String.IsNullOrEmpty(txtAgendarTo.Text) Then
            MessageBox.Show("Você precisa inserir informação no campo [Agendar para]", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtDescricao.Text) Then
            MessageBox.Show("Você precisa inserir informação no campo [Descrição]", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End If




        Dim app = New Compromisso
        Dim c = New CompromissoProperts()
        c.DataCompromisso = novadata.Value
        c.HoraCompromisso = novahora.Value
        c.Tag = c.DataCompromisso.ToString("dddd").Replace("-feira", "").ToUpper()
        c.Descricao = txtAgendarTo.Text
        c.Subject = ""
        c.Observacao = txtDescricao.Text
        c.Status=cboStatus.Text

        Try
            app.AddNewCompromisso(c)
            MessageBox.Show("Agendamento gravado!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
            Dispose()
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub novahora_ValueChanged(sender As Object, e As EventArgs) Handles novahora.ValueChanged

    End Sub

    Private Sub AddCompromisso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboStatus.SelectedIndex=0
    End Sub
End Class