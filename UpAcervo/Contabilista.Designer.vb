<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilista))
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.cMun = New CBOAutoCompleteFocus.CboFocus()
        Me.CEP = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cpf = New TexBoxFocusNet.TextBoxFocusNet()
        Me.BarraBt = New System.Windows.Forms.ToolStrip()
        Me.SalvarBT = New System.Windows.Forms.ToolStripButton()
        Me.FecharBT = New System.Windows.Forms.ToolStripButton()
        Me.reg = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.crc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.cnpj = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nome = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bairro = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.compl = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ende = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.num = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Estado = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.fax = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Telefone = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.email = New TexBoxFocusNet.TextBoxFocusNet()
        Me.cod_mun = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Fundo.SuspendLayout()
        Me.BarraBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fundo
        '
        Me.Fundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Fundo.Controls.Add(Me.cMun)
        Me.Fundo.Controls.Add(Me.CEP)
        Me.Fundo.Controls.Add(Me.Label5)
        Me.Fundo.Controls.Add(Me.Label2)
        Me.Fundo.Controls.Add(Me.cpf)
        Me.Fundo.Controls.Add(Me.BarraBt)
        Me.Fundo.Controls.Add(Me.reg)
        Me.Fundo.Controls.Add(Me.Label1)
        Me.Fundo.Controls.Add(Me.Label3)
        Me.Fundo.Controls.Add(Me.crc)
        Me.Fundo.Controls.Add(Me.cnpj)
        Me.Fundo.Controls.Add(Me.Label11)
        Me.Fundo.Controls.Add(Me.Label4)
        Me.Fundo.Controls.Add(Me.nome)
        Me.Fundo.Controls.Add(Me.Label6)
        Me.Fundo.Controls.Add(Me.bairro)
        Me.Fundo.Controls.Add(Me.Label15)
        Me.Fundo.Controls.Add(Me.compl)
        Me.Fundo.Controls.Add(Me.Label7)
        Me.Fundo.Controls.Add(Me.ende)
        Me.Fundo.Controls.Add(Me.Label9)
        Me.Fundo.Controls.Add(Me.cod_mun)
        Me.Fundo.Controls.Add(Me.num)
        Me.Fundo.Controls.Add(Me.Estado)
        Me.Fundo.Controls.Add(Me.Label10)
        Me.Fundo.Controls.Add(Me.Label8)
        Me.Fundo.Controls.Add(Me.Label12)
        Me.Fundo.Controls.Add(Me.fax)
        Me.Fundo.Controls.Add(Me.Telefone)
        Me.Fundo.Controls.Add(Me.Label14)
        Me.Fundo.Controls.Add(Me.Label13)
        Me.Fundo.Controls.Add(Me.email)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(606, 394)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'cMun
        '
        Me.cMun.Auto_Complete = True
        Me.cMun.AutoLimitar_Lista = True
        Me.cMun.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.cMun.CPObrigatorio = False
        Me.cMun.CPObrigatorioMsg = Nothing
        Me.cMun.DropDownHeight = 50
        Me.cMun.FlatBorder = False
        Me.cMun.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cMun.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cMun.FormattingEnabled = True
        Me.cMun.HighlightBorderColor = System.Drawing.Color.Empty
        Me.cMun.HighlightBorderOnEnter = False
        Me.cMun.IntegralHeight = False
        Me.cMun.ItemHeight = 15
        Me.cMun.Location = New System.Drawing.Point(89, 253)
        Me.cMun.MaxDropDownItems = 6
        Me.cMun.Name = "cMun"
        Me.cMun.Size = New System.Drawing.Size(351, 23)
        Me.cMun.TabIndex = 18
        '
        'CEP
        '
        Me.CEP.AceitaColarTexto = True
        Me.CEP.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.CEP.CasasDecimais = 0
        Me.CEP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CEP.CPObrigatorio = False
        Me.CEP.CPObrigatorioMsg = Nothing
        Me.CEP.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.CEP.FlatBorder = False
        Me.CEP.FlatBorderColor = System.Drawing.Color.DimGray
        Me.CEP.FocusColor = System.Drawing.Color.Empty
        Me.CEP.FocusColorEnd = System.Drawing.Color.Empty
        Me.CEP.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEP.HighlightBorderOnEnter = False
        Me.CEP.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.CEP.Location = New System.Drawing.Point(88, 286)
        Me.CEP.MaxLength = 9
        Me.CEP.Name = "CEP"
        Me.CEP.PreencherZeroEsqueda = False
        Me.CEP.RegraValidação = Nothing
        Me.CEP.RegraValidaçãoMensagem = Nothing
        Me.CEP.Size = New System.Drawing.Size(173, 23)
        Me.CEP.TabIndex = 21
        Me.CEP.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cep
        Me.CEP.ValorPadrao = Nothing
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(267, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 19)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "E-mail"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 19)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "CEP"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cpf
        '
        Me.cpf.AceitaColarTexto = True
        Me.cpf.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.cpf.CasasDecimais = 0
        Me.cpf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cpf.CPObrigatorio = False
        Me.cpf.CPObrigatorioMsg = Nothing
        Me.cpf.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.cpf.FlatBorder = False
        Me.cpf.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cpf.FocusColor = System.Drawing.Color.Empty
        Me.cpf.FocusColorEnd = System.Drawing.Color.Empty
        Me.cpf.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpf.HighlightBorderOnEnter = False
        Me.cpf.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.cpf.Location = New System.Drawing.Point(89, 103)
        Me.cpf.MaxLength = 14
        Me.cpf.Name = "cpf"
        Me.cpf.PreencherZeroEsqueda = False
        Me.cpf.RegraValidação = Nothing
        Me.cpf.RegraValidaçãoMensagem = Nothing
        Me.cpf.Size = New System.Drawing.Size(172, 23)
        Me.cpf.TabIndex = 4
        Me.cpf.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cpf
        Me.cpf.ValorPadrao = Nothing
        '
        'BarraBt
        '
        Me.BarraBt.BackColor = System.Drawing.Color.Transparent
        Me.BarraBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BarraBt.Font = New System.Drawing.Font("Comic Sans MS", 8.25!)
        Me.BarraBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalvarBT, Me.FecharBT})
        Me.BarraBt.Location = New System.Drawing.Point(0, 0)
        Me.BarraBt.Name = "BarraBt"
        Me.BarraBt.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.BarraBt.Size = New System.Drawing.Size(606, 58)
        Me.BarraBt.TabIndex = 0
        Me.BarraBt.Text = "ToolStrip1"
        '
        'SalvarBT
        '
        Me.SalvarBT.Image = CType(resources.GetObject("SalvarBT.Image"), System.Drawing.Image)
        Me.SalvarBT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalvarBT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SalvarBT.Name = "SalvarBT"
        Me.SalvarBT.Size = New System.Drawing.Size(45, 55)
        Me.SalvarBT.Text = "Salvar"
        Me.SalvarBT.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.SalvarBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.SalvarBT.ToolTipText = "Salvar"
        '
        'FecharBT
        '
        Me.FecharBT.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.FecharBT.Image = CType(resources.GetObject("FecharBT.Image"), System.Drawing.Image)
        Me.FecharBT.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.FecharBT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FecharBT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FecharBT.Name = "FecharBT"
        Me.FecharBT.Size = New System.Drawing.Size(46, 55)
        Me.FecharBT.Text = "Fechar"
        Me.FecharBT.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.FecharBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'reg
        '
        Me.reg.AceitaColarTexto = True
        Me.reg.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.reg.CasasDecimais = 0
        Me.reg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.reg.CPObrigatorio = False
        Me.reg.CPObrigatorioMsg = Nothing
        Me.reg.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.reg.FlatBorder = False
        Me.reg.FlatBorderColor = System.Drawing.Color.DimGray
        Me.reg.FocusColor = System.Drawing.Color.Empty
        Me.reg.FocusColorEnd = System.Drawing.Color.Empty
        Me.reg.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reg.HighlightBorderOnEnter = False
        Me.reg.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.reg.Location = New System.Drawing.Point(89, 74)
        Me.reg.Name = "reg"
        Me.reg.PreencherZeroEsqueda = False
        Me.reg.ReadOnly = True
        Me.reg.RegraValidação = Nothing
        Me.reg.RegraValidaçãoMensagem = Nothing
        Me.reg.Size = New System.Drawing.Size(91, 23)
        Me.reg.TabIndex = 2
        Me.reg.Text = "0100"
        Me.reg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.reg.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.reg.ValorPadrao = ""
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Reg"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cpf"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'crc
        '
        Me.crc.AceitaColarTexto = True
        Me.crc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.crc.CasasDecimais = 0
        Me.crc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.crc.CPObrigatorio = False
        Me.crc.CPObrigatorioMsg = Nothing
        Me.crc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.crc.FlatBorder = False
        Me.crc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.crc.FocusColor = System.Drawing.Color.Empty
        Me.crc.FocusColorEnd = System.Drawing.Color.Empty
        Me.crc.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crc.HighlightBorderOnEnter = False
        Me.crc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.crc.Location = New System.Drawing.Point(477, 104)
        Me.crc.MaxLength = 15
        Me.crc.Name = "crc"
        Me.crc.PreencherZeroEsqueda = False
        Me.crc.RegraValidação = Nothing
        Me.crc.RegraValidaçãoMensagem = Nothing
        Me.crc.Size = New System.Drawing.Size(109, 23)
        Me.crc.TabIndex = 8
        Me.crc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.crc.ValorPadrao = Nothing
        '
        'cnpj
        '
        Me.cnpj.AceitaColarTexto = True
        Me.cnpj.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.cnpj.CasasDecimais = 0
        Me.cnpj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cnpj.CPObrigatorio = False
        Me.cnpj.CPObrigatorioMsg = Nothing
        Me.cnpj.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.cnpj.FlatBorder = False
        Me.cnpj.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cnpj.FocusColor = System.Drawing.Color.Empty
        Me.cnpj.FocusColorEnd = System.Drawing.Color.Empty
        Me.cnpj.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cnpj.HighlightBorderOnEnter = False
        Me.cnpj.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.cnpj.Location = New System.Drawing.Point(319, 104)
        Me.cnpj.MaxLength = 18
        Me.cnpj.Name = "cnpj"
        Me.cnpj.PreencherZeroEsqueda = False
        Me.cnpj.RegraValidação = Nothing
        Me.cnpj.RegraValidaçãoMensagem = Nothing
        Me.cnpj.Size = New System.Drawing.Size(121, 23)
        Me.cnpj.TabIndex = 7
        Me.cnpj.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cnpj
        Me.cnpj.ValorPadrao = Nothing
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(446, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 19)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Crc"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(268, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 19)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Cnpj"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nome
        '
        Me.nome.AceitaColarTexto = True
        Me.nome.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.nome.CasasDecimais = 0
        Me.nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nome.CPObrigatorio = False
        Me.nome.CPObrigatorioMsg = Nothing
        Me.nome.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.nome.FlatBorder = False
        Me.nome.FlatBorderColor = System.Drawing.Color.DimGray
        Me.nome.FocusColor = System.Drawing.Color.Empty
        Me.nome.FocusColorEnd = System.Drawing.Color.Empty
        Me.nome.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nome.HighlightBorderOnEnter = False
        Me.nome.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.nome.Location = New System.Drawing.Point(89, 132)
        Me.nome.MaxLength = 100
        Me.nome.Name = "nome"
        Me.nome.PreencherZeroEsqueda = False
        Me.nome.RegraValidação = Nothing
        Me.nome.RegraValidaçãoMensagem = Nothing
        Me.nome.Size = New System.Drawing.Size(497, 23)
        Me.nome.TabIndex = 10
        Me.nome.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.nome.ValorPadrao = Nothing
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 19)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Nome"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bairro
        '
        Me.bairro.AceitaColarTexto = True
        Me.bairro.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.bairro.CasasDecimais = 0
        Me.bairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.bairro.CPObrigatorio = False
        Me.bairro.CPObrigatorioMsg = Nothing
        Me.bairro.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.bairro.FlatBorder = False
        Me.bairro.FlatBorderColor = System.Drawing.Color.DimGray
        Me.bairro.FocusColor = System.Drawing.Color.Empty
        Me.bairro.FocusColorEnd = System.Drawing.Color.Empty
        Me.bairro.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bairro.HighlightBorderOnEnter = False
        Me.bairro.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.bairro.Location = New System.Drawing.Point(89, 191)
        Me.bairro.MaxLength = 50
        Me.bairro.Name = "bairro"
        Me.bairro.PreencherZeroEsqueda = False
        Me.bairro.RegraValidação = Nothing
        Me.bairro.RegraValidaçãoMensagem = Nothing
        Me.bairro.Size = New System.Drawing.Size(497, 23)
        Me.bairro.TabIndex = 16
        Me.bairro.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.bairro.ValorPadrao = Nothing
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 191)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 19)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Bairro"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'compl
        '
        Me.compl.AceitaColarTexto = True
        Me.compl.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.compl.CasasDecimais = 0
        Me.compl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.compl.CPObrigatorio = False
        Me.compl.CPObrigatorioMsg = Nothing
        Me.compl.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.compl.FlatBorder = False
        Me.compl.FlatBorderColor = System.Drawing.Color.DimGray
        Me.compl.FocusColor = System.Drawing.Color.Empty
        Me.compl.FocusColorEnd = System.Drawing.Color.Empty
        Me.compl.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.compl.HighlightBorderOnEnter = False
        Me.compl.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.compl.Location = New System.Drawing.Point(89, 222)
        Me.compl.MaxLength = 60
        Me.compl.Name = "compl"
        Me.compl.PreencherZeroEsqueda = False
        Me.compl.RegraValidação = Nothing
        Me.compl.RegraValidaçãoMensagem = Nothing
        Me.compl.Size = New System.Drawing.Size(497, 23)
        Me.compl.TabIndex = 17
        Me.compl.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.compl.ValorPadrao = Nothing
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 19)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Complemento"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ende
        '
        Me.ende.AceitaColarTexto = True
        Me.ende.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.ende.CasasDecimais = 0
        Me.ende.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ende.CPObrigatorio = False
        Me.ende.CPObrigatorioMsg = Nothing
        Me.ende.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ende.FlatBorder = False
        Me.ende.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ende.FocusColor = System.Drawing.Color.Empty
        Me.ende.FocusColorEnd = System.Drawing.Color.Empty
        Me.ende.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ende.HighlightBorderOnEnter = False
        Me.ende.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ende.Location = New System.Drawing.Point(89, 162)
        Me.ende.MaxLength = 50
        Me.ende.Name = "ende"
        Me.ende.PreencherZeroEsqueda = False
        Me.ende.RegraValidação = Nothing
        Me.ende.RegraValidaçãoMensagem = Nothing
        Me.ende.Size = New System.Drawing.Size(394, 23)
        Me.ende.TabIndex = 14
        Me.ende.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ende.ValorPadrao = Nothing
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 162)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 19)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Endereço"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'num
        '
        Me.num.AceitaColarTexto = True
        Me.num.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.num.CasasDecimais = 0
        Me.num.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.num.CPObrigatorio = False
        Me.num.CPObrigatorioMsg = Nothing
        Me.num.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.num.FlatBorder = False
        Me.num.FlatBorderColor = System.Drawing.Color.DimGray
        Me.num.FocusColor = System.Drawing.Color.Empty
        Me.num.FocusColorEnd = System.Drawing.Color.Empty
        Me.num.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.num.HighlightBorderOnEnter = False
        Me.num.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.num.Location = New System.Drawing.Point(510, 161)
        Me.num.MaxLength = 10
        Me.num.Name = "num"
        Me.num.PreencherZeroEsqueda = False
        Me.num.RegraValidação = Nothing
        Me.num.RegraValidaçãoMensagem = Nothing
        Me.num.Size = New System.Drawing.Size(76, 23)
        Me.num.TabIndex = 15
        Me.num.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.num.ValorPadrao = Nothing
        '
        'Estado
        '
        Me.Estado.AceitaColarTexto = True
        Me.Estado.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Estado.CasasDecimais = 0
        Me.Estado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Estado.CPObrigatorio = False
        Me.Estado.CPObrigatorioMsg = Nothing
        Me.Estado.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Estado.FlatBorder = False
        Me.Estado.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Estado.FocusColor = System.Drawing.Color.Empty
        Me.Estado.FocusColorEnd = System.Drawing.Color.Empty
        Me.Estado.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Estado.HighlightBorderOnEnter = False
        Me.Estado.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Estado.Location = New System.Drawing.Point(510, 253)
        Me.Estado.MaxLength = 2
        Me.Estado.Name = "Estado"
        Me.Estado.PreencherZeroEsqueda = False
        Me.Estado.ReadOnly = True
        Me.Estado.RegraValidação = Nothing
        Me.Estado.RegraValidaçãoMensagem = Nothing
        Me.Estado.Size = New System.Drawing.Size(76, 23)
        Me.Estado.TabIndex = 19
        Me.Estado.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Estado.ValorPadrao = Nothing
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(486, 163)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 19)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Nº"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 253)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 19)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Municipio"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(468, 257)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 19)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "UF"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fax
        '
        Me.fax.AceitaColarTexto = True
        Me.fax.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.fax.CasasDecimais = 0
        Me.fax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.fax.CPObrigatorio = False
        Me.fax.CPObrigatorioMsg = Nothing
        Me.fax.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.fax.FlatBorder = False
        Me.fax.FlatBorderColor = System.Drawing.Color.DimGray
        Me.fax.FocusColor = System.Drawing.Color.Empty
        Me.fax.FocusColorEnd = System.Drawing.Color.Empty
        Me.fax.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fax.HighlightBorderOnEnter = False
        Me.fax.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.fax.Location = New System.Drawing.Point(319, 315)
        Me.fax.MaxLength = 14
        Me.fax.Name = "fax"
        Me.fax.PreencherZeroEsqueda = False
        Me.fax.RegraValidação = Nothing
        Me.fax.RegraValidaçãoMensagem = Nothing
        Me.fax.Size = New System.Drawing.Size(131, 23)
        Me.fax.TabIndex = 24
        Me.fax.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Fone
        Me.fax.ValorPadrao = Nothing
        '
        'Telefone
        '
        Me.Telefone.AceitaColarTexto = True
        Me.Telefone.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Telefone.CasasDecimais = 0
        Me.Telefone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Telefone.CPObrigatorio = False
        Me.Telefone.CPObrigatorioMsg = Nothing
        Me.Telefone.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Telefone.FlatBorder = False
        Me.Telefone.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Telefone.FocusColor = System.Drawing.Color.Empty
        Me.Telefone.FocusColorEnd = System.Drawing.Color.Empty
        Me.Telefone.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Telefone.HighlightBorderOnEnter = False
        Me.Telefone.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Telefone.Location = New System.Drawing.Point(88, 315)
        Me.Telefone.MaxLength = 14
        Me.Telefone.Name = "Telefone"
        Me.Telefone.PreencherZeroEsqueda = False
        Me.Telefone.RegraValidação = Nothing
        Me.Telefone.RegraValidaçãoMensagem = Nothing
        Me.Telefone.Size = New System.Drawing.Size(172, 23)
        Me.Telefone.TabIndex = 23
        Me.Telefone.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Fone
        Me.Telefone.ValorPadrao = Nothing
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(267, 316)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 19)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Fax"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 315)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 19)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Telefone"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'email
        '
        Me.email.AceitaColarTexto = True
        Me.email.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.email.CasasDecimais = 0
        Me.email.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.email.CPObrigatorio = False
        Me.email.CPObrigatorioMsg = Nothing
        Me.email.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.email.FlatBorder = False
        Me.email.FlatBorderColor = System.Drawing.Color.DimGray
        Me.email.FocusColor = System.Drawing.Color.Empty
        Me.email.FocusColorEnd = System.Drawing.Color.Empty
        Me.email.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email.HighlightBorderOnEnter = False
        Me.email.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.email.Location = New System.Drawing.Point(319, 286)
        Me.email.MaxLength = 50
        Me.email.Name = "email"
        Me.email.PreencherZeroEsqueda = False
        Me.email.RegraValidação = Nothing
        Me.email.RegraValidaçãoMensagem = Nothing
        Me.email.Size = New System.Drawing.Size(267, 23)
        Me.email.TabIndex = 22
        Me.email.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.email.ValorPadrao = Nothing
        '
        'cod_mun
        '
        Me.cod_mun.AceitaColarTexto = True
        Me.cod_mun.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.cod_mun.CasasDecimais = 0
        Me.cod_mun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cod_mun.CPObrigatorio = False
        Me.cod_mun.CPObrigatorioMsg = Nothing
        Me.cod_mun.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.cod_mun.FlatBorder = False
        Me.cod_mun.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cod_mun.FocusColor = System.Drawing.Color.Empty
        Me.cod_mun.FocusColorEnd = System.Drawing.Color.Empty
        Me.cod_mun.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cod_mun.HighlightBorderOnEnter = False
        Me.cod_mun.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.cod_mun.Location = New System.Drawing.Point(88, 344)
        Me.cod_mun.MaxLength = 10
        Me.cod_mun.Name = "cod_mun"
        Me.cod_mun.PreencherZeroEsqueda = False
        Me.cod_mun.RegraValidação = Nothing
        Me.cod_mun.RegraValidaçãoMensagem = Nothing
        Me.cod_mun.Size = New System.Drawing.Size(92, 23)
        Me.cod_mun.TabIndex = 20
        Me.cod_mun.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.cod_mun.ValorPadrao = Nothing
        Me.cod_mun.Visible = False
        '
        'Contabilista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 394)
        Me.ControlBox = False
        Me.Controls.Add(Me.Fundo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Contabilista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilista"
        Me.Fundo.ResumeLayout(False)
        Me.Fundo.PerformLayout()
        Me.BarraBt.ResumeLayout(False)
        Me.BarraBt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents CEP As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cpf As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents BarraBt As System.Windows.Forms.ToolStrip
    Friend WithEvents SalvarBT As System.Windows.Forms.ToolStripButton
    Friend WithEvents FecharBT As System.Windows.Forms.ToolStripButton
    Friend WithEvents reg As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cnpj As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nome As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ende As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents num As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Telefone As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents email As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents crc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents compl As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents fax As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents bairro As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cMun As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents Estado As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cod_mun As TexBoxFocusNet.TextBoxFocusNet
End Class
