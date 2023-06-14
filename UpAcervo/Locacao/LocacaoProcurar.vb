Imports System.Data.OleDb
Public Class LocacaoProcurar

    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub LocacaoProcurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TxtProcura.Focus()
        Me.A1.Checked = True
    End Sub

    Private Sub TxtProcura_Enter(sender As Object, e As EventArgs) Handles TxtProcura.Enter
        If Me.A1.Checked = True Then
            Me.TxtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
            Me.TxtProcura.CasasDecimais = 0
        End If

        If Me.A2.Checked = True Then
            Me.TxtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
            Me.TxtProcura.CasasDecimais = 0
        End If

        If Me.A3.Checked = True Then
            Me.TxtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
            Me.TxtProcura.CasasDecimais = 0
        End If

        If Me.A4.Checked = True Then
            Me.TxtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
            Me.TxtProcura.CasasDecimais = 0
        End If

    End Sub



    Private Sub BuscarLocacao(ByVal Opt As String)

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty


        If My.Forms.Devolucao.Visible = True Then
            Select Case Opt
                Case 1 'busca por codigo da Locação
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Locacao.IdLoc)=" & Me.TxtProcura.Text & ") AND ((Locacao.StatusLoc)='LOCADO'))  ORDER BY DataLoc"
                Case 2 'busca por Codigo do cliente
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Locacao.Cliente)=" & Me.TxtProcura.Text & ") AND ((Locacao.StatusLoc)='LOCADO'))  ORDER BY DataLoc"
                Case 3 'busca por Nome do Cliente
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Clientes.Nome like '%" & Me.TxtProcura.Text & "%')) AND ((Locacao.StatusLoc)='LOCADO'))  ORDER BY DataLoc"
                Case 4 'busca por Data de Locação
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Locacao.DataLoc)=#" & Format(CDate(Me.TxtProcura.Text), "dd/MM/yyyy") & "#) AND ((Locacao.StatusLoc)='LOCADO'))  ORDER BY DataLoc"
                Case 5
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Locacao.StatusLoc)='LOCADO'))"
            End Select
        Else
            Select Case Opt
                Case 1 'busca por codigo da Locação
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Locacao.IdLoc)=" & Me.TxtProcura.Text & "))  ORDER BY DataLoc"
                Case 2 'busca por Codigo do cliente
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Locacao.Cliente)=" & Me.TxtProcura.Text & "))  ORDER BY DataLoc"
                Case 3 'busca por Nome do Cliente
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Clientes.Nome like '%" & Me.TxtProcura.Text & "%')))  ORDER BY DataLoc"
                Case 4 'busca por Data de Locação
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo WHERE (((Locacao.DataLoc)=#" & Format(CDate(Me.TxtProcura.Text), "dd/MM/yyyy") & "#))  ORDER BY DataLoc"
                Case 5
                    Sql = "SELECT Locacao.IdLoc, Locacao.DataLoc, Locacao.Cliente, Clientes.Nome, Locacao.TotalLoc, Locacao.StatusLoc, Locacao.DataRetorno FROM Locacao INNER JOIN Clientes ON Locacao.Cliente = Clientes.Codigo  ORDER BY DataLoc"
            End Select
        End If

        

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()

    End Sub


    Private Sub TxtProcura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProcura.Leave
        If Me.TxtProcura.Text = "" Then
            Exit Sub
        End If

        If Me.A1.Checked = True Then BuscarLocacao(1) 'busca por codigo da Locação
        If Me.A2.Checked = True Then BuscarLocacao(2) 'busca por Codigo do cliente
        If Me.A3.Checked = True Then BuscarLocacao(3) 'busca por Nome do Cliente
        If Me.A4.Checked = True Then BuscarLocacao(4) 'busca por Data de Locação

        Me.Lista.Focus()

    End Sub

    Private Sub A1_CheckedChanged(sender As Object, e As EventArgs) Handles A1.CheckedChanged, A2.CheckedChanged, A3.CheckedChanged, A4.CheckedChanged
        Me.TxtProcura.Focus()
    End Sub

    Private Sub Lista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lista.CellDoubleClick
        Dim vID As Integer
        vID = CInt(Me.Lista.CurrentRow.Cells("cIdLoc").Value)

        If My.Forms.Locacao.Visible = True Then My.Forms.Locacao.IdLoc.Text = vID
        If My.Forms.Devolucao.Visible = True Then My.Forms.Devolucao.txtNumeroLocacao.Text = vID
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            BuscarLocacao(5) 'busca todos
        End If
    End Sub
End Class