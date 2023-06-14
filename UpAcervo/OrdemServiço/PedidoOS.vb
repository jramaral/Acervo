Imports System.Data.OleDb
Imports System.Drawing

Public Class PedidoOS

#Region "Tela de Procura"

    Private Sub PainelProcuraPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PainelProcuraPedido.Click
        If Me.Pedido.Checked = False And Me.Cliente.Checked = False Then
            Me.Cliente.Checked = True
            Me.TxtProcura.Focus()
        End If
       
        Me.PainelProcuraPedido.Expanded = True
        Me.TotalParcelamento.Clear()
        RetornoProcura = ""
    End Sub

    Private Sub PainelProcuraPedido_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles PainelProcuraPedido.ExpandedChanged
        If NzZero(C�digoCliente.Text) = 0 And NzZero(Me.PedidoSequencia.Text) > 0 Then
            If Me.PainelProcuraPedido.Expanded = True Then
                MessageBox.Show("O Cliente n�o pode ser nulo", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.PainelProcuraPedido.Expanded = False
                Exit Sub
            End If
        End If
        If Me.PainelProcuraPedido.Expanded = True Then
            If Me.Pedido.Checked = False And Me.Cliente.Checked = False Then
                Me.Cliente.Checked = True
                Me.TxtProcura.Focus()
            End If
            Me.PainelProcuraPedido.Expanded = True

            If Me.Confirmado.Checked = False Then
                Me.ConfImg.Visible = False
            Else
                Me.ConfImg.Visible = True
            End If
            Me.TotalParcelamento.Clear()
            RetornoProcura = ""
        End If
    End Sub

    Private Sub TxtProcura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProcura.Leave
        EncheGrid()
    End Sub

    Private Sub VoltarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoltarPedido.Click
        Me.PainelProcuraPedido.Expanded = False
    End Sub

#End Region
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2
    Const VAZ As Byte = 5

    Dim A��o As New TrfGerais()
    Dim Autorizado As Boolean
    Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
    Public ConversorPc As Double = 0
    Dim CrtlEstIten As String = "N"
    Dim DescontoMaximo As Double = 0
    Dim ds As New DataSet
    Dim EstaNosItens As Boolean = False
    Dim EstoqueEstaNegativo As Boolean
    Private IdServico As Integer
    Dim JaFoiGeradoReceber As Boolean = False
    Private Operation As Byte
    Private OperationItens As Byte
    Dim opt As String
    Dim PedidoEmAndamento As Boolean = False
    Public PedidoInterno As Double = 0
    Public PVendedorEstaCheia As Boolean = False
    Dim QtdEstoqueEdi��o As Double
    Dim QtdEstoqueTela As Double
    Dim QtdEstoqueTemp As Double
    Public SomaDesconto As Double
    Public SomaDosParcelamentos As Double = 0
    Public SomaIpi As Double
    Public SomaTotalProdutos As Double
    Public SomaTotalServico As Double = 0
    Public SomaTotalServicos As Double
    Dim strCombo1 As String
    Dim strCombo2 As String
    Dim TipoProduto As Integer = 1
    Dim TipoVenda As String = ""
    Dim VarTemEntrada As Boolean = False
    Dim xLinha As Integer



    Private Sub AchaFormaPgto()
        If Me.ParcelamentoFixo.Text = "" Then
            VarTemEntrada = False
            Exit Sub
        Else

            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()

            Dim Sql As String = "Select * from FormaPgto Where CodFormaPgto = " & Me.ParcelamentoFixo.Text
            Dim Cmd As New OleDb.OleDbCommand(Sql, CNN)
            Dim DR As OleDb.OleDbDataReader

            Try
                DR = Cmd.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    Me.ParcelamentoFixoDesc.Text = DR.Item("Descri��o") & ""
                    Me.DiasParcelamento.Text = DR.Item("DiasParcelamento") & ""
                    If DR.Item("TemEntrada") = True Then
                        VarTemEntrada = True
                    Else
                        VarTemEntrada = False
                    End If
                Else
                    Me.ParcelamentoFixoDesc.Text = ""
                    Me.DiasParcelamento.Text = ""
                    VarTemEntrada = False
                End If
                DR.Close()
                CNN.Close()

            Catch Merror As System.Exception
                MsgBox(Merror.ToString)
            End Try
        End If
    End Sub

    Private Sub AchaFuncionario()

        Dim Cmd As New OleDb.OleDbCommand()
        Dim DR As OleDb.OleDbDataReader
        If CNN.State = ConnectionState.Closed Then
            CNN.Open()
        End If
        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "Select * From Funcion�rios Where C�digoFuncion�rio = " & Me.C�digoFuncion�rio.Text
            .CommandType = CommandType.Text
        End With

        Try
            DR = Cmd.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                If DR.Item("AdicionarEmVendas") = True Then
                    Me.FuncionarioDesc.Text = DR.Item("Nome") & ""
                Else
                    MessageBox.Show("Este funcion�rio n�o pode ser usado como vendedor, favor informar outro", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.C�digoFuncion�rio.Clear()
                    Me.FuncionarioDesc.Clear()
                    Me.C�digoFuncion�rio.Focus()
                    Exit Sub
                End If
            End If
            DR.Close()

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
        End Try

    End Sub

    Sub AchaObjeto()


        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String

        Sql = "SELECT *  From ObjetosCad Where CodObjeto =" & NzZero(Me.codigoObjeto.Text)


        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader
        Try
            CNN.Open()
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                With Me
                    .codigoObjeto.Text = DR.Item("CodObjeto")
                    .Veiculo.Text = DR.Item("Veiculo") & ""
                    .Placa.Text = DR.Item("placa") & ""
                    '.km.Text = DR.Item("km") & ""
                    '.obs.Text = DR.Item("obs") & ""
                End With
            End If


            DR.Close()
            CNN.Close()
        Catch ex As Exception
            Throw ex
        Finally
            CNN.Close()
        End Try
    End Sub

    Function AchaPropriedade() As Boolean
        If Me.Propriedade.Text = "" Then
            Me.PropriedadeDesc.Clear()
            Me.propUf.Clear()
            Me.PropriedadeIncri��o.Clear()
            Exit Function
        Else
            Dim Cmd As New OleDb.OleDbCommand()
            Dim DR As OleDb.OleDbDataReader

            With Cmd
                .Connection = CNN
                .CommandTimeout = 0
                .CommandText = "Select * from Propriedades Where Id = " & NzZero(Me.Propriedade.Text)
                .CommandType = CommandType.Text
            End With

            Try
                DR = Cmd.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    Me.PropriedadeDesc.Text = DR.Item("NomePropriedade") & ""
                    Me.propUf.Text = DR.Item("Estado") & ""
                    Me.PropriedadeIncri��o.Text = DR.Item("Inscricao") & ""
                    Return True
                Else
                    Me.PropriedadeDesc.Clear()
                    Me.Propriedade.Clear()
                    Me.PropriedadeDesc.Clear()
                    Me.propUf.Clear()
                    Me.PropriedadeIncri��o.Clear()
                    Return False
                End If
                DR.Close()

            Catch Merror As System.Exception
                MsgBox(Merror.ToString)
            End Try
        End If
    End Function

    Private Sub AchaUltimoPedido()

        Dim CnnNew As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CnnNew.Open()

        Dim Sql As String = "Select max(PedidoSequencia) from Pedido"
        Dim Cmd As New OleDb.OleDbCommand(Sql, CnnNew)
        Dim DR As OleDb.OleDbDataReader
        Dim Ult As Integer

        Try
            DR = Cmd.ExecuteReader
            DR.Read()
            If DR.HasRows = True Then
                If Not IsDBNull(DR.Item(0)) Then
                    Ult = DR.Item(0)
                Else
                    Ult = 0
                End If
            Else
                Ult = 0
            End If
            DR.Close()

        Catch EX As System.Exception
            MsgBox(EX.ToString)
            If ConnectionState.Open Then
                Exit Sub
            End If
        End Try

        Me.PedidoSequencia.Text = Ult + 1
        Me.DataPedido.Text = DataDia
        Me.TipoEntrega.Text = "IMEDIATA"
        Me.TpVenda.Text = "VENDA"

        If CNN.State = ConnectionState.Closed Then
            CNN.Open()
        End If

        Cmd = New OleDbCommand("Select C�digoCliente  FROM Pedido    WHERE PedidoSequencia=" & Me.PedidoSequencia.Text, CNN)
        'Dim i As Integer = Cmd.ExecuteScalar

    End Sub

    Public Sub atGridServico()
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim sql As String

        sql = "SELECT ItemServico.Id, ItemServico.PedidoSequencia, ItemServico.CodigoServico, Servicos.Serv_Descricao, Funcion�rios.Nome, ItemServico.Qtd, ItemServico.ValorUnitario, ItemServico.ValorDesconto, ItemServico.TotalServico, ItemServico.ValorISSQN, ItemServico.Desconto FROM (ItemServico INNER JOIN Servicos ON ItemServico.CodigoServico = Servicos.Serv_Codigo) INNER JOIN Funcion�rios ON ItemServico.Funcionario = Funcion�rios.C�digoFuncion�rio WHERE ItemServico.PedidoSequencia=" & NzZero(Me.PedidoSequencia.Text)


        Dim CMD As New OleDb.OleDbCommand(sql, CNN)
        Dim Da As New OleDb.OleDbDataAdapter(CMD)

        Dim ds As New DataSet


        Da.Fill(ds, "Table")

        Me.DgvItem.DataSource = ds.Tables("Table").DefaultView
        Me.ValorServicos.Text = FormatCurrency(NzZero(ds.Tables("Table").Compute("SUM(totalservico)", "")), 2)
        Me.Issqn.Text = FormatCurrency(NzZero(ds.Tables("Table").Compute("SUM(ValorISSQN)", "")), 2)
        SomaTotalServico = Me.ValorServicos.Text

        Da.Dispose()
        CNN.Close()

        If Me.DgvItem.Rows.Count > 0 Then
            Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.btClienteFind.Enabled = False
        Else
            Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.btClienteFind.Enabled = True
        End If
    End Sub

    Private Sub AVista_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValorAVista.Enter

        If Me.chkReterImposto.Checked Then
            Me.ValorAVista.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Else
            Me.ValorAVista.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        End If

        If Me.ValorAVista.Text = "" Then Me.ValorAVista.Text = FormatCurrency(0, 2)

    End Sub

    Private Sub AVista_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValorAVista.Leave

        If Me.MyLista1.Items.Count > 0 Then
            Exit Sub
        End If


        If CDbl(NzZero(Me.ValorAVista.Text)) + CDbl(NzZero(Me.ValorOutros.Text)) > TPedido.Text Then
            Me.ValorAVista.Text = 0
        End If

        If Me.chkReterImposto.Checked = True Then
            Me.ValorAFaturar.Text = FormatCurrency(CDbl(NzZero(Me.TPedido.Text)) - CDbl(NzZero(Me.ValorAVista.Text)) - CDbl(NzZero(Me.ValorOutros.Text)) - CDbl(NzZero(Me.Issqn.Text)), 2)
            Me.ValorAFaturar.Text = FormatCurrency(NzZero(Me.ValorAFaturar.Text), 2)
            If (CDbl(ValorAFaturar.Text) < 0) Then
                Me.ValorAFaturar.Text = "0,00"
            End If
        Else
            Me.ValorAFaturar.Text = FormatCurrency(CDbl(NzZero(Me.TPedido.Text)) - CDbl(NzZero(Me.ValorAVista.Text)) - CDbl(NzZero(Me.ValorOutros.Text)), 2)
        End If

        Me.ValorAVista.Text = FormatCurrency(Me.ValorAVista.Text, 2)

        If ValorAVista.Text = TPedido.Text Then
            ParcelamentoFixo.Text = ""
            ParcelamentoFixoDesc.Text = ""
            DiasParcelamento.Text = ""
        End If

    End Sub

    Private Sub BloquearCabecalho()

        If Me.MyLista.Items.Count <> 0 Then
            'Me.NumeroControle.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.TpVenda.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Sim
            Me.TipoEntrega.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Sim
        Else
            'Me.NumeroControle.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.TpVenda.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.N�o
            Me.TipoEntrega.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.N�o
        End If
    End Sub

    Private Sub btAddNumeroControle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddNumeroControle.Click
        If Me.PedidoSequencia.Text = "" Then
            Exit Sub
        End If
        If Me.NumeroControle.Text <> "" Then
            MessageBox.Show("J� foi adicionado um n�mero de Controle, opera��o ser� cancelada.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        My.Forms.PedidoVendaAddNumeroControle.ShowDialog()
    End Sub

    Private Sub btClienteFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClienteFind.Click
        If CDbl(NzZero(Me.TotalPedido.Text)) > 0 Then
            MessageBox.Show("N�o � poss�vel trocar de cliente." & Chr(13) & "H� produtos ou servi�os lan�ados neste pedido", "Aten��o", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If Me.Inativo.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi Cancelado n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Operation = VAZ Then
            MessageBox.Show("O usu�rio n�o inicializou um Pedido para procurar o cliente, Verifique", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Operation = UPD Then
            '
            If Me.C�digoCliente.Text <> "" Then
                If Me.MyLista.Items.Count > 0 Or DgvItem.RowCount > 0 Then
                    Me.C�digoCliente.Focus()
                    Autorizado = PedirPermissao(Me.Text, Me.PedidoSequencia.Text)
                    Autorizado = varAutorizado
                    If Autorizado = False Then
                        Exit Sub
                    End If
                End If
            End If

            Me.NomeCliente.Clear()
            Me.CpfCgc.Clear()
            Me.Insc.Clear()
            Me.Endere�o.Clear()
            Me.Cidade.Clear()
            Me.Estado.Clear()
            Me.Cep.Clear()
            Me.UsarLimite.Checked = False
            Me.ClienteBloqueado.Checked = False
            Me.LimiteCredito.Text = FormatNumber(0, 2)


            Operation = UPD
            My.Forms.ClientesProcura.ShowDialog()
            LocalizaDadosCliente()
            Me.C�digoCliente.Focus()
            ErroLivre = "Altera��o do Cliente " & Me.C�digoCliente.TextoAntigo & " Para o Cliente " & Me.C�digoCliente.Text
            GerarLog(Me.Text, A��oTP.Livre, Me.PedidoSequencia.Text)
        End If
    End Sub

    Private Sub btFindParcelamentoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFindParcelamentoFixo.Click
        If Operation = UPD Then
            My.Forms.ProcuraFormaPgto.ShowDialog()
            AchaFormaPgto()
            'Me.C�digoFuncion�rio.Focus()
            Me.ParcelamentoFixo.Focus()
        End If
    End Sub

    Private Sub btFindVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFindVendedor.Click
        If Operation = VAZ Then
            MessageBox.Show("O usu�rio n�o inicializou um Pedido para procurar um vendedor, Verifique", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Operation = UPD Then
            My.Forms.PedidoVendaFindVendedores.ShowDialog()
            Me.C�digoFuncion�rio.Focus()
            AchaFuncionario()
        End If

    End Sub

    Private Sub btGerarParcelas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGerarParcelas.Click

        If Me.Inativo.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi Cancelado n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If


        If Me.ValorAFaturar.Text = 0 Then

            Exit Sub
        End If

        If String.IsNullOrEmpty(ValorOutros.Text) Then
            ValorOutros.Text = "0,00"
        End If

        If VarTemEntrada = True And NzZero(Me.ValorAVista.Text) = 0 Then
            MessageBox.Show("Esta condi��o de Pagamento necessita de uma entrada, favor verificar...", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ValorAVista.Focus()
            Exit Sub
        End If

        If Me.TpVenda.Text = "" Then
            MsgBox("O usu�rio deve informar qual o tipo de venda.", 64, "Valida��o de Dados")
            Me.TpVenda.Focus()
            Exit Sub
        End If

        If Me.Confirmado.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi confirmado n�o pode ser alterado as parcelas", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.C�digoFuncion�rio.Text = "" Then
            MsgBox("O usu�rio deve informar qual o vendedor.", 64, "Valida��o de Dados")
            Me.C�digoFuncion�rio.Focus()
            Exit Sub
        End If

        If JaFoiGeradoReceber = True Then
            MsgBox("Para este pedido o parcelamento ja foi gerado. Verifique...", 64, "Valida��o de Dados")
            Me.DiasParcelamento.Focus()
            Exit Sub
        End If

        Dim TpedidoVAR As Double = Me.TPedido.Text
        Dim Tconfer As Double
        If Me.chkReterImposto.Checked = True Then
            Tconfer = Nz(CDbl(Me.ValorAFaturar.Text), 3) + Nz(CDbl(Me.ValorAVista.Text), 3) + Nz(CDbl(Me.ValorOutros.Text), 3) + Nz(CDbl(Me.Issqn.Text), 3)
        Else
            Tconfer = Nz(CDbl(Me.ValorAFaturar.Text), 3) + Nz(CDbl(NzZero(Me.ValorAVista.Text)), 3) + Nz(CDbl(Me.ValorOutros.Text), 3)
        End If

        If TpedidoVAR <> FormatNumber(Tconfer, 2) Then
            MsgBox("Os Valores de faturamento n�o batem com o total do pedido, passe por todos os campos ou contacte o Administrador.", 64, "Valida��o de Dados")
            Exit Sub
        End If



        If Me.ValorAFaturar.Text <> 0 Then
            If Me.DiasParcelamento.Text = "" Then
                MsgBox("O usu�rio deve criar o parcelamento para o valor a ser faturado.", 64, "Valida��o de Dados")
                Me.DiasParcelamento.Focus()
                Exit Sub
            End If
        End If

        If Me.Confirmado.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi confirmado n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.ValorIpiPedido.Text = "" Then Me.ValorIpiPedido.Text = FormatCurrency(SomaIpi, 2)
        If Me.VlrDescProduto.Text = "" Then Me.VlrDescProduto.Text = FormatCurrency(0, 2)
        If Me.ValorProduto.Text = "" Then Me.ValorProduto.Text = FormatCurrency(SomaTotalProdutos, 2)

        'If DescontoEmLinha = True Then
        '    Me.VlrDescProduto.Text = FormatCurrency(SomaDesconto, 2)
        '    Me.TotalPedido.Text = FormatCurrency(CDbl(Me.ValorProduto.Text) + CDbl(Me.ValorIpiPedido.Text))
        'Else
        '    Me.TotalPedido.Text = FormatCurrency(CDbl(Me.ValorProduto.Text) + CDbl(Me.ValorIpiPedido.Text) - CDbl(Me.VlrDescProduto.Text), 2)
        'End If


        If Me.C�digoFuncion�rio.Text = "" Then
            MsgBox("O usu�rio deve selecionar um vendedor para o Pedido.", 64, "Valida��o de Dados")
            Me.C�digoFuncion�rio.Focus()
            Exit Sub
        ElseIf Me.ValorAVista.Text = "" Then
            Me.ValorAVista.Text = FormatCurrency(0, 2)
        ElseIf Me.ValorOutros.Text = "" Then
            Me.ValorOutros.Text = FormatCurrency(0, 2)
        ElseIf Me.ValorAFaturar.Text = "" Then
            Me.ValorAFaturar.Text = FormatCurrency(0, 2)
        ElseIf Me.Propriedade.Text = "" Then
            Me.Propriedade.Text = 0
        ElseIf Me.Propriedade.Text = "" Then
            Me.Propriedade.Text = 0
        End If

        If Me.C�digoFuncion�rio.Text = 0 Then
            MsgBox("O usu�rio deve selecionar um vendedor para o Pedido.", 64, "Valida��o de Dados")
            Me.C�digoFuncion�rio.Focus()
            Exit Sub
        End If

        If Me.TotalPropostoPedido.Text = "" Then
            Me.TotalPropostoPedido.Text = FormatNumber(Me.TPedido.Text, 2)
        End If

        'Fim da Area destinada para as validacoes
        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        If Operation = UPD Then

            Dim Sql As String = "Update Pedido  set C�digoCliente = @1, Propriedade = @2, DataPedido = @3, ObsCab = @4, ObsRod = @5, Empresa = @6, ValorProduto = @7, TotalPedido = @8, ValorAVista = @9, ValorOutros = @10, ValorAFaturar = @11, VlrDescProduto = @12, ValorIpiPedido = @13, DiasParcelamento = @14, C�digoFuncion�rio = @15, PedidoTipo = @16, TipoEntrega = @17, TotalPropostoPedido = @18, MediaDesconto = @19 Where PedidoSequencia = " & Me.PedidoSequencia.Text
            Dim cmd As New OleDb.OleDbCommand(Sql, Cnn)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.C�digoCliente.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Propriedade.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.DataPedido.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.ObsCab.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.ObsRod.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", CodEmpresa))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.ValorProduto.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.TotalPedido.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.ValorAVista.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.ValorOutros.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.ValorAFaturar.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.VlrDescProduto.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(Me.ValorIpiPedido.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.DiasParcelamento.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.C�digoFuncion�rio.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.TpVenda.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.TipoEntrega.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", NzZero(Me.TotalPropostoPedido.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", NzZero(Me.MediaDesconto.Text)))

            Try
                cmd.ExecuteNonQuery()
                Operation = UPD
                GerarParcelamentos()

                ErroLivre = "Gerado contas a receber"
                GerarLog(Me.Text, A��oTP.Livre, Me.PedidoSequencia.Text)


                Me.chkReterImposto.Enabled = False
                Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.btClienteFind.Enabled = False
                PainelParcelamentoFixo.Enabled = False

            Catch ex As Exception



                MsgBox(ex.Message, 64, "Valida��o de Dados")
            End Try
        End If

    End Sub

    Private Sub BtLimparObjeto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtLimparObjeto.Click
        Me.Veiculo.Clear()
        Me.Placa.Clear()
        Me.km.Clear()
        Me.obs.Clear()
        Me.codigoObjeto.Clear()
    End Sub

    Private Sub btNovoItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNovoItem.Click
        If JaFoiGeradoReceber = True Then
            MsgBox("Neste pedido n�o pode ser incluido produto, pois ja foi gerado o contas a receber, exclua o contas receber para incluir novos produtos.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If JaFoiGeradoReceber = True Then
            MsgBox("Para este pedido o parcelamento ja foi gerado. Verifique...", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.Inativo.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi Cancelado n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If


        If Me.Confirmado.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi confirmado n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.PedidoSequencia.Text = "" Then
            MsgBox("O usu�rio deve antes de lan�ar os itens inicializar um pedido.", 64, "Valida��o de Dados")
            Me.PedidoSequencia.Focus()
            Exit Sub
        ElseIf Me.C�digoCliente.Text = "" Then
            MsgBox("O usu�rio deve antes selecionar um cliente para lan�ar os itens.", 64, "Valida��o de Dados")
            Me.C�digoCliente.Focus()
            Exit Sub
        End If

        EstaNosItens = True

        Me.PedidoSequencia.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.NomeCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.CpfCgc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Insc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Endere�o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cidade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cep.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Estado.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Propriedade.Enabled = False
        Me.propUf.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.PropriedadeIncri��o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.DataPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim

        Me.MyLista.Enabled = True
        CNN.Close()

        My.Forms.PedidoAddItemOS.OperationItens = INS
        My.Forms.PedidoAddItemOS.ShowDialog()
        'ctrlTabParcelamento()

        Me.TabPedido.SelectedTab = Me.TabServico
        'Me.TotalPropostoPedido.Focus()
        CNN.Open()

    End Sub

    Private Sub btParcelamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btParcelamento.Click
        Me.TabPedido.SelectedTab = Me.TabParcelamento

        Me.TotalPropostoPedido.Focus()
    End Sub

    Private Sub btPropriedadeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPropriedadeFind.Click
        If Operation = VAZ Then
            MessageBox.Show("O usu�rio n�o inicializou um Pedido para procurar o cliente, Verifique", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Me.PropriedadeDesc.Clear()
        Me.propUf.Clear()
        Me.PropriedadeIncri��o.Clear()

        My.Forms.ProcuraPropriedades.ShowDialog()
        AchaPropriedade()
        Me.Propriedade.Focus()
    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        If Me.Confirmado.Checked = False Then
            MessageBox.Show("O usu�rio n�o pode emitir Ordem de Entrega para pedido n�o Confirmado", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Me.TipoEntrega.Text = "IMEDIATA" Then
            MessageBox.Show("A Entrega deste pedido est� como IMEDIATA, n�o pode gerar Ordem de Entrega para este pedido.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Me.StatusAndamentos.Text = "FINALIZADO" Then
            MessageBox.Show("A Entrega deste pedido est� como finalizado, n�o pode gerar nova ordem de entrega para este pedido.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        TRVDados(UserAtivo, "OrdemEntrega")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.OrdemEntrega.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        TRVDados(UserAtivo, "OrdemEntregaVisualizador")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.OrdemEntregaVisualizador.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click
        If Me.PedidoSequencia.Text = "" Then
            MsgBox("Favor informar um Pedido/Venda para emiss�o de Nota Fiscal.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        TRVDados(UserAtivo, "NFiscal")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            NotaFiscalAvulsa = False
            My.Forms.NFiscal.ShowDialog()
        End If

    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem4.Click
        If Me.PedidoSequencia.Text = "NFVisualizador" Then
            MsgBox("O usu�rio deve selecionar um pedido antes.", 64, "Valida��o de Dados")
            Exit Sub
        End If
        My.Forms.NFVisualizador.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        My.Forms.OsObjetoLocalizar.ShowDialog()
        'My.Forms.ObjetoLocalizar.ShowDialog()
    End Sub

    Private Sub chkReterImposto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReterImposto.CheckedChanged
        Dim VlrPedido As Double = FormatNumber(Me.TPedido.Text, 2)
        Dim VlrGeral As Double = 0



        If Me.chkReterImposto.Checked = True Then

            Me.ValorOutros.Text = "0,00"
            Me.ValorAVista.Text = "0,00"
            Me.ValorAFaturar.Text = FormatCurrency(CDbl(NzZero(Me.TPedido.Text)) - CDbl(NzZero(Me.Issqn.Text)), 2)

        Else
            Me.ValorAFaturar.Text = FormatCurrency(CDbl(NzZero(Me.TPedido.Text)) - CDbl(NzZero(Me.ValorAVista.Text)) - CDbl(NzZero(Me.ValorOutros.Text)), 2)
        End If
        Me.ValorAFaturar.Text = FormatCurrency(NzZero(Me.ValorAFaturar.Text), 2)

    End Sub

    Private Sub Clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clientes.Click
        My.Forms.Clientes.ShowDialog()
    End Sub

    Private Sub C�digoCliente_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C�digoCliente.Enter
        If NzZero(Me.TotalPedido.Text) > 0 Then
            Me.C�digoCliente.ReadOnly = True
        Else
            Me.C�digoCliente.ReadOnly = False
        End If
    End Sub

    Private Sub C�digoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C�digoCliente.KeyDown
        If Operation = VAZ Then
            MessageBox.Show("O usu�rio n�o inicializou um Pedido para procurar o cliente, Verifique", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Select Case e.KeyCode
            Case Keys.F5
                If Operation = UPD Then

                    'controle da troca de cliente no peidoos
                    If Me.C�digoCliente.Text <> "" Then
                        Autorizado = PedirPermissao(Me.Text, Me.PedidoSequencia.Text)
                        Autorizado = varAutorizado
                        If Autorizado = False Then
                            Exit Sub
                        End If
                    End If

                    Me.NomeCliente.Clear()
                    Me.CpfCgc.Clear()
                    Me.Insc.Clear()
                    Me.Endere�o.Clear()
                    Me.Cidade.Clear()
                    Me.Estado.Clear()
                    Me.Cep.Clear()
                    Me.UsarLimite.Checked = False
                    Me.ClienteBloqueado.Checked = False
                    Me.LimiteCredito.Text = FormatNumber(0, 2)
                    'My.Forms.ClientesProcura.ShowDialog()
                    'LocalizaDadosCliente()


                    '
                    My.Forms.ClientesProcura.ShowDialog()
                    LocalizaDadosCliente()
                    Me.C�digoCliente.Focus()

                    ErroLivre = "Selecionou o Cliente para o Pedido"
                    GerarLog(Me.Text, A��oTP.Livre, Me.PedidoSequencia.Text)
                    GerarLog(Me.Text, A��oTP.Livre, Me.C�digoCliente.Text)
                End If
        End Select

    End Sub

    Private Sub C�digoCliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C�digoCliente.Leave
        If String.CompareOrdinal(Me.C�digoCliente.Text, Me.C�digoCliente.TextoAntigo) Then
            LocalizaDadosCliente()
        End If
    End Sub

    Private Sub C�digoCliente_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles C�digoCliente.Validating
        'faz um jun��o se o cliente � nulo e o pedido n�o � nulo. **** beto
        If String.IsNullOrEmpty(C�digoCliente.Text) And Not String.IsNullOrEmpty(PedidoSequencia.Text) Then
            Me.C�digoCliente.Focus()
            Exit Sub
        Else
            salvarDadosClientes()
        End If
    End Sub

    Private Sub C�digoFuncion�rio_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C�digoFuncion�rio.Enter
        ctrlTabParcelamento()
    End Sub

    Private Sub C�digoFuncion�rio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C�digoFuncion�rio.KeyDown
        If e.KeyCode = Keys.F5 Then
            If Operation = VAZ Then
                MessageBox.Show("O usu�rio n�o inicializou um Pedido para procurar um vendedor, Verifique", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Operation = UPD Then
                My.Forms.PedidoVendaFindVendedores.ShowDialog()
                Me.C�digoFuncion�rio.Focus()
                AchaFuncionario()
            End If
        End If


    End Sub

    Private Sub C�digoFuncion�rio_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles C�digoFuncion�rio.Leave
        If String.CompareOrdinal(Me.C�digoFuncion�rio.Text, Me.C�digoFuncion�rio.TextoAntigo) Then
            AchaFuncionario()
        End If
    End Sub

    Private Sub CodigoProduto_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Bal�oAjuda.Show("Pressione enter sem codigo para localizar um produto.", Me.CodigoProduto, 2000)

        If Me.PedidoSequencia.Text = "" Then
            MsgBox("Para lan�ar Itens o usu�rio deve selecionar um pedido.", 64, "Valida��o de Dados")
            Me.PedidoSequencia.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub Confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Confirmar.Click
        Dim cxFechado As New CaixaFechado
        cxFechado.CaixaEstaFechado()

        If CDbl(NzZero(Me.ValorAFaturar.Text)) <> 0 Then
            If Me.DiasParcelamento.Text = "" Then
                MsgBox("O usu�rio deve criar o parcelamento para o valor a ser faturado.", 64, "Valida��o de Dados")

                Me.DiasParcelamento.Focus()
                Exit Sub
            End If
        End If
        If NzZero(Me.TotalPropostoPedido.Text) = 0 Then
            Me.TotalPropostoPedido.Text = FormatNumber(NzZero(Me.TPedido.Text), 2)
        End If
        ctrlTabParcelamento()
        'If NzZero(Me.TotalPropostoPedido.Text) = 0 Then
        '    MessageBox.Show("O valor proposto n�o foi informado.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        If Operation = INS Then
            MessageBox.Show("Este pedido ainda n�o foi adicionado os dados, verifique.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If NzZero(Me.TotalParcelamento.Text) = 0 Then FormatNumber(0, 2)

        If Me.PedidoSequencia.Text = "" Then
            MsgBox("N�o foi informado nenhum Pedido/Venda.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.Confirmado.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi confirmado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.DataPedido.Text = "" Then
            MsgBox("A data do Pedido n�o foi informada, favor verificar...", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.TpVenda.Text = "" Then
            MsgBox("O usu�rio deve informar qual o tipo de venda.", 64, "Valida��o de Dados")
            Me.TpVenda.Focus()
            Exit Sub
        End If



        If NzZero(Me.C�digoFuncion�rio.Text) = 0 Then
            MsgBox("O usu�rio deve selecionar um Funcion�rio para o Pedido.", 64, "Valida��o de Dados")
            Me.C�digoFuncion�rio.Focus()
            Exit Sub
        End If

        If Me.ValorAVista.Text = "" Then
            MsgBox("o Valor a vista n�o pode ser vazio, se n�o h� faturamento a Vista coloque zero.", 64, "Valida��o de Dados")
            Me.ValorAVista.Focus()
            Exit Sub
        ElseIf Me.ValorOutros.Text = "" Then
            MsgBox("o Valor Ch/Outros n�o pode ser vazio, se n�o h� faturamento Ch/Outros coloque zero.", 64, "Valida��o de Dados")
            Me.ValorOutros.Focus()
            Exit Sub
        ElseIf Me.ValorAFaturar.Text = "" Then
            MsgBox("o Valor a faturar n�o pode ser vazio, se n�o h� faturamento a Prazo coloque zero.", 64, "Valida��o de Dados")
            Me.ValorAFaturar.Focus()
            Exit Sub
        End If

        If Me.ValorAFaturar.Text <> Me.TotalParcelamento.Text Then
            MsgBox("Verifique o total de parcelamento, pois esta diferente do valor a faturar", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.UsarLimite.Checked = True Then
            Dim VlrFaturar As Double = FormatNumber(Me.ValorAFaturar.Text, 2)
            Dim VlrLimite As Double = FormatNumber(Me.LimiteCredito.Text, 2)
            If VlrFaturar > VlrLimite Then
                MsgBox("Este Cliente esta sendo controlado por limite de Cr�dito, Limite ultrapassado, Verifique.", 64, "Valida��o de Dados")
                Exit Sub
            End If
        End If


        Dim VlrPedido As Double = FormatNumber(Me.TPedido.Text, 2)
        Dim VlrGeral As Double = 0

        If Me.chkReterImposto.Checked = True Then
            VlrGeral = FormatNumber(CDbl(Me.ValorAVista.Text) + CDbl(Me.ValorOutros.Text) + CDbl(Me.ValorAFaturar.Text) + CDbl(Me.Issqn.Text), 2)
        Else
            VlrGeral = FormatNumber(CDbl(Me.ValorAVista.Text) + CDbl(Me.ValorOutros.Text) + CDbl(Me.ValorAFaturar.Text), 2)
        End If

        If VlrPedido <> VlrGeral Then
            MsgBox("Verifique...O valor do pedido esta diferente dos valores de faturamento A Vista/Outros/Parcelado.", 64, "Valida��o de Dados")
            Exit Sub
        End If


        'Verifica se a parcela foi gerada para o cliente correto
        RetornoProcura = ""
        Dim I As Integer = 0

        For I = 0 To MyLista1.Items.Count - 1
            RetornoProcura = MyLista1.Items(I).SubItems(5).Text.Substring(0)
            If Me.C�digoCliente.Text <> RetornoProcura Then
                MsgBox("O Cliente que foi gerado parcela esta diferente do cliente do Pedido, favor verificar.", 64, "Valida��o de Dados")
                Exit Sub
            End If
        Next
        'fim


        'fim

        If NzZero(Me.TotalPropostoPedido.Text) = 0 Then
            Me.TotalPropostoPedido.Text = FormatNumber(Me.TPedido.Text, 2)
        End If

        'Salvar dados do Pedido
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "Update Pedido  Set C�digoCliente = @1, Propriedade = @2, DataPedido = @3, ObsCab = @4, ObsRod = @5, Empresa = @6, ValorProduto = @7, TotalPedido = @8, ValorAVista = @9, ValorOutros = @10, ValorAFaturar = @11, VlrDescProduto = @12, ValorIpiPedido = @13, DiasParcelamento = @14, C�digoFuncion�rio = @15, PedidoTipo = @16, StatusAndamentos = @17, FormaPgto = @18, TipoEntrega = @19, PercDesconto = @20, ValorServicos = @21, TotalPropostoPedido = @22, MediaDesconto = @23,reterimposto=@24,issqn=@25 Where Pedido.PedidoSequencia = " & Me.PedidoSequencia.Text
        Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

        cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.C�digoCliente.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Propriedade.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.DataPedido.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.ObsCab.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.ObsRod.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@6", CodEmpresa))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@7", NzZero(Me.ValorProduto.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@8", NzZero(Me.TPedido.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@9", NzZero(Me.ValorAVista.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@10", NzZero(Me.ValorOutros.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@11", NzZero(Me.ValorAFaturar.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@12", NzZero(Me.VlrDescProduto.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@13", NzZero(Me.ValorIpiPedido.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@14", NzZero(Me.DiasParcelamento.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.C�digoFuncion�rio.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.TpVenda.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.StatusAndamentos.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.ParcelamentoFixo.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@19", Nz(Me.TipoEntrega.Text, 1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@20", NzZero(Me.PercDesconto.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@21", NzZero(Me.ValorServicos.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@22", NzZero(Me.TotalPropostoPedido.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@23", NzZero(Me.MediaDesconto.Text)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@24", Me.chkReterImposto.Checked))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@25", NzZero(Me.Issqn.Text)))


        Try
            'Atualiza o Pedido
            cmd.ExecuteNonQuery()

            'Atualiza os Registros do Contas a Receber
            cmd = New OleDb.OleDbCommand()
            cmd.CommandText = "UPDATE Receber SET Receber.NotaFiscal = @30, Receber.NotaFiscalServico =@32 WHERE Receber.PedidoProdutos=" & Me.PedidoSequencia.Text
            cmd.Connection = CNN
            cmd.Parameters.Add(New OleDb.OleDbParameter("@30", Nz(Me.txtNfePecas.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@32", Nz(Me.txtNfeServico.Text, 1)))
            cmd.ExecuteNonQuery()



            CNN.Close()
            Operation = UPD
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Valida��o de Dados")
        End Try
        '
        If Len(CaixaAtivo) <> 4 Then
            MessageBox.Show("O usuario deve selecionar um caixa antes de Confirmar o Pedido. Verifique", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If MsgBox("Deseja Ativar o caixa agora", 36, "Valida��o de Dados") = 6 Then
                TRVDados(UserAtivo, "CaixaAtivarDesativar")
                If Ina = True Then
                    MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
                    Exit Sub
                Else
                    My.Forms.CaixaAtivarDesativar.ShowDialog()
                End If
            End If
        End If
        If String.IsNullOrEmpty(CaixaAtivo) Then
            Exit Sub
        End If

        If Me.TpVenda.Text <> "CONSIGNA��O" Then
            My.Forms.PedidoVendaConfirmarOS.ShowDialog()
        Else
            My.Forms.PedidoVendaConfirmarOutrosOS.ShowDialog()
        End If

    End Sub

    Public Sub ctrlTabParcelamento()
        Me.VlrDescProduto.Text = FormatCurrency(CDbl(NzZero(SomaDesconto)), 2)
        Me.TotalPedido.Text = FormatCurrency(CDbl(NzZero(SomaTotalProdutos)) - CDbl(NzZero(Me.VlrDescProduto.Text)), 2)
        Me.TPedido.Text = FormatCurrency(CDbl(NzZero(Me.TotalPedido.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)) + (SomaTotalServico), 2)
        Me.VlrDescProduto.Focus()

        If String.IsNullOrEmpty(Me.TotalPropostoPedido.Text) Then
            Me.TotalPropostoPedido.Text = Me.TPedido.Text
        End If

        'Me.TPedido.Text = Me.TotalPedido.Text
        Me.TabPedido.SelectedTab = Me.TabParcelamento
        Me.C�digoFuncion�rio.Focus()
    End Sub

    Private Sub DgvItem_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvItem.CellClick
        IdServico = Me.DgvItem.CurrentRow.Cells("gridID").Value
    End Sub

    Private Sub DgvItem_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvItem.SelectionChanged
        Try
            IdServico = Me.DgvItem.CurrentRow.Cells("gridID").Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditaItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditaItemToolStripMenuItem.Click
        If Me.Confirmado.Checked = True Then
            MsgBox("Este pedido j� foi confirmado, n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If JaFoiGeradoReceber = True Then
            MsgBox("Neste pedido n�o pode ser Editado produto, pois ja foi gerado o contas a receber, exclua o contas receber para incluir novos produtos.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        RetornoProcura = ""
        Dim I As Integer = 0

        For I = 0 To MyLista.Items.Count - 1
            If MyLista.Items(I).Selected = True Then RetornoProcura = (MyLista.Items(I).Text.Substring(0))
        Next

        If RetornoProcura = "" Then
            MsgBox("O usu�rio deve selecionar um item da lista.", 64, "Valida��o de Dados")
            Exit Sub
        End If


        My.Forms.PedidoAddItemOS.OperationItens = UPD

        PedidoAddItemOS.ShowDialog()

    End Sub

    Private Sub Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Editar.Click

        If Me.Inativo.Checked = True Then
            MessageBox.Show("Este pedido foi cancelado, somente pode ser visualizado.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Me.Confirmado.Checked = True Then
            MessageBox.Show("Este pedido ja foi confirmado, somente pode ser visualizado.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Me.NumeroControle.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.PedidoSequencia.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.NomeCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.CpfCgc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.Insc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.Endere�o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.Cidade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.Cep.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.Estado.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.ObsCab.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.ObsRod.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.Propriedade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.propUf.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.PropriedadeIncri��o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.DataPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.TpVenda.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.N�o
            Me.TipoEntrega.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.N�o
            Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim

            If ParcFixo = True Then
                Me.PainelParcelamentoFixo.Visible = True
                Me.ParcelamentoFixo.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.ParcelamentoFixoDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.DiasParcelamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.DiasParcelamento.Visible = False
                LabelParcelamento.Visible = False
            Else
                Me.PainelParcelamentoFixo.Visible = False
                Me.DiasParcelamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.DiasParcelamento.Visible = True
                LabelParcelamento.Visible = True
            End If

            If DescontoEmLinha = False Then
                Me.PainelDesconto.Visible = True
                Me.PercDesconto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.VlrDescProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Else
                Me.PainelDesconto.Visible = False
                Me.PercDesconto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.VlrDescProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            End If

            Me.C�digoFuncion�rio.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.ValorAVista.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.ValorOutros.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.ValorAFaturar.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.btGerarParcelas.Enabled = True


            Operation = UPD
            Me.PedidoSequencia.Focus()
        End If
    End Sub

    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Selecione um item da Lista com duplo Click para entrar editando o item.", 64, "Valida��o de Dados")
        Exit Sub
    End Sub

    Private Sub EmAberto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmAberto.CheckedChanged
        If Me.EmAberto.Checked = True Then
            EncheGrid()
        End If
    End Sub

    Public Sub EncheCaixas(ByVal ControleRetorno As Control, ByVal Tabela As String, ByVal CampoOrdenar As String, ByVal ItemDisplay As String, ByVal ItemCodigo As String, ByVal AgrupaItemDisplay As Boolean)

        Dim ItemCombo As New ArrayList

        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader

        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "Select * from " & Tabela & " where Empresa = " & CodEmpresa & " order by " & CampoOrdenar
            .CommandType = CommandType.Text
        End With

        Try
            DataReader = Cmd.ExecuteReader

            If DataReader.HasRows = True Then
                With ItemCombo
                    While DataReader.Read
                        If Not IsDBNull(DataReader.Item(0)) Then
                            If AgrupaItemDisplay = True Then
                                .Add(New ItemData(DataReader.Item(ItemCodigo) & "-" & DataReader.Item(ItemDisplay), DataReader.Item(ItemCodigo), DataReader.Item(ItemCodigo)))
                            Else
                                .Add(New ItemData(DataReader.Item(ItemDisplay), DataReader.Item(ItemCodigo), DataReader.Item(ItemCodigo)))
                            End If
                        End If
                    End While
                End With
            End If
            DataReader.Close()

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Exit Sub
            End If
        End Try

        With CType(ControleRetorno, ComboBox)
            .DataSource = ItemCombo
            .DisplayMember = "GetDescri��o"
            .ValueMember = "GetidentificadorString"
        End With
        CType(ControleRetorno, ComboBox).SelectedIndex = -1
        'fim inserir ultimo registro

    End Sub

    Private Sub EncheGrid()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Dim DsProcura As New DataSet

        If Me.MostrarTodos.Checked = True Then
            'Sql = "SELECT Pedido.PedidoSequencia, Pedido.Requisicao, Pedido.PedidoTipo, Funcion�rios.Nome AS NomeFunc, Clientes.Nome, Clientes.Cidade, Pedido.TotalPedido, Pedido.Empresa, Pedido.Inativo, Pedido.DataPedido, Pedido.codobjeto, Pedido.Confirmado                    FROM (Pedido LEFT JOIN Clientes ON Pedido.C�digoCliente = Clientes.Codigo) LEFT JOIN Funcion�rios ON Pedido.C�digoFuncion�rio = Funcion�rios.C�digoFuncion�rio WHERE(((Pedido.Empresa) = " & CodEmpresa & ")) ORDER BY Pedido.PedidoSequencia DESC;"
            Sql = "SELECT Pedido.PedidoSequencia, Pedido.Requisicao, Pedido.PedidoTipo, Funcion�rios.Nome AS NomeFunc, Clientes.Nome, Clientes.Cidade, Pedido.TotalPedido, Pedido.Empresa, Pedido.Inativo, Pedido.DataPedido, Pedido.Confirmado, objetoscad.placa, objetoscad.veiculo FROM ((Pedido LEFT JOIN Clientes ON Pedido.C�digoCliente = Clientes.Codigo) LEFT JOIN Funcion�rios ON Pedido.C�digoFuncion�rio = Funcion�rios.C�digoFuncion�rio) LEFT JOIN objetoscad ON Pedido.codobjeto = objetoscad.codobjeto WHERE(((Pedido.Empresa) = " & CodEmpresa & ") and ((Pedido.C�digoCliente)>0)) ORDER BY Pedido.PedidoSequencia DESC;"

        ElseIf Me.EmAberto.Checked = True Then
            'Sql = "SELECT Pedido.PedidoSequencia, Pedido.Requisicao, Pedido.PedidoTipo, Funcion�rios.Nome AS NomeFunc, Clientes.Nome, Clientes.Cidade, Pedido.TotalPedido, Pedido.Empresa, Pedido.Inativo, Pedido.DataPedido, Pedido.codobjeto, Pedido.Confirmado FROM (Pedido LEFT JOIN Clientes ON Pedido.C�digoCliente = Clientes.Codigo) LEFT JOIN Funcion�rios ON Pedido.C�digoFuncion�rio = Funcion�rios.C�digoFuncion�rio WHERE(((Pedido.Empresa) = " & CodEmpresa & ")) And Pedido.Confirmado = False And Pedido.Inativo = False ORDER BY Pedido.PedidoSequencia DESC;"
            Sql = "SELECT Pedido.PedidoSequencia, Pedido.Requisicao, Pedido.PedidoTipo, Funcion�rios.Nome AS NomeFunc, Clientes.Nome, Clientes.Cidade, Pedido.TotalPedido, Pedido.Empresa, Pedido.Inativo, Pedido.DataPedido, Pedido.Confirmado, objetoscad.placa, objetoscad.veiculo FROM ((Pedido LEFT JOIN Clientes ON Pedido.C�digoCliente = Clientes.Codigo) LEFT JOIN Funcion�rios ON Pedido.C�digoFuncion�rio = Funcion�rios.C�digoFuncion�rio) LEFT JOIN objetoscad ON Pedido.codobjeto = objetoscad.codobjeto  WHERE (((Pedido.Empresa) = " & CodEmpresa & ") And ((Pedido.Inativo) = False) And ((Pedido.Confirmado) = False) and ((Pedido.C�digoCliente)>0)) ORDER BY Pedido.PedidoSequencia DESC;"

        Else

            Dim CampoFilter As String = ""
            Select Case opt
                Case "Pedido"
                    CampoFilter = "PedidoSequencia" & " Like '%" & Me.TxtProcura.Text & "%'"
                Case "Cliente"
                    CampoFilter = "Clientes.Nome" & " Like '%" & Me.TxtProcura.Text & "%'"
                Case "controle"
                    CampoFilter = "Requisicao" & " Like '%" & Me.TxtProcura.Text & "%'"
                Case "Data"
                    CampoFilter = "DataPedido" & "=#" & Format(CDate(Me.TxtProcura.Text), "MM/dd/yyyy") & "#"

            End Select

            'Sql = "SELECT Pedido.PedidoSequencia, Pedido.Requisicao, Pedido.PedidoTipo, Funcion�rios.Nome AS NomeFunc, Clientes.Nome, Clientes.Cidade, Pedido.TotalPedido, Pedido.Empresa, Pedido.Inativo, Pedido.DataPedido,Pedido.codobjeto , Pedido.Confirmado FROM (Pedido LEFT JOIN Clientes ON Pedido.C�digoCliente = Clientes.Codigo) LEFT JOIN Funcion�rios ON Pedido.C�digoFuncion�rio = Funcion�rios.C�digoFuncion�rio WHERE " & CampoFilter & " AND Pedido.Empresa = " & CodEmpresa & " ORDER BY Pedido.PedidoSequencia DESC;"
            Sql = "SELECT Pedido.PedidoSequencia, Pedido.Requisicao, Pedido.PedidoTipo, Funcion�rios.Nome AS NomeFunc, Clientes.Nome, Clientes.Cidade, Pedido.TotalPedido, Pedido.Empresa, Pedido.Inativo, Pedido.DataPedido, Pedido.Confirmado, objetoscad.placa, objetoscad.veiculo FROM ((Pedido LEFT JOIN Clientes ON Pedido.C�digoCliente = Clientes.Codigo) LEFT JOIN Funcion�rios ON Pedido.C�digoFuncion�rio = Funcion�rios.C�digoFuncion�rio) LEFT JOIN objetoscad ON Pedido.codobjeto = objetoscad.codobjeto   WHERE (((Pedido.Empresa) = " & CodEmpresa & ") And ((" & CampoFilter & ") <> False) and ((Pedido.C�digoCliente)>0)) ORDER BY Pedido.PedidoSequencia DESC;"


        End If


        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)

        da.Fill(DsProcura, "Table")

        Me.Lista.DataSource = DsProcura.Tables("Table").DefaultView

        da.Dispose()
        DsProcura.Dispose()
        Cnn.Close()

        For Each Linha As DataGridViewRow In Me.Lista.Rows
            If Linha.Cells("cConfirmado").Value = True Then
                Linha.Cells("Img").Value = Linha.Cells("ImgConf").Value
            End If
            If Linha.Cells("cConfirmado").Value = False Then
                Linha.Cells("Img").Value = Linha.Cells("ImgEdd").Value
            End If
            If Linha.Cells("cInativo").Value = True Then
                Linha.Cells("Img").Value = Linha.Cells("ImgCanc").Value
            End If
        Next

    End Sub

    Public Sub EncheListaItens()

        If Me.PedidoSequencia.Text = "" Then Exit Sub

        MyLista.Items.Clear()
        Dim CNN1 As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN1.Open()

        Dim Sql As String = "SELECT Produtos.Descri��o, Produtos.Tipo, * FROM ItensPedido INNER JOIN Produtos ON ItensPedido.CodigoProduto = Produtos.CodigoProduto WHERE ItensPedido.PedidoSequencia = " & Me.PedidoSequencia.Text & " Order by Produtos.Tipo"

        Dim Cmd As New OleDb.OleDbCommand(Sql, CNN1)
        Dim DataReader As OleDb.OleDbDataReader

        Try
            DataReader = Cmd.ExecuteReader

            SomaTotalProdutos = 0
            SomaTotalServicos = 0
            SomaDesconto = 0
            SomaIpi = 0
            Dim AddLinhaWhite As Boolean = False
            Dim Zebrar As Boolean = False

            While DataReader.Read
                If Not IsDBNull(DataReader.Item("Id")) Then

                    If AddLinhaWhite = False Then
                        If DataReader.Item("Tipo") = 99 Then
                            Dim LinhaBranco As New ListViewItem("", 0)
                            Dim LinhaBranco2 As New ListViewItem("", 0)
                            MyLista.Items.AddRange(New ListViewItem() {LinhaBranco})

                            LinhaBranco2.SubItems.Add("SERVI�OS")
                            MyLista.Items.AddRange(New ListViewItem() {LinhaBranco2})
                            MyLista.Items.Item(MyLista.Items.Count() - 1).BackColor = Color.DarkOrange
                            AddLinhaWhite = True
                        End If
                    End If


                    Dim AA As String = DataReader.Item("Id")
                    Dim item1 As New ListViewItem(AA, 0)

                    item1.SubItems.Add(DataReader.Item("ItensPedido.CodigoProduto") & "")
                    item1.SubItems.Add(DataReader.Item("Descri��o") & "")
                    item1.SubItems.Add(FormatNumber(DataReader.Item("Qtd"), 4))
                    item1.SubItems.Add(FormatNumber((Nz(DataReader.Item("Qtd"), 3) - Nz(DataReader.Item("QtdRetirada"), 3)), 4))
                    item1.SubItems.Add(FormatNumber(DataReader.Item("ValorUnitario"), 2))
                    item1.SubItems.Add(FormatNumber(DataReader.Item("ValorDesconto"), 2))
                    item1.SubItems.Add(FormatNumber(NzZero(DataReader.Item("TotalProduto")), 2))

                    MyLista.Items.AddRange(New ListViewItem() {item1})

                    If DataReader.Item("Tipo") <> 99 Then
                        If Zebrar = True Then
                            MyLista.Items.Item(MyLista.Items.Count() - 1).BackColor = Color.White
                            Zebrar = False
                        Else
                            MyLista.Items.Item(MyLista.Items.Count() - 1).BackColor = Color.MediumOrchid
                            Zebrar = True
                        End If
                    Else
                        MyLista.Items.Item(MyLista.Items.Count() - 1).BackColor = Color.SandyBrown
                    End If
                    'retirado para teste pois estava apresentando falha na grava��o em alguns pedidos n�o ficava correto valouglas)
                    'If DataReader.Item("Tipo") = 99 Then
                    '    SomaTotalServicos += CDbl(NzZero(DataReader.Item("TotalProduto")))
                    'Else
                    '    SomaTotalProdutos += CDbl(NzZero(DataReader.Item("TotalProduto")))
                    'End If
                    SomaTotalProdutos += CDbl(NzZero(DataReader.Item("TotalProduto")))

                    SomaDesconto += CDbl(NzZero(DataReader.Item("ValorDesconto")))
                    SomaIpi += CDbl(NzZero(DataReader.Item("ValorIpi")))

                End If

            End While

            If Me.VlrDescProduto.Text = "" Then Me.VlrDescProduto.Text = FormatNumber(0, 2)
            If DescontoEmLinha = False Then
                Me.ValorProduto.Text = FormatNumber(SomaTotalProdutos, 2)
                Me.ValorServicos.Text = FormatNumber(SomaTotalServicos, 2)
                'Me.VlrDescProduto.Text = FormatNumber(SomaDesconto, 2)
                Me.ValorIpiPedido.Text = FormatNumber(SomaIpi, 2)
                Me.TotalPedido.Text = FormatNumber((SomaTotalProdutos + SomaTotalServicos + SomaIpi) - NzZero(Me.VlrDescProduto.Text), 2)
                Me.TPedido.Text = FormatNumber((SomaTotalProdutos + SomaTotalServicos + SomaIpi) - NzZero(Me.VlrDescProduto.Text), 2)
            Else
                Me.ValorProduto.Text = FormatNumber(SomaTotalProdutos, 2)
                Me.ValorServicos.Text = FormatNumber(SomaTotalServicos, 2)
                Me.VlrDescProduto.Text = FormatNumber(SomaDesconto, 2)
                Me.ValorIpiPedido.Text = FormatNumber(SomaIpi, 2)
                Me.TotalPedido.Text = FormatNumber((SomaTotalProdutos + SomaTotalServicos + SomaIpi) - NzZero(Me.VlrDescProduto.Text), 2)
                'Me.TPedido.Text = FormatNumber((SomaTotalProdutos + SomaTotalServicos + SomaIpi) - NzZero(Me.VlrDescProduto.Text), 2)
            End If


            Dim VarMediaDesconto As Double = 0
            If NzZero(Me.TPedido.Text) > 0 Then
                VarMediaDesconto = (CDbl(NzZero(Me.VlrDescProduto.Text)) / (CDbl(NzZero(Me.TPedido.Text)) + CDbl(NzZero(Me.VlrDescProduto.Text)))) * 100
            End If
            Me.MediaDesconto.Text = FormatNumber(NzZero(VarMediaDesconto), 2)


            DataReader.Close()
            CNN1.Close()
            Me.MyLista.Refresh()
        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                'Cnn.Close()
                Exit Sub
            End If
        End Try
        'Cnn.Close()

    End Sub

    Public Sub EncheListaReceber()
        If Me.PedidoSequencia.Text = "" Then Exit Sub

        JaFoiGeradoReceber = False
        MyLista1.Items.Clear()

        Dim CNNListaReceber As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNNListaReceber.Open()

        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader

        With Cmd
            .Connection = CNNListaReceber
            .CommandTimeout = 0
            .CommandText = "SELECT  * FROM Receber WHERE Receber.Documento <> '" & Me.PedidoSequencia.Text & "-AVISTA' And Receber.Documento <> 'CHEQUE' AND Receber.PedidoProdutos = " & Me.PedidoSequencia.Text & " AND Receber.OriginalParcial = 'O' ORDER BY Receber.Vencimento"
            .CommandType = CommandType.Text
        End With

        Try
            DataReader = Cmd.ExecuteReader

            SomaDosParcelamentos = 0

            Dim Zebrar As Boolean = True

            While DataReader.Read
                If Not IsDBNull(DataReader.Item("Id")) Then
                    Dim AA As String = DataReader.Item("Id")
                    Dim item1 As New ListViewItem(AA, 0)

                    item1.SubItems.Add(DataReader.Item("Documento") & "")
                    item1.SubItems.Add(FormatNumber(DataReader.Item("ValorDocumento"), 2))
                    item1.SubItems.Add(DataReader.Item("Vencimento"))
                    item1.SubItems.Add(DataReader.Item("LocalPgto") & "")
                    item1.SubItems.Add(DataReader.Item("CodCliente") & "")
                    item1.SubItems.Add(DataReader.Item("ContaCorrente") & "")


                    MyLista1.Items.AddRange(New ListViewItem() {item1})

                    SomaDosParcelamentos += CDbl(DataReader.Item("ValorDocumento"))

                    If Zebrar = True Then
                        MyLista1.Items.Item(MyLista1.Items.Count() - 1).BackColor = Color.White
                        Zebrar = False
                    Else
                        MyLista1.Items.Item(MyLista1.Items.Count() - 1).BackColor = Color.MediumOrchid
                        Zebrar = True
                    End If
                    JaFoiGeradoReceber = True
                End If
            End While
            Me.TotalParcelamento.Text = FormatCurrency(SomaDosParcelamentos, 2)
            DataReader.Close()
            CNNListaReceber.Close()
            Me.MyLista1.Refresh()

            'instru��o inserida pelo beto  09072012
            If ParcFixo Then 'parcelamento fixo � true
                If (MyLista1.Items.Count > 0) Then 'tem linhas na lista
                    PainelParcelamentoFixo.Enabled = False 'desativa campo
                Else 'sen�o
                    PainelParcelamentoFixo.Enabled = True 'ativa campo
                End If
            Else 'sen�o parcelamento n�o � fixo
                If (MyLista1.Items.Count > 0) Then 'mas tem linha na lista
                    DiasParcelamento.Enabled = False 'desativa campo
                Else
                    DiasParcelamento.Enabled = True 'ativa campo
                End If 'fim se
            End If 'fim se


        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                CNNListaReceber.Close()
                Exit Sub
            End If
        End Try
    End Sub

    Public Sub EncheTPpedido()

        Dim ItemCombo As New ArrayList

        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader

        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "Select * from PedidoTipo"
            .CommandType = CommandType.Text
        End With

        Try
            DataReader = Cmd.ExecuteReader

            If DataReader.HasRows = True Then
                With ItemCombo
                    While DataReader.Read
                        If Not IsDBNull(DataReader.Item(0)) Then
                            .Add(DataReader.Item("PedidoTipo"))
                        End If
                    End While
                End With
            End If
            DataReader.Close()

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Exit Sub
            End If
        End Try

        Me.TpVenda.Items.Clear()
        With CType(Me.TpVenda, ComboBox)
            .DataSource = ItemCombo
        End With
        CType(Me.TpVenda, ComboBox).SelectedIndex = -1
        'fim inserir ultimo registro

    End Sub

    Private Sub ExcluirItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirItemToolStripMenuItem.Click
        If Me.Confirmado.Checked = True Then
            MsgBox("Este pedido j� foi confirmado, n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If JaFoiGeradoReceber = True Then
            MsgBox("Neste pedido n�o pode ser Excluido produto, pois ja foi gerado o contas a receber, exclua o contas receber para incluir novos produtos.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        RetornoProcura = ""
        Dim I As Integer = 0
        Dim Prod As String = ""

        For I = 0 To MyLista.Items.Count - 1
            If MyLista.Items(I).Selected = True Then RetornoProcura = (MyLista.Items(I).Text.Substring(0))
            If MyLista.Items(I).Selected = True Then Prod = MyLista.Items(I).SubItems(1).Text.Substring(0)
        Next

        If RetornoProcura = "" Then
            MsgBox("O usu�rio deve selecionar um item da lista.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "Delete * from ItensPedido where Id = " & RetornoProcura
        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader

        DR.Close()
        CNN.Close()


        ErroLivre = "Excluiu o intem de Produto da lista"
        GerarLog(Me.Text, A��oTP.Livre, Me.PedidoSequencia.Text)
        OperationItens = INS


        EncheListaItens()


    End Sub

    Private Sub ExcluirTodasParcelasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirTodasParcelasToolStripMenuItem.Click
        If Me.Confirmado.Checked = True Then
            MsgBox("Este pedido j� foi confirmado, n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "Delete * from Receber where PedidoProdutos = " & Me.PedidoSequencia.Text
        Dim CMD As New OleDb.OleDbCommand(Sql, Cnn)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader

        DR.Close()
        Cnn.Close()
        EncheListaReceber()

        If Me.MyLista1.Items.Count = 0 Then
            Me.chkReterImposto.Enabled = True
            Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.btClienteFind.Enabled = True
        End If

        If Me.DgvItem.Rows.Count > 0 Then
            Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.btClienteFind.Enabled = False
            Me.ParcelamentoFixo.Clear()
            Me.ParcelamentoFixoDesc.Clear()
            Me.PainelParcelamentoFixo.Enabled = False
        End If


        ErroLivre = "Excluiu todas as parcelas do Receber"
        GerarLog(Me.Text, A��oTP.Livre, Me.PedidoSequencia.Text)
        Me.Salvar.Focus()

    End Sub

    Private Sub ExcluirTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirTodosToolStripMenuItem.Click
        If Me.Confirmado.Checked = True Then
            MsgBox("Este pedido j� foi confirmado, n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If JaFoiGeradoReceber = True Then
            MsgBox("Neste pedido n�o pode ser Exclu�do o servi�o, pois ja foi gerado o contas a receber, exclua o contas receber para incluir novos servi�os.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "Delete * from ItemServico where PedidoSequencia = " & Me.PedidoSequencia.Text
        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader

        DR.Close()
        CNN.Close()

        ErroLivre = "Excluiu todos os servi�os da lista"
        GerarLog(Me.Text, A��oTP.Livre, Me.PedidoSequencia.Text)
        OperationItens = INS
        Me.atGridServico()


    End Sub

    Private Sub ExcluirTodosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirTodosToolStripMenuItem1.Click
        If Me.Confirmado.Checked = True Then
            MsgBox("Este pedido j� foi confirmado, n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If JaFoiGeradoReceber = True Then
            MsgBox("Neste pedido n�o pode ser Excluido produto, pois ja foi gerado o contas a receber, exclua o contas receber para incluir novos produtos.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "Delete * from ItensPedido where PedidoSequencia = " & Me.PedidoSequencia.Text
        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader

        DR.Close()
        CNN.Close()

        ErroLivre = "Excluiu todos os itens dos Produtos da lista"
        GerarLog(Me.Text, A��oTP.Livre, Me.PedidoSequencia.Text)

        OperationItens = INS
        EncheListaItens()
    End Sub

    Private Sub ExcluirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirToolStripMenuItem.Click
        If Me.Confirmado.Checked = True Then
            MsgBox("Este pedido j� foi confirmado, n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        RetornoProcura = ""
        Dim I As Integer = 0

        For I = 0 To MyLista1.Items.Count - 1
            If MyLista1.Items(I).Selected = True Then RetornoProcura = (MyLista1.Items(I).Text.Substring(0))
        Next

        If RetornoProcura = "" Then
            MsgBox("O usu�rio deve selecionar um item da lista.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "Delete * from Receber where Id = " & RetornoProcura
        Dim CMD As New OleDb.OleDbCommand(Sql, Cnn)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader

        DR.Close()
        Cnn.Close()
        EncheListaReceber()
        If Me.MyLista1.Items.Count = 0 Then
            Me.chkReterImposto.Enabled = True
            Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.btClienteFind.Enabled = True
        End If
        Me.Salvar.Focus()

    End Sub

    Private Sub Fechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fechar.Click
        If String.IsNullOrEmpty(C�digoCliente.Text) And NzZero(Me.PedidoSequencia.Text) > 0 Then
            MessageBox.Show("O Cliente n�o pode ser nulo", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.PainelProcuraPedido.Expanded = False
            Exit Sub
        Else
            salvarDadosClientes()
        End If
        If Not TpVenda.Text = "DEVOLU��O" Then
            If ParcFixo = True Then  '
                If Not Confirmado.Checked Then
                    If (MyLista1.Items.Count > 0 And (String.IsNullOrEmpty(ParcelamentoFixo.Text) Or ParcelamentoFixo.Text = "0")) Then
                        MessageBox.Show("Existem parcelas geradas, a forma de pagamento n�o pode ser nula", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub

                    Else  '
                    End If
                End If
            End If
        End If

        If PedidoEmAndamento = True Then
            If MsgBox("O usu�rio n�o finalizou este pedido, deseja fechar a tela de pedido mesmo assim ?", 36, "Valida��o de Dados") = 6 Then
                Me.Close()
                Me.Dispose()
            Else
                Exit Sub
            End If
        Else
            If NzZero(Me.PedidoSequencia.Text) > 0 And Me.Confirmado.Checked = False Then
                UpdatePED()
            End If
            CNN.Close()
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Public Sub GerarParcelamentos()

        CNN.Close()

        Dim ComissaoFaixaExecutar As Double = 0
        If TipoComissaoVenda = "porFAIXA" Then
            Dim CNNComissao As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNNComissao.Open()

            Dim SqlEMPRESA As String = "Select * From EmpresaComissaoFaixa Where Empresa = " & CodEmpresa
            Dim CmdEmpresaComissao As New OleDb.OleDbCommand(SqlEMPRESA, CNNComissao)

            Dim DrEmpresaComissao As OleDb.OleDbDataReader

            DrEmpresaComissao = CmdEmpresaComissao.ExecuteReader
            DrEmpresaComissao.Read()

            Dim media_DESCONTO As Double = FormatNumber(CDbl(NzZero(Me.MediaDesconto.Text)), 2)
            If DrEmpresaComissao.HasRows = True Then
                If media_DESCONTO <= DrEmpresaComissao.Item("pFaixa1") Then ComissaoFaixaExecutar = DrEmpresaComissao.Item("cFaixa1")
                If media_DESCONTO > DrEmpresaComissao.Item("pFaixa1") And NzZero(Me.MediaDesconto.Text) <= DrEmpresaComissao.Item("pFaixa2") Then ComissaoFaixaExecutar = CDbl(NzZero(DrEmpresaComissao.Item("cFaixa2")))
                If media_DESCONTO > DrEmpresaComissao.Item("pFaixa2") And NzZero(Me.MediaDesconto.Text) <= DrEmpresaComissao.Item("pFaixa3") Then ComissaoFaixaExecutar = CDbl(NzZero(DrEmpresaComissao.Item("cFaixa3")))
                If media_DESCONTO > DrEmpresaComissao.Item("pFaixa3") And NzZero(Me.MediaDesconto.Text) <= DrEmpresaComissao.Item("pFaixa4") Then ComissaoFaixaExecutar = CDbl(NzZero(DrEmpresaComissao.Item("cFaixa4")))
                If media_DESCONTO > DrEmpresaComissao.Item("pFaixa4") And NzZero(Me.MediaDesconto.Text) <= DrEmpresaComissao.Item("pFaixa5") Then ComissaoFaixaExecutar = CDbl(NzZero(DrEmpresaComissao.Item("cFaixa5")))
                If media_DESCONTO > DrEmpresaComissao.Item("pFaixa5") And NzZero(Me.MediaDesconto.Text) <= DrEmpresaComissao.Item("pFaixa6") Then ComissaoFaixaExecutar = CDbl(NzZero(DrEmpresaComissao.Item("cFaixa6")))
            End If
            CNNComissao.Close()
        End If



        If Me.ValorAFaturar.Text = "" Or Me.ValorAFaturar.Text = 0 Then
            Exit Sub
        End If

        If Me.DiasParcelamento.Text = "" Then
            Exit Sub
        End If

        'Pegar o total de Parcelamentos
        Dim Parcelas() As String = Split(Me.DiasParcelamento.Text, "-")
        Dim Contar As Integer
        Dim Dividido As Decimal


        Dim CNNReceber As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNNReceber.Open()

        Dim Ds As New DataSet

        Dim Sql As String = "SELECT * from Receber Where Id = -1"

        Dim DAReceber As New OleDb.OleDbDataAdapter(Sql, CNNReceber)
        DAReceber.Fill(Ds, "Receber")



        Dim VlrFat As Double = FormatNumber(Me.ValorAFaturar.Text, 2) 'recebe o valor a faturar
        If VlrMinFat > VlrFat Then
            If Parcelas.Length > 1 Then
                MessageBox.Show("O Valor a faturar n�o atingiu o valor m�nimo de faturamento, o Pedido deve ser Parcelado em 1 vez ou ser a vista.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ValorAVista.Focus()
                CNNReceber.Open()
                Exit Sub
            End If
        End If

        If Me.ParcelamentoFixoDesc.Text = "MENSAL" Then   'Gerar valor mensal
            Dim DrNew As DataRow
            DrNew = Ds.Tables("Receber").NewRow
            Dim Parc As String = Me.PedidoSequencia.Text & "-" & 1 & "/" & 1
            If Me.TpVenda.Text = "DEVOLU��O" Then Parc = "D" & Parc
            DrNew("Documento") = Parc
            DrNew("DataDocumento") = Me.DataPedido.Text
            DrNew("ValorDocumento") = CDbl(Me.ValorAFaturar.Text)
            DrNew("LocalPgto") = "CARTEIRA"
            DrNew("PedidoProdutos") = Me.PedidoSequencia.Text
            DrNew("CodCliente") = Me.C�digoCliente.Text
            DrNew("Cliente") = Me.NomeCliente.Text
            DrNew("Empresa") = CodEmpresa
            DrNew("OriginalParcial") = "O"
            DrNew("Vendedor") = Me.C�digoFuncion�rio.Text
            DrNew("Vencimento") = DateSerial(Year(DataDia), Month(DataDia) + 1, DiaFechamentoMensal) 'gera o vencimento  para o dia 10 de cada m�s.
            DrNew("MediaDescontoPedido") = NzZero(Me.MediaDesconto.Text)
            DrNew("PercentComissao") = ComissaoFaixaExecutar
            DrNew("ControlePedido") = Nz(Me.NumeroControle.Text, 1)
            If Me.TpVenda.Text = "DEVOLU��O" Then DrNew("Referencia") = "DEVOLU��O REALIZADA NO DIA " & DataDia & " USU�RIO " & UserAtivo
            DrNew("ContaValorBaixado") = Nz(CodLancamentoReceber, 1)
            DrNew("Virtual") = True
            Ds.Tables("Receber").Rows.Add(DrNew)

        Else 'caso contr�rio usa outro parcelamento
            Dividido = Me.ValorAFaturar.Text / Parcelas.Length
            For Contar = 1 To Parcelas.Length
                Dim DrNew As DataRow
                DrNew = Ds.Tables("Receber").NewRow
                Dim Parc As String = Me.PedidoSequencia.Text & "-" & Contar & "/" & Parcelas.Length
                If Me.TpVenda.Text = "DEVOLU��O" Then Parc = "D" & Parc
                DrNew("Documento") = Parc
                DrNew("DataDocumento") = Me.DataPedido.Text
                DrNew("ValorDocumento") = Dividido
                DrNew("LocalPgto") = "CARTEIRA"
                DrNew("PedidoProdutos") = Me.PedidoSequencia.Text
                DrNew("CodCliente") = Me.C�digoCliente.Text
                DrNew("Cliente") = Me.NomeCliente.Text
                DrNew("Empresa") = CodEmpresa
                DrNew("OriginalParcial") = "O"
                DrNew("Vendedor") = Me.C�digoFuncion�rio.Text
                DrNew("Vencimento") = DataDia.AddDays(CInt(Parcelas(Contar - 1)))
                DrNew("MediaDescontoPedido") = NzZero(Me.MediaDesconto.Text)
                DrNew("PercentComissao") = ComissaoFaixaExecutar
                DrNew("ControlePedido") = Nz(Me.NumeroControle.Text, 1)
                If Me.TpVenda.Text = "DEVOLU��O" Then DrNew("Referencia") = "DEVOLU��O REALIZADA NO DIA " & DataDia & " USU�RIO " & UserAtivo
                DrNew("ContaValorBaixado") = Nz(CodLancamentoReceber, 1)
                DrNew("Virtual") = True
                Ds.Tables("Receber").Rows.Add(DrNew)
            Next
        End If

        Dim objCommandBuilder As New OleDb.OleDbCommandBuilder(DAReceber) 'Usa a classe commandbuilder para criar os comandos de update,insert, delete
        DAReceber.Update(Ds, "Receber") 'faz uma Insert na tabela receber usando o commandbuilder.
        System.Threading.Thread.Sleep(1000) 'retarda 1s para a pr�xima execu��o
        EncheListaReceber() 'atualiza o grid de recebimentos

    End Sub

    Private Sub Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimir.Click

        If Me.TpVenda.Text = "" Then
            MsgBox("O usu�rio deve informar qual o tipo de venda.", 64, "Valida��o de Dados")
            Me.TpVenda.Focus()
            Exit Sub
        End If


        'se Diferente de consigna�ao testa alguns campos obrigatorios
        If Me.TpVenda.Text <> "CONSIGNA��O" Then

            If NzZero(Me.C�digoFuncion�rio.Text) = 0 Then
                MsgBox("O usu�rio deve selecionar um vendedor para o Pedido.", 64, "Valida��o de Dados")
                Me.C�digoFuncion�rio.Focus()
                Exit Sub
            End If

            If Me.TotalParcelamento.Text = "" Then Me.TotalParcelamento.Text = FormatCurrency(0, 2)

            If CDbl(Me.TotalParcelamento.Text) <> CDbl(Me.ValorAFaturar.Text) Then
                MsgBox("VERIFIQUE....O valor do parcelamento esta diferente do valor a faturar.", 64, "Valida��o de Dados")
                Me.ValorAFaturar.Focus()
                Exit Sub
            End If

            Dim SomaValores As Double = 0
            If Me.chkReterImposto.Checked = True Then
                SomaValores = CDbl(NzZero(Me.ValorAVista.Text)) + CDbl(NzZero(Me.ValorOutros.Text)) + CDbl(NzZero(Me.ValorAFaturar.Text)) + CDbl(NzZero(Me.Issqn.Text))
            Else
                SomaValores = CDbl(NzZero(Me.ValorAVista.Text)) + CDbl(NzZero(Me.ValorOutros.Text)) + CDbl(NzZero(Me.ValorAFaturar.Text))
            End If
            If FormatNumber(CDbl(NzZero(SomaValores)), 2) <> FormatNumber(CDbl(NzZero(Me.TPedido.Text)), 2) Then
                MsgBox("VERIFIQUE....O valor do Pedido esta diferente dos valores faturado.", 64, "Valida��o de Dados")
                Me.ValorAVista.Focus()
                Exit Sub
            End If
        End If
        'Fim das valida�oes se diferente de consigna�ao

        If Me.ValorIpiPedido.Text = "" Then Me.ValorIpiPedido.Text = FormatCurrency(SomaIpi, 2)
        If Me.VlrDescProduto.Text = "" Then Me.VlrDescProduto.Text = FormatCurrency(0, 2)
        If Me.ValorProduto.Text = "" Then Me.ValorProduto.Text = FormatCurrency(SomaTotalProdutos, 2)

        If DescontoEmLinha = True Then
            Me.VlrDescProduto.Text = FormatCurrency(SomaDesconto, 2)
            Me.TotalPedido.Text = FormatCurrency(CDbl(Me.ValorProduto.Text) + CDbl(Me.ValorIpiPedido.Text) - CDbl(Me.VlrDescProduto.Text), 2)

        Else
            Me.TotalPedido.Text = FormatCurrency(CDbl(Me.ValorProduto.Text) + CDbl(Me.ValorIpiPedido.Text) - CDbl(Me.VlrDescProduto.Text), 2)
        End If


        If Me.ValorAVista.Text = "" Then Me.ValorAVista.Text = FormatCurrency(0, 2)
        If Me.ValorOutros.Text = "" Then Me.ValorOutros.Text = FormatCurrency(0, 2)
        If Me.ValorAFaturar.Text = "" Then Me.ValorAFaturar.Text = FormatCurrency(0, 2)



        If Me.ValorAFaturar.Text <> 0 Then
            If Me.DiasParcelamento.Text = "" Then
                MsgBox("O usu�rio deve criar o parcelamento para o valor a ser faturado.", 64, "Valida��o de Dados")
                Me.DiasParcelamento.Focus()
                Exit Sub
            End If
        End If

        If Me.TipoEntrega.Text = "" Then
            MessageBox.Show("O usu�rio deve selecionar o tipo de entrega", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Me.TpVenda.Text = "" Then
            MessageBox.Show("O usu�rio deve selecionar o tipo de venda", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.C�digoCliente.Text) Then
            MessageBox.Show("Favor informar o Cliente", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        'Fim da Area destinada para as validacoes
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        If Me.Confirmado.Checked = False Then

            If Operation = UPD Then

                Dim Sql As String = "Update Pedido  Set C�digoCliente = @1, Propriedade = @2, DataPedido = @3, ObsCab = @4, ObsRod = @5, Empresa = @6, ValorProduto = @7, TotalPedido = @8, ValorAVista = @9, ValorOutros = @10, ValorAFaturar = @11, VlrDescProduto = @12, ValorIpiPedido = @13, DiasParcelamento = @14, C�digoFuncion�rio = @15, PedidoTipo = @16, StatusAndamentos = @17, FormaPgto = @18, TipoEntrega = @19, PercDesconto = @20, ValorServicos = @21, requisicao = @22, TotalPropostoPedido = @23, MediaDesconto = @24, codObjeto= @25, obsObjeto=@26, kmObjeto=@27,reterimposto=@28,issqn=@29,NfePecas=@30,NfeServico=@31  Where Pedido.PedidoSequencia = " & Me.PedidoSequencia.Text
                Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

                cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.C�digoCliente.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Propriedade.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.DataPedido.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.ObsCab.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.ObsRod.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@6", CodEmpresa))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@7", NzZero(Me.ValorProduto.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@8", NzZero(Me.TPedido.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@9", NzZero(Me.ValorAVista.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@10", NzZero(Me.ValorOutros.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@11", NzZero(Me.ValorAFaturar.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@12", NzZero(Me.VlrDescProduto.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@13", NzZero(Me.ValorIpiPedido.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@14", NzZero(Me.DiasParcelamento.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.C�digoFuncion�rio.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.TpVenda.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.StatusAndamentos.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.ParcelamentoFixo.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@19", Nz(Me.TipoEntrega.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@20", NzZero(Me.PercDesconto.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@21", NzZero(Me.ValorServicos.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@22", Nz(Me.NumeroControle.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@23", NzZero(Me.TotalPropostoPedido.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@24", NzZero(Me.MediaDesconto.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@25", Nz(Me.codigoObjeto.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@26", Nz(Me.obs.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@27", Nz(Me.km.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@28", Me.chkReterImposto.Checked))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@29", NzZero(Me.Issqn.Text)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@30", Nz(Me.txtNfePecas.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@31", Nz(Me.txtNfeServico.Text, 1)))

                Try
                    cmd.ExecuteNonQuery()
                    CNN.Close()
                    MsgBox("Registro Atualizado com sucesso", 64, "Valida��o de Dados")
                    Operation = UPD
                Catch ex As Exception
                    MsgBox(ex.Message, 64, "Valida��o de Dados")
                End Try
            End If
        End If

        If CNN.State = ConnectionState.Closed Then
            CNN.Open()
        End If

        'Dim oDA As New OleDb.OleDbDataAdapter("Select * from ObjetosCad where codobjeto=" & NzZero(Me.codigoObjeto.Text), CNN)
        'Dim oDs As New DataSet
        'oDA.Fill(oDs, "Obj")

        'Dim rpt As New OS
        'If oDs.Tables(0).Rows.Count > 0 Then
        '    rpt.txtVeiculo.Text = oDs.Tables(0).Rows(0).Item("veiculo")
        '    rpt.txtplaca.Text = oDs.Tables(0).Rows(0).Item("placa")
        'End If

        'ViewReport.VerRelat.Document = rpt.Document
        'rpt.Run()
        'ViewReport.ShowDialog()

        If bUsaPapelA4Pedido Then
            RelatorioCarregar = "RelPedidoOS.rpt"
            Dim SelectFormula As String = "{Pedido.PedidoSequencia} = " & Me.PedidoSequencia.Text & " and {Pedido.Empresa} = " & CodEmpresa

            'chama a classe e passa os parametros para o relatorio
            Dim f As New ClassView.cView
            f.frm(DirRelat & RelatorioCarregar, LocalBD & Nome_BD, SenhaBancoDados, SelectFormula)
        Else
            Dim rpt As New OSA5
            'rpt.Document.Printer.PrinterName = ""
            ViewReport.VerRelat.Document = rpt.Document
            rpt.Run()
            ViewReport.ShowDialog()
        End If
    End Sub

    Private Sub ImprimirPedidoRaz�oToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirPedidoRaz�oToolStripMenuItem.Click
        If Len(Me.PedidoSequencia.Text) = 0 Then
            MsgBox("N�o existe pedido criado", 48, "Valida��o de dados")
            Return
        End If
        Dim rpt As New OSA5
        'rpt.Document.Printer.PrinterName = ""
        ViewReport.VerRelat.Document = rpt.Document
        rpt.Run()
        ViewReport.ShowDialog()
    End Sub

    Private Sub Ipi_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Me.Ipi.Text = "" Then Me.Ipi.Text = FormatNumber(0, 2)
    End Sub

    Private Sub IrParaOParcelamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IrParaOParcelamentoToolStripMenuItem.Click
        Me.TabPedido.SelectedTab = Me.TabParcelamento
        Me.ValorProduto.Focus()
    End Sub

    Private Sub Lista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lista.CellDoubleClick

        If NzZero(Me.PedidoSequencia.Text) > 0 And Me.Confirmado.Checked = False Then
            UpdatePED()
        End If

        Dim vID As Integer
        vID = CInt(Me.Lista.CurrentRow.Cells("cPedido").Value)
        xLinha = Me.Lista.CurrentRow.Index

        RetornoProcura = vID

        If RetornoProcura = "" Then
            MsgBox("O usu�rio deve informar um iten da lista de procura.", 64, "Valida��o de Dados")
            Exit Sub
        Else


            'Localizando os dados do pedido
            LocalizaDadosPedido()

            'Depois de localizar os dados eche a lista de itens
            EncheListaItens()

            'Aqui eche a lista de receber se existir
            EncheListaReceber()
            If Me.MyLista1.Items.Count > 0 Then
                Me.chkReterImposto.Enabled = False
                Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.btClienteFind.Enabled = False
            Else
                Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.btClienteFind.Enabled = True
            End If
            atGridServico()
            ' ds.Tables(0).Clear()
            Me.PainelProcuraPedido.Expanded = False

            Me.PedidoSequencia.Focus()
            Operation = UPD
            Me.TabPedido.SelectedTab = Me.TabCliente
            AchaObjeto()
            If Me.Inativo.Checked = True Then
                Me.TabControlPanel1.Enabled = False
                Me.TabControlPanel2.Enabled = False
                Me.TabControlPanel3.Enabled = False
                Me.TabControlPanel4.Enabled = False
                Me.TabControlPanel5.Enabled = False

                Me.Confirmar.Enabled = False
                Me.Editar.Enabled = False
                Me.Salvar.Enabled = False
                Me.Imprimir.Enabled = False


            Else
                Me.TabControlPanel1.Enabled = True
                Me.TabControlPanel2.Enabled = True
                Me.TabControlPanel3.Enabled = True
                Me.TabControlPanel4.Enabled = True
                Me.TabControlPanel5.Enabled = True

                Me.Confirmar.Enabled = True
                Me.Editar.Enabled = True
                Me.Salvar.Enabled = True
                Me.Imprimir.Enabled = True

            End If


        End If


    End Sub

    Private Sub Lista_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lista.Sorted
        For Each Linha As DataGridViewRow In Me.Lista.Rows
            If Linha.Cells("cConfirmado").Value = True Then
                Linha.Cells("Img").Value = Linha.Cells("ImgConf").Value
            End If
            If Linha.Cells("cConfirmado").Value = False Then
                Linha.Cells("Img").Value = Linha.Cells("ImgEdd").Value
            End If
            If Linha.Cells("cInativo").Value = True Then
                Linha.Cells("Img").Value = Linha.Cells("ImgCanc").Value
            End If
        Next
    End Sub

    Public Sub LocalizaDadosCliente()

        If Me.C�digoCliente.Text = "" Then
            Exit Sub
        End If
        Me.SaldoLimiteCredito.ForeColor = Color.Black

        If Me.Inativo.Checked Then
            Exit Sub
        End If

        Dim CnnFind As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CnnFind.Open()

        Dim Sql As String = "Select * from Clientes where Codigo = " & Me.C�digoCliente.Text
        Dim CMD As New OleDb.OleDbCommand(Sql, CnnFind)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then


            If DR.Item("Bloqueado") = True Then
                If Not Me.Confirmado.Checked Then
                    MessageBox.Show("Este cliente esta bloqueado, Favor verificar", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.C�digoCliente.Clear()
                    Me.NomeCliente.Clear()
                    Me.CpfCgc.Clear()
                    Me.Insc.Clear()
                    Me.Endere�o.Clear()
                    Me.Cidade.Clear()
                    Me.Estado.Clear()
                    Me.Cep.Clear()
                    Me.UsarLimite.Checked = False
                    Me.ClienteBloqueado.Checked = False
                    Me.LimiteCredito.Text = FormatNumber(0, 2)
                    Me.EmDebito.Text = FormatNumber(0, 2)
                    Me.SaldoLimiteCredito.Text = FormatNumber(0, 2)
                    Me.C�digoCliente.Focus()

                End If
            End If
            If IsDBNull(DR.Item("TpComercio")) Then
                MessageBox.Show("Este cliente esta sem o tipo de com�rcio, Favor verificar", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.C�digoCliente.Clear()
                Me.NomeCliente.Clear()
                Me.CpfCgc.Clear()
                Me.Insc.Clear()
                Me.Endere�o.Clear()
                Me.Cidade.Clear()
                Me.Estado.Clear()
                Me.Cep.Clear()
                Me.UsarLimite.Checked = False
                Me.ClienteBloqueado.Checked = False
                Me.LimiteCredito.Text = FormatNumber(0, 2)
                Me.EmDebito.Text = FormatNumber(0, 2)
                Me.SaldoLimiteCredito.Text = FormatNumber(0, 2)
                Me.C�digoCliente.Focus()
                Exit Sub
            End If

            Me.NomeCliente.Text = DR.Item("Nome") & ""
            Me.CpfCgc.Text = DR.Item("CpfCgc") & ""
            Me.Insc.Text = DR.Item("Insc") & ""
            Me.Endere�o.Text = DR.Item("Endere�o") & "" & " N� " & DR.Item("Nro") & ""
            Me.Cidade.Text = DR.Item("Cidade") & ""
            Me.Estado.Text = DR.Item("Estado") & ""
            Me.Cep.Text = DR.Item("Cep") & ""
            Me.chkSubstitutoTributario.Checked = DR.Item("UsaSubstitucaoTributaria")
            Me.UsarLimite.Checked = DR.Item("UsarLimite")
            Me.ClienteBloqueado.Checked = DR.Item("Bloqueado")
            Me.LimiteCredito.Text = FormatNumber(Nz(DR.Item("LimiteMensal"), 3), 2)
            Me.TpComercio.Text = DR.Item("TpComercio") & ""
            Me.txtCelular.Text = DR.Item("Celular") & ""
            Me.txtTelefone.Text = DR.Item("Telefone") & ""
            Me.txttelefone1.Text = DR.Item("telefone1") & ""
            If Me.C�digoFuncion�rio.Text = "" Then
                Me.C�digoFuncion�rio.Text = DR.Item("Vendedor") & ""
                AchaFuncionario()
            End If
        Else
            MessageBox.Show("Cliente n�o localizado, Verifique.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.C�digoCliente.Clear()
            Me.NomeCliente.Clear()
            Me.CpfCgc.Clear()
            Me.Insc.Clear()
            Me.Endere�o.Clear()
            Me.Cidade.Clear()
            Me.Estado.Clear()
            Me.Cep.Clear()
            Me.UsarLimite.Checked = False
            Me.ClienteBloqueado.Checked = False
            Me.LimiteCredito.Text = FormatNumber(0, 2)
            Me.EmDebito.Text = FormatNumber(0, 2)
            Me.SaldoLimiteCredito.Text = FormatNumber(0, 2)
            Me.C�digoCliente.Focus()
        End If

        DR.Close()
        CnnFind.Close()

        If UsarLimite.Checked = True Then
            VerDebitoCliente()
            Me.SaldoLimiteCredito.Text = FormatNumber(NzZero(Me.LimiteCredito.Text) - NzZero(Me.EmDebito.Text), 2)

            Dim PercentualGasto As Double = (NzZero(Me.SaldoLimiteCredito.Text) / NzZero(Me.LimiteCredito.Text)) * 100

            If PercentualGasto > 70 Then Me.SaldoLimiteCredito.ForeColor = Color.Green
            If PercentualGasto < 70 And PercentualGasto > 35 Then Me.SaldoLimiteCredito.ForeColor = Color.Blue
            If PercentualGasto < 35 Then Me.SaldoLimiteCredito.ForeColor = Color.Red

            If FormatNumber(Me.SaldoLimiteCredito.Text, 2) <= FormatNumber(0, 2) Then
                MessageBox.Show("Este cliente esta com limite de compra insuficiente para uma opera��o.", "Validador de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.C�digoCliente.Clear()
                Me.NomeCliente.Clear()
                Me.CpfCgc.Clear()
                Me.Insc.Clear()
                Me.Endere�o.Clear()
                Me.Cidade.Clear()
                Me.Estado.Clear()
                Me.Cep.Clear()
                Me.UsarLimite.Checked = False
                Me.ClienteBloqueado.Checked = False
                Me.LimiteCredito.Text = FormatNumber(0, 2)
                Me.EmDebito.Text = FormatNumber(0, 2)
                Me.SaldoLimiteCredito.Text = FormatNumber(0, 2)
                Me.C�digoCliente.Focus()
            End If

        Else
            Me.SaldoLimiteCredito.Text = FormatNumber(NzZero(0), 2)
        End If
        If Me.chkSubstitutoTributario.Checked = True Then
            Me.chkReterImposto.Visible = True

        Else
            Me.chkReterImposto.Visible = False
        End If
    End Sub

    Public Sub LocalizaDadosPedido()

        If RetornoProcura = "" Then
            Exit Sub
        End If

        'Limpar os dados em tela
        JaFoiGeradoReceber = False

        Me.TabPedido.SelectedTab = Me.TabCliente
        Me.NumeroControle.Clear()
        Me.StatusAndamentos.Clear()
        Me.PedidoSequencia.Clear()
        Me.C�digoCliente.Clear()
        Me.NomeCliente.Clear()
        Me.CpfCgc.Clear()
        Me.LimiteCredito.Clear()
        Me.EmDebito.Clear()
        Me.SaldoLimiteCredito.Clear()
        Me.txtNfeServico.Clear()
        Me.txtNfePecas.Clear()



        Me.Insc.Clear()
        Me.Endere�o.Clear()
        Me.Cidade.Clear()
        Me.Cep.Clear()
        Me.Estado.Clear()
        Me.ObsCab.Clear()
        Me.ObsRod.Clear()
        Me.Propriedade.Text = ""
        Me.propUf.Clear()
        Me.PropriedadeIncri��o.Clear()
        Me.DataPedido.Clear()
        Me.Confirmado.Checked = False
        Me.Inativo.Checked = False
        Me.chkReterImposto.Checked = False
        Me.chkSubstitutoTributario.Checked = False

        Me.MyLista.Items.Clear()

        Me.ValorProduto.Clear()
        Me.VlrDescProduto.Clear()
        Me.TotalPedido.Clear()
        Me.TPedido.Clear()
        Me.TotalPropostoPedido.Clear()
        Me.Issqn.Clear()
        SomaTotalProdutos = 0
        SomaDesconto = 0
        Me.Veiculo.Clear()
        Me.Placa.Clear()
        Me.obs.Clear()
        Me.km.Clear()


        Me.C�digoFuncion�rio.Text = ""
        Me.FuncionarioDesc.Clear()
        Me.ValorAVista.Clear()
        Me.ValorOutros.Clear()
        Me.ValorAFaturar.Clear()
        Me.DiasParcelamento.Clear()
        Me.ParcelamentoFixo.Clear()
        Me.ParcelamentoFixoDesc.Clear()
        Me.TotalParcelamento.Clear()
        Me.MyLista1.Items.Clear()
        Me.atGridServico()
        Me.ConfImg.Visible = False

        Me.TabControlPanel1.Enabled = True
        Me.TabControlPanel2.Enabled = True
        Me.TabControlPanel3.Enabled = True
        Me.TabControlPanel4.Enabled = True
        Me.TabControlPanel5.Enabled = True
        Me.chkReterImposto.Enabled = True


        Me.Confirmar.Enabled = True
        Me.Editar.Enabled = True
        Me.Salvar.Enabled = True
        Me.Imprimir.Enabled = True

        If Me.Confirmado.Checked = False Then
            Me.ConfImg.Visible = False
        Else
            Me.ConfImg.Visible = True
        End If

        Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.btClienteFind.Enabled = True

        'fim 


        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()


        Dim Sql As String = "SELECT Pedido.PedidoInterno, Pedido.PedidoSequencia, Pedido.PedidoTipo, Pedido.TipoEntrega, Pedido.Requisicao, Pedido.LimiteCredito, Pedido.C�digoFuncion�rio, Pedido.C�digoCliente, Pedido.Propriedade, Pedido.DataPedido, Pedido.PercDesconto, Pedido.VlrDescProduto, Pedido.ValorProduto, Pedido.TotalPedido, Pedido.TotalPropostoPedido, Pedido.ValorAVista, Pedido.ValorOutros, Pedido.ValorAFaturar, Pedido.DataFechamento, Pedido.NatOpera��o, Pedido.Empresa, Pedido.Inativo, Pedido.Confirmado, Pedido.ObsCab, Pedido.ObsRod, Pedido.FormaPgto, FormaPgto.Descri��o, Pedido.DiasParcelamento, Pedido.ImpressoPedido, Pedido.ValorIpiPedido, Pedido.InfBloqueio, Pedido.StatusAndamentos, Pedido.CodObjeto, Pedido.kmObjeto, Pedido.ObsObjeto,Pedido.issqn, Pedido.ReterImposto, Pedido.NfePecas, Pedido.NfeServico,Pedido.NFe,Pedido.ChaveNFe,Pedido.cStat,Pedido.xMotivo,Funcion�rios.Nome, Propriedades.NomePropriedade, Propriedades.Estado, Propriedades.Inscricao, CFOP.Descri��o, Clientes.CpfCgc, Clientes.Insc, Clientes.UsarLimite, Clientes.Nome, Clientes.Endere�o, Clientes.Nro, Clientes.Cidade, Clientes.Cep, Clientes.Estado,Clientes.UsaSubstitucaoTributaria, clientes.TpComercio FROM ((((Pedido LEFT JOIN Funcion�rios ON Pedido.C�digoFuncion�rio = Funcion�rios.C�digoFuncion�rio) LEFT JOIN Propriedades ON Pedido.Propriedade = Propriedades.Id) LEFT JOIN CFOP ON Pedido.NatOpera��o = CFOP.CFOP) LEFT JOIN Clientes ON Pedido.C�digoCliente = Clientes.Codigo) LEFT JOIN FormaPgto ON Pedido.FormaPgto = FormaPgto.CodFormaPgto WHERE (((Pedido.PedidoSequencia)=" & RetornoProcura & "));"

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        Me.TpVenda.Text = ""
        If DR.HasRows = True Then
            Me.PedidoSequencia.Text = DR.Item("PedidoSequencia") & ""
            PedidoInterno = DR.Item("PedidoInterno")
            Me.NumeroControle.Text = DR.Item("Requisicao") & ""
            Me.C�digoCliente.Text = DR.Item("C�digoCliente") & ""
            Me.DataPedido.Text = DR.Item("DataPedido") & ""
            Me.DataFechamento.Text = DR.Item("DataFechamento") & ""
            Me.ObsCab.Text = DR.Item("ObsCab") & ""
            Me.ObsRod.Text = DR.Item("ObsRod") & ""
            Me.Confirmado.Checked = DR.Item("Confirmado")
            Me.TpVenda.SelectedText = DR.Item("PedidoTipo") & ""
            Me.TpComercio.Text = DR.Item("TpComercio") & ""
            Me.TipoEntrega.SelectedIndex = Me.TipoEntrega.FindStringExact(DR.Item("TipoEntrega") & "")
            Me.codigoObjeto.Text = DR.Item("CodObjeto") & ""
            Me.ValorProduto.Text = FormatCurrency(Nz(DR.Item("ValorProduto"), 3), 2)
            Me.TotalPedido.Text = FormatCurrency(Nz(DR.Item("TotalPedido"), 3), 2)
            Me.TPedido.Text = FormatCurrency(Nz(DR.Item("TotalPedido"), 3), 2)
            Me.TotalPropostoPedido.Text = FormatCurrency(Nz(DR.Item("TotalPropostoPedido"), 3), 2)
            Me.ValorAVista.Text = FormatCurrency(Nz(DR.Item("ValorAVista"), 3), 2)
            Me.ValorOutros.Text = FormatCurrency(Nz(DR.Item("ValorOutros"), 3), 2)
            Me.ValorAFaturar.Text = FormatCurrency(Nz(DR.Item("ValorAFaturar"), 3), 2)
            Me.PercDesconto.Text = FormatCurrency(NzZero(DR.Item("PercDesconto")), 3)
            Me.VlrDescProduto.Text = FormatCurrency(NzZero(DR.Item("VlrDescProduto")), 2)

            Me.Issqn.Text = FormatCurrency(NzZero(DR.Item("issqn")))
            Me.chkReterImposto.Checked = DR.Item("reterimposto")
            Me.ParcelamentoFixo.Text = DR.Item("FormaPgto") & ""
            Me.ParcelamentoFixoDesc.Text = DR.Item("FormaPgto.Descri��o") & ""
            Me.DiasParcelamento.Text = DR.Item("DiasParcelamento") & ""
            Me.C�digoFuncion�rio.Text = DR.Item("C�digoFuncion�rio") & ""
            Me.FuncionarioDesc.Text = DR.Item("Funcion�rios.Nome") & ""
            strCombo2 = Me.TpVenda.Text
            Me.km.Text = DR.Item("kmobjeto") & ""
            Me.obs.Text = DR.Item("obsObjeto") & ""
            Me.Propriedade.Text = DR.Item("Propriedade") & ""
            Me.PropriedadeDesc.Text = DR.Item("NomePropriedade") & ""
            Me.propUf.Text = DR.Item("Propriedades.Estado") & ""
            Me.PropriedadeIncri��o.Text = DR.Item("Inscricao") & ""
            Me.txtNfePecas.Text = DR.Item("NfePecas") & ""
            Me.txtNfeServico.Text = DR.Item("NfeServico") & ""

            ' TipoVenda = DR.Item("TipoVenda") & ""

            Me.CpfCgc.Text = DR.Item("CpfCgc") & ""
            Me.chkSubstitutoTributario.Checked = IIf(Me.C�digoCliente.Text = "", False, DR.Item("UsaSubstitucaoTributaria"))
            Me.Insc.Text = DR.Item("Insc") & ""
            Me.NomeCliente.Text = DR.Item("Clientes.Nome") & ""
            Me.Endere�o.Text = DR.Item("Endere�o") & "" & " N� " & DR.Item("Nro") & ""
            Me.Cidade.Text = DR.Item("Cidade") & ""
            Me.Cep.Text = DR.Item("Cep") & ""
            Me.Estado.Text = DR.Item("Clientes.Estado") & ""
            Me.LimiteCredito.Text = FormatNumber(Nz(DR.Item("LimiteCredito"), 3), 2)
            ' Me.UsarLimite.Checked = DR.Item("UsarLimite")
            Me.StatusAndamentos.Text = Trim(DR.Item("StatusAndamentos") & "")
            Me.Inativo.Checked = DR.Item("Inativo")

            If Not String.IsNullOrEmpty(DR.Item("ChaveNFe") & "") Then
                Me.ChaveNFe.Text = "NFe: " & DR.Item("NFe") & " - " & DR.Item("ChaveNFe")
                Me.cState.Text = "Status: " & DR.Item("cStat") & " - " & DR.Item("xMotivo")
            Else
                Me.ChaveNFe.Text = ""
                Me.cState.Text = ""
            End If

            'LOCALIZANDO OS DADOS DO CLIENTE
            LocalizaDadosCliente()

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

        'EncheListaItens()
        If Me.Inativo.Checked = False Then

            If Me.Confirmado.Checked = False Then
                Me.PedidoSequencia.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.NomeCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.CpfCgc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.Insc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.Endere�o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.Cidade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.Cep.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.Estado.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.ObsCab.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.ObsRod.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.Propriedade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.propUF.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.PropriedadeIncri��o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.DataPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.TpVenda.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.N�o
                Me.TipoEntrega.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.N�o
                Me.VlrDescProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim

                If ParcFixo = True Then
                    Me.PainelParcelamentoFixo.Visible = True
                    Me.ParcelamentoFixo.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                    Me.ParcelamentoFixoDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                    Me.DiasParcelamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
                    Me.DiasParcelamento.Visible = False
                    LabelParcelamento.Visible = False
                Else
                    Me.PainelParcelamentoFixo.Visible = False
                    Me.DiasParcelamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                    Me.DiasParcelamento.Visible = True
                    LabelParcelamento.Visible = True
                End If

                Me.C�digoFuncion�rio.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.ValorAVista.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.ValorOutros.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.ValorAFaturar.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
                Me.btGerarParcelas.Enabled = True


                Operation = UPD
                Me.PedidoSequencia.Focus()

            End If
        End If

        If Me.chkSubstitutoTributario.Checked = True Then
            Me.chkReterImposto.Visible = True
            If Me.MyLista1.Items.Count > 0 Then
                Me.chkReterImposto.Enabled = False
            Else
                Me.chkReterImposto.Enabled = True
            End If
        Else
            Me.chkReterImposto.Visible = False
        End If
        DR.Close()

        If Me.Inativo.Checked Then
            Exit Sub
        End If

        If Not Me.Confirmado.Checked Then
            VerificaSaldoCreditoAtualizado()
        End If

    End Sub

    Public Sub LocalizaPedidoNovo()
        If Me.PedidoSequencia.Text = "" Then
            MsgBox("O usu�rio deve iniciar um novo pedido.", 64, "Valida��o de Dados")
            Exit Sub
        End If


        Dim Sql As String = "SELECT Pedido.*, Clientes.CpfCgc, Clientes.Insc, Clientes.Nome, Clientes.Endere�o, Clientes.Cidade, Clientes.Cep, Clientes.Estado, Pedido.PedidoSequencia, Pedido.StatusAndamentos FROM Pedido INNER JOIN Clientes ON Pedido.C�digoCliente = Clientes.Codigo WHERE (((Pedido.PedidoSequencia) = " & Me.PedidoSequencia.Text & "));"

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Me.C�digoCliente.Text = DR.Item("C�digoCliente") & ""
            PedidoInterno = DR.Item("PedidoInterno")
            Me.DataPedido.Text = DR.Item("DataPedido") & ""
            Me.ObsCab.Text = DR.Item("ObsCab") & ""
            Me.ObsRod.Text = DR.Item("ObsRod") & ""
            Me.Confirmado.Checked = DR.Item("Confirmado")

            Me.CpfCgc.Text = DR.Item("CpfCgc") & ""
            Me.Insc.Text = DR.Item("Insc") & ""
            Me.NomeCliente.Text = DR.Item("Nome") & ""
            Me.Endere�o.Text = DR.Item("Endere�o") & ""
            Me.Cidade.Text = DR.Item("Cidade") & ""
            Me.Cep.Text = DR.Item("Cep") & ""
            Me.Estado.Text = DR.Item("Estado") & ""
            Me.StatusAndamentos.Text = DR.Item("StatusAndamentos") & ""
        End If

        If Me.Confirmado.Checked = False Then
            Me.ConfImg.Visible = False
        Else
            Me.ConfImg.Visible = True
        End If

        DR.Close()
        Operation = UPD
        Me.PedidoSequencia.Focus()

        'CNN.Close()

    End Sub

    Private Sub MostrarTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarTodos.CheckedChanged
        If Me.MostrarTodos.Checked = True Then
            EncheGrid()
        End If
    End Sub

    Private Sub MyLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyLista.DoubleClick
        EditaItemToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub MyLista1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyLista1.DoubleClick
        If Me.Confirmado.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi confirmado n�o pode ser alterado as parcelas", 64, "Valida��o de Dados")
            Exit Sub
        End If

        RetornoProcura = ""
        Dim I As Integer = 0

        For I = 0 To MyLista1.Items.Count - 1
            If MyLista1.Items(I).Selected = True Then RetornoProcura = (MyLista1.Items(I).Text.Substring(0))
        Next

        If RetornoProcura = "" Then
            Exit Sub
        End If

        My.Forms.PedidoVendaEditReceber.ShowDialog()
        EncheListaReceber()
    End Sub

    Private Sub Novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Novo.Click
        If Not String.IsNullOrEmpty(Me.PedidoSequencia.Text) Then
            If String.IsNullOrEmpty(Me.C�digoCliente.Text) Then
                MessageBox.Show("O Cliente n�o pode ser nulo", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.C�digoCliente.Focus()
                Exit Sub

            End If
        End If




        If Not String.IsNullOrEmpty(PedidoSequencia.Text) Then
            Dim CnnNew As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CnnNew.Open()

            Dim cmdNew As New OleDb.OleDbCommand("Select C�digoCliente  FROM Pedido    WHERE PedidoSequencia=" & Me.PedidoSequencia.Text, CnnNew)
            Dim i As Integer = NzZero(cmdNew.ExecuteScalar)


            If i = 0 Then
                MessageBox.Show("Salve o pedido primeiro", "Valida��o", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Exit Sub


            End If




        End If

        'Limpar a Tela
        JaFoiGeradoReceber = False

        Me.TabPedido.SelectedTab = Me.TabCliente
        Me.NumeroControle.Clear()
        Me.StatusAndamentos.Clear()
        Me.PedidoSequencia.Clear()
        Me.C�digoCliente.Clear()
        Me.NomeCliente.Clear()
        Me.CpfCgc.Clear()
        Me.LimiteCredito.Clear()
        Me.EmDebito.Clear()
        Me.SaldoLimiteCredito.Clear()
        Me.txtNfePecas.Clear()
        Me.txtNfeServico.Clear()
        Me.ChaveNFe.Text = ""
        Me.cState.Text = ""



        Me.Insc.Clear()
        Me.Endere�o.Clear()
        Me.Cidade.Clear()
        Me.Cep.Clear()
        Me.Estado.Clear()
        Me.txtCelular.Clear()
        Me.txtTelefone.Clear()
        Me.txttelefone1.Clear()
        Me.ObsCab.Clear()
        Me.ObsRod.Clear()
        Me.Propriedade.Text = ""
        Me.propUF.Clear()
        Me.PropriedadeIncri��o.Clear()
        Me.DataPedido.Clear()
        Me.Confirmado.Checked = False
        Me.Inativo.Checked = False
        Me.chkReterImposto.Checked = False
        Me.chkSubstitutoTributario.Checked = False

        Me.MyLista.Items.Clear()

        Me.ValorProduto.Clear()
        Me.VlrDescProduto.Clear()
        Me.TotalPedido.Clear()
        Me.TPedido.Clear()
        Me.TotalPropostoPedido.Clear()
        Me.Issqn.Clear()
        SomaTotalProdutos = 0
        SomaDesconto = 0
        Me.codigoObjeto.Clear()
        Me.Veiculo.Clear()
        Me.Placa.Clear()
        Me.obs.Clear()
        Me.km.Clear()


        Me.C�digoFuncion�rio.Text = ""
        Me.FuncionarioDesc.Clear()
        Me.ValorAVista.Clear()
        Me.ValorOutros.Clear()
        Me.ValorAFaturar.Clear()
        Me.DiasParcelamento.Clear()
        Me.ParcelamentoFixo.Clear()
        Me.ParcelamentoFixoDesc.Clear()
        Me.TotalParcelamento.Clear()
        Me.MyLista1.Items.Clear()
        Me.atGridServico()
        Me.ConfImg.Visible = False

        Me.TabControlPanel1.Enabled = True
        Me.TabControlPanel2.Enabled = True
        Me.TabControlPanel3.Enabled = True
        Me.TabControlPanel4.Enabled = True
        Me.TabControlPanel5.Enabled = True
        Me.chkReterImposto.Enabled = True


        Me.Confirmar.Enabled = True
        Me.Editar.Enabled = True
        Me.Salvar.Enabled = True
        Me.Imprimir.Enabled = True

        If Me.Confirmado.Checked = False Then
            Me.ConfImg.Visible = False
        Else
            Me.ConfImg.Visible = True
        End If

        Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.btClienteFind.Enabled = True


        AchaUltimoPedido()

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Transacao As OleDb.OleDbTransaction = CNN.BeginTransaction()
        Dim Cmd As OleDb.OleDbCommand = CNN.CreateCommand

        Cmd.Transaction = Transacao

        Try

            Dim Sql As String = "INSERT INTO Pedido (PedidoSequencia, DataPedido, Empresa, ValorProduto, TotalPedido, ValorAVista, ValorOutros, ValorAFaturar, LimiteCredito, PedidoTipo, TipoEntrega, requisicao) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @requisicao)"
            Cmd.CommandText = Sql

            Cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.PedidoSequencia.Text, 1)))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.DataPedido.Text, 1)))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@3", CodEmpresa))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@4", 0))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@5", 0))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@6", 0))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@7", 0))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@8", 0))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@9", 0))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Me.TpVenda.Text))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@11", Me.TipoEntrega.Text))
            Cmd.Parameters.Add(New OleDb.OleDbParameter("@requisicao", Nz(Me.NumeroControle.Text, 1)))

            Cmd.ExecuteNonQuery()

            Transacao.Commit()
            CNN.Close()
        Catch ex As Exception
            Transacao.Rollback()
            CNN.Close()
            MessageBox.Show(ex.Message, "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.PedidoSequencia.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.NomeCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.CpfCgc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Insc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Endere�o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cidade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cep.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Estado.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ObsCab.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.ObsRod.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.Propriedade.Enabled = True
        Me.Propriedade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.propUF.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.PropriedadeIncri��o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.DataPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.TpVenda.Enabled = True
        Me.TpVenda.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.N�o
        Me.TipoEntrega.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.N�o

        Me.C�digoFuncion�rio.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.ValorAVista.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.ValorOutros.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.ValorAFaturar.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o

        If ParcFixo = True Then
            Me.PainelParcelamentoFixo.Visible = True
            Me.ParcelamentoFixo.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.DiasParcelamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.DiasParcelamento.Visible = False
            LabelParcelamento.Visible = False
        Else
            Me.PainelParcelamentoFixo.Visible = False
            Me.ParcelamentoFixo.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.DiasParcelamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.DiasParcelamento.Visible = True
            LabelParcelamento.Visible = True
        End If

        If DescontoEmLinha = False Then
            Me.PainelDesconto.Visible = True
            Me.PercDesconto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.VlrDescProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Else
            Me.PainelDesconto.Visible = False
            Me.PercDesconto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.VlrDescProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        End If

        CNN.Close()
        'MsgBox("Registro Atualizado com sucesso", 64, "Valida��o de Dados")
        ErroLivre = "Gerado um novo Pedido OS " & Me.PedidoSequencia.Text
        GerarLog(Me.Text, A��oTP.Livre, Me.PedidoSequencia.Text)

        Operation = UPD
        Me.TpVenda.Focus()

    End Sub

    Private Sub NovoItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovoItemToolStripMenuItem.Click
        btNovoItem_Click(sender, e)
        'If Me.Confirmado.Checked = True Then
        '    MsgBox("Este pedido j� foi confirmado, n�o pode ser alterado.", 64, "Valida��o de Dados")
        '    Exit Sub
        'End If

        'If JaFoiGeradoReceber = True Then
        '    MsgBox("Neste pedido n�o pode ser incluido produto, pois ja foi gerado o contas a receber, exclua o contas receber para incluir novos produtos.", 64, "Valida��o de Dados")
        '    Exit Sub
        'End If

        'OperationItens = INS

        'LimparItens()
        'Me.CodigoProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        'Me.CodigoProduto.Focus()
    End Sub

    Private Sub NovoServico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovoServico.Click
        If JaFoiGeradoReceber = True Then
            MsgBox("Neste pedido n�o pode ser inclu�do servi�os, pois ja foi gerado o contas a receber, exclua o contas receber para incluir novos servi�os.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If JaFoiGeradoReceber = True Then
            MsgBox("Para este pedido o parcelamento ja foi gerado. Verifique...", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.Inativo.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi Cancelado n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.C�digoCliente.Text) Then
            MessageBox.Show("Favor informar o Cliente", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If Me.Confirmado.Checked = True Then
            MsgBox("Este Pedido/OS j� foi confirmado n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        My.Forms.PedOSServicoAdd.ShowDialog()
        ctrlTabParcelamento()
    End Sub

    Private Sub NumeroControle_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumeroControle.Enter
        BloquearCabecalho()
    End Sub

    Private Sub ParcelamentoFixo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ParcelamentoFixo.KeyDown
        If e.KeyCode = Keys.F5 Then
            If Operation = UPD Then
                My.Forms.ProcuraFormaPgto.ShowDialog()
            End If
        End If

        If e.KeyCode = Keys.Enter Then
            If Me.ParcelamentoFixo.Text = "" Then
                Me.ParcelamentoFixo.Clear()
                Me.ParcelamentoFixoDesc.Clear()
                Me.DiasParcelamento.Clear()
            End If
        End If
    End Sub

    Private Sub ParcelamentoFixo_Leave(sender As Object, e As EventArgs) Handles ParcelamentoFixo.Leave
        If IsNumeric(ParcelamentoFixo.Text) Then
            If String.IsNullOrEmpty(ParcelamentoFixo.Text) Or ParcelamentoFixo.Text = 0 Then
                ParcelamentoFixo.Clear()
                DiasParcelamento.Clear()
            End If
        Else
            ParcelamentoFixo.Clear()
            DiasParcelamento.Clear()
        End If
    End Sub

    Private Sub ParcelamentoFixo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParcelamentoFixo.Validated
        If IsNumeric(ParcelamentoFixo.Text) Then
            AchaFormaPgto()
        End If
    End Sub

    Private Sub Pedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pedido.CheckedChanged, Cliente.CheckedChanged, controle.CheckedChanged, Data.CheckedChanged
        opt = DirectCast(sender, RadioButton).Name
        If opt = "Data" Then
            Me.TxtProcura.TpFormata��o = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Else
            Me.TxtProcura.TpFormata��o = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        End If
        Me.TxtProcura.Focus()
    End Sub

    Private Sub PedidoVenda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            btNovoItem_Click(sender, e)
        End If
        If e.KeyCode = Keys.F8 Then
            Me.TabPedido.SelectedTab = Me.TabParcelamento
            Me.C�digoFuncion�rio.Focus()
        End If

        If e.KeyCode = Keys.F9 Then
            Me.TabPedido.SelectedTab = Me.TabServico
            'PedOSServicoAdd.ShowDialog()
            NovoServico_Click(sender, e)
        End If

        If Me.PainelProcuraPedido.Expanded = True Then

            Select Case e.KeyCode
                Case Keys.F2
                    Me.Pedido.Checked = True
                    Me.TxtProcura.Focus()
                Case Keys.F3
                    Me.Cliente.Checked = True
                    Me.TxtProcura.Focus()
                Case Keys.F4
                    Me.controle.Checked = True
                    Me.TxtProcura.Focus()
                Case Keys.F5
                    Me.Data.Checked = True
                    Me.TxtProcura.Focus()
                Case Keys.F6
                    Me.EmAberto.Checked = True
                    Me.TxtProcura.Focus()
                Case Keys.F7
                    Me.MostrarTodos.Checked = True
                    Me.TxtProcura.Focus()
            End Select

        End If


    End Sub

    Private Sub PedidoVenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PainelProcuraPedido.Expanded = False
        Me.TabPedido.SelectedTab = Me.TabCliente
        Me.ConfImg.Visible = False
        Me.chkReterImposto.Enabled = False

        EncheLabelObjeto(Me)

        If ParcFixo = True Then
            Me.PainelParcelamentoFixo.Visible = True
            Me.DiasParcelamento.Visible = False
            LabelParcelamento.Visible = False
        Else
            Me.PainelParcelamentoFixo.Visible = False
            Me.DiasParcelamento.Visible = True
            LabelParcelamento.Visible = True
        End If

        CNN.Open() ' Abre Banco de dados

        If EntrarAchandoPedido = True Then
            EncheTPpedido()
            LocalizaDadosPedido()
            EncheListaItens()
            EncheListaReceber()
            Me.PedidoSequencia.Focus()
            Operation = UPD
        Else
            Operation = VAZ
        End If

        'Bloquear as caixa de entradas habilitando somente o botao novo
        Me.PedidoSequencia.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.C�digoCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.NomeCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.CpfCgc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Insc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Endere�o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cidade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cep.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Estado.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ObsCab.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ObsRod.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Propriedade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.propUf.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.PropriedadeIncri��o.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.DataPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim


        Me.ValorProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.VlrDescProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim

        Me.C�digoFuncion�rio.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ValorAVista.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ValorOutros.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ValorAFaturar.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.DiasParcelamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.TpVenda.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.TipoEntrega.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim

        If DescontoEmLinha = False Then
            Me.PainelDesconto.Visible = True
        Else
            Me.PainelDesconto.Visible = False
        End If

        'Fim dos controles bloqueados
        If EntrarAchandoPedido = False Then
            EncheTPpedido()
        End If
    End Sub

    Private Sub PercDesconto_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PercDesconto.Enter
        If DescontoEmLinha = False Then
            Me.PercDesconto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.VlrDescProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
            Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Else
            Me.PercDesconto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.VlrDescProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
            Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        End If
    End Sub

    Private Sub PercDesconto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PercDesconto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.VlrDescProduto.Focus()
        End If
    End Sub

    Private Sub PercDesconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PercDesconto.Leave
        If DescontoEmLinha = False Then
            Me.VlrDescProduto.Text = FormatCurrency((CDbl(NzZero(Me.ValorProduto.Text))) * FormatNumber(CDbl(NzZero(Me.PercDesconto.Text)), 3) / 100, 2)
            Me.TotalPedido.Text = FormatCurrency(CDbl(NzZero(Me.ValorProduto.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)) - CDbl(NzZero(Me.VlrDescProduto.Text)), 2)
            Me.TPedido.Text = FormatCurrency(CDbl(NzZero(Me.ValorProduto.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)) - CDbl(NzZero(Me.VlrDescProduto.Text)), 2)
            Me.VlrDescProduto.Focus()
        End If
    End Sub

    Private Sub Propriedade_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Propriedade.KeyDown

        If e.KeyCode = Keys.F5 Then
            If Operation = VAZ Then
                MessageBox.Show("O usu�rio n�o inicializou um Pedido para procurar o cliente, Verifique", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Me.PropriedadeDesc.Clear()
            Me.propUf.Clear()
            Me.PropriedadeIncri��o.Clear()

            My.Forms.ProcuraPropriedades.ShowDialog()
            AchaPropriedade()
            Me.Propriedade.Focus()
        End If

        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrEmpty(Propriedade.Text) Then
                Me.PropriedadeDesc.Clear()
                Me.propUf.Clear()
                Me.PropriedadeIncri��o.Clear()
                Me.TabPedido.SelectedTab = Me.TabItemPedido
                Me.VlrDescProduto.Focus()
            End If
        End If

    End Sub


    Private Sub Salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salvar.Click

        If Me.TotalParcelamento.Text = "" Then FormatNumber(0, 2)

        If Me.Inativo.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi Cancelado n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If
        If Me.Confirmado.Checked = True Then
            MsgBox("Este Pedido/Venda j� foi confirmado n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If


        If DescontoEmLinha = True Then
            Me.VlrDescProduto.Text = FormatCurrency(SomaDesconto, 2)
            Me.TotalPedido.Text = FormatCurrency(CDbl(NzZero(Me.ValorProduto.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)) - CDbl(NzZero(Me.VlrDescProduto.Text)), 2)

            'Me.TotalPedido.Text = FormatCurrency(CDbl(NzZero(Me.ValorProduto.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)))
        Else
            Me.TotalPedido.Text = FormatCurrency(CDbl(NzZero(Me.ValorProduto.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)) - CDbl(NzZero(Me.VlrDescProduto.Text)), 2)
        End If

        If Me.VlrDescProduto.Text = "" Then Me.VlrDescProduto.Text = FormatCurrency(0, 2)
        Me.ValorIpiPedido.Text = FormatCurrency(NzZero(SomaIpi), 2)
        Me.ValorProduto.Text = FormatCurrency(NzZero(SomaTotalProdutos), 2)


        If Me.ValorAVista.Text = "" Then Me.ValorAVista.Text = FormatCurrency(0, 2)
        If Me.ValorOutros.Text = "" Then Me.ValorOutros.Text = FormatCurrency(0, 2)
        If Me.ValorAFaturar.Text = "" Then Me.ValorAFaturar.Text = FormatCurrency(0, 2)



        If Me.TpVenda.Text <> "CONSIGNA��O" Then
            If Me.C�digoFuncion�rio.Text = "" Then
                MsgBox("O usu�rio deve selecionar um vendedor para o Pedido.", 64, "Valida��o de Dados")
                Me.C�digoFuncion�rio.Focus()
                Exit Sub
            End If
        End If

        If CDbl(NzZero(Me.ValorAFaturar.Text)) <> 0 Then
            If Me.DiasParcelamento.Text = "" Then
                MsgBox("O usu�rio deve criar o parcelamento para o valor a ser faturado.", 64, "Valida��o de Dados")
                Me.DiasParcelamento.Focus()
                Exit Sub
            End If
        End If

        If Me.UsarLimite.Checked = True Then
            Dim VlrFaturar As Double = FormatNumber(NzZero(Me.ValorAFaturar.Text), 2)
            Dim VlrLimite As Double = FormatNumber(Me.LimiteCredito.Text, 2)
            If VlrFaturar > VlrLimite Then
                MsgBox("Este Cliente esta sendo controlado por limite de Cr�dito, Limite ultrapassado, Verifique.", 64, "Valida��o de Dados")
                Exit Sub
            End If
        End If

        If Me.TpVenda.Text = "" Then
            MsgBox("O usu�rio deve informar qual o tipo de venda.", 64, "Valida��o de Dados")
            Me.TpVenda.Focus()
            Exit Sub
        End If

        If Me.StatusAndamentos.Text = "" Then Me.StatusAndamentos.Text = "INICIAL"

        If Me.TotalPropostoPedido.Text = "" Then Me.TotalPropostoPedido.Text = FormatNumber(0, 2)

        If NzZero(Me.TotalPropostoPedido.Text) = 0 Then
            Me.TotalPropostoPedido.Text = FormatNumber(NzZero(Me.TPedido.Text), 2)
        End If

        If String.IsNullOrEmpty(Me.C�digoCliente.Text) Then
            MessageBox.Show("Favor informar o Cliente", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If



        'Fim da Area destinada para as validacoes

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        If Operation = UPD Then

            Dim Sql As String = "Update Pedido  Set C�digoCliente = @1, Propriedade = @2, DataPedido = @3, ObsCab = @4, ObsRod = @5, Empresa = @6, ValorProduto = @7, TotalPedido = @8, ValorAVista = @9, ValorOutros = @10, ValorAFaturar = @11, VlrDescProduto = @12, ValorIpiPedido = @13, DiasParcelamento = @14, C�digoFuncion�rio = @15, PedidoTipo = @16, StatusAndamentos = @17, FormaPgto = @18, TipoEntrega = @19, PercDesconto = @20, ValorServicos = @21, requisicao = @22, TotalPropostoPedido = @23, MediaDesconto = @24, codObjeto= @25, obsObjeto=@26, kmObjeto=@27,reterimposto=@28,issqn=@29,NfePecas=@30,NfeServico=@31  Where Pedido.PedidoSequencia = " & Me.PedidoSequencia.Text
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.C�digoCliente.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", NzZero(Me.Propriedade.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.DataPedido.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.ObsCab.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.ObsRod.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", CodEmpresa))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", NzZero(Me.ValorProduto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", NzZero(Me.TPedido.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", NzZero(Me.ValorAVista.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", NzZero(Me.ValorOutros.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", NzZero(Me.ValorAFaturar.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", NzZero(Me.VlrDescProduto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@13", NzZero(Me.ValorIpiPedido.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", NzZero(Me.DiasParcelamento.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.C�digoFuncion�rio.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.TpVenda.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.StatusAndamentos.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.ParcelamentoFixo.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", Nz(Me.TipoEntrega.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@20", NzZero(Me.PercDesconto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@21", NzZero(Me.ValorServicos.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@22", Nz(Me.NumeroControle.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@23", NzZero(Me.TotalPropostoPedido.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@24", NzZero(Me.MediaDesconto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@25", Nz(Me.codigoObjeto.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@26", Nz(Me.obs.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@27", Nz(Me.km.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@28", Me.chkReterImposto.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@29", NzZero(Me.Issqn.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@30", Nz(Me.txtNfePecas.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@31", Nz(Me.txtNfeServico.Text, 1)))

            Try
                cmd.ExecuteNonQuery()
                CNN.Close()
                MsgBox("Registro Atualizado com sucesso", 64, "Valida��o de Dados")
                ErroLivre = ""
                GerarLog(Me.Text, A��oTP.Editou, Me.PedidoSequencia.Text)
                Operation = UPD
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Valida��o de Dados")
            End Try
        End If

    End Sub

    Private Sub TabItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabServico.Click
        Me.ValorServicos.Text = FormatCurrency(SomaTotalServico, 2)
    End Sub

    Private Sub TabParcelamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabParcelamento.Click
        ctrlTabParcelamento()
        Me.C�digoFuncion�rio.Focus()
    End Sub

    Private Sub TipoEntrega_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoEntrega.Enter
        strCombo1 = Me.TipoEntrega.SelectedItem
        BloquearCabecalho()
    End Sub

    Private Sub TipoEntrega_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TipoEntrega.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim tab As DevComponents.DotNetBar.TabItem = Me.TabCliente
            Me.TabPedido.SelectedTab = tab


            'Me.C�digoCliente.Focus()
        End If
    End Sub

    Private Sub TipoEntrega_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoEntrega.SelectedValueChanged
        If Me.MyLista.Items.Count <> 0 Then
            Me.TipoEntrega.Text = strCombo1
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        NovoServico_Click(sender, e)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        If Me.Confirmado.Checked = True Then
            MsgBox("Este pedido j� foi confirmado, n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If JaFoiGeradoReceber = True Then
            MsgBox("Neste pedido n�o pode ser Editado o servi�o, pois j� foi gerado o contas a receber, exclua o contas receber para incluir novos servi�os.", 64, "Valida��o de Dados")
            Exit Sub
        End If


        My.Forms.PedOSServicoAdd.OperationItens = UPD
        My.Forms.PedOSServicoAdd.IdLinha = IdServico
        PedOSServicoAdd.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If Me.Confirmado.Checked = True Then
            MsgBox("Este pedido j� foi confirmado, n�o pode ser alterado.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If JaFoiGeradoReceber = True Then
            MsgBox("Neste pedido n�o pode ser Exclu�do o servi�o, pois ja foi gerado o contas a receber, exclua o contas receber para incluir novos servi�os.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "Delete * from ItemServico where Id = " & IdServico
        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader

        DR.Close()
        CNN.Close()

        ErroLivre = "Excluiu um item de servi�os da lista"
        GerarLog(Me.Text, A��oTP.Livre, Me.PedidoSequencia.Text)

        OperationItens = INS
        Me.atGridServico()
    End Sub
    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click


        If Len(Me.PedidoSequencia.Text) = 0 Then
            MsgBox("N�o existe pedido criado", 48, "Valida��o de dados")
            Return
        End If



        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()
        Dim oDA As New OleDb.OleDbDataAdapter("Select * from ObjetosCad where codobjeto=" & NzZero(Me.codigoObjeto.Text), CNN)
        Dim oDs As New DataSet
        oDA.Fill(oDs, "Obj")

        Dim rpt As New OSLiquido
        If oDs.Tables(0).Rows.Count > 0 Then
            rpt.txtVeiculo.Text = oDs.Tables(0).Rows(0).Item("veiculo")
            rpt.txtplaca.Text = oDs.Tables(0).Rows(0).Item("placa")
        End If

        ViewReport.VerRelat.Document = rpt.Document
        rpt.Run()
        ViewReport.ShowDialog()
    End Sub
    Private Sub TotalPedido_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TotalPedido.Validated
        If Me.VlrDescProduto.Text = "" Then Me.VlrDescProduto.Text = FormatCurrency(CDbl(0), 2)

        If DescontoEmLinha = False Then
            Me.VlrDescProduto.Text = FormatCurrency((CDbl(Me.ValorProduto.Text) + CDbl(Me.ValorIpiPedido.Text) - CDbl(Me.TotalPedido.Text)), 2)
        End If

    End Sub
    Private Sub TotalPropostoPedido_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalPropostoPedido.Enter
        If Me.TotalPropostoPedido.Text = "" Then
            Me.TotalPropostoPedido.Text = FormatNumber(NzZero(Me.TPedido.Text), 2)
        End If
    End Sub
    Private Sub TpVenda_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpVenda.Enter
        strCombo2 = TpVenda.Text
        BloquearCabecalho()
    End Sub

    Private Sub TpVenda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpVenda.SelectedIndexChanged
        If Me.MyLista.Items.Count <> 0 Then
            Me.TpVenda.Text = strCombo2
            Exit Sub
        End If


        If Me.TpVenda.Text = "CONSIGNA��O" Then
            Me.C�digoFuncion�rio.Enabled = False
            Me.FuncionarioDesc.Enabled = False
            Me.btFindVendedor.Enabled = False
            Me.ValorAVista.Enabled = False
            Me.ValorOutros.Enabled = False
            Me.ValorAFaturar.Enabled = False
            Me.ParcelamentoFixo.Enabled = False
            Me.ParcelamentoFixoDesc.Enabled = False
            Me.btFindParcelamentoFixo.Enabled = False
            Me.DiasParcelamento.Enabled = False
            Me.btGerarParcelas.Enabled = False
        Else
            Me.C�digoFuncion�rio.Enabled = True
            Me.FuncionarioDesc.Enabled = True
            Me.btFindVendedor.Enabled = True
            Me.ValorAVista.Enabled = True
            Me.ValorOutros.Enabled = True
            Me.ValorAFaturar.Enabled = True
            Me.ParcelamentoFixo.Enabled = True
            Me.ParcelamentoFixoDesc.Enabled = True
            Me.btFindParcelamentoFixo.Enabled = True
            Me.DiasParcelamento.Enabled = True
            Me.btGerarParcelas.Enabled = True
        End If

        If Me.TpVenda.Text = "DEVOLU��O" Then
            Me.ValorAVista.Enabled = False
            Me.ValorOutros.Enabled = False
            Me.ParcelamentoFixo.Enabled = False
            Me.ParcelamentoFixoDesc.Enabled = False
            Me.btFindParcelamentoFixo.Enabled = False
            Me.DiasParcelamento.Enabled = False
            Me.DiasParcelamento.Text = "005"
            Me.TipoEntrega.SelectedValue = "IMEDIATA"
            Me.TipoEntrega.Enabled = False
            Me.ValorAVista.Text = FormatNumber(0, 2)
            Me.ValorOutros.Text = FormatNumber(0, 2)
        Else
            Me.ValorAVista.Enabled = True
            Me.ValorOutros.Enabled = True
            Me.ParcelamentoFixo.Enabled = True
            Me.ParcelamentoFixoDesc.Enabled = True
            Me.btFindParcelamentoFixo.Enabled = True
            Me.DiasParcelamento.Enabled = True
            Me.DiasParcelamento.Clear()
            Me.TipoEntrega.Enabled = True
        End If

    End Sub

    Private Sub TpVenda_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpVenda.SelectedValueChanged
        If Me.MyLista.Items.Count <> 0 Then
            Me.TpVenda.Text = strCombo2
        End If
    End Sub

    Private Sub TxtProcura_Enter(sender As Object, e As EventArgs) Handles TxtProcura.Enter
        Me.TxtProcura.Clear()
    End Sub

    Sub UpdatePED()

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        If Operation = UPD Then

            Dim Sql As String = "Update Pedido  Set C�digoCliente = @1, Propriedade = @2, DataPedido = @3, ObsCab = @4, ObsRod = @5, Empresa = @6, ValorProduto = @7, TotalPedido = @8, ValorAVista = @9, ValorOutros = @10, ValorAFaturar = @11, VlrDescProduto = @12, ValorIpiPedido = @13, DiasParcelamento = @14, C�digoFuncion�rio = @15, PedidoTipo = @16, StatusAndamentos = @17, FormaPgto = @18, TipoEntrega = @19, PercDesconto = @20, ValorServicos = @21, requisicao = @22, TotalPropostoPedido = @23, MediaDesconto = @24, codObjeto= @25, obsObjeto=@26, kmObjeto=@27,ReterImposto=@28,issqn=@29,NfePecas=@30,NfeServico=@31 Where Pedido.PedidoSequencia = " & Me.PedidoSequencia.Text
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.C�digoCliente.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Propriedade.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.DataPedido.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.ObsCab.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.ObsRod.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", CodEmpresa))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", NzZero(Me.ValorProduto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", NzZero(Me.TPedido.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", NzZero(Me.ValorAVista.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", NzZero(Me.ValorOutros.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", NzZero(Me.ValorAFaturar.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", NzZero(Me.VlrDescProduto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@13", NzZero(Me.ValorIpiPedido.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", NzZero(Me.DiasParcelamento.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.C�digoFuncion�rio.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.TpVenda.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.StatusAndamentos.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.ParcelamentoFixo.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", Nz(Me.TipoEntrega.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@20", NzZero(Me.PercDesconto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@21", NzZero(Me.ValorServicos.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@22", Nz(Me.NumeroControle.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@23", NzZero(Me.TotalPropostoPedido.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@24", NzZero(Me.MediaDesconto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@25", Nz(Me.codigoObjeto.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@26", Nz(Me.obs.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@27", Nz(Me.km.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@28", Me.chkReterImposto.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@29", NzZero(Me.Issqn.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@30", Nz(Me.txtNfePecas.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@31", Nz(Me.txtNfeServico.Text, 1)))

            Try
                cmd.ExecuteNonQuery()
                CNN.Close()
                Operation = UPD
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Valida��o de Dados")
            End Try
        End If
    End Sub
    Private Sub ValorAFaturar_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValorAFaturar.Leave
        'If Me.chkReterImposto.Checked = True Then
        '    Me.ValorAFaturar.Text = FormatCurrency(CDbl(NzZero(Me.TPedido.Text)) - CDbl(NzZero(Me.ValorAVista.Text)) - CDbl(NzZero(Me.ValorOutros.Text)) - CDbl(NzZero(Me.Issqn.Text)), 2)
        'Else
        '    Me.ValorAFaturar.Text = FormatCurrency(CDbl(NzZero(Me.TPedido.Text)) - CDbl(NzZero(Me.ValorAVista.Text)) - CDbl(NzZero(Me.ValorOutros.Text)), 2)
        'End If
        Me.ValorAFaturar.Text = FormatCurrency(NzZero(Me.ValorAFaturar.Text), 2)

        If NzZero(Me.ValorAFaturar.Text) = 0 Then
            Me.PainelParcelamentoFixo.Enabled = False
            Me.DiasParcelamento.Enabled = False
            Me.ParcelamentoFixo.Text = 0
        Else
            If MyLista1.Items.Count = 0 Then
                Me.PainelParcelamentoFixo.Enabled = True
                Me.DiasParcelamento.Enabled = True
                If String.IsNullOrEmpty(ParcelamentoFixo.Text) Then
                    Me.ParcelamentoFixo.Text = 0
                End If
                Me.ParcelamentoFixo.Focus()

            End If
        End If
        If DiasParcelamento.Visible Then
            DiasParcelamento.Focus()
        End If

    End Sub
    Private Sub ValorIpi_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Me.Ipi.Text = "" Then Me.Ipi.Text = FormatNumber(0, 2)
        'Me.ValorIpi.Text = FormatNumber(CDbl(Me.TotalProduto.Text) * CDbl(Me.Ipi.Text) / 100, 2)
    End Sub
    Private Sub ValorOutros_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValorOutros.Enter
        If Me.chkReterImposto.Checked Then
            Me.ValorOutros.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Else
            Me.ValorOutros.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        End If
        If Me.ValorOutros.Text = "" Then Me.ValorOutros.Text = FormatCurrency(0, 2)
    End Sub
    Private Sub ValorOutros_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValorOutros.Leave

        If (CDbl(Me.ValorAVista.Text) + CDbl(Me.ValorOutros.Text) > TPedido.Text) Then
            ValorOutros.Text = 0
        End If


        If Me.chkReterImposto.Checked = True Then
            Me.ValorAFaturar.Text = FormatCurrency(CDbl(NzZero(Me.TPedido.Text)) - CDbl(NzZero(Me.ValorAVista.Text)) - CDbl(NzZero(Me.ValorOutros.Text)) - CDbl(NzZero(Me.Issqn.Text)), 2)
            Me.ValorAFaturar.Text = FormatCurrency(NzZero(Me.ValorAFaturar.Text), 2)
            If CDbl(Me.ValorAFaturar.Text) < 0 Then
                Me.ValorAFaturar.Text = 0
            End If
        Else
            Me.ValorAFaturar.Text = FormatCurrency(CDbl(NzZero(Me.TPedido.Text)) - CDbl(NzZero(Me.ValorAVista.Text)) - CDbl(NzZero(Me.ValorOutros.Text)), 2)
        End If
        Me.ValorOutros.Text = FormatCurrency(Me.ValorOutros.Text, 2)
    End Sub
    Private Sub VerDebitoCliente()
        If Me.C�digoCliente.Text = "" Then
            Exit Sub
        End If

        Dim CnnFind As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CnnFind.Open()

        Dim Sql As String = "SELECT Receber.CodCliente, Sum(Receber.ValorDocumento) AS SomaDeValorDocumento FROM(Receber) WHERE(((Receber.Recebimento) Is Null) And ((Receber.Baixado) = False) And ((Receber.Inativo) = False) And ((Receber.Empresa) = " & CodEmpresa & ")) GROUP BY Receber.CodCliente HAVING (((Receber.CodCliente)=" & Me.C�digoCliente.Text & "));"
        Dim CMD As New OleDb.OleDbCommand(Sql, CnnFind)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Me.EmDebito.Text = FormatNumber(NzZero(DR.Item("SomaDeValorDocumento")), 2)
        Else
            Me.EmDebito.Text = FormatNumber(NzZero(0), 2)
        End If

        DR.Close()
        CnnFind.Close()
    End Sub
    Private Sub VerificaSaldoCreditoAtualizado()


        If Me.C�digoCliente.Text = "" Then
            Exit Sub
        End If
        Me.SaldoLimiteCredito.ForeColor = Color.Black

        Dim CnnFind As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CnnFind.Open()

        Dim Sql As String = "Select * from Clientes where Codigo = " & Me.C�digoCliente.Text
        Dim CMD As New OleDb.OleDbCommand(Sql, CnnFind)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Me.UsarLimite.Checked = DR.Item("UsarLimite")
            Me.LimiteCredito.Text = FormatNumber(NzZero(DR.Item("LimiteMensal")), 2)
            If DR.Item("Bloqueado") = True Then


                MessageBox.Show("Este cliente esta bloqueado, Favor verificar", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.C�digoCliente.Clear()
                Me.NomeCliente.Clear()
                Me.CpfCgc.Clear()
                Me.Insc.Clear()
                Me.Endere�o.Clear()
                Me.Cidade.Clear()
                Me.Estado.Clear()
                Me.Cep.Clear()
                Me.UsarLimite.Checked = False
                Me.ClienteBloqueado.Checked = False
                Me.LimiteCredito.Text = FormatNumber(0, 2)
                Me.EmDebito.Text = FormatNumber(0, 2)
                Me.SaldoLimiteCredito.Text = FormatNumber(0, 2)
                Me.C�digoCliente.Focus()
                Exit Sub


            End If

        Else
            MessageBox.Show("Cliente n�o localizado, Verifique.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.C�digoCliente.Clear()
            Me.NomeCliente.Clear()
            Me.CpfCgc.Clear()
            Me.Insc.Clear()
            Me.Endere�o.Clear()
            Me.Cidade.Clear()
            Me.Estado.Clear()
            Me.Cep.Clear()
            Me.UsarLimite.Checked = False
            Me.ClienteBloqueado.Checked = False
            Me.LimiteCredito.Text = FormatNumber(0, 2)
            Me.EmDebito.Text = FormatNumber(0, 2)
            Me.SaldoLimiteCredito.Text = FormatNumber(0, 2)
            Me.C�digoCliente.Focus()
        End If

        DR.Close()
        CnnFind.Close()

        If UsarLimite.Checked = True Then
            VerDebitoCliente()
            Me.SaldoLimiteCredito.Text = FormatNumber(NzZero(Me.LimiteCredito.Text) - NzZero(Me.EmDebito.Text), 2)

            Dim PercentualGasto As Double = (NzZero(Me.SaldoLimiteCredito.Text) / NzZero(Me.LimiteCredito.Text)) * 100

            If PercentualGasto > 70 Then Me.SaldoLimiteCredito.ForeColor = Color.Green
            If PercentualGasto < 70 And PercentualGasto > 35 Then Me.SaldoLimiteCredito.ForeColor = Color.Blue
            If PercentualGasto < 35 Then Me.SaldoLimiteCredito.ForeColor = Color.Red

            If FormatNumber(Me.SaldoLimiteCredito.Text, 2) <= FormatNumber(0, 2) Then
                MessageBox.Show("Este cliente esta com limite de compra insuficiente para uma opera��o.", "Validador de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.C�digoCliente.Clear()
                Me.NomeCliente.Clear()
                Me.CpfCgc.Clear()
                Me.Insc.Clear()
                Me.Endere�o.Clear()
                Me.Cidade.Clear()
                Me.Estado.Clear()
                Me.Cep.Clear()
                Me.UsarLimite.Checked = False
                Me.ClienteBloqueado.Checked = False
                Me.LimiteCredito.Text = FormatNumber(0, 2)
                Me.EmDebito.Text = FormatNumber(0, 2)
                Me.SaldoLimiteCredito.Text = FormatNumber(0, 2)
                Me.C�digoCliente.Focus()
            End If

        Else
            Me.SaldoLimiteCredito.Text = FormatNumber(NzZero(0), 2)
        End If

    End Sub
    Private Sub VlrDescProduto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles VlrDescProduto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TotalPedido.Focus()
        End If
    End Sub
    Private Sub VlrDescProduto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles VlrDescProduto.Leave
        If Me.VlrDescProduto.Text = "" Then Me.VlrDescProduto.Text = FormatCurrency(0, 2)
        If Me.PercDesconto.Text = "" Then Me.PercDesconto.Text = FormatNumber(0, 3)
        If DescontoEmLinha = True Then
            Me.PercDesconto.Text = FormatNumber(0, 3)
            Me.VlrDescProduto.Text = FormatCurrency(SomaDesconto, 2)
            Me.TotalPedido.Text = FormatCurrency(CDbl(NzZero(Me.ValorProduto.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)) - NzZero(Me.VlrDescProduto.Text))
            Me.TPedido.Text = FormatCurrency(CDbl(NzZero(Me.ValorProduto.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)) - NzZero(Me.VlrDescProduto.Text))
        Else
            If Me.VlrDescProduto.Text <> 0 Then Me.PercDesconto.Text = FormatNumber(CDbl(NzZero(Me.VlrDescProduto.Text)) / (CDbl(NzZero(Me.ValorProduto.Text))) * 100, 3)
            Me.TotalPedido.Text = FormatCurrency(CDbl(NzZero(Me.ValorProduto.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)) - CDbl(NzZero(Me.VlrDescProduto.Text)), 2)
            Me.TPedido.Text = FormatCurrency(CDbl(NzZero(Me.ValorProduto.Text)) + CDbl(NzZero(Me.ValorIpiPedido.Text)) - CDbl(NzZero(Me.VlrDescProduto.Text)), 2)
        End If

    End Sub
    Public Sub ZebraLista()
        Dim II As Integer
        Dim Zebrar As Boolean = True
        For II = 0 To MyLista.Items.Count - 1
            If Zebrar = True Then
                MyLista.Items.Item(II).BackColor = Color.White
                Zebrar = False
            Else
                MyLista.Items.Item(II).BackColor = Color.MediumOrchid
                Zebrar = True
            End If
        Next
    End Sub
    Private Sub Propriedade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Propriedade.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))

        KeyAscii = CShort(OnlyNumber(KeyAscii))

        If KeyAscii = 0 Then

            e.Handled = True

        End If
    End Sub
    Private Sub Propriedade_Leave(sender As Object, e As EventArgs) Handles Propriedade.Leave
        If Not String.IsNullOrEmpty(Propriedade.Text) Then
            AchaPropriedade()
        Else
            Me.propUF.Focus()
        End If

    End Sub
    Private Sub propUF_KeyDown(sender As Object, e As KeyEventArgs) Handles propUF.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TabPedido.SelectedTab = Me.TabItemPedido
            Me.VlrDescProduto.Focus()
        End If
    End Sub
    Private Sub propUF_Leave(sender As Object, e As EventArgs) Handles propUF.Leave
        Me.TabPedido.SelectedTab = Me.TabItemPedido
        Me.VlrDescProduto.Focus()
    End Sub

    Private Sub C�digoFuncion�rio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles C�digoFuncion�rio.KeyPress
        'so aceita numeros ***beto
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(OnlyNumber(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ParcelamentoFixo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ParcelamentoFixo.KeyPress
        'so aceira numeros *** beto
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(OnlyNumber(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub C�digoCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles C�digoCliente.KeyPress
        'so aceita numeros
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(OnlyNumber(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click
        If Me.PedidoSequencia.Text = "" Then
            Exit Sub
        End If
        Dim f As New PedidoOSNumeroNF
        f.Nfe.Text = Me.txtNfePecas.Text
        f.Nfs.Text = Me.txtNfeServico.Text
        f.ShowDialog()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        TRVDados(UserAtivo, "ObejtosCad")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ObjetosCad.ShowDialog()
        End If
    End Sub

    Private Sub ValorAFaturar_Enter(sender As Object, e As EventArgs) Handles ValorAFaturar.Enter
        If TpVenda.Text = "DEVOLU��O" Then
            ValorAFaturar.Text = TPedido.Text
        End If
    End Sub
    Private Sub salvarDadosClientes()
        'Fim da Area destinada para as validacoes
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        If Me.Confirmado.Checked = False Then

            If Operation = UPD Then

                Dim Sql As String = "Update Pedido  Set C�digoCliente = @1, Propriedade = @2, DataPedido = @3, ObsCab = @4, ObsRod = @5, Empresa = @6 Where Pedido.PedidoSequencia = " & Me.PedidoSequencia.Text
                Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

                cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.C�digoCliente.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Propriedade.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.DataPedido.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.ObsCab.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.ObsRod.Text, 1)))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@6", CodEmpresa))
                Try
                    cmd.ExecuteNonQuery()
                    CNN.Close()
                    Operation = UPD
                Catch ex As Exception
                    MsgBox(ex.Message, 64, "Valida��o de Dados")
                End Try
            End If
        End If

    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click

        If Me.PedidoSequencia.Text = "" Then
            MessageBox.Show("Favor selecionar um pedido.", "Valida��o de Dados", MessageBoxButtons.OK)
            Exit Sub
        End If


        My.Forms.PedidoCancelamentoOS.PedidoCancelar = Me.PedidoSequencia.Text
        My.Forms.PedidoCancelamentoOS.ShowDialog()
    End Sub

    Private Sub btGerarNFe_Click(sender As Object, e As EventArgs) Handles btGerarNFe.Click
        TRVDados(UserAtivo, "NFeValidarDados")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else

            'Antes de Gerar a NFe devemos validar os Dados e posteriormente Salvar ou Editar os Dados

            'If UserAtivo <> "ADMIN" Then
            'MessageBox.Show("Fun��o em desenvolvimento", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Exit Sub
            'End If

            If Me.PedidoSequencia.Text = "" Then
                MessageBox.Show("Favor selecionar um Pedido para emitir a NFe.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Me.Confirmado.Checked = False Then
                MessageBox.Show("Favor selecionar um Pedido confirmado para emitir a NFe.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If Me.MyLista.Items.Count = 0 Then
            '    MessageBox.Show("N�o pode gerar NFe para Pedido sem Item.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If

            Dim jaGerouNFe() As String


            jaGerouNFe = Split(Me.ChaveNFe.Text, "-")
            If jaGerouNFe.Length > 1 Then
                If Trim(jaGerouNFe(1)) <> "" Then
                    MessageBox.Show("Este Pedido ja tem uma NFe com a Chave: " & jaGerouNFe(1) & ", n�o pode gerar mais NFe neste pedido.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If Me.TpVenda.Text = "VENDA" Or Me.TpVenda.Text = "VENDA INTERNA" Then
                My.Forms.NFeValidarDados.CodigoCliente = Me.C�digoCliente.Text
                My.Forms.NFeValidarDados.NumeroPedido = Me.PedidoSequencia.Text
                My.Forms.NFeValidarDados.ShowDialog()
            Else
                MessageBox.Show("Este tipo de Venda n�o pode Emitir NFe.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        End If
    End Sub
End Class
