<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceberDecompor
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReceberDecompor))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.btn_gerar = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_id_linha = New TexBoxFocusNet.TextBoxFocusNet()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.Total = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Dgv = New System.Windows.Forms.DataGridView()
        Me.salvar = New DevComponents.DotNetBar.ButtonX()
        Me.txt_quantidade_parcela = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_valor_documento = New TexBoxFocusNet.TextBoxFocusNet()
        Me.LabelDocCheque = New System.Windows.Forms.Label()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.A = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.B = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_doc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Fundo.SuspendLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fundo
        '
        Me.Fundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Fundo.Controls.Add(Me.txt_doc)
        Me.Fundo.Controls.Add(Me.btn_gerar)
        Me.Fundo.Controls.Add(Me.Label1)
        Me.Fundo.Controls.Add(Me.txt_id_linha)
        Me.Fundo.Controls.Add(Me.LabelX1)
        Me.Fundo.Controls.Add(Me.btFechar)
        Me.Fundo.Controls.Add(Me.Total)
        Me.Fundo.Controls.Add(Me.Dgv)
        Me.Fundo.Controls.Add(Me.salvar)
        Me.Fundo.Controls.Add(Me.txt_quantidade_parcela)
        Me.Fundo.Controls.Add(Me.Label2)
        Me.Fundo.Controls.Add(Me.txt_valor_documento)
        Me.Fundo.Controls.Add(Me.LabelDocCheque)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(415, 283)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 1
        '
        'btn_gerar
        '
        Me.btn_gerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_gerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_gerar.Image = Global.UpAcervo.My.Resources.Resources.BeOS_write
        Me.btn_gerar.Location = New System.Drawing.Point(183, 42)
        Me.btn_gerar.Name = "btn_gerar"
        Me.btn_gerar.Size = New System.Drawing.Size(71, 23)
        Me.btn_gerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn_gerar.TabIndex = 39
        Me.btn_gerar.Text = "Gerar"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(294, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 19)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_id_linha
        '
        Me.txt_id_linha.AceitaColarTexto = True
        Me.txt_id_linha.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txt_id_linha.CasasDecimais = 0
        Me.txt_id_linha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_id_linha.CPObrigatorio = False
        Me.txt_id_linha.CPObrigatorioMsg = Nothing
        Me.txt_id_linha.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txt_id_linha.FlatBorder = False
        Me.txt_id_linha.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txt_id_linha.FocusColor = System.Drawing.Color.Empty
        Me.txt_id_linha.FocusColorEnd = System.Drawing.Color.Empty
        Me.txt_id_linha.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_linha.HighlightBorderOnEnter = False
        Me.txt_id_linha.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txt_id_linha.Location = New System.Drawing.Point(331, 13)
        Me.txt_id_linha.Name = "txt_id_linha"
        Me.txt_id_linha.PreencherZeroEsqueda = False
        Me.txt_id_linha.ReadOnly = True
        Me.txt_id_linha.RegraValidação = Nothing
        Me.txt_id_linha.RegraValidaçãoMensagem = Nothing
        Me.txt_id_linha.Size = New System.Drawing.Size(72, 23)
        Me.txt_id_linha.TabIndex = 37
        Me.txt_id_linha.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txt_id_linha.ValorPadrao = Nothing
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelX1.Location = New System.Drawing.Point(17, 345)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(103, 23)
        Me.LabelX1.TabIndex = 36
        Me.LabelX1.Text = "Total Documento"
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Image = CType(resources.GetObject("btFechar.Image"), System.Drawing.Image)
        Me.btFechar.Location = New System.Drawing.Point(206, 233)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(96, 36)
        Me.btFechar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btFechar.TabIndex = 35
        Me.btFechar.Text = "Fechar"
        '
        'Total
        '
        Me.Total.AceitaColarTexto = True
        Me.Total.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Sim
        Me.Total.CasasDecimais = 2
        Me.Total.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Total.CPObrigatorio = False
        Me.Total.CPObrigatorioMsg = Nothing
        Me.Total.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Total.FlatBorder = False
        Me.Total.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Total.FocusColor = System.Drawing.Color.Empty
        Me.Total.FocusColorEnd = System.Drawing.Color.Empty
        Me.Total.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.HighlightBorderOnEnter = False
        Me.Total.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Total.Location = New System.Drawing.Point(126, 345)
        Me.Total.MaxLength = 10
        Me.Total.Name = "Total"
        Me.Total.PreencherZeroEsqueda = False
        Me.Total.RegraValidação = Nothing
        Me.Total.RegraValidaçãoMensagem = Nothing
        Me.Total.Size = New System.Drawing.Size(119, 23)
        Me.Total.TabIndex = 33
        Me.Total.TabStop = False
        Me.Total.Text = "0,00"
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Total.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Moeda
        Me.Total.ValorPadrao = "0,00"
        '
        'Dgv
        '
        Me.Dgv.AllowUserToAddRows = False
        Me.Dgv.AllowUserToDeleteRows = False
        Me.Dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.A, Me.Column3, Me.B})
        Me.Dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Dgv.Location = New System.Drawing.Point(13, 83)
        Me.Dgv.Name = "Dgv"
        Me.Dgv.RowHeadersWidth = 25
        Me.Dgv.ShowEditingIcon = False
        Me.Dgv.Size = New System.Drawing.Size(392, 144)
        Me.Dgv.TabIndex = 32
        '
        'salvar
        '
        Me.salvar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.salvar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.salvar.Image = CType(resources.GetObject("salvar.Image"), System.Drawing.Image)
        Me.salvar.Location = New System.Drawing.Point(309, 233)
        Me.salvar.Name = "salvar"
        Me.salvar.Size = New System.Drawing.Size(96, 36)
        Me.salvar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.salvar.TabIndex = 34
        Me.salvar.Text = "Salvar"
        '
        'txt_quantidade_parcela
        '
        Me.txt_quantidade_parcela.AceitaColarTexto = True
        Me.txt_quantidade_parcela.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txt_quantidade_parcela.CasasDecimais = 0
        Me.txt_quantidade_parcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_quantidade_parcela.CPObrigatorio = False
        Me.txt_quantidade_parcela.CPObrigatorioMsg = Nothing
        Me.txt_quantidade_parcela.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txt_quantidade_parcela.FlatBorder = False
        Me.txt_quantidade_parcela.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txt_quantidade_parcela.FocusColor = System.Drawing.Color.Empty
        Me.txt_quantidade_parcela.FocusColorEnd = System.Drawing.Color.Empty
        Me.txt_quantidade_parcela.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_quantidade_parcela.HighlightBorderOnEnter = False
        Me.txt_quantidade_parcela.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txt_quantidade_parcela.Location = New System.Drawing.Point(126, 42)
        Me.txt_quantidade_parcela.MaxLength = 15
        Me.txt_quantidade_parcela.Name = "txt_quantidade_parcela"
        Me.txt_quantidade_parcela.PreencherZeroEsqueda = False
        Me.txt_quantidade_parcela.RegraValidação = Nothing
        Me.txt_quantidade_parcela.RegraValidaçãoMensagem = Nothing
        Me.txt_quantidade_parcela.Size = New System.Drawing.Size(50, 23)
        Me.txt_quantidade_parcela.TabIndex = 27
        Me.txt_quantidade_parcela.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
        Me.txt_quantidade_parcela.ValorPadrao = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 19)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Qtd Parc."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_valor_documento
        '
        Me.txt_valor_documento.AceitaColarTexto = True
        Me.txt_valor_documento.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txt_valor_documento.CasasDecimais = 0
        Me.txt_valor_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_valor_documento.CPObrigatorio = False
        Me.txt_valor_documento.CPObrigatorioMsg = Nothing
        Me.txt_valor_documento.Enabled = False
        Me.txt_valor_documento.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txt_valor_documento.FlatBorder = False
        Me.txt_valor_documento.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txt_valor_documento.FocusColor = System.Drawing.Color.Empty
        Me.txt_valor_documento.FocusColorEnd = System.Drawing.Color.Empty
        Me.txt_valor_documento.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valor_documento.HighlightBorderOnEnter = False
        Me.txt_valor_documento.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txt_valor_documento.Location = New System.Drawing.Point(126, 13)
        Me.txt_valor_documento.Name = "txt_valor_documento"
        Me.txt_valor_documento.PreencherZeroEsqueda = False
        Me.txt_valor_documento.RegraValidação = Nothing
        Me.txt_valor_documento.RegraValidaçãoMensagem = Nothing
        Me.txt_valor_documento.Size = New System.Drawing.Size(131, 23)
        Me.txt_valor_documento.TabIndex = 23
        Me.txt_valor_documento.TabStop = False
        Me.txt_valor_documento.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txt_valor_documento.ValorPadrao = Nothing
        '
        'LabelDocCheque
        '
        Me.LabelDocCheque.BackColor = System.Drawing.Color.Transparent
        Me.LabelDocCheque.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDocCheque.Location = New System.Drawing.Point(12, 13)
        Me.LabelDocCheque.Name = "LabelDocCheque"
        Me.LabelDocCheque.Size = New System.Drawing.Size(108, 19)
        Me.LabelDocCheque.TabIndex = 22
        Me.LabelDocCheque.Text = "Valor Documento"
        Me.LabelDocCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "parcela"
        Me.Column1.HeaderText = "Doc"
        Me.Column1.Name = "Column1"
        '
        'A
        '
        Me.A.DataPropertyName = "A"
        Me.A.HeaderText = "Column2"
        Me.A.Name = "A"
        Me.A.Visible = False
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "valor"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Valor"
        Me.Column3.Name = "Column3"
        '
        'B
        '
        Me.B.DataPropertyName = "B"
        Me.B.HeaderText = "Column4"
        Me.B.Name = "B"
        Me.B.Visible = False
        '
        'txt_doc
        '
        Me.txt_doc.AceitaColarTexto = True
        Me.txt_doc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txt_doc.CasasDecimais = 0
        Me.txt_doc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_doc.CPObrigatorio = False
        Me.txt_doc.CPObrigatorioMsg = Nothing
        Me.txt_doc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txt_doc.FlatBorder = False
        Me.txt_doc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txt_doc.FocusColor = System.Drawing.Color.Empty
        Me.txt_doc.FocusColorEnd = System.Drawing.Color.Empty
        Me.txt_doc.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_doc.HighlightBorderOnEnter = False
        Me.txt_doc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txt_doc.Location = New System.Drawing.Point(331, 39)
        Me.txt_doc.Name = "txt_doc"
        Me.txt_doc.PreencherZeroEsqueda = False
        Me.txt_doc.ReadOnly = True
        Me.txt_doc.RegraValidação = Nothing
        Me.txt_doc.RegraValidaçãoMensagem = Nothing
        Me.txt_doc.Size = New System.Drawing.Size(72, 23)
        Me.txt_doc.TabIndex = 40
        Me.txt_doc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txt_doc.ValorPadrao = Nothing
        Me.txt_doc.Visible = False
        '
        'ReceberDecompor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 283)
        Me.Controls.Add(Me.Fundo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReceberDecompor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receber Decompor"
        Me.Fundo.ResumeLayout(False)
        Me.Fundo.PerformLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents txt_quantidade_parcela As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_valor_documento As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents LabelDocCheque As Label
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Total As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Dgv As DataGridView
    Friend WithEvents salvar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_id_linha As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents btn_gerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents A As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents B As DataGridViewTextBoxColumn
    Friend WithEvents txt_doc As TexBoxFocusNet.TextBoxFocusNet
End Class
