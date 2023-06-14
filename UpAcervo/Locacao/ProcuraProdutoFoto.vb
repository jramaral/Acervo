Imports System.Data.OleDb
Imports System.Drawing
Imports Pesquisa
Imports System.IO

Public Class ProcuraProdutoFoto

    Private Sub PanelEx1_Click(sender As Object, e As EventArgs) Handles PanelEx1.Click

    End Sub

    Private Sub FecharToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FecharToolStripMenuItem.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tsExecutar_Click(sender As Object, e As EventArgs) Handles tsExecutar.Click

        listView.Clear()

        If String.IsNullOrEmpty(stComboBoxFilter.Text) Then
            MessageBox.Show("Escolha um filtro", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = ""

        Select Case stComboBoxFilter.Text
            Case "Todos"
                ' Sql = "SELECT Produtos.CodigoProduto, Produtos.Descrição, Produtos.UnidadeMedida, IIf([Tipo]=1,'PRODUTO',IIf([Tipo]=2,'MATERIA PRIMA',IIf([Tipo]=3,'ALMOXARIFADO',IIf([Tipo]=4,'IMOBILIZADO',IIf([Tipo]=5,'PROD. INDUST'))))) AS TP, ProdutoLocal.SetorLocalDesc, Produtos.QuantidadeEstoque, Produtos.ValorVenda, Marcas.Marca, Produtos.Referencia, Produtos.CodigoBarra, Produtos.ValorVenda2, Produtos.QtdeLocado FROM (Produtos LEFT JOIN ProdutoLocal ON Produtos.Localização = ProdutoLocal.SetorLocal) LEFT JOIN Marcas ON Produtos.Marca = Marcas.Codigo WHERE (((Produtos.Tipo)<>99) AND ((Produtos.Empresa)=" & CodEmpresa & ") AND ((Produtos.Inativo)=False));"
                Sql = "SELECT Produtos.CodigoProduto, Produtos.Descrição, Produtos.QuantidadeEstoque, ProdutosFoto.Foto, Produtos.Tipo FROM Produtos LEFT JOIN ProdutosFoto ON Produtos.CodigoProduto = ProdutosFoto.CodigoProduto WHERE (((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Tipo)=1));"
            Case "Descrição"
                Sql = "SELECT Produtos.CodigoProduto, Produtos.Descrição, Produtos.QuantidadeEstoque, ProdutosFoto.Foto, Produtos.Tipo FROM Produtos LEFT JOIN ProdutosFoto ON Produtos.CodigoProduto = ProdutosFoto.CodigoProduto WHERE (((Produtos.QuantidadeEstoque)>0) AND ((Produtos.Descrição) Like '%" & tsTxtTexto.Text & "%')   AND ((Produtos.Tipo)=1));"

        End Select

        Dim cmd As New OleDbCommand(Sql, CNN)
        Dim dr As OleDbDataReader

        dr = cmd.ExecuteReader


        Dim imgl As New ImageList

        Dim Define As New cquery()

        Dim listOfImages As New List(Of Image)()

        Dim i As Integer = 0
        Dim count As Integer = 0
        While (dr.Read)

            Try
                'dr.Item("descrição").ToString()

                If Not String.IsNullOrEmpty(dr.Item("foto").ToString()) Then

                    Dim imageBytes() As Byte = dr.Item("foto")
                    Dim memStm As New MemoryStream(imageBytes)
                    memStm.Seek(0, SeekOrigin.Begin)
                    Dim image1 As Image = Image.FromStream(memStm)

                    imgl.ImageSize = New Size(94, 94)
                    imgl.ColorDepth = ColorDepth.Depth32Bit
                    imgl.Images.Add(image1)
                    Define.DefListView(listView, "Cod:" & dr.Item("codigoproduto").ToString() & Chr(13) & "Estque: " & dr.Item("QuantidadeEstoque").ToString(), i, imgl)
                    listView.Items(count).ToolTipText = dr.Item("descrição").ToString()
                    i += 1

                Else
                    Define.DefListView(listView, "Cod:" & dr.Item("codigoproduto").ToString() & Chr(13) & "Estque: " & dr.Item("QuantidadeEstoque").ToString(), imgl)
                    listView.Items(count).ToolTipText = dr.Item("descrição").ToString()
                End If

                count += 1

            Catch ex As Exception

            End Try
        End While

        dr.Close()


    End Sub
End Class