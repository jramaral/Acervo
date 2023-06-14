<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IniciarOrcamento
    Inherits DevComponents.DotNetBar.Office2007Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IniciarOrcamento))
        Me.Wizard1 = New DevComponents.DotNetBar.Wizard()
        Me.pagEscolher = New DevComponents.DotNetBar.WizardPage()
        Me.opt_sem_cadastro = New System.Windows.Forms.RadioButton()
        Me.opt_com_cadastro = New System.Windows.Forms.RadioButton()
        Me.pagDadosCliente = New DevComponents.DotNetBar.WizardPage()
        Me.txtID = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCidade = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtTelefone = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtNomeCliente = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Check1 = New System.Windows.Forms.CheckBox()
        Me.Wizard1.SuspendLayout
        Me.pagEscolher.SuspendLayout
        Me.pagDadosCliente.SuspendLayout
        Me.SuspendLayout
        '
        'Wizard1
        '
        Me.Wizard1.BackButtonText = "< Voltar"
        Me.Wizard1.BackColor = System.Drawing.Color.FromArgb(CType(CType(205,Byte),Integer), CType(CType(229,Byte),Integer), CType(CType(253,Byte),Integer))
        Me.Wizard1.BackgroundImage = CType(resources.GetObject("Wizard1.BackgroundImage"),System.Drawing.Image)
        Me.Wizard1.ButtonHeight = 30
        Me.Wizard1.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007
        Me.Wizard1.CancelButtonText = "Cancelar"
        Me.Wizard1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Wizard1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Wizard1.FinishButtonTabIndex = 3
        Me.Wizard1.FinishButtonText = "Finalizar"
        '
        '
        '
        Me.Wizard1.FooterStyle.BackColor = System.Drawing.Color.Transparent
        Me.Wizard1.FooterStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Wizard1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15,Byte),Integer), CType(CType(57,Byte),Integer), CType(CType(129,Byte),Integer))
        Me.Wizard1.HeaderCaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold)
        Me.Wizard1.HeaderDescriptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Wizard1.HeaderDescriptionIndent = 62
        Me.Wizard1.HeaderHeight = 90
        Me.Wizard1.HeaderImageAlignment = DevComponents.DotNetBar.eWizardTitleImageAlignment.Left
        '
        '
        '
        Me.Wizard1.HeaderStyle.BackColor = System.Drawing.Color.Transparent
        Me.Wizard1.HeaderStyle.BackColorGradientAngle = 90
        Me.Wizard1.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Wizard1.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(121,Byte),Integer), CType(CType(157,Byte),Integer), CType(CType(182,Byte),Integer))
        Me.Wizard1.HeaderStyle.BorderBottomWidth = 1
        Me.Wizard1.HeaderStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Wizard1.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Wizard1.HeaderTitleIndent = 62
        Me.Wizard1.HelpButtonVisible = false
        Me.Wizard1.Location = New System.Drawing.Point(0, 0)
        Me.Wizard1.Name = "Wizard1"
        Me.Wizard1.NextButtonText = "Avançar >"
        Me.Wizard1.Size = New System.Drawing.Size(624, 190)
        Me.Wizard1.TabIndex = 0
        Me.Wizard1.WizardPages.AddRange(New DevComponents.DotNetBar.WizardPage() {Me.pagEscolher, Me.pagDadosCliente})
        '
        'pagEscolher
        '
        Me.pagEscolher.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.pagEscolher.AntiAlias = false
        Me.pagEscolher.BackColor = System.Drawing.Color.Transparent
        Me.pagEscolher.Controls.Add(Me.opt_sem_cadastro)
        Me.pagEscolher.Controls.Add(Me.opt_com_cadastro)
        Me.pagEscolher.InteriorPage = false
        Me.pagEscolher.Location = New System.Drawing.Point(0, 0)
        Me.pagEscolher.Name = "pagEscolher"
        Me.pagEscolher.Size = New System.Drawing.Size(624, 144)
        '
        '
        '
        Me.pagEscolher.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.pagEscolher.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.pagEscolher.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pagEscolher.TabIndex = 0
        '
        'opt_sem_cadastro
        '
        Me.opt_sem_cadastro.AutoSize = true
        Me.opt_sem_cadastro.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.opt_sem_cadastro.Location = New System.Drawing.Point(102, 95)
        Me.opt_sem_cadastro.Name = "opt_sem_cadastro"
        Me.opt_sem_cadastro.Size = New System.Drawing.Size(327, 30)
        Me.opt_sem_cadastro.TabIndex = 1
        Me.opt_sem_cadastro.Text = "Não usar Cadastro de Clientes"
        Me.opt_sem_cadastro.UseVisualStyleBackColor = true
        '
        'opt_com_cadastro
        '
        Me.opt_com_cadastro.AutoSize = true
        Me.opt_com_cadastro.Checked = true
        Me.opt_com_cadastro.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.opt_com_cadastro.Location = New System.Drawing.Point(102, 36)
        Me.opt_com_cadastro.Name = "opt_com_cadastro"
        Me.opt_com_cadastro.Size = New System.Drawing.Size(285, 30)
        Me.opt_com_cadastro.TabIndex = 0
        Me.opt_com_cadastro.TabStop = true
        Me.opt_com_cadastro.Text = "Usar Cadastro de Clientes"
        Me.opt_com_cadastro.UseVisualStyleBackColor = true
        '
        'pagDadosCliente
        '
        Me.pagDadosCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.pagDadosCliente.AntiAlias = false
        Me.pagDadosCliente.BackColor = System.Drawing.Color.Transparent
        Me.pagDadosCliente.Controls.Add(Me.Check1)
        Me.pagDadosCliente.Controls.Add(Me.txtID)
        Me.pagDadosCliente.Controls.Add(Me.Label3)
        Me.pagDadosCliente.Controls.Add(Me.Label1)
        Me.pagDadosCliente.Controls.Add(Me.Label2)
        Me.pagDadosCliente.Controls.Add(Me.txtCidade)
        Me.pagDadosCliente.Controls.Add(Me.txtTelefone)
        Me.pagDadosCliente.Controls.Add(Me.txtNomeCliente)
        Me.pagDadosCliente.InteriorPage = false
        Me.pagDadosCliente.Location = New System.Drawing.Point(0, 0)
        Me.pagDadosCliente.Name = "pagDadosCliente"
        Me.pagDadosCliente.Size = New System.Drawing.Size(624, 144)
        '
        '
        '
        Me.pagDadosCliente.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.pagDadosCliente.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.pagDadosCliente.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pagDadosCliente.TabIndex = 1
        '
        'txtID
        '
        Me.txtID.AceitaColarTexto = true
        Me.txtID.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtID.CasasDecimais = 0
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.CPObrigatorio = false
        Me.txtID.CPObrigatorioMsg = Nothing
        Me.txtID.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtID.FlatBorder = false
        Me.txtID.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtID.FocusColor = System.Drawing.Color.Empty
        Me.txtID.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtID.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtID.HighlightBorderOnEnter = false
        Me.txtID.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtID.Location = New System.Drawing.Point(254, 112)
        Me.txtID.MaxLength = 50
        Me.txtID.Name = "txtID"
        Me.txtID.PreencherZeroEsqueda = false
        Me.txtID.RegraValidação = Nothing
        Me.txtID.RegraValidaçãoMensagem = Nothing
        Me.txtID.Size = New System.Drawing.Size(58, 26)
        Me.txtID.TabIndex = 6
        Me.txtID.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtID.ValorPadrao = Nothing
        Me.txtID.Visible = false
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cidade"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Telefone"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nome do Cliente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCidade
        '
        Me.txtCidade.AceitaColarTexto = true
        Me.txtCidade.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtCidade.CasasDecimais = 0
        Me.txtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCidade.CPObrigatorio = false
        Me.txtCidade.CPObrigatorioMsg = Nothing
        Me.txtCidade.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtCidade.FlatBorder = false
        Me.txtCidade.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtCidade.FocusColor = System.Drawing.Color.Empty
        Me.txtCidade.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtCidade.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCidade.HighlightBorderOnEnter = false
        Me.txtCidade.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtCidade.Location = New System.Drawing.Point(143, 80)
        Me.txtCidade.MaxLength = 50
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.PreencherZeroEsqueda = false
        Me.txtCidade.RegraValidação = Nothing
        Me.txtCidade.RegraValidaçãoMensagem = Nothing
        Me.txtCidade.Size = New System.Drawing.Size(456, 26)
        Me.txtCidade.TabIndex = 2
        Me.txtCidade.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtCidade.ValorPadrao = Nothing
        '
        'txtTelefone
        '
        Me.txtTelefone.AceitaColarTexto = true
        Me.txtTelefone.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtTelefone.CasasDecimais = 0
        Me.txtTelefone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefone.CPObrigatorio = false
        Me.txtTelefone.CPObrigatorioMsg = Nothing
        Me.txtTelefone.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtTelefone.FlatBorder = false
        Me.txtTelefone.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtTelefone.FocusColor = System.Drawing.Color.Empty
        Me.txtTelefone.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtTelefone.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTelefone.HighlightBorderOnEnter = false
        Me.txtTelefone.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtTelefone.Location = New System.Drawing.Point(143, 48)
        Me.txtTelefone.MaxLength = 14
        Me.txtTelefone.Name = "txtTelefone"
        Me.txtTelefone.PreencherZeroEsqueda = false
        Me.txtTelefone.RegraValidação = Nothing
        Me.txtTelefone.RegraValidaçãoMensagem = Nothing
        Me.txtTelefone.Size = New System.Drawing.Size(150, 26)
        Me.txtTelefone.TabIndex = 1
        Me.txtTelefone.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Fone
        Me.txtTelefone.ValorPadrao = Nothing
        '
        'txtNomeCliente
        '
        Me.txtNomeCliente.AceitaColarTexto = true
        Me.txtNomeCliente.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtNomeCliente.CasasDecimais = 0
        Me.txtNomeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeCliente.CPObrigatorio = false
        Me.txtNomeCliente.CPObrigatorioMsg = Nothing
        Me.txtNomeCliente.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtNomeCliente.FlatBorder = false
        Me.txtNomeCliente.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtNomeCliente.FocusColor = System.Drawing.Color.Empty
        Me.txtNomeCliente.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtNomeCliente.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNomeCliente.HighlightBorderOnEnter = false
        Me.txtNomeCliente.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtNomeCliente.Location = New System.Drawing.Point(143, 16)
        Me.txtNomeCliente.MaxLength = 50
        Me.txtNomeCliente.Name = "txtNomeCliente"
        Me.txtNomeCliente.PreencherZeroEsqueda = false
        Me.txtNomeCliente.RegraValidação = Nothing
        Me.txtNomeCliente.RegraValidaçãoMensagem = Nothing
        Me.txtNomeCliente.Size = New System.Drawing.Size(456, 26)
        Me.txtNomeCliente.TabIndex = 0
        Me.txtNomeCliente.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtNomeCliente.ValorPadrao = Nothing
        '
        'Check1
        '
        Me.Check1.AutoSize = true
        Me.Check1.Location = New System.Drawing.Point(143, 117)
        Me.Check1.Name = "Check1"
        Me.Check1.Size = New System.Drawing.Size(81, 17)
        Me.Check1.TabIndex = 1
        Me.Check1.TabStop = false
        Me.Check1.Text = "CheckBox1"
        Me.Check1.UseVisualStyleBackColor = true
        Me.Check1.Visible = false
        '
        'IniciarOrcamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 190)
        Me.ControlBox = false
        Me.Controls.Add(Me.Wizard1)
        Me.DoubleBuffered = true
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "IniciarOrcamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar Orçamento"
        Me.Wizard1.ResumeLayout(false)
        Me.pagEscolher.ResumeLayout(false)
        Me.pagEscolher.PerformLayout
        Me.pagDadosCliente.ResumeLayout(false)
        Me.pagDadosCliente.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Wizard1 As DevComponents.DotNetBar.Wizard
    Friend WithEvents pagEscolher As DevComponents.DotNetBar.WizardPage
    Friend WithEvents pagDadosCliente As DevComponents.DotNetBar.WizardPage
    Friend WithEvents opt_sem_cadastro As System.Windows.Forms.RadioButton
    Friend WithEvents opt_com_cadastro As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCidade As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtTelefone As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtNomeCliente As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtID As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Check1 As System.Windows.Forms.CheckBox
End Class
