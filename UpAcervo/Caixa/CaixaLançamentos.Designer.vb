<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CaixaLançamentos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaixaLançamentos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataLancamento = New TexBoxFocusNet.TextBoxFocusNet()
        Me.LabelCliFor = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CliForDesc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.ContaCCDesc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Historico = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Valor = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DataDocumento = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Documento = New TexBoxFocusNet.TextBoxFocusNet()
        Me.ContaCC = New TexBoxFocusNet.TextBoxFocusNet()
        Me.CliFor = New TexBoxFocusNet.TextBoxFocusNet()
        Me.TravarDados = New System.Windows.Forms.CheckBox()
        Me.Id = New TexBoxFocusNet.TextBoxFocusNet()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btnCadastrar = New DevComponents.DotNetBar.ButtonX()
        Me.checkCliente = New DevComponents.DotNetBar.CheckBoxItem()
        Me.checkFornecedor = New DevComponents.DotNetBar.CheckBoxItem()
        Me.btFindCR = New System.Windows.Forms.Label()
        Me.ContaBalanceteDesc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.ContaBalancete = New TexBoxFocusNet.TextBoxFocusNet()
        Me.LabelReceitaDespesa = New System.Windows.Forms.Label()
        Me.btFindContaLanc = New System.Windows.Forms.Label()
        Me.btFindCliFor = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.A2 = New System.Windows.Forms.RadioButton()
        Me.A1 = New System.Windows.Forms.RadioButton()
        Me.btSalvar = New DevComponents.DotNetBar.ButtonX()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.PanelEx1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(25, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data Lançamento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataLancamento
        '
        Me.DataLancamento.AceitaColarTexto = True
        Me.DataLancamento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.DataLancamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataLancamento.CasasDecimais = 0
        Me.DataLancamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataLancamento.CPObrigatorio = False
        Me.DataLancamento.CPObrigatorioMsg = Nothing
        Me.DataLancamento.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataLancamento.FlatBorder = False
        Me.DataLancamento.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataLancamento.FocusColor = System.Drawing.Color.NavajoWhite
        Me.DataLancamento.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataLancamento.HighlightBorderOnEnter = False
        Me.DataLancamento.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataLancamento.Location = New System.Drawing.Point(171, 84)
        Me.DataLancamento.MaxLength = 10
        Me.DataLancamento.Name = "DataLancamento"
        Me.DataLancamento.PreencherZeroEsqueda = False
        Me.DataLancamento.RegraValidação = Nothing
        Me.DataLancamento.RegraValidaçãoMensagem = Nothing
        Me.DataLancamento.Size = New System.Drawing.Size(116, 23)
        Me.DataLancamento.TabIndex = 2
        Me.DataLancamento.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataLancamento.ValorPadrao = Nothing
        '
        'LabelCliFor
        '
        Me.LabelCliFor.BackColor = System.Drawing.Color.Transparent
        Me.LabelCliFor.ForeColor = System.Drawing.Color.Black
        Me.LabelCliFor.Location = New System.Drawing.Point(25, 115)
        Me.LabelCliFor.Name = "LabelCliFor"
        Me.LabelCliFor.Size = New System.Drawing.Size(139, 19)
        Me.LabelCliFor.TabIndex = 4
        Me.LabelCliFor.Text = "Cliente/Fornecedor"
        Me.LabelCliFor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(25, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Conta Centro Custo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CliForDesc
        '
        Me.CliForDesc.AceitaColarTexto = True
        Me.CliForDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.CliForDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CliForDesc.CasasDecimais = 0
        Me.CliForDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CliForDesc.CPObrigatorio = False
        Me.CliForDesc.CPObrigatorioMsg = Nothing
        Me.CliForDesc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.CliForDesc.FlatBorder = False
        Me.CliForDesc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.CliForDesc.FocusColor = System.Drawing.Color.NavajoWhite
        Me.CliForDesc.FocusColorEnd = System.Drawing.Color.Empty
        Me.CliForDesc.HighlightBorderOnEnter = False
        Me.CliForDesc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.CliForDesc.Location = New System.Drawing.Point(295, 115)
        Me.CliForDesc.Name = "CliForDesc"
        Me.CliForDesc.PreencherZeroEsqueda = False
        Me.CliForDesc.RegraValidação = Nothing
        Me.CliForDesc.RegraValidaçãoMensagem = Nothing
        Me.CliForDesc.Size = New System.Drawing.Size(303, 23)
        Me.CliForDesc.TabIndex = 7
        Me.CliForDesc.TabStop = False
        Me.CliForDesc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.CliForDesc.ValorPadrao = Nothing
        '
        'ContaCCDesc
        '
        Me.ContaCCDesc.AceitaColarTexto = True
        Me.ContaCCDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ContaCCDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContaCCDesc.CasasDecimais = 0
        Me.ContaCCDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContaCCDesc.CPObrigatorio = False
        Me.ContaCCDesc.CPObrigatorioMsg = Nothing
        Me.ContaCCDesc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ContaCCDesc.FlatBorder = False
        Me.ContaCCDesc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ContaCCDesc.FocusColor = System.Drawing.Color.NavajoWhite
        Me.ContaCCDesc.FocusColorEnd = System.Drawing.Color.Empty
        Me.ContaCCDesc.HighlightBorderOnEnter = False
        Me.ContaCCDesc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ContaCCDesc.Location = New System.Drawing.Point(295, 173)
        Me.ContaCCDesc.Name = "ContaCCDesc"
        Me.ContaCCDesc.PreencherZeroEsqueda = False
        Me.ContaCCDesc.RegraValidação = Nothing
        Me.ContaCCDesc.RegraValidaçãoMensagem = Nothing
        Me.ContaCCDesc.Size = New System.Drawing.Size(303, 23)
        Me.ContaCCDesc.TabIndex = 15
        Me.ContaCCDesc.TabStop = False
        Me.ContaCCDesc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ContaCCDesc.ValorPadrao = Nothing
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(25, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 19)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Histórico"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Historico
        '
        Me.Historico.AceitaColarTexto = True
        Me.Historico.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Historico.CasasDecimais = 0
        Me.Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Historico.CPObrigatorio = False
        Me.Historico.CPObrigatorioMsg = Nothing
        Me.Historico.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Historico.FlatBorder = False
        Me.Historico.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Historico.FocusColor = System.Drawing.Color.NavajoWhite
        Me.Historico.FocusColorEnd = System.Drawing.Color.Empty
        Me.Historico.HighlightBorderOnEnter = False
        Me.Historico.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Historico.Location = New System.Drawing.Point(171, 259)
        Me.Historico.MaxLength = 200
        Me.Historico.Multiline = True
        Me.Historico.Name = "Historico"
        Me.Historico.PreencherZeroEsqueda = False
        Me.Historico.RegraValidação = Nothing
        Me.Historico.RegraValidaçãoMensagem = Nothing
        Me.Historico.Size = New System.Drawing.Size(427, 63)
        Me.Historico.TabIndex = 23
        Me.Historico.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Historico.ValorPadrao = Nothing
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(25, 230)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 19)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Valor"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Valor
        '
        Me.Valor.AceitaColarTexto = True
        Me.Valor.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Valor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Valor.CasasDecimais = 2
        Me.Valor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Valor.CPObrigatorio = False
        Me.Valor.CPObrigatorioMsg = Nothing
        Me.Valor.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Valor.FlatBorder = False
        Me.Valor.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Valor.FocusColor = System.Drawing.Color.NavajoWhite
        Me.Valor.FocusColorEnd = System.Drawing.Color.Empty
        Me.Valor.HighlightBorderOnEnter = False
        Me.Valor.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Valor.Location = New System.Drawing.Point(171, 230)
        Me.Valor.MaxLength = 10
        Me.Valor.Name = "Valor"
        Me.Valor.PreencherZeroEsqueda = False
        Me.Valor.RegraValidação = Nothing
        Me.Valor.RegraValidaçãoMensagem = Nothing
        Me.Valor.Size = New System.Drawing.Size(116, 23)
        Me.Valor.TabIndex = 21
        Me.Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Valor.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.Valor.ValorPadrao = Nothing
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(336, 201)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 19)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Data do Documento"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataDocumento
        '
        Me.DataDocumento.AceitaColarTexto = True
        Me.DataDocumento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.DataDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataDocumento.CasasDecimais = 0
        Me.DataDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataDocumento.CPObrigatorio = False
        Me.DataDocumento.CPObrigatorioMsg = Nothing
        Me.DataDocumento.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataDocumento.FlatBorder = False
        Me.DataDocumento.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataDocumento.FocusColor = System.Drawing.Color.NavajoWhite
        Me.DataDocumento.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataDocumento.HighlightBorderOnEnter = False
        Me.DataDocumento.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataDocumento.Location = New System.Drawing.Point(485, 201)
        Me.DataDocumento.MaxLength = 10
        Me.DataDocumento.Name = "DataDocumento"
        Me.DataDocumento.PreencherZeroEsqueda = False
        Me.DataDocumento.RegraValidação = Nothing
        Me.DataDocumento.RegraValidaçãoMensagem = Nothing
        Me.DataDocumento.Size = New System.Drawing.Size(113, 23)
        Me.DataDocumento.TabIndex = 19
        Me.DataDocumento.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataDocumento.ValorPadrao = Nothing
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(25, 201)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 19)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Documento"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Documento
        '
        Me.Documento.AceitaColarTexto = True
        Me.Documento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Documento.CasasDecimais = 0
        Me.Documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Documento.CPObrigatorio = False
        Me.Documento.CPObrigatorioMsg = Nothing
        Me.Documento.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Documento.FlatBorder = False
        Me.Documento.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Documento.FocusColor = System.Drawing.Color.NavajoWhite
        Me.Documento.FocusColorEnd = System.Drawing.Color.Empty
        Me.Documento.HighlightBorderOnEnter = False
        Me.Documento.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Documento.Location = New System.Drawing.Point(171, 201)
        Me.Documento.MaxLength = 15
        Me.Documento.Name = "Documento"
        Me.Documento.PreencherZeroEsqueda = False
        Me.Documento.RegraValidação = Nothing
        Me.Documento.RegraValidaçãoMensagem = Nothing
        Me.Documento.Size = New System.Drawing.Size(116, 23)
        Me.Documento.TabIndex = 17
        Me.Documento.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Documento.ValorPadrao = Nothing
        '
        'ContaCC
        '
        Me.ContaCC.AceitaColarTexto = True
        Me.ContaCC.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.ContaCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContaCC.CasasDecimais = 0
        Me.ContaCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContaCC.CPObrigatorio = False
        Me.ContaCC.CPObrigatorioMsg = Nothing
        Me.ContaCC.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ContaCC.FlatBorder = False
        Me.ContaCC.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ContaCC.FocusColor = System.Drawing.Color.NavajoWhite
        Me.ContaCC.FocusColorEnd = System.Drawing.Color.Empty
        Me.ContaCC.HighlightBorderOnEnter = False
        Me.ContaCC.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ContaCC.Location = New System.Drawing.Point(171, 173)
        Me.ContaCC.MaxLength = 6
        Me.ContaCC.Name = "ContaCC"
        Me.ContaCC.PreencherZeroEsqueda = True
        Me.ContaCC.RegraValidação = Nothing
        Me.ContaCC.RegraValidaçãoMensagem = Nothing
        Me.ContaCC.Size = New System.Drawing.Size(97, 23)
        Me.ContaCC.TabIndex = 13
        Me.ContaCC.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ContaCC.ValorPadrao = Nothing
        '
        'CliFor
        '
        Me.CliFor.AceitaColarTexto = True
        Me.CliFor.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.CliFor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CliFor.CasasDecimais = 0
        Me.CliFor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CliFor.CPObrigatorio = False
        Me.CliFor.CPObrigatorioMsg = Nothing
        Me.CliFor.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.CliFor.FlatBorder = False
        Me.CliFor.FlatBorderColor = System.Drawing.Color.DimGray
        Me.CliFor.FocusColor = System.Drawing.Color.NavajoWhite
        Me.CliFor.FocusColorEnd = System.Drawing.Color.Empty
        Me.CliFor.HighlightBorderOnEnter = False
        Me.CliFor.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.CliFor.Location = New System.Drawing.Point(171, 115)
        Me.CliFor.MaxLength = 14
        Me.CliFor.Name = "CliFor"
        Me.CliFor.PreencherZeroEsqueda = False
        Me.CliFor.RegraValidação = Nothing
        Me.CliFor.RegraValidaçãoMensagem = Nothing
        Me.CliFor.Size = New System.Drawing.Size(97, 23)
        Me.CliFor.TabIndex = 5
        Me.CliFor.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.CliFor.ValorPadrao = Nothing
        '
        'TravarDados
        '
        Me.TravarDados.BackColor = System.Drawing.Color.Transparent
        Me.TravarDados.ForeColor = System.Drawing.Color.Black
        Me.TravarDados.Location = New System.Drawing.Point(25, 328)
        Me.TravarDados.Name = "TravarDados"
        Me.TravarDados.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TravarDados.Size = New System.Drawing.Size(157, 16)
        Me.TravarDados.TabIndex = 24
        Me.TravarDados.TabStop = False
        Me.TravarDados.Text = "Travar os Dados"
        Me.TravarDados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TravarDados.UseVisualStyleBackColor = False
        '
        'Id
        '
        Me.Id.AceitaColarTexto = True
        Me.Id.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Id.CasasDecimais = 0
        Me.Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Id.CPObrigatorio = False
        Me.Id.CPObrigatorioMsg = Nothing
        Me.Id.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Id.FlatBorder = False
        Me.Id.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Id.FocusColor = System.Drawing.Color.NavajoWhite
        Me.Id.FocusColorEnd = System.Drawing.Color.Empty
        Me.Id.HighlightBorderOnEnter = False
        Me.Id.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Id.Location = New System.Drawing.Point(485, 84)
        Me.Id.Name = "Id"
        Me.Id.PreencherZeroEsqueda = False
        Me.Id.RegraValidação = Nothing
        Me.Id.RegraValidaçãoMensagem = Nothing
        Me.Id.Size = New System.Drawing.Size(113, 23)
        Me.Id.TabIndex = 3
        Me.Id.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Id.ValorPadrao = Nothing
        Me.Id.Visible = False
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.PanelEx1.Controls.Add(Me.btnCadastrar)
        Me.PanelEx1.Controls.Add(Me.btFindCR)
        Me.PanelEx1.Controls.Add(Me.ContaBalanceteDesc)
        Me.PanelEx1.Controls.Add(Me.ContaBalancete)
        Me.PanelEx1.Controls.Add(Me.LabelReceitaDespesa)
        Me.PanelEx1.Controls.Add(Me.btFindContaLanc)
        Me.PanelEx1.Controls.Add(Me.btFindCliFor)
        Me.PanelEx1.Controls.Add(Me.GroupPanel1)
        Me.PanelEx1.Controls.Add(Me.btSalvar)
        Me.PanelEx1.Controls.Add(Me.btFechar)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.Controls.Add(Me.Id)
        Me.PanelEx1.Controls.Add(Me.ContaCCDesc)
        Me.PanelEx1.Controls.Add(Me.TravarDados)
        Me.PanelEx1.Controls.Add(Me.CliForDesc)
        Me.PanelEx1.Controls.Add(Me.DataLancamento)
        Me.PanelEx1.Controls.Add(Me.LabelCliFor)
        Me.PanelEx1.Controls.Add(Me.ContaCC)
        Me.PanelEx1.Controls.Add(Me.CliFor)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.Documento)
        Me.PanelEx1.Controls.Add(Me.Label7)
        Me.PanelEx1.Controls.Add(Me.Label10)
        Me.PanelEx1.Controls.Add(Me.Historico)
        Me.PanelEx1.Controls.Add(Me.DataDocumento)
        Me.PanelEx1.Controls.Add(Me.Label8)
        Me.PanelEx1.Controls.Add(Me.Label9)
        Me.PanelEx1.Controls.Add(Me.Valor)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(615, 388)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'btnCadastrar
        '
        Me.btnCadastrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCadastrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCadastrar.Location = New System.Drawing.Point(352, 343)
        Me.btnCadastrar.Name = "btnCadastrar"
        Me.btnCadastrar.Size = New System.Drawing.Size(88, 27)
        Me.btnCadastrar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.checkCliente, Me.checkFornecedor})
        Me.btnCadastrar.TabIndex = 28
        Me.btnCadastrar.Text = "Cadastrar"
        '
        'checkCliente
        '
        Me.checkCliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.checkCliente.GlobalItem = False
        Me.checkCliente.Name = "checkCliente"
        Me.checkCliente.Text = "Cliente"
        '
        'checkFornecedor
        '
        Me.checkFornecedor.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.checkFornecedor.GlobalItem = False
        Me.checkFornecedor.Name = "checkFornecedor"
        Me.checkFornecedor.Text = "Fornecedor"
        '
        'btFindCR
        '
        Me.btFindCR.Image = CType(resources.GetObject("btFindCR.Image"), System.Drawing.Image)
        Me.btFindCR.Location = New System.Drawing.Point(270, 144)
        Me.btFindCR.Name = "btFindCR"
        Me.btFindCR.Size = New System.Drawing.Size(23, 23)
        Me.btFindCR.TabIndex = 10
        '
        'ContaBalanceteDesc
        '
        Me.ContaBalanceteDesc.AceitaColarTexto = True
        Me.ContaBalanceteDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.ContaBalanceteDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContaBalanceteDesc.CasasDecimais = 0
        Me.ContaBalanceteDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContaBalanceteDesc.CPObrigatorio = False
        Me.ContaBalanceteDesc.CPObrigatorioMsg = Nothing
        Me.ContaBalanceteDesc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ContaBalanceteDesc.FlatBorder = False
        Me.ContaBalanceteDesc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ContaBalanceteDesc.FocusColor = System.Drawing.Color.NavajoWhite
        Me.ContaBalanceteDesc.FocusColorEnd = System.Drawing.Color.Empty
        Me.ContaBalanceteDesc.HighlightBorderOnEnter = False
        Me.ContaBalanceteDesc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ContaBalanceteDesc.Location = New System.Drawing.Point(295, 144)
        Me.ContaBalanceteDesc.Name = "ContaBalanceteDesc"
        Me.ContaBalanceteDesc.PreencherZeroEsqueda = False
        Me.ContaBalanceteDesc.RegraValidação = Nothing
        Me.ContaBalanceteDesc.RegraValidaçãoMensagem = Nothing
        Me.ContaBalanceteDesc.Size = New System.Drawing.Size(303, 23)
        Me.ContaBalanceteDesc.TabIndex = 11
        Me.ContaBalanceteDesc.TabStop = False
        Me.ContaBalanceteDesc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ContaBalanceteDesc.ValorPadrao = Nothing
        '
        'ContaBalancete
        '
        Me.ContaBalancete.AceitaColarTexto = True
        Me.ContaBalancete.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.ContaBalancete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContaBalancete.CasasDecimais = 0
        Me.ContaBalancete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContaBalancete.CPObrigatorio = False
        Me.ContaBalancete.CPObrigatorioMsg = Nothing
        Me.ContaBalancete.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ContaBalancete.FlatBorder = False
        Me.ContaBalancete.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ContaBalancete.FocusColor = System.Drawing.Color.NavajoWhite
        Me.ContaBalancete.FocusColorEnd = System.Drawing.Color.Empty
        Me.ContaBalancete.HighlightBorderOnEnter = False
        Me.ContaBalancete.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ContaBalancete.Location = New System.Drawing.Point(171, 144)
        Me.ContaBalancete.MaxLength = 6
        Me.ContaBalancete.Name = "ContaBalancete"
        Me.ContaBalancete.PreencherZeroEsqueda = True
        Me.ContaBalancete.RegraValidação = Nothing
        Me.ContaBalancete.RegraValidaçãoMensagem = Nothing
        Me.ContaBalancete.Size = New System.Drawing.Size(97, 23)
        Me.ContaBalancete.TabIndex = 9
        Me.ContaBalancete.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ContaBalancete.ValorPadrao = Nothing
        '
        'LabelReceitaDespesa
        '
        Me.LabelReceitaDespesa.BackColor = System.Drawing.Color.Transparent
        Me.LabelReceitaDespesa.ForeColor = System.Drawing.Color.Black
        Me.LabelReceitaDespesa.Location = New System.Drawing.Point(25, 144)
        Me.LabelReceitaDespesa.Name = "LabelReceitaDespesa"
        Me.LabelReceitaDespesa.Size = New System.Drawing.Size(139, 19)
        Me.LabelReceitaDespesa.TabIndex = 8
        Me.LabelReceitaDespesa.Text = "Conta Receita Despesas"
        Me.LabelReceitaDespesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btFindContaLanc
        '
        Me.btFindContaLanc.Image = CType(resources.GetObject("btFindContaLanc.Image"), System.Drawing.Image)
        Me.btFindContaLanc.Location = New System.Drawing.Point(270, 173)
        Me.btFindContaLanc.Name = "btFindContaLanc"
        Me.btFindContaLanc.Size = New System.Drawing.Size(23, 23)
        Me.btFindContaLanc.TabIndex = 14
        '
        'btFindCliFor
        '
        Me.btFindCliFor.Image = CType(resources.GetObject("btFindCliFor.Image"), System.Drawing.Image)
        Me.btFindCliFor.Location = New System.Drawing.Point(270, 115)
        Me.btFindCliFor.Name = "btFindCliFor"
        Me.btFindCliFor.Size = New System.Drawing.Size(23, 23)
        Me.btFindCliFor.TabIndex = 6
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.A2)
        Me.GroupPanel1.Controls.Add(Me.A1)
        Me.GroupPanel1.Location = New System.Drawing.Point(14, 11)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(587, 59)
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
        Me.GroupPanel1.Text = "Tipo de Lançamento no Caixa"
        '
        'A2
        '
        Me.A2.AutoSize = True
        Me.A2.Location = New System.Drawing.Point(201, 6)
        Me.A2.Name = "A2"
        Me.A2.Size = New System.Drawing.Size(137, 19)
        Me.A2.TabIndex = 1
        Me.A2.TabStop = True
        Me.A2.Text = "Lançamento de Débito"
        Me.A2.UseVisualStyleBackColor = True
        '
        'A1
        '
        Me.A1.AutoSize = True
        Me.A1.Location = New System.Drawing.Point(22, 6)
        Me.A1.Name = "A1"
        Me.A1.Size = New System.Drawing.Size(141, 19)
        Me.A1.TabIndex = 0
        Me.A1.TabStop = True
        Me.A1.Text = "Lançamento de Crédito"
        Me.A1.UseVisualStyleBackColor = True
        '
        'btSalvar
        '
        Me.btSalvar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btSalvar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btSalvar.Location = New System.Drawing.Point(456, 343)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(69, 27)
        Me.btSalvar.TabIndex = 25
        Me.btSalvar.Text = "Salvar"
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Location = New System.Drawing.Point(531, 343)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(70, 27)
        Me.btFechar.TabIndex = 26
        Me.btFechar.Text = "Fechar"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "C:\UpSistemas\Help\dblsistemas.chm"
        '
        'CaixaLançamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(615, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "CaixaLançamentos"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lançamentos no Caixa - T105"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataLancamento As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents LabelCliFor As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CliForDesc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents ContaCCDesc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Historico As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Valor As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataDocumento As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Documento As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents ContaCC As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents CliFor As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents TravarDados As System.Windows.Forms.CheckBox
    Friend WithEvents Id As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btSalvar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents A2 As System.Windows.Forms.RadioButton
    Friend WithEvents A1 As System.Windows.Forms.RadioButton
    Friend WithEvents btFindCliFor As System.Windows.Forms.Label
    Friend WithEvents btFindContaLanc As System.Windows.Forms.Label
    Friend WithEvents btFindCR As System.Windows.Forms.Label
    Friend WithEvents ContaBalanceteDesc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents ContaBalancete As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents LabelReceitaDespesa As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents btnCadastrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents checkCliente As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents checkFornecedor As DevComponents.DotNetBar.CheckBoxItem
End Class
