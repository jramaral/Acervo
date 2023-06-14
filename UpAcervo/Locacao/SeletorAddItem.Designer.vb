<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeletorAddItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeletorAddItem))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btConfirmar = New DevComponents.DotNetBar.ButtonX()
        Me.QtdSelecionado = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btConfirmar)
        Me.PanelEx1.Controls.Add(Me.QtdSelecionado)
        Me.PanelEx1.Controls.Add(Me.Label14)
        Me.PanelEx1.Controls.Add(Me.btCancelar)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(450, 264)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.PowderBlue
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.DeepSkyBlue
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'btConfirmar
        '
        Me.btConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btConfirmar.Image = CType(resources.GetObject("btConfirmar.Image"), System.Drawing.Image)
        Me.btConfirmar.Location = New System.Drawing.Point(258, 222)
        Me.btConfirmar.Name = "btConfirmar"
        Me.btConfirmar.Size = New System.Drawing.Size(93, 30)
        Me.btConfirmar.TabIndex = 2
        Me.btConfirmar.Text = "Confirmar"
        '
        'QtdSelecionado
        '
        Me.QtdSelecionado.AceitaColarTexto = False
        Me.QtdSelecionado.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.QtdSelecionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.QtdSelecionado.CasasDecimais = 0
        Me.QtdSelecionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QtdSelecionado.CPObrigatorio = False
        Me.QtdSelecionado.CPObrigatorioMsg = Nothing
        Me.QtdSelecionado.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.QtdSelecionado.FlatBorder = True
        Me.QtdSelecionado.FlatBorderColor = System.Drawing.Color.DimGray
        Me.QtdSelecionado.FocusColor = System.Drawing.Color.Empty
        Me.QtdSelecionado.FocusColorEnd = System.Drawing.Color.Empty
        Me.QtdSelecionado.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QtdSelecionado.HighlightBorderOnEnter = False
        Me.QtdSelecionado.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.QtdSelecionado.Location = New System.Drawing.Point(142, 95)
        Me.QtdSelecionado.MaxLength = 15
        Me.QtdSelecionado.Name = "QtdSelecionado"
        Me.QtdSelecionado.PreencherZeroEsqueda = False
        Me.QtdSelecionado.RegraValidação = Nothing
        Me.QtdSelecionado.RegraValidaçãoMensagem = Nothing
        Me.QtdSelecionado.ShortcutsEnabled = False
        Me.QtdSelecionado.Size = New System.Drawing.Size(167, 37)
        Me.QtdSelecionado.TabIndex = 1
        Me.QtdSelecionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.QtdSelecionado.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Numeros
        Me.QtdSelecionado.ValorPadrao = Nothing
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(25, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(401, 36)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Informe a quantidade a ser selecionada"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btCancelar
        '
        Me.btCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btCancelar.Image = CType(resources.GetObject("btCancelar.Image"), System.Drawing.Image)
        Me.btCancelar.Location = New System.Drawing.Point(357, 222)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(81, 30)
        Me.btCancelar.TabIndex = 3
        Me.btCancelar.Text = "Cancelar"
        '
        'SeletorAddItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 264)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "SeletorAddItem"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adicionar item"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btConfirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents QtdSelecionado As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
