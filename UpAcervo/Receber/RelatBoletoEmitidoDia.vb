Public Class RelatBoletoEmitidoDia

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btVisualizar_Click(sender As Object, e As EventArgs) Handles btVisualizar.Click

        Dim Relat As New Reports


        If Me.DataInicial.Text = "" Then
            MsgBox("O usuário deve informar a data inicial para o relatório.", 64, "Validação de Dados")
            Me.DataInicial.Focus()
            Exit Sub
        ElseIf Me.DataFinal.Text = "" Then
            MsgBox("O usuário deve informar a data Final para o relatório.", 64, "Validação de Dados")
            Me.DataFinal.Focus()
            Exit Sub
        End If

        If CDate(Me.DataInicial.Text) > CDate(Me.DataFinal.Text) Then
            MsgBox("A data Final não pode ser maior que a inicial.", 64, "Validação de Dados")
            Me.DataInicial.Clear()
            Me.DataFinal.Clear()
            Me.DataInicial.Focus()
            Exit Sub
        End If


        Relat.BoletosEmitidosDia()


    End Sub

    Private Sub RelatBoletoEmitidoDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If String.IsNullOrEmpty(Me.DataInicial.Text) Then
            Me.DataInicial.Text = DataDia
        End If
        If String.IsNullOrEmpty(Me.DataFinal.Text) Then
            Me.DataFinal.Text = DataDia
        End If
    End Sub
End Class