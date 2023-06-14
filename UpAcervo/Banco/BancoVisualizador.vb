Imports System.Data.OleDb
Public Class BancoVisualizador

    Private Sub Fechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Codigo.KeyDown
        If e.KeyCode = Keys.F5 Then
            If Con = False Then
                MsgBox("O Usuário não tem permissão para consultar o registro, verifique com o Administrador.", 64, "Validação de Dados")
                Exit Sub
            End If

            My.Forms.TelaProcuraBancoCC.ShowDialog()
            Me.Codigo.Focus()

        End If
    End Sub

    Public Sub LocalizaDados()
        If Con = False Then
            MsgBox("O Usuário não tem permissão para consultar o registro, verifique com o Administrador.", 64, "Validação de Dados")
            Me.Codigo.Clear()
            Me.Codigo.Focus()
            Exit Sub
        End If

        If Me.Codigo.Text = "" Then Exit Sub

        Dim DBOpen As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        DBOpen.Open()

        Dim Sql As String = "Select * from Banco where Codigo = '" & Me.Codigo.Text & "' and Empresa = " & CodEmpresa
        Dim CMD As New OleDb.OleDbCommand(Sql, DBOpen)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Me.Codigo.Text = DR.Item("Codigo") & ""
            Me.ContaCorrente.Text = DR.Item("ContaCorrente") & ""
            Me.Agencia.Text = DR.Item("Agencia") & ""
            Me.Banco.Text = DR.Item("NomeBanco") & ""

        Else
            MsgBox("Verique...Conta inexistente.", 64, "Validação de Dados")
            Me.Codigo.Clear()
            Me.Codigo.Focus()
            Exit Sub
        End If
        DR.Close()
    End Sub

    Private Sub Codigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Codigo.Validated
        If Me.Codigo.Text = "" Or Me.Codigo.Text = 0 Then Exit Sub
        LocalizaDados()
        EncheGrid("S")
    End Sub

    Public Sub EncheGrid(Real As String)

        Me.Cursor = Cursors.AppStarting

        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim cmd As New OleDbCommand()
        Dim da As New OleDbDataAdapter()
        Dim dt As New DataTable()
        Try
            Dim sMM As String = CDate(DataDia).Month
            Dim sYY As String = CDate(DataDia).Year

            Dim Sql As String = "select Id,DataLancamento,Documento,Historico,ValorDocumento, CaiuBanco,Favorecido from LancamentoBanco where Tipo = 'BANCO' and CaiuBanco = 'S' and ContaCorrente='" & Me.Codigo.Text & "' and month(DataLancamento)>=" & sMM & " and year(DataLancamento)=" & sYY & " Order by Id DESC"
            cmd = New OleDbCommand(Sql, CNN)

            da.SelectCommand = cmd
            da.Fill(dt)
            DGLanc.DataSource = dt

            Me.Cursor = Cursors.Default

        Catch x As Exception
            MessageBox.Show(x.GetBaseException().ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Finally
            cmd.Dispose()
            CNN.Close()
        End Try
    End Sub

    Private Sub BTCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTCC.Click

        Dim cxFechado As New CaixaFechado
        cxFechado.CaixaEstaFechado()

        TRVDados(UserAtivo, "BancosContaCorrente")
        If Ina = True Then
            MsgBox("O usuário não esta autorizado a usar esta opção do sistema.", 64, "Validação de Dados")
            Exit Sub
        Else
            My.Forms.BancosContaCorrente.ShowDialog()
        End If
    End Sub

    Private Sub Lançamentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lançamentos.Click
        TRVDados(UserAtivo, "BancoLançamento")
        If Ina = True Then
            MsgBox("O usuário não esta autorizado a usar esta opção do sistema.", 64, "Validação de Dados")
            Exit Sub
        Else
            If nzINT(Me.Codigo.Text) = 0 Then
                MessageBox.Show("Favor informar a conta para fazer o lançamento", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            My.Forms.BancoLançamento.ShowDialog()
        End If
    End Sub

    Private Sub Compensar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Compensar.Click
        If Me.Codigo.Text = "" Then
            Exit Sub
        End If
        TRVDados(UserAtivo, "BancoCompensar")
        If Ina = True Then
            MsgBox("O usuário não esta autorizado a usar esta opção do sistema.", 64, "Validação de Dados")
            Exit Sub
        Else
            My.Forms.BancoCompensar.ShowDialog()
        End If
    End Sub

    Private Sub Extrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Extrato.Click
        If Me.Codigo.Text = "" Then
            Exit Sub
        End If
        TRVDados(UserAtivo, "BancoExtrato")
        If Ina = True Then
            MsgBox("O usuário não esta autorizado a usar esta opção do sistema.", 64, "Validação de Dados")
            Exit Sub
        Else
            My.Forms.BancoExtrato.ShowDialog()
        End If

    End Sub

    Private Sub Localizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Localizar.Click
        If String.IsNullOrEmpty(Me.Codigo.Text) Then
            MsgBox("Selecione um banco para continuar.", 64, "Validação de Dados")
            Exit Sub
        End If

        My.Forms.BancoProcurar.ShowDialog()

        LocalizaDados()
        EncheGrid("S")
    End Sub

    Private Sub btFindCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFindCC.Click
        If Con = False Then
            MsgBox("O Usuário não tem permissão para consultar o registro, verifique com o Administrador.", 64, "Validação de Dados")
            Exit Sub
        End If

        My.Forms.TelaProcuraBancoCC.ShowDialog()
        Me.Codigo.Focus()

    End Sub

    Private Sub BancoVisualizador_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btChequePre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btChequePre.Click
        If Me.Codigo.Text = "" Then
            MessageBox.Show("O usuário deve selecionar uma conta antes de emitir o relatório.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        My.Forms.BancoRelChequePre.ShowDialog()
    End Sub
End Class