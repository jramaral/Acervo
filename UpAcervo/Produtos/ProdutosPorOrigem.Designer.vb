<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProdutosPorOrigem
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
        Me.PanelFundo = New DevComponents.DotNetBar.PanelEx()
        Me.btnVisualizar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cboOrigem = New CBOAutoCompleteFocus.CboFocus()
        Me.PanelFundo.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'PanelFundo
        '
        Me.PanelFundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelFundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelFundo.Controls.Add(Me.GroupBox1)
        Me.PanelFundo.Controls.Add(Me.btnCancelar)
        Me.PanelFundo.Controls.Add(Me.btnVisualizar)
        Me.PanelFundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelFundo.Location = New System.Drawing.Point(0, 0)
        Me.PanelFundo.Name = "PanelFundo"
        Me.PanelFundo.Size = New System.Drawing.Size(388, 175)
        Me.PanelFundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelFundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelFundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelFundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelFundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelFundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelFundo.Style.GradientAngle = 90
        Me.PanelFundo.TabIndex = 0
        '
        'btnVisualizar
        '
        Me.btnVisualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVisualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVisualizar.Location = New System.Drawing.Point(158, 126)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(106, 32)
        Me.btnVisualizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVisualizar.TabIndex = 0
        Me.btnVisualizar.Text = "Visualizar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Location = New System.Drawing.Point(270, 126)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 32)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.cboOrigem)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 108)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Selecione uma Origem"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(13, 39)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 19)
        Me.Label29.TabIndex = 41
        Me.Label29.Text = "Origem"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOrigem
        '
        Me.cboOrigem.Auto_Complete = true
        Me.cboOrigem.AutoLimitar_Lista = true
        Me.cboOrigem.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.cboOrigem.CPObrigatorio = false
        Me.cboOrigem.CPObrigatorioMsg = Nothing
        Me.cboOrigem.FlatBorder = false
        Me.cboOrigem.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboOrigem.FormattingEnabled = true
        Me.cboOrigem.HighlightBorderColor = System.Drawing.Color.Empty
        Me.cboOrigem.HighlightBorderOnEnter = false
        Me.cboOrigem.Items.AddRange(New Object() {"(NENHUM)", "MARCIA", "MAISA"})
        Me.cboOrigem.Location = New System.Drawing.Point(70, 37)
        Me.cboOrigem.Name = "cboOrigem"
        Me.cboOrigem.Size = New System.Drawing.Size(247, 23)
        Me.cboOrigem.TabIndex = 40
        '
        'ProdutosPorOrigem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 175)
        Me.ControlBox = false
        Me.Controls.Add(Me.PanelFundo)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "ProdutosPorOrigem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtos por Origem"
        Me.PanelFundo.ResumeLayout(false)
        Me.GroupBox1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents PanelFundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnVisualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label29 As Label
    Friend WithEvents cboOrigem As CBOAutoCompleteFocus.CboFocus
End Class
