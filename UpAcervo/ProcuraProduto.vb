Imports System.IO

Public Class ProcuraProduto

    Dim opt As Integer
    'Conexao
    Dim Cn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub MarcarLinha()
        For i As Integer = 0 To DgvItem.Rows.Count - 1

            Dim SS As String
            SS = NzZero(DgvItem.Rows(i).Cells("estoque").Value.ToString)
            If Int(SS) <= 0 Then
                Me.DgvItem.Rows(i).Cells("estoque").Style.ForeColor = Color.Red
                'DgvItem.Rows(i).Cells("img").Value = DgvItem.Rows(i).Cells("imgVermelho").Value
                'DgvItem.Rows(i).Cells("img").Value = DgvItem.Rows(i).Cells("imgAzul").Value
                'Me.DgvItem.CurrentRow.Cells("Sel").Value = True
            End If
        Next
    End Sub
    Public Sub VisualizaFoto()
        
        'tratamento de erro
        Try
            'command para pegar os dados
            Dim Cmd As New OleDb.OleDbCommand("SELECT * From ProdutosFoto where CodigoProduto = " & Me.DgvItem.CurrentRow.Cells("codigo").Value, Cn)
            'dataadapter para fazer a ligação dos dados
            Dim Da As New OleDb.OleDbDataAdapter(Cmd)
            'dataset para guardar em memória os dados
            Dim Ds As New DataSet()
            'abre conexão
            Cn.Open()
            'preenche dataset com a tabela "ProdutosFotos"
            Da.Fill(Ds, "FotoProduto")
            'variavel para recebe a quantidade de linhas da tabela retornada
            Dim c As Integer = Ds.Tables(0).Rows.Count
            If c > 0 Then
                'array recebe a última linha do dataset, a imagem
                Dim ByteData() As Byte = Ds.Tables(0).Rows(c - 1).Item("Foto")
                'stream em memória recebe a imagem
                Dim ImgVer As New MemoryStream(ByteData)
                'a picturebox recebe imagem que usa o método FromStream para "ler" a stream que contém a imagem

                'Compara tamanhos para fazer ajustes no quadro de visualização
                Me.Display.Visible = True
                Me.Display.Image = Image.FromStream(ImgVer)

            Else
                Me.Display.Image = Me.Vazio.Image

            End If
            Cn.Close()
        Catch err As Exception
            Me.Display.Visible = False
        Finally
            'fecha a conexão
            Cn.Close()
        End Try

    End Sub
    Private Sub ProcuraProduto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtProcura.Focus()
    End Sub

    Private Sub txtProcura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcura.Leave

        If Me.A3.Checked = True Then
            Me.DgvItem.Focus()
            Exit Sub
        End If

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = ""
        If Me.A1.Checked = True Then
            ' Sql = "SELECT Produtos.CodigoProduto,  Produtos.Descrição, Produtos.UnidadeMedida, IIf([Tipo]=1,'PRODUTO',IIf([Tipo]=2,'MATERIA PRIMA',IIf([Tipo]=3,'ALMOXARIFADO',IIf([Tipo]=4,'IMOBILIZADO',IIf([Tipo]=5,'PROD. INDUST'))))) AS TP, ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque,  Produtos.ValorVenda, Marcas.Marca, Produtos.Referencia, Produtos.CodigoBarra, Produtos.ValorVendaAtacado, Produtos.QtdeLocado FROM (Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Marcas ON Produtos.Marca = Marcas.Codigo WHERE (((Produtos.CodigoProduto)=" & Me.txtProcura.Text & ") AND ((Produtos.Tipo)<>99) AND ((Produtos.Empresa)=" & CodEmpresa & ") AND ((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Inativo)=False));"
            Sql = "SELECT Produtos.CodigoProduto, Produtos.Descrição, Produtos.UnidadeMedida, Produtos.QuantidadeEstoque, Produtos.ValorVenda,Produtos.CodigoBarra,Produtos.ValorVenda2, Produtos.QtdeLocado, Marcas.Marca, ProdutosFoto.Foto, ([Produtos.EmLocacao] * -1) AS EmLocacao FROM (Produtos LEFT JOIN ProdutosFoto ON Produtos.CodigoProduto = ProdutosFoto.CodigoProduto) LEFT JOIN Marcas ON Produtos.Marca = Marcas.Codigo  WHERE (((Produtos.QuantidadeEstoque)>=0) AND ((Produtos.CodigoProduto)=" & Me.txtProcura.Text & ") AND ((Produtos.Inativo)=False) AND ((Produtos.Tipo)=1))"
        End If
        If Me.A2.Checked = True Then
            'Sql = "SELECT Produtos.CodigoProduto,  Produtos.Descrição, Produtos.UnidadeMedida, IIf([Tipo]=1,'PRODUTO',IIf([Tipo]=2,'MATERIA PRIMA',IIf([Tipo]=3,'ALMOXARIFADO',IIf([Tipo]=4,'IMOBILIZADO',IIf([Tipo]=5,'PROD. INDUST'))))) AS TP, ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque,  Produtos.ValorVenda, Marcas.Marca, Produtos.Referencia, Produtos.CodigoBarra, Produtos.ValorVendaAtacado, Produtos.QtdeLocado FROM (Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Marcas ON Produtos.Marca = Marcas.Codigo WHERE (((Produtos.Descrição) Like '%" & Me.txtProcura.Text & "%') AND ((Produtos.Tipo)<>99) AND ((Produtos.Empresa)=" & CodEmpresa & ") AND ((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Inativo)=False));"
            Sql = "SELECT Produtos.CodigoProduto, Produtos.Descrição, Produtos.UnidadeMedida, Produtos.QuantidadeEstoque, Produtos.ValorVenda,Produtos.CodigoBarra,Produtos.ValorVenda2, Produtos.QtdeLocado, Marcas.Marca, ProdutosFoto.Foto, ([Produtos.EmLocacao] * -1) AS EmLocacao FROM (Produtos LEFT JOIN ProdutosFoto ON Produtos.CodigoProduto = ProdutosFoto.CodigoProduto) LEFT JOIN Marcas ON Produtos.Marca = Marcas.Codigo  WHERE (((Produtos.QuantidadeEstoque)>=0) AND ((Produtos.Descrição) Like '%" & Me.txtProcura.Text & "%') AND ((Produtos.Inativo)=False) AND ((Produtos.Tipo)=1))"
        End If

        If Me.A6.Checked = True Then
            ' Sql = "SELECT Produtos.CodigoProduto, Produtos.Descrição, Produtos.UnidadeMedida, IIf([Tipo]=1,'PRODUTO',IIf([Tipo]=2,'MATERIA PRIMA',IIf([Tipo]=3,'ALMOXARIFADO',IIf([Tipo]=4,'IMOBILIZADO',IIf([Tipo]=5,'PROD. INDUST'))))) AS TP, ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque,  Produtos.ValorVenda, Marcas.Marca, Produtos.Referencia, Produtos.CodigoBarra, Produtos.ValorVendaAtacado, Produtos.QtdeLocado FROM (Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Marcas ON Produtos.Marca = Marcas.Codigo WHERE (((Marcas.Marca) Like '%" & Me.txtProcura.Text & "%') AND ((Produtos.Tipo)<>99) AND ((Produtos.Empresa)=" & CodEmpresa & ") AND ((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Inativo)=False));"
            Sql = "SELECT Produtos.CodigoProduto, Produtos.Descrição, Produtos.UnidadeMedida, Produtos.QuantidadeEstoque, Produtos.ValorVenda,Produtos.CodigoBarra,Produtos.ValorVenda2, Produtos.QtdeLocado, Marcas.Marca, ProdutosFoto.Foto, ([Produtos.EmLocacao] * -1) AS EmLocacao FROM (Produtos LEFT JOIN ProdutosFoto ON Produtos.CodigoProduto = ProdutosFoto.CodigoProduto) LEFT JOIN Marcas ON Produtos.Marca = Marcas.Codigo  WHERE (((Produtos.QuantidadeEstoque)>=0) AND ((Marcas.Marca) Like '%" & Me.txtProcura.Text & "%') AND ((Produtos.Inativo)=False) AND ((Produtos.Tipo)=1))"
        End If


        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim Da As New OleDb.OleDbDataAdapter(CMD)

        Dim ds As New DataSet
        Da.Fill(ds, "Table")

        Me.DgvItem.DataSource = ds.Tables("Table").DefaultView
        MarcarLinha()

        Da.Dispose()
        CNN.Close()

        If Me.DgvItem.RowCount > 0 Then
            Me.DgvItem.Focus()
        Else
            Me.txtProcura.Focus()
        End If
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


        If Me.A6.Checked = True Then
            Me.txtProcura.Clear()
            Me.txtProcura.Focus()
        End If

    End Sub

    Private Sub MostraTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A3.CheckedChanged
        If Me.A3.Checked = True Then
            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()


            Dim Sql As String = "SELECT Produtos.CodigoProduto, Produtos.Descrição, Produtos.UnidadeMedida, Produtos.QuantidadeEstoque, Produtos.ValorVenda,Produtos.CodigoBarra,Produtos.ValorVenda2, Produtos.QtdeLocado, Marcas.Marca, ProdutosFoto.Foto, ([Produtos.EmLocacao] * -1) AS EmLocacao FROM (Produtos LEFT JOIN ProdutosFoto ON Produtos.CodigoProduto = ProdutosFoto.CodigoProduto) LEFT JOIN Marcas ON Produtos.Marca = Marcas.Codigo  WHERE (((Produtos.QuantidadeEstoque)>=0) AND  ((Produtos.Tipo)=1))"

            Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
            Dim Da As New OleDb.OleDbDataAdapter(CMD)

            Dim ds As New DataSet
            Da.Fill(ds, "Table")

            Me.DgvItem.DataSource = ds.Tables("Table").DefaultView
            MarcarLinha()

            Da.Dispose()
            CNN.Close()
        End If
    End Sub

    Private Sub DgvItem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvItem.CellDoubleClick

        'Vai para a tela de Cadastro de Produtos
        If My.Forms.Produtos.Visible = True Then
            My.Forms.Produtos.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            My.Forms.Produtos.LocalizaDados()
            Me.Close()
            Me.Dispose()
        End If


        If My.Forms.ProdutoEstoqueConsulta.Visible = True Then
            My.Forms.ProdutoEstoqueConsulta.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
        End If

        If My.Forms.ProdutoEstoqueAtualizar.Visible = True Then
            My.Forms.ProdutoEstoqueAtualizar.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
        End If

        If My.Forms.ProdutoSaldoEstoque.Visible = True Then
            My.Forms.ProdutoSaldoEstoque.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
        End If

        If My.Forms.ComprasAddItem.Visible = True Then
            My.Forms.ComprasAddItem.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
        End If

        If My.Forms.ProdutoEtiquetas.Visible = True Then
            My.Forms.ProdutoEtiquetas.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
        End If

        If My.Forms.ComprasRelat.Visible = True Then
            My.Forms.ComprasRelat.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
            Return
        End If

        If My.Forms.NfiscalLancaItens.Visible = True Then
            My.Forms.NfiscalLancaItens.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
            Return
        End If

        If My.Forms.ProdutoRelat.Visible = True Then
            My.Forms.ProdutoRelat.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
            Return
        End If

        If My.Forms.ProdutoEstoqueAjuste.Visible = True Then
            My.Forms.ProdutoEstoqueAjuste.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
            Return
        End If

        If My.Forms.EstoqueTransferencia.Visible = True Then
            My.Forms.EstoqueTransferencia.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
            Return
        End If


        If My.Forms.SellShoesOrcamento.Visible = True Then
            If UsarGrade = False Then
                My.Forms.SellShoesOrcamento.CodBarra.Text &= Me.DgvItem.CurrentRow.Cells("CodBarra").Value
            End If
            Me.Close()
            Me.Dispose()
            Return
        End If

        If My.Forms.LocacaoCilindro.Visible = True Then
            My.Forms.LocacaoCilindro.txtCodigoProduto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
            Return
        End If

        If My.Forms.ProdutoGradeEstoqueAjuste.Visible = True Then
            My.Forms.ProdutoGradeEstoqueAjuste.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
            Return
        End If

        If My.Forms.LocacaoSeletor.Visible = True Then
            My.Forms.LocacaoSeletor.CodProduto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
            Me.Close()
            Me.Dispose()
            Return
        End If

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
                Me.A6.Checked = True
                Me.txtProcura.Focus()
            Case Keys.F8
                Me.A3.Checked = True
                Me.DgvItem.Focus()
        End Select
    End Sub

    Private Sub DgvItem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvItem.KeyDown
        If e.KeyCode = Keys.Enter Then

            'usado para a tela de pedido venda OS
            If PedidoAddItemOS.Visible Then
                My.Forms.PedidoAddItemOS.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
                Me.Close()
                Me.Dispose()
            End If
            'usado para a tela de pedido venda
            If PedidoAddItem.Visible Then
                My.Forms.PedidoAddItem.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
                Me.Close()
                Me.Dispose()
            End If

            'vai para tela de orcamentoitens
            If OrçamentoItens.Visible Then
                OrçamentoItens.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
                Me.Close()
                Me.Dispose()
            End If

            'Vai para tela de OSorcamentoitens
            If OSorçamentoItens.Visible Then
                OSorçamentoItens.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.Produtos.Visible = True Then
                My.Forms.Produtos.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                My.Forms.Produtos.LocalizaDados()
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ProdutoEstoqueConsulta.Visible = True Then
                My.Forms.ProdutoEstoqueConsulta.Produto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ProducaoAddItem.Visible = True Then
                My.Forms.ProducaoAddItem.Produto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ProdutoEstoqueAtualizar.Visible = True Then
                My.Forms.ProdutoEstoqueAtualizar.Produto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ProdutoSaldoEstoque.Visible = True Then
                My.Forms.ProdutoSaldoEstoque.Produto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ComprasAddItem.Visible = True Then
                My.Forms.ComprasAddItem.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ProdutoEtiquetas.Visible = True Then
                My.Forms.ProdutoEtiquetas.Produto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ComprasRelat.Visible = True Then
                My.Forms.ComprasRelat.Produto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.NfiscalLancaItens.Visible = True Then
                My.Forms.NfiscalLancaItens.Produto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ProdutoRelat.Visible = True Then
                My.Forms.ProdutoRelat.Produto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ProdutoEstoqueAjuste.Visible = True Then
                My.Forms.ProdutoEstoqueAjuste.Produto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.EstoqueTransferencia.Visible = True Then
                My.Forms.EstoqueTransferencia.CodigoProduto.Text = Me.DgvItem.CurrentRow.Cells(0).Value
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.SellShoes.Visible = True Then
                If UsarGrade = False Then
                    My.Forms.SellShoes.CodBarra.Text &= Me.DgvItem.CurrentRow.Cells("CodBarra").Value
                End If
                Me.Close()
                Me.Dispose()
                Return
            End If

            If My.Forms.SellShoesOrcamento.Visible = True Then
                If UsarGrade = False Then
                    My.Forms.SellShoesOrcamento.CodBarra.Text &= Me.DgvItem.CurrentRow.Cells("CodBarra").Value
                End If
                Me.Close()
                Me.Dispose()
            End If

            If My.Forms.ProdutoGradeEstoqueAjuste.Visible = True Then
                My.Forms.ProdutoGradeEstoqueAjuste.Produto.Text = Me.DgvItem.CurrentRow.Cells("codigo").Value
                Me.Close()
                Me.Dispose()
                Return
            End If

        End If
    End Sub

    Private Sub DgvItem_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvItem.SelectionChanged
        Try
            Me.lblMensagem.Text = Convert.ToString(Me.DgvItem.CurrentRow.Cells("greferencia").Value)
            Me.lbldescProd.Text = Convert.ToString(Me.DgvItem.CurrentRow.Cells("Desc").Value)
            VisualizaFoto()
        Catch ex As Exception
            Me.lblMensagem.Text = ""
            Me.lbldescProd.Text = ""
        End Try
    End Sub
End Class