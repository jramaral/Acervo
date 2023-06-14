Public Class LocacaoProdutoProcura

    Dim opt As Integer

    Dim DsGrade As DataSet
    Dim bs As BindingSource
    Dim fnome As String
    Dim myform As Form
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(ByRef f As Form)
        InitializeComponent()
        fnome = f.Name
    End Sub
    Public Sub New(ByRef sNome As String)
        InitializeComponent()
        fnome = sNome
    End Sub
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub MarcarLinha()
        For i As Integer = 0 To Lista.Rows.Count - 1

            Dim SS As String
            SS = NzZero(Lista.Rows(i).Cells("estoque").Value.ToString)
            If Int(SS) <= 0 Then
                Me.Lista.Rows(i).Cells("estoque").Style.ForeColor = Color.Red
            End If
        Next
    End Sub

    Private Sub LocacaoProdutoProcura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.txtProcura.Focus()

    End Sub

    Private Sub txtProcura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcura.Leave

        If Me.A3.Checked = True Then
            Me.Lista.Focus()
            Exit Sub
        End If

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()


        Dim Sql As String = ""
        If Me.A1.Checked = True Then
            'Sql = "SELECT Produtos.CodigoProduto, Produtos.CodigoBarra, Produtos.CodigoFabrica, Produtos.Descrição, Produtos.UnidadeMedida,  ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque, Produtos.ValorVenda, Cor.CorDesc,ProdutosFoto.Foto FROM (Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Cor ON Produtos.Cor = Cor.Codigo WHERE (((Produtos.CodigoProduto) =" & Me.txtProcura.Text & ") AND ((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Tipo)=1)  AND ((Produtos.Empresa)=" & CodEmpresa & ")) and Produtos.Inativo = false"
            Sql = "SELECT Produtos.CodigoProduto, Produtos.CodigoBarra, Produtos.CodigoFabrica, Produtos.Descrição, Produtos.UnidadeMedida, ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque, Produtos.ValorVenda, Cor.CorDesc,ProdutosFoto.Foto, QtdeLocado  FROM ProdutosFoto RIGHT JOIN ((Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Cor ON Produtos.Cor = Cor.Codigo) ON ProdutosFoto.CodigoProduto = Produtos.CodigoProduto WHERE (((Produtos.Tipo)=1) AND ((Produtos.CodigoProduto) =" & Me.txtProcura.Text & ") AND ((Produtos.QuantidadeEstoque)>=0) AND ((Produtos.Empresa)=" & CodEmpresa & ")) and Produtos.Inativo = false"
            Me.Lista.Focus()
        End If
        If Me.A2.Checked = True Then
            'Sql = "SELECT Produtos.CodigoProduto, Produtos.CodigoBarra, Produtos.CodigoFabrica, Produtos.Descrição, Produtos.UnidadeMedida,  ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque, Produtos.ValorVenda, Cor.CorDesc FROM (Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Cor ON Produtos.Cor = Cor.Codigo WHERE (((Produtos.Descrição) Like '%" & Me.txtProcura.Text & "%') AND ((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Tipo)=1) AND ((Produtos.Empresa)=" & CodEmpresa & ")) and Produtos.Inativo = false"
            Sql = "SELECT Produtos.CodigoProduto, Produtos.CodigoBarra, Produtos.CodigoFabrica, Produtos.Descrição, Produtos.UnidadeMedida, ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque, Produtos.ValorVenda, Cor.CorDesc,ProdutosFoto.Foto, QtdeLocado  FROM ProdutosFoto RIGHT JOIN ((Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Cor ON Produtos.Cor = Cor.Codigo) ON ProdutosFoto.CodigoProduto = Produtos.CodigoProduto WHERE (((Produtos.Tipo)=1) AND ((Produtos.Descrição) Like '%" & Me.txtProcura.Text & "%') AND ((Produtos.QuantidadeEstoque)>=0) AND ((Produtos.Empresa)=" & CodEmpresa & ")) and Produtos.Inativo = false"
            Me.Lista.Focus()
        End If

        'If Me.A4.Checked = True Then
        '    'Sql = "SELECT Produtos.CodigoProduto, Produtos.CodigoBarra, Produtos.CodigoFabrica, Produtos.Descrição, Produtos.UnidadeMedida,  ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque, Produtos.ValorVenda, Cor.CorDesc FROM (Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Cor ON Produtos.Cor = Cor.Codigo WHERE (((Produtos.CodigoOriginal) Like '%" & Me.txtProcura.Text & "%') AND ((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Tipo)=1) AND ((Produtos.Empresa)=" & CodEmpresa & ")) and Produtos.Inativo = false"
        '    Sql = "SELECT Produtos.CodigoProduto, Produtos.CodigoBarra, Produtos.CodigoFabrica, Produtos.Descrição, Produtos.UnidadeMedida, ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque, Produtos.ValorVenda, Cor.CorDesc,ProdutosFoto.Foto  FROM ProdutosFoto RIGHT JOIN ((Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Cor ON Produtos.Cor = Cor.Codigo) ON ProdutosFoto.CodigoProduto = Produtos.CodigoProduto WHERE (((Produtos.Tipo)=1) AND ((Produtos.Descrição) Like '%" & Me.txtProcura.Text & "%') AND ((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Empresa)=" & CodEmpresa & ")) and Produtos.Inativo = false"
        '    Me.Lista.Focus()
        'End If

        'If Me.A5.Checked = True Then
        '    Sql = "SELECT Produtos.CodigoProduto, Produtos.CodigoBarra, Produtos.CodigoFabrica, Produtos.Descrição, Produtos.UnidadeMedida,  ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque, Produtos.ValorVenda, Cor.CorDesc FROM (Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Cor ON Produtos.Cor = Cor.Codigo WHERE (((Produtos.CodigoFabrica) Like '%" & Me.txtProcura.Text & "%') AND ((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Tipo)=1) AND ((Produtos.Empresa)=" & CodEmpresa & ")) and Produtos.Inativo = false"
        '    Me.Lista.Focus()
        'End If



        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim Da As New OleDb.OleDbDataAdapter(CMD)

        Dim ds As New DataSet
        Da.Fill(ds, "Table")

        If ds.Tables("Table").Rows.Count = 0 Then
            Da.Dispose()
            CNN.Close()
            Me.Lista.Focus()
            Exit Sub
        End If


        Me.Lista.DataSource = ds.Tables("Table").DefaultView
        MarcarLinha()


        Da.Dispose()
        CNN.Close()

        Me.Lista.Focus()

    End Sub

    Private Sub A1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A1.CheckedChanged, A2.CheckedChanged

        If Me.A1.Checked = True Then
            Me.txtProcura.Clear()
            Me.txtProcura.Focus()
        End If
        If Me.A2.Checked = True Then
            Me.txtProcura.Clear()
            Me.txtProcura.Focus()
        End If

       


    End Sub

    Private Sub MostraTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A3.CheckedChanged
        If Me.A3.Checked = True Then
            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()


            Dim Sql As String = "SELECT Produtos.CodigoProduto, Produtos.CodigoBarra, Produtos.CodigoFabrica, Produtos.Descrição, Produtos.UnidadeMedida, ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque, Produtos.ValorVenda, Cor.CorDesc,ProdutosFoto.Foto, QtdeLocado  FROM ProdutosFoto RIGHT JOIN ((Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Cor ON Produtos.Cor = Cor.Codigo) ON ProdutosFoto.CodigoProduto = Produtos.CodigoProduto WHERE (((Produtos.Tipo)=1) AND ((Produtos.QuantidadeEstoque)>=0) AND ((Produtos.Empresa)=" & CodEmpresa & ")) and Produtos.Inativo = false"

            Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
            Dim Da As New OleDb.OleDbDataAdapter(CMD)

            Dim ds As New DataSet
            Da.Fill(ds, "Table")

            Me.Lista.DataSource = ds.Tables("Table").DefaultView
            MarcarLinha()



            Da.Dispose()
            CNN.Close()

            Me.Lista.Focus()
        End If
    End Sub



    Private Sub DgvItem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lista.CellDoubleClick

        Select Case fnome
            Case "Locacao"
                My.Forms.Locacao.CodBarra.Text = Me.Lista.CurrentRow.Cells("cCodigoBarra").Value

            Case "LocacaoOrcamento"

                DirectCast(LocacaoOrcamento.m_instace.Fundo.Controls("CodBarra"), TexBoxFocusNet.TextBoxFocusNet).Text = Me.Lista.CurrentRow.Cells("cCodigoBarra").Value
            Case "LocacaoSeletor"

                My.Forms.LocacaoSeletor.CodProduto.Text = Me.Lista.CurrentRow.Cells("cCodigoBarra").Value
            Case "SaidaProdutos"
                My.Forms.SaidaProdutos.txtCodigoProduto.Text = Me.Lista.CurrentRow.Cells("cCodigoBarra").Value
                My.Forms.SaidaProdutos.txtDescricaoProduto.Text = Me.Lista.CurrentRow.Cells("Desc").Value
                My.Forms.SaidaProdutos.txtEstoqueAtual.Text = Me.Lista.CurrentRow.Cells("estoque").Value

        End Select
        Me.Close()
        Me.Dispose()

    End Sub



    Private Sub ProcuraProduto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Me.A1.Checked = True
                Me.txtProcura.Focus()
            Case Keys.F4
                Me.A2.Checked = True
                Me.txtProcura.Focus()
            
            Case Keys.F7
                Me.A3.Checked = True
                Me.Lista.Focus()
        End Select
    End Sub


    Private Sub Lista_KeyDown(sender As Object, e As KeyEventArgs) Handles Lista.KeyDown
        Dim evt As DataGridViewCellEventArgs = Nothing
        If e.KeyCode = Keys.Return Then
            Call DgvItem_CellDoubleClick(sender, evt)
        End If

    End Sub
End Class