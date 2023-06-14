<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SellShoesOEVerItens
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ListaItens = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodigoProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescrição = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtdRetirada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCustoMercadoriaVendida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.ListaItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListaItens
        '
        Me.ListaItens.AllowUserToAddRows = False
        Me.ListaItens.AllowUserToDeleteRows = False
        Me.ListaItens.AllowUserToResizeColumns = False
        Me.ListaItens.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.ListaItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ListaItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListaItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cId, Me.cPedido, Me.cCodigoProduto, Me.cDescrição, Me.cQtd, Me.cQtdRetirada, Me.cValorUnitario, Me.cDesconto, Me.cValorDesconto, Me.cTotalProduto, Me.cCustoMercadoriaVendida})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListaItens.DefaultCellStyle = DataGridViewCellStyle8
        Me.ListaItens.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ListaItens.Location = New System.Drawing.Point(6, 12)
        Me.ListaItens.Name = "ListaItens"
        Me.ListaItens.RowHeadersVisible = False
        Me.ListaItens.RowHeadersWidth = 20
        Me.ListaItens.SelectAllSignVisible = False
        Me.ListaItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListaItens.Size = New System.Drawing.Size(1019, 629)
        Me.ListaItens.TabIndex = 3
        '
        'cId
        '
        Me.cId.DataPropertyName = "Id"
        Me.cId.HeaderText = "Id"
        Me.cId.Name = "cId"
        Me.cId.ReadOnly = True
        Me.cId.Visible = False
        '
        'cPedido
        '
        Me.cPedido.DataPropertyName = "PedidoSequencia"
        Me.cPedido.HeaderText = "Pedido"
        Me.cPedido.Name = "cPedido"
        Me.cPedido.ReadOnly = True
        Me.cPedido.Visible = False
        '
        'cCodigoProduto
        '
        Me.cCodigoProduto.DataPropertyName = "CodigoProduto"
        Me.cCodigoProduto.HeaderText = "Produto"
        Me.cCodigoProduto.Name = "cCodigoProduto"
        Me.cCodigoProduto.ReadOnly = True
        Me.cCodigoProduto.Width = 80
        '
        'cDescrição
        '
        Me.cDescrição.DataPropertyName = "Descrição"
        Me.cDescrição.HeaderText = "Descrição"
        Me.cDescrição.Name = "cDescrição"
        Me.cDescrição.ReadOnly = True
        Me.cDescrição.Width = 400
        '
        'cQtd
        '
        Me.cQtd.DataPropertyName = "Qtd"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.cQtd.DefaultCellStyle = DataGridViewCellStyle2
        Me.cQtd.HeaderText = "Qtd"
        Me.cQtd.Name = "cQtd"
        Me.cQtd.ReadOnly = True
        Me.cQtd.Width = 80
        '
        'cQtdRetirada
        '
        Me.cQtdRetirada.DataPropertyName = "QtdRetirada"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.cQtdRetirada.DefaultCellStyle = DataGridViewCellStyle3
        Me.cQtdRetirada.HeaderText = "Entregue"
        Me.cQtdRetirada.Name = "cQtdRetirada"
        Me.cQtdRetirada.ReadOnly = True
        Me.cQtdRetirada.Width = 70
        '
        'cValorUnitario
        '
        Me.cValorUnitario.DataPropertyName = "ValorUnitario"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.cValorUnitario.DefaultCellStyle = DataGridViewCellStyle4
        Me.cValorUnitario.HeaderText = "Unitário"
        Me.cValorUnitario.Name = "cValorUnitario"
        Me.cValorUnitario.ReadOnly = True
        Me.cValorUnitario.Width = 80
        '
        'cDesconto
        '
        Me.cDesconto.DataPropertyName = "Desconto"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.cDesconto.DefaultCellStyle = DataGridViewCellStyle5
        Me.cDesconto.HeaderText = "Desconto"
        Me.cDesconto.Name = "cDesconto"
        Me.cDesconto.ReadOnly = True
        Me.cDesconto.Width = 90
        '
        'cValorDesconto
        '
        Me.cValorDesconto.DataPropertyName = "ValorDesconto"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.cValorDesconto.DefaultCellStyle = DataGridViewCellStyle6
        Me.cValorDesconto.HeaderText = "Vlr Desc"
        Me.cValorDesconto.Name = "cValorDesconto"
        Me.cValorDesconto.ReadOnly = True
        Me.cValorDesconto.Width = 90
        '
        'cTotalProduto
        '
        Me.cTotalProduto.DataPropertyName = "TotalProduto"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.cTotalProduto.DefaultCellStyle = DataGridViewCellStyle7
        Me.cTotalProduto.HeaderText = "Total Prod."
        Me.cTotalProduto.Name = "cTotalProduto"
        Me.cTotalProduto.ReadOnly = True
        Me.cTotalProduto.Width = 90
        '
        'cCustoMercadoriaVendida
        '
        Me.cCustoMercadoriaVendida.DataPropertyName = "CustoMercadoriaVendida"
        Me.cCustoMercadoriaVendida.HeaderText = "CustoMercadoriaVendida"
        Me.cCustoMercadoriaVendida.Name = "cCustoMercadoriaVendida"
        Me.cCustoMercadoriaVendida.Visible = False
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btFechar)
        Me.PanelEx1.Controls.Add(Me.ListaItens)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1037, 697)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 4
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Location = New System.Drawing.Point(934, 659)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(90, 26)
        Me.btFechar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btFechar.TabIndex = 6
        Me.btFechar.Text = "Fechar"
        '
        'SellShoesOEVerItens
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1037, 697)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SellShoesOEVerItens"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Itens do Pedido "
        CType(Me.ListaItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListaItens As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Private WithEvents btFechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodigoProduto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDescrição As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cQtd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cQtdRetirada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cValorUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesconto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cValorDesconto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalProduto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCustoMercadoriaVendida As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
