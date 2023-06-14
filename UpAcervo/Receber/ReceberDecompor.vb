Imports Grid.DBL.DataGridViewCustomColumn
Imports System.Text
Imports System.Math
Imports System.Data.OleDb
Public Class ReceberDecompor
    Dim i As Integer = 0
    Dim vpar As Double = 0
    Dim cp As Integer = 0 'total de parcelas
    Dim CodFornecedor As Integer = 0 'Armazena o codigo do fornecedor
    Dim dResta As Double = 0 'Armazena o valor que resta.
    Dim idLinha As Integer
    Dim db As New clsBancoDados
    Dim cVlr As Double = 0
    Dim bs As BindingSource
    Dim Da As OleDb.OleDbDataAdapter
    Dim ds As DataSet
    Dim erroCell As Boolean = False
    'Uso o metodo para reescrever o evento keypress
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub AceitaSomenteNumeros_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim nonNumberEntered As Boolean
        nonNumberEntered = True
        If (e.KeyChar >= Convert.ToChar(48) AndAlso e.KeyChar <= Convert.ToChar(57)) OrElse e.KeyChar = Convert.ToChar(8) OrElse e.KeyChar = Convert.ToChar(44) Then
            nonNumberEntered = False
        End If
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control
            ' since it is non-numerical. 
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub Dgv_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Dgv.EditingControlShowing
        'As declarações AddHandler e RemoveHandler permitem que você iniciar
        'e parar o tratamento de eventos para um evento específico a qualquer 
        'momento durante a execução do programa.
        RemoveHandler e.Control.KeyPress, AddressOf AceitaSomenteNumeros_KeyPress

        If CInt((DirectCast((sender), System.Windows.Forms.DataGridView).CurrentCell.ColumnIndex)) = 1 Then
            AddHandler e.Control.KeyPress, AddressOf AceitaSomenteNumeros_KeyPress
        End If
    End Sub
    Private Sub Dgv_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv.CellEnter
        If Dgv.CurrentCell.ColumnIndex = 2 Then
            If e.RowIndex = Dgv.Rows.Count - 1 Then

                Dgv.CurrentCell.ReadOnly = True

            Else
                Dgv.BeginEdit(True)
            End If





        End If
    End Sub
    Private Sub Dgv_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv.CellEndEdit

        Dim erro As String = CDbl(Me.Dgv(1, e.RowIndex).Value) - CDbl(Me.Dgv(2, e.RowIndex).Value)

        If erro <= 0 Then
            Dgv(2, e.RowIndex).Value = Dgv(1, e.RowIndex).Value - Dgv(3, e.RowIndex).Value
            Exit Sub
        End If

        Dim vValue As String = CDbl(Me.Dgv(2, e.RowIndex).Value)


        ' Me.Dgv(1, e.RowIndex).Value = String.Format("{0:c}", Convert.ToDouble(vValue))
        'Dgv.CurrentCell. = String.Format("{0:c}", Convert.ToDouble(vValue))



        Dim par As Double = Dgv.Item(2, e.RowIndex).Value
        dResta = Dgv.Item(1, e.RowIndex).Value - par
        Dgv.Item(3, e.RowIndex).Value = dResta
        vValue = dResta / (txt_quantidade_parcela.Text - (e.RowIndex + 1))
        'Dgv.Item(1, e.RowIndex).Value = FormatNumber(par, 2)

        Dim j As Integer = e.RowIndex + 1
        While (j <= Dgv.Rows.Count - 1)
            Dgv.Item(1, j).Value = dResta
            Dgv.Item(2, j).Value = vValue
            Dgv.Item(3, j).Value = dResta - vValue
            dResta = dResta - vValue
            j = j + 1
        End While

        j = e.RowIndex + 1



    End Sub
    Private Sub btn_gerar_Click(sender As Object, e As EventArgs) Handles btn_gerar.Click
        Dim dt As New DataTable With {.TableName = "MyTable"}


        dt.Columns.Add("parcela", Type.GetType("System.String"))
        dt.Columns.Add("A", Type.GetType("System.Double"))
        dt.Columns.Add("valor", Type.GetType("System.Double"))
        dt.Columns.Add("B", Type.GetType("System.Double"))

        Dim valor_dividido As Double = Convert.ToDouble(txt_valor_documento.Text) / txt_quantidade_parcela.Text



        Dim i As Integer = 1
        Dim TEMP As Double = txt_valor_documento.Text
        While (i <= txt_quantidade_parcela.Text)
            dt.Rows.Add(New Object() {"DEC-" & i, TEMP, valor_dividido, (TEMP - valor_dividido)})
            'dt.Rows.Add(New Object() {"DEC-" & i, valor_dividido})
            TEMP = TEMP - valor_dividido
            i = i + 1
        End While

        Dgv.DataSource = dt



    End Sub

    Private Sub Dgv_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles Dgv.CellParsing
        If Dgv.CurrentCell.IsInEditMode Then
            Me.Dgv.BeginEdit(True)
        End If
    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ReceberDecompor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dResta = txt_valor_documento.Text
    End Sub

    Private Sub salvar_Click(sender As Object, e As EventArgs) Handles salvar.Click
        If String.IsNullOrEmpty(txt_quantidade_parcela.Text) Or txt_quantidade_parcela.Text <= 1 Or txt_quantidade_parcela.Text > 3 Then
            MessageBox.Show("Verifique os valores das parcelas", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        Dim transaction As OleDbTransaction
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()


        transaction = CNN.BeginTransaction()
        Try




            Dim cmd As OleDbCommand


            ' Loop over each element with For Each.
            For Each r As DataGridViewRow In Dgv.Rows
                'A primeira linha é atualizada
                If r.Index = 0 Then
                    cmd = New OleDbCommand("UPDATE RECEBER SET ValorDocumento='" & r.Cells(2).Value & "', Documento='" & txt_doc.Text & "-" & r.Cells(0).Value & "' WHERE ID=" & txt_id_linha.Text, CNN, transaction)
                    cmd.ExecuteNonQuery()
                Else
                    cmd = New OleDbCommand("INSERT INTO Receber ( OriginalParcial, PedidoProdutos, NotaFiscal, Documento, CodCliente, Cliente, DataDocumento, ValorDocumento, Vencimento, Empresa, LocalPgto, Banco ) SELECT Receber.OriginalParcial, Receber.PedidoProdutos, Receber.NotaFiscal,'" & txt_doc.Text & "-" & r.Cells(0).Value & "' AS Expr2, Receber.CodCliente, Receber.Cliente, Receber.DataDocumento, '" & r.Cells(2).Value & "' AS Expr1, Receber.Vencimento, Receber.Empresa, Receber.LocalPgto, Receber.Banco FROM Receber WHERE (((Receber.ID)=" & txt_id_linha.Text & "));", CNN, transaction)
                    cmd.ExecuteNonQuery()
                End If

                ' transaction.Commit()

                'As outras são inseridas


            Next

            transaction.Commit()
            MessageBox.Show("Operação não realiza", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Close()
            Dispose()

        Catch ex As Exception

            transaction.Rollback()
            MessageBox.Show("Houve um erro ao decompor o documento. Operação não realiza", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




    End Sub
End Class