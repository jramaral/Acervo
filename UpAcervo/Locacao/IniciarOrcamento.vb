Public Class IniciarOrcamento
    Dim f As New LocacaoClientesProcura
    Private Sub Wizard1_NextButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Wizard1.NextButtonClick



        If Me.opt_com_cadastro.Checked Then

            f.ShowDialog()
            Me.txtNomeCliente.Text = f.xCliente.Text
            Me.txtTelefone.Text = f.xTelefone.Text
            Me.txtCidade.Text = f.xCidade.Text
            Me.txtID.Text = f.ID.Text

            Me.txtNomeCliente.ReadOnly = True
            Me.txtTelefone.ReadOnly = True
            Me.txtCidade.ReadOnly = True
            Me.txtID.Text = f.ID.Text

        Else
            Me.txtID.Clear()

            Me.txtNomeCliente.ReadOnly = False
            Me.txtTelefone.ReadOnly = False
            Me.txtCidade.ReadOnly = False
            Me.txtNomeCliente.Focus()
        End If


    End Sub
    Private Sub Wizard1_FinishButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Wizard1.FinishButtonClick
        If Me.opt_sem_cadastro.Checked And String.IsNullOrEmpty(Me.txtTelefone.Text) Or String.IsNullOrEmpty(Me.txtNomeCliente.Text) Then
            MessageBox.Show("Insira um telefone e o nome do cliente para prosseguir!", "Validação", MessageBoxButtons.OK)
            Exit Sub
        End If
        Me.Check1.Checked = True
        'Me.Dispose()
        Close()
    End Sub

    Private Sub Wizard1_CancelButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Wizard1.CancelButtonClick
        Me.Check1.Checked = False
    End Sub
End Class