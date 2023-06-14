Public Class SeletorAddItem

    Dim EstoqueDisponivel As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal param As Integer)
        InitializeComponent()
        EstoqueDisponivel = param
        QtdSelecionado.Text = param
    End Sub
    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub QtdSelecionado_Leave(sender As Object, e As EventArgs) Handles QtdSelecionado.Leave

        If String.IsNullOrEmpty(Me.QtdSelecionado.Text) Then
            MessageBox.Show("O usuário deve informar uma quantidade para adicionar", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.QtdSelecionado.Text = FormatNumber(My.Forms.LocacaoSeletor.Total_Disponivel.Text, 2)
            Me.QtdSelecionado.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub btConfirmar_Click(sender As Object, e As EventArgs) Handles btConfirmar.Click

        If CInt(Me.QtdSelecionado.Text) > EstoqueDisponivel Then
            MessageBox.Show("A quantidade selecionada não pode ser maior que a disponivel.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.QtdSelecionado.Text = EstoqueDisponivel
            Me.QtdSelecionado.Focus()
            Exit Sub
        End If




        Dim newRow As DataRow = My.Forms.LocacaoSeletor.Selecionados.NewRow

        newRow("ProdutoCod") = My.Forms.LocacaoSeletor.CodProduto.Text
        newRow("ProdutoNome") = My.Forms.LocacaoSeletor.ProdutoNome.Text
        newRow("ProdutoQtd") = Me.QtdSelecionado.Text
        newRow("ProdutoUnitario") = FormatNumber(NzZero(My.Forms.LocacaoSeletor.UnitarioLoc.Text), 2)
        newRow("ProdutoUnitarioDecorador") = FormatNumber(NzZero(My.Forms.LocacaoSeletor.UnitarioLocDecorador.Text), 2)
        newRow("ProdutoUnitarioPromocao") = FormatNumber(NzZero(My.Forms.LocacaoSeletor.UnitarioLocPromocao.Text), 2)
        newRow("ValorVenda2") = FormatNumber(NzZero(My.Forms.LocacaoSeletor.ValorReposicao), 2)
        Dim Total As Double = NzZero(Me.QtdSelecionado.Text) * NzZero(My.Forms.LocacaoSeletor.UnitarioLoc.Text)
        newRow("ProdutoTotal") = FormatNumber(Total, 2)

        Dim TotalDiariaAmais As Double = NzZero(Total) * NzZero(My.Forms.LocacaoSeletor.DiariaAmais.Text)
        newRow("ProdutoTotalDiaria") = FormatNumber(TotalDiariaAmais, 2)


        My.Forms.LocacaoSeletor.Selecionados.Rows.Add(newRow)

        

        Me.Close()
        Me.Dispose()

    End Sub
End Class