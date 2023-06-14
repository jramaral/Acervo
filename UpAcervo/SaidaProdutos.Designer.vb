<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaidaProdutos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaidaProdutos))
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEstoqueAtual = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDataMovimentacao = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescricaoProduto = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQtde = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtCodigoProduto = New TexBoxFocusNet.TextBoxFocusNet()
        Me.btnConfirmar = New DevComponents.DotNetBar.ButtonX()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.limpar = New System.Windows.Forms.Label()
        Me.Fundo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fundo
        '
        Me.Fundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Fundo.Controls.Add(Me.limpar)
        Me.Fundo.Controls.Add(Me.Label3)
        Me.Fundo.Controls.Add(Me.txtEstoqueAtual)
        Me.Fundo.Controls.Add(Me.Label5)
        Me.Fundo.Controls.Add(Me.Label4)
        Me.Fundo.Controls.Add(Me.txtDataMovimentacao)
        Me.Fundo.Controls.Add(Me.Label2)
        Me.Fundo.Controls.Add(Me.txtDescricaoProduto)
        Me.Fundo.Controls.Add(Me.Label1)
        Me.Fundo.Controls.Add(Me.txtQtde)
        Me.Fundo.Controls.Add(Me.txtCodigoProduto)
        Me.Fundo.Controls.Add(Me.btnConfirmar)
        Me.Fundo.Controls.Add(Me.btFechar)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(580, 239)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(326, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 22)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Estoque Atual"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEstoqueAtual
        '
        Me.txtEstoqueAtual.AceitaColarTexto = True
        Me.txtEstoqueAtual.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtEstoqueAtual.CasasDecimais = 0
        Me.txtEstoqueAtual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstoqueAtual.CPObrigatorio = False
        Me.txtEstoqueAtual.CPObrigatorioMsg = Nothing
        Me.txtEstoqueAtual.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtEstoqueAtual.FlatBorder = False
        Me.txtEstoqueAtual.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtEstoqueAtual.FocusColor = System.Drawing.Color.MistyRose
        Me.txtEstoqueAtual.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtEstoqueAtual.HighlightBorderOnEnter = False
        Me.txtEstoqueAtual.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtEstoqueAtual.Location = New System.Drawing.Point(420, 102)
        Me.txtEstoqueAtual.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtEstoqueAtual.MaxLength = 15
        Me.txtEstoqueAtual.Name = "txtEstoqueAtual"
        Me.txtEstoqueAtual.PreencherZeroEsqueda = False
        Me.txtEstoqueAtual.ReadOnly = True
        Me.txtEstoqueAtual.RegraValidação = Nothing
        Me.txtEstoqueAtual.RegraValidaçãoMensagem = Nothing
        Me.txtEstoqueAtual.Size = New System.Drawing.Size(126, 23)
        Me.txtEstoqueAtual.TabIndex = 10
        Me.txtEstoqueAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEstoqueAtual.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.txtEstoqueAtual.ValorPadrao = Nothing
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(43, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 22)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Código Produto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(344, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 22)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Data"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDataMovimentacao
        '
        Me.txtDataMovimentacao.AceitaColarTexto = True
        Me.txtDataMovimentacao.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.txtDataMovimentacao.CasasDecimais = 0
        Me.txtDataMovimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataMovimentacao.CPObrigatorio = False
        Me.txtDataMovimentacao.CPObrigatorioMsg = Nothing
        Me.txtDataMovimentacao.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtDataMovimentacao.FlatBorder = False
        Me.txtDataMovimentacao.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtDataMovimentacao.FocusColor = System.Drawing.Color.MistyRose
        Me.txtDataMovimentacao.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtDataMovimentacao.HighlightBorderOnEnter = False
        Me.txtDataMovimentacao.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtDataMovimentacao.Location = New System.Drawing.Point(420, 28)
        Me.txtDataMovimentacao.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtDataMovimentacao.MaxLength = 120
        Me.txtDataMovimentacao.Name = "txtDataMovimentacao"
        Me.txtDataMovimentacao.PreencherZeroEsqueda = False
        Me.txtDataMovimentacao.RegraValidação = Nothing
        Me.txtDataMovimentacao.RegraValidaçãoMensagem = Nothing
        Me.txtDataMovimentacao.Size = New System.Drawing.Size(126, 23)
        Me.txtDataMovimentacao.TabIndex = 1
        Me.txtDataMovimentacao.TabStop = False
        Me.txtDataMovimentacao.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtDataMovimentacao.ValorPadrao = Nothing
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 22)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Descrição"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescricaoProduto
        '
        Me.txtDescricaoProduto.AceitaColarTexto = True
        Me.txtDescricaoProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtDescricaoProduto.CasasDecimais = 0
        Me.txtDescricaoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescricaoProduto.CPObrigatorio = False
        Me.txtDescricaoProduto.CPObrigatorioMsg = Nothing
        Me.txtDescricaoProduto.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtDescricaoProduto.FlatBorder = False
        Me.txtDescricaoProduto.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtDescricaoProduto.FocusColor = System.Drawing.Color.MistyRose
        Me.txtDescricaoProduto.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtDescricaoProduto.HighlightBorderOnEnter = False
        Me.txtDescricaoProduto.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtDescricaoProduto.Location = New System.Drawing.Point(162, 56)
        Me.txtDescricaoProduto.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtDescricaoProduto.MaxLength = 120
        Me.txtDescricaoProduto.Multiline = True
        Me.txtDescricaoProduto.Name = "txtDescricaoProduto"
        Me.txtDescricaoProduto.PreencherZeroEsqueda = False
        Me.txtDescricaoProduto.ReadOnly = True
        Me.txtDescricaoProduto.RegraValidação = Nothing
        Me.txtDescricaoProduto.RegraValidaçãoMensagem = Nothing
        Me.txtDescricaoProduto.Size = New System.Drawing.Size(384, 36)
        Me.txtDescricaoProduto.TabIndex = 2
        Me.txtDescricaoProduto.TabStop = False
        Me.txtDescricaoProduto.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtDescricaoProduto.ValorPadrao = Nothing
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 22)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Quantidade"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQtde
        '
        Me.txtQtde.AceitaColarTexto = True
        Me.txtQtde.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtQtde.CasasDecimais = 0
        Me.txtQtde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQtde.CPObrigatorio = False
        Me.txtQtde.CPObrigatorioMsg = Nothing
        Me.txtQtde.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtQtde.FlatBorder = False
        Me.txtQtde.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtQtde.FocusColor = System.Drawing.Color.MistyRose
        Me.txtQtde.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtQtde.HighlightBorderOnEnter = False
        Me.txtQtde.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtQtde.Location = New System.Drawing.Point(162, 102)
        Me.txtQtde.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtQtde.MaxLength = 15
        Me.txtQtde.Name = "txtQtde"
        Me.txtQtde.PreencherZeroEsqueda = False
        Me.txtQtde.RegraValidação = Nothing
        Me.txtQtde.RegraValidaçãoMensagem = Nothing
        Me.txtQtde.Size = New System.Drawing.Size(98, 23)
        Me.txtQtde.TabIndex = 3
        Me.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtQtde.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.txtQtde.ValorPadrao = Nothing
        '
        'txtCodigoProduto
        '
        Me.txtCodigoProduto.AceitaColarTexto = True
        Me.txtCodigoProduto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.txtCodigoProduto.CasasDecimais = 0
        Me.txtCodigoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoProduto.CPObrigatorio = False
        Me.txtCodigoProduto.CPObrigatorioMsg = Nothing
        Me.txtCodigoProduto.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtCodigoProduto.FlatBorder = False
        Me.txtCodigoProduto.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtCodigoProduto.FocusColor = System.Drawing.Color.MistyRose
        Me.txtCodigoProduto.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtCodigoProduto.HighlightBorderOnEnter = False
        Me.txtCodigoProduto.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtCodigoProduto.Location = New System.Drawing.Point(162, 26)
        Me.txtCodigoProduto.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtCodigoProduto.MaxLength = 120
        Me.txtCodigoProduto.Name = "txtCodigoProduto"
        Me.txtCodigoProduto.PreencherZeroEsqueda = False
        Me.txtCodigoProduto.RegraValidação = Nothing
        Me.txtCodigoProduto.RegraValidaçãoMensagem = Nothing
        Me.txtCodigoProduto.Size = New System.Drawing.Size(98, 23)
        Me.txtCodigoProduto.TabIndex = 0
        Me.txtCodigoProduto.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtCodigoProduto.ValorPadrao = Nothing
        '
        'btnConfirmar
        '
        Me.btnConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnConfirmar.Location = New System.Drawing.Point(280, 163)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(118, 45)
        Me.btnConfirmar.TabIndex = 4
        Me.btnConfirmar.Text = "Confirmar"
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Location = New System.Drawing.Point(405, 163)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(138, 45)
        Me.btFechar.TabIndex = 5
        Me.btFechar.Text = "Fechar"
        '
        'limpar
        '
        Me.limpar.BackColor = System.Drawing.Color.Transparent
        Me.limpar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.limpar.Image = CType(resources.GetObject("limpar.Image"), System.Drawing.Image)
        Me.limpar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.limpar.Location = New System.Drawing.Point(265, 26)
        Me.limpar.Name = "limpar"
        Me.limpar.Size = New System.Drawing.Size(25, 22)
        Me.limpar.TabIndex = 12
        Me.limpar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SaidaProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 239)
        Me.ControlBox = False
        Me.Controls.Add(Me.Fundo)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SaidaProdutos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saida de Produtos"
        Me.Fundo.ResumeLayout(False)
        Me.Fundo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnConfirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCodigoProduto As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDataMovimentacao As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescricaoProduto As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQtde As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEstoqueAtual As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents limpar As System.Windows.Forms.Label
End Class
