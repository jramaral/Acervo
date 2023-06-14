<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcuraProdutoFoto
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
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.listView = New System.Windows.Forms.ListView()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FiltrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.stComboBoxFilter = New System.Windows.Forms.ToolStripComboBox()
        Me.tsTxtTexto = New System.Windows.Forms.ToolStripTextBox()
        Me.tsExecutar = New System.Windows.Forms.ToolStripMenuItem()
        Me.FecharToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelEx1.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.PanelEx1.Controls.Add(Me.listView)
        Me.PanelEx1.Controls.Add(Me.MenuStrip)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1241, 623)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'listView
        '
        Me.listView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listView.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.listView.Location = New System.Drawing.Point(0, 32)
        Me.listView.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.listView.Name = "listView"
        Me.listView.ShowItemToolTips = True
        Me.listView.Size = New System.Drawing.Size(1241, 591)
        Me.listView.TabIndex = 2
        Me.listView.UseCompatibleStateImageBehavior = False
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FiltrosToolStripMenuItem, Me.stComboBoxFilter, Me.tsTxtTexto, Me.tsExecutar, Me.FecharToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1241, 32)
        Me.MenuStrip.TabIndex = 3
        '
        'FiltrosToolStripMenuItem
        '
        Me.FiltrosToolStripMenuItem.Name = "FiltrosToolStripMenuItem"
        Me.FiltrosToolStripMenuItem.Size = New System.Drawing.Size(67, 28)
        Me.FiltrosToolStripMenuItem.Text = "Filtros=>"
        '
        'stComboBoxFilter
        '
        Me.stComboBoxFilter.Items.AddRange(New Object() {"Todos", "Descrição"})
        Me.stComboBoxFilter.Name = "stComboBoxFilter"
        Me.stComboBoxFilter.Size = New System.Drawing.Size(87, 28)
        '
        'tsTxtTexto
        '
        Me.tsTxtTexto.Name = "tsTxtTexto"
        Me.tsTxtTexto.Size = New System.Drawing.Size(200, 28)
        '
        'tsExecutar
        '
        Me.tsExecutar.Image = Global.UpAcervo.My.Resources.Resources.Localizar
        Me.tsExecutar.Name = "tsExecutar"
        Me.tsExecutar.Size = New System.Drawing.Size(136, 28)
        Me.tsExecutar.Text = "Executar Pesquisa"
        '
        'FecharToolStripMenuItem
        '
        Me.FecharToolStripMenuItem.Image = Global.UpAcervo.My.Resources.Resources.Sair
        Me.FecharToolStripMenuItem.Name = "FecharToolStripMenuItem"
        Me.FecharToolStripMenuItem.Size = New System.Drawing.Size(78, 28)
        Me.FecharToolStripMenuItem.Text = "Fechar"
        '
        'ProcuraProdutoFoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 623)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "ProcuraProdutoFoto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProcuraProdutoFoto"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Private WithEvents listView As System.Windows.Forms.ListView
    Private WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents stComboBoxFilter As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsTxtTexto As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsExecutar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FecharToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
