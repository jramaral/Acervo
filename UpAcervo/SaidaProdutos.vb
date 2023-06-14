Imports System.Data.OleDb

Public Class SaidaProdutos
    Dim valida As Boolean = False
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.txtDataMovimentacao.Text = DataDia
    End Sub
    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

        Dim f As New LocacaoProdutoProcura(Me)

        f.ShowDialog()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub txtQtde_Leave(sender As Object, e As EventArgs) Handles txtQtde.Leave

        If (Convert.ToInt32(txtQtde.Text) > 0) And (Convert.ToInt32(txtQtde.Text) <= Convert.ToInt32(txtEstoqueAtual.Text)) Then
            'valor da saida tem que ser maior q zero e menor igual ao estoque atual
            valida = True
        Else
            valida = False
        End If

    End Sub
    Public Sub LocalizaDados()

        
        If Me.txtCodigoProduto.Text = "" Then
            Exit Sub
        End If

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "SELECT * FROM Produtos WHERE Produtos.CodigoProduto = " & Me.txtCodigoProduto.Text & " and Produtos.Inativo = False and ControlaEstoque='SIM'"

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Me.txtCodigoProduto.Text = DR.Item("CodigoProduto") & ""
            Me.txtDescricaoProduto.Text = DR.Item("Descrição") & ""
            Me.txtEstoqueAtual.Text = FormatNumber(Nz(DR.Item("QuantidadeEstoque"), 3))

            DR.Close()

        End If

    End Sub
    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        If valida = True Then

            Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()

            Dim Transacao As OleDbTransaction = CNN.BeginTransaction()
            Dim CmdEstoque As OleDbCommand = CNN.CreateCommand
            Dim CmdEstProd As OleDbCommand = CNN.CreateCommand

            CmdEstoque.Transaction = Transacao
            CmdEstProd.Transaction = Transacao

            Try


                'Fazer o Lancamento na tabela EstoqueUP e atualização na tabela de Produtos
                CmdEstoque.CommandText = "INSERT INTO EstoqueUP (CodigoProduto, Qtd, Tipo, IdLancamento, DataLancamento, PedidoOrdem, Prg, ClienteFornecedor, NFDoc) VALUES ('" & Me.txtCodigoProduto.Text & "',  '" & Me.txtQtde.Text * -1 & "','S', 0 ,#" & CDate(DataDia) & "#, 0 ,'SAIDA','DONA FUJII',0)"

                CmdEstoque.ExecuteNonQuery()


                ' CmdEstProd.CommandText = "SELECT SUM(Qtd) AS Estoque FROM EstoqueUP GROUP BY CodigoProduto HAVING CodigoProduto = " & Me.txtCodigoProduto.Text
                CmdEstProd.CommandText = "SELECT Sum(Qtd) AS Estoque FROM EstoqueUP WHERE (((Tipo) In ('E','S'))) AND (CodigoProduto)=" & Me.txtCodigoProduto.Text


                Dim Testoque As Integer = CmdEstProd.ExecuteScalar

                CmdEstProd.CommandText = "Update Produtos set QuantidadeEstoque = @1  Where CodigoProduto = " & txtCodigoProduto.Text
                CmdEstProd.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUM(Testoque)))

                CmdEstProd.ExecuteNonQuery()

                Transacao.Commit()
                MessageBox.Show("Saída efetudado com sucesso!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.txtCodigoProduto.Clear()
                Me.txtDescricaoProduto.Clear()
                Me.txtEstoqueAtual.Clear()
                Me.txtQtde.Clear()
                Me.txtCodigoProduto.Focus()
                CNN.Close()

            Catch ex As Exception
                Transacao.Rollback()
            End Try


        End If



    End Sub

   

    Private Sub limpar_Click(sender As Object, e As EventArgs) Handles limpar.Click
        Me.txtCodigoProduto.Clear()
        Me.txtDescricaoProduto.Clear()
        Me.txtEstoqueAtual.Clear()
        Me.txtQtde.Clear()
        Me.txtCodigoProduto.Focus()
    End Sub
End Class