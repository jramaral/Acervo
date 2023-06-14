Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class RelPedidoLiquido
    Dim I As Integer
    Public cPed As Integer 'Armazena o valor do codigo da venda e passa para as demais conexãoes.

   


    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        If (I Mod 2) = 0 Then
            Me.Detail1.BackColor = Color.Silver
        Else
            Me.Detail1.BackColor = Color.Transparent
        End If
        I += 1
        Me.txtVlrUnitLiq.Text = FormatNumber(Me.txtValorUnitario.Text - (Me.txtValorUnitario.Text * Me.txtPercentual1.Text / 100), 4)
        Me.VlrLiquido.Text = FormatNumber(Me.txtQtd1.Text * Me.txtVlrUnitLiq.Text, 2)
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        ''Mostra se o pedido esta cancelado na impressao.
        'If Me.txtInativo1.Text = True Then
        '    Me.lblmsgCancelado.Visible = True
        'Else
        '    Me.lblmsgCancelado.Visible = False
        'End If
    End Sub

    Private Sub RelPedidoSellShoes_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        Dim Conect As New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Conect.ConnectionString = New Conectar().ConectarBD(LocalBD & Nome_BD)

        'Conect.SQL = "SELECT Empresa.RazãoSocial, Empresa.Endereço AS EnderecoEmpresa, Empresa.Numero, Empresa.Telefone AS FoneEmpresa, Empresa.Cidade AS CidadeEmpresa, Empresa.Estado AS EstadoEmpresa, Empresa.Cep, Funcionários.Nome AS NomeFuncionario, Funcionários.Telefone AS FoneFuncionario, Pedido.PedidoSequencia, Pedido.DataPedido, Pedido.ValorProduto AS PedValorProdutos, Pedido.VlrDescProduto AS PedVlrDescProduto, Pedido.Acrecimo, Pedido.TotalPedido, Pedido.EnderecoEntrega, Clientes.Nome, Clientes.Endereço, Clientes.Nro, Clientes.Cidade, Clientes.Bairro, Clientes.Estado, Clientes.Codigo, Clientes.Telefone, Clientes.Celular, ItensPedido.CodigoProduto, Produtos.Descrição AS ProdutoDescricao, Produtos.UnidadeMedida, ItensPedido.Qtd, ItensPedido.ValorUnitario, ItensPedido.ValorDesconto, ItensPedido.TotalProduto, Pedido.FormaPgto, FormaPgto.Descrição, Pedido.TipoPgto,Pedido.PedidoTipo, TipoPgto.DescricaoTipoPgto,  Pedido.Inativo FROM FormaPgto INNER JOIN (TipoPgto INNER JOIN ((Clientes INNER JOIN (Produtos INNER JOIN ((Funcionários INNER JOIN Pedido ON Funcionários.CódigoFuncionário = Pedido.CódigoFuncionário) INNER JOIN ItensPedido ON Pedido.PedidoSequencia = ItensPedido.PedidoSequencia) ON Produtos.CodigoProduto = ItensPedido.CodigoProduto) ON Clientes.Codigo = Pedido.CódigoCliente) INNER JOIN Empresa ON Pedido.Empresa = Empresa.CódigoEmpresa) ON TipoPgto.CodigoTipoPgto = Pedido.TipoPgto) ON FormaPgto.CodFormaPgto = Pedido.CodPgto WHERE(((Pedido.PedidoSequencia) = " & cPed & ")) ORDER BY ItensPedido.Id;"
        Conect.SQL = "SELECT Empresa.RazãoSocial, Empresa.Endereço AS EnderecoEmpresa, Empresa.Numero, Empresa.Telefone AS FoneEmpresa, Empresa.Cidade AS CidadeEmpresa, Empresa.Estado AS EstadoEmpresa, Empresa.Cep, Funcionários.Nome AS NomeFuncionario, Funcionários.Telefone AS FoneFuncionario, Pedido.PedidoSequencia, Pedido.Contrato, Pedido.DataPedido, Pedido.ValorProduto AS PedValorProdutos, Pedido.VlrDescProduto AS PedVlrDescProduto, Pedido.Acrecimo, Pedido.TotalPedido, Pedido.PedidoTipo, Pedido.Requisicao, Clientes.Nome, Clientes.Endereço, Clientes.Nro, Clientes.Cidade, Clientes.Bairro, Clientes.Estado, Clientes.Telefone, Clientes.Celular, Clientes.Codigo, ItensPedido.CodigoProduto, Produtos.Descrição AS ProdutoDescricao, Produtos.UnidadeMedida, ItensPedido.Qtd, ItensPedido.ValorUnitario, ItensPedido.ValorDesconto, ItensPedido.TotalProduto, Pedido.FormaPgto, FormaPgto.Descrição, Pedido.TipoPgto, TipoPgto.DescricaoTipoPgto, Pedido.Inativo,  Format(([Pedido].[vlrdescProduto]*100)/[Pedido].[valorproduto],'#.##') AS Percentual FROM FormaPgto INNER JOIN (TipoPgto INNER JOIN ((Clientes INNER JOIN (Produtos INNER JOIN ((Funcionários INNER JOIN Pedido ON Funcionários.CódigoFuncionário = Pedido.CódigoFuncionário) INNER JOIN ItensPedido ON Pedido.PedidoSequencia = ItensPedido.PedidoSequencia) ON Produtos.CodigoProduto = ItensPedido.CodigoProduto) ON Clientes.Codigo = Pedido.CódigoCliente) INNER JOIN Empresa ON Pedido.Empresa = Empresa.CódigoEmpresa) ON TipoPgto.CodigoTipoPgto = Pedido.TipoPgto) ON FormaPgto.CodFormaPgto = Pedido.CodPgto WHERE(((Pedido.PedidoSequencia) = " & cPed & ")) ORDER BY ItensPedido.Id;"
        Me.DataSource = Conect


        If CabecalhoPersonalizado Then
            Me.PageHeader1.Visible = True
            Me.ReportHeader1.Visible = False
        Else
            Me.PageHeader1.Visible = False
            Me.ReportHeader1.Visible = True
        End If


        Dim sql As String = "Select * from Empresa"
        Dim oDA As New OleDb.OleDbDataAdapter(sql, Conect.ConnectionString)
        Dim oDS As New DataSet
        oDA.Fill(oDS, "empresa")
        Dim bytePic() As Byte = oDS.Tables("empresa").Rows(0).Item("foto")

        Dim PicMemStream As New System.IO.MemoryStream(bytePic)

        Picture1.Image = Image.FromStream(PicMemStream)
        

    End Sub

    Private Sub RelPedidoLiquido_ReportStart(sender As Object, e As EventArgs) Handles Me.ReportStart
        If bUsaPapelA4Pedido Then
            Me.PageSettings.PaperKind = Printing.PaperKind.A4
        End If
    End Sub
End Class
