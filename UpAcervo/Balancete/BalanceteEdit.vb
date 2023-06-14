Imports System.Data.OleDb

Public Class BalanceteEdit

    Dim TpPesquisa As Integer

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btFiltrar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CarregaLista()
        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Try
            If TpPesquisa = 1 Then
                Sql = "SELECT Id, DataLancamento,Documento,Historico,ValorDocumento,ContaBalancete,Tipo,ContaCorrente,TipoLancamento FROM LancamentoBanco WHERE LancamentoBanco.DataLancamento Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyy") & "#"
            End If
            If TpPesquisa = 2 Then
                Sql = "SELECT Id, DataLancamento,Documento,Historico,ValorDocumento,ContaBalancete,Tipo,ContaCorrente,TipoLancamento FROM LancamentoBanco WHERE LancamentoBanco.Id = " & Me.Identificador.Text
            End If
            If TpPesquisa = 3 Then
                Sql = "SELECT Id, DataLancamento,Documento,Historico,ValorDocumento,ContaBalancete,Tipo,ContaCorrente,TipoLancamento FROM LancamentoBanco WHERE LancamentoBanco.Documento Like '%" & Me.Identificador.Text & "%'"
            End If

            Dim da = New OleDbDataAdapter(Sql, Cnn)
            Dim ds As New DataSet
            da.Fill(ds, "Pagar")

            Me.DG.DataSource = ds.Tables("Pagar").DefaultView

            da.Dispose()
            Cnn.Close()

            Me.DG.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
       

    End Sub

    Private Sub DG_SelectionChanged(sender As Object, e As EventArgs) Handles DG.SelectionChanged
        Try
            Dim vID As Integer
            vID = CInt(NzZero(Me.DG.CurrentRow.Cells("cId").Value))

            Me.Id.Text = Me.DG.CurrentRow.Cells("cid").Value
            Me.DataLancamento.Text = Me.DG.CurrentRow.Cells("cDataLancamento").Value
            Me.Documento.Text = Me.DG.CurrentRow.Cells("cDocumento").Value & ""
            Me.Historico.Text = Me.DG.CurrentRow.Cells("cHistorico").Value & ""
            Me.ValorDocumento.Text = Me.DG.CurrentRow.Cells("cValorDocumento").Value
            Me.ContaBalancete.Text = Me.DG.CurrentRow.Cells("cContaRC").Value & ""
            Me.Tipo.Text = Me.DG.CurrentRow.Cells("cTipo").Value & ""
            Me.ContaCorrente.Text = Me.DG.CurrentRow.Cells("cContaCorrente").Value & ""
            Me.TipoLancamento.Text = Me.DG.CurrentRow.Cells("cTipoLancamento").Value & ""

            AchaContaBalancete()

            'If CDbl(Me.ValorDocumento.Text) < 0 Then
            CarregaListaCentroCusto()
            'End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btFindConta_Click(sender As Object, e As EventArgs) Handles btFindConta.Click
        If CDbl(Me.ValorDocumento.Text) > 0 Then
            My.Forms.BalanceteContasProcura.TipoConta = "C"
            My.Forms.BalanceteContasProcura.ShowDialog()
            AchaContaBalancete()
            Me.ContaBalancete.Focus()
        Else
            My.Forms.BalanceteContasProcura.TipoConta = "D"
            My.Forms.BalanceteContasProcura.ShowDialog()
            AchaContaBalancete()
            Me.ContaBalancete.Focus()
        End If
    End Sub

    Private Sub btSalvarDados_Click(sender As Object, e As EventArgs) Handles btSalvarDados.Click

        If CDbl(Me.ValorDocumento.Text) < 0 Then
            If Me.TipoLancamento.Text = "C" Then
                MessageBox.Show("O tipo de lançamento não pode ser crédito neste lançamento", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If CDbl(Me.ValorDocumento.Text) > 0 Then
            If Me.TipoLancamento.Text = "D" Then
                MessageBox.Show("O tipo de lançamento não pode ser débito neste lançamento", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        Dim Sql As String = String.Empty
        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Transacao As OleDbTransaction = CNN.BeginTransaction()
        Dim CmdBanco As OleDbCommand = CNN.CreateCommand

        CmdBanco.Transaction = Transacao

        Try
            Sql = "Update LancamentoBanco set  ContaBalancete = @ContaBalancete, TipoLancamento = @TipoLancamento Where Id = " & Me.Id.Text
            CmdBanco.CommandText = Sql

            CmdBanco.Parameters.Add(New OleDbParameter("@ContaBalancete", nzNUL(Me.ContaBalancete.Text)))
            CmdBanco.Parameters.Add(New OleDbParameter("@TipoLancamento", nzNUL(Me.TipoLancamento.Text)))
            CmdBanco.ExecuteNonQuery()

            Transacao.Commit()
            CNN.Close()
            CarregaLista()
            MsgBox("Registro Atualizado com sucesso", 64, "Validação de Dados")

        Catch ex As Exception
            Transacao.Rollback()
            CNN.Close()
            MsgBox(ex.Message, 64, "Validação de Dados")
        End Try
    End Sub

    Public Sub CarregaListaCentroCusto()
        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT CcLanc.ContaCC, Cc3.DescContaGrupo3, CcLanc.DataLanc, CcLanc.ValorLanc,Cclanc.Id FROM CcLanc INNER JOIN Cc3 ON CcLanc.ContaCC = Cc3.ContaGrupo3 WHERE (CcLanc.IdCaixaBanco = " & Me.Id.Text & ")"

        Dim da = New OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        ds.Dispose()
        Cnn.Close()

        Dim Vlr As Double = 0
        For Each dr As DataGridViewRow In Me.Lista.Rows
            Vlr += Me.Lista.Rows(dr.Index).Cells("cValorLanc").Value
        Next dr
        Me.TotCentroCusto.Text = FormatNumber(Vlr, 2)

    End Sub

    Private Sub btAddCC_Click(sender As Object, e As EventArgs) Handles btAddCC.Click
        If Me.Id.Text = "" Then
            MessageBox.Show("Favor selecionar um lancamento do caixa/banco.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        My.Forms.BalanceteEditLancCC.TipoOperação = 0
        My.Forms.BalanceteEditLancCC.ShowDialog()

    End Sub

    Private Sub Lista_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Lista.CellDoubleClick
        Dim vID As Integer
        vID = CInt(Me.Lista.CurrentRow.Cells("cIdLanc").Value)

        My.Forms.BalanceteEditLancCC.Id.Text = vID
        My.Forms.BalanceteEditLancCC.TipoOperação = 1
        My.Forms.BalanceteEditLancCC.ShowDialog()

    End Sub

    Public Sub AchaContaBalancete()

        Dim Cn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cn.Open()
        Dim Sql As String = String.Empty

        Sql = "SELECT * FROM ContasG3 WHERE (ContasG3.ContaGrupo3 = '" & Me.ContaBalancete.Text & "') AND (ContasG3.Empresa = " & CodEmpresa & ")"

        Dim CMD As New OleDbCommand(Sql, Cn)
        Dim DR As OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Me.ContaBalanceteDesc.Text = DR.Item("DescContaGrupo3") & ""
        End If
        Cn.Close()
    End Sub

    Private Sub ContaRC_Validated(sender As Object, e As EventArgs) Handles ContaBalancete.Validated
        AchaContaBalancete()
    End Sub

    Private Sub checkDocumento_Click(sender As Object, e As EventArgs) Handles checkDocumento.Click

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If ChequeIdentificador.Checked Then
            If Me.Identificador.Text = "" Then Exit Sub

            TpPesquisa = 2
            CarregaLista()
        ElseIf checkDocumento.Checked Then
            If Me.Identificador.Text = "" Then Exit Sub

            TpPesquisa = 3
            CarregaLista()
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        TpPesquisa = 1
        CarregaLista()
    End Sub
End Class