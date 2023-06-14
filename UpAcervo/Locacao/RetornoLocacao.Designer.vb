<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RetornoLocacao
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RetornoLocacao))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtDataInicial = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtDataFinal = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lista1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cbtExcluir = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.cIdItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescrição = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorUnitarioLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorDescontoLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalDiarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtdDev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cQtdAvarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cValorUnitarioAvarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalAvarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lista = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cIdLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDataLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gRetorno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStatusLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnRetornar = New System.Windows.Forms.Button()
        CType(Me.Lista1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDataInicial
        '
        Me.txtDataInicial.AceitaColarTexto = False
        Me.txtDataInicial.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDataInicial.CasasDecimais = 0
        Me.txtDataInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataInicial.CPObrigatorio = False
        Me.txtDataInicial.CPObrigatorioMsg = Nothing
        Me.txtDataInicial.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtDataInicial.FlatBorder = True
        Me.txtDataInicial.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtDataInicial.FocusColor = System.Drawing.Color.Empty
        Me.txtDataInicial.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtDataInicial.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataInicial.HighlightBorderOnEnter = False
        Me.txtDataInicial.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtDataInicial.Location = New System.Drawing.Point(97, 12)
        Me.txtDataInicial.MaxLength = 10
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.PreencherZeroEsqueda = False
        Me.txtDataInicial.RegraValidação = Nothing
        Me.txtDataInicial.RegraValidaçãoMensagem = Nothing
        Me.txtDataInicial.ShortcutsEnabled = False
        Me.txtDataInicial.Size = New System.Drawing.Size(144, 26)
        Me.txtDataInicial.TabIndex = 2
        Me.txtDataInicial.Text = "01/12/2017"
        Me.txtDataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDataInicial.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.txtDataInicial.ValorPadrao = Nothing
        '
        'txtDataFinal
        '
        Me.txtDataFinal.AceitaColarTexto = False
        Me.txtDataFinal.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDataFinal.CasasDecimais = 0
        Me.txtDataFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDataFinal.CPObrigatorio = False
        Me.txtDataFinal.CPObrigatorioMsg = Nothing
        Me.txtDataFinal.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtDataFinal.FlatBorder = True
        Me.txtDataFinal.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtDataFinal.FocusColor = System.Drawing.Color.Empty
        Me.txtDataFinal.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtDataFinal.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataFinal.HighlightBorderOnEnter = False
        Me.txtDataFinal.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtDataFinal.Location = New System.Drawing.Point(97, 44)
        Me.txtDataFinal.MaxLength = 10
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.PreencherZeroEsqueda = False
        Me.txtDataFinal.RegraValidação = Nothing
        Me.txtDataFinal.RegraValidaçãoMensagem = Nothing
        Me.txtDataFinal.ShortcutsEnabled = False
        Me.txtDataFinal.Size = New System.Drawing.Size(144, 26)
        Me.txtDataFinal.TabIndex = 3
        Me.txtDataFinal.Text = "27/12/2017"
        Me.txtDataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDataFinal.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.txtDataFinal.ValorPadrao = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Data Inicial"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Data Final"
        '
        'Lista1
        '
        Me.Lista1.AllowUserToAddRows = False
        Me.Lista1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.Lista1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Lista1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cbtExcluir, Me.cIdItem, Me.cIdLocacao, Me.cProduto, Me.cDescrição, Me.cQtd, Me.cValorUnitarioLoc, Me.cValorDescontoLoc, Me.cTotalDiarias, Me.cTotalLoc, Me.cQtdDev, Me.cQtdAvarias, Me.cValorUnitarioAvarias, Me.cTotalAvarias})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lista1.DefaultCellStyle = DataGridViewCellStyle12
        Me.Lista1.EnableHeadersVisualStyles = False
        Me.Lista1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Lista1.Location = New System.Drawing.Point(12, 287)
        Me.Lista1.MultiSelect = False
        Me.Lista1.Name = "Lista1"
        Me.Lista1.ReadOnly = True
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista1.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Lista1.RowHeadersVisible = False
        Me.Lista1.RowHeadersWidth = 20
        Me.Lista1.SelectAllSignVisible = False
        Me.Lista1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista1.Size = New System.Drawing.Size(898, 338)
        Me.Lista1.TabIndex = 6
        '
        'cbtExcluir
        '
        Me.cbtExcluir.HeaderText = ""
        Me.cbtExcluir.Image = CType(resources.GetObject("cbtExcluir.Image"), System.Drawing.Image)
        Me.cbtExcluir.Name = "cbtExcluir"
        Me.cbtExcluir.ReadOnly = True
        Me.cbtExcluir.Text = Nothing
        Me.cbtExcluir.ToolTipText = "Excluir"
        Me.cbtExcluir.Width = 25
        '
        'cIdItem
        '
        Me.cIdItem.DataPropertyName = "IdItem"
        Me.cIdItem.HeaderText = "IdItem"
        Me.cIdItem.Name = "cIdItem"
        Me.cIdItem.ReadOnly = True
        Me.cIdItem.Visible = False
        Me.cIdItem.Width = 180
        '
        'cIdLocacao
        '
        Me.cIdLocacao.DataPropertyName = "IdLocacao"
        Me.cIdLocacao.HeaderText = "IdLocação"
        Me.cIdLocacao.Name = "cIdLocacao"
        Me.cIdLocacao.ReadOnly = True
        Me.cIdLocacao.Visible = False
        '
        'cProduto
        '
        Me.cProduto.DataPropertyName = "Produto"
        Me.cProduto.HeaderText = "Produto"
        Me.cProduto.Name = "cProduto"
        Me.cProduto.ReadOnly = True
        Me.cProduto.Width = 60
        '
        'cDescrição
        '
        Me.cDescrição.DataPropertyName = "Descrição"
        Me.cDescrição.HeaderText = "Descrição Produto"
        Me.cDescrição.Name = "cDescrição"
        Me.cDescrição.ReadOnly = True
        Me.cDescrição.Width = 300
        '
        'cQtd
        '
        Me.cQtd.DataPropertyName = "Qtd"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.cQtd.DefaultCellStyle = DataGridViewCellStyle3
        Me.cQtd.HeaderText = "Locado"
        Me.cQtd.Name = "cQtd"
        Me.cQtd.ReadOnly = True
        Me.cQtd.Width = 75
        '
        'cValorUnitarioLoc
        '
        Me.cValorUnitarioLoc.DataPropertyName = "ValorUnitarioLoc"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.cValorUnitarioLoc.DefaultCellStyle = DataGridViewCellStyle4
        Me.cValorUnitarioLoc.HeaderText = "Unit. Loc"
        Me.cValorUnitarioLoc.Name = "cValorUnitarioLoc"
        Me.cValorUnitarioLoc.ReadOnly = True
        Me.cValorUnitarioLoc.Visible = False
        Me.cValorUnitarioLoc.Width = 80
        '
        'cValorDescontoLoc
        '
        Me.cValorDescontoLoc.DataPropertyName = "ValorDescontoLoc"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.cValorDescontoLoc.DefaultCellStyle = DataGridViewCellStyle5
        Me.cValorDescontoLoc.HeaderText = "Desc. Loc"
        Me.cValorDescontoLoc.Name = "cValorDescontoLoc"
        Me.cValorDescontoLoc.ReadOnly = True
        Me.cValorDescontoLoc.Visible = False
        Me.cValorDescontoLoc.Width = 85
        '
        'cTotalDiarias
        '
        Me.cTotalDiarias.DataPropertyName = "TotalDiarias"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.cTotalDiarias.DefaultCellStyle = DataGridViewCellStyle6
        Me.cTotalDiarias.HeaderText = "Tot Diarias"
        Me.cTotalDiarias.Name = "cTotalDiarias"
        Me.cTotalDiarias.ReadOnly = True
        Me.cTotalDiarias.Visible = False
        Me.cTotalDiarias.Width = 90
        '
        'cTotalLoc
        '
        Me.cTotalLoc.DataPropertyName = "TotalLoc"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.cTotalLoc.DefaultCellStyle = DataGridViewCellStyle7
        Me.cTotalLoc.HeaderText = "Total Loc"
        Me.cTotalLoc.Name = "cTotalLoc"
        Me.cTotalLoc.ReadOnly = True
        Me.cTotalLoc.Visible = False
        Me.cTotalLoc.Width = 90
        '
        'cQtdDev
        '
        Me.cQtdDev.DataPropertyName = "QtdDev"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.cQtdDev.DefaultCellStyle = DataGridViewCellStyle8
        Me.cQtdDev.HeaderText = "Retorno"
        Me.cQtdDev.Name = "cQtdDev"
        Me.cQtdDev.ReadOnly = True
        Me.cQtdDev.Width = 75
        '
        'cQtdAvarias
        '
        Me.cQtdAvarias.DataPropertyName = "QtdAvarias"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.cQtdAvarias.DefaultCellStyle = DataGridViewCellStyle9
        Me.cQtdAvarias.HeaderText = "Falta"
        Me.cQtdAvarias.Name = "cQtdAvarias"
        Me.cQtdAvarias.ReadOnly = True
        Me.cQtdAvarias.Width = 75
        '
        'cValorUnitarioAvarias
        '
        Me.cValorUnitarioAvarias.DataPropertyName = "ValorUnitarioAvarias"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.cValorUnitarioAvarias.DefaultCellStyle = DataGridViewCellStyle10
        Me.cValorUnitarioAvarias.HeaderText = "Valor Reposição"
        Me.cValorUnitarioAvarias.Name = "cValorUnitarioAvarias"
        Me.cValorUnitarioAvarias.ReadOnly = True
        Me.cValorUnitarioAvarias.Width = 90
        '
        'cTotalAvarias
        '
        Me.cTotalAvarias.DataPropertyName = "TotalAvarias"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.cTotalAvarias.DefaultCellStyle = DataGridViewCellStyle11
        Me.cTotalAvarias.HeaderText = "Total"
        Me.cTotalAvarias.Name = "cTotalAvarias"
        Me.cTotalAvarias.ReadOnly = True
        Me.cTotalAvarias.Width = 90
        '
        'lista
        '
        Me.lista.AllowUserToAddRows = False
        Me.lista.AllowUserToDeleteRows = False
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.MediumPurple
        Me.lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdLoc, Me.cDataLoc, Me.gRetorno, Me.cCliente, Me.cNome, Me.DataGridViewTextBoxColumn1, Me.cStatusLoc})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lista.DefaultCellStyle = DataGridViewCellStyle16
        Me.lista.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.lista.Location = New System.Drawing.Point(12, 83)
        Me.lista.Name = "lista"
        Me.lista.ReadOnly = True
        Me.lista.RowHeadersWidth = 20
        Me.lista.SelectAllSignVisible = False
        Me.lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.lista.Size = New System.Drawing.Size(899, 198)
        Me.lista.TabIndex = 7
        '
        'cIdLoc
        '
        Me.cIdLoc.DataPropertyName = "IdLoc"
        Me.cIdLoc.HeaderText = "Locação Id"
        Me.cIdLoc.Name = "cIdLoc"
        Me.cIdLoc.ReadOnly = True
        Me.cIdLoc.Width = 90
        '
        'cDataLoc
        '
        Me.cDataLoc.DataPropertyName = "DataLoc"
        Me.cDataLoc.HeaderText = "Data Locação"
        Me.cDataLoc.Name = "cDataLoc"
        Me.cDataLoc.ReadOnly = True
        '
        'gRetorno
        '
        Me.gRetorno.DataPropertyName = "DataRetorno"
        Me.gRetorno.HeaderText = "Retorno"
        Me.gRetorno.Name = "gRetorno"
        Me.gRetorno.ReadOnly = True
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
        Me.cNome.Width = 300
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "TotalLoc"
        DataGridViewCellStyle15.Format = "C2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn1.HeaderText = "Total Locação"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 110
        '
        'cStatusLoc
        '
        Me.cStatusLoc.DataPropertyName = "StatusLoc"
        Me.cStatusLoc.HeaderText = "Status"
        Me.cStatusLoc.Name = "cStatusLoc"
        Me.cStatusLoc.ReadOnly = True
        Me.cStatusLoc.Width = 110
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(277, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 25)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnRetornar
        '
        Me.btnRetornar.Location = New System.Drawing.Point(277, 45)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Size = New System.Drawing.Size(100, 25)
        Me.btnRetornar.TabIndex = 9
        Me.btnRetornar.Text = "Retornar"
        Me.btnRetornar.UseVisualStyleBackColor = True
        '
        'RetornoLocacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 637)
        Me.Controls.Add(Me.btnRetornar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lista)
        Me.Controls.Add(Me.Lista1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDataFinal)
        Me.Controls.Add(Me.txtDataInicial)
        Me.Name = "RetornoLocacao"
        Me.Text = "Retorno"
        CType(Me.Lista1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDataInicial As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtDataFinal As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Lista1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cbtExcluir As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents cIdItem As DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacao As DataGridViewTextBoxColumn
    Friend WithEvents cProduto As DataGridViewTextBoxColumn
    Friend WithEvents cDescrição As DataGridViewTextBoxColumn
    Friend WithEvents cQtd As DataGridViewTextBoxColumn
    Friend WithEvents cValorUnitarioLoc As DataGridViewTextBoxColumn
    Friend WithEvents cValorDescontoLoc As DataGridViewTextBoxColumn
    Friend WithEvents cTotalDiarias As DataGridViewTextBoxColumn
    Friend WithEvents cTotalLoc As DataGridViewTextBoxColumn
    Friend WithEvents cQtdDev As DataGridViewTextBoxColumn
    Friend WithEvents cQtdAvarias As DataGridViewTextBoxColumn
    Friend WithEvents cValorUnitarioAvarias As DataGridViewTextBoxColumn
    Friend WithEvents cTotalAvarias As DataGridViewTextBoxColumn
    Friend WithEvents lista As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cIdLoc As DataGridViewTextBoxColumn
    Friend WithEvents cDataLoc As DataGridViewTextBoxColumn
    Friend WithEvents gRetorno As DataGridViewTextBoxColumn
    Friend WithEvents cCliente As DataGridViewTextBoxColumn
    Friend WithEvents cNome As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents cStatusLoc As DataGridViewTextBoxColumn
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnRetornar As Button
End Class
