<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BoletoIndicarConta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BoletoIndicarConta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.Dgv = New System.Windows.Forms.DataGridView()
        Me.salvar = New DevComponents.DotNetBar.ButtonX()
        Me.codigopedidocompra = New System.Windows.Forms.TextBox()
        Me.MenuAuxiliar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ProrrogarContaSelecionadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelEx1.SuspendLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuAuxiliar.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btFechar)
        Me.PanelEx1.Controls.Add(Me.Dgv)
        Me.PanelEx1.Controls.Add(Me.salvar)
        Me.PanelEx1.Controls.Add(Me.codigopedidocompra)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(767, 435)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Image = CType(resources.GetObject("btFechar.Image"), System.Drawing.Image)
        Me.btFechar.Location = New System.Drawing.Point(558, 387)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(96, 36)
        Me.btFechar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btFechar.TabIndex = 6
        Me.btFechar.Text = "Fechar"
        '
        'Dgv
        '
        Me.Dgv.AllowUserToAddRows = False
        Me.Dgv.AllowUserToDeleteRows = False
        Me.Dgv.AllowUserToResizeColumns = False
        Me.Dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Dgv.Location = New System.Drawing.Point(12, 12)
        Me.Dgv.Name = "Dgv"
        Me.Dgv.RowHeadersWidth = 25
        Me.Dgv.ShowEditingIcon = False
        Me.Dgv.Size = New System.Drawing.Size(743, 369)
        Me.Dgv.TabIndex = 4
        '
        'salvar
        '
        Me.salvar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.salvar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.salvar.Image = CType(resources.GetObject("salvar.Image"), System.Drawing.Image)
        Me.salvar.Location = New System.Drawing.Point(660, 387)
        Me.salvar.Name = "salvar"
        Me.salvar.Size = New System.Drawing.Size(96, 36)
        Me.salvar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.salvar.TabIndex = 5
        Me.salvar.Text = "Salvar"
        '
        'codigopedidocompra
        '
        Me.codigopedidocompra.Location = New System.Drawing.Point(359, 448)
        Me.codigopedidocompra.Name = "codigopedidocompra"
        Me.codigopedidocompra.Size = New System.Drawing.Size(78, 20)
        Me.codigopedidocompra.TabIndex = 3
        Me.codigopedidocompra.Visible = False
        '
        'MenuAuxiliar
        '
        Me.MenuAuxiliar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProrrogarContaSelecionadaToolStripMenuItem})
        Me.MenuAuxiliar.Name = "MenuAuxiliar"
        Me.MenuAuxiliar.Size = New System.Drawing.Size(147, 26)
        '
        'ProrrogarContaSelecionadaToolStripMenuItem
        '
        Me.ProrrogarContaSelecionadaToolStripMenuItem.Name = "ProrrogarContaSelecionadaToolStripMenuItem"
        Me.ProrrogarContaSelecionadaToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ProrrogarContaSelecionadaToolStripMenuItem.Text = "Limpar Conta"
        '
        'BoletoIndicarConta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 435)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "BoletoIndicarConta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicar Conta - T314"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuAuxiliar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents codigopedidocompra As System.Windows.Forms.TextBox
    Friend WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dgv As System.Windows.Forms.DataGridView
    Friend WithEvents salvar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MenuAuxiliar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ProrrogarContaSelecionadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
