<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrcamentoBuscaProduto
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtProcura = New TexBoxFocusNet.TextBoxFocusNet()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.A2 = New System.Windows.Forms.RadioButton()
        Me.A1 = New System.Windows.Forms.RadioButton()
        Me.A3 = New System.Windows.Forms.RadioButton()
        Me.Lista = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodigoBarra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoFabrica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Local = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estoque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.glocado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorvenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.foto = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PanelEx1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.Lista)
        Me.PanelEx1.Controls.Add(Me.GroupBox1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(836, 411)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.A2)
        Me.GroupBox1.Controls.Add(Me.A1)
        Me.GroupBox1.Controls.Add(Me.A3)
        Me.GroupBox1.Controls.Add(Me.ButtonX2)
        Me.GroupBox1.Controls.Add(Me.txtProcura)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(812, 75)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'txtProcura
        '
        Me.txtProcura.AceitaColarTexto = True
        Me.txtProcura.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtProcura.CasasDecimais = 2
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
        Me.txtProcura.Location = New System.Drawing.Point(6, 49)
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.PreencherZeroEsqueda = False
        Me.txtProcura.RegraValidação = Nothing
        Me.txtProcura.RegraValidaçãoMensagem = Nothing
        Me.txtProcura.Size = New System.Drawing.Size(418, 20)
        Me.txtProcura.TabIndex = 2
        Me.txtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtProcura.ValorPadrao = Nothing
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Location = New System.Drawing.Point(430, 46)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(69, 23)
        Me.ButtonX2.TabIndex = 3
        Me.ButtonX2.TabStop = False
        Me.ButtonX2.Text = "Fechar"
        '
        'A2
        '
        Me.A2.AutoSize = True
        Me.A2.Checked = True
        Me.A2.Location = New System.Drawing.Point(103, 19)
        Me.A2.Name = "A2"
        Me.A2.Size = New System.Drawing.Size(94, 17)
        Me.A2.TabIndex = 8
        Me.A2.TabStop = True
        Me.A2.Text = "Descrição [F4]"
        Me.A2.UseVisualStyleBackColor = True
        '
        'A1
        '
        Me.A1.AutoSize = True
        Me.A1.Location = New System.Drawing.Point(6, 19)
        Me.A1.Name = "A1"
        Me.A1.Size = New System.Drawing.Size(79, 17)
        Me.A1.TabIndex = 7
        Me.A1.Text = "Código [F3]"
        Me.A1.UseVisualStyleBackColor = True
        '
        'A3
        '
        Me.A3.AutoSize = True
        Me.A3.Location = New System.Drawing.Point(203, 19)
        Me.A3.Name = "A3"
        Me.A3.Size = New System.Drawing.Size(114, 17)
        Me.A3.TabIndex = 9
        Me.A3.Text = "Mostrar Todos [F7]"
        Me.A3.UseVisualStyleBackColor = True
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        Me.Lista.AllowUserToResizeColumns = False
        Me.Lista.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Lista.BackgroundColor = System.Drawing.Color.White
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.cCodigoBarra, Me.CodigoFabrica, Me.Desc, Me.cCor, Me.unidade, Me.Local, Me.estoque, Me.glocado, Me.valorvenda, Me.foto})
        Me.Lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Lista.Location = New System.Drawing.Point(12, 93)
        Me.Lista.MultiSelect = False
        Me.Lista.Name = "Lista"
        Me.Lista.RowHeadersVisible = False
        Me.Lista.RowHeadersWidth = 15
        Me.Lista.RowTemplate.Height = 60
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(812, 286)
        Me.Lista.TabIndex = 2
        '
        'codigo
        '
        Me.codigo.DataPropertyName = "CodigoProduto"
        Me.codigo.HeaderText = "Código"
        Me.codigo.Name = "codigo"
        Me.codigo.Visible = False
        Me.codigo.Width = 70
        '
        'cCodigoBarra
        '
        Me.cCodigoBarra.DataPropertyName = "CodigoBarra"
        DataGridViewCellStyle2.Format = """00000"""
        Me.cCodigoBarra.DefaultCellStyle = DataGridViewCellStyle2
        Me.cCodigoBarra.HeaderText = "Cod. Prod"
        Me.cCodigoBarra.Name = "cCodigoBarra"
        Me.cCodigoBarra.Width = 80
        '
        'CodigoFabrica
        '
        Me.CodigoFabrica.DataPropertyName = "CodigoFabrica"
        Me.CodigoFabrica.HeaderText = "Cod. Fábrica"
        Me.CodigoFabrica.Name = "CodigoFabrica"
        Me.CodigoFabrica.Visible = False
        '
        'Desc
        '
        Me.Desc.DataPropertyName = "Descrição"
        Me.Desc.HeaderText = "Descrição"
        Me.Desc.Name = "Desc"
        Me.Desc.Width = 290
        '
        'cCor
        '
        Me.cCor.DataPropertyName = "CorDesc"
        Me.cCor.HeaderText = "Cor"
        Me.cCor.Name = "cCor"
        Me.cCor.Width = 80
        '
        'unidade
        '
        Me.unidade.DataPropertyName = "UnidadeMedida"
        Me.unidade.HeaderText = "Un"
        Me.unidade.Name = "unidade"
        Me.unidade.Width = 35
        '
        'Local
        '
        Me.Local.DataPropertyName = "SetorLocalDesc"
        DataGridViewCellStyle3.NullValue = "Não Locado"
        Me.Local.DefaultCellStyle = DataGridViewCellStyle3
        Me.Local.HeaderText = "Local"
        Me.Local.MaxInputLength = 20
        Me.Local.Name = "Local"
        Me.Local.Visible = False
        Me.Local.Width = 80
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
        'glocado
        '
        Me.glocado.DataPropertyName = "QtdeLocado"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red
        Me.glocado.DefaultCellStyle = DataGridViewCellStyle5
        Me.glocado.HeaderText = "Nº vezes Locado"
        Me.glocado.Name = "glocado"
        Me.glocado.Width = 110
        '
        'valorvenda
        '
        Me.valorvenda.DataPropertyName = "ValorVenda"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0,00"
        Me.valorvenda.DefaultCellStyle = DataGridViewCellStyle6
        Me.valorvenda.HeaderText = "Vlr Venda"
        Me.valorvenda.Name = "valorvenda"
        '
        'foto
        '
        Me.foto.DataPropertyName = "foto"
        Me.foto.HeaderText = "Foto"
        Me.foto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.foto.Name = "foto"
        '
        'OrcamentoBuscaProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 411)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "OrcamentoBuscaProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orcamento -> Busca Produto"
        Me.PanelEx1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtProcura As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents A2 As RadioButton
    Friend WithEvents A1 As RadioButton
    Friend WithEvents A3 As RadioButton
    Friend WithEvents Lista As DataGridView
    Friend WithEvents codigo As DataGridViewTextBoxColumn
    Friend WithEvents cCodigoBarra As DataGridViewTextBoxColumn
    Friend WithEvents CodigoFabrica As DataGridViewTextBoxColumn
    Friend WithEvents Desc As DataGridViewTextBoxColumn
    Friend WithEvents cCor As DataGridViewTextBoxColumn
    Friend WithEvents unidade As DataGridViewTextBoxColumn
    Friend WithEvents Local As DataGridViewTextBoxColumn
    Friend WithEvents estoque As DataGridViewTextBoxColumn
    Friend WithEvents glocado As DataGridViewTextBoxColumn
    Friend WithEvents valorvenda As DataGridViewTextBoxColumn
    Friend WithEvents foto As DataGridViewImageColumn
End Class
