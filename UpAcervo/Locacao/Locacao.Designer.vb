<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Locacao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Locacao))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.btnImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.chkProdutosEntregue = New System.Windows.Forms.CheckBox()
        Me.btnEntregar = New DevComponents.DotNetBar.ButtonX()
        Me.cboVendedor = New CBOAutoCompleteFocus.CboFocus()
        Me.cboDevolve = New CBOAutoCompleteFocus.CboFocus()
        Me.cboEntrega = New CBOAutoCompleteFocus.CboFocus()
        Me.txtLocalEntrega = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtPlaca = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboTransportadora = New CBOAutoCompleteFocus.CboFocus()
        Me.StatusLoc = New System.Windows.Forms.Label()
        Me.Frete = New CBOAutoCompleteFocus.CboFocus()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DiariaAmais = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.HoraRetorno = New TexBoxFocusNet.TextBoxFocusNet()
        Me.HoraLoc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DataRetorno = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btConfirmarLocacao = New DevComponents.DotNetBar.ButtonX()
        Me.btProcuraLocacao = New DevComponents.DotNetBar.ButtonX()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CodBarra = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Qtd = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btNovo = New DevComponents.DotNetBar.ButtonX()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btObterEndereço = New DevComponents.DotNetBar.ButtonX()
        Me.ObsLoc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Decorador = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtcontato = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Telefone = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ClienteNome = New TexBoxFocusNet.TextBoxFocusNet()
        Me.CPFCNPJ = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cliente = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataLoc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lista = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cbtExcluir = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.cIdItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescrição = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorUnitarioLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorDescontoLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalDiarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtdDev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtdAvarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorUnitarioAvarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalAvarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdLoc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtOutrosAjustes = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tDesconto = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tItens = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ValorFrete = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tDiariaAmais = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TotalLoc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Fundo.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.Panel1.SuspendLayout
        CType(Me.Lista,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel3.SuspendLayout
        Me.SuspendLayout
        '
        'Fundo
        '
        Me.Fundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Fundo.Controls.Add(Me.btnImprimir)
        Me.Fundo.Controls.Add(Me.chkProdutosEntregue)
        Me.Fundo.Controls.Add(Me.btnEntregar)
        Me.Fundo.Controls.Add(Me.cboVendedor)
        Me.Fundo.Controls.Add(Me.cboDevolve)
        Me.Fundo.Controls.Add(Me.cboEntrega)
        Me.Fundo.Controls.Add(Me.txtLocalEntrega)
        Me.Fundo.Controls.Add(Me.txtPlaca)
        Me.Fundo.Controls.Add(Me.Label22)
        Me.Fundo.Controls.Add(Me.cboTransportadora)
        Me.Fundo.Controls.Add(Me.StatusLoc)
        Me.Fundo.Controls.Add(Me.Frete)
        Me.Fundo.Controls.Add(Me.Label21)
        Me.Fundo.Controls.Add(Me.Label23)
        Me.Fundo.Controls.Add(Me.Label16)
        Me.Fundo.Controls.Add(Me.DiariaAmais)
        Me.Fundo.Controls.Add(Me.Label2)
        Me.Fundo.Controls.Add(Me.HoraRetorno)
        Me.Fundo.Controls.Add(Me.HoraLoc)
        Me.Fundo.Controls.Add(Me.Label27)
        Me.Fundo.Controls.Add(Me.DataRetorno)
        Me.Fundo.Controls.Add(Me.Label26)
        Me.Fundo.Controls.Add(Me.Label25)
        Me.Fundo.Controls.Add(Me.Label14)
        Me.Fundo.Controls.Add(Me.btConfirmarLocacao)
        Me.Fundo.Controls.Add(Me.btProcuraLocacao)
        Me.Fundo.Controls.Add(Me.Label12)
        Me.Fundo.Controls.Add(Me.Label11)
        Me.Fundo.Controls.Add(Me.CodBarra)
        Me.Fundo.Controls.Add(Me.Qtd)
        Me.Fundo.Controls.Add(Me.Label10)
        Me.Fundo.Controls.Add(Me.Label9)
        Me.Fundo.Controls.Add(Me.btNovo)
        Me.Fundo.Controls.Add(Me.Fechar)
        Me.Fundo.Controls.Add(Me.Label8)
        Me.Fundo.Controls.Add(Me.Panel2)
        Me.Fundo.Controls.Add(Me.Label4)
        Me.Fundo.Controls.Add(Me.Panel1)
        Me.Fundo.Controls.Add(Me.DataLoc)
        Me.Fundo.Controls.Add(Me.Label3)
        Me.Fundo.Controls.Add(Me.Lista)
        Me.Fundo.Controls.Add(Me.IdLoc)
        Me.Fundo.Controls.Add(Me.Label1)
        Me.Fundo.Controls.Add(Me.Panel3)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(984, 673)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'btnImprimir
        '
        Me.btnImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnImprimir.Enabled = false
        Me.btnImprimir.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"),System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(527, 626)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(112, 42)
        Me.btnImprimir.TabIndex = 43
        Me.btnImprimir.TabStop = false
        Me.btnImprimir.Text = "2ª Via"
        '
        'chkProdutosEntregue
        '
        Me.chkProdutosEntregue.AutoSize = true
        Me.chkProdutosEntregue.Enabled = false
        Me.chkProdutosEntregue.Location = New System.Drawing.Point(15, 642)
        Me.chkProdutosEntregue.Name = "chkProdutosEntregue"
        Me.chkProdutosEntregue.Size = New System.Drawing.Size(119, 19)
        Me.chkProdutosEntregue.TabIndex = 42
        Me.chkProdutosEntregue.Text = "Produtos Entregue"
        Me.chkProdutosEntregue.UseVisualStyleBackColor = true
        '
        'btnEntregar
        '
        Me.btnEntregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEntregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEntregar.Enabled = false
        Me.btnEntregar.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnEntregar.Image = CType(resources.GetObject("btnEntregar.Image"),System.Drawing.Image)
        Me.btnEntregar.Location = New System.Drawing.Point(410, 629)
        Me.btnEntregar.Name = "btnEntregar"
        Me.btnEntregar.Size = New System.Drawing.Size(112, 42)
        Me.btnEntregar.TabIndex = 41
        Me.btnEntregar.TabStop = false
        Me.btnEntregar.Text = "Entregar"
        '
        'cboVendedor
        '
        Me.cboVendedor.Auto_Complete = true
        Me.cboVendedor.AutoLimitar_Lista = true
        Me.cboVendedor.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.cboVendedor.CPObrigatorio = false
        Me.cboVendedor.CPObrigatorioMsg = Nothing
        Me.cboVendedor.FlatBorder = true
        Me.cboVendedor.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboVendedor.FormattingEnabled = true
        Me.cboVendedor.HighlightBorderColor = System.Drawing.Color.Empty
        Me.cboVendedor.HighlightBorderOnEnter = false
        Me.cboVendedor.Items.AddRange(New Object() {"D. Fujii Retira", "Cliente Devolve"})
        Me.cboVendedor.Location = New System.Drawing.Point(800, 108)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(168, 23)
        Me.cboVendedor.TabIndex = 16
        '
        'cboDevolve
        '
        Me.cboDevolve.Auto_Complete = true
        Me.cboDevolve.AutoLimitar_Lista = true
        Me.cboDevolve.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.cboDevolve.CPObrigatorio = false
        Me.cboDevolve.CPObrigatorioMsg = Nothing
        Me.cboDevolve.FlatBorder = true
        Me.cboDevolve.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboDevolve.FormattingEnabled = true
        Me.cboDevolve.HighlightBorderColor = System.Drawing.Color.Empty
        Me.cboDevolve.HighlightBorderOnEnter = false
        Me.cboDevolve.Items.AddRange(New Object() {"D. Fujii Retira", "Cliente Devolve"})
        Me.cboDevolve.Location = New System.Drawing.Point(603, 77)
        Me.cboDevolve.Name = "cboDevolve"
        Me.cboDevolve.Size = New System.Drawing.Size(133, 23)
        Me.cboDevolve.TabIndex = 14
        '
        'cboEntrega
        '
        Me.cboEntrega.Auto_Complete = true
        Me.cboEntrega.AutoLimitar_Lista = true
        Me.cboEntrega.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.cboEntrega.CPObrigatorio = false
        Me.cboEntrega.CPObrigatorioMsg = Nothing
        Me.cboEntrega.FlatBorder = true
        Me.cboEntrega.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboEntrega.FormattingEnabled = true
        Me.cboEntrega.HighlightBorderColor = System.Drawing.Color.Empty
        Me.cboEntrega.HighlightBorderOnEnter = false
        Me.cboEntrega.Items.AddRange(New Object() {"D. Fujii", "Cliente Retira"})
        Me.cboEntrega.Location = New System.Drawing.Point(603, 49)
        Me.cboEntrega.Name = "cboEntrega"
        Me.cboEntrega.Size = New System.Drawing.Size(133, 23)
        Me.cboEntrega.TabIndex = 13
        '
        'txtLocalEntrega
        '
        Me.txtLocalEntrega.AceitaColarTexto = false
        Me.txtLocalEntrega.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtLocalEntrega.CasasDecimais = 0
        Me.txtLocalEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocalEntrega.CPObrigatorio = false
        Me.txtLocalEntrega.CPObrigatorioMsg = Nothing
        Me.txtLocalEntrega.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtLocalEntrega.FlatBorder = false
        Me.txtLocalEntrega.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtLocalEntrega.FocusColor = System.Drawing.Color.Empty
        Me.txtLocalEntrega.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtLocalEntrega.HighlightBorderOnEnter = false
        Me.txtLocalEntrega.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtLocalEntrega.Location = New System.Drawing.Point(161, 107)
        Me.txtLocalEntrega.MaxLength = 100
        Me.txtLocalEntrega.Name = "txtLocalEntrega"
        Me.txtLocalEntrega.PreencherZeroEsqueda = false
        Me.txtLocalEntrega.RegraValidação = Nothing
        Me.txtLocalEntrega.RegraValidaçãoMensagem = Nothing
        Me.txtLocalEntrega.ShortcutsEnabled = false
        Me.txtLocalEntrega.Size = New System.Drawing.Size(575, 23)
        Me.txtLocalEntrega.TabIndex = 15
        Me.txtLocalEntrega.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtLocalEntrega.ValorPadrao = Nothing
        '
        'txtPlaca
        '
        Me.txtPlaca.AceitaColarTexto = false
        Me.txtPlaca.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtPlaca.CasasDecimais = 0
        Me.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlaca.CPObrigatorio = false
        Me.txtPlaca.CPObrigatorioMsg = Nothing
        Me.txtPlaca.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtPlaca.FlatBorder = false
        Me.txtPlaca.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtPlaca.FocusColor = System.Drawing.Color.Empty
        Me.txtPlaca.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtPlaca.HighlightBorderOnEnter = false
        Me.txtPlaca.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtPlaca.Location = New System.Drawing.Point(436, 78)
        Me.txtPlaca.MaxLength = 7
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.PreencherZeroEsqueda = false
        Me.txtPlaca.RegraValidação = Nothing
        Me.txtPlaca.RegraValidaçãoMensagem = Nothing
        Me.txtPlaca.ShortcutsEnabled = false
        Me.txtPlaca.Size = New System.Drawing.Size(92, 23)
        Me.txtPlaca.TabIndex = 12
        Me.txtPlaca.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtPlaca.ValorPadrao = Nothing
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(391, 77)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 22)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "Placa"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTransportadora
        '
        Me.cboTransportadora.Auto_Complete = true
        Me.cboTransportadora.AutoLimitar_Lista = true
        Me.cboTransportadora.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.cboTransportadora.CPObrigatorio = false
        Me.cboTransportadora.CPObrigatorioMsg = Nothing
        Me.cboTransportadora.FlatBorder = true
        Me.cboTransportadora.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboTransportadora.FormattingEnabled = true
        Me.cboTransportadora.HighlightBorderColor = System.Drawing.Color.Empty
        Me.cboTransportadora.HighlightBorderOnEnter = false
        Me.cboTransportadora.Location = New System.Drawing.Point(161, 76)
        Me.cboTransportadora.Name = "cboTransportadora"
        Me.cboTransportadora.Size = New System.Drawing.Size(220, 23)
        Me.cboTransportadora.TabIndex = 11
        '
        'StatusLoc
        '
        Me.StatusLoc.BackColor = System.Drawing.Color.Transparent
        Me.StatusLoc.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.StatusLoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.StatusLoc.Location = New System.Drawing.Point(751, 76)
        Me.StatusLoc.Name = "StatusLoc"
        Me.StatusLoc.Size = New System.Drawing.Size(218, 25)
        Me.StatusLoc.TabIndex = 39
        Me.StatusLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Frete
        '
        Me.Frete.Auto_Complete = true
        Me.Frete.AutoLimitar_Lista = true
        Me.Frete.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.Frete.CPObrigatorio = false
        Me.Frete.CPObrigatorioMsg = Nothing
        Me.Frete.FlatBorder = true
        Me.Frete.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Frete.FormattingEnabled = true
        Me.Frete.HighlightBorderColor = System.Drawing.Color.Empty
        Me.Frete.HighlightBorderOnEnter = false
        Me.Frete.Location = New System.Drawing.Point(161, 49)
        Me.Frete.Name = "Frete"
        Me.Frete.Size = New System.Drawing.Size(367, 23)
        Me.Frete.TabIndex = 10
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(12, 76)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(141, 22)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "Trasnportadora"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(12, 103)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(95, 22)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Local Entrega"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(12, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(141, 22)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Frete para"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DiariaAmais
        '
        Me.DiariaAmais.AceitaColarTexto = false
        Me.DiariaAmais.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DiariaAmais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DiariaAmais.CasasDecimais = 0
        Me.DiariaAmais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DiariaAmais.CPObrigatorio = false
        Me.DiariaAmais.CPObrigatorioMsg = Nothing
        Me.DiariaAmais.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DiariaAmais.FlatBorder = true
        Me.DiariaAmais.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DiariaAmais.FocusColor = System.Drawing.Color.Empty
        Me.DiariaAmais.FocusColorEnd = System.Drawing.Color.Empty
        Me.DiariaAmais.HighlightBorderOnEnter = false
        Me.DiariaAmais.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DiariaAmais.Location = New System.Drawing.Point(910, 23)
        Me.DiariaAmais.MaxLength = 15
        Me.DiariaAmais.Name = "DiariaAmais"
        Me.DiariaAmais.PreencherZeroEsqueda = false
        Me.DiariaAmais.RegraValidação = Nothing
        Me.DiariaAmais.RegraValidaçãoMensagem = Nothing
        Me.DiariaAmais.ShortcutsEnabled = false
        Me.DiariaAmais.Size = New System.Drawing.Size(58, 23)
        Me.DiariaAmais.TabIndex = 9
        Me.DiariaAmais.TabStop = false
        Me.DiariaAmais.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DiariaAmais.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.DiariaAmais.ValorPadrao = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(815, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 22)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Diárias a Mais"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HoraRetorno
        '
        Me.HoraRetorno.AceitaColarTexto = false
        Me.HoraRetorno.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.HoraRetorno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HoraRetorno.CasasDecimais = 0
        Me.HoraRetorno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.HoraRetorno.CPObrigatorio = false
        Me.HoraRetorno.CPObrigatorioMsg = Nothing
        Me.HoraRetorno.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.HoraRetorno.FlatBorder = true
        Me.HoraRetorno.FlatBorderColor = System.Drawing.Color.DimGray
        Me.HoraRetorno.FocusColor = System.Drawing.Color.Empty
        Me.HoraRetorno.FocusColorEnd = System.Drawing.Color.Empty
        Me.HoraRetorno.HighlightBorderOnEnter = false
        Me.HoraRetorno.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.HoraRetorno.Location = New System.Drawing.Point(751, 24)
        Me.HoraRetorno.MaxLength = 8
        Me.HoraRetorno.Name = "HoraRetorno"
        Me.HoraRetorno.PreencherZeroEsqueda = false
        Me.HoraRetorno.RegraValidação = Nothing
        Me.HoraRetorno.RegraValidaçãoMensagem = Nothing
        Me.HoraRetorno.ShortcutsEnabled = false
        Me.HoraRetorno.Size = New System.Drawing.Size(58, 23)
        Me.HoraRetorno.TabIndex = 8
        Me.HoraRetorno.TabStop = false
        Me.HoraRetorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HoraRetorno.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Hora
        Me.HoraRetorno.ValorPadrao = Nothing
        '
        'HoraLoc
        '
        Me.HoraLoc.AceitaColarTexto = false
        Me.HoraLoc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.HoraLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HoraLoc.CasasDecimais = 0
        Me.HoraLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.HoraLoc.CPObrigatorio = false
        Me.HoraLoc.CPObrigatorioMsg = Nothing
        Me.HoraLoc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.HoraLoc.FlatBorder = true
        Me.HoraLoc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.HoraLoc.FocusColor = System.Drawing.Color.Empty
        Me.HoraLoc.FocusColorEnd = System.Drawing.Color.Empty
        Me.HoraLoc.HighlightBorderOnEnter = false
        Me.HoraLoc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.HoraLoc.Location = New System.Drawing.Point(470, 22)
        Me.HoraLoc.MaxLength = 8
        Me.HoraLoc.Name = "HoraLoc"
        Me.HoraLoc.PreencherZeroEsqueda = false
        Me.HoraLoc.RegraValidação = Nothing
        Me.HoraLoc.RegraValidaçãoMensagem = Nothing
        Me.HoraLoc.ShortcutsEnabled = false
        Me.HoraLoc.Size = New System.Drawing.Size(58, 23)
        Me.HoraLoc.TabIndex = 6
        Me.HoraLoc.TabStop = false
        Me.HoraLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HoraLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Hora
        Me.HoraLoc.ValorPadrao = Nothing
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(741, 110)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 22)
        Me.Label27.TabIndex = 34
        Me.Label27.Text = "Vendedor"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataRetorno
        '
        Me.DataRetorno.AceitaColarTexto = false
        Me.DataRetorno.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DataRetorno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataRetorno.CasasDecimais = 0
        Me.DataRetorno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataRetorno.CPObrigatorio = false
        Me.DataRetorno.CPObrigatorioMsg = Nothing
        Me.DataRetorno.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataRetorno.FlatBorder = true
        Me.DataRetorno.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataRetorno.FocusColor = System.Drawing.Color.Empty
        Me.DataRetorno.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataRetorno.HighlightBorderOnEnter = false
        Me.DataRetorno.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataRetorno.Location = New System.Drawing.Point(603, 22)
        Me.DataRetorno.MaxLength = 10
        Me.DataRetorno.Name = "DataRetorno"
        Me.DataRetorno.PreencherZeroEsqueda = false
        Me.DataRetorno.ReadOnly = True
        Me.DataRetorno.RegraValidação = Nothing
        Me.DataRetorno.RegraValidaçãoMensagem = Nothing
        Me.DataRetorno.ShortcutsEnabled = False
        Me.DataRetorno.Size = New System.Drawing.Size(133, 23)
        Me.DataRetorno.TabIndex = 7
        Me.DataRetorno.TabStop = False
        Me.DataRetorno.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataRetorno.ValorPadrao = Nothing
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(532, 77)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(61, 22)
        Me.Label26.TabIndex = 33
        Me.Label26.Text = "Devolve"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(532, 47)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 22)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "Entrega"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(529, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 22)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Data Retorno"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btConfirmarLocacao
        '
        Me.btConfirmarLocacao.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btConfirmarLocacao.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btConfirmarLocacao.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConfirmarLocacao.Image = CType(resources.GetObject("btConfirmarLocacao.Image"), System.Drawing.Image)
        Me.btConfirmarLocacao.Location = New System.Drawing.Point(759, 625)
        Me.btConfirmarLocacao.Name = "btConfirmarLocacao"
        Me.btConfirmarLocacao.Size = New System.Drawing.Size(112, 41)
        Me.btConfirmarLocacao.TabIndex = 31
        Me.btConfirmarLocacao.TabStop = False
        Me.btConfirmarLocacao.Text = "Confirmar Locação"
        '
        'btProcuraLocacao
        '
        Me.btProcuraLocacao.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btProcuraLocacao.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btProcuraLocacao.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btProcuraLocacao.Image = CType(resources.GetObject("btProcuraLocacao.Image"), System.Drawing.Image)
        Me.btProcuraLocacao.Location = New System.Drawing.Point(641, 625)
        Me.btProcuraLocacao.Name = "btProcuraLocacao"
        Me.btProcuraLocacao.Size = New System.Drawing.Size(112, 42)
        Me.btProcuraLocacao.TabIndex = 0
        Me.btProcuraLocacao.TabStop = False
        Me.btProcuraLocacao.Text = "Localizar Locação"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(27, 548)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 22)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Totais da Locação"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(455, 251)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(379, 22)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Pressione [F5] para Procurar o produto [F6] - Para editar a Quantidade"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CodBarra
        '
        Me.CodBarra.AceitaColarTexto = False
        Me.CodBarra.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.CodBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CodBarra.CasasDecimais = 0
        Me.CodBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CodBarra.CPObrigatorio = False
        Me.CodBarra.CPObrigatorioMsg = Nothing
        Me.CodBarra.Enabled = False
        Me.CodBarra.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.CodBarra.FlatBorder = True
        Me.CodBarra.FlatBorderColor = System.Drawing.Color.DimGray
        Me.CodBarra.FocusColor = System.Drawing.Color.Empty
        Me.CodBarra.FocusColorEnd = System.Drawing.Color.Empty
        Me.CodBarra.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodBarra.HighlightBorderOnEnter = False
        Me.CodBarra.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.CodBarra.Location = New System.Drawing.Point(161, 249)
        Me.CodBarra.MaxLength = 15
        Me.CodBarra.Name = "CodBarra"
        Me.CodBarra.PreencherZeroEsqueda = False
        Me.CodBarra.RegraValidação = Nothing
        Me.CodBarra.RegraValidaçãoMensagem = Nothing
        Me.CodBarra.ShortcutsEnabled = False
        Me.CodBarra.Size = New System.Drawing.Size(220, 23)
        Me.CodBarra.TabIndex = 23
        Me.CodBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CodBarra.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.CodBarra.ValorPadrao = Nothing
        '
        'Qtd
        '
        Me.Qtd.AceitaColarTexto = False
        Me.Qtd.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Qtd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Qtd.CasasDecimais = 0
        Me.Qtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Qtd.CPObrigatorio = False
        Me.Qtd.CPObrigatorioMsg = Nothing
        Me.Qtd.Enabled = False
        Me.Qtd.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Qtd.FlatBorder = True
        Me.Qtd.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Qtd.FocusColor = System.Drawing.Color.Empty
        Me.Qtd.FocusColorEnd = System.Drawing.Color.Empty
        Me.Qtd.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qtd.HighlightBorderOnEnter = False
        Me.Qtd.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Qtd.Location = New System.Drawing.Point(387, 249)
        Me.Qtd.MaxLength = 15
        Me.Qtd.Name = "Qtd"
        Me.Qtd.PreencherZeroEsqueda = False
        Me.Qtd.RegraValidação = Nothing
        Me.Qtd.RegraValidaçãoMensagem = Nothing
        Me.Qtd.ShortcutsEnabled = False
        Me.Qtd.Size = New System.Drawing.Size(57, 23)
        Me.Qtd.TabIndex = 24
        Me.Qtd.TabStop = False
        Me.Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Qtd.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.Qtd.ValorPadrao = Nothing
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(19, 251)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 22)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Qtd / Código de Barra"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(860, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 22)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Status da Locação"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btNovo
        '
        Me.btNovo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btNovo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btNovo.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNovo.Image = CType(resources.GetObject("btNovo.Image"), System.Drawing.Image)
        Me.btNovo.Location = New System.Drawing.Point(174, 629)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(112, 41)
        Me.btNovo.TabIndex = 29
        Me.btNovo.TabStop = False
        Me.btNovo.Text = "Nova Locação"
        Me.btNovo.Visible = False
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fechar.Image = CType(resources.GetObject("Fechar.Image"), System.Drawing.Image)
        Me.Fechar.Location = New System.Drawing.Point(877, 625)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(95, 41)
        Me.Fechar.TabIndex = 30
        Me.Fechar.TabStop = False
        Me.Fechar.Text = "Fechar"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(656, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 22)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Observações"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btObterEndereço)
        Me.Panel2.Controls.Add(Me.ObsLoc)
        Me.Panel2.Location = New System.Drawing.Point(647, 137)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(325, 105)
        Me.Panel2.TabIndex = 21
        '
        'btObterEndereço
        '
        Me.btObterEndereço.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btObterEndereço.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btObterEndereço.Location = New System.Drawing.Point(4, 83)
        Me.btObterEndereço.Name = "btObterEndereço"
        Me.btObterEndereço.Size = New System.Drawing.Size(113, 18)
        Me.btObterEndereço.TabIndex = 1
        Me.btObterEndereço.TabStop = False
        Me.btObterEndereço.Text = "Obter do  Cadastro"
        '
        'ObsLoc
        '
        Me.ObsLoc.AceitaColarTexto = True
        Me.ObsLoc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.ObsLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ObsLoc.CasasDecimais = 0
        Me.ObsLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ObsLoc.CPObrigatorio = False
        Me.ObsLoc.CPObrigatorioMsg = Nothing
        Me.ObsLoc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ObsLoc.FlatBorder = True
        Me.ObsLoc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ObsLoc.FocusColor = System.Drawing.Color.Empty
        Me.ObsLoc.FocusColorEnd = System.Drawing.Color.Empty
        Me.ObsLoc.HighlightBorderOnEnter = False
        Me.ObsLoc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ObsLoc.Location = New System.Drawing.Point(3, 11)
        Me.ObsLoc.MaxLength = 1500
        Me.ObsLoc.Multiline = True
        Me.ObsLoc.Name = "ObsLoc"
        Me.ObsLoc.PreencherZeroEsqueda = False
        Me.ObsLoc.RegraValidação = Nothing
        Me.ObsLoc.RegraValidaçãoMensagem = Nothing
        Me.ObsLoc.Size = New System.Drawing.Size(317, 70)
        Me.ObsLoc.TabIndex = 0
        Me.ObsLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ObsLoc.ValorPadrao = Nothing
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(20, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 22)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Dados do Cliente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Decorador)
        Me.Panel1.Controls.Add(Me.txtcontato)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Telefone)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.ClienteNome)
        Me.Panel1.Controls.Add(Me.CPFCNPJ)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Cliente)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(12, 137)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(629, 105)
        Me.Panel1.TabIndex = 19
        '
        'Decorador
        '
        Me.Decorador.AceitaColarTexto = False
        Me.Decorador.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Decorador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Decorador.CasasDecimais = 0
        Me.Decorador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Decorador.CPObrigatorio = False
        Me.Decorador.CPObrigatorioMsg = Nothing
        Me.Decorador.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Decorador.FlatBorder = True
        Me.Decorador.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Decorador.FocusColor = System.Drawing.Color.Empty
        Me.Decorador.FocusColorEnd = System.Drawing.Color.Empty
        Me.Decorador.HighlightBorderOnEnter = False
        Me.Decorador.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Decorador.Location = New System.Drawing.Point(582, 42)
        Me.Decorador.MaxLength = 1
        Me.Decorador.Name = "Decorador"
        Me.Decorador.PreencherZeroEsqueda = False
        Me.Decorador.RegraValidação = Nothing
        Me.Decorador.RegraValidaçãoMensagem = Nothing
        Me.Decorador.ShortcutsEnabled = False
        Me.Decorador.Size = New System.Drawing.Size(37, 23)
        Me.Decorador.TabIndex = 9
        Me.Decorador.TabStop = False
        Me.Decorador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Decorador.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Decorador.ValorPadrao = Nothing
        '
        'txtcontato
        '
        Me.txtcontato.AceitaColarTexto = False
        Me.txtcontato.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtcontato.CasasDecimais = 0
        Me.txtcontato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontato.CPObrigatorio = False
        Me.txtcontato.CPObrigatorioMsg = Nothing
        Me.txtcontato.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtcontato.FlatBorder = False
        Me.txtcontato.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtcontato.FocusColor = System.Drawing.Color.Empty
        Me.txtcontato.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtcontato.HighlightBorderOnEnter = False
        Me.txtcontato.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtcontato.Location = New System.Drawing.Point(148, 71)
        Me.txtcontato.MaxLength = 50
        Me.txtcontato.Name = "txtcontato"
        Me.txtcontato.PreencherZeroEsqueda = False
        Me.txtcontato.RegraValidação = Nothing
        Me.txtcontato.RegraValidaçãoMensagem = Nothing
        Me.txtcontato.ShortcutsEnabled = False
        Me.txtcontato.Size = New System.Drawing.Size(471, 23)
        Me.txtcontato.TabIndex = 10
        Me.txtcontato.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtcontato.ValorPadrao = Nothing
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(472, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 22)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "É Decorador ?"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Telefone
        '
        Me.Telefone.AceitaColarTexto = False
        Me.Telefone.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Telefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Telefone.CasasDecimais = 0
        Me.Telefone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Telefone.CPObrigatorio = False
        Me.Telefone.CPObrigatorioMsg = Nothing
        Me.Telefone.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Telefone.FlatBorder = True
        Me.Telefone.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Telefone.FocusColor = System.Drawing.Color.Empty
        Me.Telefone.FocusColorEnd = System.Drawing.Color.Empty
        Me.Telefone.HighlightBorderOnEnter = False
        Me.Telefone.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Telefone.Location = New System.Drawing.Point(340, 43)
        Me.Telefone.MaxLength = 14
        Me.Telefone.Name = "Telefone"
        Me.Telefone.PreencherZeroEsqueda = False
        Me.Telefone.RegraValidação = Nothing
        Me.Telefone.RegraValidaçãoMensagem = Nothing
        Me.Telefone.ShortcutsEnabled = False
        Me.Telefone.Size = New System.Drawing.Size(119, 23)
        Me.Telefone.TabIndex = 7
        Me.Telefone.TabStop = False
        Me.Telefone.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Fone
        Me.Telefone.ValorPadrao = Nothing
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(267, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 22)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Telefone"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ClienteNome
        '
        Me.ClienteNome.AceitaColarTexto = False
        Me.ClienteNome.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ClienteNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ClienteNome.CasasDecimais = 0
        Me.ClienteNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ClienteNome.CPObrigatorio = False
        Me.ClienteNome.CPObrigatorioMsg = Nothing
        Me.ClienteNome.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ClienteNome.FlatBorder = True
        Me.ClienteNome.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ClienteNome.FocusColor = System.Drawing.Color.Empty
        Me.ClienteNome.FocusColorEnd = System.Drawing.Color.Empty
        Me.ClienteNome.HighlightBorderOnEnter = False
        Me.ClienteNome.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ClienteNome.Location = New System.Drawing.Point(223, 13)
        Me.ClienteNome.MaxLength = 15
        Me.ClienteNome.Name = "ClienteNome"
        Me.ClienteNome.PreencherZeroEsqueda = False
        Me.ClienteNome.RegraValidação = Nothing
        Me.ClienteNome.RegraValidaçãoMensagem = Nothing
        Me.ClienteNome.ShortcutsEnabled = False
        Me.ClienteNome.Size = New System.Drawing.Size(396, 23)
        Me.ClienteNome.TabIndex = 2
        Me.ClienteNome.TabStop = False
        Me.ClienteNome.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.ClienteNome.ValorPadrao = Nothing
        '
        'CPFCNPJ
        '
        Me.CPFCNPJ.AceitaColarTexto = False
        Me.CPFCNPJ.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.CPFCNPJ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CPFCNPJ.CasasDecimais = 0
        Me.CPFCNPJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CPFCNPJ.CPObrigatorio = False
        Me.CPFCNPJ.CPObrigatorioMsg = Nothing
        Me.CPFCNPJ.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.CPFCNPJ.FlatBorder = True
        Me.CPFCNPJ.FlatBorderColor = System.Drawing.Color.DimGray
        Me.CPFCNPJ.FocusColor = System.Drawing.Color.Empty
        Me.CPFCNPJ.FocusColorEnd = System.Drawing.Color.Empty
        Me.CPFCNPJ.HighlightBorderOnEnter = False
        Me.CPFCNPJ.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.CPFCNPJ.Location = New System.Drawing.Point(148, 42)
        Me.CPFCNPJ.MaxLength = 15
        Me.CPFCNPJ.Name = "CPFCNPJ"
        Me.CPFCNPJ.PreencherZeroEsqueda = False
        Me.CPFCNPJ.RegraValidação = Nothing
        Me.CPFCNPJ.RegraValidaçãoMensagem = Nothing
        Me.CPFCNPJ.ShortcutsEnabled = False
        Me.CPFCNPJ.Size = New System.Drawing.Size(113, 23)
        Me.CPFCNPJ.TabIndex = 5
        Me.CPFCNPJ.TabStop = False
        Me.CPFCNPJ.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.CPFCNPJ.ValorPadrao = Nothing
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(9, 72)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(133, 22)
        Me.Label24.TabIndex = 3
        Me.Label24.Text = "Contato"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(9, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 22)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "CPF/CNPJ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cliente
        '
        Me.Cliente.AceitaColarTexto = False
        Me.Cliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cliente.CasasDecimais = 0
        Me.Cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cliente.CPObrigatorio = False
        Me.Cliente.CPObrigatorioMsg = Nothing
        Me.Cliente.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Cliente.FlatBorder = True
        Me.Cliente.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Cliente.FocusColor = System.Drawing.Color.Empty
        Me.Cliente.FocusColorEnd = System.Drawing.Color.Empty
        Me.Cliente.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cliente.HighlightBorderOnEnter = False
        Me.Cliente.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Cliente.Location = New System.Drawing.Point(148, 12)
        Me.Cliente.MaxLength = 15
        Me.Cliente.Name = "Cliente"
        Me.Cliente.PreencherZeroEsqueda = False
        Me.Cliente.RegraValidação = Nothing
        Me.Cliente.RegraValidaçãoMensagem = Nothing
        Me.Cliente.ShortcutsEnabled = False
        Me.Cliente.Size = New System.Drawing.Size(69, 23)
        Me.Cliente.TabIndex = 1
        Me.Cliente.TabStop = False
        Me.Cliente.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.Cliente.ValorPadrao = Nothing
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(7, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 22)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cliente"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataLoc
        '
        Me.DataLoc.AceitaColarTexto = False
        Me.DataLoc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DataLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataLoc.CasasDecimais = 0
        Me.DataLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataLoc.CPObrigatorio = False
        Me.DataLoc.CPObrigatorioMsg = Nothing
        Me.DataLoc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataLoc.FlatBorder = True
        Me.DataLoc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataLoc.FocusColor = System.Drawing.Color.Empty
        Me.DataLoc.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataLoc.HighlightBorderOnEnter = False
        Me.DataLoc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataLoc.Location = New System.Drawing.Point(379, 22)
        Me.DataLoc.MaxLength = 10
        Me.DataLoc.Name = "DataLoc"
        Me.DataLoc.PreencherZeroEsqueda = False
        Me.DataLoc.ReadOnly = True
        Me.DataLoc.RegraValidação = Nothing
        Me.DataLoc.RegraValidaçãoMensagem = Nothing
        Me.DataLoc.ShortcutsEnabled = false
        Me.DataLoc.Size = New System.Drawing.Size(85, 23)
        Me.DataLoc.TabIndex = 5
        Me.DataLoc.TabStop = false
        Me.DataLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataLoc.ValorPadrao = Nothing
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(279, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Data da Locação"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = false
        Me.Lista.AllowUserToDeleteRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumPurple
        Me.Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cbtExcluir, Me.cIdItem, Me.cIdLocacao, Me.cProduto, Me.cDescrição, Me.cQtd, Me.cValorUnitarioLoc, Me.cValorDescontoLoc, Me.cTotalDiarias, Me.cTotalLoc, Me.cQtdDev, Me.cQtdAvarias, Me.cValorUnitarioAvarias, Me.cTotalAvarias})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lista.DefaultCellStyle = DataGridViewCellStyle12
        Me.Lista.EnableHeadersVisualStyles = false
        Me.Lista.GridColor = System.Drawing.Color.FromArgb(CType(CType(208,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(229,Byte),Integer))
        Me.Lista.Location = New System.Drawing.Point(12, 277)
        Me.Lista.MultiSelect = false
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = true
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Lista.RowHeadersVisible = false
        Me.Lista.RowHeadersWidth = 20
        Me.Lista.SelectAllSignVisible = false
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(960, 270)
        Me.Lista.TabIndex = 26
        Me.Lista.TabStop = false
        '
        'cbtExcluir
        '
        Me.cbtExcluir.HeaderText = ""
        Me.cbtExcluir.Image = CType(resources.GetObject("cbtExcluir.Image"),System.Drawing.Image)
        Me.cbtExcluir.Name = "cbtExcluir"
        Me.cbtExcluir.ReadOnly = true
        Me.cbtExcluir.Text = Nothing
        Me.cbtExcluir.ToolTipText = "Excluir"
        Me.cbtExcluir.Width = 25
        '
        'cIdItem
        '
        Me.cIdItem.DataPropertyName = "IdItem"
        Me.cIdItem.HeaderText = "IdItem"
        Me.cIdItem.Name = "cIdItem"
        Me.cIdItem.ReadOnly = true
        Me.cIdItem.Visible = false
        Me.cIdItem.Width = 180
        '
        'cIdLocacao
        '
        Me.cIdLocacao.DataPropertyName = "IdLocacao"
        Me.cIdLocacao.HeaderText = "IdLocação"
        Me.cIdLocacao.Name = "cIdLocacao"
        Me.cIdLocacao.ReadOnly = true
        Me.cIdLocacao.Visible = false
        '
        'cProduto
        '
        Me.cProduto.DataPropertyName = "Produto"
        Me.cProduto.HeaderText = "Produto"
        Me.cProduto.Name = "cProduto"
        Me.cProduto.ReadOnly = true
        Me.cProduto.Width = 60
        '
        'cDescrição
        '
        Me.cDescrição.DataPropertyName = "Descrição"
        Me.cDescrição.HeaderText = "Descrição Produto"
        Me.cDescrição.Name = "cDescrição"
        Me.cDescrição.ReadOnly = true
        Me.cDescrição.Width = 250
        '
        'cQtd
        '
        Me.cQtd.DataPropertyName = "Qtd"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.cQtd.DefaultCellStyle = DataGridViewCellStyle3
        Me.cQtd.HeaderText = "Qtd Loc"
        Me.cQtd.Name = "cQtd"
        Me.cQtd.ReadOnly = true
        Me.cQtd.Width = 75
        '
        'cValorUnitarioLoc
        '
        Me.cValorUnitarioLoc.DataPropertyName = "ValorUnitarioLoc"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.cValorUnitarioLoc.DefaultCellStyle = DataGridViewCellStyle4
        Me.cValorUnitarioLoc.HeaderText = "Unit. Loc"
        Me.cValorUnitarioLoc.Name = "cValorUnitarioLoc"
        Me.cValorUnitarioLoc.ReadOnly = true
        Me.cValorUnitarioLoc.Width = 80
        '
        'cValorDescontoLoc
        '
        Me.cValorDescontoLoc.DataPropertyName = "ValorDescontoLoc"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.cValorDescontoLoc.DefaultCellStyle = DataGridViewCellStyle5
        Me.cValorDescontoLoc.HeaderText = "Desc. Loc"
        Me.cValorDescontoLoc.Name = "cValorDescontoLoc"
        Me.cValorDescontoLoc.ReadOnly = true
        Me.cValorDescontoLoc.Width = 85
        '
        'cTotalDiarias
        '
        Me.cTotalDiarias.DataPropertyName = "TotalDiarias"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.cTotalDiarias.DefaultCellStyle = DataGridViewCellStyle6
        Me.cTotalDiarias.HeaderText = "Tot Diarias"
        Me.cTotalDiarias.Name = "cTotalDiarias"
        Me.cTotalDiarias.ReadOnly = true
        Me.cTotalDiarias.Width = 90
        '
        'cTotalLoc
        '
        Me.cTotalLoc.DataPropertyName = "TotalLoc"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.cTotalLoc.DefaultCellStyle = DataGridViewCellStyle7
        Me.cTotalLoc.HeaderText = "Total Loc"
        Me.cTotalLoc.Name = "cTotalLoc"
        Me.cTotalLoc.ReadOnly = true
        Me.cTotalLoc.Width = 90
        '
        'cQtdDev
        '
        Me.cQtdDev.DataPropertyName = "QtdDev"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.cQtdDev.DefaultCellStyle = DataGridViewCellStyle8
        Me.cQtdDev.HeaderText = "Qtd Dev"
        Me.cQtdDev.Name = "cQtdDev"
        Me.cQtdDev.ReadOnly = true
        Me.cQtdDev.Width = 75
        '
        'cQtdAvarias
        '
        Me.cQtdAvarias.DataPropertyName = "QtdAvarias"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.cQtdAvarias.DefaultCellStyle = DataGridViewCellStyle9
        Me.cQtdAvarias.HeaderText = "Qtd Av"
        Me.cQtdAvarias.Name = "cQtdAvarias"
        Me.cQtdAvarias.ReadOnly = true
        Me.cQtdAvarias.Width = 75
        '
        'cValorUnitarioAvarias
        '
        Me.cValorUnitarioAvarias.DataPropertyName = "ValorUnitarioAvarias"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.cValorUnitarioAvarias.DefaultCellStyle = DataGridViewCellStyle10
        Me.cValorUnitarioAvarias.HeaderText = "Unit. Av"
        Me.cValorUnitarioAvarias.Name = "cValorUnitarioAvarias"
        Me.cValorUnitarioAvarias.ReadOnly = true
        Me.cValorUnitarioAvarias.Width = 90
        '
        'cTotalAvarias
        '
        Me.cTotalAvarias.DataPropertyName = "TotalAvarias"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.cTotalAvarias.DefaultCellStyle = DataGridViewCellStyle11
        Me.cTotalAvarias.HeaderText = "Total Av"
        Me.cTotalAvarias.Name = "cTotalAvarias"
        Me.cTotalAvarias.ReadOnly = true
        Me.cTotalAvarias.Width = 90
        '
        'IdLoc
        '
        Me.IdLoc.AceitaColarTexto = false
        Me.IdLoc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.IdLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IdLoc.CasasDecimais = 0
        Me.IdLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.IdLoc.CPObrigatorio = false
        Me.IdLoc.CPObrigatorioMsg = Nothing
        Me.IdLoc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.IdLoc.FlatBorder = true
        Me.IdLoc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.IdLoc.FocusColor = System.Drawing.Color.Empty
        Me.IdLoc.FocusColorEnd = System.Drawing.Color.Empty
        Me.IdLoc.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.IdLoc.HighlightBorderOnEnter = false
        Me.IdLoc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.IdLoc.Location = New System.Drawing.Point(161, 23)
        Me.IdLoc.MaxLength = 15
        Me.IdLoc.Name = "IdLoc"
        Me.IdLoc.PreencherZeroEsqueda = false
        Me.IdLoc.RegraValidação = Nothing
        Me.IdLoc.RegraValidaçãoMensagem = Nothing
        Me.IdLoc.ShortcutsEnabled = false
        Me.IdLoc.Size = New System.Drawing.Size(112, 23)
        Me.IdLoc.TabIndex = 2
        Me.IdLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.IdLoc.ValorPadrao = Nothing
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID da Locação"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtOutrosAjustes)
        Me.Panel3.Controls.Add(Me.Label28)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.tDesconto)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.tItens)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.ValorFrete)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.tDiariaAmais)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.TotalLoc)
        Me.Panel3.Location = New System.Drawing.Point(15, 562)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(954, 61)
        Me.Panel3.TabIndex = 28
        '
        'txtOutrosAjustes
        '
        Me.txtOutrosAjustes.AceitaColarTexto = false
        Me.txtOutrosAjustes.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtOutrosAjustes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutrosAjustes.CasasDecimais = 2
        Me.txtOutrosAjustes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOutrosAjustes.CPObrigatorio = false
        Me.txtOutrosAjustes.CPObrigatorioMsg = Nothing
        Me.txtOutrosAjustes.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtOutrosAjustes.FlatBorder = true
        Me.txtOutrosAjustes.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtOutrosAjustes.FocusColor = System.Drawing.Color.Empty
        Me.txtOutrosAjustes.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtOutrosAjustes.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtOutrosAjustes.HighlightBorderOnEnter = false
        Me.txtOutrosAjustes.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtOutrosAjustes.Location = New System.Drawing.Point(593, 26)
        Me.txtOutrosAjustes.MaxLength = 10
        Me.txtOutrosAjustes.Name = "txtOutrosAjustes"
        Me.txtOutrosAjustes.PreencherZeroEsqueda = false
        Me.txtOutrosAjustes.RegraValidação = Nothing
        Me.txtOutrosAjustes.RegraValidaçãoMensagem = Nothing
        Me.txtOutrosAjustes.ShortcutsEnabled = false
        Me.txtOutrosAjustes.Size = New System.Drawing.Size(114, 26)
        Me.txtOutrosAjustes.TabIndex = 11
        Me.txtOutrosAjustes.TabStop = false
        Me.txtOutrosAjustes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOutrosAjustes.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.txtOutrosAjustes.ValorPadrao = Nothing
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(594, 2)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(133, 20)
        Me.Label28.TabIndex = 10
        Me.Label28.Text = "(-) Outros Ajustes"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(303, 2)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 25)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "(-) Desconto"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tDesconto
        '
        Me.tDesconto.AceitaColarTexto = false
        Me.tDesconto.BackColor = System.Drawing.Color.White
        Me.tDesconto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.tDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tDesconto.CasasDecimais = 2
        Me.tDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tDesconto.CPObrigatorio = false
        Me.tDesconto.CPObrigatorioMsg = Nothing
        Me.tDesconto.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.tDesconto.FlatBorder = true
        Me.tDesconto.FlatBorderColor = System.Drawing.Color.DimGray
        Me.tDesconto.FocusColor = System.Drawing.Color.Empty
        Me.tDesconto.FocusColorEnd = System.Drawing.Color.Empty
        Me.tDesconto.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tDesconto.HighlightBorderOnEnter = false
        Me.tDesconto.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.tDesconto.Location = New System.Drawing.Point(305, 27)
        Me.tDesconto.MaxLength = 10
        Me.tDesconto.Name = "tDesconto"
        Me.tDesconto.PreencherZeroEsqueda = false
        Me.tDesconto.ReadOnly = true
        Me.tDesconto.RegraValidação = Nothing
        Me.tDesconto.RegraValidaçãoMensagem = Nothing
        Me.tDesconto.ShortcutsEnabled = false
        Me.tDesconto.Size = New System.Drawing.Size(91, 26)
        Me.tDesconto.TabIndex = 8
        Me.tDesconto.TabStop = false
        Me.tDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tDesconto.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.tDesconto.ValorPadrao = Nothing
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(3, 1)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 25)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Locação"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tItens
        '
        Me.tItens.AceitaColarTexto = false
        Me.tItens.BackColor = System.Drawing.Color.White
        Me.tItens.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.tItens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tItens.CasasDecimais = 2
        Me.tItens.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tItens.CPObrigatorio = false
        Me.tItens.CPObrigatorioMsg = Nothing
        Me.tItens.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.tItens.FlatBorder = true
        Me.tItens.FlatBorderColor = System.Drawing.Color.DimGray
        Me.tItens.FocusColor = System.Drawing.Color.Empty
        Me.tItens.FocusColorEnd = System.Drawing.Color.Empty
        Me.tItens.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tItens.HighlightBorderOnEnter = false
        Me.tItens.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.tItens.Location = New System.Drawing.Point(5, 27)
        Me.tItens.MaxLength = 10
        Me.tItens.Name = "tItens"
        Me.tItens.PreencherZeroEsqueda = false
        Me.tItens.ReadOnly = true
        Me.tItens.RegraValidação = Nothing
        Me.tItens.RegraValidaçãoMensagem = Nothing
        Me.tItens.ShortcutsEnabled = false
        Me.tItens.Size = New System.Drawing.Size(96, 26)
        Me.tItens.TabIndex = 6
        Me.tItens.TabStop = false
        Me.tItens.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tItens.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.tItens.ValorPadrao = Nothing
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(446, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 22)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "(+) Taxas"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ValorFrete
        '
        Me.ValorFrete.AceitaColarTexto = false
        Me.ValorFrete.BackColor = System.Drawing.Color.White
        Me.ValorFrete.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ValorFrete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ValorFrete.CasasDecimais = 2
        Me.ValorFrete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ValorFrete.CPObrigatorio = false
        Me.ValorFrete.CPObrigatorioMsg = Nothing
        Me.ValorFrete.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ValorFrete.FlatBorder = true
        Me.ValorFrete.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ValorFrete.FocusColor = System.Drawing.Color.Empty
        Me.ValorFrete.FocusColorEnd = System.Drawing.Color.Empty
        Me.ValorFrete.Font = New System.Drawing.Font("Comic Sans MS", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ValorFrete.ForeColor = System.Drawing.Color.Red
        Me.ValorFrete.HighlightBorderOnEnter = false
        Me.ValorFrete.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ValorFrete.Location = New System.Drawing.Point(442, 27)
        Me.ValorFrete.MaxLength = 10
        Me.ValorFrete.Name = "ValorFrete"
        Me.ValorFrete.PreencherZeroEsqueda = false
        Me.ValorFrete.ReadOnly = true
        Me.ValorFrete.RegraValidação = Nothing
        Me.ValorFrete.RegraValidaçãoMensagem = Nothing
        Me.ValorFrete.ShortcutsEnabled = false
        Me.ValorFrete.Size = New System.Drawing.Size(93, 24)
        Me.ValorFrete.TabIndex = 2
        Me.ValorFrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ValorFrete.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.ValorFrete.ValorPadrao = Nothing
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(159, 1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 25)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "(+) Diárias"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tDiariaAmais
        '
        Me.tDiariaAmais.AceitaColarTexto = false
        Me.tDiariaAmais.BackColor = System.Drawing.Color.White
        Me.tDiariaAmais.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.tDiariaAmais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tDiariaAmais.CasasDecimais = 2
        Me.tDiariaAmais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tDiariaAmais.CPObrigatorio = false
        Me.tDiariaAmais.CPObrigatorioMsg = Nothing
        Me.tDiariaAmais.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.tDiariaAmais.FlatBorder = true
        Me.tDiariaAmais.FlatBorderColor = System.Drawing.Color.DimGray
        Me.tDiariaAmais.FocusColor = System.Drawing.Color.Empty
        Me.tDiariaAmais.FocusColorEnd = System.Drawing.Color.Empty
        Me.tDiariaAmais.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tDiariaAmais.HighlightBorderOnEnter = false
        Me.tDiariaAmais.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.tDiariaAmais.Location = New System.Drawing.Point(151, 28)
        Me.tDiariaAmais.MaxLength = 10
        Me.tDiariaAmais.Name = "tDiariaAmais"
        Me.tDiariaAmais.PreencherZeroEsqueda = false
        Me.tDiariaAmais.ReadOnly = true
        Me.tDiariaAmais.RegraValidação = Nothing
        Me.tDiariaAmais.RegraValidaçãoMensagem = Nothing
        Me.tDiariaAmais.ShortcutsEnabled = false
        Me.tDiariaAmais.Size = New System.Drawing.Size(96, 26)
        Me.tDiariaAmais.TabIndex = 4
        Me.tDiariaAmais.TabStop = false
        Me.tDiariaAmais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tDiariaAmais.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.tDiariaAmais.ValorPadrao = Nothing
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(804, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 25)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Total Geral"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TotalLoc
        '
        Me.TotalLoc.AceitaColarTexto = false
        Me.TotalLoc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.TotalLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalLoc.CasasDecimais = 2
        Me.TotalLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TotalLoc.CPObrigatorio = false
        Me.TotalLoc.CPObrigatorioMsg = Nothing
        Me.TotalLoc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.TotalLoc.FlatBorder = true
        Me.TotalLoc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.TotalLoc.FocusColor = System.Drawing.Color.Empty
        Me.TotalLoc.FocusColorEnd = System.Drawing.Color.Empty
        Me.TotalLoc.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TotalLoc.HighlightBorderOnEnter = false
        Me.TotalLoc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.TotalLoc.Location = New System.Drawing.Point(802, 26)
        Me.TotalLoc.MaxLength = 10
        Me.TotalLoc.Name = "TotalLoc"
        Me.TotalLoc.PreencherZeroEsqueda = false
        Me.TotalLoc.RegraValidação = Nothing
        Me.TotalLoc.RegraValidaçãoMensagem = Nothing
        Me.TotalLoc.ShortcutsEnabled = false
        Me.TotalLoc.Size = New System.Drawing.Size(114, 26)
        Me.TotalLoc.TabIndex = 0
        Me.TotalLoc.TabStop = false
        Me.TotalLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TotalLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.TotalLoc.ValorPadrao = Nothing
        '
        'Locacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 673)
        Me.ControlBox = false
        Me.Controls.Add(Me.Fundo)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = true
        Me.Name = "Locacao"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Locação de Acervo"
        Me.Fundo.ResumeLayout(false)
        Me.Fundo.PerformLayout
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.Lista,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Lista As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents IdLoc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ObsLoc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents DataLoc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cliente As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Telefone As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ClienteNome As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents CPFCNPJ As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btNovo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btObterEndereço As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CodBarra As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Qtd As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TotalLoc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents btProcuraLocacao As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Decorador As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btConfirmarLocacao As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DataRetorno As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents HoraRetorno As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents HoraLoc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents DiariaAmais As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ValorFrete As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Frete As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tItens As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tDiariaAmais As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents StatusLoc As System.Windows.Forms.Label
    Friend WithEvents cbtExcluir As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents cIdItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cProduto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDescrição As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cQtd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cValorUnitarioLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cValorDescontoLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalDiarias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cQtdDev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cQtdAvarias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cValorUnitarioAvarias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalAvarias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tDesconto As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents cboTransportadora As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtLocalEntrega As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtcontato As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboEntrega As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents cboDevolve As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboVendedor As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtOutrosAjustes As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnEntregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkProdutosEntregue As System.Windows.Forms.CheckBox
    Friend WithEvents btnImprimir As DevComponents.DotNetBar.ButtonX
End Class
