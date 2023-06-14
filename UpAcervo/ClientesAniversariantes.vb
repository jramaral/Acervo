Public Class ClientesAniversariantes

    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.DestroyHandle()
    End Sub

    Private Sub Visualizar_Click(sender As Object, e As EventArgs) Handles Visualizar.Click

        RelatorioCarregar = "ClientesAniversariantes.rpt"

        'chama a classe e passa os parametros para o relatorio
        Dim f As New ClassView.cView
        Dim strParam As String = "Month ({Clientes.DataNascimento})=" & cMeses.SelectedValue
        f.frm(DirRelat & RelatorioCarregar, LocalBD & Nome_BD, SenhaBancoDados, "Aniversariantes do mês de " & cMeses.Text, strParam)



    End Sub
    Private Sub carregaMeses()
        ' Uma base ...
        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("nome", GetType(String))
        dt.Rows.Add(New Object() {1, "JANEIRO"})
        dt.Rows.Add(New Object() {2, "FEVEREIRO"})
        dt.Rows.Add(New Object() {3, "MARÇO"})
        dt.Rows.Add(New Object() {4, "ABRIL"})
        dt.Rows.Add(New Object() {5, "MAIO"})
        dt.Rows.Add(New Object() {6, "JUNHO"})
        dt.Rows.Add(New Object() {7, "JULHO"})
        dt.Rows.Add(New Object() {8, "AGOSTO"})
        dt.Rows.Add(New Object() {9, "SETEMBRO"})
        dt.Rows.Add(New Object() {10, "OUTUBRO"})
        dt.Rows.Add(New Object() {11, "NOVEMBRO"})
        dt.Rows.Add(New Object() {12, "DEZEMBRO"})
        cMeses.DataSource = dt
        cMeses.DisplayMember = "nome"
        cMeses.ValueMember = "id"
        cMeses.SelectedIndex = -1




    End Sub
    Private Sub ClientesAniversariantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        carregaMeses()

    End Sub
End Class