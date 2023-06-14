Public Class ProdutoGerarEtiqueta
    Dim data_campra, nome_produto, codigo_produto, tamanho As String
    Dim valor_prazo As Double
    Dim gerar As Boolean = False
    Dim da As OleDb.OleDbDataAdapter
    Dim ds As DataSet
    Dim oCB As OleDb.OleDbCommandBuilder
    Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
    Dim row As DataRow
    Dim i As Integer
    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click

        If gerar = True Then
            If MsgBox("Existem etiquetas geradas deseja excluí-las agora?", 36, "Mensagem") = MsgBoxResult.Yes Then
                excluir()
            Else
                oCB = New OleDb.OleDbCommandBuilder(da) 'usa o objeto Buidler para persiist dos daod do dataadaeter
                da.Update(ds, "Etiqueta") 'atualiza o data a com os valore so dataset no banco de dados.
                CNN.Close()
                gerar = False
            End If
        End If

        Me.Close()
        Me.Dispose()

    End Sub
    Private Sub Produto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Produto.Leave
        If Me.Produto.Text = "" Then
            Exit Sub
        End If

        Dim CON As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CON.Open()
        Dim Sql As String = "SELECT CodigoProduto, Descrição, DataUltimaCompra, ValorVenda FROM Produtos WHERE Produtos.CodigoProduto = " & Me.Produto.Text

        Dim CMD As New OleDb.OleDbCommand(Sql, CON)
        Dim DR As OleDb.OleDbDataReader



        DR = CMD.ExecuteReader
        DR.Read()
        Try

      
        If DR.HasRows Then

            data_campra = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(DR.Item("DataUltimaCompra")).ToShortDateString)
            nome_produto = DR.Item("Descrição").ToString
            valor_prazo = DR.Item("ValorVenda")
            codigo_produto = DR.Item("CodigoProduto").ToString
            Me.lblInfProduto.Text = nome_produto


            Else
            Me.lblInfProduto.Text = "Informação do produto"
            Me.txtQtd.Clear()

                Me.Produto.Clear()

                MessageBox.Show("Produto não encontrado." _
              & Microsoft.VisualBasic.ControlChars.CrLf & "Por favor tente novamente.", "Validação de dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If
        Catch ex As Exception
            Select Case Err.Number
                Case 13
                    MessageBox.Show("Este produto está com a data da compra vazio." _
                        & Microsoft.VisualBasic.ControlChars.CrLf & "Verifique no cadastro do produto.", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Select


        End Try
        DR.Close()
        CON.Close()

    End Sub

    Private Sub butGerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGerar.Click

        If Not (String.IsNullOrEmpty(Me.txtQtd.Text)) Then


            i = 0
            If gerar = False Then
                CNN.Open()
                Dim cmd1 As New OleDb.OleDbCommand("Select * from EtiquetaTemp where id<0", CNN)
                da = New OleDb.OleDbDataAdapter(cmd1)
                ds = New DataSet
                da.Fill(ds, "Etiqueta")

                gerar = True
            End If

            'Faço um for para dar um loop e criar as etiquetas
            For i = 1 To Me.txtQtd.Text
                row = ds.Tables(0).NewRow
                row("datacompra") = data_campra
                row("codigoproduto") = codigo_produto
                row("descricao") = nome_produto
                row("valorprazo") = valor_prazo

                ds.Tables("Etiqueta").Rows.Add(row) 'adiciona a linha na coleção rows do dataset


            Next

            MessageBox.Show("Operação realizada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtQtd.Clear()

            Me.Produto.Focus()
        Else
            MessageBox.Show("Operação inválida verifique se todos os campos estão preenchidos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Sub excluir()
        Dim CON As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CON.Open()
        Dim cmdExc As New OleDb.OleDbCommand("Delete * from EtiquetaTemp", CON)
        Try
            cmdExc.ExecuteNonQuery()
            CON.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        Try
            If gerar = True Then
                oCB = New OleDb.OleDbCommandBuilder(da) 'usa o objeto Buidler para persiist dos daod do dataadaeter
                da.Update(ds, "Etiqueta") 'atualiza o data a com os valore so dataset no banco de dados.
                CNN.Close()
                gerar = False

                RelatorioCarregar = "Etiqueta3CR"

                My.Forms.VisualizadorRelatorio.ShowDialog()
                excluir()
            Else

                RelatorioCarregar = "Etiqueta3CR"

                My.Forms.VisualizadorRelatorio.ShowDialog()
                excluir()
            End If

        Catch ex As Exception
            MessageBox.Show("Houve um erro na operação! Tente novamente.", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            CNN.Close()
        End Try
    End Sub

    Private Sub ProdutoGerarEtiqueta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class