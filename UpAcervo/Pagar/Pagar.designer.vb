<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pagar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pagar))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuPagar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditaContaSelecionadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarVinculoDePagamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.IdSelecionado = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Total = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.btnPesquisar = New DevComponents.DotNetBar.ButtonX()
        Me.txtProcura = New TexBoxFocusNet.TextBoxFocusNet()
        Me.cboFiltros = New CBOAutoCompleteFocus.CboFocus()
        Me.dgvItem = New System.Windows.Forms.DataGridView()
        Me.g_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.g_documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.g_notafiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.g_fornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.g_datadoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.g_vencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.g_valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.g_virtual = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.g_Destino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdAgrupamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.MenuPagar.SuspendLayout()
        Me.Fundo.SuspendLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuPagar
        '
        Me.MenuPagar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditaContaSelecionadaToolStripMenuItem, Me.VisualizarVinculoDePagamentoToolStripMenuItem})
        Me.MenuPagar.Name = "MenuPagar"
        Me.MenuPagar.Size = New System.Drawing.Size(247, 48)
        '
        'EditaContaSelecionadaToolStripMenuItem
        '
        Me.EditaContaSelecionadaToolStripMenuItem.Image = CType(resources.GetObject("EditaContaSelecionadaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditaContaSelecionadaToolStripMenuItem.Name = "EditaContaSelecionadaToolStripMenuItem"
        Me.EditaContaSelecionadaToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.EditaContaSelecionadaToolStripMenuItem.Text = "Edita Conta Selecionada"
        '
        'VisualizarVinculoDePagamentoToolStripMenuItem
        '
        Me.VisualizarVinculoDePagamentoToolStripMenuItem.Name = "VisualizarVinculoDePagamentoToolStripMenuItem"
        Me.VisualizarVinculoDePagamentoToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.VisualizarVinculoDePagamentoToolStripMenuItem.Text = "Visualizar Vinculo de Pagamento"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(239, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Duplo Click no Documento para baixa"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IdSelecionado
        '
        Me.IdSelecionado.AceitaColarTexto = True
        Me.IdSelecionado.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.IdSelecionado.CasasDecimais = 0
        Me.IdSelecionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.IdSelecionado.CPObrigatorio = False
        Me.IdSelecionado.CPObrigatorioMsg = Nothing
        Me.IdSelecionado.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.IdSelecionado.FlatBorder = False
        Me.IdSelecionado.FlatBorderColor = System.Drawing.Color.DimGray
        Me.IdSelecionado.FocusColor = System.Drawing.Color.Empty
        Me.IdSelecionado.FocusColorEnd = System.Drawing.Color.Empty
        Me.IdSelecionado.HighlightBorderOnEnter = False
        Me.IdSelecionado.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.IdSelecionado.Location = New System.Drawing.Point(488, 11)
        Me.IdSelecionado.Name = "IdSelecionado"
        Me.IdSelecionado.PreencherZeroEsqueda = False
        Me.IdSelecionado.RegraValidação = Nothing
        Me.IdSelecionado.RegraValidaçãoMensagem = Nothing
        Me.IdSelecionado.Size = New System.Drawing.Size(81, 23)
        Me.IdSelecionado.TabIndex = 3
        Me.IdSelecionado.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.IdSelecionado.ValorPadrao = Nothing
        Me.IdSelecionado.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(536, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Total Filtrado R$"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Total
        '
        Me.Total.AceitaColarTexto = True
        Me.Total.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Total.CasasDecimais = 2
        Me.Total.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Total.CPObrigatorio = False
        Me.Total.CPObrigatorioMsg = Nothing
        Me.Total.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Total.FlatBorder = False
        Me.Total.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Total.FocusColor = System.Drawing.Color.Empty
        Me.Total.FocusColorEnd = System.Drawing.Color.Empty
        Me.Total.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Total.HighlightBorderOnEnter = False
        Me.Total.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Total.Location = New System.Drawing.Point(709, 8)
        Me.Total.Name = "Total"
        Me.Total.PreencherZeroEsqueda = False
        Me.Total.RegraValidação = Nothing
        Me.Total.RegraValidaçãoMensagem = Nothing
        Me.Total.Size = New System.Drawing.Size(192, 26)
        Me.Total.TabIndex = 1
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Total.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Total.ValorPadrao = Nothing
        '
        'Fundo
        '
        Me.Fundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Fundo.Controls.Add(Me.btnPesquisar)
        Me.Fundo.Controls.Add(Me.txtProcura)
        Me.Fundo.Controls.Add(Me.cboFiltros)
        Me.Fundo.Controls.Add(Me.dgvItem)
        Me.Fundo.Controls.Add(Me.PanelEx1)
        Me.Fundo.Controls.Add(Me.Label7)
        Me.Fundo.Controls.Add(Me.Label6)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(928, 573)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'btnPesquisar
        '
        Me.btnPesquisar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPesquisar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPesquisar.Image = CType(resources.GetObject("btnPesquisar.Image"), System.Drawing.Image)
        Me.btnPesquisar.Location = New System.Drawing.Point(760, 10)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(150, 23)
        Me.btnPesquisar.TabIndex = 2
        Me.btnPesquisar.Text = "Pesquisar"
        '
        'txtProcura
        '
        Me.txtProcura.AceitaColarTexto = True
        Me.txtProcura.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtProcura.CasasDecimais = 0
        Me.txtProcura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProcura.CPObrigatorio = False
        Me.txtProcura.CPObrigatorioMsg = Nothing
        Me.txtProcura.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtProcura.FlatBorder = False
        Me.txtProcura.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtProcura.FocusColor = System.Drawing.Color.Empty
        Me.txtProcura.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtProcura.HighlightBorderOnEnter = False
        Me.txtProcura.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtProcura.Location = New System.Drawing.Point(295, 10)
        Me.txtProcura.MaxLength = 15
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.PreencherZeroEsqueda = False
        Me.txtProcura.RegraValidação = Nothing
        Me.txtProcura.RegraValidaçãoMensagem = Nothing
        Me.txtProcura.Size = New System.Drawing.Size(459, 23)
        Me.txtProcura.TabIndex = 1
        Me.txtProcura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Numeros
        Me.txtProcura.ValorPadrao = Nothing
        '
        'cboFiltros
        '
        Me.cboFiltros.Auto_Complete = True
        Me.cboFiltros.AutoLimitar_Lista = True
        Me.cboFiltros.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.cboFiltros.CPObrigatorio = False
        Me.cboFiltros.CPObrigatorioMsg = Nothing
        Me.cboFiltros.FlatBorder = False
        Me.cboFiltros.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboFiltros.FormattingEnabled = True
        Me.cboFiltros.HighlightBorderColor = System.Drawing.Color.Empty
        Me.cboFiltros.HighlightBorderOnEnter = False
        Me.cboFiltros.Items.AddRange(New Object() {"Todos", "Por Data", "Por Nome", "Por NF"})
        Me.cboFiltros.Location = New System.Drawing.Point(90, 9)
        Me.cboFiltros.MaxDropDownItems = 4
        Me.cboFiltros.Name = "cboFiltros"
        Me.cboFiltros.Size = New System.Drawing.Size(106, 23)
        Me.cboFiltros.TabIndex = 0
        '
        'dgvItem
        '
        Me.dgvItem.AllowUserToAddRows = False
        Me.dgvItem.AllowUserToDeleteRows = False
        Me.dgvItem.AllowUserToResizeColumns = False
        Me.dgvItem.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue
        Me.dgvItem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItem.BackgroundColor = System.Drawing.Color.White
        Me.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItem.ColumnHeadersHeight = 18
        Me.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.g_id, Me.g_documento, Me.g_notafiscal, Me.g_fornecedor, Me.g_datadoc, Me.g_vencimento, Me.g_valor, Me.g_virtual, Me.g_Destino, Me.cIdAgrupamento})
        Me.dgvItem.ContextMenuStrip = Me.MenuPagar
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Comic Sans MS", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItem.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvItem.EnableHeadersVisualStyles = False
        Me.dgvItem.Location = New System.Drawing.Point(6, 39)
        Me.dgvItem.MultiSelect = False
        Me.dgvItem.Name = "dgvItem"
        Me.dgvItem.RowHeadersVisible = False
        Me.dgvItem.RowHeadersWidth = 15
        Me.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItem.Size = New System.Drawing.Size(914, 439)
        Me.dgvItem.TabIndex = 6
        '
        'g_id
        '
        Me.g_id.DataPropertyName = "id"
        Me.g_id.HeaderText = "id"
        Me.g_id.Name = "g_id"
        Me.g_id.Visible = False
        '
        'g_documento
        '
        Me.g_documento.DataPropertyName = "documento"
        Me.g_documento.HeaderText = "Documento"
        Me.g_documento.Name = "g_documento"
        '
        'g_notafiscal
        '
        Me.g_notafiscal.DataPropertyName = "notafiscal"
        Me.g_notafiscal.HeaderText = "NF"
        Me.g_notafiscal.Name = "g_notafiscal"
        Me.g_notafiscal.Width = 90
        '
        'g_fornecedor
        '
        Me.g_fornecedor.DataPropertyName = "fornecedor"
        Me.g_fornecedor.HeaderText = "Fornecedor"
        Me.g_fornecedor.Name = "g_fornecedor"
        Me.g_fornecedor.Width = 240
        '
        'g_datadoc
        '
        Me.g_datadoc.DataPropertyName = "datadocumento"
        Me.g_datadoc.HeaderText = "Data Doc"
        Me.g_datadoc.Name = "g_datadoc"
        Me.g_datadoc.Width = 75
        '
        'g_vencimento
        '
        Me.g_vencimento.DataPropertyName = "Vencimento"
        Me.g_vencimento.HeaderText = "Vencimento"
        Me.g_vencimento.Name = "g_vencimento"
        Me.g_vencimento.Width = 75
        '
        'g_valor
        '
        Me.g_valor.DataPropertyName = "valordocumento"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.g_valor.DefaultCellStyle = DataGridViewCellStyle3
        Me.g_valor.HeaderText = "Valor"
        Me.g_valor.Name = "g_valor"
        '
        'g_virtual
        '
        Me.g_virtual.DataPropertyName = "virtual"
        Me.g_virtual.HeaderText = "Virtual"
        Me.g_virtual.Name = "g_virtual"
        Me.g_virtual.Width = 45
        '
        'g_Destino
        '
        Me.g_Destino.DataPropertyName = "Destino"
        Me.g_Destino.HeaderText = "Destino"
        Me.g_Destino.Name = "g_Destino"
        Me.g_Destino.Width = 200
        '
        'cIdAgrupamento
        '
        Me.cIdAgrupamento.DataPropertyName = "IdAgrupamento"
        Me.cIdAgrupamento.HeaderText = "IdAgrupamento"
        Me.cIdAgrupamento.Name = "cIdAgrupamento"
        Me.cIdAgrupamento.Visible = False
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.PanelEx1.Controls.Add(Me.Label8)
        Me.PanelEx1.Controls.Add(Me.Label5)
        Me.PanelEx1.Controls.Add(Me.IdSelecionado)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.btFechar)
        Me.PanelEx1.Controls.Add(Me.Total)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Location = New System.Drawing.Point(9, 483)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(911, 84)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(10, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 15)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "      "
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(41, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(208, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Conta em Atraso"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Location = New System.Drawing.Point(785, 50)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(116, 28)
        Me.btFechar.TabIndex = 4
        Me.btFechar.Text = "Fechar"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(211, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 19)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Digite aqui->"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(5, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 19)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Filtros"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "C:\UpSistemas\Help\dblsistemas.chm"
        '
        'Pagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(928, 573)
        Me.ControlBox = False
        Me.Controls.Add(Me.Fundo)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Pagar"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta e Baixa de Contas a Pagar - T067"
        Me.MenuPagar.ResumeLayout(False)
        Me.Fundo.ResumeLayout(False)
        Me.Fundo.PerformLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents IdSelecionado As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Total As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents MenuPagar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditaContaSelecionadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Private WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Private WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents dgvItem As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents VisualizarVinculoDePagamentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents g_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g_documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g_notafiscal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g_fornecedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g_datadoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g_vencimento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g_valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g_virtual As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents g_Destino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdAgrupamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboFiltros As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtProcura As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents btnPesquisar As DevComponents.DotNetBar.ButtonX
End Class
