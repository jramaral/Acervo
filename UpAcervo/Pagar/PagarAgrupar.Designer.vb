<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PagarAgrupar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PagarAgrupar))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btSalvarParcelas = New DevComponents.DotNetBar.ButtonX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btFindValor = New System.Windows.Forms.Label()
        Me.ContaCRDesc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ContaDespesa = New TexBoxFocusNet.TextBoxFocusNet()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Find1 = New System.Windows.Forms.Label()
        Me.Conta1 = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DescConta1 = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Vlr1 = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Inativo = New System.Windows.Forms.CheckBox()
        Me.btDesfazer = New DevComponents.DotNetBar.ButtonX()
        Me.btLocalizarAgrupamento = New DevComponents.DotNetBar.ButtonX()
        Me.TotParcelado = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListaPagar = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimento = New DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn()
        Me.LocalPgto = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.CodFornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Confirmado = New System.Windows.Forms.CheckBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.DiasParcelamento = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataLancamento = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Lista = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Selecao = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btFindClintes = New System.Windows.Forms.Label()
        Me.btSalvar = New DevComponents.DotNetBar.ButtonX()
        Me.btNovo = New DevComponents.DotNetBar.ButtonX()
        Me.FornecedorDesc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Fornecedor = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ValorAgrupado = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Descricao = New TexBoxFocusNet.TextBoxFocusNet()
        Me.IdAgrupar = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PanelEx1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ListaPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.Label8)
        Me.PanelEx1.Controls.Add(Me.btSalvarParcelas)
        Me.PanelEx1.Controls.Add(Me.Label7)
        Me.PanelEx1.Controls.Add(Me.btFindValor)
        Me.PanelEx1.Controls.Add(Me.ContaCRDesc)
        Me.PanelEx1.Controls.Add(Me.Label16)
        Me.PanelEx1.Controls.Add(Me.ContaDespesa)
        Me.PanelEx1.Controls.Add(Me.GroupPanel1)
        Me.PanelEx1.Controls.Add(Me.Inativo)
        Me.PanelEx1.Controls.Add(Me.btDesfazer)
        Me.PanelEx1.Controls.Add(Me.btLocalizarAgrupamento)
        Me.PanelEx1.Controls.Add(Me.TotParcelado)
        Me.PanelEx1.Controls.Add(Me.Label6)
        Me.PanelEx1.Controls.Add(Me.ListaPagar)
        Me.PanelEx1.Controls.Add(Me.Confirmado)
        Me.PanelEx1.Controls.Add(Me.Label42)
        Me.PanelEx1.Controls.Add(Me.DiasParcelamento)
        Me.PanelEx1.Controls.Add(Me.Label5)
        Me.PanelEx1.Controls.Add(Me.DataLancamento)
        Me.PanelEx1.Controls.Add(Me.Lista)
        Me.PanelEx1.Controls.Add(Me.btFindClintes)
        Me.PanelEx1.Controls.Add(Me.btSalvar)
        Me.PanelEx1.Controls.Add(Me.btNovo)
        Me.PanelEx1.Controls.Add(Me.FornecedorDesc)
        Me.PanelEx1.Controls.Add(Me.Fornecedor)
        Me.PanelEx1.Controls.Add(Me.Label4)
        Me.PanelEx1.Controls.Add(Me.ValorAgrupado)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.Descricao)
        Me.PanelEx1.Controls.Add(Me.IdAgrupar)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.Controls.Add(Me.btFechar)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(887, 550)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'btSalvarParcelas
        '
        Me.btSalvarParcelas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btSalvarParcelas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btSalvarParcelas.Location = New System.Drawing.Point(765, 491)
        Me.btSalvarParcelas.Name = "btSalvarParcelas"
        Me.btSalvarParcelas.Size = New System.Drawing.Size(108, 23)
        Me.btSalvarParcelas.TabIndex = 31
        Me.btSalvarParcelas.Text = "Salvar Parcelas"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(9, 512)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(419, 33)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "O agrupamento só pode ser feito apenas para um centro de custo. "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btFindValor
        '
        Me.btFindValor.Image = CType(resources.GetObject("btFindValor.Image"), System.Drawing.Image)
        Me.btFindValor.Location = New System.Drawing.Point(512, 184)
        Me.btFindValor.Name = "btFindValor"
        Me.btFindValor.Size = New System.Drawing.Size(19, 20)
        Me.btFindValor.TabIndex = 20
        '
        'ContaCRDesc
        '
        Me.ContaCRDesc.AceitaColarTexto = True
        Me.ContaCRDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ContaCRDesc.CasasDecimais = 2
        Me.ContaCRDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContaCRDesc.CPObrigatorio = False
        Me.ContaCRDesc.CPObrigatorioMsg = Nothing
        Me.ContaCRDesc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ContaCRDesc.FlatBorder = False
        Me.ContaCRDesc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ContaCRDesc.FocusColor = System.Drawing.Color.Empty
        Me.ContaCRDesc.FocusColorEnd = System.Drawing.Color.Empty
        Me.ContaCRDesc.HighlightBorderOnEnter = False
        Me.ContaCRDesc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ContaCRDesc.Location = New System.Drawing.Point(533, 184)
        Me.ContaCRDesc.MaxLength = 6
        Me.ContaCRDesc.Name = "ContaCRDesc"
        Me.ContaCRDesc.PreencherZeroEsqueda = False
        Me.ContaCRDesc.RegraValidação = Nothing
        Me.ContaCRDesc.RegraValidaçãoMensagem = Nothing
        Me.ContaCRDesc.Size = New System.Drawing.Size(336, 23)
        Me.ContaCRDesc.TabIndex = 21
        Me.ContaCRDesc.TabStop = False
        Me.ContaCRDesc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ContaCRDesc.ValorPadrao = Nothing
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(448, 159)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(116, 22)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Conta Despesa"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContaDespesa
        '
        Me.ContaDespesa.AceitaColarTexto = True
        Me.ContaDespesa.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.ContaDespesa.CasasDecimais = 2
        Me.ContaDespesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContaDespesa.CPObrigatorio = False
        Me.ContaDespesa.CPObrigatorioMsg = Nothing
        Me.ContaDespesa.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ContaDespesa.FlatBorder = False
        Me.ContaDespesa.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ContaDespesa.FocusColor = System.Drawing.Color.Empty
        Me.ContaDespesa.FocusColorEnd = System.Drawing.Color.Empty
        Me.ContaDespesa.HighlightBorderOnEnter = False
        Me.ContaDespesa.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ContaDespesa.Location = New System.Drawing.Point(448, 184)
        Me.ContaDespesa.MaxLength = 6
        Me.ContaDespesa.Name = "ContaDespesa"
        Me.ContaDespesa.PreencherZeroEsqueda = True
        Me.ContaDespesa.RegraValidação = Nothing
        Me.ContaDespesa.RegraValidaçãoMensagem = Nothing
        Me.ContaDespesa.Size = New System.Drawing.Size(61, 23)
        Me.ContaDespesa.TabIndex = 19
        Me.ContaDespesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ContaDespesa.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ContaDespesa.ValorPadrao = Nothing
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Find1)
        Me.GroupPanel1.Controls.Add(Me.Conta1)
        Me.GroupPanel1.Controls.Add(Me.Label12)
        Me.GroupPanel1.Controls.Add(Me.Label18)
        Me.GroupPanel1.Controls.Add(Me.DescConta1)
        Me.GroupPanel1.Controls.Add(Me.Label19)
        Me.GroupPanel1.Controls.Add(Me.Vlr1)
        Me.GroupPanel1.Location = New System.Drawing.Point(445, 213)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(429, 74)
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
        Me.GroupPanel1.TabIndex = 22
        Me.GroupPanel1.Text = "Contas Centro Custo"
        '
        'Find1
        '
        Me.Find1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Find1.Image = CType(resources.GetObject("Find1.Image"), System.Drawing.Image)
        Me.Find1.Location = New System.Drawing.Point(65, 22)
        Me.Find1.Name = "Find1"
        Me.Find1.Size = New System.Drawing.Size(22, 23)
        Me.Find1.TabIndex = 4
        '
        'Conta1
        '
        Me.Conta1.AceitaColarTexto = True
        Me.Conta1.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Conta1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Conta1.CasasDecimais = 0
        Me.Conta1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Conta1.CPObrigatorio = False
        Me.Conta1.CPObrigatorioMsg = Nothing
        Me.Conta1.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Conta1.FlatBorder = True
        Me.Conta1.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Conta1.FocusColor = System.Drawing.Color.Empty
        Me.Conta1.FocusColorEnd = System.Drawing.Color.Empty
        Me.Conta1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Conta1.HighlightBorderOnEnter = False
        Me.Conta1.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Conta1.Location = New System.Drawing.Point(9, 22)
        Me.Conta1.MaxLength = 6
        Me.Conta1.Name = "Conta1"
        Me.Conta1.PreencherZeroEsqueda = True
        Me.Conta1.RegraValidação = Nothing
        Me.Conta1.RegraValidaçãoMensagem = Nothing
        Me.Conta1.Size = New System.Drawing.Size(57, 23)
        Me.Conta1.TabIndex = 3
        Me.Conta1.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Conta1.ValorPadrao = Nothing
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 21)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Conta"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(345, 2)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 21)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Valor"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DescConta1
        '
        Me.DescConta1.AceitaColarTexto = True
        Me.DescConta1.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.DescConta1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DescConta1.CasasDecimais = 0
        Me.DescConta1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DescConta1.CPObrigatorio = False
        Me.DescConta1.CPObrigatorioMsg = Nothing
        Me.DescConta1.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DescConta1.FlatBorder = True
        Me.DescConta1.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DescConta1.FocusColor = System.Drawing.Color.Empty
        Me.DescConta1.FocusColorEnd = System.Drawing.Color.Empty
        Me.DescConta1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescConta1.HighlightBorderOnEnter = False
        Me.DescConta1.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DescConta1.Location = New System.Drawing.Point(86, 22)
        Me.DescConta1.MaxLength = 100
        Me.DescConta1.Name = "DescConta1"
        Me.DescConta1.PreencherZeroEsqueda = False
        Me.DescConta1.RegraValidação = Nothing
        Me.DescConta1.RegraValidaçãoMensagem = Nothing
        Me.DescConta1.Size = New System.Drawing.Size(260, 23)
        Me.DescConta1.TabIndex = 5
        Me.DescConta1.TabStop = False
        Me.DescConta1.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.DescConta1.ValorPadrao = Nothing
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(65, 2)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(281, 21)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Descrição"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Vlr1
        '
        Me.Vlr1.AceitaColarTexto = True
        Me.Vlr1.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Vlr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Vlr1.CasasDecimais = 2
        Me.Vlr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Vlr1.CPObrigatorio = False
        Me.Vlr1.CPObrigatorioMsg = Nothing
        Me.Vlr1.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Vlr1.FlatBorder = True
        Me.Vlr1.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Vlr1.FocusColor = System.Drawing.Color.Empty
        Me.Vlr1.FocusColorEnd = System.Drawing.Color.Empty
        Me.Vlr1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vlr1.HighlightBorderOnEnter = False
        Me.Vlr1.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Vlr1.Location = New System.Drawing.Point(345, 22)
        Me.Vlr1.MaxLength = 15
        Me.Vlr1.Name = "Vlr1"
        Me.Vlr1.PreencherZeroEsqueda = False
        Me.Vlr1.RegraValidação = Nothing
        Me.Vlr1.RegraValidaçãoMensagem = Nothing
        Me.Vlr1.Size = New System.Drawing.Size(76, 23)
        Me.Vlr1.TabIndex = 6
        Me.Vlr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Vlr1.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Numeros
        Me.Vlr1.ValorPadrao = Nothing
        '
        'Inativo
        '
        Me.Inativo.AutoSize = True
        Me.Inativo.Location = New System.Drawing.Point(615, 34)
        Me.Inativo.Name = "Inativo"
        Me.Inativo.Size = New System.Drawing.Size(64, 19)
        Me.Inativo.TabIndex = 10
        Me.Inativo.Text = "Inativo"
        Me.Inativo.UseVisualStyleBackColor = True
        Me.Inativo.Visible = False
        '
        'btDesfazer
        '
        Me.btDesfazer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btDesfazer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btDesfazer.Location = New System.Drawing.Point(437, 519)
        Me.btDesfazer.Name = "btDesfazer"
        Me.btDesfazer.Size = New System.Drawing.Size(134, 26)
        Me.btDesfazer.TabIndex = 29
        Me.btDesfazer.Text = "Desfazer Agrupamento"
        '
        'btLocalizarAgrupamento
        '
        Me.btLocalizarAgrupamento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btLocalizarAgrupamento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btLocalizarAgrupamento.Location = New System.Drawing.Point(577, 519)
        Me.btLocalizarAgrupamento.Name = "btLocalizarAgrupamento"
        Me.btLocalizarAgrupamento.Size = New System.Drawing.Size(134, 26)
        Me.btLocalizarAgrupamento.TabIndex = 28
        Me.btLocalizarAgrupamento.Text = "Localizar Agrupamento"
        '
        'TotParcelado
        '
        Me.TotParcelado.BackColor = System.Drawing.Color.Transparent
        Me.TotParcelado.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotParcelado.Location = New System.Drawing.Point(538, 490)
        Me.TotParcelado.Name = "TotParcelado"
        Me.TotParcelado.Size = New System.Drawing.Size(108, 19)
        Me.TotParcelado.TabIndex = 25
        Me.TotParcelado.Text = "00,00"
        Me.TotParcelado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(447, 490)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 19)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Total Parcelado"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListaPagar
        '
        Me.ListaPagar.AllowUserToAddRows = False
        Me.ListaPagar.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListaPagar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.ListaPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListaPagar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Documento, Me.ValorDocumento, Me.Vencimento, Me.LocalPgto, Me.CodFornecedor})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListaPagar.DefaultCellStyle = DataGridViewCellStyle11
        Me.ListaPagar.EnableHeadersVisualStyles = False
        Me.ListaPagar.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ListaPagar.Location = New System.Drawing.Point(445, 329)
        Me.ListaPagar.Name = "ListaPagar"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListaPagar.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.ListaPagar.RowHeadersWidth = 20
        Me.ListaPagar.Size = New System.Drawing.Size(427, 156)
        Me.ListaPagar.TabIndex = 23
        '
        'Id
        '
        Me.Id.DataPropertyName = "ID"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Documento
        '
        Me.Documento.DataPropertyName = "Documento"
        Me.Documento.HeaderText = "Documento"
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        '
        'ValorDocumento
        '
        Me.ValorDocumento.DataPropertyName = "ValorDocumento"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.ValorDocumento.DefaultCellStyle = DataGridViewCellStyle10
        Me.ValorDocumento.HeaderText = "Valor"
        Me.ValorDocumento.Name = "ValorDocumento"
        Me.ValorDocumento.Width = 80
        '
        'Vencimento
        '
        Me.Vencimento.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.Vencimento.BackgroundStyle.Class = "DataGridViewBorder"
        Me.Vencimento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Vencimento.Culture = New System.Globalization.CultureInfo("pt-BR")
        Me.Vencimento.DataPropertyName = "Vencimento"
        Me.Vencimento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Vencimento.HeaderText = "Vencimento"
        Me.Vencimento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Vencimento.Mask = "00/00/0000"
        Me.Vencimento.Name = "Vencimento"
        Me.Vencimento.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Vencimento.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Vencimento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Vencimento.Text = "  /  /"
        Me.Vencimento.Width = 80
        '
        'LocalPgto
        '
        Me.LocalPgto.DataPropertyName = "LocalPgto"
        Me.LocalPgto.FillWeight = 120.0!
        Me.LocalPgto.HeaderText = "Local"
        Me.LocalPgto.Items.AddRange(New Object() {"CARTEIRA", "BANCO"})
        Me.LocalPgto.Name = "LocalPgto"
        Me.LocalPgto.ReadOnly = True
        Me.LocalPgto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LocalPgto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.LocalPgto.Width = 120
        '
        'CodFornecedor
        '
        Me.CodFornecedor.DataPropertyName = "CodFornecedor"
        Me.CodFornecedor.HeaderText = "CodFornecedor"
        Me.CodFornecedor.Name = "CodFornecedor"
        Me.CodFornecedor.ReadOnly = True
        Me.CodFornecedor.Visible = False
        '
        'Confirmado
        '
        Me.Confirmado.AutoSize = True
        Me.Confirmado.Location = New System.Drawing.Point(523, 34)
        Me.Confirmado.Name = "Confirmado"
        Me.Confirmado.Size = New System.Drawing.Size(86, 19)
        Me.Confirmado.TabIndex = 9
        Me.Confirmado.Text = "Confirmado"
        Me.Confirmado.UseVisualStyleBackColor = True
        Me.Confirmado.Visible = False
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Location = New System.Drawing.Point(448, 111)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(99, 19)
        Me.Label42.TabIndex = 16
        Me.Label42.Text = "Parcelamento"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DiasParcelamento
        '
        Me.DiasParcelamento.AceitaColarTexto = True
        Me.DiasParcelamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DiasParcelamento.CasasDecimais = 0
        Me.DiasParcelamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DiasParcelamento.CPObrigatorio = False
        Me.DiasParcelamento.CPObrigatorioMsg = Nothing
        Me.DiasParcelamento.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DiasParcelamento.FlatBorder = False
        Me.DiasParcelamento.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DiasParcelamento.FocusColor = System.Drawing.Color.MistyRose
        Me.DiasParcelamento.FocusColorEnd = System.Drawing.Color.Empty
        Me.DiasParcelamento.HighlightBorderOnEnter = False
        Me.DiasParcelamento.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DiasParcelamento.Location = New System.Drawing.Point(448, 133)
        Me.DiasParcelamento.MaxLength = 119
        Me.DiasParcelamento.Name = "DiasParcelamento"
        Me.DiasParcelamento.PreencherZeroEsqueda = False
        Me.DiasParcelamento.RegraValidação = Nothing
        Me.DiasParcelamento.RegraValidaçãoMensagem = Nothing
        Me.DiasParcelamento.Size = New System.Drawing.Size(421, 23)
        Me.DiasParcelamento.TabIndex = 17
        Me.DiasParcelamento.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Parcelamento
        Me.DiasParcelamento.ValorPadrao = Nothing
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(445, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Data de Lançamento"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataLancamento
        '
        Me.DataLancamento.AceitaColarTexto = True
        Me.DataLancamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.DataLancamento.CasasDecimais = 0
        Me.DataLancamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataLancamento.CPObrigatorio = False
        Me.DataLancamento.CPObrigatorioMsg = Nothing
        Me.DataLancamento.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataLancamento.FlatBorder = False
        Me.DataLancamento.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataLancamento.FocusColor = System.Drawing.Color.Empty
        Me.DataLancamento.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataLancamento.HighlightBorderOnEnter = False
        Me.DataLancamento.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataLancamento.Location = New System.Drawing.Point(448, 85)
        Me.DataLancamento.MaxLength = 10
        Me.DataLancamento.Name = "DataLancamento"
        Me.DataLancamento.PreencherZeroEsqueda = False
        Me.DataLancamento.RegraValidação = Nothing
        Me.DataLancamento.RegraValidaçãoMensagem = Nothing
        Me.DataLancamento.Size = New System.Drawing.Size(116, 23)
        Me.DataLancamento.TabIndex = 14
        Me.DataLancamento.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataLancamento.ValorPadrao = Nothing
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cID, Me.cDocumento, Me.cValorDocumento, Me.Selecao})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lista.DefaultCellStyle = DataGridViewCellStyle15
        Me.Lista.EnableHeadersVisualStyles = False
        Me.Lista.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Lista.Location = New System.Drawing.Point(12, 63)
        Me.Lista.Name = "Lista"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.Lista.RowHeadersWidth = 20
        Me.Lista.Size = New System.Drawing.Size(427, 446)
        Me.Lista.TabIndex = 5
        '
        'cID
        '
        Me.cID.DataPropertyName = "ID"
        Me.cID.HeaderText = "ID"
        Me.cID.Name = "cID"
        Me.cID.ReadOnly = True
        Me.cID.Width = 80
        '
        'cDocumento
        '
        Me.cDocumento.DataPropertyName = "Documento"
        Me.cDocumento.HeaderText = "Documento"
        Me.cDocumento.Name = "cDocumento"
        Me.cDocumento.ReadOnly = True
        Me.cDocumento.Width = 120
        '
        'cValorDocumento
        '
        Me.cValorDocumento.DataPropertyName = "ValorDocumento"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.cValorDocumento.DefaultCellStyle = DataGridViewCellStyle14
        Me.cValorDocumento.HeaderText = "Valor Doc"
        Me.cValorDocumento.Name = "cValorDocumento"
        Me.cValorDocumento.ReadOnly = True
        Me.cValorDocumento.Width = 120
        '
        'Selecao
        '
        Me.Selecao.HeaderText = "Select"
        Me.Selecao.Name = "Selecao"
        Me.Selecao.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Selecao.Width = 60
        '
        'btFindClintes
        '
        Me.btFindClintes.Image = CType(resources.GetObject("btFindClintes.Image"), System.Drawing.Image)
        Me.btFindClintes.Location = New System.Drawing.Point(68, 34)
        Me.btFindClintes.Name = "btFindClintes"
        Me.btFindClintes.Size = New System.Drawing.Size(20, 21)
        Me.btFindClintes.TabIndex = 3
        '
        'btSalvar
        '
        Me.btSalvar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btSalvar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btSalvar.Location = New System.Drawing.Point(799, 293)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(74, 23)
        Me.btSalvar.TabIndex = 26
        Me.btSalvar.Text = "Gerar"
        '
        'btNovo
        '
        Me.btNovo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btNovo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btNovo.Location = New System.Drawing.Point(717, 519)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(75, 26)
        Me.btNovo.TabIndex = 27
        Me.btNovo.Text = "Novo"
        '
        'FornecedorDesc
        '
        Me.FornecedorDesc.AceitaColarTexto = True
        Me.FornecedorDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.FornecedorDesc.CasasDecimais = 0
        Me.FornecedorDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.FornecedorDesc.CPObrigatorio = False
        Me.FornecedorDesc.CPObrigatorioMsg = Nothing
        Me.FornecedorDesc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.FornecedorDesc.FlatBorder = False
        Me.FornecedorDesc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.FornecedorDesc.FocusColor = System.Drawing.Color.Empty
        Me.FornecedorDesc.FocusColorEnd = System.Drawing.Color.Empty
        Me.FornecedorDesc.HighlightBorderOnEnter = False
        Me.FornecedorDesc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.FornecedorDesc.Location = New System.Drawing.Point(94, 34)
        Me.FornecedorDesc.MaxLength = 100
        Me.FornecedorDesc.Name = "FornecedorDesc"
        Me.FornecedorDesc.PreencherZeroEsqueda = False
        Me.FornecedorDesc.RegraValidação = Nothing
        Me.FornecedorDesc.RegraValidaçãoMensagem = Nothing
        Me.FornecedorDesc.Size = New System.Drawing.Size(345, 23)
        Me.FornecedorDesc.TabIndex = 4
        Me.FornecedorDesc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.FornecedorDesc.ValorPadrao = Nothing
        '
        'Fornecedor
        '
        Me.Fornecedor.AceitaColarTexto = True
        Me.Fornecedor.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Fornecedor.CasasDecimais = 0
        Me.Fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Fornecedor.CPObrigatorio = False
        Me.Fornecedor.CPObrigatorioMsg = Nothing
        Me.Fornecedor.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Fornecedor.FlatBorder = False
        Me.Fornecedor.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Fornecedor.FocusColor = System.Drawing.Color.Empty
        Me.Fornecedor.FocusColorEnd = System.Drawing.Color.Empty
        Me.Fornecedor.HighlightBorderOnEnter = False
        Me.Fornecedor.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Fornecedor.Location = New System.Drawing.Point(12, 34)
        Me.Fornecedor.MaxLength = 15
        Me.Fornecedor.Name = "Fornecedor"
        Me.Fornecedor.PreencherZeroEsqueda = False
        Me.Fornecedor.RegraValidação = Nothing
        Me.Fornecedor.RegraValidaçãoMensagem = Nothing
        Me.Fornecedor.Size = New System.Drawing.Size(55, 23)
        Me.Fornecedor.TabIndex = 2
        Me.Fornecedor.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.Fornecedor.ValorPadrao = Nothing
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 19)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Fornecedor"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ValorAgrupado
        '
        Me.ValorAgrupado.AceitaColarTexto = True
        Me.ValorAgrupado.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ValorAgrupado.CasasDecimais = 2
        Me.ValorAgrupado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ValorAgrupado.CPObrigatorio = False
        Me.ValorAgrupado.CPObrigatorioMsg = Nothing
        Me.ValorAgrupado.Enabled = False
        Me.ValorAgrupado.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ValorAgrupado.FlatBorder = False
        Me.ValorAgrupado.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ValorAgrupado.FocusColor = System.Drawing.Color.Empty
        Me.ValorAgrupado.FocusColorEnd = System.Drawing.Color.Empty
        Me.ValorAgrupado.HighlightBorderOnEnter = False
        Me.ValorAgrupado.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ValorAgrupado.Location = New System.Drawing.Point(707, 34)
        Me.ValorAgrupado.MaxLength = 15
        Me.ValorAgrupado.Name = "ValorAgrupado"
        Me.ValorAgrupado.PreencherZeroEsqueda = False
        Me.ValorAgrupado.RegraValidação = Nothing
        Me.ValorAgrupado.RegraValidaçãoMensagem = Nothing
        Me.ValorAgrupado.Size = New System.Drawing.Size(162, 23)
        Me.ValorAgrupado.TabIndex = 11
        Me.ValorAgrupado.TabStop = False
        Me.ValorAgrupado.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Numeros
        Me.ValorAgrupado.ValorPadrao = Nothing
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(704, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Valor Agrupado"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(570, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Descrição"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Descricao
        '
        Me.Descricao.AceitaColarTexto = True
        Me.Descricao.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Descricao.CasasDecimais = 0
        Me.Descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Descricao.CPObrigatorio = False
        Me.Descricao.CPObrigatorioMsg = Nothing
        Me.Descricao.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Descricao.FlatBorder = False
        Me.Descricao.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Descricao.FocusColor = System.Drawing.Color.Empty
        Me.Descricao.FocusColorEnd = System.Drawing.Color.Empty
        Me.Descricao.HighlightBorderOnEnter = False
        Me.Descricao.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Descricao.Location = New System.Drawing.Point(570, 85)
        Me.Descricao.MaxLength = 100
        Me.Descricao.Name = "Descricao"
        Me.Descricao.PreencherZeroEsqueda = False
        Me.Descricao.RegraValidação = Nothing
        Me.Descricao.RegraValidaçãoMensagem = Nothing
        Me.Descricao.Size = New System.Drawing.Size(299, 23)
        Me.Descricao.TabIndex = 15
        Me.Descricao.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Descricao.ValorPadrao = Nothing
        '
        'IdAgrupar
        '
        Me.IdAgrupar.AceitaColarTexto = True
        Me.IdAgrupar.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.IdAgrupar.CasasDecimais = 0
        Me.IdAgrupar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.IdAgrupar.CPObrigatorio = False
        Me.IdAgrupar.CPObrigatorioMsg = Nothing
        Me.IdAgrupar.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.IdAgrupar.FlatBorder = False
        Me.IdAgrupar.FlatBorderColor = System.Drawing.Color.DimGray
        Me.IdAgrupar.FocusColor = System.Drawing.Color.Empty
        Me.IdAgrupar.FocusColorEnd = System.Drawing.Color.Empty
        Me.IdAgrupar.HighlightBorderOnEnter = False
        Me.IdAgrupar.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.IdAgrupar.Location = New System.Drawing.Point(448, 34)
        Me.IdAgrupar.MaxLength = 15
        Me.IdAgrupar.Name = "IdAgrupar"
        Me.IdAgrupar.PreencherZeroEsqueda = False
        Me.IdAgrupar.RegraValidação = Nothing
        Me.IdAgrupar.RegraValidaçãoMensagem = Nothing
        Me.IdAgrupar.Size = New System.Drawing.Size(69, 23)
        Me.IdAgrupar.TabIndex = 8
        Me.IdAgrupar.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.IdAgrupar.ValorPadrao = Nothing
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(445, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Id"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Location = New System.Drawing.Point(798, 519)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(75, 26)
        Me.btFechar.TabIndex = 0
        Me.btFechar.Text = "Fechar"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(445, 288)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(349, 40)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Ao alterar valor ou data do vencimento das parcelas           Salve as Parcelas."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PagarAgrupar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 550)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PagarAgrupar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agrupamento de Contas a Pagar - T277"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.ListaPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents IdAgrupar As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ValorAgrupado As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Descricao As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents btSalvar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btNovo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents FornecedorDesc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Fornecedor As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btFindClintes As System.Windows.Forms.Label
    Friend WithEvents Lista As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataLancamento As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents DiasParcelamento As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents ListaPagar As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Confirmado As System.Windows.Forms.CheckBox
    Friend WithEvents TotParcelado As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btLocalizarAgrupamento As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btDesfazer As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Inativo As System.Windows.Forms.CheckBox
    Friend WithEvents cID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cValorDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Selecao As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Find1 As System.Windows.Forms.Label
    Public WithEvents Conta1 As TexBoxFocusNet.TextBoxFocusNet
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents DescConta1 As TexBoxFocusNet.TextBoxFocusNet
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Vlr1 As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents btFindValor As System.Windows.Forms.Label
    Friend WithEvents ContaCRDesc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ContaDespesa As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btSalvarParcelas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimento As DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn
    Friend WithEvents LocalPgto As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents CodFornecedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
