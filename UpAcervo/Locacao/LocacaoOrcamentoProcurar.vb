Imports System.Data.OleDb
Imports System.Text

Public Class LocacaoOrcamentoProcurar

    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub



    Private Sub BuscarLocacao(ByVal opt As String)

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT LocacaoOrcamento.IdLoc, LocacaoOrcamento.DataLoc, LocacaoOrcamento.NomeCliente,LocacaoOrcamento.TotalLoc, LocacaoOrcamento.StatusLoc, LocacaoOrcamento.NomeVendedor FROM LocacaoOrcamento WHERE "& Opt 
        Try 
            Dim da = New OleDbDataAdapter(Sql, Cnn)
            Dim ds As New DataSet
            da.Fill(ds, "Table")

            Me.Lista.DataSource = ds.Tables("Table").DefaultView

            da.Dispose()
            Cnn.Close()
        Catch ex As Exception

        End Try
    
    End Sub
    
    Private Sub Lista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lista.CellDoubleClick
        Dim vID As Integer
        vID = CInt(Me.Lista.CurrentRow.Cells("cIdLoc").Value)

        Dim f As New LocacaoOrcamento(vID)
        f.ShowDialog()
        
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        dim sb = New StringBuilder
        dim i=0
        If(Not String.IsNullOrEmpty(txtNumero.Text)) then
            If i>=1 Then
                sb.Append(" AND ")
            End If
            i=i+1
            sb.Append("LocacaoOrcamento.IdLoc = " & txtNumero.Text)
    
        End If

       
        If(Not String.IsNullOrEmpty(txtData.Text)) Then
            If i>=1 Then
                sb.Append(" AND ")
            End If
            i=i+1
            sb.Append("LocacaoOrcamento.DataLoc=#" & Format(CDate(Me.txtData.Text), "dd/MM/yyyy") & "#")

        End If
       
        If (Not String.IsNullOrEmpty(txtNome.text)) Then
            If i>=1 Then
                sb.Append(" AND ")
            End If
            i=i+1
            sb.Append("LocacaoOrcamento.NomeCliente like '%" & txtNome.Text & "%'")
            
        End If
      
        If(Not String.IsNullOrEmpty(txtVendedor.Text)) Then
            If i>=1 Then
                sb.Append(" AND ")
            End If
            i=i+1
            sb.Append("LocacaoOrcamento.NomeVendedor like '%" & txtVendedor.Text & "%'" )
            
        End If

        'se for maior q zero tem informacao para filtrar
        If(i>0) Then
            BuscarLocacao(sb.ToString())
        End If


    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        txtNumero.Clear()
        txtData.Clear()
        txtNome.Clear()
        txtVendedor.Clear()

    End Sub
End Class