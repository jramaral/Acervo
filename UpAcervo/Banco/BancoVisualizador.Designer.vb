<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BancoVisualizador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BancoVisualizador))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Codigo = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ContaCorrente = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Agencia = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Banco = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btChequePre = New DevComponents.DotNetBar.ButtonX()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.Lançamentos = New DevComponents.DotNetBar.ButtonX()
        Me.Compensar = New DevComponents.DotNetBar.ButtonX()
        Me.Extrato = New DevComponents.DotNetBar.ButtonX()
        Me.Localizar = New DevComponents.DotNetBar.ButtonX()
        Me.BTCC = New DevComponents.DotNetBar.ButtonX()
        Me.Painel = New System.Windows.Forms.Panel()
        Me.DGLanc = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btFindCC = New System.Windows.Forms.Label()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.DataLancamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Historico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaiuBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ano = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFavorecido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fundo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Painel.SuspendLayout()
        CType(Me.DGLanc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cod C/C"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Codigo
        '
        Me.Codigo.AceitaColarTexto = True
        Me.Codigo.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Codigo.CasasDecimais = 0
        Me.Codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Codigo.CPObrigatorio = False
        Me.Codigo.CPObrigatorioMsg = Nothing
        Me.Codigo.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Sim
        Me.Codigo.FlatBorder = False
        Me.Codigo.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Codigo.FocusColor = System.Drawing.Color.MistyRose
        Me.Codigo.FocusColorEnd = System.Drawing.Color.Empty
        Me.Codigo.HighlightBorderOnEnter = False
        Me.Codigo.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Codigo.Location = New System.Drawing.Point(70, 14)
        Me.Codigo.MaxLength = 15
        Me.Codigo.Name = "Codigo"
        Me.Codigo.PreencherZeroEsqueda = False
        Me.Codigo.RegraValidação = Nothing
        Me.Codigo.RegraValidaçãoMensagem = Nothing
        Me.Codigo.Size = New System.Drawing.Size(62, 23)
        Me.Codigo.TabIndex = 1
        Me.Codigo.Text = "0"
        Me.Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Codigo.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Numeros
        Me.Codigo.ValorPadrao = Nothing
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "C/C"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContaCorrente
        '
        Me.ContaCorrente.AceitaColarTexto = True
        Me.ContaCorrente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ContaCorrente.CasasDecimais = 0
        Me.ContaCorrente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContaCorrente.CPObrigatorio = False
        Me.ContaCorrente.CPObrigatorioMsg = Nothing
        Me.ContaCorrente.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ContaCorrente.FlatBorder = False
        Me.ContaCorrente.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ContaCorrente.FocusColor = System.Drawing.Color.MistyRose
        Me.ContaCorrente.FocusColorEnd = System.Drawing.Color.Empty
        Me.ContaCorrente.HighlightBorderOnEnter = False
        Me.ContaCorrente.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ContaCorrente.Location = New System.Drawing.Point(70, 40)
        Me.ContaCorrente.Name = "ContaCorrente"
        Me.ContaCorrente.PreencherZeroEsqueda = False
        Me.ContaCorrente.RegraValidação = Nothing
        Me.ContaCorrente.RegraValidaçãoMensagem = Nothing
        Me.ContaCorrente.Size = New System.Drawing.Size(103, 23)
        Me.ContaCorrente.TabIndex = 4
        Me.ContaCorrente.TabStop = False
        Me.ContaCorrente.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ContaCorrente.ValorPadrao = Nothing
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Agência"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Agencia
        '
        Me.Agencia.AceitaColarTexto = True
        Me.Agencia.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Agencia.CasasDecimais = 0
        Me.Agencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Agencia.CPObrigatorio = False
        Me.Agencia.CPObrigatorioMsg = Nothing
        Me.Agencia.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Agencia.FlatBorder = False
        Me.Agencia.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Agencia.FocusColor = System.Drawing.Color.MistyRose
        Me.Agencia.FocusColorEnd = System.Drawing.Color.Empty
        Me.Agencia.HighlightBorderOnEnter = False
        Me.Agencia.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Agencia.Location = New System.Drawing.Point(70, 67)
        Me.Agencia.Name = "Agencia"
        Me.Agencia.PreencherZeroEsqueda = False
        Me.Agencia.RegraValidação = Nothing
        Me.Agencia.RegraValidaçãoMensagem = Nothing
        Me.Agencia.Size = New System.Drawing.Size(103, 23)
        Me.Agencia.TabIndex = 6
        Me.Agencia.TabStop = False
        Me.Agencia.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Agencia.ValorPadrao = Nothing
        '
        'Banco
        '
        Me.Banco.AceitaColarTexto = True
        Me.Banco.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Banco.CasasDecimais = 0
        Me.Banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Banco.CPObrigatorio = False
        Me.Banco.CPObrigatorioMsg = Nothing
        Me.Banco.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Banco.FlatBorder = False
        Me.Banco.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Banco.FocusColor = System.Drawing.Color.MistyRose
        Me.Banco.FocusColorEnd = System.Drawing.Color.Empty
        Me.Banco.HighlightBorderOnEnter = False
        Me.Banco.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Banco.Location = New System.Drawing.Point(193, 67)
        Me.Banco.Name = "Banco"
        Me.Banco.PreencherZeroEsqueda = False
        Me.Banco.RegraValidação = Nothing
        Me.Banco.RegraValidaçãoMensagem = Nothing
        Me.Banco.Size = New System.Drawing.Size(281, 23)
        Me.Banco.TabIndex = 7
        Me.Banco.TabStop = False
        Me.Banco.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Banco.ValorPadrao = Nothing
        '
        'Fundo
        '
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Fundo.Controls.Add(Me.Panel3)
        Me.Fundo.Controls.Add(Me.Painel)
        Me.Fundo.Controls.Add(Me.Panel1)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(994, 616)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btChequePre)
        Me.Panel3.Controls.Add(Me.Fechar)
        Me.Panel3.Controls.Add(Me.Lançamentos)
        Me.Panel3.Controls.Add(Me.Compensar)
        Me.Panel3.Controls.Add(Me.Extrato)
        Me.Panel3.Controls.Add(Me.Localizar)
        Me.Panel3.Controls.Add(Me.BTCC)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 580)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(994, 36)
        Me.Panel3.TabIndex = 19
        '
        'btChequePre
        '
        Me.btChequePre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btChequePre.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btChequePre.Location = New System.Drawing.Point(442, 4)
        Me.btChequePre.Name = "btChequePre"
        Me.btChequePre.Size = New System.Drawing.Size(82, 27)
        Me.btChequePre.TabIndex = 17
        Me.btChequePre.Text = "Cheques-pré"
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Location = New System.Drawing.Point(2, 4)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(82, 27)
        Me.Fechar.TabIndex = 12
        Me.Fechar.Text = "Fechar"
        '
        'Lançamentos
        '
        Me.Lançamentos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Lançamentos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Lançamentos.Location = New System.Drawing.Point(90, 4)
        Me.Lançamentos.Name = "Lançamentos"
        Me.Lançamentos.Size = New System.Drawing.Size(82, 27)
        Me.Lançamentos.TabIndex = 11
        Me.Lançamentos.Text = "Lançamentos"
        '
        'Compensar
        '
        Me.Compensar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Compensar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Compensar.Location = New System.Drawing.Point(530, 4)
        Me.Compensar.Name = "Compensar"
        Me.Compensar.Size = New System.Drawing.Size(82, 27)
        Me.Compensar.TabIndex = 16
        Me.Compensar.Text = "Compensar"
        '
        'Extrato
        '
        Me.Extrato.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Extrato.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Extrato.Location = New System.Drawing.Point(354, 4)
        Me.Extrato.Name = "Extrato"
        Me.Extrato.Size = New System.Drawing.Size(82, 27)
        Me.Extrato.TabIndex = 15
        Me.Extrato.Text = "Extratos"
        '
        'Localizar
        '
        Me.Localizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Localizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Localizar.Location = New System.Drawing.Point(178, 4)
        Me.Localizar.Name = "Localizar"
        Me.Localizar.Size = New System.Drawing.Size(82, 27)
        Me.Localizar.TabIndex = 13
        Me.Localizar.Text = "Localizar"
        '
        'BTCC
        '
        Me.BTCC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTCC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTCC.Location = New System.Drawing.Point(266, 4)
        Me.BTCC.Name = "BTCC"
        Me.BTCC.Size = New System.Drawing.Size(82, 27)
        Me.BTCC.TabIndex = 14
        Me.BTCC.Text = "C/C"
        '
        'Painel
        '
        Me.Painel.Controls.Add(Me.DGLanc)
        Me.Painel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Painel.Location = New System.Drawing.Point(0, 99)
        Me.Painel.Name = "Painel"
        Me.Painel.Size = New System.Drawing.Size(994, 517)
        Me.Painel.TabIndex = 18
        '
        'DGLanc
        '
        Me.DGLanc.AllowUserToAddRows = False
        Me.DGLanc.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray
        Me.DGLanc.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGLanc.BackgroundColor = System.Drawing.Color.White
        Me.DGLanc.ColumnHeadersHeight = 20
        Me.DGLanc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataLancamento, Me.Id, Me.Documento, Me.Historico, Me.ValorDocumento, Me.CaiuBanco, Me.CC, Me.Ano, Me.cFavorecido})
        Me.DGLanc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGLanc.Location = New System.Drawing.Point(0, 0)
        Me.DGLanc.Name = "DGLanc"
        Me.DGLanc.ReadOnly = True
        Me.DGLanc.RowHeadersVisible = False
        Me.DGLanc.Size = New System.Drawing.Size(994, 517)
        Me.DGLanc.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Codigo)
        Me.Panel1.Controls.Add(Me.Banco)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Agencia)
        Me.Panel1.Controls.Add(Me.btFindCC)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ContaCorrente)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 99)
        Me.Panel1.TabIndex = 17
        '
        'btFindCC
        '
        Me.btFindCC.Image = CType(resources.GetObject("btFindCC.Image"), System.Drawing.Image)
        Me.btFindCC.Location = New System.Drawing.Point(134, 14)
        Me.btFindCC.Name = "btFindCC"
        Me.btFindCC.Size = New System.Drawing.Size(23, 23)
        Me.btFindCC.TabIndex = 2
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "C:\UpSistemas\Help\dblsistemas.chm"
        '
        'DataLancamento
        '
        Me.DataLancamento.DataPropertyName = "DataLancamento"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataLancamento.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataLancamento.HeaderText = "Data"
        Me.DataLancamento.Name = "DataLancamento"
        Me.DataLancamento.ReadOnly = True
        Me.DataLancamento.Width = 70
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        '
        'Documento
        '
        Me.Documento.DataPropertyName = "Documento"
        Me.Documento.HeaderText = "Documento"
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        Me.Documento.Width = 80
        '
        'Historico
        '
        Me.Historico.DataPropertyName = "Historico"
        Me.Historico.HeaderText = "Historico"
        Me.Historico.Name = "Historico"
        Me.Historico.ReadOnly = True
        Me.Historico.Width = 450
        '
        'ValorDocumento
        '
        Me.ValorDocumento.DataPropertyName = "ValorDocumento"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ValorDocumento.DefaultCellStyle = DataGridViewCellStyle3
        Me.ValorDocumento.HeaderText = "Valor Doc"
        Me.ValorDocumento.Name = "ValorDocumento"
        Me.ValorDocumento.ReadOnly = True
        Me.ValorDocumento.Width = 85
        '
        'CaiuBanco
        '
        Me.CaiuBanco.DataPropertyName = "CaiuBanco"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CaiuBanco.DefaultCellStyle = DataGridViewCellStyle4
        Me.CaiuBanco.HeaderText = "Comp."
        Me.CaiuBanco.Name = "CaiuBanco"
        Me.CaiuBanco.ReadOnly = True
        Me.CaiuBanco.Width = 40
        '
        'CC
        '
        Me.CC.DataPropertyName = "ContaCorrente"
        Me.CC.HeaderText = "CC"
        Me.CC.Name = "CC"
        Me.CC.ReadOnly = True
        Me.CC.Visible = False
        '
        'Ano
        '
        Me.Ano.DataPropertyName = "AnoAtual"
        Me.Ano.HeaderText = "Ano"
        Me.Ano.Name = "Ano"
        Me.Ano.ReadOnly = True
        Me.Ano.Visible = False
        Me.Ano.Width = 50
        '
        'cFavorecido
        '
        Me.cFavorecido.DataPropertyName = "Favorecido"
        Me.cFavorecido.HeaderText = "Favorecido"
        Me.cFavorecido.Name = "cFavorecido"
        Me.cFavorecido.ReadOnly = True
        Me.cFavorecido.Width = 250
        '
        'BancoVisualizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(994, 616)
        Me.Controls.Add(Me.Fundo)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!)
        Me.HelpProvider1.SetHelpKeyword(Me, "Conta Corrente")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimizeBox = False
        Me.Name = "BancoVisualizador"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conta Corrente - T102"
        Me.Fundo.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Painel.ResumeLayout(False)
        CType(Me.DGLanc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Codigo As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContaCorrente As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Agencia As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Banco As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Lançamentos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Localizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTCC As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Extrato As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Compensar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btFindCC As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Painel As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btChequePre As DevComponents.DotNetBar.ButtonX
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents DGLanc As System.Windows.Forms.DataGridView
    Friend WithEvents DataLancamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Historico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaiuBanco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ano As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFavorecido As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
