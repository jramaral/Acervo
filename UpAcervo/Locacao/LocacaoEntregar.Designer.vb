<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocacaoEntregar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.Lista = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.cIdLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDataLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStatusLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gEntregar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PanelEx1.SuspendLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.Lista)
        Me.PanelEx1.Controls.Add(Me.Fechar)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(916, 504)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumPurple
        Me.Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdLoc, Me.cDataLoc, Me.cCliente, Me.cNome, Me.cTotalLoc, Me.cStatusLoc, Me.gEntregar})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lista.DefaultCellStyle = DataGridViewCellStyle3
        Me.Lista.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Lista.Location = New System.Drawing.Point(5, 7)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = True
        Me.Lista.RowHeadersWidth = 20
        Me.Lista.SelectAllSignVisible = False
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(899, 452)
        Me.Lista.TabIndex = 1
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Location = New System.Drawing.Point(784, 465)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(81, 28)
        Me.Fechar.TabIndex = 2
        Me.Fechar.TabStop = False
        Me.Fechar.Text = "Fechar"
        '
        'cIdLoc
        '
        Me.cIdLoc.DataPropertyName = "IdLoc"
        Me.cIdLoc.HeaderText = "Locação Id"
        Me.cIdLoc.Name = "cIdLoc"
        Me.cIdLoc.ReadOnly = True
        Me.cIdLoc.Width = 70
        '
        'cDataLoc
        '
        Me.cDataLoc.DataPropertyName = "DataLoc"
        Me.cDataLoc.HeaderText = "Data Locação"
        Me.cDataLoc.Name = "cDataLoc"
        Me.cDataLoc.ReadOnly = True
        '
        'cCliente
        '
        Me.cCliente.DataPropertyName = "Cliente"
        Me.cCliente.HeaderText = "Cliente"
        Me.cCliente.Name = "cCliente"
        Me.cCliente.ReadOnly = True
        Me.cCliente.Width = 80
        '
        'cNome
        '
        Me.cNome.DataPropertyName = "Nome"
        Me.cNome.HeaderText = "Nome Cliente"
        Me.cNome.Name = "cNome"
        Me.cNome.ReadOnly = True
        Me.cNome.Width = 310
        '
        'cTotalLoc
        '
        Me.cTotalLoc.DataPropertyName = "TotalLoc"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.cTotalLoc.DefaultCellStyle = DataGridViewCellStyle2
        Me.cTotalLoc.HeaderText = "Total Locação"
        Me.cTotalLoc.Name = "cTotalLoc"
        Me.cTotalLoc.ReadOnly = True
        Me.cTotalLoc.Width = 110
        '
        'cStatusLoc
        '
        Me.cStatusLoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cStatusLoc.DataPropertyName = "StatusLoc"
        Me.cStatusLoc.HeaderText = "Status"
        Me.cStatusLoc.Name = "cStatusLoc"
        Me.cStatusLoc.ReadOnly = True
        '
        'gEntregar
        '
        Me.gEntregar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gEntregar.HeaderText = ""
        Me.gEntregar.Name = "gEntregar"
        Me.gEntregar.ReadOnly = True
        Me.gEntregar.Text = "Entregar"
        Me.gEntregar.UseColumnTextForButtonValue = True
        '
        'LocacaoEntregar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 504)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "LocacaoEntregar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Locação a Entregar"
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Lista As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cIdLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDataLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStatusLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gEntregar As System.Windows.Forms.DataGridViewButtonColumn
End Class
