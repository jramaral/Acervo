<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcuraProduto
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProcuraProduto))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.DgvItem = New System.Windows.Forms.DataGridView()
        Me.Vazio = New System.Windows.Forms.PictureBox()
        Me.Display = New System.Windows.Forms.PictureBox()
        Me.lbldescProd = New System.Windows.Forms.Label()
        Me.lblMensagem = New System.Windows.Forms.Label()
        Me.lblRef = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.A6 = New System.Windows.Forms.RadioButton()
        Me.A2 = New System.Windows.Forms.RadioButton()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.txtProcura = New TexBoxFocusNet.TextBoxFocusNet()
        Me.A1 = New System.Windows.Forms.RadioButton()
        Me.A3 = New System.Windows.Forms.RadioButton()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodBarra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Local = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gmarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estoque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gEmLocacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtdLocado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorvenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.greferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorVendaAtacado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PanelEx1.SuspendLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Vazio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Display, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.PanelEx1.Controls.Add(Me.DgvItem)
        Me.PanelEx1.Controls.Add(Me.Vazio)
        Me.PanelEx1.Controls.Add(Me.Display)
        Me.PanelEx1.Controls.Add(Me.lbldescProd)
        Me.PanelEx1.Controls.Add(Me.lblMensagem)
        Me.PanelEx1.Controls.Add(Me.lblRef)
        Me.PanelEx1.Controls.Add(Me.GroupPanel1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1005, 680)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'DgvItem
        '
        Me.DgvItem.AllowUserToAddRows = False
        Me.DgvItem.AllowUserToDeleteRows = False
        Me.DgvItem.AllowUserToResizeColumns = False
        Me.DgvItem.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.DgvItem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvItem.BackgroundColor = System.Drawing.Color.White
        Me.DgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.CodBarra, Me.Desc, Me.unidade, Me.Local, Me.gmarca, Me.estoque, Me.gEmLocacao, Me.cQtdLocado, Me.valorvenda, Me.greferencia, Me.tipo, Me.cValorVendaAtacado, Me.Column1})
        Me.DgvItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgvItem.Location = New System.Drawing.Point(3, 86)
        Me.DgvItem.MultiSelect = False
        Me.DgvItem.Name = "DgvItem"
        Me.DgvItem.RowHeadersVisible = False
        Me.DgvItem.RowHeadersWidth = 15
        Me.DgvItem.RowTemplate.Height = 60
        Me.DgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvItem.Size = New System.Drawing.Size(996, 591)
        Me.DgvItem.TabIndex = 1
        '
        'Vazio
        '
        Me.Vazio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Vazio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Vazio.Image = CType(resources.GetObject("Vazio.Image"), System.Drawing.Image)
        Me.Vazio.Location = New System.Drawing.Point(315, 642)
        Me.Vazio.Name = "Vazio"
        Me.Vazio.Size = New System.Drawing.Size(28, 27)
        Me.Vazio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Vazio.TabIndex = 52
        Me.Vazio.TabStop = False
        Me.Vazio.Visible = False
        '
        'Display
        '
        Me.Display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Display.Location = New System.Drawing.Point(8, 465)
        Me.Display.Name = "Display"
        Me.Display.Size = New System.Drawing.Size(301, 204)
        Me.Display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Display.TabIndex = 51
        Me.Display.TabStop = False
        Me.Display.Visible = False
        '
        'lbldescProd
        '
        Me.lbldescProd.Font = New System.Drawing.Font("Comic Sans MS", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldescProd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbldescProd.Location = New System.Drawing.Point(324, 469)
        Me.lbldescProd.Name = "lbldescProd"
        Me.lbldescProd.Size = New System.Drawing.Size(667, 48)
        Me.lbldescProd.TabIndex = 2
        '
        'lblMensagem
        '
        Me.lblMensagem.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensagem.Location = New System.Drawing.Point(12, 607)
        Me.lblMensagem.Name = "lblMensagem"
        Me.lblMensagem.Size = New System.Drawing.Size(837, 23)
        Me.lblMensagem.TabIndex = 2
        '
        'lblRef
        '
        Me.lblRef.AutoSize = True
        Me.lblRef.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRef.Location = New System.Drawing.Point(653, 466)
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Size = New System.Drawing.Size(41, 23)
        Me.lblRef.TabIndex = 2
        Me.lblRef.Text = "Ref."
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.A6)
        Me.GroupPanel1.Controls.Add(Me.A2)
        Me.GroupPanel1.Controls.Add(Me.ButtonX2)
        Me.GroupPanel1.Controls.Add(Me.txtProcura)
        Me.GroupPanel1.Controls.Add(Me.A1)
        Me.GroupPanel1.Controls.Add(Me.A3)
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(996, 68)
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
        Me.GroupPanel1.Text = "Selecione uma das op��es de procura do Produto"
        '
        'A6
        '
        Me.A6.AutoSize = True
        Me.A6.Location = New System.Drawing.Point(453, 20)
        Me.A6.Name = "A6"
        Me.A6.Size = New System.Drawing.Size(102, 19)
        Me.A6.TabIndex = 7
        Me.A6.Text = "Por Marca [F7]"
        Me.A6.UseVisualStyleBackColor = True
        '
        'A2
        '
        Me.A2.AutoSize = True
        Me.A2.Checked = True
        Me.A2.Location = New System.Drawing.Point(346, 19)
        Me.A2.Name = "A2"
        Me.A2.Size = New System.Drawing.Size(101, 19)
        Me.A2.TabIndex = 2
        Me.A2.TabStop = True
        Me.A2.Text = "Descri��o [F4]"
        Me.A2.UseVisualStyleBackColor = True
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(932, 16)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(57, 23)
        Me.ButtonX2.TabIndex = 6
        Me.ButtonX2.TabStop = False
        Me.ButtonX2.Text = "Fechar"
        '
        'txtProcura
        '
        Me.txtProcura.AceitaColarTexto = True
        Me.txtProcura.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.N�o
        Me.txtProcura.CasasDecimais = 2
        Me.txtProcura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProcura.CPObrigatorio = False
        Me.txtProcura.CPObrigatorioMsg = Nothing
        Me.txtProcura.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.N�o
        Me.txtProcura.FlatBorder = False
        Me.txtProcura.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtProcura.FocusColor = System.Drawing.Color.Empty
        Me.txtProcura.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtProcura.HighlightBorderOnEnter = False
        Me.txtProcura.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtProcura.Location = New System.Drawing.Point(3, 18)
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.PreencherZeroEsqueda = False
        Me.txtProcura.RegraValida��o = Nothing
        Me.txtProcura.RegraValida��oMensagem = Nothing
        Me.txtProcura.Size = New System.Drawing.Size(245, 23)
        Me.txtProcura.TabIndex = 0
        Me.txtProcura.TpFormata��o = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtProcura.ValorPadrao = Nothing
        '
        'A1
        '
        Me.A1.AutoSize = True
        Me.A1.Location = New System.Drawing.Point(256, 18)
        Me.A1.Name = "A1"
        Me.A1.Size = New System.Drawing.Size(84, 19)
        Me.A1.TabIndex = 1
        Me.A1.Text = "C�digo [F3]"
        Me.A1.UseVisualStyleBackColor = True
        '
        'A3
        '
        Me.A3.AutoSize = True
        Me.A3.Location = New System.Drawing.Point(565, 20)
        Me.A3.Name = "A3"
        Me.A3.Size = New System.Drawing.Size(123, 19)
        Me.A3.TabIndex = 5
        Me.A3.Text = "Mostrar Todos [F8]"
        Me.A3.UseVisualStyleBackColor = True
        '
        'codigo
        '
        Me.codigo.DataPropertyName = "CodigoProduto"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle2
        Me.codigo.HeaderText = "C�digo"
        Me.codigo.Name = "codigo"
        Me.codigo.Width = 80
        '
        'CodBarra
        '
        Me.CodBarra.DataPropertyName = "CodigoBarra"
        Me.CodBarra.HeaderText = "CodBarra"
        Me.CodBarra.Name = "CodBarra"
        Me.CodBarra.Visible = False
        '
        'Desc
        '
        Me.Desc.DataPropertyName = "Descri��o"
        Me.Desc.HeaderText = "Descri��o"
        Me.Desc.Name = "Desc"
        Me.Desc.Width = 350
        '
        'unidade
        '
        Me.unidade.DataPropertyName = "UnidadeMedida"
        Me.unidade.HeaderText = "Un"
        Me.unidade.Name = "unidade"
        Me.unidade.Width = 30
        '
        'Local
        '
        Me.Local.DataPropertyName = "SetorLocalDesc"
        DataGridViewCellStyle3.NullValue = "N�o Locado"
        Me.Local.DefaultCellStyle = DataGridViewCellStyle3
        Me.Local.HeaderText = "Local"
        Me.Local.MaxInputLength = 20
        Me.Local.Name = "Local"
        Me.Local.Visible = False
        Me.Local.Width = 70
        '
        'gmarca
        '
        Me.gmarca.DataPropertyName = "Marca"
        Me.gmarca.HeaderText = "Marca"
        Me.gmarca.Name = "gmarca"
        '
        'estoque
        '
        Me.estoque.DataPropertyName = "QuantidadeEstoque"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N4"
        DataGridViewCellStyle4.NullValue = "0,0000"
        Me.estoque.DefaultCellStyle = DataGridViewCellStyle4
        Me.estoque.HeaderText = "Estoque"
        Me.estoque.Name = "estoque"
        Me.estoque.Width = 80
        '
        'gEmLocacao
        '
        Me.gEmLocacao.DataPropertyName = "EmLocacao"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.gEmLocacao.DefaultCellStyle = DataGridViewCellStyle5
        Me.gEmLocacao.HeaderText = "Locado"
        Me.gEmLocacao.Name = "gEmLocacao"
        Me.gEmLocacao.Visible = False
        Me.gEmLocacao.Width = 60
        '
        'cQtdLocado
        '
        Me.cQtdLocado.DataPropertyName = "qtdelocado"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cQtdLocado.DefaultCellStyle = DataGridViewCellStyle6
        Me.cQtdLocado.HeaderText = "N� vezes Locado"
        Me.cQtdLocado.Name = "cQtdLocado"
        Me.cQtdLocado.Width = 80
        '
        'valorvenda
        '
        Me.valorvenda.DataPropertyName = "ValorVenda"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0,00"
        Me.valorvenda.DefaultCellStyle = DataGridViewCellStyle7
        Me.valorvenda.HeaderText = "Vlr Loca��o"
        Me.valorvenda.Name = "valorvenda"
        Me.valorvenda.Width = 75
        '
        'greferencia
        '
        Me.greferencia.DataPropertyName = "referencia"
        Me.greferencia.HeaderText = "Referencia"
        Me.greferencia.Name = "greferencia"
        Me.greferencia.Visible = False
        '
        'tipo
        '
        Me.tipo.DataPropertyName = "TP"
        Me.tipo.FillWeight = 90.0!
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.Visible = False
        Me.tipo.Width = 80
        '
        'cValorVendaAtacado
        '
        Me.cValorVendaAtacado.DataPropertyName = "ValorVenda2"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.cValorVendaAtacado.DefaultCellStyle = DataGridViewCellStyle8
        Me.cValorVendaAtacado.HeaderText = "Vlr Reposi��o"
        Me.cValorVendaAtacado.Name = "cValorVendaAtacado"
        Me.cValorVendaAtacado.Width = 90
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Foto"
        Me.Column1.HeaderText = "Foto"
        Me.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column1.Name = "Column1"
        '
        'ProcuraProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 680)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "ProcuraProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procurar de Produtos - T009"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Vazio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Display, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtProcura As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents A2 As System.Windows.Forms.RadioButton
    Friend WithEvents A3 As System.Windows.Forms.RadioButton
    Friend WithEvents A1 As System.Windows.Forms.RadioButton
    Friend WithEvents DgvItem As System.Windows.Forms.DataGridView
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbldescProd As System.Windows.Forms.Label
    Friend WithEvents lblMensagem As System.Windows.Forms.Label
    Friend WithEvents lblRef As System.Windows.Forms.Label
    Friend WithEvents A6 As System.Windows.Forms.RadioButton
    Friend WithEvents Display As System.Windows.Forms.PictureBox
    Friend WithEvents Vazio As System.Windows.Forms.PictureBox
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodBarra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Local As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gmarca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estoque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gEmLocacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cQtdLocado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorvenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents greferencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cValorVendaAtacado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
End Class
