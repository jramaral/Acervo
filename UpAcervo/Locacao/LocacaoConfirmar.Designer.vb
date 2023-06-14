<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocacaoConfirmar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocacaoConfirmar))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.txtValorEntrada = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DataRetorno = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btConfirmar = New DevComponents.DotNetBar.ButtonX()
        Me.QtdParcelas = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LocalPgto = New CBOAutoCompleteFocus.CboFocus()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TotalLocacao = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1.SuspendLayout()
        CType(Me.QtdParcelas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.txtValorEntrada)
        Me.PanelEx1.Controls.Add(Me.Label4)
        Me.PanelEx1.Controls.Add(Me.DataRetorno)
        Me.PanelEx1.Controls.Add(Me.Label14)
        Me.PanelEx1.Controls.Add(Me.btConfirmar)
        Me.PanelEx1.Controls.Add(Me.QtdParcelas)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.LocalPgto)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.TotalLocacao)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.Controls.Add(Me.Fechar)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(450, 337)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.PowderBlue
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.DeepSkyBlue
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        Me.PanelEx1.TabStop = True
        '
        'txtValorEntrada
        '
        Me.txtValorEntrada.AceitaColarTexto = False
        Me.txtValorEntrada.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtValorEntrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorEntrada.CasasDecimais = 2
        Me.txtValorEntrada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValorEntrada.CPObrigatorio = False
        Me.txtValorEntrada.CPObrigatorioMsg = Nothing
        Me.txtValorEntrada.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtValorEntrada.FlatBorder = True
        Me.txtValorEntrada.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtValorEntrada.FocusColor = System.Drawing.Color.Empty
        Me.txtValorEntrada.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtValorEntrada.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorEntrada.HighlightBorderOnEnter = False
        Me.txtValorEntrada.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtValorEntrada.Location = New System.Drawing.Point(240, 65)
        Me.txtValorEntrada.MaxLength = 15
        Me.txtValorEntrada.Name = "txtValorEntrada"
        Me.txtValorEntrada.PreencherZeroEsqueda = False
        Me.txtValorEntrada.RegraValidação = Nothing
        Me.txtValorEntrada.RegraValidaçãoMensagem = Nothing
        Me.txtValorEntrada.ShortcutsEnabled = False
        Me.txtValorEntrada.Size = New System.Drawing.Size(198, 37)
        Me.txtValorEntrada.TabIndex = 1
        Me.txtValorEntrada.TabStop = False
        Me.txtValorEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValorEntrada.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Numeros
        Me.txtValorEntrada.ValorPadrao = "0,00"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(217, 36)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Valor Entrada"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataRetorno
        '
        Me.DataRetorno.AceitaColarTexto = False
        Me.DataRetorno.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DataRetorno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataRetorno.CasasDecimais = 0
        Me.DataRetorno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataRetorno.CPObrigatorio = False
        Me.DataRetorno.CPObrigatorioMsg = Nothing
        Me.DataRetorno.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataRetorno.FlatBorder = True
        Me.DataRetorno.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataRetorno.FocusColor = System.Drawing.Color.Empty
        Me.DataRetorno.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataRetorno.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataRetorno.HighlightBorderOnEnter = False
        Me.DataRetorno.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataRetorno.Location = New System.Drawing.Point(240, 213)
        Me.DataRetorno.MaxLength = 10
        Me.DataRetorno.Name = "DataRetorno"
        Me.DataRetorno.PreencherZeroEsqueda = False
        Me.DataRetorno.RegraValidação = Nothing
        Me.DataRetorno.RegraValidaçãoMensagem = Nothing
        Me.DataRetorno.ShortcutsEnabled = False
        Me.DataRetorno.Size = New System.Drawing.Size(198, 37)
        Me.DataRetorno.TabIndex = 4
        Me.DataRetorno.TabStop = False
        Me.DataRetorno.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataRetorno.ValorPadrao = Nothing
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 214)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(217, 36)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Data para Retorno"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btConfirmar
        '
        Me.btConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btConfirmar.Image = CType(resources.GetObject("btConfirmar.Image"), System.Drawing.Image)
        Me.btConfirmar.Location = New System.Drawing.Point(261, 298)
        Me.btConfirmar.Name = "btConfirmar"
        Me.btConfirmar.Size = New System.Drawing.Size(90, 28)
        Me.btConfirmar.TabIndex = 5
        Me.btConfirmar.TabStop = False
        Me.btConfirmar.Text = "Confirmar"
        '
        'QtdParcelas
        '
        Me.QtdParcelas.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QtdParcelas.Location = New System.Drawing.Point(240, 167)
        Me.QtdParcelas.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.QtdParcelas.Name = "QtdParcelas"
        Me.QtdParcelas.Size = New System.Drawing.Size(65, 30)
        Me.QtdParcelas.TabIndex = 3
        Me.QtdParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 28)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Qtd Parcelas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LocalPgto
        '
        Me.LocalPgto.Auto_Complete = True
        Me.LocalPgto.AutoLimitar_Lista = True
        Me.LocalPgto.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.LocalPgto.CPObrigatorio = False
        Me.LocalPgto.CPObrigatorioMsg = Nothing
        Me.LocalPgto.FlatBorder = False
        Me.LocalPgto.FlatBorderColor = System.Drawing.Color.DimGray
        Me.LocalPgto.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LocalPgto.FormattingEnabled = True
        Me.LocalPgto.HighlightBorderColor = System.Drawing.Color.Empty
        Me.LocalPgto.HighlightBorderOnEnter = False
        Me.LocalPgto.Location = New System.Drawing.Point(240, 117)
        Me.LocalPgto.MaxDropDownItems = 4
        Me.LocalPgto.Name = "LocalPgto"
        Me.LocalPgto.Size = New System.Drawing.Size(198, 31)
        Me.LocalPgto.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 28)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Forma de Pagamento"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TotalLocacao
        '
        Me.TotalLocacao.BackColor = System.Drawing.Color.Transparent
        Me.TotalLocacao.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalLocacao.ForeColor = System.Drawing.Color.Navy
        Me.TotalLocacao.Location = New System.Drawing.Point(235, 19)
        Me.TotalLocacao.Name = "TotalLocacao"
        Me.TotalLocacao.Size = New System.Drawing.Size(203, 28)
        Me.TotalLocacao.TabIndex = 0
        Me.TotalLocacao.Text = "00,00"
        Me.TotalLocacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total da Locação"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Image = CType(resources.GetObject("Fechar.Image"), System.Drawing.Image)
        Me.Fechar.Location = New System.Drawing.Point(357, 298)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(81, 28)
        Me.Fechar.TabIndex = 6
        Me.Fechar.TabStop = False
        Me.Fechar.Text = "Fechar"
        '
        'LocacaoConfirmar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 337)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "LocacaoConfirmar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirmar Locação"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        CType(Me.QtdParcelas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TotalLocacao As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LocalPgto As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents QtdParcelas As System.Windows.Forms.NumericUpDown
    Friend WithEvents btConfirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DataRetorno As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtValorEntrada As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label4 As Label
End Class
