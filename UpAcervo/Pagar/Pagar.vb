
Public Class Pagar
    Public nf_Filtro As Boolean = False
    Dim Ação As New TrfGerais()
    Dim strVirtual As Boolean
    Dim DsProcura As DataSet
    Dim Cmd As OleDb.OleDbCommand
    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub EncheLista()
        'Me.MyLista.Columns.Item(0).Width = 24

      

        ' MyLista.Items.Clear()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()
        Dim sql As String = String.Empty
        'If Me.nfFiltro.Text = "" Then
        '    sql = "SELECT id,documento,notafiscal,fornecedor,datadocumento,vencimento,valordocumento,virtual,Destino,IdAgrupamento FROM Pagar WHERE CodFornecedor = " & Me.Fornecedor.Text & " and Baixado = False and Empresa = " & CodEmpresa & " and Inativo = False Order by Vencimento"

        'Else
        '    sql = "SELECT id,documento,notafiscal,fornecedor,datadocumento,vencimento,valordocumento,virtual,Destino,IdAgrupamento FROM Pagar WHERE CodFornecedor = " & Me.Fornecedor.Text & " and Baixado = False and Empresa = " & CodEmpresa & " And NotaFiscal like '" & Me.nfFiltro.Text & "' and Inativo = False Order by Vencimento"
        'End If

        Select Case cboFiltros.SelectedIndex
            Case 0 'todos
                sql = "SELECT id,documento,notafiscal,fornecedor,datadocumento,vencimento,valordocumento,virtual,Destino,IdAgrupamento FROM Pagar WHERE Baixado = False and Empresa = " & CodEmpresa & " and Inativo = False Order by Vencimento"
            Case 1 'por data
                sql = "SELECT id,documento,notafiscal,fornecedor,datadocumento,vencimento,valordocumento,virtual,Destino,IdAgrupamento FROM Pagar WHERE Vencimento =#" & Format(CDate(Me.txtProcura.Text), "MM/dd/yyyy") & "# and Baixado = False and Empresa = " & CodEmpresa & " and Inativo = False Order by Vencimento"
            Case 2 'por nome
                If Me.txtProcura.Text = "" Then
                    MsgBox("Fornecedor não pode ser nulo", 48, "ATENÇÃO")
                    Exit Sub
                End If
                sql = "SELECT id,documento,notafiscal,fornecedor,datadocumento,vencimento,valordocumento,virtual,Destino,IdAgrupamento FROM Pagar WHERE Fornecedor Like '%" & Me.txtProcura.Text & "%' and Baixado = False and Empresa = " & CodEmpresa & " and Inativo = False Order by Vencimento"
            Case 3 'por nf
                sql = "SELECT id,documento,notafiscal,fornecedor,datadocumento,vencimento,valordocumento,virtual,Destino,IdAgrupamento FROM Pagar WHERE notafiscal Like '%" & Me.txtProcura.Text & "%' and Baixado = False and Empresa = " & CodEmpresa & " and Inativo = False Order by Vencimento"

        End Select


        Dim oDa = New OleDb.OleDbDataAdapter(sql, Cnn)
        DsProcura = New DataSet
        oDa.Fill(DsProcura, "Pagar")

        dgvItem.DataSource = DsProcura.Tables("Pagar")

        Try
            For Each Linha As DataGridViewRow In Me.dgvItem.Rows
                If Linha.Cells("g_vencimento").Value < CDate(DataDia) Then
                    Linha.DefaultCellStyle.BackColor = Color.Red
                End If
            Next

            Cnn.Close()
            ObtemSomaColunas()
            dgvItem.ClearSelection()

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            Exit Sub
        End Try

    End Sub
    'ROTINA PARA OBTER A SOMA DE UMA DETERMINADA COLUNA
    Sub ObtemSomaColunas()
        Dim SomaColuna As Double
        Try

            'Se o valor for nulo...
            If DsProcura.Tables(0).Compute("SUM(valordocumento)", "") Is DBNull.Value Then

                SomaColuna = "0"

            Else

                'Utilizo o compute para somar os valores da coluna...

                SomaColuna = DsProcura.Tables(0).Compute("SUM(valordocumento)", "")

            End If
            Total.Text = String.Format("{0:R$ #,##0.00}", SomaColuna)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub btFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EncheLista()
    End Sub

    Private Sub btFindFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.PagarProcuraFor.ShowDialog()
        EncheLista()
    End Sub

    Private Sub Pagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvItem_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItem.CellDoubleClick

        Dim cxFechado As New CaixaFechado
        cxFechado.CaixaEstaFechado()

        If Len(CaixaAtivo) <> 4 Then
            MessageBox.Show("O usuario deve selecionar um caixa antes de baixar um documento. Verifique", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If MsgBox("Deseja Ativar o caixa agora", 36, "Validação de Dados") = 6 Then
                TRVDados(UserAtivo, "CaixaAtivarDesativar")
                If Ina = True Then
                    MsgBox("O usuário não esta autorizado a usar esta opção do sistema.", 64, "Validação de Dados")
                    Exit Sub
                Else
                    My.Forms.CaixaAtivarDesativar.ShowDialog()
                    dgvItem_CellDoubleClick(sender, e)
                End If
            End If
            Exit Sub
        End If

        Dim I As Integer = 0


        If strVirtual = True Then
            MessageBox.Show("Esta conta esta como Virtual não pode ser Baixada", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            My.Forms.PagarBaixa.AchaRegistro(Me.IdSelecionado.Text)
            My.Forms.PagarBaixa.ShowDialog()
            EncheLista()
        End If


    End Sub


    Private Sub EditaContaSelecionadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditaContaSelecionadaToolStripMenuItem.Click

        TRVDados(UserAtivo, "PagarEditar")
        If Ina = True Then
            MsgBox("O usuário não esta autorizado a usar esta opção do sistema.", 64, "Validação de Dados")
            Exit Sub
        Else

            If Me.IdSelecionado.Text = "" Then Exit Sub
            My.Forms.PagarEditar.ShowDialog()
            EncheLista()
        End If
    End Sub

    Private Sub dgvItem_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItem.CellClick
        Me.IdSelecionado.Text = dgvItem.CurrentRow.Cells("g_id").Value
        strVirtual = dgvItem.CurrentRow.Cells("g_virtual").Value
    End Sub

    Private Sub dgvItem_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvItem.SelectionChanged

        'Try
        '    'Todas a vez que for retornar um valor da celula no datagriview deverá ser feita a devida conversão.
        '    Me.xCliente.Text = Me.Lista.CurrentRow.Cells("cCodigo").Value & "-" & Me.Lista.CurrentRow.Cells("cNome").Value
        '    Me.xEndereço.Text = Me.Lista.CurrentRow.Cells("cEndereco").Value
        '    Me.xCpfCnpj.Text = Me.Lista.CurrentRow.Cells("cCpfCnpj").Value
        '    Me.xCidade.Text = Me.Lista.CurrentRow.Cells("cCidade").Value
        '    Me.xVendaVista.Checked = Me.Lista.CurrentRow.Cells("cVendaVista").Value
        '    Me.xVendaCheque.Checked = Me.Lista.CurrentRow.Cells("cVendaCheque").Value
        '    Me.xVendaCrediario.Checked = Me.Lista.CurrentRow.Cells("cVendaCrediario").Value
        '    Me.xTelefone.Text = Convert.ToString(Me.Lista.CurrentRow.Cells("gTelefone").Value)
        '    Me.xCelular.Text = Convert.ToString(Me.Lista.CurrentRow.Cells("gCelular").Value)
        '    Me.xContato.Text = Convert.ToString(Me.Lista.CurrentRow.Cells("gContato").Value)
        '    'Me.xMotivoBloqueado.Text = Me.Lista.CurrentRow.Cells("cMotivoBloqueado").Value & ""
        '    Me.xBloqueado.Checked = Me.Lista.CurrentRow.Cells("cBloqueado").Value

        '    If Me.xBloqueado.Checked = True Then
        '        Me.xMotivoBloqueado.Text = "Favor conduzir o Cliente para o setor de Crédito"
        '    Else
        '        Me.xMotivoBloqueado.Text = ""
        '    End If

        'Catch ex As Exception
        'End Try

    End Sub

    Private Sub VisualizarVinculoDePagamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarVinculoDePagamentoToolStripMenuItem.Click

        Dim cDoc As String = dgvItem.CurrentRow.Cells("g_documento").Value 'pega o valor do coluna documento
        Dim cId As Integer = dgvItem.CurrentRow.Cells("g_id").Value
        Dim cIdAG As Integer = NzZero(dgvItem.CurrentRow.Cells("cIdAgrupamento").Value)

        If cDoc.ToString.IndexOf("AG") <> -1 Then
            My.Forms.PagarAgrupar.Visualizador = True
            My.Forms.PagarAgrupar.IDVisualizador = cIdAG
            My.Forms.PagarAgrupar.ShowDialog()
        Else
            MessageBox.Show("O documento selecionado não contem agrupamento de contas", "Validação de dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cboFiltros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFiltros.SelectedIndexChanged
        Me.txtProcura.Clear()
        Select Case cboFiltros.SelectedIndex
            Case 0 'todos
                Me.txtProcura.ReadOnly = True

            Case 1 'por data
                Me.txtProcura.ReadOnly = False

                Me.txtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
                Me.txtProcura.Focus()
            Case 2 'por nome
                Me.txtProcura.ReadOnly = False
                Me.txtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
                Me.txtProcura.Focus()
            Case 3 'nf
                Me.txtProcura.ReadOnly = False
                Me.txtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
                Me.txtProcura.Focus()
        End Select


       
    End Sub

    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        If cboFiltros.SelectedIndex = -1 Then
            MessageBox.Show("Selecione um filtro", "Validação de dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboFiltros.Focus()
            Exit Sub
        End If

        EncheLista()
    End Sub
End Class