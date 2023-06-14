Imports Grid.DBL.DataGridViewCustomColumn
Imports System.Data.OleDb
Public Class BoletoIndicarConta

    Dim conn As New OleDbConnection()
    Dim i As Integer = 0
    Dim vpar As Double = 0
    Dim cp As Integer = 0 'total de parcelas
    Dim idLinha As Integer
    Dim db As New clsBancoDados
    Dim cVlr As Double = 0
    Dim bs As BindingSource
    Dim Da As OleDb.OleDbDataAdapter
    Dim ds As DataSet

    'Uso o metodo para reescrever o evento keypress
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    'Metodo para cria as colunas em tempo de execução.
    Sub CreateCol()

        Dim sql = "SELECT ContaCorrente FROM Banco"
        Dim cmd As New OleDbCommand(sql, conn)
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader

        'Aqui definimos as nossa datagridview.
        Dim col As DataGridViewTextBoxColumn 'Importa a coluna textbox
        Dim ColM As MaskedTextBoxColumn  'importa a coluna maskedtext
        Dim colCB As DataGridViewComboBoxColumn 'importa a coluna combobox

        'Definir alguma propriedades da coluna TextBox
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "id"
        col.Name = "id"
        col.Width = 70
        col.Visible = False
        Me.Dgv.Columns.Add(col)

        'Documento
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "Documento"
        col.Name = "documento"
        col.Width = 110
        ' col.ReadOnly = True
        Me.Dgv.Columns.Add(col)

        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "NF"
        col.Name = "notafiscal"
        col.Width = 90
        Me.Dgv.Columns.Add(col)

        'Vencimento
        ColM = New MaskedTextBoxColumn()
        ColM.HeaderText = "Vencimento"
        ColM.Name = "vencimento"
        ColM.Mask = "00/00/0000"
        ColM.Width = 75
        ColM.ReadOnly = False
        Me.Dgv.Columns.Add(ColM)      '

        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "Valor"
        col.Name = "valor"
        col.Width = 90
        col.DefaultCellStyle.Format = FormatCurrency(0, 2)
        Me.Dgv.Columns.Add(col)

        'local de pagamento
        colCB = New DataGridViewComboBoxColumn()
        colCB.HeaderText = "Local Pgto"
        colCB.Name = "gLocal"
        colCB.Width = 90
        colCB.Items.Add("CARTEIRA")
        colCB.Items.Add("BANCO")
        Me.Dgv.Columns.Add(colCB)

        'Conta corrente
        colCB = New DataGridViewComboBoxColumn()
        colCB.HeaderText = "Conta Corrente"
        colCB.Name = "gCC"
        colCB.Width = 90

        colCB.Items.Add("")
        While dr.Read
            colCB.Items.Add(dr.Item("ContaCorrente"))
        End While

        Me.Dgv.Columns.Add(colCB)

        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "Boleto"
        col.Name = "cBoleto"
        col.Width = 90
        Me.Dgv.Columns.Add(col)

    End Sub

    Private Sub BoletoIndicarConta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = db.AbreBanco
        CreateCol()

        Dim sql As String
        sql = "Select * from Receber Where Baixado=False And Agrupada=False And id =" & My.Forms.Receber.dgvItem.CurrentRow.Cells("g_id").Value & " Order By id"

        Dim CMD As New OleDb.OleDbCommand(sql, conn)

        Dim odr As OleDb.OleDbDataReader
        odr = CMD.ExecuteReader
        Dim nf As String
        Dim cc As String
        Dim row As New DataGridViewRow
        Dim cVlr As Double = 0
        Dim boleto As String = String.Empty
        Dim localpgto As String = String.Empty

        While odr.Read()
            nf = odr.Item("NotaFiscal").ToString
            cc = odr.Item("ContaCorrente").ToString
            boleto = odr.Item("NumeroBoleto").ToString
            localpgto = odr.Item("LocalPgto").ToString()

            If localpgto.Equals("CARTAO CREDITO") Or localpgto.Equals("CARTAO DEBITO") Then
                localpgto = "BANCO"
            End If

            'preenche o grid com alguns dados
            Dim row0 As String() = {odr.Item("Id"), odr.Item("Documento"), nf, odr.Item("Vencimento"), FormatCurrency(odr.Item("valorDocumento"), 2), localpgto, cc, boleto}
            'adiciona as linhas
            With Me.Dgv.Rows
                .Add(row0)
            End With
        End While

    End Sub
    Private Sub Dgv_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv.CellEnter
        If Me.Dgv.CurrentCell.ColumnIndex = 6 Or Me.Dgv.CurrentCell.ColumnIndex = 7 Then
            Me.Dgv.BeginEdit(True)
        End If
    End Sub
    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        db.fechabanco(conn)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub salvar_Click(sender As Object, e As EventArgs) Handles salvar.Click
        Dim transaction As OleDbTransaction
        transaction = conn.BeginTransaction()

        If Dgv.RowCount > 0 Then
            Try

                Dim linha As Integer
                Dim v_NF As String = String.Empty
                Dim v_Local As String = String.Empty
                Dim v_cc As Object
                Dim v_Boleto As String = String.Empty

                Dim sql As String
                Dim cmd As OleDb.OleDbCommand

                For rowIndex As Integer = 0 To Dgv.Rows.Count - 1 Step 1
                    linha = Dgv.Item(0, rowIndex).Value         'pegar o id da linha do DataGrid
                    v_NF = Dgv.Item(2, rowIndex).Value          'pegar o numero  da nf
                    v_Local = Dgv.Item(5, rowIndex).Value       'pegar o local do pagamento carteiro ou banco
                    v_cc = Nz(Dgv.Item(6, rowIndex).Value, 2)   'pegar a conta conrrente
                    v_Boleto = Dgv.Item(7, rowIndex).Value      'Pega o boleto




                    sql = "Update Receber Set  NotaFiscal=@1,LocalPgto=@2,ContaCorrente=@3, numeroBoleto= @4 where id=" & linha
                    cmd = New OleDb.OleDbCommand(sql, conn, transaction)
                    cmd.Parameters.AddWithValue("@1", Nz(v_NF, 1))
                    cmd.Parameters.AddWithValue("@2", Nz(v_Local, 1))
                    cmd.Parameters.AddWithValue("@3", Nz(v_cc, 1))
                    cmd.Parameters.AddWithValue("@4", Nz(v_Boleto, 1))
                    cmd.ExecuteNonQuery()
                Next rowIndex
                transaction.Commit()
                MessageBox.Show("Parcelas Atualizadas com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
                transaction.Rollback()
            Finally
                conn.Close()
            End Try
        Else
            MsgBox("ATENÇÃO!! O usuário prescisa gerar o paracelamento para prosseguir", 48, "Validação de dados")
            Return
        End If

    End Sub

    Private Sub Dgv_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles Dgv.CellParsing
        If Dgv.CurrentCell.IsInEditMode Then
            Me.Dgv.BeginEdit(True)
        End If
    End Sub
    Private Sub Dgv_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellValidated
        If e.ColumnIndex.Equals(7) Then
            Dim v = Dgv.CurrentCell.Value
            If Len(v) > 20 Then
                MsgBox("ATENÇÃO!! Quantidade de caracteres maiores que o permitido", 48, "Validação de dados")
                Dgv.CurrentCell.Value = ""

            End If
        End If
    End Sub

End Class