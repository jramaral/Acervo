Imports Agendamento

Public Class Alert
    Public Sub New (id As String, desc As String, observacao As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Label1.Text=id
        label3.Text=desc
        Label4.Text=observacao
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        DestroyHandle()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        dim f = new AlterarAgenda(Label1.Text)
        Close()
        f.ShowDialog()
    End Sub

    Private Sub Alert_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        try
            Dim app = New Compromisso
            app.RemoveCompromisso(Convert.ToInt32(Label1.Text))
            My.Forms.MenuGeral.AtualizaGridDia()
            DestroyHandle()
           
        Catch ex As Exception
            
        End Try
       



    End Sub
End Class