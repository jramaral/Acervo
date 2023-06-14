Public Class LocacaoRelatorios
    Dim ctr As Control
    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click, RadioButton2.Click,RadioButton5.Click
        ctr = sender
        DataInicial.Focus()
    End Sub

    Private Sub Visualizar_Click(sender As Object, e As EventArgs) Handles Visualizar.Click


        If RadioButton1.Checked Then
            RelatorioCarregar = "MaioresClientes"
        ElseIf RadioButton2.Checked Then
            RelatorioCarregar = "ProdutosMaisLocados"
        ElseIf RadioButton3.Checked Then
            RelatorioCarregar = "MovimentacaoProdutos"
        ElseIf RadioButton4.Checked Then
            RelatorioCarregar = "MaioresClientes2"
        ElseIf RadioButton5.Checked Then
            RelatorioCarregar = "RelLocacaoVendedor"
        End If


        My.Forms.VisualizadorRelatorio.ShowDialog()
    End Sub


    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged,RadioButton5.CheckedChanged
        Me.DataInicial.Enabled = True
        Me.DataFinal.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.DataInicial.Enabled = True
        Me.DataFinal.Enabled = True
    End Sub



    Private Sub RadioButton3_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Me.DataInicial.Enabled = False
        Me.DataFinal.Enabled = False
    End Sub

End Class