<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NFeFaturas
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.ValorGerado = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NFeValor = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ListaReceber = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ChaveAcesso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnDup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cdVenc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cvDup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuDuplicata = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExcluitDuplicataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PainelParcelas = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Parcela = New TexBoxFocusNet.TextBoxFocusNet()
        Me.dVenc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.btSalvar = New DevComponents.DotNetBar.ButtonX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.vDup = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nNF = New TexBoxFocusNet.TextBoxFocusNet()
        Me.APrazo = New System.Windows.Forms.RadioButton()
        Me.Avista = New System.Windows.Forms.RadioButton()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.Fundo.SuspendLayout()
        CType(Me.ListaReceber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuDuplicata.SuspendLayout()
        Me.PainelParcelas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fundo
        '
        Me.Fundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Fundo.Controls.Add(Me.ValorGerado)
        Me.Fundo.Controls.Add(Me.Label7)
        Me.Fundo.Controls.Add(Me.NFeValor)
        Me.Fundo.Controls.Add(Me.Label5)
        Me.Fundo.Controls.Add(Me.ListaReceber)
        Me.Fundo.Controls.Add(Me.PainelParcelas)
        Me.Fundo.Controls.Add(Me.APrazo)
        Me.Fundo.Controls.Add(Me.Avista)
        Me.Fundo.Controls.Add(Me.btFechar)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(475, 310)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'ValorGerado
        '
        Me.ValorGerado.ForeColor = System.Drawing.Color.Navy
        Me.ValorGerado.Location = New System.Drawing.Point(95, 288)
        Me.ValorGerado.Name = "ValorGerado"
        Me.ValorGerado.Size = New System.Drawing.Size(99, 21)
        Me.ValorGerado.TabIndex = 9
        Me.ValorGerado.Text = "00,00"
        Me.ValorGerado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 21)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Valor Gerado:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NFeValor
        '
        Me.NFeValor.ForeColor = System.Drawing.Color.Navy
        Me.NFeValor.Location = New System.Drawing.Point(95, 267)
        Me.NFeValor.Name = "NFeValor"
        Me.NFeValor.Size = New System.Drawing.Size(99, 21)
        Me.NFeValor.TabIndex = 7
        Me.NFeValor.Text = "00,00"
        Me.NFeValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 267)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 21)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Valor da NFe:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListaReceber
        '
        Me.ListaReceber.AllowUserToAddRows = False
        Me.ListaReceber.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.ListaReceber.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ListaReceber.BackgroundColor = System.Drawing.Color.White
        Me.ListaReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListaReceber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChaveAcesso, Me.cnDup, Me.cdVenc, Me.cvDup})
        Me.ListaReceber.ContextMenuStrip = Me.MenuDuplicata
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(129, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(129, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListaReceber.DefaultCellStyle = DataGridViewCellStyle3
        Me.ListaReceber.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.ListaReceber.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ListaReceber.Location = New System.Drawing.Point(12, 102)
        Me.ListaReceber.Name = "ListaReceber"
        Me.ListaReceber.RowHeadersWidth = 20
        Me.ListaReceber.SelectAllSignVisible = False
        Me.ListaReceber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListaReceber.Size = New System.Drawing.Size(451, 162)
        Me.ListaReceber.TabIndex = 3
        '
        'ChaveAcesso
        '
        Me.ChaveAcesso.DataPropertyName = "ChaveAcesso"
        Me.ChaveAcesso.HeaderText = "Chave"
        Me.ChaveAcesso.Name = "ChaveAcesso"
        Me.ChaveAcesso.Visible = False
        '
        'cnDup
        '
        Me.cnDup.DataPropertyName = "nDup"
        Me.cnDup.HeaderText = "Documento"
        Me.cnDup.Name = "cnDup"
        Me.cnDup.Width = 120
        '
        'cdVenc
        '
        Me.cdVenc.DataPropertyName = "dVenc"
        Me.cdVenc.HeaderText = "Vencimento"
        Me.cdVenc.Name = "cdVenc"
        Me.cdVenc.Width = 120
        '
        'cvDup
        '
        Me.cvDup.DataPropertyName = "vDup"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.cvDup.DefaultCellStyle = DataGridViewCellStyle2
        Me.cvDup.HeaderText = "Valor"
        Me.cvDup.Name = "cvDup"
        Me.cvDup.Width = 150
        '
        'MenuDuplicata
        '
        Me.MenuDuplicata.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcluitDuplicataToolStripMenuItem})
        Me.MenuDuplicata.Name = "MenuDuplicata"
        Me.MenuDuplicata.Size = New System.Drawing.Size(162, 26)
        '
        'ExcluitDuplicataToolStripMenuItem
        '
        Me.ExcluitDuplicataToolStripMenuItem.Name = "ExcluitDuplicataToolStripMenuItem"
        Me.ExcluitDuplicataToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ExcluitDuplicataToolStripMenuItem.Text = "Excluir Duplicata"
        '
        'PainelParcelas
        '
        Me.PainelParcelas.Controls.Add(Me.Label4)
        Me.PainelParcelas.Controls.Add(Me.Parcela)
        Me.PainelParcelas.Controls.Add(Me.dVenc)
        Me.PainelParcelas.Controls.Add(Me.btSalvar)
        Me.PainelParcelas.Controls.Add(Me.Label2)
        Me.PainelParcelas.Controls.Add(Me.vDup)
        Me.PainelParcelas.Controls.Add(Me.Label1)
        Me.PainelParcelas.Controls.Add(Me.Label3)
        Me.PainelParcelas.Controls.Add(Me.nNF)
        Me.PainelParcelas.Location = New System.Drawing.Point(12, 35)
        Me.PainelParcelas.Name = "PainelParcelas"
        Me.PainelParcelas.Size = New System.Drawing.Size(451, 61)
        Me.PainelParcelas.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(122, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Parcela"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Parcela
        '
        Me.Parcela.AceitaColarTexto = True
        Me.Parcela.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Parcela.CasasDecimais = 2
        Me.Parcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Parcela.CPObrigatorio = True
        Me.Parcela.CPObrigatorioMsg = "O usuário deve informar o tipo de Documento"
        Me.Parcela.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Parcela.FlatBorder = False
        Me.Parcela.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Parcela.FocusColor = System.Drawing.Color.Empty
        Me.Parcela.FocusColorEnd = System.Drawing.Color.Empty
        Me.Parcela.HighlightBorderOnEnter = False
        Me.Parcela.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Parcela.Location = New System.Drawing.Point(122, 32)
        Me.Parcela.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Parcela.MaxLength = 15
        Me.Parcela.Name = "Parcela"
        Me.Parcela.PreencherZeroEsqueda = False
        Me.Parcela.RegraValidação = "1;2;3;4;5;6"
        Me.Parcela.RegraValidaçãoMensagem = "Parcelas podem ser numeros inteiro de 1 a 6"
        Me.Parcela.Size = New System.Drawing.Size(45, 21)
        Me.Parcela.TabIndex = 5
        Me.Parcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Parcela.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Parcela.ValorPadrao = Nothing
        '
        'dVenc
        '
        Me.dVenc.AceitaColarTexto = True
        Me.dVenc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.dVenc.CasasDecimais = 2
        Me.dVenc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dVenc.CPObrigatorio = True
        Me.dVenc.CPObrigatorioMsg = "O usuário deve informar o tipo de Documento"
        Me.dVenc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.dVenc.FlatBorder = False
        Me.dVenc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.dVenc.FocusColor = System.Drawing.Color.Empty
        Me.dVenc.FocusColorEnd = System.Drawing.Color.Empty
        Me.dVenc.HighlightBorderOnEnter = False
        Me.dVenc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.dVenc.Location = New System.Drawing.Point(173, 32)
        Me.dVenc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dVenc.MaxLength = 10
        Me.dVenc.Name = "dVenc"
        Me.dVenc.PreencherZeroEsqueda = False
        Me.dVenc.RegraValidação = ""
        Me.dVenc.RegraValidaçãoMensagem = ""
        Me.dVenc.Size = New System.Drawing.Size(80, 21)
        Me.dVenc.TabIndex = 6
        Me.dVenc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dVenc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.dVenc.ValorPadrao = Nothing
        '
        'btSalvar
        '
        Me.btSalvar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btSalvar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btSalvar.Location = New System.Drawing.Point(367, 30)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btSalvar.TabIndex = 8
        Me.btSalvar.Text = "Salvar"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(173, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vencimento"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'vDup
        '
        Me.vDup.AceitaColarTexto = True
        Me.vDup.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.vDup.CasasDecimais = 2
        Me.vDup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.vDup.CPObrigatorio = True
        Me.vDup.CPObrigatorioMsg = "O usuário deve informar o tipo de Documento"
        Me.vDup.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.vDup.FlatBorder = False
        Me.vDup.FlatBorderColor = System.Drawing.Color.DimGray
        Me.vDup.FocusColor = System.Drawing.Color.Empty
        Me.vDup.FocusColorEnd = System.Drawing.Color.Empty
        Me.vDup.HighlightBorderOnEnter = False
        Me.vDup.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.vDup.Location = New System.Drawing.Point(259, 32)
        Me.vDup.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.vDup.MaxLength = 15
        Me.vDup.Name = "vDup"
        Me.vDup.PreencherZeroEsqueda = False
        Me.vDup.RegraValidação = ""
        Me.vDup.RegraValidaçãoMensagem = ""
        Me.vDup.Size = New System.Drawing.Size(102, 21)
        Me.vDup.TabIndex = 7
        Me.vDup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.vDup.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Numeros
        Me.vDup.ValorPadrao = Nothing
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NF"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(259, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 21)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Valor"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nNF
        '
        Me.nNF.AceitaColarTexto = True
        Me.nNF.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.nNF.CasasDecimais = 2
        Me.nNF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nNF.CPObrigatorio = True
        Me.nNF.CPObrigatorioMsg = "O usuário deve informar o tipo de Documento"
        Me.nNF.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.nNF.FlatBorder = False
        Me.nNF.FlatBorderColor = System.Drawing.Color.DimGray
        Me.nNF.FocusColor = System.Drawing.Color.Empty
        Me.nNF.FocusColorEnd = System.Drawing.Color.Empty
        Me.nNF.HighlightBorderOnEnter = False
        Me.nNF.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.nNF.Location = New System.Drawing.Point(8, 32)
        Me.nNF.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.nNF.MaxLength = 15
        Me.nNF.Name = "nNF"
        Me.nNF.PreencherZeroEsqueda = False
        Me.nNF.RegraValidação = ""
        Me.nNF.RegraValidaçãoMensagem = ""
        Me.nNF.Size = New System.Drawing.Size(108, 21)
        Me.nNF.TabIndex = 4
        Me.nNF.TabStop = False
        Me.nNF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nNF.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.nNF.ValorPadrao = Nothing
        '
        'APrazo
        '
        Me.APrazo.AutoSize = True
        Me.APrazo.Location = New System.Drawing.Point(76, 12)
        Me.APrazo.Name = "APrazo"
        Me.APrazo.Size = New System.Drawing.Size(62, 17)
        Me.APrazo.TabIndex = 1
        Me.APrazo.TabStop = True
        Me.APrazo.Text = "A Prazo"
        Me.APrazo.UseVisualStyleBackColor = True
        '
        'Avista
        '
        Me.Avista.AutoSize = True
        Me.Avista.Location = New System.Drawing.Point(12, 12)
        Me.Avista.Name = "Avista"
        Me.Avista.Size = New System.Drawing.Size(58, 17)
        Me.Avista.TabIndex = 0
        Me.Avista.TabStop = True
        Me.Avista.Text = "A Vista"
        Me.Avista.UseVisualStyleBackColor = True
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Enabled = False
        Me.btFechar.Location = New System.Drawing.Point(388, 282)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(75, 23)
        Me.btFechar.TabIndex = 5
        Me.btFechar.Text = "Fechar"
        '
        'NFeFaturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.Fundo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NFeFaturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NFeFaturas"
        Me.TopMost = True
        Me.Fundo.ResumeLayout(False)
        Me.Fundo.PerformLayout()
        CType(Me.ListaReceber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuDuplicata.ResumeLayout(False)
        Me.PainelParcelas.ResumeLayout(False)
        Me.PainelParcelas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btSalvar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents nNF As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents vDup As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents dVenc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PainelParcelas As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Parcela As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents APrazo As System.Windows.Forms.RadioButton
    Friend WithEvents Avista As System.Windows.Forms.RadioButton
    Friend WithEvents ListaReceber As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents NFeValor As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChaveAcesso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnDup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cdVenc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cvDup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorGerado As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MenuDuplicata As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExcluitDuplicataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
