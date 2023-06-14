Public Class SellShoesOEVerItens

    Dim Ped As Integer
    Public Property PedidoVer() As Integer
        Get
            Return Ped
        End Get
        Set(ByVal Value As Integer)
            Ped = Value
        End Set
    End Property


    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub SellShoesOEVerItens_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaItens(Ped)
    End Sub


    Private Sub CarregaItens(VarPedido As Integer)


        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim SqlItens As String = String.Empty

        SqlItens = "SELECT ItensPedido.Id, ItensPedido.PedidoSequencia, ItensPedido.CodigoProduto, Produtos.Descrição, ItensPedido.Qtd, ItensPedido.QtdRetirada,ItensPedido.ValorUnitario, ItensPedido.Desconto, ItensPedido.ValorDesconto, ItensPedido.TotalProduto  FROM (Pedido INNER JOIN ItensPedido ON Pedido.PedidoSequencia = ItensPedido.PedidoSequencia) INNER JOIN Produtos ON ItensPedido.CodigoProduto = Produtos.CodigoProduto WHERE (((Pedido.PedidoSequencia)=" & VarPedido & ") AND ((Pedido.Empresa)=" & CodEmpresa & ") AND ((Pedido.Inativo)=False) AND ((Pedido.Confirmado)=True));"


        'Carrega os Itens
        Dim CmdItens As New OleDb.OleDbCommand(SqlItens, CNN)
        Dim DaItens As New OleDb.OleDbDataAdapter(CmdItens)

        Dim DsItens As New DataSet
        DaItens.Fill(DsItens, "Itens")


        Me.ListaItens.DataSource = DsItens.Tables("Itens").DefaultView
        DaItens.Dispose()

        CNN.Close()
    End Sub

   
End Class