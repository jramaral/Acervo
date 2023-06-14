Imports System.Data.OleDb
Imports System.Math
Public Class EditarParcelasAvulso
    Dim i As Integer = 0
    Dim vpar As Double = 0
    Dim CNN As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\TreinamentoGridView\database.mdb")
    Dim cp As Integer = 0
    Dim bs As New BindingSource
    Dim vValorAnterior As Double = 0
    Dim db As New clsBancoDados
    Public filter As String
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Class CalendarColumn
        Inherits DataGridViewColumn

        Public Sub New()
            MyBase.New(New CalendarCell())
        End Sub

        Public Overrides Property CellTemplate() As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(ByVal value As DataGridViewCell)

                ' Ensure that the cell used for the template is a CalendarCell.
                If Not (value Is Nothing) AndAlso Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) Then
                    Throw New InvalidCastException("Must be a CalendarCell")
                End If
                MyBase.CellTemplate = value

            End Set
        End Property

    End Class
    Public Class CalendarCell
        Inherits DataGridViewTextBoxCell

        Public Sub New()
            ' Use the short date format.
            Me.Style.Format = "d"
        End Sub

        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
            ByVal initialFormattedValue As Object, _
            ByVal dataGridViewCellStyle As DataGridViewCellStyle)

            ' Set the value of the editing control to the current cell value.
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
                dataGridViewCellStyle)

            Dim ctl As CalendarEditingControl = _
                CType(DataGridView.EditingControl, CalendarEditingControl)
            ctl.Value = CType(Me.Value, DateTime)

        End Sub

        Public Overrides ReadOnly Property EditType() As Type
            Get
                ' Return the type of the editing contol that CalendarCell uses.
                Return GetType(CalendarEditingControl)
            End Get
        End Property

        Public Overrides ReadOnly Property ValueType() As Type
            Get
                ' Return the type of the value that CalendarCell contains.
                Return GetType(DateTime)
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultNewRowValue() As Object
            Get
                ' Use the current date and time as the default value.
                Return DateTime.Now
            End Get
        End Property

    End Class
    Class CalendarEditingControl
        Inherits DateTimePicker
        Implements IDataGridViewEditingControl

        Private dataGridViewControl As DataGridView
        Private valueIsChanged As Boolean = False
        Private rowIndexNum As Integer

        Public Sub New()
            Me.Format = DateTimePickerFormat.Short
        End Sub

        Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue

            Get
                Return Me.Value.ToShortDateString()
            End Get

            Set(ByVal value As Object)
                If TypeOf value Is [String] Then
                    Me.Value = DateTime.Parse(CStr(value))
                End If
            End Set

        End Property

        Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

            Return Me.Value.ToShortDateString()

        End Function

        Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

            Me.Font = dataGridViewCellStyle.Font
            Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
            Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

        End Sub

        Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex

            Get
                Return rowIndexNum
            End Get
            Set(ByVal value As Integer)
                rowIndexNum = value
            End Set

        End Property

        Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey

            ' Let the DateTimePicker handle the keys listed.
            Select Case key And Keys.KeyCode
                Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                    Return True

                Case Else
                    Return False
            End Select

        End Function

        Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

            ' No preparation needs to be done.

        End Sub
        Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
            Get
                Return False
            End Get
        End Property
        Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
            Get
                Return dataGridViewControl
            End Get
            Set(ByVal value As DataGridView)
                dataGridViewControl = value
            End Set
        End Property
        Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
            Get
                Return valueIsChanged
            End Get
            Set(ByVal value As Boolean)
                valueIsChanged = value
            End Set
        End Property
        Public ReadOnly Property EditingControlCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
            Get
                Return MyBase.Cursor
            End Get
        End Property
        Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

            ' Notify the DataGridView that the contents of the cell have changed.
            valueIsChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
            MyBase.OnValueChanged(eventargs)

        End Sub

    End Class
    Private Sub AceitaSomenteValores_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)

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
    Private Sub FaturaEditarParcelamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As OleDbConnection
        conn = db.AbreBanco

        Dim Sql As String = "SELECT ID,Documento,ValorDocumento,vencimento  FROM RECEBER WHERE Documento " & filter

        Dim ocmd As New OleDb.OleDbCommand(Sql, conn)

        Dim odr As OleDb.OleDbDataReader
        odr = ocmd.ExecuteReader

        Dim col As New CalendarColumn()
        Dgv.Columns.Add("ID", "Codigo")
        Dgv.Columns.Add("P", "PP")
        Dgv.Columns.Add("Doc", "Documento")
        Dgv.Columns.Add("Vlr", "Valor")
        Dgv.Columns.Add(col)
        Dgv.Columns(0).Visible = False
        Dgv.Columns(1).Visible = False
        Dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Dim row As New DataGridViewRow
        Dim cVlr As Double = 0
        While odr.Read()
            'preenche o grid com alguns dados
            i += 1
            Dim row0 As String() = {odr.Item("id"), i, odr.Item("documento"), FormatCurrency(odr.Item("valordocumento"), 2), odr.Item("Vencimento")}
            'adiciona as linhas

            With Me.Dgv.Rows

                .Add(row0)

            End With

            cVlr += odr.Item("Valordocumento")
            Me.txtTotal.Text = FormatCurrency(Round(cVlr), 2)
        End While
    End Sub

    Private Sub Dgv_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv.CellEnter
        Try
            cp = Dgv.CurrentRow.Cells(1).Value
            Dim x As Short = i - cp
            Try
                If x = 0 Then
                    Dgv.CurrentRow.Cells("vlr").ReadOnly = True
                Else
                    Dgv.CurrentRow.Cells("vlr").ReadOnly = False
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgv_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Dgv.EditingControlShowing
        RemoveHandler e.Control.KeyPress, AddressOf AceitaSomenteValores_KeyPress 'AceitaSomenteValores

        RemoveHandler e.Control.KeyPress, AddressOf AceitaSomenteNumeros_KeyPress

        'If CInt((DirectCast((sender), System.Windows.Forms.DataGridView).CurrentCell.ColumnIndex)) = 2 Then

        '    AddHandler e.Control.KeyPress, AddressOf AceitaSomenteValores_KeyPress
        If CInt((DirectCast((sender), System.Windows.Forms.DataGridView).CurrentCell.ColumnIndex)) = 4 Then

            AddHandler e.Control.KeyPress, AddressOf AceitaSomenteNumeros_KeyPress
        ElseIf CInt((DirectCast((sender), System.Windows.Forms.DataGridView).CurrentCell.ColumnIndex)) = 3 Then

            AddHandler e.Control.KeyPress, AddressOf AceitaSomenteNumeros_KeyPress
        End If
    End Sub

    Private Sub Dgv_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv.CellEndEdit
        Dim cv As Double = 0
        Try
            If Dgv.Columns(e.ColumnIndex).Index = 4 Or Dgv.Columns(e.ColumnIndex).Index = 1 Then
                Me.txtResto.Text = Me.txtTotal.Text - Dgv.CurrentRow.Cells(3).Value
                Exit Sub
            Else
                Me.Dgv(3, e.RowIndex).Value = String.Format("{0:c}", Convert.ToDouble(Me.Dgv(3, e.RowIndex).Value))
                Dim sobra As Double = 0
                vpar = Dgv.CurrentRow.Cells(3).Value
                cp = Dgv.CurrentRow.Cells(1).Value

                For rowIndex As Integer = 0 To cp - 1 Step 1
                    sobra += Dgv.Item(3, rowIndex).Value
                Next

                Me.txtResto.Text = Me.txtTotal.Text - sobra
                Dim sP As Integer = i - cp
                cv = FormatNumber((Me.txtResto.Text / sP), 3)

                For rowIndex As Integer = 0 To Dgv.Rows.Count - 1 Step 1
                    'For columnIndex As Integer = 0 To DGPagar.Columns.Count '- 1 Step 1
                    If rowIndex >= cp Then
                        'Write a comma if an only if this is NOT the first column. 
                        'If columnIndex = 3 OrElse columnIndex = 4 Then
                        'Write a space in the fourth and fifth columns.  
                        Dgv.Item(3, rowIndex).Value = FormatCurrency(cv, 2)
                        'End If
                    End If
                    'Write the cell value.    
                    'Next columnIndex
                Next rowIndex
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgv_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles Dgv.CellValidating
        'Valida o entrada não permitindo valores em branco
        Dim x As Integer
        Dim x1 As Integer

        If Dgv.Columns(e.ColumnIndex).Name = "Vlr" Then


            Me.txtResto.Text = Dgv.CurrentRow.Cells(3).Value
            Me.vValorAnterior = e.FormattedValue.ToString()
            x1 = cp - 1

            If i = Dgv.CurrentRow.Cells("P").Value Then
                Dgv.Item(3, e.RowIndex).ReadOnly = True
            End If
            For rowIndex As Integer = 0 To cp - 1 Step 1
                If rowIndex = x1 Then
                    x += vValorAnterior
                Else
                    x += Dgv.Item(3, rowIndex).Value
                End If
            Next

            Dim sobra As Double
            sobra = Me.txtTotal.Text - x

            If sobra <= 0 Then
                'e.Cancel = True
            End If
        End If
    End Sub

    Private Sub fechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salvar.Click
        Dim linha As Integer
        Dim v_Doc As String
        Dim v_Valor As Double
        Dim v_Data As String

        Dim conn As OleDbConnection
        conn = db.AbreBanco
        Dim sql As String
        Dim cmd As OleDbCommand


        Try
            For rowIndex As Integer = 0 To Dgv.Rows.Count - 1 Step 1

                linha = Dgv.Item(0, rowIndex).Value
                v_Doc = Dgv.Item(2, rowIndex).Value
                v_Valor = Dgv.Item(3, rowIndex).Value
                v_Data = Dgv.Item(4, rowIndex).Value

                sql = "Update Receber Set Documento='" & v_Doc & "', ValorDocumento='" & v_Valor & "', Vencimento='" & v_Data & "' where id=" & linha
                cmd = New OleDbCommand(sql, conn)
                cmd.ExecuteNonQuery()

            Next rowIndex
            MsgBox("Parcelas Atualizadas com sucesso", 48, "Atenção")
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.fechabanco(conn)
        End Try
    End Sub
End Class