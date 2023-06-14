<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Devolucao
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Devolucao))
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
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataEfetiva = New TexBoxFocusNet.TextBoxFocusNet()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.txtNumeroLocacao = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btConfirmarLocacao = New DevComponents.DotNetBar.ButtonX()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cliente = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Telefone = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataLoc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNomeVendedor = New TexBoxFocusNet.TextBoxFocusNet()
        Me.ClienteNome = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DataRetorno = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
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
        Me.painelRetorno = New System.Windows.Forms.Panel()
        Me.btConfirmar = New DevComponents.DotNetBar.ButtonX()
        Me.txtQuantidadeRetorno = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtValorReposicao = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Fundo.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.Panel1.SuspendLayout
        CType(Me.Lista,System.ComponentModel.ISupportInitialize).BeginInit
        Me.painelRetorno.SuspendLayout
        Me.Panel3.SuspendLayout
        Me.SuspendLayout
        '
        'Fundo
        '
        Me.Fundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Fundo.Controls.Add(Me.ButtonX2)
        Me.Fundo.Controls.Add(Me.Panel2)
        Me.Fundo.Controls.Add(Me.btConfirmarLocacao)
        Me.Fundo.Controls.Add(Me.Fechar)
        Me.Fundo.Controls.Add(Me.Label4)
        Me.Fundo.Controls.Add(Me.Panel1)
        Me.Fundo.Controls.Add(Me.Lista)
        Me.Fundo.Controls.Add(Me.painelRetorno)
        Me.Fundo.Controls.Add(Me.Panel3)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(1049, 585)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ButtonX2.Image = CType(resources.GetObject("ButtonX2.Image"),System.Drawing.Image)
        Me.ButtonX2.Location = New System.Drawing.Point(14, 532)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(161, 47)
        Me.ButtonX2.TabIndex = 8
        Me.ButtonX2.TabStop = false
        Me.ButtonX2.Text = "Marcar Todos"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtDataEfetiva)
        Me.Panel2.Controls.Add(Me.ButtonX1)
        Me.Panel2.Controls.Add(Me.txtNumeroLocacao)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Location = New System.Drawing.Point(14, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1023, 72)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(635, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 30)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Data Efetiva do Retorno"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDataEfetiva
        '
        Me.txtDataEfetiva.AceitaColarTexto = false
        Me.txtDataEfetiva.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtDataEfetiva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDataEfetiva.CasasDecimais = 0
        Me.txtDataEfetiva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataEfetiva.CPObrigatorio = false
        Me.txtDataEfetiva.CPObrigatorioMsg = Nothing
        Me.txtDataEfetiva.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtDataEfetiva.FlatBorder = true
        Me.txtDataEfetiva.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtDataEfetiva.FocusColor = System.Drawing.Color.Empty
        Me.txtDataEfetiva.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtDataEfetiva.Font = New System.Drawing.Font("Comic Sans MS", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDataEfetiva.HighlightBorderOnEnter = false
        Me.txtDataEfetiva.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtDataEfetiva.Location = New System.Drawing.Point(856, 20)
        Me.txtDataEfetiva.MaxLength = 10
        Me.txtDataEfetiva.Name = "txtDataEfetiva"
        Me.txtDataEfetiva.PreencherZeroEsqueda = false
        Me.txtDataEfetiva.ReadOnly = true
        Me.txtDataEfetiva.RegraValidação = Nothing
        Me.txtDataEfetiva.RegraValidaçãoMensagem = Nothing
        Me.txtDataEfetiva.ShortcutsEnabled = false
        Me.txtDataEfetiva.Size = New System.Drawing.Size(144, 26)
        Me.txtDataEfetiva.TabIndex = 3
        Me.txtDataEfetiva.TabStop = false
        Me.txtDataEfetiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDataEfetiva.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.txtDataEfetiva.ValorPadrao = Nothing
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ButtonX1.Location = New System.Drawing.Point(293, 22)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(85, 30)
        Me.ButtonX1.TabIndex = 2
        Me.ButtonX1.Text = "< Busca"
        '
        'txtNumeroLocacao
        '
        Me.txtNumeroLocacao.AceitaColarTexto = false
        Me.txtNumeroLocacao.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtNumeroLocacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroLocacao.CasasDecimais = 0
        Me.txtNumeroLocacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroLocacao.CPObrigatorio = false
        Me.txtNumeroLocacao.CPObrigatorioMsg = Nothing
        Me.txtNumeroLocacao.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtNumeroLocacao.FlatBorder = true
        Me.txtNumeroLocacao.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtNumeroLocacao.FocusColor = System.Drawing.Color.Empty
        Me.txtNumeroLocacao.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtNumeroLocacao.Font = New System.Drawing.Font("Comic Sans MS", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNumeroLocacao.HighlightBorderOnEnter = false
        Me.txtNumeroLocacao.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtNumeroLocacao.Location = New System.Drawing.Point(143, 22)
        Me.txtNumeroLocacao.MaxLength = 15
        Me.txtNumeroLocacao.Name = "txtNumeroLocacao"
        Me.txtNumeroLocacao.PreencherZeroEsqueda = false
        Me.txtNumeroLocacao.RegraValidação = Nothing
        Me.txtNumeroLocacao.RegraValidaçãoMensagem = Nothing
        Me.txtNumeroLocacao.ShortcutsEnabled = false
        Me.txtNumeroLocacao.Size = New System.Drawing.Size(144, 26)
        Me.txtNumeroLocacao.TabIndex = 1
        Me.txtNumeroLocacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtNumeroLocacao.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.txtNumeroLocacao.ValorPadrao = Nothing
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Comic Sans MS", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label23.Location = New System.Drawing.Point(10, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(126, 30)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Nº Locação"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btConfirmarLocacao
        '
        Me.btConfirmarLocacao.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btConfirmarLocacao.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btConfirmarLocacao.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btConfirmarLocacao.Image = CType(resources.GetObject("btConfirmarLocacao.Image"),System.Drawing.Image)
        Me.btConfirmarLocacao.Location = New System.Drawing.Point(789, 530)
        Me.btConfirmarLocacao.Name = "btConfirmarLocacao"
        Me.btConfirmarLocacao.Size = New System.Drawing.Size(131, 47)
        Me.btConfirmarLocacao.TabIndex = 7
        Me.btConfirmarLocacao.TabStop = false
        Me.btConfirmarLocacao.Text = "Confirmar Devolução"
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Fechar.Image = CType(resources.GetObject("Fechar.Image"),System.Drawing.Image)
        Me.Fechar.Location = New System.Drawing.Point(926, 530)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(111, 47)
        Me.Fechar.TabIndex = 6
        Me.Fechar.TabStop = false
        Me.Fechar.Text = "Fechar"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(27, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 25)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Dados do Cliente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Cliente)
        Me.Panel1.Controls.Add(Me.Telefone)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.DataLoc)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtNomeVendedor)
        Me.Panel1.Controls.Add(Me.ClienteNome)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.DataRetorno)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Enabled = false
        Me.Panel1.Location = New System.Drawing.Point(14, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1023, 80)
        Me.Panel1.TabIndex = 2
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
        Me.Cliente.Location = New System.Drawing.Point(143, 14)
        Me.Cliente.MaxLength = 15
        Me.Cliente.Name = "Cliente"
        Me.Cliente.PreencherZeroEsqueda = false
        Me.Cliente.RegraValidação = Nothing
        Me.Cliente.RegraValidaçãoMensagem = Nothing
        Me.Cliente.ShortcutsEnabled = false
        Me.Cliente.Size = New System.Drawing.Size(65, 23)
        Me.Cliente.TabIndex = 10
        Me.Cliente.TabStop = false
        Me.Cliente.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.Cliente.ValorPadrao = Nothing
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
        Me.Telefone.Location = New System.Drawing.Point(696, 14)
        Me.Telefone.MaxLength = 14
        Me.Telefone.Name = "Telefone"
        Me.Telefone.PreencherZeroEsqueda = false
        Me.Telefone.RegraValidação = Nothing
        Me.Telefone.RegraValidaçãoMensagem = Nothing
        Me.Telefone.ShortcutsEnabled = false
        Me.Telefone.Size = New System.Drawing.Size(119, 23)
        Me.Telefone.TabIndex = 9
        Me.Telefone.TabStop = false
        Me.Telefone.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Fone
        Me.Telefone.ValorPadrao = Nothing
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(623, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 22)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Telefone"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataLoc
        '
        Me.DataLoc.AceitaColarTexto = false
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
        Me.DataLoc.Location = New System.Drawing.Point(933, 14)
        Me.DataLoc.MaxLength = 10
        Me.DataLoc.Name = "DataLoc"
        Me.DataLoc.PreencherZeroEsqueda = false
        Me.DataLoc.RegraValidação = Nothing
        Me.DataLoc.RegraValidaçãoMensagem = Nothing
        Me.DataLoc.ShortcutsEnabled = false
        Me.DataLoc.Size = New System.Drawing.Size(85, 23)
        Me.DataLoc.TabIndex = 7
        Me.DataLoc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataLoc.ValorPadrao = Nothing
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(833, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 22)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Data da Locação"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNomeVendedor
        '
        Me.txtNomeVendedor.AceitaColarTexto = false
        Me.txtNomeVendedor.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtNomeVendedor.CasasDecimais = 0
        Me.txtNomeVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeVendedor.CPObrigatorio = false
        Me.txtNomeVendedor.CPObrigatorioMsg = Nothing
        Me.txtNomeVendedor.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtNomeVendedor.FlatBorder = false
        Me.txtNomeVendedor.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtNomeVendedor.FocusColor = System.Drawing.Color.Empty
        Me.txtNomeVendedor.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtNomeVendedor.HighlightBorderOnEnter = false
        Me.txtNomeVendedor.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtNomeVendedor.Location = New System.Drawing.Point(143, 40)
        Me.txtNomeVendedor.MaxLength = 100
        Me.txtNomeVendedor.Name = "txtNomeVendedor"
        Me.txtNomeVendedor.PreencherZeroEsqueda = false
        Me.txtNomeVendedor.RegraValidação = Nothing
        Me.txtNomeVendedor.RegraValidaçãoMensagem = Nothing
        Me.txtNomeVendedor.ShortcutsEnabled = false
        Me.txtNomeVendedor.Size = New System.Drawing.Size(468, 23)
        Me.txtNomeVendedor.TabIndex = 2
        Me.txtNomeVendedor.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtNomeVendedor.ValorPadrao = Nothing
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
        Me.ClienteNome.Location = New System.Drawing.Point(211, 14)
        Me.ClienteNome.MaxLength = 15
        Me.ClienteNome.Name = "ClienteNome"
        Me.ClienteNome.PreencherZeroEsqueda = false
        Me.ClienteNome.RegraValidação = Nothing
        Me.ClienteNome.RegraValidaçãoMensagem = Nothing
        Me.ClienteNome.ShortcutsEnabled = false
        Me.ClienteNome.Size = New System.Drawing.Size(399, 23)
        Me.ClienteNome.TabIndex = 0
        Me.ClienteNome.TabStop = false
        Me.ClienteNome.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.ClienteNome.ValorPadrao = Nothing
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(12, 41)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(64, 25)
        Me.Label27.TabIndex = 5
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
        Me.DataRetorno.Location = New System.Drawing.Point(933, 41)
        Me.DataRetorno.MaxLength = 10
        Me.DataRetorno.Name = "DataRetorno"
        Me.DataRetorno.PreencherZeroEsqueda = false
        Me.DataRetorno.RegraValidação = Nothing
        Me.DataRetorno.RegraValidaçãoMensagem = Nothing
        Me.DataRetorno.ShortcutsEnabled = false
        Me.DataRetorno.Size = New System.Drawing.Size(85, 23)
        Me.DataRetorno.TabIndex = 1
        Me.DataRetorno.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataRetorno.ValorPadrao = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cliente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(836, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 25)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Data Retorno"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = false
        Me.Lista.AllowUserToDeleteRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
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
        Me.Lista.Location = New System.Drawing.Point(14, 172)
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
        Me.Lista.Size = New System.Drawing.Size(1023, 262)
        Me.Lista.TabIndex = 3
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
        Me.cDescrição.Width = 300
        '
        'cQtd
        '
        Me.cQtd.DataPropertyName = "Qtd"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.cQtd.DefaultCellStyle = DataGridViewCellStyle3
        Me.cQtd.HeaderText = "Locado"
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
        Me.cValorUnitarioLoc.Visible = false
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
        Me.cValorDescontoLoc.Visible = false
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
        Me.cTotalDiarias.Visible = false
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
        Me.cTotalLoc.Visible = false
        Me.cTotalLoc.Width = 90
        '
        'cQtdDev
        '
        Me.cQtdDev.DataPropertyName = "QtdDev"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.cQtdDev.DefaultCellStyle = DataGridViewCellStyle8
        Me.cQtdDev.HeaderText = "Retorno"
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
        Me.cQtdAvarias.HeaderText = "Falta"
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
        Me.cValorUnitarioAvarias.HeaderText = "Valor Reposição"
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
        Me.cTotalAvarias.HeaderText = "Total"
        Me.cTotalAvarias.MaxInputLength = 131068
        Me.cTotalAvarias.Name = "cTotalAvarias"
        Me.cTotalAvarias.ReadOnly = true
        Me.cTotalAvarias.Width = 90
        '
        'painelRetorno
        '
        Me.painelRetorno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.painelRetorno.Controls.Add(Me.btConfirmar)
        Me.painelRetorno.Controls.Add(Me.txtQuantidadeRetorno)
        Me.painelRetorno.Enabled = false
        Me.painelRetorno.Location = New System.Drawing.Point(14, 446)
        Me.painelRetorno.Name = "painelRetorno"
        Me.painelRetorno.Size = New System.Drawing.Size(712, 59)
        Me.painelRetorno.TabIndex = 4
        '
        'btConfirmar
        '
        Me.btConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btConfirmar.Image = CType(resources.GetObject("btConfirmar.Image"),System.Drawing.Image)
        Me.btConfirmar.Location = New System.Drawing.Point(182, 13)
        Me.btConfirmar.Name = "btConfirmar"
        Me.btConfirmar.Size = New System.Drawing.Size(111, 30)
        Me.btConfirmar.TabIndex = 1
        Me.btConfirmar.Text = "Confirmar"
        '
        'txtQuantidadeRetorno
        '
        Me.txtQuantidadeRetorno.AceitaColarTexto = false
        Me.txtQuantidadeRetorno.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtQuantidadeRetorno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantidadeRetorno.CasasDecimais = 0
        Me.txtQuantidadeRetorno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantidadeRetorno.CPObrigatorio = false
        Me.txtQuantidadeRetorno.CPObrigatorioMsg = Nothing
        Me.txtQuantidadeRetorno.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtQuantidadeRetorno.FlatBorder = true
        Me.txtQuantidadeRetorno.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtQuantidadeRetorno.FocusColor = System.Drawing.Color.Empty
        Me.txtQuantidadeRetorno.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtQuantidadeRetorno.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtQuantidadeRetorno.HighlightBorderOnEnter = false
        Me.txtQuantidadeRetorno.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtQuantidadeRetorno.Location = New System.Drawing.Point(9, 9)
        Me.txtQuantidadeRetorno.MaxLength = 15
        Me.txtQuantidadeRetorno.Name = "txtQuantidadeRetorno"
        Me.txtQuantidadeRetorno.PreencherZeroEsqueda = false
        Me.txtQuantidadeRetorno.RegraValidação = Nothing
        Me.txtQuantidadeRetorno.RegraValidaçãoMensagem = Nothing
        Me.txtQuantidadeRetorno.ShortcutsEnabled = false
        Me.txtQuantidadeRetorno.Size = New System.Drawing.Size(167, 37)
        Me.txtQuantidadeRetorno.TabIndex = 0
        Me.txtQuantidadeRetorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtQuantidadeRetorno.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Numeros
        Me.txtQuantidadeRetorno.ValorPadrao = Nothing
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.txtValorReposicao)
        Me.Panel3.Location = New System.Drawing.Point(732, 446)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(305, 59)
        Me.Panel3.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(16, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 29)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Total Reposição"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValorReposicao
        '
        Me.txtValorReposicao.AceitaColarTexto = false
        Me.txtValorReposicao.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.txtValorReposicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorReposicao.CasasDecimais = 2
        Me.txtValorReposicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValorReposicao.CPObrigatorio = false
        Me.txtValorReposicao.CPObrigatorioMsg = Nothing
        Me.txtValorReposicao.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtValorReposicao.FlatBorder = true
        Me.txtValorReposicao.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtValorReposicao.FocusColor = System.Drawing.Color.Empty
        Me.txtValorReposicao.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtValorReposicao.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtValorReposicao.HighlightBorderOnEnter = false
        Me.txtValorReposicao.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtValorReposicao.Location = New System.Drawing.Point(156, 14)
        Me.txtValorReposicao.MaxLength = 10
        Me.txtValorReposicao.Name = "txtValorReposicao"
        Me.txtValorReposicao.PreencherZeroEsqueda = false
        Me.txtValorReposicao.RegraValidação = Nothing
        Me.txtValorReposicao.RegraValidaçãoMensagem = Nothing
        Me.txtValorReposicao.ShortcutsEnabled = false
        Me.txtValorReposicao.Size = New System.Drawing.Size(133, 26)
        Me.txtValorReposicao.TabIndex = 0
        Me.txtValorReposicao.TabStop = false
        Me.txtValorReposicao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValorReposicao.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.txtValorReposicao.ValorPadrao = Nothing
        '
        'Devolucao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 585)
        Me.ControlBox = false
        Me.Controls.Add(Me.Fundo)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Devolucao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devolução de Locação"
        Me.Fundo.ResumeLayout(false)
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.Lista,System.ComponentModel.ISupportInitialize).EndInit
        Me.painelRetorno.ResumeLayout(false)
        Me.painelRetorno.PerformLayout
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents txtNomeVendedor As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents DataRetorno As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btConfirmarLocacao As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtNumeroLocacao As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ClienteNome As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Lista As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtValorReposicao As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDataEfetiva As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DataLoc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Telefone As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents painelRetorno As System.Windows.Forms.Panel
    Friend WithEvents txtQuantidadeRetorno As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents btConfirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Cliente As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents cbtExcluir As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents cIdItem As DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacao As DataGridViewTextBoxColumn
    Friend WithEvents cProduto As DataGridViewTextBoxColumn
    Friend WithEvents cDescrição As DataGridViewTextBoxColumn
    Friend WithEvents cQtd As DataGridViewTextBoxColumn
    Friend WithEvents cValorUnitarioLoc As DataGridViewTextBoxColumn
    Friend WithEvents cValorDescontoLoc As DataGridViewTextBoxColumn
    Friend WithEvents cTotalDiarias As DataGridViewTextBoxColumn
    Friend WithEvents cTotalLoc As DataGridViewTextBoxColumn
    Friend WithEvents cQtdDev As DataGridViewTextBoxColumn
    Friend WithEvents cQtdAvarias As DataGridViewTextBoxColumn
    Friend WithEvents cValorUnitarioAvarias As DataGridViewTextBoxColumn
    Friend WithEvents cTotalAvarias As DataGridViewTextBoxColumn
End Class
