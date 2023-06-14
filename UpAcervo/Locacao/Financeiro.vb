Imports System.Data.OleDb
Imports System.Text

Public Class Financeiro
    Public Shared Sub AtualizarFinanceiro()

        Dim con As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        con.Open()
        Dim sb As New StringBuilder

        sb.Append("UPDATE  Clientes ")
        sb.Append("SET ValorEmAberto=")
        sb.Append("(SELECT SUM(ValorDocumento) As SomaDeValorTotal ")
        sb.Append("FROM Receber ")
        sb.Append("WHERE CodCliente = Codigo And Receber.Recebimento Is Null)")

       try 
           dim cmd as New OleDbCommand(sb.ToString(),con)
           cmd.ExecuteNonQuery()
          
           con.Dispose()
       Catch ex As Exception
            MessageBox.Show("Não foi possível atualizar os valores do financeiro","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning)
       End Try
      
    End Sub
End Class
