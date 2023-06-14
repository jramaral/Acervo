Imports System.Data.OleDb
Imports ClassView
Public Class AcompanharPedido

    Private TipoFilter As Byte
    Const PED As Byte = 0
    Const TODOS As Byte = 1

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
    Private Sub AcompanharPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = db.AbreBanco
        CreateCol()
    End Sub
    'Metodo para cria as colunas em tempo de execução.
    Sub CreateCol()

        Dim sql = "SELECT * FROM TipoAndamento"
        Dim cmd As New OleDbCommand(sql, conn)
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader

        'Aqui definimos as nossa datagridview.
        Dim col As DataGridViewTextBoxColumn 'Importa a coluna textbox
        Dim colCB As DataGridViewComboBoxColumn 'importa a coluna combobox
        Dim colbtn As DataGridViewButtonColumn

        'Definir alguma propriedades da coluna TextBox
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "Pedido"
        col.Name = "gpedido"
        col.Width = 70
        col.Visible = True
        Me.Dgv.Columns.Add(col)

        'Data Pedido
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "Data Pedido"
        col.Name = "gdatapedido"
        col.Width = 110
        ' col.ReadOnly = True
        Me.Dgv.Columns.Add(col)

        'nome do cliente
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "Cliente"
        col.Name = "gcliente"
        col.Width = 300
        Me.Dgv.Columns.Add(col)

        'Tipo de andamento do pedido
        colCB = New DataGridViewComboBoxColumn()
        colCB.HeaderText = "Andamento"
        colCB.Name = "gandamento"
        colCB.Width = 150
        While dr.Read
            colCB.Items.Add(dr.Item("DescricaoAndamento"))
        End While
        Me.Dgv.Columns.Add(colCB)

        colbtn = New DataGridViewButtonColumn
        Me.Dgv.Columns.Add(colbtn)
        colbtn.HeaderText = "Hitórico"
        colbtn.Text = "Clique Aqui!"
        colbtn.Name = "gbutton"
        colbtn.UseColumnTextForButtonValue = True
        colbtn.FlatStyle = FlatStyle.Popup
        colbtn.DefaultCellStyle.ForeColor = Color.Green

    End Sub

    Private Sub CarregarGrid()

        Dim sql As String = String.Empty

        Select Case TipoFilter
            Case PED
                sql = "SELECT Pedido.PedidoSequencia, Pedido.DataPedido, Clientes.Nome, Pedido.AndamentoDoPedido FROM Pedido INNER JOIN Clientes ON Pedido.CódigoCliente = Clientes.Codigo WHERE Pedido.PedidoSequencia=" & Me.pedido.Text
            Case TODOS
                sql = "SELECT Pedido.PedidoSequencia, Pedido.DataPedido, Clientes.Nome, Pedido.AndamentoDoPedido FROM Pedido INNER JOIN Clientes ON Pedido.CódigoCliente = Clientes.Codigo WHERE(((pedido.AndamentoDoPedido) Is Not Null)) ORDER BY Pedido.PedidoSequencia"
        End Select

        Dim CMD As New OleDb.OleDbCommand(sql, conn)

        Dim odr As OleDb.OleDbDataReader
        odr = CMD.ExecuteReader
        Dim tpAndamento As String
        Dim row As New DataGridViewRow
        Me.Dgv.Rows.Clear()
        If odr.HasRows Then
            While odr.Read()

                tpAndamento = odr.Item("AndamentoDoPedido").ToString
                'preenche o grid com alguns dados
                Dim row0 As String() = {odr.Item("PedidoSequencia"), odr.Item("DataPedido"), odr.Item("Nome"), tpAndamento}
                'adiciona as linhas
                With Me.Dgv.Rows
                    .Add(row0)
                End With
            End While
        Else
            MessageBox.Show("Pedido não foi encontrado." _
            & Microsoft.VisualBasic.ControlChars.CrLf & "Certifique-se de ter  digitado o número corretamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dgv.Rows.Clear()
            Me.pedido.Clear()
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        TipoFilter = TODOS

        CarregarGrid()
    End Sub

    Private Sub pedido_Leave(sender As Object, e As EventArgs) Handles pedido.Leave
        If Not String.IsNullOrEmpty(pedido.Text) Then
            TipoFilter = PED
            CarregarGrid()
        End If
    End Sub

    Private Sub pedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pedido.KeyPress
        'Só entra com numeros 0 a 9
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(OnlyNumber(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        db.fechabanco(conn)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Dgv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellEnter
        If Me.Dgv.CurrentCell.ColumnIndex = 3 Or Me.Dgv.CurrentCell.ColumnIndex = 4 Then
            Me.Dgv.BeginEdit(True)
        End If
    End Sub

    Private Sub salvar_Click(sender As Object, e As EventArgs) Handles salvar.Click
        Dim transaction As OleDbTransaction
        transaction = conn.BeginTransaction()

        If Dgv.RowCount > 0 Then
            Try

                Dim linha As Integer
                Dim tpAcompanhamento As Object

                Dim sql As String
                Dim cmd As OleDb.OleDbCommand

                For rowIndex As Integer = 0 To Dgv.Rows.Count - 1 Step 1
                    linha = Dgv.Item(0, rowIndex).Value         'pegar o id da linha do DataGrid
                    tpAcompanhamento = Nz(Dgv.Item(3, rowIndex).Value, 1)  'pegar a conta conrrente

                    sql = "Update Pedido Set  AndamentoDoPedido=@1 where PedidoSequencia=" & linha
                    cmd = New OleDb.OleDbCommand(sql, conn, transaction)
                    cmd.Parameters.AddWithValue("@1", Nz(tpAcompanhamento, 1))
                    cmd.ExecuteNonQuery()
                Next rowIndex
                transaction.Commit()
                MessageBox.Show("Andamentos Atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
                transaction.Rollback()
            Finally

            End Try
        Else

            Return
        End If
    End Sub

    Private Sub Dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellClick
        If (e.ColumnIndex = 4) Then

            Try
                RelatorioCarregar = "AcompanhamentoPedido.rpt"
                Dim strFormula As String = "{Pedido.PedidoSequencia} =" & Me.Dgv.CurrentRow.Cells("gpedido").Value
                'chama a classe e passa os parametros para o relatorio
                Dim f As New cView

                'adiciona valores para as formulas no contrato

                f.AddFormula("NomeEmpresa", NomEmpresa)

                'executa o relatorio
                f.frm(DirRelat & RelatorioCarregar, LocalBD & Nome_BD, SenhaBancoDados, "Movimentação do Pedido", strFormula, False)

            Catch ex As Exception

            End Try

        End If

    End Sub
End Class