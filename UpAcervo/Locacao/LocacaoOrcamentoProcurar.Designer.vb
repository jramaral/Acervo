<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocacaoOrcamentoProcurar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocacaoOrcamentoProcurar))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnLimpar = New DevComponents.DotNetBar.ButtonX()
        Me.btnFiltrar = New DevComponents.DotNetBar.ButtonX()
        Me.txtNome = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtVendedor = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtData = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtNumero = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Lista = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.cIdLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDataLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cvendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStatusLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelEx1.SuspendLayout
        Me.GroupPanel1.SuspendLayout
        CType(Me.Lista,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.GroupPanel1)
        Me.PanelEx1.Controls.Add(Me.Lista)
        Me.PanelEx1.Controls.Add(Me.Fechar)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(892, 504)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.btnLimpar)
        Me.GroupPanel1.Controls.Add(Me.btnFiltrar)
        Me.GroupPanel1.Controls.Add(Me.txtNome)
        Me.GroupPanel1.Controls.Add(Me.txtVendedor)
        Me.GroupPanel1.Controls.Add(Me.txtData)
        Me.GroupPanel1.Controls.Add(Me.txtNumero)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(865, 37)
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
        '
        'btnLimpar
        '
        Me.btnLimpar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpar.Image = CType(resources.GetObject("btnLimpar.Image"),System.Drawing.Image)
        Me.btnLimpar.Location = New System.Drawing.Point(767, 4)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(29, 24)
        Me.btnLimpar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLimpar.TabIndex = 5
        Me.btnLimpar.Tooltip = "Limpar Filtro"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFiltrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFiltrar.Image = CType(resources.GetObject("btnFiltrar.Image"),System.Drawing.Image)
        Me.btnFiltrar.Location = New System.Drawing.Point(732, 4)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(29, 24)
        Me.btnFiltrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFiltrar.TabIndex = 4
        Me.btnFiltrar.Tooltip = "Filtrar"
        '
        'txtNome
        '
        Me.txtNome.AceitaColarTexto = true
        Me.txtNome.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtNome.CasasDecimais = 0
        Me.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNome.CPObrigatorio = false
        Me.txtNome.CPObrigatorioMsg = Nothing
        Me.txtNome.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtNome.FlatBorder = false
        Me.txtNome.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtNome.FocusColor = System.Drawing.Color.Empty
        Me.txtNome.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtNome.HighlightBorderOnEnter = true
        Me.txtNome.HighlightBorderOnEnterColor = System.Drawing.Color.Maroon
        Me.txtNome.Location = New System.Drawing.Point(209, 5)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.PreencherZeroEsqueda = false
        Me.txtNome.RegraValidação = Nothing
        Me.txtNome.RegraValidaçãoMensagem = Nothing
        Me.txtNome.Size = New System.Drawing.Size(327, 23)
        Me.txtNome.TabIndex = 2
        Me.txtNome.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtNome.ValorPadrao = Nothing
        '
        'txtVendedor
        '
        Me.txtVendedor.AceitaColarTexto = true
        Me.txtVendedor.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtVendedor.CasasDecimais = 0
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.CPObrigatorio = false
        Me.txtVendedor.CPObrigatorioMsg = Nothing
        Me.txtVendedor.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtVendedor.FlatBorder = false
        Me.txtVendedor.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtVendedor.FocusColor = System.Drawing.Color.Empty
        Me.txtVendedor.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtVendedor.HighlightBorderOnEnter = true
        Me.txtVendedor.HighlightBorderOnEnterColor = System.Drawing.Color.Maroon
        Me.txtVendedor.Location = New System.Drawing.Point(538, 5)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.PreencherZeroEsqueda = false
        Me.txtVendedor.RegraValidação = Nothing
        Me.txtVendedor.RegraValidaçãoMensagem = Nothing
        Me.txtVendedor.Size = New System.Drawing.Size(188, 23)
        Me.txtVendedor.TabIndex = 3
        Me.txtVendedor.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtVendedor.ValorPadrao = Nothing
        '
        'txtData
        '
        Me.txtData.AceitaColarTexto = true
        Me.txtData.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtData.CasasDecimais = 0
        Me.txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData.CPObrigatorio = false
        Me.txtData.CPObrigatorioMsg = Nothing
        Me.txtData.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtData.FlatBorder = false
        Me.txtData.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtData.FocusColor = System.Drawing.Color.Empty
        Me.txtData.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtData.HighlightBorderOnEnter = true
        Me.txtData.HighlightBorderOnEnterColor = System.Drawing.Color.Maroon
        Me.txtData.Location = New System.Drawing.Point(108, 5)
        Me.txtData.MaxLength = 10
        Me.txtData.Name = "txtData"
        Me.txtData.PreencherZeroEsqueda = false
        Me.txtData.RegraValidação = Nothing
        Me.txtData.RegraValidaçãoMensagem = Nothing
        Me.txtData.Size = New System.Drawing.Size(99, 23)
        Me.txtData.TabIndex = 1
        Me.txtData.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.txtData.ValorPadrao = Nothing
        '
        'txtNumero
        '
        Me.txtNumero.AceitaColarTexto = true
        Me.txtNumero.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtNumero.CasasDecimais = 0
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.CPObrigatorio = false
        Me.txtNumero.CPObrigatorioMsg = Nothing
        Me.txtNumero.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtNumero.FlatBorder = false
        Me.txtNumero.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtNumero.FocusColor = System.Drawing.Color.Empty
        Me.txtNumero.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtNumero.HighlightBorderOnEnter = true
        Me.txtNumero.HighlightBorderOnEnterColor = System.Drawing.Color.Maroon
        Me.txtNumero.Location = New System.Drawing.Point(20, 5)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.PreencherZeroEsqueda = false
        Me.txtNumero.RegraValidação = Nothing
        Me.txtNumero.RegraValidaçãoMensagem = Nothing
        Me.txtNumero.Size = New System.Drawing.Size(87, 23)
        Me.txtNumero.TabIndex = 0
        Me.txtNumero.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtNumero.ValorPadrao = Nothing
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = false
        Me.Lista.AllowUserToDeleteRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumPurple
        Me.Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdLoc, Me.cDataLoc, Me.cNome, Me.cvendedor, Me.cTotalLoc, Me.cStatusLoc})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lista.DefaultCellStyle = DataGridViewCellStyle3
        Me.Lista.GridColor = System.Drawing.Color.FromArgb(CType(CType(208,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(229,Byte),Integer))
        Me.Lista.Location = New System.Drawing.Point(12, 53)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = true
        Me.Lista.RowHeadersWidth = 20
        Me.Lista.SelectAllSignVisible = false
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(865, 399)
        Me.Lista.TabIndex = 1
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Location = New System.Drawing.Point(796, 467)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(81, 28)
        Me.Fechar.TabIndex = 2
        Me.Fechar.TabStop = false
        Me.Fechar.Text = "Fechar"
        '
        'cIdLoc
        '
        Me.cIdLoc.DataPropertyName = "IdLoc"
        Me.cIdLoc.HeaderText = "Num Orç."
        Me.cIdLoc.Name = "cIdLoc"
        Me.cIdLoc.ReadOnly = true
        Me.cIdLoc.Width = 90
        '
        'cDataLoc
        '
        Me.cDataLoc.DataPropertyName = "DataLoc"
        Me.cDataLoc.HeaderText = "Data Locação"
        Me.cDataLoc.Name = "cDataLoc"
        Me.cDataLoc.ReadOnly = true
        '
        'cNome
        '
        Me.cNome.DataPropertyName = "NomeCliente"
        Me.cNome.HeaderText = "Nome Cliente"
        Me.cNome.Name = "cNome"
        Me.cNome.ReadOnly = true
        Me.cNome.Width = 330
        '
        'cvendedor
        '
        Me.cvendedor.DataPropertyName = "NomeVendedor"
        Me.cvendedor.HeaderText = "Vendedor"
        Me.cvendedor.Name = "cvendedor"
        Me.cvendedor.ReadOnly = true
        Me.cvendedor.Width = 190
        '
        'cTotalLoc
        '
        Me.cTotalLoc.DataPropertyName = "TotalLoc"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.cTotalLoc.DefaultCellStyle = DataGridViewCellStyle2
        Me.cTotalLoc.HeaderText = "Total Orçamento"
        Me.cTotalLoc.Name = "cTotalLoc"
        Me.cTotalLoc.ReadOnly = true
        Me.cTotalLoc.Width = 130
        '
        'cStatusLoc
        '
        Me.cStatusLoc.DataPropertyName = "StatusLoc"
        Me.cStatusLoc.HeaderText = "Status"
        Me.cStatusLoc.Name = "cStatusLoc"
        Me.cStatusLoc.ReadOnly = true
        Me.cStatusLoc.Visible = false
        Me.cStatusLoc.Width = 110
        '
        'LocacaoOrcamentoProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 504)
        Me.ControlBox = false
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "LocacaoOrcamentoProcurar"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procura de Orçamento"
        Me.PanelEx1.ResumeLayout(false)
        Me.GroupPanel1.ResumeLayout(false)
        Me.GroupPanel1.PerformLayout
        CType(Me.Lista,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lista As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnLimpar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnFiltrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtNome As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtVendedor As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtData As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtNumero As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents cIdLoc As DataGridViewTextBoxColumn
    Friend WithEvents cDataLoc As DataGridViewTextBoxColumn
    Friend WithEvents cNome As DataGridViewTextBoxColumn
    Friend WithEvents cvendedor As DataGridViewTextBoxColumn
    Friend WithEvents cTotalLoc As DataGridViewTextBoxColumn
    Friend WithEvents cStatusLoc As DataGridViewTextBoxColumn
End Class
