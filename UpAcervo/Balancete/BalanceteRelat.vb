Imports System.Data.OleDb
Public Class BalanceteRelat

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub A1_CheckedChanged(sender As Object, e As EventArgs) Handles A1.CheckedChanged, A2.CheckedChanged
        If Me.A1.Checked = True Then
            Me.PainelPeriodo.Visible = True
            Me.PainelContaReceitaDespesa.Visible = False
            Me.DataInicial.Focus()
        End If
        If Me.A2.Checked = True Then
            Me.PainelPeriodo.Visible = True
            Me.PainelContaReceitaDespesa.Visible = True
            Me.DataInicial.Focus()
        End If
        If Me.A3.Checked = True Then
            Me.PainelPeriodo.Visible = True
            Me.PainelContaReceitaDespesa.Visible = False
            Me.DataInicial.Focus()
        End If

    End Sub

    Private Sub btVisualizar_Click(sender As Object, e As EventArgs) Handles btVisualizar.Click

        If Me.A1.Checked = True Then
            If Me.DataInicial.Text = "" Then
                MsgBox("O usuário deve informar a data inicial para o relatório.", 64, "Validação de Dados")
                Me.DataInicial.Focus()
                Exit Sub
            ElseIf Me.DataFinal.Text = "" Then
                MsgBox("O usuário deve informar a data Final para o relatório.", 64, "Validação de Dados")
                Me.DataFinal.Focus()
                Exit Sub
            End If

            RelatorioCarregar = "RelReceitasDespesas"
            My.Forms.VisualizadorRelatorio.ShowDialog()

        End If

        If Me.A2.Checked = True Then
            If Me.DataInicial.Text = "" Then
                MsgBox("O usuário deve informar a data inicial para o relatório.", 64, "Validação de Dados")
                Me.DataInicial.Focus()
                Exit Sub
            ElseIf Me.DataFinal.Text = "" Then
                MsgBox("O usuário deve informar a data Final para o relatório.", 64, "Validação de Dados")
                Me.DataFinal.Focus()
                Exit Sub
            ElseIf Me.ContaBalancete.Text = "" Then
                MsgBox("O usuário deve informar a Conta para o relatório.", 64, "Validação de Dados")
                Me.ContaBalancete.Focus()
                Exit Sub
            End If

            RelatorioCarregar = "RelReceitasDespesasConta"
            My.Forms.VisualizadorRelatorio.ShowDialog()
        End If

        If Me.A3.Checked = True Then
            If Me.DataInicial.Text = "" Then
                MsgBox("O usuário deve informar a data inicial para o relatório.", 64, "Validação de Dados")
                Me.DataInicial.Focus()
                Exit Sub
            ElseIf Me.DataFinal.Text = "" Then
                MsgBox("O usuário deve informar a data Final para o relatório.", 64, "Validação de Dados")
                Me.DataFinal.Focus()
                Exit Sub
            End If

            RelatorioCarregar = "RelDespesasReceitasSintetico"
            My.Forms.VisualizadorRelatorio.ShowDialog()
        End If
    End Sub

    Private Sub btFindDespesas_Click(sender As Object, e As EventArgs) Handles btFindDespesas.Click
        If Me.Nivel1.Checked = True Then My.Forms.BalanceteContasProcura.Nivel = 1
        If Me.Nivel2.Checked = True Then My.Forms.BalanceteContasProcura.Nivel = 2
        If Me.Nivel3.Checked = True Then My.Forms.BalanceteContasProcura.Nivel = 3
        My.Forms.BalanceteContasProcura.ShowDialog()
        AchaContaBalancete(Me.ContaBalancete.Text, Me.ContaBalanceteDesc, Me.ContaBalanceteDesc)
        Me.ContaBalancete.Focus()
    End Sub

    Public Sub AchaContaBalancete(ByVal ContaBalancete As String, ByVal CampoParaRetornar As Control, ContaErro As Control)
        If ContaBalancete = "" Then
            Exit Sub
        End If

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()
        Dim Sql As String = String.Empty

        If Me.Nivel1.Checked = True Then
            Sql = "SELECT *, DescContaGrupo1 as Txt FROM ContasG1 WHERE ContasG1.ContaGrupo1 = '" & ContaBalancete & "' AND Empresa = " & CodEmpresa
        End If
        If Me.Nivel2.Checked = True Then
            Sql = "SELECT *, DescContaGrupo2 as Txt From ContasG2 WHERE ContaGrupo1 = '" & Me.ContaBalancete.Tag & "' and ContaGrupo2 = '" & ContaBalancete & "' AND Empresa = " & CodEmpresa
        End If
        If Me.Nivel3.Checked = True Then
            Sql = "SELECT *, DescContaGrupo3 as Txt From ContasG3 WHERE ContaGrupo3 = '" & ContaBalancete & "' AND Empresa = " & CodEmpresa
        End If

        Dim CMD As New OleDbCommand(Sql, Cnn)
        Dim DR As OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            CampoParaRetornar.Text = DR.Item("Txt") & ""
        Else
            CampoParaRetornar.Text = ""
            ContaErro.Text = ""
        End If
        Cnn.Close()
    End Sub

    Private Sub ContaBalancete_Validated(sender As Object, e As EventArgs) Handles ContaBalancete.Validated
        AchaContaBalancete(Me.ContaBalancete.Text, Me.ContaBalanceteDesc, Me.ContaBalanceteDesc)
    End Sub

    Private Sub ContaBalancete_KeyDown(sender As Object, e As KeyEventArgs) Handles ContaBalancete.KeyDown
        If e.KeyCode = Keys.F5 Then
            My.Forms.BalanceteContasProcura.ShowDialog()
            AchaContaBalancete(Me.ContaBalancete.Text, Me.ContaBalanceteDesc, Me.ContaBalanceteDesc)
            Me.ContaBalancete.Focus()
        End If
    End Sub

    Private Sub Nivel1_CheckedChanged(sender As Object, e As EventArgs) Handles Nivel1.CheckedChanged, Nivel2.CheckedChanged, Nivel3.CheckedChanged
        If Me.Nivel1.Checked Then Me.ContaBalancete.MaxLength = 4
        If Me.Nivel2.Checked Then Me.ContaBalancete.MaxLength = 4
        If Me.Nivel3.Checked Then Me.ContaBalancete.MaxLength = 6

        Me.ContaBalancete.Clear()
        Me.ContaBalanceteDesc.Clear()
        Me.ContaBalancete.Focus()
    End Sub

End Class