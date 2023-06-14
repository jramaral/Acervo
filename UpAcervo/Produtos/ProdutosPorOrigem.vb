Public Class ProdutosPorOrigem
    Private Sub btnVisualizar_Click(sender As Object, e As EventArgs) Handles btnVisualizar.Click
        RelatorioCarregar="ProdutosPorOrigem"
        My.Forms.VisualizadorRelatorio.ShowDialog()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
        Dispose()

    End Sub
End Class