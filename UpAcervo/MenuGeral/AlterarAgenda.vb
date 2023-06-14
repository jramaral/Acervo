Imports Agendamento

Public Class AlterarAgenda


    Dim app = New Compromisso
    Public Sub New(codigo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblcodigo.Text = codigo
    End Sub

    Private Sub ButtonX2_Click_1(sender As Object, e As EventArgs) Handles ButtonX2.Click
        DestroyHandle()
    End Sub

    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
        
        Dim c = New CompromissoProperts()
        c.DataCompromisso = novadata.Value
        c.HoraCompromisso = novahora.Value
        c.Tag = c.DataCompromisso.ToString("dddd").Replace("-feira", "").ToUpper()
        c.Descricao = txtAgendarTo.Text
        c.Subject = ""
        c.Observacao = txtDescricao.Text
        c.Status=cboStatus.Text

        c.Id = lblcodigo.Text
        Try
            app.AddNewCompromisso(c)
            Close()
            Dispose()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AlterarAgenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cp As New CompromissoProperts
        cp = app.GetAgendamento(Convert.ToInt32(lblcodigo.Text))

        novadata.Value = cp.DataCompromisso
        novahora.Value = cp.HoraCompromisso
        txtAgendarTo.Text = cp.Descricao
        txtDescricao.Text=cp.Observacao
        cboStatus.Text=cp.Status




    End Sub
End Class