<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompraXmlProdutoImportar
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompraXmlProdutoImportar))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btSalvarCodERP = New DevComponents.DotNetBar.ButtonX()
        Me.ListaItens = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cdet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cadProd = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.ccProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cProdERP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cxProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cuCom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cqCom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cvUnCom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cvProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCFOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNCM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.DataGridViewButtonXColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.PanelEx1.SuspendLayout()
        CType(Me.ListaItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btSalvarCodERP)
        Me.PanelEx1.Controls.Add(Me.ListaItens)
        Me.PanelEx1.Controls.Add(Me.btFechar)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1084, 641)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'btSalvarCodERP
        '
        Me.btSalvarCodERP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btSalvarCodERP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btSalvarCodERP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btSalvarCodERP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSalvarCodERP.Location = New System.Drawing.Point(785, 606)
        Me.btSalvarCodERP.Name = "btSalvarCodERP"
        Me.btSalvarCodERP.Size = New System.Drawing.Size(142, 23)
        Me.btSalvarCodERP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btSalvarCodERP.TabIndex = 11
        Me.btSalvarCodERP.Text = "Salvar/Atualizar Cod. ERP"
        '
        'ListaItens
        '
        Me.ListaItens.AllowUserToAddRows = False
        Me.ListaItens.AllowUserToDeleteRows = False
        Me.ListaItens.AllowUserToResizeColumns = False
        Me.ListaItens.AllowUserToResizeRows = False
        Me.ListaItens.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ListaItens.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListaItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ListaItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.ListaItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cdet, Me.cadProd, Me.ccProd, Me.cProdERP, Me.cxProd, Me.cuCom, Me.cqCom, Me.cvUnCom, Me.cvProd, Me.cCFOP, Me.cNCM})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListaItens.DefaultCellStyle = DataGridViewCellStyle6
        Me.ListaItens.EnableHeadersVisualStyles = False
        Me.ListaItens.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ListaItens.Location = New System.Drawing.Point(11, 43)
        Me.ListaItens.MultiSelect = False
        Me.ListaItens.Name = "ListaItens"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListaItens.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.ListaItens.RowHeadersVisible = False
        Me.ListaItens.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListaItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListaItens.Size = New System.Drawing.Size(1060, 557)
        Me.ListaItens.TabIndex = 6
        '
        'cdet
        '
        Me.cdet.DataPropertyName = "det"
        Me.cdet.HeaderText = "IT"
        Me.cdet.Name = "cdet"
        Me.cdet.ReadOnly = True
        Me.cdet.Width = 30
        '
        'cadProd
        '
        Me.cadProd.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.cadProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cadProd.HeaderText = ""
        Me.cadProd.Image = CType(resources.GetObject("cadProd.Image"), System.Drawing.Image)
        Me.cadProd.Name = "cadProd"
        Me.cadProd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cadProd.Text = "Cadastrar Produto"
        Me.cadProd.UseColumnTextForButtonValue = True
        '
        'ccProd
        '
        Me.ccProd.DataPropertyName = "cProd"
        Me.ccProd.FillWeight = 120.0!
        Me.ccProd.HeaderText = "Cod"
        Me.ccProd.Name = "ccProd"
        Me.ccProd.ReadOnly = True
        Me.ccProd.Width = 120
        '
        'cProdERP
        '
        Me.cProdERP.DataPropertyName = "ProdErp"
        Me.cProdERP.HeaderText = "Cod ERP"
        Me.cProdERP.Name = "cProdERP"
        Me.cProdERP.Width = 75
        '
        'cxProd
        '
        Me.cxProd.DataPropertyName = "xProd"
        Me.cxProd.HeaderText = "Descrição"
        Me.cxProd.Name = "cxProd"
        Me.cxProd.Width = 350
        '
        'cuCom
        '
        Me.cuCom.DataPropertyName = "uCom"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cuCom.DefaultCellStyle = DataGridViewCellStyle2
        Me.cuCom.HeaderText = "UN"
        Me.cuCom.Name = "cuCom"
        Me.cuCom.Width = 70
        '
        'cqCom
        '
        Me.cqCom.DataPropertyName = "qCom"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.cqCom.DefaultCellStyle = DataGridViewCellStyle3
        Me.cqCom.HeaderText = "Qtd"
        Me.cqCom.Name = "cqCom"
        Me.cqCom.Width = 60
        '
        'cvUnCom
        '
        Me.cvUnCom.DataPropertyName = "vUnCom"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.cvUnCom.DefaultCellStyle = DataGridViewCellStyle4
        Me.cvUnCom.HeaderText = "Unitário"
        Me.cvUnCom.Name = "cvUnCom"
        '
        'cvProd
        '
        Me.cvProd.DataPropertyName = "vProd"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cvProd.DefaultCellStyle = DataGridViewCellStyle5
        Me.cvProd.HeaderText = "Total"
        Me.cvProd.Name = "cvProd"
        '
        'cCFOP
        '
        Me.cCFOP.DataPropertyName = "CFOP"
        Me.cCFOP.HeaderText = "CFOPs "
        Me.cCFOP.Name = "cCFOP"
        Me.cCFOP.Width = 50
        '
        'cNCM
        '
        Me.cNCM.DataPropertyName = "ncm"
        Me.cNCM.HeaderText = "NCM"
        Me.cNCM.Name = "cNCM"
        Me.cNCM.ReadOnly = True
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Location = New System.Drawing.Point(933, 606)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(75, 23)
        Me.btFechar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btFechar.TabIndex = 0
        Me.btFechar.Text = "Fechar"
        '
        'DataGridViewButtonXColumn1
        '
        Me.DataGridViewButtonXColumn1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.DataGridViewButtonXColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewButtonXColumn1.HeaderText = "..."
        Me.DataGridViewButtonXColumn1.Image = CType(resources.GetObject("DataGridViewButtonXColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewButtonXColumn1.Name = "DataGridViewButtonXColumn1"
        Me.DataGridViewButtonXColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonXColumn1.Text = Nothing
        Me.DataGridViewButtonXColumn1.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonXColumn1.Width = 22
        '
        'CompraXmlProdutoImportar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 641)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "CompraXmlProdutoImportar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importação de Produt da Compra - T275"
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.ListaItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ListaItens As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewButtonXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents btSalvarCodERP As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cdet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cadProd As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents ccProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cProdERP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cxProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cuCom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cqCom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cvUnCom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cvProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCFOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNCM As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
