<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProdutoGerarEtiqueta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProdutoGerarEtiqueta))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.PainelProduto = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblInfProduto = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Produto = New TexBoxFocusNet.TextBoxFocusNet()
        Me.btImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.butGerar = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQtd = New TexBoxFocusNet.TextBoxFocusNet()
        Me.PanelEx1.SuspendLayout()
        Me.PainelProduto.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.PanelEx1.Controls.Add(Me.PainelProduto)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(475, 226)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'PainelProduto
        '
        Me.PainelProduto.Controls.Add(Me.PictureBox1)
        Me.PainelProduto.Controls.Add(Me.lblInfProduto)
        Me.PainelProduto.Controls.Add(Me.Label2)
        Me.PainelProduto.Controls.Add(Me.Produto)
        Me.PainelProduto.Controls.Add(Me.btImprimir)
        Me.PainelProduto.Controls.Add(Me.btFechar)
        Me.PainelProduto.Controls.Add(Me.butGerar)
        Me.PainelProduto.Controls.Add(Me.Label1)
        Me.PainelProduto.Controls.Add(Me.txtQtd)
        Me.PainelProduto.Location = New System.Drawing.Point(3, 3)
        Me.PainelProduto.Name = "PainelProduto"
        Me.PainelProduto.Size = New System.Drawing.Size(469, 218)
        Me.PainelProduto.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(264, 44)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(196, 168)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'lblInfProduto
        '
        Me.lblInfProduto.BackColor = System.Drawing.Color.White
        Me.lblInfProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfProduto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfProduto.Location = New System.Drawing.Point(3, 6)
        Me.lblInfProduto.Name = "lblInfProduto"
        Me.lblInfProduto.Size = New System.Drawing.Size(457, 35)
        Me.lblInfProduto.TabIndex = 5
        Me.lblInfProduto.Text = "Informação do Produto"
        Me.lblInfProduto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Informe o Produto"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Produto
        '
        Me.Produto.AceitaColarTexto = True
        Me.Produto.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.Produto.CasasDecimais = 0
        Me.Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Produto.CPObrigatorio = False
        Me.Produto.CPObrigatorioMsg = Nothing
        Me.Produto.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.Produto.FlatBorder = False
        Me.Produto.FlatBorderColor = System.Drawing.Color.DimGray
        Me.Produto.FocusColor = System.Drawing.Color.Empty
        Me.Produto.FocusColorEnd = System.Drawing.Color.Empty
        Me.Produto.HighlightBorderOnEnter = False
        Me.Produto.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.Produto.Location = New System.Drawing.Point(141, 56)
        Me.Produto.Name = "Produto"
        Me.Produto.PreencherZeroEsqueda = False
        Me.Produto.RegraValidação = Nothing
        Me.Produto.RegraValidaçãoMensagem = Nothing
        Me.Produto.Size = New System.Drawing.Size(116, 20)
        Me.Produto.TabIndex = 0
        Me.Produto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Produto.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.Produto.ValorPadrao = Nothing
        '
        'btImprimir
        '
        Me.btImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btImprimir.Location = New System.Drawing.Point(101, 145)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btImprimir.TabIndex = 8
        Me.btImprimir.Text = "Imprimir"
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Location = New System.Drawing.Point(182, 145)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(75, 23)
        Me.btFechar.TabIndex = 9
        Me.btFechar.Text = "Fechar"
        '
        'butGerar
        '
        Me.butGerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.butGerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.butGerar.Location = New System.Drawing.Point(141, 105)
        Me.butGerar.Name = "butGerar"
        Me.butGerar.Size = New System.Drawing.Size(116, 23)
        Me.butGerar.TabIndex = 3
        Me.butGerar.Text = "Gerar"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Informe a Qtd de Etiqueta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQtd
        '
        Me.txtQtd.AceitaColarTexto = True
        Me.txtQtd.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtQtd.CasasDecimais = 0
        Me.txtQtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQtd.CPObrigatorio = False
        Me.txtQtd.CPObrigatorioMsg = Nothing
        Me.txtQtd.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtQtd.FlatBorder = False
        Me.txtQtd.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtQtd.FocusColor = System.Drawing.Color.Empty
        Me.txtQtd.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtQtd.HighlightBorderOnEnter = False
        Me.txtQtd.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtQtd.Location = New System.Drawing.Point(141, 79)
        Me.txtQtd.MaxLength = 15
        Me.txtQtd.Name = "txtQtd"
        Me.txtQtd.PreencherZeroEsqueda = False
        Me.txtQtd.RegraValidação = Nothing
        Me.txtQtd.RegraValidaçãoMensagem = Nothing
        Me.txtQtd.Size = New System.Drawing.Size(116, 20)
        Me.txtQtd.TabIndex = 2
        Me.txtQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtQtd.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Numeros
        Me.txtQtd.ValorPadrao = Nothing
        '
        'ProdutoGerarEtiqueta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 226)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ProdutoGerarEtiqueta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gerar Etiqueta - T030"
        Me.PanelEx1.ResumeLayout(False)
        Me.PainelProduto.ResumeLayout(False)
        Me.PainelProduto.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PainelProduto As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Produto As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQtd As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents btImprimir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents butGerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblInfProduto As System.Windows.Forms.Label
End Class
