<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NFeValidarDados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NFeValidarDados))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.Wizard1 = New DevComponents.DotNetBar.Wizard()
        Me.WizardPage1 = New DevComponents.DotNetBar.WizardPage()
        Me.infCpl = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Msg = New System.Windows.Forms.Label()
        Me.Pedido = New System.Windows.Forms.Label()
        Me.btLocalizaInfAdicionais = New System.Windows.Forms.Button()
        Me.btSalvarInfCPL = New System.Windows.Forms.Button()
        Me.WizardPage3 = New DevComponents.DotNetBar.WizardPage()
        Me.BrEnviar = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.btLimparProdutos = New System.Windows.Forms.Button()
        Me.btTodosProdutos = New System.Windows.Forms.Button()
        Me.Lista = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cValorProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelEx1.SuspendLayout()
        Me.Wizard1.SuspendLayout()
        Me.WizardPage1.SuspendLayout()
        Me.WizardPage3.SuspendLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.PanelEx1.Controls.Add(Me.Wizard1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(784, 561)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'Wizard1
        '
        Me.Wizard1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.Wizard1.BackButtonText = "< Anterior"
        Me.Wizard1.BackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Wizard1.BackgroundImage = CType(resources.GetObject("Wizard1.BackgroundImage"), System.Drawing.Image)
        Me.Wizard1.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007
        Me.Wizard1.CancelButtonText = "Fechar"
        Me.Wizard1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Wizard1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Wizard1.FinishButtonTabIndex = 3
        Me.Wizard1.FinishButtonText = "Gerar"
        '
        '
        '
        Me.Wizard1.FooterStyle.BackColor = System.Drawing.Color.Transparent
        Me.Wizard1.FooterStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Wizard1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Wizard1.HeaderCaptionFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Wizard1.HeaderDescriptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wizard1.HeaderDescriptionIndent = 62
        Me.Wizard1.HeaderDescriptionVisible = False
        Me.Wizard1.HeaderHeight = 90
        Me.Wizard1.HeaderImageAlignment = DevComponents.DotNetBar.eWizardTitleImageAlignment.Left
        '
        '
        '
        Me.Wizard1.HeaderStyle.BackColor = System.Drawing.Color.Transparent
        Me.Wizard1.HeaderStyle.BackColorGradientAngle = 90
        Me.Wizard1.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Wizard1.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Wizard1.HeaderStyle.BorderBottomWidth = 1
        Me.Wizard1.HeaderStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Wizard1.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Wizard1.HeaderTitleIndent = 62
        Me.Wizard1.HelpButtonVisible = False
        Me.Wizard1.Location = New System.Drawing.Point(0, 0)
        Me.Wizard1.Name = "Wizard1"
        Me.Wizard1.NextButtonText = "Proximo >"
        Me.Wizard1.Size = New System.Drawing.Size(784, 561)
        Me.Wizard1.TabIndex = 82
        Me.Wizard1.WizardPages.AddRange(New DevComponents.DotNetBar.WizardPage() {Me.WizardPage1, Me.WizardPage3})
        '
        'WizardPage1
        '
        Me.WizardPage1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WizardPage1.AntiAlias = False
        Me.WizardPage1.BackColor = System.Drawing.Color.Transparent
        Me.WizardPage1.Controls.Add(Me.infCpl)
        Me.WizardPage1.Controls.Add(Me.Msg)
        Me.WizardPage1.Controls.Add(Me.Pedido)
        Me.WizardPage1.Controls.Add(Me.btLocalizaInfAdicionais)
        Me.WizardPage1.Controls.Add(Me.btSalvarInfCPL)
        Me.WizardPage1.Location = New System.Drawing.Point(7, 102)
        Me.WizardPage1.Name = "WizardPage1"
        Me.WizardPage1.PageHeaderImage = CType(resources.GetObject("WizardPage1.PageHeaderImage"), System.Drawing.Image)
        Me.WizardPage1.PageTitle = "Informações Adicionais da NFe"
        Me.WizardPage1.Size = New System.Drawing.Size(770, 401)
        '
        '
        '
        Me.WizardPage1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.WizardPage1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.WizardPage1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.WizardPage1.TabIndex = 7
        '
        'infCpl
        '
        Me.infCpl.AceitaColarTexto = True
        Me.infCpl.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.infCpl.CasasDecimais = 0
        Me.infCpl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.infCpl.CPObrigatorio = False
        Me.infCpl.CPObrigatorioMsg = Nothing
        Me.infCpl.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Sim
        Me.infCpl.FlatBorder = False
        Me.infCpl.FlatBorderColor = System.Drawing.Color.DimGray
        Me.infCpl.FocusColor = System.Drawing.Color.Empty
        Me.infCpl.FocusColorEnd = System.Drawing.Color.Empty
        Me.infCpl.HighlightBorderOnEnter = False
        Me.infCpl.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.infCpl.Location = New System.Drawing.Point(13, 26)
        Me.infCpl.MaxLength = 5000
        Me.infCpl.Multiline = True
        Me.infCpl.Name = "infCpl"
        Me.infCpl.PreencherZeroEsqueda = False
        Me.infCpl.RegraValidação = Nothing
        Me.infCpl.RegraValidaçãoMensagem = Nothing
        Me.infCpl.Size = New System.Drawing.Size(745, 357)
        Me.infCpl.TabIndex = 78
        Me.infCpl.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.infCpl.ValorPadrao = Nothing
        '
        'Msg
        '
        Me.Msg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Msg.Location = New System.Drawing.Point(537, 3)
        Me.Msg.Name = "Msg"
        Me.Msg.Size = New System.Drawing.Size(221, 22)
        Me.Msg.TabIndex = 74
        Me.Msg.Text = "Validação de dados"
        Me.Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Msg.Visible = False
        '
        'Pedido
        '
        Me.Pedido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pedido.Location = New System.Drawing.Point(460, 3)
        Me.Pedido.Name = "Pedido"
        Me.Pedido.Size = New System.Drawing.Size(88, 21)
        Me.Pedido.TabIndex = 75
        Me.Pedido.Text = "0000"
        Me.Pedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Pedido.Visible = False
        '
        'btLocalizaInfAdicionais
        '
        Me.btLocalizaInfAdicionais.Image = CType(resources.GetObject("btLocalizaInfAdicionais.Image"), System.Drawing.Image)
        Me.btLocalizaInfAdicionais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btLocalizaInfAdicionais.Location = New System.Drawing.Point(13, 0)
        Me.btLocalizaInfAdicionais.Name = "btLocalizaInfAdicionais"
        Me.btLocalizaInfAdicionais.Size = New System.Drawing.Size(25, 25)
        Me.btLocalizaInfAdicionais.TabIndex = 80
        Me.btLocalizaInfAdicionais.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btLocalizaInfAdicionais.UseVisualStyleBackColor = True
        '
        'btSalvarInfCPL
        '
        Me.btSalvarInfCPL.Image = CType(resources.GetObject("btSalvarInfCPL.Image"), System.Drawing.Image)
        Me.btSalvarInfCPL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btSalvarInfCPL.Location = New System.Drawing.Point(44, 0)
        Me.btSalvarInfCPL.Name = "btSalvarInfCPL"
        Me.btSalvarInfCPL.Size = New System.Drawing.Size(25, 25)
        Me.btSalvarInfCPL.TabIndex = 81
        Me.btSalvarInfCPL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btSalvarInfCPL.UseVisualStyleBackColor = True
        '
        'WizardPage3
        '
        Me.WizardPage3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WizardPage3.AntiAlias = False
        Me.WizardPage3.BackColor = System.Drawing.Color.Transparent
        Me.WizardPage3.Controls.Add(Me.BrEnviar)
        Me.WizardPage3.Controls.Add(Me.btLimparProdutos)
        Me.WizardPage3.Controls.Add(Me.btTodosProdutos)
        Me.WizardPage3.Controls.Add(Me.Lista)
        Me.WizardPage3.Location = New System.Drawing.Point(7, 102)
        Me.WizardPage3.Name = "WizardPage3"
        Me.WizardPage3.PageDescription = "< Wizard step description >"
        Me.WizardPage3.PageHeaderImage = CType(resources.GetObject("WizardPage3.PageHeaderImage"), System.Drawing.Image)
        Me.WizardPage3.PageTitle = "Seleção de Produtos"
        Me.WizardPage3.Size = New System.Drawing.Size(770, 401)
        '
        '
        '
        Me.WizardPage3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.WizardPage3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.WizardPage3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.WizardPage3.TabIndex = 9
        '
        'BrEnviar
        '
        '
        '
        '
        Me.BrEnviar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BrEnviar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrEnviar.Location = New System.Drawing.Point(420, 368)
        Me.BrEnviar.Name = "BrEnviar"
        Me.BrEnviar.Size = New System.Drawing.Size(350, 21)
        Me.BrEnviar.TabIndex = 56
        Me.BrEnviar.Text = "Enviando NFe aguarde..."
        Me.BrEnviar.TextVisible = True
        Me.BrEnviar.Visible = False
        '
        'btLimparProdutos
        '
        Me.btLimparProdutos.Location = New System.Drawing.Point(141, 366)
        Me.btLimparProdutos.Name = "btLimparProdutos"
        Me.btLimparProdutos.Size = New System.Drawing.Size(135, 23)
        Me.btLimparProdutos.TabIndex = 27
        Me.btLimparProdutos.Text = "Limpar os Produtos"
        Me.btLimparProdutos.UseVisualStyleBackColor = True
        '
        'btTodosProdutos
        '
        Me.btTodosProdutos.Location = New System.Drawing.Point(0, 366)
        Me.btTodosProdutos.Name = "btTodosProdutos"
        Me.btTodosProdutos.Size = New System.Drawing.Size(135, 23)
        Me.btTodosProdutos.TabIndex = 26
        Me.btTodosProdutos.Text = "Emitir todos os Produtos"
        Me.btTodosProdutos.UseVisualStyleBackColor = True
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cProduto, Me.cDesc, Me.cQtd, Me.cSelect, Me.cValorProduto})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(129, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(129, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lista.DefaultCellStyle = DataGridViewCellStyle5
        Me.Lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Lista.EnableHeadersVisualStyles = False
        Me.Lista.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Lista.Location = New System.Drawing.Point(0, 0)
        Me.Lista.Name = "Lista"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Lista.RowHeadersWidth = 20
        Me.Lista.SelectAllSignVisible = False
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(770, 363)
        Me.Lista.TabIndex = 2
        '
        'cProduto
        '
        Me.cProduto.DataPropertyName = "CodigoProduto"
        Me.cProduto.HeaderText = "Produto"
        Me.cProduto.Name = "cProduto"
        Me.cProduto.ReadOnly = True
        Me.cProduto.Width = 85
        '
        'cDesc
        '
        Me.cDesc.DataPropertyName = "Descrição"
        Me.cDesc.HeaderText = "Descrição"
        Me.cDesc.Name = "cDesc"
        Me.cDesc.ReadOnly = True
        Me.cDesc.Width = 470
        '
        'cQtd
        '
        Me.cQtd.DataPropertyName = "Qtd"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N4"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.cQtd.DefaultCellStyle = DataGridViewCellStyle3
        Me.cQtd.HeaderText = "Qtd"
        Me.cQtd.Name = "cQtd"
        Me.cQtd.ReadOnly = True
        Me.cQtd.Width = 120
        '
        'cSelect
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N4"
        DataGridViewCellStyle4.NullValue = False
        Me.cSelect.DefaultCellStyle = DataGridViewCellStyle4
        Me.cSelect.HeaderText = "Seleção"
        Me.cSelect.Name = "cSelect"
        Me.cSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cSelect.Width = 50
        '
        'cValorProduto
        '
        Me.cValorProduto.DataPropertyName = "ValorUnitario"
        Me.cValorProduto.HeaderText = "cValorProduto"
        Me.cValorProduto.Name = "cValorProduto"
        Me.cValorProduto.Visible = False
        '
        'NFeValidarDados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NFeValidarDados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Validar Dados Para NFe"
        Me.PanelEx1.ResumeLayout(False)
        Me.Wizard1.ResumeLayout(False)
        Me.WizardPage1.ResumeLayout(False)
        Me.WizardPage1.PerformLayout()
        Me.WizardPage3.ResumeLayout(False)
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Msg As System.Windows.Forms.Label
    Friend WithEvents Pedido As System.Windows.Forms.Label
    Friend WithEvents infCpl As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents btSalvarInfCPL As System.Windows.Forms.Button
    Friend WithEvents btLocalizaInfAdicionais As System.Windows.Forms.Button
    Friend WithEvents Wizard1 As DevComponents.DotNetBar.Wizard
    Friend WithEvents WizardPage1 As DevComponents.DotNetBar.WizardPage
    Friend WithEvents WizardPage3 As DevComponents.DotNetBar.WizardPage
    Friend WithEvents Lista As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btTodosProdutos As System.Windows.Forms.Button
    Friend WithEvents btLimparProdutos As System.Windows.Forms.Button
    Friend WithEvents cProduto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cQtd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cValorProduto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BrEnviar As DevComponents.DotNetBar.Controls.ProgressBarX
End Class
