Public Class SellShoesGerarNFe

    
    Private Sub Fechar_Click(sender As Object, e As EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub SellShoesGerarNFe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub AcharPedido()

        If Me.Pedido.Text = "" Then Exit Sub

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()


        Dim Sql As String = "SELECT Pedido.PedidoInterno, Pedido.PedidoSequencia, Pedido.PedidoTipo, Pedido.TipoEntrega, Pedido.Requisicao, Pedido.LimiteCredito, Pedido.CódigoFuncionário, Pedido.CódigoCliente, Pedido.Propriedade, Pedido.DataPedido, Pedido.PercDesconto, Pedido.VlrDescProduto, Pedido.ValorProduto, Pedido.TotalPedido, Pedido.TotalPropostoPedido, Pedido.ValorAVista, Pedido.ValorOutros, Pedido.ValorAFaturar, Pedido.DataFechamento, Pedido.NatOperação, Pedido.Empresa, Pedido.Inativo, Pedido.Confirmado, Pedido.ObsCab, Pedido.ObsRod, Pedido.FormaPgto, FormaPgto.Descrição, Pedido.DiasParcelamento, Pedido.ImpressoPedido, Pedido.ValorIpiPedido, Pedido.InfBloqueio, Pedido.StatusAndamentos, Pedido.CodObjeto, Pedido.kmObjeto, Pedido.ObsObjeto,Pedido.issqn, Pedido.ReterImposto, Pedido.NfePecas, Pedido.NfeServico,Pedido.NFe,Pedido.ChaveNFe,Pedido.cStat,Pedido.xMotivo,Funcionários.Nome, Propriedades.NomePropriedade, Propriedades.Estado, Propriedades.Inscricao, CFOP.Descrição, Clientes.CpfCgc, Clientes.Insc, Clientes.UsarLimite, Clientes.Nome, Clientes.Endereço, Clientes.Nro, Clientes.Cidade, Clientes.Cep, Clientes.Estado,Clientes.UsaSubstitucaoTributaria, clientes.TpComercio FROM ((((Pedido LEFT JOIN Funcionários ON Pedido.CódigoFuncionário = Funcionários.CódigoFuncionário) LEFT JOIN Propriedades ON Pedido.Propriedade = Propriedades.Id) LEFT JOIN CFOP ON Pedido.NatOperação = CFOP.CFOP) LEFT JOIN Clientes ON Pedido.CódigoCliente = Clientes.Codigo) LEFT JOIN FormaPgto ON Pedido.FormaPgto = FormaPgto.CodFormaPgto WHERE (((Pedido.PedidoSequencia)=" & Me.Pedido.Text & "));"

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows = True Then
            Me.Pedido.Text = DR.Item("PedidoSequencia") & ""


            Me.Cliente.Text = DR.Item("CódigoCliente") & ""
            Me.Cnpj.Text = DR.Item("CpfCgc") & ""
            Me.ClienteDesc.Text = DR.Item("Clientes.Nome") & ""
            Me.TotalPedido.Text = FormatCurrency(Nz(DR.Item("TotalPedido"), 3), 2)
            Me.DataPedido.Text = DR.Item("DataPedido") & ""
            Me.Confirmado.Checked = DR.Item("Confirmado")
            Me.Inativo.Checked = DR.Item("Inativo")
            Me.TpVenda.Text = DR.Item("PedidoTipo") & ""



            If Not String.IsNullOrEmpty(DR.Item("ChaveNFe") & "") Then
                Me.ChaveNFe.Text = "NFe: " & DR.Item("NFe") & " - " & DR.Item("ChaveNFe")
                Me.cState.Text = "Status: " & DR.Item("cStat") & " - " & DR.Item("xMotivo")
            Else
                Me.ChaveNFe.Text = ""
                Me.cState.Text = ""
            End If

            If Me.Confirmado.Checked = False Then
                Me.ConfImg.Visible = False
                Me.ConfImg.Text = "Pedido Confirmado"
                Me.ConfImg.ForeColor = Color.Green
            Else
                Me.ConfImg.Visible = True
                Me.ConfImg.ForeColor = Color.Green
                Me.ConfImg.Text = "Pedido Confirmado"
            End If

            If Me.Inativo.Checked = True Then
                Me.ConfImg.Visible = True
                Me.ConfImg.Text = "Pedido Cancelado"
                Me.ConfImg.ForeColor = Color.Red
            End If



        End If
        DR.Close()
        CNN.Close()

        'Dim TemItens As Boolean = VerificarItens()

        'If TemItens = False Then
        '    MessageBox.Show("Este pedido esta sem item não pode emitir NFe", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Cliente.Clear()
        '    Me.Cnpj.Clear()
        '    Me.ClienteDesc.Clear()
        '    Me.TotalPedido.Clear()
        '    Me.DataPedido.Clear()
        '    Me.Confirmado.Checked = False
        '    Me.Inativo.Checked = False
        '    Me.TpVenda.Clear()
        '    Me.ChaveNFe.Clear()
        '    Me.cState.Text = ""
        '    Me.Pedido.Clear()
        '    Me.Pedido.Focus()
        'End If

    End Sub

    Private Function VerificarItens() As Boolean
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()


        Dim Sql As String = "SELECT * from ItensPedido Where ItensPedido.PedidoSequencia = " & Me.Pedido.Text

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If Not DR.HasRows = True Then
            Return False
        End If
        DR.Close()
        CNN.Close()

    End Function





    Private Sub Pedido_KeyDown(sender As Object, e As KeyEventArgs) Handles Pedido.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            AcharPedido()
        End If
    End Sub

    Private Sub btGerarNFe_Click(sender As Object, e As EventArgs) Handles btGerarNFe.Click
        
            'Antes de Gerar a NFe devemos validar os Dados e posteriormente Salvar ou Editar os Dados

        If Me.Pedido.Text = "" Then
            MessageBox.Show("Favor selecionar um Pedido para emitir a NFe.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

            If Me.Confirmado.Checked = False Then
                MessageBox.Show("Favor selecionar um Pedido confirmado para emitir a NFe.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        Dim jaGerouNFe() As String


        jaGerouNFe = Split(Me.ChaveNFe.Text, "-")
        If jaGerouNFe.Length > 1 Then
            If Trim(jaGerouNFe(1)) <> "" Then
                MessageBox.Show("Este Pedido ja tem uma NFe com a Chave: " & jaGerouNFe(1) & ", não pode gerar mais NFe neste pedido.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If Me.TpVenda.Text = "VENDA" Or Me.TpVenda.Text = "VENDA INTERNA" Then
            My.Forms.NFeValidarDados.CodigoCliente = Me.Cliente.Text
            My.Forms.NFeValidarDados.NumeroPedido = Me.Pedido.Text
            My.Forms.NFeValidarDados.ShowDialog()
        Else
            MessageBox.Show("Este tipo de Venda não pode Emitir NFe.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub
End Class