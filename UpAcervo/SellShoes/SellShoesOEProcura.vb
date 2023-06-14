Public Class SellShoesOEProcura

    Dim DsItens As DataSet

    Public Q_Devolver As Double = 0


    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub EncheListaPedido(ByVal Opc As Integer)

        If Opc = 0 Then Exit Sub

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = String.Empty

        If Opc = 1 Then 'Por Pedido
            Sql = "SELECT Pedido.PedidoSequencia, Pedido.CódigoCliente, Clientes.Nome, Pedido.DataPedido, Pedido.TotalPedido, Pedido.PedidoTipo, Funcionários.Nome as Vendedor, Pedido.StatusAndamentos FROM (Pedido INNER JOIN Clientes ON Pedido.CódigoCliente = Clientes.Codigo) INNER JOIN Funcionários ON Pedido.CódigoFuncionário = Funcionários.CódigoFuncionário WHERE (((Pedido.PedidoSequencia)=" & Me.txtProcura.Text & ") AND ((Pedido.Empresa)=" & CodEmpresa & ") AND ((Pedido.Inativo)=False) AND ((Pedido.Confirmado)=True) AND ((Pedido.PedidoTipo)='VENDA'));"
        End If
        If Opc = 2 Then 'Por Cliente
            Sql = "SELECT Pedido.PedidoSequencia, Pedido.CódigoCliente,  Clientes.Nome, Pedido.DataPedido, Pedido.TotalPedido, Pedido.PedidoTipo, Funcionários.Nome as Vendedor, Pedido.StatusAndamentos FROM (Pedido INNER JOIN Clientes ON Pedido.CódigoCliente = Clientes.Codigo) INNER JOIN Funcionários ON Pedido.CódigoFuncionário = Funcionários.CódigoFuncionário WHERE (((Clientes.Nome) Like '%" & Me.txtProcura.Text & "%') AND ((Pedido.Empresa)=" & CodEmpresa & ") AND ((Pedido.Inativo)=False) AND ((Pedido.Confirmado)=True) AND ((Pedido.PedidoTipo)='VENDA'));"
        End If
        If Opc = 3 Then 'Por Periodo
            Sql = "SELECT Pedido.PedidoSequencia,  Pedido.CódigoCliente, Clientes.Nome, Pedido.DataPedido, Pedido.TotalPedido, Pedido.PedidoTipo, Funcionários.Nome as Vendedor, Pedido.StatusAndamentos FROM (Pedido INNER JOIN Clientes ON Pedido.CódigoCliente = Clientes.Codigo) INNER JOIN Funcionários ON Pedido.CódigoFuncionário = Funcionários.CódigoFuncionário WHERE (((Pedido.DataPedido) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#) AND ((Pedido.Empresa)=" & CodEmpresa & ") AND ((Pedido.Inativo)=False) AND ((Pedido.Confirmado)=True) AND ((Pedido.PedidoTipo)='VENDA'));"
        End If


        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim Da As New OleDb.OleDbDataAdapter(CMD)

        Dim ds As New DataSet
        Da.Fill(ds, "Pedidos")

        Me.ListaPedido.DataSource = ds.Tables("Pedidos").DefaultView
        Da.Dispose()

        CNN.Close()

    End Sub

    Private Sub A1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A1.CheckedChanged, A2.CheckedChanged, A3.CheckedChanged
        If Me.A1.Checked = True Then
            Me.PainelPeriodo.Visible = False
            Me.txtProcura.Visible = True
            Me.txtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
            Me.txtProcura.TextAlign = HorizontalAlignment.Left
            Me.txtProcura.CasasDecimais = 0
            Me.txtProcura.Clear()
            Me.txtProcura.Focus()
        End If
        If Me.A2.Checked = True Then
            Me.PainelPeriodo.Visible = False
            Me.txtProcura.Visible = True
            Me.txtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
            Me.txtProcura.TextAlign = HorizontalAlignment.Left
            Me.txtProcura.CasasDecimais = 0
            Me.txtProcura.Clear()
            Me.txtProcura.Focus()
        End If
        If Me.A3.Checked = True Then
            Me.PainelPeriodo.Visible = True
            Me.txtProcura.Visible = False
            Me.DataInicial.Clear()
            Me.DataFinal.Clear()
            Me.DataInicial.Focus()
        End If
    End Sub

    Private Sub ListaPedido_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListaPedido.SelectionChanged

        Try

            Dim Tbl As New DataView(DsItens.Tables("Itens").Copy)
            Tbl.RowFilter = "PedidoSequencia = " & Me.ListaPedido.CurrentRow.Cells("cPedidoSequencia").Value



            Dim FRiscada As New Font("Comic Sans MS", 8, FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point)
            Dim FLimpa As New Font("Comic Sans MS", 8, System.Drawing.GraphicsUnit.Point)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtProcura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcura.Leave
        If Me.txtProcura.Text = "" Then
            Exit Sub
        End If

        If Me.A1.Checked = True Then
            EncheListaPedido(1)
        End If
        If Me.A2.Checked = True Then
            EncheListaPedido(2)
        End If
    End Sub

    Private Sub DataFinal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataFinal.Leave
        If Me.DataInicial.Text = "" Then
            Exit Sub
        End If
        If Me.DataFinal.Text = "" Then
            Exit Sub
        End If

        If Me.A3.Checked = True Then
            EncheListaPedido(3)
        End If
    End Sub

    Private Sub ListaItens_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = 0 Then
            System.Windows.Forms.SendKeys.Send("{Tab}")
        End If
    End Sub




    Private Sub SellShoesOrdemEntregaProcura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ListaPedido_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaPedido.CellClick

        If (e.ColumnIndex = 0) Then

            Try
                My.Forms.SellShoesOEVerItens.PedidoVer = Me.ListaPedido.CurrentRow.Cells("cPedidoSequencia").Value
                My.Forms.SellShoesOEVerItens.ShowDialog()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub btEmitirOrdem_Click(sender As Object, e As EventArgs) Handles btEmitirOrdem.Click


        Dim Status As String = ListaPedido.CurrentRow.Cells("cStatusAndamentos").Value

        'Fazer a verificação do status
        If Status = "FINALIZADO" Then
            MessageBox.Show("Este pedido já foi finalizado a entrega, não pode gerar mais ordem.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim IdSelecionado = ListaPedido.CurrentRow.Cells("cPedidoSequencia").Value


        My.Forms.OrdemEntrega.Pedido.Text = IdSelecionado
        My.Forms.OrdemEntrega.ShowDialog()


    End Sub
End Class