Imports System.Data.OleDb

Public Class ReceberInserirNF

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click

        If Me.Pedido.Text = "" Then
            MessageBox.Show("Favor informar o numero do Pedido", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Pedido.Focus()
            Exit Sub
        End If
        If Me.nf.Text = "" Then
            MessageBox.Show("Favor informar o numero da NF", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.NF.Focus()
            Exit Sub
        End If


        Dim Ret As Boolean = VerificarPedido(Me.Pedido.Text)
        If Ret = False Then
            Exit Sub
        End If



        Dim Sql As String = String.Empty
        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()


        Sql = "UPDATE Receber SET NotaFiscal = " & Me.NF.Text & " WHERE  (PedidoProdutos = " & Me.Pedido.Text & ")"
        Dim cmd As New OleDbCommand(Sql, Cnn)
        cmd.ExecuteNonQuery()

        Cnn.Close()

        MessageBox.Show("Atualização Realizada com sucesso", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
        Me.Dispose()

    End Sub


    Private Function VerificarPedido(Ped As Integer) As Boolean

        Dim retorno As Boolean

        Dim Sql As String = String.Empty
        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Ds As New DataSet

        Sql = "Select Pedido.PedidoSequencia from Pedido Where Pedido.PedidoSequencia = " & Ped
        Dim cmd As New oledbcommand(Sql, Cnn)
        Dim da As New OleDbDataAdapter(cmd)
        da.Fill(Ds, "TabelaPedido")

        If Ds.Tables("TabelaPedido").Rows.Count = 0 Then
            retorno = False
            MessageBox.Show("Não encontrei este pedido favor selecionar outro.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            retorno = True
        End If

        Ds.Dispose()
        Cnn.Close()

        Return retorno

    End Function


End Class