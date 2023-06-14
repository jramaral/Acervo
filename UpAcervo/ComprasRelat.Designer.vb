<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComprasRelat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PainelPeriodo = New System.Windows.Forms.Panel()
        Me.DataFinal = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DataInicial = New TexBoxFocusNet.TextBoxFocusNet()
        Me.PainelFornecedor = New System.Windows.Forms.Panel()
        Me.FornecedorDesc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Fornecedor = New TexBoxFocusNet.TextBoxFocusNet()
        Me.PainelProdutos = New System.Windows.Forms.Panel()
        Me.ProdutoDesc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Produto = New TexBoxFocusNet.TextBoxFocusNet()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.Visualizar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.A22 = New System.Windows.Forms.RadioButton()
        Me.A6 = New System.Windows.Forms.RadioButton()
        Me.A21 = New System.Windows.Forms.RadioButton()
        Me.A20 = New System.Windows.Forms.RadioButton()
        Me.A3 = New System.Windows.Forms.RadioButton()
        Me.A2 = New System.Windows.Forms.RadioButton()
        Me.A5 = New System.Windows.Forms.RadioButton()
        Me.A4 = New System.Windows.Forms.RadioButton()
        Me.compraCFOP = New System.Windows.Forms.RadioButton()
        Me.A1 = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PainelPeriodo.SuspendLayout
        Me.PainelFornecedor.SuspendLayout
        Me.PainelProdutos.SuspendLayout
        Me.PanelEx1.SuspendLayout
        Me.GroupPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'PainelPeriodo
        '
        Me.PainelPeriodo.BackColor = System.Drawing.Color.Transparent
        Me.PainelPeriodo.Controls.Add(Me.DataFinal)
        Me.PainelPeriodo.Controls.Add(Me.Label9)
        Me.PainelPeriodo.Controls.Add(Me.DataInicial)
        Me.PainelPeriodo.Location = New System.Drawing.Point(8, 209)
        Me.PainelPeriodo.Name = "PainelPeriodo"
        Me.PainelPeriodo.Size = New System.Drawing.Size(328, 28)
        Me.PainelPeriodo.TabIndex = 2
        Me.PainelPeriodo.Visible = false
        '
        'DataFinal
        '
        Me.DataFinal.AceitaColarTexto = true
        Me.DataFinal.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DataFinal.CasasDecimais = 0
        Me.DataFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataFinal.CPObrigatorio = false
        Me.DataFinal.CPObrigatorioMsg = Nothing
        Me.DataFinal.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataFinal.FlatBorder = false
        Me.DataFinal.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataFinal.FocusColor = System.Drawing.Color.Empty
        Me.DataFinal.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataFinal.HighlightBorderOnEnter = false
        Me.DataFinal.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataFinal.Location = New System.Drawing.Point(219, 3)
        Me.DataFinal.MaxLength = 10
        Me.DataFinal.Name = "DataFinal"
        Me.DataFinal.PreencherZeroEsqueda = false
        Me.DataFinal.RegraValidação = Nothing
        Me.DataFinal.RegraValidaçãoMensagem = Nothing
        Me.DataFinal.Size = New System.Drawing.Size(100, 20)
        Me.DataFinal.TabIndex = 2
        Me.DataFinal.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataFinal.ValorPadrao = Nothing
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Informe o Período"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataInicial
        '
        Me.DataInicial.AceitaColarTexto = true
        Me.DataInicial.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DataInicial.CasasDecimais = 0
        Me.DataInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataInicial.CPObrigatorio = false
        Me.DataInicial.CPObrigatorioMsg = Nothing
        Me.DataInicial.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataInicial.FlatBorder = false
        Me.DataInicial.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataInicial.FocusColor = System.Drawing.Color.Empty
        Me.DataInicial.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataInicial.HighlightBorderOnEnter = false
        Me.DataInicial.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataInicial.Location = New System.Drawing.Point(113, 3)
        Me.DataInicial.MaxLength = 10
        Me.DataInicial.Name = "DataInicial"
        Me.DataInicial.PreencherZeroEsqueda = false
        Me.DataInicial.RegraValidação = Nothing
        Me.DataInicial.RegraValidaçãoMensagem = Nothing
        Me.DataInicial.Size = New System.Drawing.Size(100, 20)
        Me.DataInicial.TabIndex = 1
        Me.DataInicial.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataInicial.ValorPadrao = Nothing
        '
        'PainelFornecedor
        '
        Me.PainelFornecedor.BackColor = System.Drawing.Color.Transparent
        Me.PainelFornecedor.Controls.Add(Me.FornecedorDesc)
        Me.PainelFornecedor.Controls.Add(Me.Label1)
        Me.PainelFornecedor.Controls.Add(Me.Fornecedor)
        Me.PainelFornecedor.Location = New System.Drawing.Point(8, 243)
        Me.PainelFornecedor.Name = "PainelFornecedor"
        Me.PainelFornecedor.Size = New System.Drawing.Size(548, 52)
        Me.PainelFornecedor.TabIndex = 4
        '
        'FornecedorDesc
        '
        Me.FornecedorDesc.AceitaColarTexto = true
        Me.FornecedorDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.FornecedorDesc.CasasDecimais = 0
        Me.FornecedorDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.FornecedorDesc.CPObrigatorio = false
        Me.FornecedorDesc.CPObrigatorioMsg = Nothing
        Me.FornecedorDesc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.FornecedorDesc.FlatBorder = false
        Me.FornecedorDesc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.FornecedorDesc.FocusColor = System.Drawing.Color.Empty
        Me.FornecedorDesc.FocusColorEnd = System.Drawing.Color.Empty
        Me.FornecedorDesc.HighlightBorderOnEnter = false
        Me.FornecedorDesc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.FornecedorDesc.Location = New System.Drawing.Point(113, 29)
        Me.FornecedorDesc.Name = "FornecedorDesc"
        Me.FornecedorDesc.PreencherZeroEsqueda = false
        Me.FornecedorDesc.RegraValidação = Nothing
        Me.FornecedorDesc.RegraValidaçãoMensagem = Nothing
        Me.FornecedorDesc.Size = New System.Drawing.Size(297, 20)
        Me.FornecedorDesc.TabIndex = 1
        Me.FornecedorDesc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.FornecedorDesc.ValorPadrao = Nothing
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Inf. o Fornecedor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Fornecedor
        '
        Me.Fornecedor.AceitaColarTexto = true
        Me.Fornecedor.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Fornecedor.CasasDecimais = 0
        Me.Fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Fornecedor.CPObrigatorio = false
        Me.Fornecedor.CPObrigatorioMsg = Nothing
        Me.Fornecedor.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Fornecedor.FlatBorder = false
        Me.Fornecedor.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Fornecedor.FocusColor = System.Drawing.Color.Empty
        Me.Fornecedor.FocusColorEnd = System.Drawing.Color.Empty
        Me.Fornecedor.HighlightBorderOnEnter = false
        Me.Fornecedor.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Fornecedor.Location = New System.Drawing.Point(113, 3)
        Me.Fornecedor.Name = "Fornecedor"
        Me.Fornecedor.PreencherZeroEsqueda = false
        Me.Fornecedor.RegraValidação = Nothing
        Me.Fornecedor.RegraValidaçãoMensagem = Nothing
        Me.Fornecedor.Size = New System.Drawing.Size(65, 20)
        Me.Fornecedor.TabIndex = 0
        Me.Fornecedor.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Fornecedor.ValorPadrao = Nothing
        '
        'PainelProdutos
        '
        Me.PainelProdutos.BackColor = System.Drawing.Color.Transparent
        Me.PainelProdutos.Controls.Add(Me.ProdutoDesc)
        Me.PainelProdutos.Controls.Add(Me.Label2)
        Me.PainelProdutos.Controls.Add(Me.Produto)
        Me.PainelProdutos.Location = New System.Drawing.Point(8, 301)
        Me.PainelProdutos.Name = "PainelProdutos"
        Me.PainelProdutos.Size = New System.Drawing.Size(548, 52)
        Me.PainelProdutos.TabIndex = 5
        '
        'ProdutoDesc
        '
        Me.ProdutoDesc.AceitaColarTexto = true
        Me.ProdutoDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.ProdutoDesc.CasasDecimais = 0
        Me.ProdutoDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ProdutoDesc.CPObrigatorio = false
        Me.ProdutoDesc.CPObrigatorioMsg = Nothing
        Me.ProdutoDesc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ProdutoDesc.FlatBorder = false
        Me.ProdutoDesc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ProdutoDesc.FocusColor = System.Drawing.Color.Empty
        Me.ProdutoDesc.FocusColorEnd = System.Drawing.Color.Empty
        Me.ProdutoDesc.HighlightBorderOnEnter = false
        Me.ProdutoDesc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ProdutoDesc.Location = New System.Drawing.Point(113, 29)
        Me.ProdutoDesc.Name = "ProdutoDesc"
        Me.ProdutoDesc.PreencherZeroEsqueda = false
        Me.ProdutoDesc.RegraValidação = Nothing
        Me.ProdutoDesc.RegraValidaçãoMensagem = Nothing
        Me.ProdutoDesc.Size = New System.Drawing.Size(297, 20)
        Me.ProdutoDesc.TabIndex = 1
        Me.ProdutoDesc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ProdutoDesc.ValorPadrao = Nothing
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Informe o Produto"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Produto
        '
        Me.Produto.AceitaColarTexto = true
        Me.Produto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Produto.CasasDecimais = 0
        Me.Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Produto.CPObrigatorio = false
        Me.Produto.CPObrigatorioMsg = Nothing
        Me.Produto.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Produto.FlatBorder = false
        Me.Produto.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Produto.FocusColor = System.Drawing.Color.Empty
        Me.Produto.FocusColorEnd = System.Drawing.Color.Empty
        Me.Produto.HighlightBorderOnEnter = false
        Me.Produto.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Produto.Location = New System.Drawing.Point(113, 3)
        Me.Produto.Name = "Produto"
        Me.Produto.PreencherZeroEsqueda = false
        Me.Produto.RegraValidação = Nothing
        Me.Produto.RegraValidaçãoMensagem = Nothing
        Me.Produto.Size = New System.Drawing.Size(65, 20)
        Me.Produto.TabIndex = 0
        Me.Produto.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Produto.ValorPadrao = Nothing
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.PanelEx1.Controls.Add(Me.PainelProdutos)
        Me.PanelEx1.Controls.Add(Me.Fechar)
        Me.PanelEx1.Controls.Add(Me.PainelFornecedor)
        Me.PanelEx1.Controls.Add(Me.Visualizar)
        Me.PanelEx1.Controls.Add(Me.PainelPeriodo)
        Me.PanelEx1.Controls.Add(Me.GroupPanel1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(572, 418)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Location = New System.Drawing.Point(465, 371)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(91, 29)
        Me.Fechar.TabIndex = 1
        Me.Fechar.Text = "Fechar"
        '
        'Visualizar
        '
        Me.Visualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Visualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Visualizar.Location = New System.Drawing.Point(368, 371)
        Me.Visualizar.Name = "Visualizar"
        Me.Visualizar.Size = New System.Drawing.Size(91, 29)
        Me.Visualizar.TabIndex = 0
        Me.Visualizar.Text = "Visualizar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.A22)
        Me.GroupPanel1.Controls.Add(Me.A6)
        Me.GroupPanel1.Controls.Add(Me.A21)
        Me.GroupPanel1.Controls.Add(Me.A20)
        Me.GroupPanel1.Controls.Add(Me.A3)
        Me.GroupPanel1.Controls.Add(Me.A2)
        Me.GroupPanel1.Controls.Add(Me.A5)
        Me.GroupPanel1.Controls.Add(Me.A4)
        Me.GroupPanel1.Controls.Add(Me.compraCFOP)
        Me.GroupPanel1.Controls.Add(Me.A1)
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(559, 200)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "Opções"
        '
        'A22
        '
        Me.A22.AutoSize = true
        Me.A22.ForeColor = System.Drawing.Color.Black
        Me.A22.Location = New System.Drawing.Point(4, 129)
        Me.A22.Name = "A22"
        Me.A22.Size = New System.Drawing.Size(244, 20)
        Me.A22.TabIndex = 8
        Me.A22.Text = "Compras no Período (Conferência) Impostos"
        Me.A22.UseVisualStyleBackColor = true
        Me.A22.Visible = false
        '
        'A6
        '
        Me.A6.AutoSize = true
        Me.A6.ForeColor = System.Drawing.Color.Black
        Me.A6.Location = New System.Drawing.Point(4, 53)
        Me.A6.Name = "A6"
        Me.A6.Size = New System.Drawing.Size(229, 20)
        Me.A6.TabIndex = 7
        Me.A6.Text = "Compras no Período Fornecedor por Tipo"
        Me.ToolTip1.SetToolTip(Me.A6, "Conferência de notas lançadas não confirmadas")
        Me.A6.UseVisualStyleBackColor = true
        Me.A6.Visible = false
        '
        'A21
        '
        Me.A21.AutoSize = true
        Me.A21.ForeColor = System.Drawing.Color.Black
        Me.A21.Location = New System.Drawing.Point(283, 33)
        Me.A21.Name = "A21"
        Me.A21.Size = New System.Drawing.Size(259, 20)
        Me.A21.TabIndex = 5
        Me.A21.Text = "Documento de entrada no Período/Fornecedor"
        Me.A21.UseVisualStyleBackColor = true
        '
        'A20
        '
        Me.A20.AutoSize = true
        Me.A20.ForeColor = System.Drawing.Color.Black
        Me.A20.Location = New System.Drawing.Point(283, 8)
        Me.A20.Name = "A20"
        Me.A20.Size = New System.Drawing.Size(195, 20)
        Me.A20.TabIndex = 4
        Me.A20.Text = "Documento de entrada no Período"
        Me.A20.UseVisualStyleBackColor = true
        '
        'A3
        '
        Me.A3.AutoSize = true
        Me.A3.ForeColor = System.Drawing.Color.Black
        Me.A3.Location = New System.Drawing.Point(4, 78)
        Me.A3.Name = "A3"
        Me.A3.Size = New System.Drawing.Size(181, 20)
        Me.A3.TabIndex = 2
        Me.A3.Text = "Compras de Produto no Período"
        Me.A3.UseVisualStyleBackColor = true
        Me.A3.Visible = false
        '
        'A2
        '
        Me.A2.AutoSize = true
        Me.A2.ForeColor = System.Drawing.Color.Black
        Me.A2.Location = New System.Drawing.Point(4, 28)
        Me.A2.Name = "A2"
        Me.A2.Size = New System.Drawing.Size(205, 20)
        Me.A2.TabIndex = 1
        Me.A2.Text = "Compras no Período por Fornecedor"
        Me.A2.UseVisualStyleBackColor = true
        '
        'A5
        '
        Me.A5.AutoSize = true
        Me.A5.ForeColor = System.Drawing.Color.Black
        Me.A5.Location = New System.Drawing.Point(283, 59)
        Me.A5.Name = "A5"
        Me.A5.Size = New System.Drawing.Size(203, 20)
        Me.A5.TabIndex = 6
        Me.A5.Text = "Notas Fiscais no Período (Sintético)"
        Me.A5.UseVisualStyleBackColor = true
        Me.A5.Visible = false
        '
        'A4
        '
        Me.A4.AutoSize = true
        Me.A4.ForeColor = System.Drawing.Color.Black
        Me.A4.Location = New System.Drawing.Point(4, 103)
        Me.A4.Name = "A4"
        Me.A4.Size = New System.Drawing.Size(321, 20)
        Me.A4.TabIndex = 3
        Me.A4.Text = "Compras no Período (Conferência) - Notas não Confirmadas"
        Me.ToolTip1.SetToolTip(Me.A4, "Conferência de notas lançadas não confirmadas")
        Me.A4.UseVisualStyleBackColor = true
        Me.A4.Visible = false
        '
        'compraCFOP
        '
        Me.compraCFOP.AutoSize = true
        Me.compraCFOP.ForeColor = System.Drawing.Color.Black
        Me.compraCFOP.Location = New System.Drawing.Point(4, 156)
        Me.compraCFOP.Name = "compraCFOP"
        Me.compraCFOP.Size = New System.Drawing.Size(174, 20)
        Me.compraCFOP.TabIndex = 0
        Me.compraCFOP.Text = "Compras no Período por CFOP"
        Me.compraCFOP.UseVisualStyleBackColor = true
        Me.compraCFOP.Visible = false
        '
        'A1
        '
        Me.A1.AutoSize = true
        Me.A1.ForeColor = System.Drawing.Color.Black
        Me.A1.Location = New System.Drawing.Point(4, 3)
        Me.A1.Name = "A1"
        Me.A1.Size = New System.Drawing.Size(124, 20)
        Me.A1.TabIndex = 0
        Me.A1.Text = "Compras no Período"
        Me.A1.UseVisualStyleBackColor = true
        '
        'ComprasRelat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(202,Byte),Integer), CType(CType(217,Byte),Integer), CType(CType(222,Byte),Integer))
        Me.ClientSize = New System.Drawing.Size(572, 418)
        Me.ControlBox = false
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = true
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ComprasRelat"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatórios de Compras - T130"
        Me.PainelPeriodo.ResumeLayout(false)
        Me.PainelPeriodo.PerformLayout
        Me.PainelFornecedor.ResumeLayout(false)
        Me.PainelFornecedor.PerformLayout
        Me.PainelProdutos.ResumeLayout(false)
        Me.PainelProdutos.PerformLayout
        Me.PanelEx1.ResumeLayout(false)
        Me.GroupPanel1.ResumeLayout(false)
        Me.GroupPanel1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents PainelPeriodo As System.Windows.Forms.Panel
    Friend WithEvents DataFinal As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataInicial As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents PainelFornecedor As System.Windows.Forms.Panel
    Friend WithEvents FornecedorDesc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Fornecedor As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents PainelProdutos As System.Windows.Forms.Panel
    Friend WithEvents ProdutoDesc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Produto As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents A21 As System.Windows.Forms.RadioButton
    Friend WithEvents A20 As System.Windows.Forms.RadioButton
    Friend WithEvents A3 As System.Windows.Forms.RadioButton
    Friend WithEvents A2 As System.Windows.Forms.RadioButton
    Friend WithEvents A1 As System.Windows.Forms.RadioButton
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Visualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents A4 As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents A5 As System.Windows.Forms.RadioButton
    Friend WithEvents A6 As System.Windows.Forms.RadioButton
    Friend WithEvents A22 As System.Windows.Forms.RadioButton
    Friend WithEvents compraCFOP As System.Windows.Forms.RadioButton
End Class
