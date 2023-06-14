Imports System.Data.OleDb
Imports System.Text
Public Class ReceberCliProcura


    Private Sub TxtProcura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProcura.Leave
        If Me.TxtProcura.Text = "" Then
            Exit Sub
        End If

        If Me.A1.Checked = True Then BuscarCliente(1)
        If Me.A2.Checked = True Then BuscarCliente(2)
        If Me.A3.Checked = True Then BuscarCliente(3)
        If Me.A5.Checked = True Then BuscarCliente(5)

    End Sub


    Private Sub BuscarCliente(ByVal Opt As String)

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        'Dim Sql As String = String.Empty
        Dim sql As New StringBuilder()
        Select Case Opt
            Case 1
                sql.Append("SELECT Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Sum(Receber.ValorDocumento) AS ValorTotal")
                sql.Append(" From Receber INNER Join Clientes On Receber.CodCliente = Clientes.Codigo")
                sql.Append(" Group By Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Empresa, Receber.Baixado")
                sql.Append(" HAVING (((Clientes.Codigo) Like '%" & Me.TxtProcura.Text & "%') AND ((Clientes.Empresa)=" & CodEmpresa & ") AND ((Receber.Baixado)=False))")
                sql.Append(" Order By Clientes.Nome;")
            Case 2
                sql.Append("SELECT Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Sum(Receber.ValorDocumento) AS ValorTotal")
                sql.Append(" From Receber INNER Join Clientes On Receber.CodCliente = Clientes.Codigo")
                sql.Append(" Group By Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Empresa, Receber.Baixado")
                sql.Append(" HAVING (((Clientes.Nome) Like '%" & Me.TxtProcura.Text & "%') AND ((Clientes.Empresa)=" & CodEmpresa & ") AND ((Receber.Baixado)=False))")
                sql.Append(" ORDER BY Clientes.Nome;")

            Case 3
                sql.Append("SELECT Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Sum(Receber.ValorDocumento) AS ValorTotal")
                sql.Append(" From Receber INNER Join Clientes On Receber.CodCliente = Clientes.Codigo")
                sql.Append(" Group By Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Empresa, Receber.Baixado")
                sql.Append(" HAVING (((Clientes.CpfCgc) Like '%" & Me.TxtProcura.Text & "%') AND ((Clientes.Empresa)=" & CodEmpresa & ") AND ((Receber.Baixado)=False))")
                sql.Append(" ORDER BY Clientes.Nome;")

            Case 4
                sql.Append("SELECT Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Sum(Receber.ValorDocumento) AS ValorTotal")
                sql.Append(" From Receber INNER Join Clientes On Receber.CodCliente = Clientes.Codigo")
                sql.Append(" Group By Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Empresa, Receber.Baixado")
                sql.Append(" HAVING(((Clientes.Empresa) = " & CodEmpresa & ") And ((Receber.Baixado) = False))")
                sql.Append(" Order By Clientes.Nome;")
            Case 5
                sql.Append("SELECT Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Sum(Receber.ValorDocumento) AS ValorTotal")
                sql.Append(" From Receber INNER Join Clientes On Receber.CodCliente = Clientes.Codigo")
                sql.Append(" Group By Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Empresa, Receber.Baixado")
                sql.Append(" HAVING (((Clientes.NomeFantasia) Like '%" & Me.TxtProcura.Text & "%') AND ((Clientes.Empresa)=" & CodEmpresa & ") AND ((Receber.Baixado)=False))")
                sql.Append(" ORDER BY Clientes.Nome;")

        End Select

        Dim da = New OleDbDataAdapter(sql.ToString(), Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub Fechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TelaProcura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtProcura.Focus()
        Me.A2.Checked = True
    End Sub

    Private Sub CampoChave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles A1.Click, A2.Click, A3.Click
        Me.TxtProcura.Focus()
    End Sub

    Private Sub Lista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lista.CellDoubleClick
        Dim vID As Integer
        vID = CInt(Me.Lista.CurrentRow.Cells(0).Value)

        If My.Forms.Receber.Visible = True Then My.Forms.Receber.Cliente.Text = vID
        If My.Forms.ReceberBaixaLote.Visible = True Then My.Forms.ReceberBaixaLote.Cliente.Text = vID
        If My.Forms.ReceberAgrupar.Visible = True Then My.Forms.ReceberAgrupar.Cliente.Text = vID

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub A1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A1.CheckedChanged, A2.CheckedChanged, A3.CheckedChanged, A5.CheckedChanged
        If Me.A1.Checked = True Then
            Me.TxtProcura.Focus()
        End If
        If Me.A2.Checked = True Then
            Me.TxtProcura.Focus()
        End If
        If Me.A3.Checked = True Then
            Me.TxtProcura.Focus()
        End If
        If Me.A5.Checked = True Then
            Me.TxtProcura.Focus()
        End If
    End Sub

    Private Sub A4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A4.CheckedChanged
        BuscarCliente(4)
    End Sub
End Class