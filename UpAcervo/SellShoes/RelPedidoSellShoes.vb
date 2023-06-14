Imports System.Linq
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class RelPedidoSellShoes
    Dim I As Integer = 0
    Public cPed As Integer 'Armazena o valor do codigo da venda e passa para as demais conexãoes.

    Dim ParcelamentoSub As New RelPedidoSellShoesParcelamento
    Public devPedidoOriginal As String = String.Empty
    Private count As Integer = 1
    Private countEnd As Integer = 0


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        devPedidoOriginal = "000000"
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        If (I Mod 2) = 0 Then
            Me.Detail1.BackColor = Color.Silver
        Else
            Me.Detail1.BackColor = Color.Transparent
        End If
        I += 1

        txtSeq.Text = Format(I, "000")

        CType(Me.Parcelas.Report.DataSource, DataSources.OleDBDataSource).ConnectionString = New Conectar().ConectarBD(LocalBD & Nome_BD)
        CType(Me.Parcelas.Report.DataSource, DataSources.OleDBDataSource).SQL = "SELECT Receber.Documento, Receber.Vencimento, Receber.ValorDocumento, Receber.IdAgrupamento FROM Receber WHERE Receber.OriginalParcial='O' and Receber.PedidoProdutos=" & cPed & ""

    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Me.txtPedVlrDescProduto1.Text = FormatCurrency(CDbl(NzZero(Me.txtAcrecimo1.Text)) - CDbl(NzZero(Me.TextBox2.Text)), 2)

        'Mostra se o pedido esta cancelado na impressao.
        If Me.txtInativo1.Text = True Then
            Me.lblmsgCancelado.Visible = True
        Else
            Me.lblmsgCancelado.Visible = False
        End If



        countEnd = PageNumber


    End Sub

    Private Sub RelPedidoSellShoes_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        Dim Conect As New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Conect.ConnectionString = New Conectar().ConectarBD(LocalBD & Nome_BD)

        'Conect.SQL = "SELECT Empresa.RazãoSocial, Empresa.Endereço AS EnderecoEmpresa, Empresa.Numero, Empresa.Telefone AS FoneEmpresa, Empresa.Cidade AS CidadeEmpresa, Empresa.Estado AS EstadoEmpresa, Empresa.Cep, Funcionários.Nome AS NomeFuncionario, Funcionários.Telefone AS FoneFuncionario, Pedido.PedidoSequencia, Pedido.DataPedido, Pedido.ValorProduto AS PedValorProdutos, Pedido.VlrDescProduto AS PedVlrDescProduto, Pedido.Acrecimo, Pedido.TotalPedido, Pedido.EnderecoEntrega, Clientes.Nome, Clientes.Endereço, Clientes.CpfCgc, Clientes.Nro, Clientes.Cidade, Clientes.Bairro, Clientes.Estado, Clientes.Codigo, Clientes.Telefone, Clientes.Celular, ItensPedido.CodigoProduto, Produtos.Descrição AS ProdutoDescricao, Produtos.UnidadeMedida, ItensPedido.Qtd, ItensPedido.ValorUnitario, ItensPedido.ValorDesconto,ItensPedido.TotalProduto, Pedido.FormaPgto, FormaPgto.Descrição, Pedido.TipoPgto,Pedido.PedidoTipo, TipoPgto.DescricaoTipoPgto,  Pedido.Inativo FROM FormaPgto INNER JOIN (TipoPgto INNER JOIN ((Clientes INNER JOIN (Produtos INNER JOIN ((Funcionários INNER JOIN Pedido ON Funcionários.CódigoFuncionário = Pedido.CódigoFuncionário) INNER JOIN ItensPedido ON Pedido.PedidoSequencia = ItensPedido.PedidoSequencia) ON Produtos.CodigoProduto = ItensPedido.CodigoProduto) ON Clientes.Codigo = Pedido.CódigoCliente) INNER JOIN Empresa ON Pedido.Empresa = Empresa.CódigoEmpresa) ON TipoPgto.CodigoTipoPgto = Pedido.TipoPgto) ON FormaPgto.CodFormaPgto = Pedido.CodPgto WHERE(((Pedido.PedidoSequencia) = " & cPed & ")) ORDER BY ItensPedido.Id;"
        Conect.SQL = "SELECT Empresa.RazãoSocial, Empresa.NomeFantasia, Empresa.Cgc, Empresa.InçriçãoEstadual, Empresa.Foto, Empresa.Endereço AS EnderecoEmpresa, Empresa.Numero, Empresa.Telefone AS FoneEmpresa, Empresa.Cidade AS CidadeEmpresa, Empresa.Estado AS EstadoEmpresa, Empresa.Cep,Empresa.email, Empresa.site, Funcionários.Nome AS NomeFuncionario, Funcionários.Telefone AS FoneFuncionario, Pedido.PedidoSequencia,Pedido.Contrato, Pedido.DataPedido, Pedido.ValorProduto AS PedValorProdutos, Pedido.VlrDescProduto AS PedVlrDescProduto, Pedido.Acrecimo, Pedido.TotalPedido, Pedido.EnderecoEntrega, Pedido.Requisicao, Clientes.Nome, Clientes.RG, Clientes.Endereço, Clientes.CpfCgc, Clientes.Nro, Clientes.Cidade, Clientes.Bairro, Clientes.Estado, Clientes.Codigo, Clientes.Telefone, Clientes.Celular, ItensPedido.CodigoProduto, Produtos.Descrição AS ProdutoDescricao, Produtos.UnidadeMedida, ItensPedido.Qtd, ItensPedido.ValorUnitario, ItensPedido.ValorDesconto, [ValorDesconto]+[vDescontoEspecial] AS [Desc], ItensPedido.TotalProduto, Pedido.FormaPgto, FormaPgto.Descrição, Pedido.TipoPgto, Pedido.PedidoTipo, TipoPgto.DescricaoTipoPgto, Pedido.Inativo FROM FormaPgto INNER JOIN (TipoPgto INNER JOIN ((Clientes INNER JOIN (Produtos INNER JOIN ((Funcionários INNER JOIN Pedido ON Funcionários.CódigoFuncionário = Pedido.CódigoFuncionário) INNER JOIN ItensPedido ON Pedido.PedidoSequencia = ItensPedido.PedidoSequencia) ON Produtos.CodigoProduto = ItensPedido.CodigoProduto) ON Clientes.Codigo = Pedido.CódigoCliente) INNER JOIN Empresa ON Pedido.Empresa = Empresa.CódigoEmpresa) ON TipoPgto.CodigoTipoPgto = Pedido.TipoPgto) ON FormaPgto.CodFormaPgto = Pedido.CodPgto WHERE(((Pedido.PedidoSequencia) = " & cPed & "))ORDER BY ItensPedido.Id;"

        Me.DataSource = Conect

        Me.Parcelas.Report = ParcelamentoSub

        'If CabecalhoPersonalizado Then
        '    Me.PageHeader1.Visible = True
        '    Me.ReportHeader1.Visible = False
        'Else
        Me.PageHeader1.Visible = True
        Me.ReportHeader1.Visible = False
        'End If


        Dim sql As String = "Select * from Empresa"
        Dim oDA As New OleDb.OleDbDataAdapter(sql, Conect.ConnectionString)
        Dim oDS As New DataSet
        oDA.Fill(oDS, "empresa")
        Dim bytePic() As Byte = oDS.Tables("empresa").Rows(0).Item("foto")

        Dim PicMemStream As New System.IO.MemoryStream(bytePic)

        Picture1.Image = Image.FromStream(PicMemStream)

        txtcnpjie.Text = "CNPJ: " & oDS.Tables("empresa").Rows(0).Item("Cgc") & "  I.E  " & oDS.Tables("empresa").Rows(0).Item("InçriçãoEstadual")
        txtEnderecoNumeroTelefone.Text = oDS.Tables("empresa").Rows(0).Item("Endereço") & "  Nº " & oDS.Tables("empresa").Rows(0).Item("Numero") & " FONE " & oDS.Tables("empresa").Rows(0).Item("Telefone")
        txtCidadeEstado.Text = oDS.Tables("empresa").Rows(0).Item("Cidade").ToString.ToUpper & " - " & oDS.Tables("empresa").Rows(0).Item("Estado").ToString.ToUpper
        txtsite.Text = oDS.Tables("empresa").Rows(0).Item("site").ToString.ToUpper
        txtEmail.Text = oDS.Tables("empresa").Rows(0).Item("email").ToString.ToLower
    End Sub

    Private Sub RelPedidoSellShoes_ReportStart(sender As Object, e As EventArgs) Handles Me.ReportStart
        If bUsaPapelA4Pedido Then
            Me.PageSettings.PaperKind = Printing.PaperKind.A4
        End If

        If devPedidoOriginal.Contains("000000") Or IsNothing(devPedidoOriginal) Then
            TextBox9.Visible = False
        Else
            TextBox9.Visible = True
            TextBox9.Text = "Pedido Original: " & devPedidoOriginal
        End If
    End Sub


    Private Sub PageFooter1_Format(sender As Object, e As EventArgs) Handles PageFooter1.Format
        If countEnd.Equals(PageNumber) Then
            Label30.Visible = True
            TextBox6.Visible = True
            TextBox6.Text = TextBox11.Text & " ou Representante Autorizado"
        End If
       
    End Sub

    Private Sub PageHeader1_Format(sender As Object, e As EventArgs) Handles PageHeader1.Format
        Me.txtNomeFuncionario1.Text = "Vendedor: " & Me.TextBox10.Text & "-" & Me.TextBox8.Text
    End Sub

    Private Sub GroupFooter1_Format(sender As System.Object, e As System.EventArgs) Handles GroupFooter1.Format

    End Sub
End Class
