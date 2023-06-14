<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SellShoesGerarNFe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SellShoesGerarNFe))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btGerarNFe = New DevComponents.DotNetBar.ButtonX()
        Me.Inativo = New System.Windows.Forms.CheckBox()
        Me.ConfImg = New System.Windows.Forms.Label()
        Me.cState = New System.Windows.Forms.Label()
        Me.TpVenda = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Confirmado = New System.Windows.Forms.CheckBox()
        Me.DataPedido = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.ChaveNFe = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TotalPedido = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cnpj = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ClienteDesc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Cliente = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Pedido = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btGerarNFe)
        Me.PanelEx1.Controls.Add(Me.Inativo)
        Me.PanelEx1.Controls.Add(Me.ConfImg)
        Me.PanelEx1.Controls.Add(Me.cState)
        Me.PanelEx1.Controls.Add(Me.TpVenda)
        Me.PanelEx1.Controls.Add(Me.Label7)
        Me.PanelEx1.Controls.Add(Me.Confirmado)
        Me.PanelEx1.Controls.Add(Me.DataPedido)
        Me.PanelEx1.Controls.Add(Me.Label5)
        Me.PanelEx1.Controls.Add(Me.Fechar)
        Me.PanelEx1.Controls.Add(Me.ChaveNFe)
        Me.PanelEx1.Controls.Add(Me.Label4)
        Me.PanelEx1.Controls.Add(Me.TotalPedido)
        Me.PanelEx1.Controls.Add(Me.Label6)
        Me.PanelEx1.Controls.Add(Me.Cnpj)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.ClienteDesc)
        Me.PanelEx1.Controls.Add(Me.Cliente)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.Pedido)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(777, 287)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'btGerarNFe
        '
        Me.btGerarNFe.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btGerarNFe.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btGerarNFe.Image = CType(resources.GetObject("btGerarNFe.Image"), System.Drawing.Image)
        Me.btGerarNFe.Location = New System.Drawing.Point(604, 249)
        Me.btGerarNFe.Name = "btGerarNFe"
        Me.btGerarNFe.Size = New System.Drawing.Size(88, 28)
        Me.btGerarNFe.TabIndex = 62
        Me.btGerarNFe.TabStop = False
        Me.btGerarNFe.Text = "Gerar NFe"
        '
        'Inativo
        '
        Me.Inativo.AutoSize = True
        Me.Inativo.Enabled = False
        Me.Inativo.Location = New System.Drawing.Point(376, 102)
        Me.Inativo.Name = "Inativo"
        Me.Inativo.Size = New System.Drawing.Size(60, 17)
        Me.Inativo.TabIndex = 39
        Me.Inativo.TabStop = False
        Me.Inativo.Text = "Inativo"
        Me.Inativo.UseVisualStyleBackColor = True
        '
        'ConfImg
        '
        Me.ConfImg.BackColor = System.Drawing.Color.Transparent
        Me.ConfImg.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfImg.Image = CType(resources.GetObject("ConfImg.Image"), System.Drawing.Image)
        Me.ConfImg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ConfImg.Location = New System.Drawing.Point(532, 110)
        Me.ConfImg.Name = "ConfImg"
        Me.ConfImg.Size = New System.Drawing.Size(233, 51)
        Me.ConfImg.TabIndex = 38
        Me.ConfImg.Tag = "7654"
        Me.ConfImg.Text = "Pedido Confirmado"
        Me.ConfImg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ConfImg.Visible = False
        '
        'cState
        '
        Me.cState.BackColor = System.Drawing.Color.Transparent
        Me.cState.Location = New System.Drawing.Point(213, 216)
        Me.cState.Name = "cState"
        Me.cState.Size = New System.Drawing.Size(552, 20)
        Me.cState.TabIndex = 30
        Me.cState.Text = "Sem NF"
        Me.cState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TpVenda
        '
        Me.TpVenda.AceitaColarTexto = True
        Me.TpVenda.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.TpVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TpVenda.CasasDecimais = 0
        Me.TpVenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TpVenda.CPObrigatorio = False
        Me.TpVenda.CPObrigatorioMsg = Nothing
        Me.TpVenda.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.TpVenda.FlatBorder = True
        Me.TpVenda.FlatBorderColor = System.Drawing.Color.DimGray
        Me.TpVenda.FocusColor = System.Drawing.Color.MistyRose
        Me.TpVenda.FocusColorEnd = System.Drawing.Color.Empty
        Me.TpVenda.GlowColor = System.Drawing.Color.Navy
        Me.TpVenda.HighlightBorderOnEnter = False
        Me.TpVenda.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.TpVenda.Location = New System.Drawing.Point(213, 155)
        Me.TpVenda.MaxLength = 30
        Me.TpVenda.Name = "TpVenda"
        Me.TpVenda.PreencherZeroEsqueda = False
        Me.TpVenda.RegraValidação = Nothing
        Me.TpVenda.RegraValidaçãoMensagem = Nothing
        Me.TpVenda.Size = New System.Drawing.Size(100, 21)
        Me.TpVenda.TabIndex = 29
        Me.TpVenda.TabStop = False
        Me.TpVenda.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.TpVenda.ValorPadrao = Nothing
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(15, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 20)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Tipo de Venda"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Confirmado
        '
        Me.Confirmado.AutoSize = True
        Me.Confirmado.Enabled = False
        Me.Confirmado.Location = New System.Drawing.Point(376, 77)
        Me.Confirmado.Name = "Confirmado"
        Me.Confirmado.Size = New System.Drawing.Size(81, 17)
        Me.Confirmado.TabIndex = 27
        Me.Confirmado.TabStop = False
        Me.Confirmado.Text = "Confirmado"
        Me.Confirmado.UseVisualStyleBackColor = True
        '
        'DataPedido
        '
        Me.DataPedido.AceitaColarTexto = True
        Me.DataPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.DataPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataPedido.CasasDecimais = 0
        Me.DataPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataPedido.CPObrigatorio = False
        Me.DataPedido.CPObrigatorioMsg = Nothing
        Me.DataPedido.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataPedido.FlatBorder = True
        Me.DataPedido.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataPedido.FocusColor = System.Drawing.Color.MistyRose
        Me.DataPedido.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataPedido.GlowColor = System.Drawing.Color.Navy
        Me.DataPedido.HighlightBorderOnEnter = False
        Me.DataPedido.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataPedido.Location = New System.Drawing.Point(213, 101)
        Me.DataPedido.MaxLength = 10
        Me.DataPedido.Name = "DataPedido"
        Me.DataPedido.PreencherZeroEsqueda = False
        Me.DataPedido.RegraValidação = Nothing
        Me.DataPedido.RegraValidaçãoMensagem = Nothing
        Me.DataPedido.Size = New System.Drawing.Size(100, 21)
        Me.DataPedido.TabIndex = 26
        Me.DataPedido.TabStop = False
        Me.DataPedido.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataPedido.ValorPadrao = Nothing
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(15, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Data do Pedido"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Location = New System.Drawing.Point(698, 249)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(67, 28)
        Me.Fechar.TabIndex = 24
        Me.Fechar.TabStop = False
        Me.Fechar.Text = "Fechar"
        '
        'ChaveNFe
        '
        Me.ChaveNFe.AceitaColarTexto = True
        Me.ChaveNFe.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ChaveNFe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ChaveNFe.CasasDecimais = 0
        Me.ChaveNFe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ChaveNFe.CPObrigatorio = False
        Me.ChaveNFe.CPObrigatorioMsg = Nothing
        Me.ChaveNFe.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ChaveNFe.FlatBorder = True
        Me.ChaveNFe.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ChaveNFe.FocusColor = System.Drawing.Color.MistyRose
        Me.ChaveNFe.FocusColorEnd = System.Drawing.Color.Empty
        Me.ChaveNFe.GlowColor = System.Drawing.Color.Navy
        Me.ChaveNFe.HighlightBorderOnEnter = False
        Me.ChaveNFe.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ChaveNFe.Location = New System.Drawing.Point(213, 192)
        Me.ChaveNFe.MaxLength = 45
        Me.ChaveNFe.Name = "ChaveNFe"
        Me.ChaveNFe.PreencherZeroEsqueda = False
        Me.ChaveNFe.RegraValidação = Nothing
        Me.ChaveNFe.RegraValidaçãoMensagem = Nothing
        Me.ChaveNFe.Size = New System.Drawing.Size(379, 21)
        Me.ChaveNFe.TabIndex = 23
        Me.ChaveNFe.TabStop = False
        Me.ChaveNFe.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ChaveNFe.ValorPadrao = Nothing
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(15, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Chave da NFe"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TotalPedido
        '
        Me.TotalPedido.AceitaColarTexto = True
        Me.TotalPedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.TotalPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalPedido.CasasDecimais = 0
        Me.TotalPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TotalPedido.CPObrigatorio = False
        Me.TotalPedido.CPObrigatorioMsg = Nothing
        Me.TotalPedido.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.TotalPedido.FlatBorder = True
        Me.TotalPedido.FlatBorderColor = System.Drawing.Color.DimGray
        Me.TotalPedido.FocusColor = System.Drawing.Color.MistyRose
        Me.TotalPedido.FocusColorEnd = System.Drawing.Color.Empty
        Me.TotalPedido.GlowColor = System.Drawing.Color.Navy
        Me.TotalPedido.HighlightBorderOnEnter = False
        Me.TotalPedido.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.TotalPedido.Location = New System.Drawing.Point(213, 128)
        Me.TotalPedido.MaxLength = 30
        Me.TotalPedido.Name = "TotalPedido"
        Me.TotalPedido.PreencherZeroEsqueda = False
        Me.TotalPedido.RegraValidação = Nothing
        Me.TotalPedido.RegraValidaçãoMensagem = Nothing
        Me.TotalPedido.Size = New System.Drawing.Size(100, 21)
        Me.TotalPedido.TabIndex = 21
        Me.TotalPedido.TabStop = False
        Me.TotalPedido.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.TotalPedido.ValorPadrao = Nothing
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(15, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(192, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Total do Pedido"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cnpj
        '
        Me.Cnpj.AceitaColarTexto = True
        Me.Cnpj.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cnpj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cnpj.CasasDecimais = 0
        Me.Cnpj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cnpj.CPObrigatorio = False
        Me.Cnpj.CPObrigatorioMsg = Nothing
        Me.Cnpj.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Cnpj.FlatBorder = True
        Me.Cnpj.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Cnpj.FocusColor = System.Drawing.Color.MistyRose
        Me.Cnpj.FocusColorEnd = System.Drawing.Color.Empty
        Me.Cnpj.GlowColor = System.Drawing.Color.Navy
        Me.Cnpj.HighlightBorderOnEnter = False
        Me.Cnpj.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Cnpj.Location = New System.Drawing.Point(213, 74)
        Me.Cnpj.MaxLength = 18
        Me.Cnpj.Name = "Cnpj"
        Me.Cnpj.PreencherZeroEsqueda = False
        Me.Cnpj.RegraValidação = Nothing
        Me.Cnpj.RegraValidaçãoMensagem = Nothing
        Me.Cnpj.Size = New System.Drawing.Size(157, 21)
        Me.Cnpj.TabIndex = 19
        Me.Cnpj.TabStop = False
        Me.Cnpj.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Cnpj.ValorPadrao = Nothing
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(15, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Cnpj"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ClienteDesc
        '
        Me.ClienteDesc.AceitaColarTexto = True
        Me.ClienteDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ClienteDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ClienteDesc.CasasDecimais = 0
        Me.ClienteDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ClienteDesc.CPObrigatorio = False
        Me.ClienteDesc.CPObrigatorioMsg = Nothing
        Me.ClienteDesc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ClienteDesc.FlatBorder = True
        Me.ClienteDesc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ClienteDesc.FocusColor = System.Drawing.Color.MistyRose
        Me.ClienteDesc.FocusColorEnd = System.Drawing.Color.Empty
        Me.ClienteDesc.GlowColor = System.Drawing.Color.Navy
        Me.ClienteDesc.HighlightBorderOnEnter = False
        Me.ClienteDesc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ClienteDesc.Location = New System.Drawing.Point(298, 48)
        Me.ClienteDesc.MaxLength = 100
        Me.ClienteDesc.Name = "ClienteDesc"
        Me.ClienteDesc.PreencherZeroEsqueda = False
        Me.ClienteDesc.RegraValidação = Nothing
        Me.ClienteDesc.RegraValidaçãoMensagem = Nothing
        Me.ClienteDesc.Size = New System.Drawing.Size(467, 21)
        Me.ClienteDesc.TabIndex = 17
        Me.ClienteDesc.TabStop = False
        Me.ClienteDesc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ClienteDesc.ValorPadrao = Nothing
        '
        'Cliente
        '
        Me.Cliente.AceitaColarTexto = True
        Me.Cliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cliente.CasasDecimais = 0
        Me.Cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cliente.CPObrigatorio = False
        Me.Cliente.CPObrigatorioMsg = Nothing
        Me.Cliente.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Cliente.FlatBorder = True
        Me.Cliente.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Cliente.FocusColor = System.Drawing.Color.MistyRose
        Me.Cliente.FocusColorEnd = System.Drawing.Color.Empty
        Me.Cliente.GlowColor = System.Drawing.Color.Navy
        Me.Cliente.HighlightBorderOnEnter = False
        Me.Cliente.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Cliente.Location = New System.Drawing.Point(213, 48)
        Me.Cliente.MaxLength = 15
        Me.Cliente.Name = "Cliente"
        Me.Cliente.PreencherZeroEsqueda = False
        Me.Cliente.RegraValidação = Nothing
        Me.Cliente.RegraValidaçãoMensagem = Nothing
        Me.Cliente.Size = New System.Drawing.Size(79, 21)
        Me.Cliente.TabIndex = 15
        Me.Cliente.TabStop = False
        Me.Cliente.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.Cliente.ValorPadrao = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(15, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Cliente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pedido
        '
        Me.Pedido.AceitaColarTexto = True
        Me.Pedido.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pedido.CasasDecimais = 0
        Me.Pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Pedido.CPObrigatorio = False
        Me.Pedido.CPObrigatorioMsg = Nothing
        Me.Pedido.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Pedido.FlatBorder = True
        Me.Pedido.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Pedido.FocusColor = System.Drawing.Color.MistyRose
        Me.Pedido.FocusColorEnd = System.Drawing.Color.Empty
        Me.Pedido.GlowColor = System.Drawing.Color.Navy
        Me.Pedido.HighlightBorderOnEnter = False
        Me.Pedido.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Pedido.Location = New System.Drawing.Point(213, 22)
        Me.Pedido.MaxLength = 15
        Me.Pedido.Name = "Pedido"
        Me.Pedido.PreencherZeroEsqueda = False
        Me.Pedido.RegraValidação = Nothing
        Me.Pedido.RegraValidaçãoMensagem = Nothing
        Me.Pedido.Size = New System.Drawing.Size(79, 21)
        Me.Pedido.TabIndex = 13
        Me.Pedido.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.Pedido.ValorPadrao = Nothing
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Informe o Pedido"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SellShoesGerarNFe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 287)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SellShoesGerarNFe"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gerar NFe"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TotalPedido As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cnpj As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ClienteDesc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Cliente As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pedido As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChaveNFe As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DataPedido As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Confirmado As System.Windows.Forms.CheckBox
    Friend WithEvents TpVenda As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cState As System.Windows.Forms.Label
    Friend WithEvents ConfImg As System.Windows.Forms.Label
    Friend WithEvents Inativo As System.Windows.Forms.CheckBox
    Friend WithEvents btGerarNFe As DevComponents.DotNetBar.ButtonX
End Class
