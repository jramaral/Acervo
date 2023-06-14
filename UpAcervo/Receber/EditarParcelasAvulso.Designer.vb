<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarParcelasAvulso
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
        Me.Dgv = New System.Windows.Forms.DataGridView()
        Me.txtResto = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.fechar = New DevComponents.DotNetBar.ButtonX()
        Me.salvar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dgv
        '
        Me.Dgv.AllowUserToAddRows = False
        Me.Dgv.AllowUserToDeleteRows = False
        Me.Dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv.Location = New System.Drawing.Point(12, 12)
        Me.Dgv.Name = "Dgv"
        Me.Dgv.RowHeadersWidth = 25
        Me.Dgv.ShowEditingIcon = False
        Me.Dgv.Size = New System.Drawing.Size(368, 194)
        Me.Dgv.TabIndex = 5
        '
        'txtResto
        '
        Me.txtResto.Location = New System.Drawing.Point(137, 361)
        Me.txtResto.Name = "txtResto"
        Me.txtResto.Size = New System.Drawing.Size(111, 20)
        Me.txtResto.TabIndex = 9
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(20, 361)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(111, 20)
        Me.txtTotal.TabIndex = 8
        '
        'fechar
        '
        Me.fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.fechar.Location = New System.Drawing.Point(284, 212)
        Me.fechar.Name = "fechar"
        Me.fechar.Size = New System.Drawing.Size(96, 36)
        Me.fechar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.fechar.TabIndex = 6
        Me.fechar.Text = "Fechar"
        '
        'salvar
        '
        Me.salvar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.salvar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.salvar.Location = New System.Drawing.Point(184, 212)
        Me.salvar.Name = "salvar"
        Me.salvar.Size = New System.Drawing.Size(96, 36)
        Me.salvar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.salvar.TabIndex = 7
        Me.salvar.Text = "Salvar"
        '
        'EditarParcelasAvulso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 254)
        Me.ControlBox = False
        Me.Controls.Add(Me.Dgv)
        Me.Controls.Add(Me.txtResto)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.fechar)
        Me.Controls.Add(Me.salvar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditarParcelasAvulso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Parcelas"
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txtResto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents salvar As DevComponents.DotNetBar.ButtonX
End Class
