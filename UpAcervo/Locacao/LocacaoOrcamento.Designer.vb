<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocacaoOrcamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocacaoOrcamento))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.chkTransformadoEmLocacao = New System.Windows.Forms.CheckBox()
        Me.btnCheckDisponibilidade = New DevComponents.DotNetBar.ButtonX()
        Me.btnChangeToLocacao = New DevComponents.DotNetBar.ButtonX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboVendedor = New CBOAutoCompleteFocus.CboFocus()
        Me.Frete = New CBOAutoCompleteFocus.CboFocus()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.HoraRetorno = New TexBoxFocusNet.TextBoxFocusNet()
        Me.HoraLoc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DataRetorno = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btConfirmarLocacao = New DevComponents.DotNetBar.ButtonX()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CodBarra = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Qtd = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ObsLoc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Decorador = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtcontato = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Telefone = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ClienteNome = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cliente = New TexBoxFocusNet.TextBoxFocusNet()
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
        Me.cTotalAvarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDisponibilidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdLoc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
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
        Me.Fundo.Controls.Add(Me.chkTransformadoEmLocacao)
        Me.Fundo.Controls.Add(Me.btnCheckDisponibilidade)
        Me.Fundo.Controls.Add(Me.btnChangeToLocacao)
        Me.Fundo.Controls.Add(Me.Label4)
        Me.Fundo.Controls.Add(Me.cboVendedor)
        Me.Fundo.Controls.Add(Me.Frete)
        Me.Fundo.Controls.Add(Me.Label16)
        Me.Fundo.Controls.Add(Me.HoraRetorno)
        Me.Fundo.Controls.Add(Me.HoraLoc)
        Me.Fundo.Controls.Add(Me.Label27)
        Me.Fundo.Controls.Add(Me.DataRetorno)
        Me.Fundo.Controls.Add(Me.Label14)
        Me.Fundo.Controls.Add(Me.btConfirmarLocacao)
        Me.Fundo.Controls.Add(Me.Label12)
        Me.Fundo.Controls.Add(Me.Label11)
        Me.Fundo.Controls.Add(Me.CodBarra)
        Me.Fundo.Controls.Add(Me.Qtd)
        Me.Fundo.Controls.Add(Me.Label10)
        Me.Fundo.Controls.Add(Me.Fechar)
        Me.Fundo.Controls.Add(Me.Label8)
        Me.Fundo.Controls.Add(Me.Panel2)
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
        Me.Fundo.Size = New System.Drawing.Size(984, 666)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'chkTransformadoEmLocacao
        '
        Me.chkTransformadoEmLocacao.AutoSize = true
        Me.chkTransformadoEmLocacao.Enabled = false
        Me.chkTransformadoEmLocacao.Font = New System.Drawing.Font("Comic Sans MS", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkTransformadoEmLocacao.Location = New System.Drawing.Point(778, 18)
        Me.chkTransformadoEmLocacao.Name = "chkTransformadoEmLocacao"
        Me.chkTransformadoEmLocacao.Size = New System.Drawing.Size(193, 23)
        Me.chkTransformadoEmLocacao.TabIndex = 27
        Me.chkTransformadoEmLocacao.Text = "Transformado em locação"
        Me.chkTransformadoEmLocacao.UseVisualStyleBackColor = true
        '
        'btnCheckDisponibilidade
        '
        Me.btnCheckDisponibilidade.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCheckDisponibilidade.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCheckDisponibilidade.Enabled = false
        Me.btnCheckDisponibilidade.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnCheckDisponibilidade.Image = CType(resources.GetObject("btnCheckDisponibilidade.Image"),System.Drawing.Image)
        Me.btnCheckDisponibilidade.Location = New System.Drawing.Point(15, 611)
        Me.btnCheckDisponibilidade.Name = "btnCheckDisponibilidade"
        Me.btnCheckDisponibilidade.Size = New System.Drawing.Size(140, 41)
        Me.btnCheckDisponibilidade.TabIndex = 26
        Me.btnCheckDisponibilidade.TabStop = false
        Me.btnCheckDisponibilidade.Text = "Checar Disponibilidade"
        '
        'btnChangeToLocacao
        '
        Me.btnChangeToLocacao.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnChangeToLocacao.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnChangeToLocacao.Enabled = false
        Me.btnChangeToLocacao.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnChangeToLocacao.Image = CType(resources.GetObject("btnChangeToLocacao.Image"),System.Drawing.Image)
        Me.btnChangeToLocacao.Location = New System.Drawing.Point(161, 611)
        Me.btnChangeToLocacao.Name = "btnChangeToLocacao"
        Me.btnChangeToLocacao.Size = New System.Drawing.Size(140, 41)
        Me.btnChangeToLocacao.TabIndex = 26
        Me.btnChangeToLocacao.TabStop = false
        Me.btnChangeToLocacao.Text = "Tranformar em Locação"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(32, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 22)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Dados do Cliente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cboVendedor.Location = New System.Drawing.Point(161, 78)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(367, 23)
        Me.cboVendedor.TabIndex = 3
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
        Me.Frete.Location = New System.Drawing.Point(161, 51)
        Me.Frete.Name = "Frete"
        Me.Frete.Size = New System.Drawing.Size(367, 23)
        Me.Frete.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(12, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(141, 22)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Frete para"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HoraRetorno
        '
        Me.HoraRetorno.AceitaColarTexto = false
        Me.HoraRetorno.BackColor = System.Drawing.Color.White
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
        Me.HoraRetorno.Location = New System.Drawing.Point(911, 77)
        Me.HoraRetorno.MaxLength = 8
        Me.HoraRetorno.Name = "HoraRetorno"
        Me.HoraRetorno.PreencherZeroEsqueda = false
        Me.HoraRetorno.ReadOnly = true
        Me.HoraRetorno.RegraValidação = Nothing
        Me.HoraRetorno.RegraValidaçãoMensagem = Nothing
        Me.HoraRetorno.ShortcutsEnabled = false
        Me.HoraRetorno.Size = New System.Drawing.Size(58, 23)
        Me.HoraRetorno.TabIndex = 9
        Me.HoraRetorno.TabStop = false
        Me.HoraRetorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HoraRetorno.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Hora
        Me.HoraRetorno.ValorPadrao = Nothing
        '
        'HoraLoc
        '
        Me.HoraLoc.AceitaColarTexto = false
        Me.HoraLoc.BackColor = System.Drawing.Color.White
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
        Me.HoraLoc.Location = New System.Drawing.Point(911, 47)
        Me.HoraLoc.MaxLength = 8
        Me.HoraLoc.Name = "HoraLoc"
        Me.HoraLoc.PreencherZeroEsqueda = false
        Me.HoraLoc.ReadOnly = true
        Me.HoraLoc.RegraValidação = Nothing
        Me.HoraLoc.RegraValidaçãoMensagem = Nothing
        Me.HoraLoc.ShortcutsEnabled = false
        Me.HoraLoc.Size = New System.Drawing.Size(58, 23)
        Me.HoraLoc.TabIndex = 7
        Me.HoraLoc.TabStop = false
        Me.HoraLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HoraLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Hora
        Me.HoraLoc.ValorPadrao = Nothing
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(17, 79)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 22)
        Me.Label27.TabIndex = 23
        Me.Label27.Text = "Vendedor"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataRetorno
        '
        Me.DataRetorno.AceitaColarTexto = false
        Me.DataRetorno.BackColor = System.Drawing.Color.White
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
        Me.DataRetorno.Location = New System.Drawing.Point(778, 78)
        Me.DataRetorno.MaxLength = 10
        Me.DataRetorno.Name = "DataRetorno"
        Me.DataRetorno.PreencherZeroEsqueda = false
        Me.DataRetorno.RegraValidação = Nothing
        Me.DataRetorno.RegraValidaçãoMensagem = Nothing
        Me.DataRetorno.ShortcutsEnabled = false
        Me.DataRetorno.Size = New System.Drawing.Size(127, 23)
        Me.DataRetorno.TabIndex = 8
        Me.DataRetorno.TabStop = false
        Me.DataRetorno.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataRetorno.ValorPadrao = Nothing
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(676, 77)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 22)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Data Retorno"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btConfirmarLocacao
        '
        Me.btConfirmarLocacao.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btConfirmarLocacao.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btConfirmarLocacao.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btConfirmarLocacao.Image = CType(resources.GetObject("btConfirmarLocacao.Image"),System.Drawing.Image)
        Me.btConfirmarLocacao.Location = New System.Drawing.Point(659, 611)
        Me.btConfirmarLocacao.Name = "btConfirmarLocacao"
        Me.btConfirmarLocacao.Size = New System.Drawing.Size(140, 41)
        Me.btConfirmarLocacao.TabIndex = 20
        Me.btConfirmarLocacao.TabStop = false
        Me.btConfirmarLocacao.Text = "Confirmar e Imprimir"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(27, 548)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 22)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Totais da Locação"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(499, 227)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(379, 22)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Pressione [F5] para Procurar o produto [F6] - Para editar a Quantidade"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CodBarra
        '
        Me.CodBarra.AceitaColarTexto = false
        Me.CodBarra.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.CodBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CodBarra.CasasDecimais = 0
        Me.CodBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CodBarra.CPObrigatorio = false
        Me.CodBarra.CPObrigatorioMsg = Nothing
        Me.CodBarra.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.CodBarra.FlatBorder = true
        Me.CodBarra.FlatBorderColor = System.Drawing.Color.DimGray
        Me.CodBarra.FocusColor = System.Drawing.Color.Empty
        Me.CodBarra.FocusColorEnd = System.Drawing.Color.Empty
        Me.CodBarra.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CodBarra.HighlightBorderOnEnter = false
        Me.CodBarra.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.CodBarra.Location = New System.Drawing.Point(161, 225)
        Me.CodBarra.MaxLength = 15
        Me.CodBarra.Name = "CodBarra"
        Me.CodBarra.PreencherZeroEsqueda = false
        Me.CodBarra.RegraValidação = Nothing
        Me.CodBarra.RegraValidaçãoMensagem = Nothing
        Me.CodBarra.ShortcutsEnabled = false
        Me.CodBarra.Size = New System.Drawing.Size(220, 23)
        Me.CodBarra.TabIndex = 14
        Me.CodBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CodBarra.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.CodBarra.ValorPadrao = Nothing
        '
        'Qtd
        '
        Me.Qtd.AceitaColarTexto = false
        Me.Qtd.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Qtd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Qtd.CasasDecimais = 0
        Me.Qtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Qtd.CPObrigatorio = false
        Me.Qtd.CPObrigatorioMsg = Nothing
        Me.Qtd.Enabled = false
        Me.Qtd.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Qtd.FlatBorder = true
        Me.Qtd.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Qtd.FocusColor = System.Drawing.Color.Empty
        Me.Qtd.FocusColorEnd = System.Drawing.Color.Empty
        Me.Qtd.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Qtd.HighlightBorderOnEnter = false
        Me.Qtd.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Qtd.Location = New System.Drawing.Point(387, 225)
        Me.Qtd.MaxLength = 15
        Me.Qtd.Name = "Qtd"
        Me.Qtd.PreencherZeroEsqueda = false
        Me.Qtd.RegraValidação = Nothing
        Me.Qtd.RegraValidaçãoMensagem = Nothing
        Me.Qtd.ShortcutsEnabled = false
        Me.Qtd.Size = New System.Drawing.Size(57, 23)
        Me.Qtd.TabIndex = 15
        Me.Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Qtd.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.Qtd.ValorPadrao = Nothing
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(19, 227)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 22)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Qtd / Código de Barra"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Fechar.Image = CType(resources.GetObject("Fechar.Image"),System.Drawing.Image)
        Me.Fechar.Location = New System.Drawing.Point(836, 611)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(136, 41)
        Me.Fechar.TabIndex = 21
        Me.Fechar.TabStop = false
        Me.Fechar.Text = "Fechar"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(656, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 22)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Observações"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ObsLoc)
        Me.Panel2.Location = New System.Drawing.Point(647, 118)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(325, 105)
        Me.Panel2.TabIndex = 12
        '
        'ObsLoc
        '
        Me.ObsLoc.AceitaColarTexto = true
        Me.ObsLoc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.ObsLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ObsLoc.CasasDecimais = 0
        Me.ObsLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ObsLoc.CPObrigatorio = false
        Me.ObsLoc.CPObrigatorioMsg = Nothing
        Me.ObsLoc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ObsLoc.FlatBorder = true
        Me.ObsLoc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ObsLoc.FocusColor = System.Drawing.Color.Empty
        Me.ObsLoc.FocusColorEnd = System.Drawing.Color.Empty
        Me.ObsLoc.HighlightBorderOnEnter = false
        Me.ObsLoc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ObsLoc.Location = New System.Drawing.Point(4, 9)
        Me.ObsLoc.MaxLength = 1500
        Me.ObsLoc.Multiline = true
        Me.ObsLoc.Name = "ObsLoc"
        Me.ObsLoc.PreencherZeroEsqueda = false
        Me.ObsLoc.RegraValidação = Nothing
        Me.ObsLoc.RegraValidaçãoMensagem = Nothing
        Me.ObsLoc.Size = New System.Drawing.Size(317, 70)
        Me.ObsLoc.TabIndex = 0
        Me.ObsLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ObsLoc.ValorPadrao = Nothing
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Decorador)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtcontato)
        Me.Panel1.Controls.Add(Me.Telefone)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.ClienteNome)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Cliente)
        Me.Panel1.Location = New System.Drawing.Point(12, 114)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(629, 105)
        Me.Panel1.TabIndex = 10
        '
        'Decorador
        '
        Me.Decorador.AceitaColarTexto = false
        Me.Decorador.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Decorador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Decorador.CasasDecimais = 0
        Me.Decorador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Decorador.CPObrigatorio = false
        Me.Decorador.CPObrigatorioMsg = Nothing
        Me.Decorador.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Decorador.FlatBorder = true
        Me.Decorador.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Decorador.FocusColor = System.Drawing.Color.Empty
        Me.Decorador.FocusColorEnd = System.Drawing.Color.Empty
        Me.Decorador.HighlightBorderOnEnter = false
        Me.Decorador.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Decorador.Location = New System.Drawing.Point(582, 41)
        Me.Decorador.MaxLength = 1
        Me.Decorador.Name = "Decorador"
        Me.Decorador.PreencherZeroEsqueda = false
        Me.Decorador.RegraValidação = Nothing
        Me.Decorador.RegraValidaçãoMensagem = Nothing
        Me.Decorador.ShortcutsEnabled = false
        Me.Decorador.Size = New System.Drawing.Size(37, 23)
        Me.Decorador.TabIndex = 11
        Me.Decorador.TabStop = false
        Me.Decorador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Decorador.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Decorador.ValorPadrao = Nothing
        Me.Decorador.Visible = false
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(472, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 22)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "É Decorador ?"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.Visible = false
        '
        'txtcontato
        '
        Me.txtcontato.AceitaColarTexto = false
        Me.txtcontato.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtcontato.CasasDecimais = 0
        Me.txtcontato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontato.CPObrigatorio = false
        Me.txtcontato.CPObrigatorioMsg = Nothing
        Me.txtcontato.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtcontato.FlatBorder = false
        Me.txtcontato.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtcontato.FocusColor = System.Drawing.Color.Empty
        Me.txtcontato.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtcontato.HighlightBorderOnEnter = false
        Me.txtcontato.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtcontato.Location = New System.Drawing.Point(148, 71)
        Me.txtcontato.MaxLength = 50
        Me.txtcontato.Name = "txtcontato"
        Me.txtcontato.PreencherZeroEsqueda = false
        Me.txtcontato.RegraValidação = Nothing
        Me.txtcontato.RegraValidaçãoMensagem = Nothing
        Me.txtcontato.ShortcutsEnabled = false
        Me.txtcontato.Size = New System.Drawing.Size(471, 23)
        Me.txtcontato.TabIndex = 5
        Me.txtcontato.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtcontato.ValorPadrao = Nothing
        '
        'Telefone
        '
        Me.Telefone.AceitaColarTexto = false
        Me.Telefone.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Telefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Telefone.CasasDecimais = 0
        Me.Telefone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Telefone.CPObrigatorio = false
        Me.Telefone.CPObrigatorioMsg = Nothing
        Me.Telefone.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Telefone.FlatBorder = true
        Me.Telefone.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Telefone.FocusColor = System.Drawing.Color.Empty
        Me.Telefone.FocusColorEnd = System.Drawing.Color.Empty
        Me.Telefone.HighlightBorderOnEnter = false
        Me.Telefone.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Telefone.Location = New System.Drawing.Point(148, 40)
        Me.Telefone.MaxLength = 14
        Me.Telefone.Name = "Telefone"
        Me.Telefone.PreencherZeroEsqueda = false
        Me.Telefone.RegraValidação = Nothing
        Me.Telefone.RegraValidaçãoMensagem = Nothing
        Me.Telefone.ShortcutsEnabled = false
        Me.Telefone.Size = New System.Drawing.Size(119, 23)
        Me.Telefone.TabIndex = 4
        Me.Telefone.TabStop = false
        Me.Telefone.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Fone
        Me.Telefone.ValorPadrao = Nothing
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(7, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 22)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Telefone"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ClienteNome
        '
        Me.ClienteNome.AceitaColarTexto = false
        Me.ClienteNome.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ClienteNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ClienteNome.CasasDecimais = 0
        Me.ClienteNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ClienteNome.CPObrigatorio = false
        Me.ClienteNome.CPObrigatorioMsg = Nothing
        Me.ClienteNome.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ClienteNome.FlatBorder = true
        Me.ClienteNome.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ClienteNome.FocusColor = System.Drawing.Color.Empty
        Me.ClienteNome.FocusColorEnd = System.Drawing.Color.Empty
        Me.ClienteNome.HighlightBorderOnEnter = false
        Me.ClienteNome.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ClienteNome.Location = New System.Drawing.Point(148, 13)
        Me.ClienteNome.MaxLength = 15
        Me.ClienteNome.Name = "ClienteNome"
        Me.ClienteNome.PreencherZeroEsqueda = false
        Me.ClienteNome.RegraValidação = Nothing
        Me.ClienteNome.RegraValidaçãoMensagem = Nothing
        Me.ClienteNome.ShortcutsEnabled = false
        Me.ClienteNome.Size = New System.Drawing.Size(471, 23)
        Me.ClienteNome.TabIndex = 1
        Me.ClienteNome.TabStop = false
        Me.ClienteNome.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.ClienteNome.ValorPadrao = Nothing
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(9, 72)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(133, 22)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Contato"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"),System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(7, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 22)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cliente"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cliente
        '
        Me.Cliente.AceitaColarTexto = false
        Me.Cliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cliente.CasasDecimais = 0
        Me.Cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cliente.CPObrigatorio = false
        Me.Cliente.CPObrigatorioMsg = Nothing
        Me.Cliente.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Cliente.FlatBorder = true
        Me.Cliente.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Cliente.FocusColor = System.Drawing.Color.Empty
        Me.Cliente.FocusColorEnd = System.Drawing.Color.Empty
        Me.Cliente.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Cliente.HighlightBorderOnEnter = false
        Me.Cliente.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Cliente.Location = New System.Drawing.Point(289, 39)
        Me.Cliente.MaxLength = 15
        Me.Cliente.Name = "Cliente"
        Me.Cliente.PreencherZeroEsqueda = false
        Me.Cliente.RegraValidação = Nothing
        Me.Cliente.RegraValidaçãoMensagem = Nothing
        Me.Cliente.ShortcutsEnabled = false
        Me.Cliente.Size = New System.Drawing.Size(69, 23)
        Me.Cliente.TabIndex = 0
        Me.Cliente.TabStop = false
        Me.Cliente.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.Cliente.ValorPadrao = Nothing
        Me.Cliente.Visible = false
        '
        'DataLoc
        '
        Me.DataLoc.AceitaColarTexto = false
        Me.DataLoc.BackColor = System.Drawing.Color.White
        Me.DataLoc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DataLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataLoc.CasasDecimais = 0
        Me.DataLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataLoc.CPObrigatorio = false
        Me.DataLoc.CPObrigatorioMsg = Nothing
        Me.DataLoc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataLoc.FlatBorder = true
        Me.DataLoc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataLoc.FocusColor = System.Drawing.Color.Empty
        Me.DataLoc.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataLoc.HighlightBorderOnEnter = false
        Me.DataLoc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataLoc.Location = New System.Drawing.Point(778, 47)
        Me.DataLoc.MaxLength = 10
        Me.DataLoc.Name = "DataLoc"
        Me.DataLoc.PreencherZeroEsqueda = false
        Me.DataLoc.RegraValidação = Nothing
        Me.DataLoc.RegraValidaçãoMensagem = Nothing
        Me.DataLoc.ShortcutsEnabled = false
        Me.DataLoc.Size = New System.Drawing.Size(127, 23)
        Me.DataLoc.TabIndex = 6
        Me.DataLoc.TabStop = false
        Me.DataLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataLoc.ValorPadrao = Nothing
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(673, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 22)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Data da Locação"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = false
        Me.Lista.AllowUserToDeleteRows = false
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.MediumPurple
        Me.Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cbtExcluir, Me.cIdItem, Me.cIdLocacao, Me.cProduto, Me.cDescrição, Me.cQtd, Me.cValorUnitarioLoc, Me.cValorDescontoLoc, Me.cTotalDiarias, Me.cTotalLoc, Me.cTotalAvarias, Me.cDisponibilidade})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lista.DefaultCellStyle = DataGridViewCellStyle19
        Me.Lista.EnableHeadersVisualStyles = false
        Me.Lista.GridColor = System.Drawing.Color.FromArgb(CType(CType(208,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(229,Byte),Integer))
        Me.Lista.Location = New System.Drawing.Point(12, 254)
        Me.Lista.MultiSelect = false
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = true
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.Lista.RowHeadersVisible = false
        Me.Lista.RowHeadersWidth = 20
        Me.Lista.SelectAllSignVisible = false
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(960, 293)
        Me.Lista.TabIndex = 17
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
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.cQtd.DefaultCellStyle = DataGridViewCellStyle13
        Me.cQtd.HeaderText = "Qtd Loc"
        Me.cQtd.Name = "cQtd"
        Me.cQtd.ReadOnly = true
        Me.cQtd.Width = 75
        '
        'cValorUnitarioLoc
        '
        Me.cValorUnitarioLoc.DataPropertyName = "ValorUnitarioLoc"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.cValorUnitarioLoc.DefaultCellStyle = DataGridViewCellStyle14
        Me.cValorUnitarioLoc.HeaderText = "Unit. Loc"
        Me.cValorUnitarioLoc.Name = "cValorUnitarioLoc"
        Me.cValorUnitarioLoc.ReadOnly = true
        Me.cValorUnitarioLoc.Width = 80
        '
        'cValorDescontoLoc
        '
        Me.cValorDescontoLoc.DataPropertyName = "ValorDescontoLoc"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.cValorDescontoLoc.DefaultCellStyle = DataGridViewCellStyle15
        Me.cValorDescontoLoc.HeaderText = "Desc. Loc"
        Me.cValorDescontoLoc.Name = "cValorDescontoLoc"
        Me.cValorDescontoLoc.ReadOnly = true
        Me.cValorDescontoLoc.Width = 85
        '
        'cTotalDiarias
        '
        Me.cTotalDiarias.DataPropertyName = "TotalDiarias"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.cTotalDiarias.DefaultCellStyle = DataGridViewCellStyle16
        Me.cTotalDiarias.HeaderText = "Tot Diarias"
        Me.cTotalDiarias.Name = "cTotalDiarias"
        Me.cTotalDiarias.ReadOnly = true
        Me.cTotalDiarias.Width = 90
        '
        'cTotalLoc
        '
        Me.cTotalLoc.DataPropertyName = "TotalLoc"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.cTotalLoc.DefaultCellStyle = DataGridViewCellStyle17
        Me.cTotalLoc.HeaderText = "Total Loc"
        Me.cTotalLoc.Name = "cTotalLoc"
        Me.cTotalLoc.ReadOnly = true
        Me.cTotalLoc.Width = 90
        '
        'cTotalAvarias
        '
        Me.cTotalAvarias.DataPropertyName = "TotalAvarias"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.cTotalAvarias.DefaultCellStyle = DataGridViewCellStyle18
        Me.cTotalAvarias.HeaderText = "Total Av"
        Me.cTotalAvarias.Name = "cTotalAvarias"
        Me.cTotalAvarias.ReadOnly = true
        Me.cTotalAvarias.Width = 90
        '
        'cDisponibilidade
        '
        Me.cDisponibilidade.DataPropertyName = "disponibilidade"
        Me.cDisponibilidade.HeaderText = "Disponível"
        Me.cDisponibilidade.Name = "cDisponibilidade"
        Me.cDisponibilidade.ReadOnly = true
        '
        'IdLoc
        '
        Me.IdLoc.AceitaColarTexto = false
        Me.IdLoc.BackColor = System.Drawing.Color.White
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
        Me.IdLoc.ReadOnly = true
        Me.IdLoc.RegraValidação = Nothing
        Me.IdLoc.RegraValidaçãoMensagem = Nothing
        Me.IdLoc.ShortcutsEnabled = false
        Me.IdLoc.Size = New System.Drawing.Size(112, 23)
        Me.IdLoc.TabIndex = 1
        Me.IdLoc.TabStop = false
        Me.IdLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.IdLoc.ValorPadrao = Nothing
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 22)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ID do Orçamento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.Panel3.Size = New System.Drawing.Size(954, 43)
        Me.Panel3.TabIndex = 19
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(397, 11)
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
        Me.tDesconto.Location = New System.Drawing.Point(472, 11)
        Me.tDesconto.MaxLength = 10
        Me.tDesconto.Name = "tDesconto"
        Me.tDesconto.PreencherZeroEsqueda = false
        Me.tDesconto.ReadOnly = true
        Me.tDesconto.RegraValidação = Nothing
        Me.tDesconto.RegraValidaçãoMensagem = Nothing
        Me.tDesconto.ShortcutsEnabled = false
        Me.tDesconto.Size = New System.Drawing.Size(102, 26)
        Me.tDesconto.TabIndex = 8
        Me.tDesconto.TabStop = false
        Me.tDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tDesconto.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.tDesconto.ValorPadrao = Nothing
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(3, 10)
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
        Me.tItens.Location = New System.Drawing.Point(60, 10)
        Me.tItens.MaxLength = 10
        Me.tItens.Name = "tItens"
        Me.tItens.PreencherZeroEsqueda = false
        Me.tItens.ReadOnly = true
        Me.tItens.RegraValidação = Nothing
        Me.tItens.RegraValidaçãoMensagem = Nothing
        Me.tItens.ShortcutsEnabled = false
        Me.tItens.Size = New System.Drawing.Size(114, 26)
        Me.tItens.TabIndex = 6
        Me.tItens.TabStop = false
        Me.tItens.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tItens.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.tItens.ValorPadrao = Nothing
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(600, 14)
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
        Me.ValorFrete.ForeColor = System.Drawing.Color.Red
        Me.ValorFrete.HighlightBorderOnEnter = false
        Me.ValorFrete.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ValorFrete.Location = New System.Drawing.Point(660, 13)
        Me.ValorFrete.MaxLength = 10
        Me.ValorFrete.Name = "ValorFrete"
        Me.ValorFrete.PreencherZeroEsqueda = false
        Me.ValorFrete.ReadOnly = true
        Me.ValorFrete.RegraValidação = Nothing
        Me.ValorFrete.RegraValidaçãoMensagem = Nothing
        Me.ValorFrete.ShortcutsEnabled = false
        Me.ValorFrete.Size = New System.Drawing.Size(93, 23)
        Me.ValorFrete.TabIndex = 2
        Me.ValorFrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ValorFrete.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.ValorFrete.ValorPadrao = Nothing
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(199, 12)
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
        Me.tDiariaAmais.Location = New System.Drawing.Point(266, 9)
        Me.tDiariaAmais.MaxLength = 10
        Me.tDiariaAmais.Name = "tDiariaAmais"
        Me.tDiariaAmais.PreencherZeroEsqueda = false
        Me.tDiariaAmais.ReadOnly = true
        Me.tDiariaAmais.RegraValidação = Nothing
        Me.tDiariaAmais.RegraValidaçãoMensagem = Nothing
        Me.tDiariaAmais.ShortcutsEnabled = false
        Me.tDiariaAmais.Size = New System.Drawing.Size(114, 26)
        Me.tDiariaAmais.TabIndex = 4
        Me.tDiariaAmais.TabStop = false
        Me.tDiariaAmais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tDiariaAmais.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.tDiariaAmais.ValorPadrao = Nothing
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(759, 12)
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
        Me.TotalLoc.Location = New System.Drawing.Point(835, 10)
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
        'LocacaoOrcamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 666)
        Me.ControlBox = false
        Me.Controls.Add(Me.Fundo)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = true
        Me.Name = "LocacaoOrcamento"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Locação de Acervo Orçamento"
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cliente As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Telefone As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ClienteNome As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CodBarra As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Qtd As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TotalLoc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents btConfirmarLocacao As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DataRetorno As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents HoraRetorno As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents HoraLoc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents ValorFrete As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Frete As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tItens As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tDiariaAmais As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tDesconto As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtcontato As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboVendedor As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCheckDisponibilidade As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnChangeToLocacao As DevComponents.DotNetBar.ButtonX
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
    Friend WithEvents cTotalAvarias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDisponibilidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents chkTransformadoEmLocacao As System.Windows.Forms.CheckBox
    Friend WithEvents Decorador As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
