<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocacaoClientesProcura
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.A3 = New System.Windows.Forms.RadioButton()
        Me.A2 = New System.Windows.Forms.RadioButton()
        Me.A1 = New System.Windows.Forms.RadioButton()
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.ID = New System.Windows.Forms.TextBox()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btnCadClientes = New DevComponents.DotNetBar.ButtonX()
        Me.xEndereço = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.xBloqueado = New System.Windows.Forms.CheckBox()
        Me.xVendaCheque = New System.Windows.Forms.CheckBox()
        Me.xVendaCrediario = New System.Windows.Forms.CheckBox()
        Me.xVendaVista = New System.Windows.Forms.CheckBox()
        Me.xMotivoBloqueado = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.xEmail = New System.Windows.Forms.Label()
        Me.xContato = New System.Windows.Forms.Label()
        Me.xCelular = New System.Windows.Forms.Label()
        Me.xTelefone = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.xCidade = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.xCpfCnpj = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.xCliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.A11 = New System.Windows.Forms.RadioButton()
        Me.A10 = New System.Windows.Forms.RadioButton()
        Me.A9 = New System.Windows.Forms.RadioButton()
        Me.A3a = New System.Windows.Forms.RadioButton()
        Me.A5 = New System.Windows.Forms.RadioButton()
        Me.A4 = New System.Windows.Forms.RadioButton()
        Me.Fechar = New DevComponents.DotNetBar.ButtonX()
        Me.TxtProcura = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Lista = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.cCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFantasia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCpfCnpj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAvista = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cCheque = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cCrediario = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cBloqueado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTelefone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCelular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cContato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEndereco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvalorEmAberto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fundo.SuspendLayout
        Me.PanelEx1.SuspendLayout
        Me.GroupPanel1.SuspendLayout
        CType(Me.Lista,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(3, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Procurar"
        '
        'A3
        '
        Me.A3.AutoSize = true
        Me.A3.Location = New System.Drawing.Point(309, 2)
        Me.A3.Name = "A3"
        Me.A3.Size = New System.Drawing.Size(68, 19)
        Me.A3.TabIndex = 3
        Me.A3.Text = "CPF [F6]"
        Me.A3.UseVisualStyleBackColor = true
        '
        'A2
        '
        Me.A2.AutoSize = true
        Me.A2.Location = New System.Drawing.Point(95, 0)
        Me.A2.Name = "A2"
        Me.A2.Size = New System.Drawing.Size(78, 19)
        Me.A2.TabIndex = 1
        Me.A2.Text = "Nome [F4]"
        Me.A2.UseVisualStyleBackColor = true
        '
        'A1
        '
        Me.A1.AutoSize = true
        Me.A1.Location = New System.Drawing.Point(6, 0)
        Me.A1.Name = "A1"
        Me.A1.Size = New System.Drawing.Size(84, 19)
        Me.A1.TabIndex = 0
        Me.A1.Text = "Código [F3]"
        Me.A1.UseVisualStyleBackColor = true
        '
        'Fundo
        '
        Me.Fundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Fundo.Controls.Add(Me.ID)
        Me.Fundo.Controls.Add(Me.PanelEx1)
        Me.Fundo.Controls.Add(Me.GroupPanel1)
        Me.Fundo.Controls.Add(Me.Lista)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(971, 578)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.Color = System.Drawing.Color.PowderBlue
        Me.Fundo.Style.BackColor2.Color = System.Drawing.Color.DeepSkyBlue
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'ID
        '
        Me.ID.Location = New System.Drawing.Point(5, 83)
        Me.ID.Name = "ID"
        Me.ID.Size = New System.Drawing.Size(48, 23)
        Me.ID.TabIndex = 4
        Me.ID.Visible = false
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btnCadClientes)
        Me.PanelEx1.Controls.Add(Me.xEndereço)
        Me.PanelEx1.Controls.Add(Me.Label10)
        Me.PanelEx1.Controls.Add(Me.xBloqueado)
        Me.PanelEx1.Controls.Add(Me.xVendaCheque)
        Me.PanelEx1.Controls.Add(Me.xVendaCrediario)
        Me.PanelEx1.Controls.Add(Me.xVendaVista)
        Me.PanelEx1.Controls.Add(Me.xMotivoBloqueado)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.xEmail)
        Me.PanelEx1.Controls.Add(Me.xContato)
        Me.PanelEx1.Controls.Add(Me.xCelular)
        Me.PanelEx1.Controls.Add(Me.xTelefone)
        Me.PanelEx1.Controls.Add(Me.Label8)
        Me.PanelEx1.Controls.Add(Me.Label9)
        Me.PanelEx1.Controls.Add(Me.xCidade)
        Me.PanelEx1.Controls.Add(Me.Label7)
        Me.PanelEx1.Controls.Add(Me.Label6)
        Me.PanelEx1.Controls.Add(Me.Label5)
        Me.PanelEx1.Controls.Add(Me.xCpfCnpj)
        Me.PanelEx1.Controls.Add(Me.Label4)
        Me.PanelEx1.Controls.Add(Me.xCliente)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Location = New System.Drawing.Point(5, 426)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(959, 146)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.PowderBlue
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.DeepSkyBlue
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 3
        '
        'btnCadClientes
        '
        Me.btnCadClientes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCadClientes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCadClientes.Location = New System.Drawing.Point(838, 7)
        Me.btnCadClientes.Name = "btnCadClientes"
        Me.btnCadClientes.Size = New System.Drawing.Size(116, 36)
        Me.btnCadClientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.btnCadClientes.TabIndex = 25
        Me.btnCadClientes.TabStop = false
        Me.btnCadClientes.Text = "Cadastra Cliente"
        '
        'xEndereço
        '
        Me.xEndereço.BackColor = System.Drawing.Color.Transparent
        Me.xEndereço.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.xEndereço.Location = New System.Drawing.Point(98, 26)
        Me.xEndereço.Name = "xEndereço"
        Me.xEndereço.Size = New System.Drawing.Size(318, 17)
        Me.xEndereço.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(6, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 15)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Endereço:"
        '
        'xBloqueado
        '
        Me.xBloqueado.AutoSize = true
        Me.xBloqueado.Enabled = false
        Me.xBloqueado.Location = New System.Drawing.Point(410, 121)
        Me.xBloqueado.Name = "xBloqueado"
        Me.xBloqueado.Size = New System.Drawing.Size(78, 19)
        Me.xBloqueado.TabIndex = 22
        Me.xBloqueado.Text = "Bloqueado"
        Me.xBloqueado.UseVisualStyleBackColor = true
        Me.xBloqueado.Visible = false
        '
        'xVendaCheque
        '
        Me.xVendaCheque.AutoSize = true
        Me.xVendaCheque.Enabled = false
        Me.xVendaCheque.Location = New System.Drawing.Point(190, 122)
        Me.xVendaCheque.Name = "xVendaCheque"
        Me.xVendaCheque.Size = New System.Drawing.Size(97, 19)
        Me.xVendaCheque.TabIndex = 21
        Me.xVendaCheque.Text = "Venda Cheque"
        Me.xVendaCheque.UseVisualStyleBackColor = true
        '
        'xVendaCrediario
        '
        Me.xVendaCrediario.AutoSize = true
        Me.xVendaCrediario.Enabled = false
        Me.xVendaCrediario.Location = New System.Drawing.Point(293, 122)
        Me.xVendaCrediario.Name = "xVendaCrediario"
        Me.xVendaCrediario.Size = New System.Drawing.Size(109, 19)
        Me.xVendaCrediario.TabIndex = 20
        Me.xVendaCrediario.Text = "Venda Crediário"
        Me.xVendaCrediario.UseVisualStyleBackColor = true
        '
        'xVendaVista
        '
        Me.xVendaVista.AutoSize = true
        Me.xVendaVista.Enabled = false
        Me.xVendaVista.Location = New System.Drawing.Point(98, 121)
        Me.xVendaVista.Name = "xVendaVista"
        Me.xVendaVista.Size = New System.Drawing.Size(86, 19)
        Me.xVendaVista.TabIndex = 19
        Me.xVendaVista.Text = "Venda Vista"
        Me.xVendaVista.UseVisualStyleBackColor = true
        '
        'xMotivoBloqueado
        '
        Me.xMotivoBloqueado.BackColor = System.Drawing.Color.Transparent
        Me.xMotivoBloqueado.Font = New System.Drawing.Font("Comic Sans MS", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.xMotivoBloqueado.ForeColor = System.Drawing.Color.Red
        Me.xMotivoBloqueado.Location = New System.Drawing.Point(431, 6)
        Me.xMotivoBloqueado.Name = "xMotivoBloqueado"
        Me.xMotivoBloqueado.Size = New System.Drawing.Size(401, 55)
        Me.xMotivoBloqueado.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(6, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Operação:"
        '
        'xEmail
        '
        Me.xEmail.BackColor = System.Drawing.Color.Transparent
        Me.xEmail.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.xEmail.Location = New System.Drawing.Point(557, 120)
        Me.xEmail.Name = "xEmail"
        Me.xEmail.Size = New System.Drawing.Size(395, 17)
        Me.xEmail.TabIndex = 11
        '
        'xContato
        '
        Me.xContato.BackColor = System.Drawing.Color.Transparent
        Me.xContato.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.xContato.Location = New System.Drawing.Point(493, 69)
        Me.xContato.Name = "xContato"
        Me.xContato.Size = New System.Drawing.Size(290, 17)
        Me.xContato.TabIndex = 11
        '
        'xCelular
        '
        Me.xCelular.BackColor = System.Drawing.Color.Transparent
        Me.xCelular.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.xCelular.Location = New System.Drawing.Point(321, 92)
        Me.xCelular.Name = "xCelular"
        Me.xCelular.Size = New System.Drawing.Size(121, 22)
        Me.xCelular.TabIndex = 11
        '
        'xTelefone
        '
        Me.xTelefone.BackColor = System.Drawing.Color.Transparent
        Me.xTelefone.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.xTelefone.Location = New System.Drawing.Point(98, 93)
        Me.xTelefone.Name = "xTelefone"
        Me.xTelefone.Size = New System.Drawing.Size(143, 21)
        Me.xTelefone.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(504, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "E-Mail:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(438, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 15)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Contato:"
        '
        'xCidade
        '
        Me.xCidade.BackColor = System.Drawing.Color.Transparent
        Me.xCidade.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.xCidade.Location = New System.Drawing.Point(98, 68)
        Me.xCidade.Name = "xCidade"
        Me.xCidade.Size = New System.Drawing.Size(318, 17)
        Me.xCidade.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(272, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Celular:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(6, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Telefone:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(6, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Cidade:"
        '
        'xCpfCnpj
        '
        Me.xCpfCnpj.BackColor = System.Drawing.Color.Transparent
        Me.xCpfCnpj.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.xCpfCnpj.Location = New System.Drawing.Point(98, 46)
        Me.xCpfCnpj.Name = "xCpfCnpj"
        Me.xCpfCnpj.Size = New System.Drawing.Size(318, 17)
        Me.xCpfCnpj.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Cpf/Cnpj:"
        '
        'xCliente
        '
        Me.xCliente.BackColor = System.Drawing.Color.Transparent
        Me.xCliente.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.xCliente.Location = New System.Drawing.Point(98, 7)
        Me.xCliente.Name = "xCliente"
        Me.xCliente.Size = New System.Drawing.Size(318, 17)
        Me.xCliente.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cliente:"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.A11)
        Me.GroupPanel1.Controls.Add(Me.A10)
        Me.GroupPanel1.Controls.Add(Me.A9)
        Me.GroupPanel1.Controls.Add(Me.A3a)
        Me.GroupPanel1.Controls.Add(Me.A5)
        Me.GroupPanel1.Controls.Add(Me.A4)
        Me.GroupPanel1.Controls.Add(Me.A3)
        Me.GroupPanel1.Controls.Add(Me.Fechar)
        Me.GroupPanel1.Controls.Add(Me.TxtProcura)
        Me.GroupPanel1.Controls.Add(Me.A1)
        Me.GroupPanel1.Controls.Add(Me.A2)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(958, 79)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.PowderBlue
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.DeepSkyBlue
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "Selecione uma das opções"
        '
        'A11
        '
        Me.A11.AutoSize = true
        Me.A11.Location = New System.Drawing.Point(771, 3)
        Me.A11.Name = "A11"
        Me.A11.Size = New System.Drawing.Size(73, 19)
        Me.A11.TabIndex = 11
        Me.A11.Text = "Endereço"
        Me.A11.UseVisualStyleBackColor = true
        '
        'A10
        '
        Me.A10.AutoSize = true
        Me.A10.Location = New System.Drawing.Point(694, 3)
        Me.A10.Name = "A10"
        Me.A10.Size = New System.Drawing.Size(71, 19)
        Me.A10.TabIndex = 10
        Me.A10.Text = "Telefone"
        Me.A10.UseVisualStyleBackColor = true
        Me.A10.Visible = false
        '
        'A9
        '
        Me.A9.AutoSize = true
        Me.A9.Location = New System.Drawing.Point(467, 3)
        Me.A9.Name = "A9"
        Me.A9.Size = New System.Drawing.Size(92, 19)
        Me.A9.TabIndex = 9
        Me.A9.Text = "Inativos [F9]"
        Me.A9.UseVisualStyleBackColor = true
        '
        'A3a
        '
        Me.A3a.AutoSize = true
        Me.A3a.Location = New System.Drawing.Point(383, 2)
        Me.A3a.Name = "A3a"
        Me.A3a.Size = New System.Drawing.Size(78, 19)
        Me.A3a.TabIndex = 8
        Me.A3a.Text = "CNPJ [F7]"
        Me.A3a.UseVisualStyleBackColor = true
        '
        'A5
        '
        Me.A5.AutoSize = true
        Me.A5.Location = New System.Drawing.Point(179, 0)
        Me.A5.Name = "A5"
        Me.A5.Size = New System.Drawing.Size(124, 19)
        Me.A5.TabIndex = 2
        Me.A5.Text = "Nome Fantasia [F5]"
        Me.A5.UseVisualStyleBackColor = true
        '
        'A4
        '
        Me.A4.AutoSize = true
        Me.A4.Location = New System.Drawing.Point(565, 3)
        Me.A4.Name = "A4"
        Me.A4.Size = New System.Drawing.Size(123, 19)
        Me.A4.TabIndex = 4
        Me.A4.Text = "Mostrar Todos [F8]"
        Me.A4.UseVisualStyleBackColor = true
        '
        'Fechar
        '
        Me.Fechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Fechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Fechar.Location = New System.Drawing.Point(876, 18)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(73, 25)
        Me.Fechar.TabIndex = 7
        Me.Fechar.TabStop = false
        Me.Fechar.Text = "Fechar"
        '
        'TxtProcura
        '
        Me.TxtProcura.AceitaColarTexto = true
        Me.TxtProcura.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.TxtProcura.CasasDecimais = 0
        Me.TxtProcura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtProcura.CPObrigatorio = false
        Me.TxtProcura.CPObrigatorioMsg = Nothing
        Me.TxtProcura.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.TxtProcura.FlatBorder = false
        Me.TxtProcura.FlatBorderColor = System.Drawing.Color.DimGray
        Me.TxtProcura.FocusColor = System.Drawing.Color.Empty
        Me.TxtProcura.FocusColorEnd = System.Drawing.Color.Empty
        Me.TxtProcura.HighlightBorderOnEnter = false
        Me.TxtProcura.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.TxtProcura.Location = New System.Drawing.Point(61, 25)
        Me.TxtProcura.Name = "TxtProcura"
        Me.TxtProcura.PreencherZeroEsqueda = false
        Me.TxtProcura.RegraValidação = Nothing
        Me.TxtProcura.RegraValidaçãoMensagem = Nothing
        Me.TxtProcura.Size = New System.Drawing.Size(783, 23)
        Me.TxtProcura.TabIndex = 6
        Me.TxtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.TxtProcura.ValorPadrao = Nothing
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = false
        Me.Lista.AllowUserToDeleteRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodigo, Me.cNome, Me.cFantasia, Me.cCpfCnpj, Me.cCidade, Me.cAvista, Me.cCheque, Me.cCrediario, Me.cBloqueado, Me.cMotivo, Me.cTelefone, Me.cCelular, Me.cContato, Me.cEndereco, Me.email, Me.gvalorEmAberto})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lista.DefaultCellStyle = DataGridViewCellStyle4
        Me.Lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Lista.EnableHeadersVisualStyles = false
        Me.Lista.GridColor = System.Drawing.Color.FromArgb(CType(CType(208,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(229,Byte),Integer))
        Me.Lista.Location = New System.Drawing.Point(5, 110)
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = true
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lista.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Lista.RowHeadersWidth = 20
        Me.Lista.SelectAllSignVisible = false
        Me.Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Lista.Size = New System.Drawing.Size(959, 311)
        Me.Lista.TabIndex = 1
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "C:\UpSistemas\Help\dblsistemas.chm"
        '
        'cCodigo
        '
        Me.cCodigo.DataPropertyName = "Codigo"
        Me.cCodigo.HeaderText = "Código"
        Me.cCodigo.Name = "cCodigo"
        Me.cCodigo.ReadOnly = true
        Me.cCodigo.Width = 70
        '
        'cNome
        '
        Me.cNome.DataPropertyName = "Nome"
        Me.cNome.HeaderText = "Nome"
        Me.cNome.Name = "cNome"
        Me.cNome.ReadOnly = true
        Me.cNome.Width = 360
        '
        'cFantasia
        '
        Me.cFantasia.DataPropertyName = "NomeFantasia"
        Me.cFantasia.HeaderText = "Nome Fantasia"
        Me.cFantasia.Name = "cFantasia"
        Me.cFantasia.ReadOnly = true
        Me.cFantasia.Width = 150
        '
        'cCpfCnpj
        '
        Me.cCpfCnpj.DataPropertyName = "CpfCgc"
        Me.cCpfCnpj.HeaderText = "Cpf/Cnpj"
        Me.cCpfCnpj.Name = "cCpfCnpj"
        Me.cCpfCnpj.ReadOnly = true
        Me.cCpfCnpj.Width = 120
        '
        'cCidade
        '
        Me.cCidade.DataPropertyName = "Cidade"
        Me.cCidade.HeaderText = "Cidade"
        Me.cCidade.Name = "cCidade"
        Me.cCidade.ReadOnly = true
        Me.cCidade.Width = 120
        '
        'cAvista
        '
        Me.cAvista.DataPropertyName = "VendaVista"
        Me.cAvista.HeaderText = "avista"
        Me.cAvista.Name = "cAvista"
        Me.cAvista.ReadOnly = true
        Me.cAvista.Visible = false
        '
        'cCheque
        '
        Me.cCheque.DataPropertyName = "VendaCheque"
        Me.cCheque.HeaderText = "cheque"
        Me.cCheque.Name = "cCheque"
        Me.cCheque.ReadOnly = true
        Me.cCheque.Visible = false
        '
        'cCrediario
        '
        Me.cCrediario.DataPropertyName = "VendaCrediario"
        Me.cCrediario.HeaderText = "crediario"
        Me.cCrediario.Name = "cCrediario"
        Me.cCrediario.ReadOnly = true
        Me.cCrediario.Visible = false
        '
        'cBloqueado
        '
        Me.cBloqueado.DataPropertyName = "Bloqueado"
        Me.cBloqueado.HeaderText = "bloqueado"
        Me.cBloqueado.Name = "cBloqueado"
        Me.cBloqueado.ReadOnly = true
        Me.cBloqueado.Visible = false
        '
        'cMotivo
        '
        Me.cMotivo.DataPropertyName = "MotivoBloqueado"
        Me.cMotivo.HeaderText = "motivo"
        Me.cMotivo.Name = "cMotivo"
        Me.cMotivo.ReadOnly = true
        Me.cMotivo.Visible = false
        '
        'cTelefone
        '
        Me.cTelefone.DataPropertyName = "Telefone"
        Me.cTelefone.HeaderText = "telefone"
        Me.cTelefone.Name = "cTelefone"
        Me.cTelefone.ReadOnly = true
        Me.cTelefone.Visible = false
        '
        'cCelular
        '
        Me.cCelular.DataPropertyName = "celular"
        Me.cCelular.HeaderText = "celular"
        Me.cCelular.Name = "cCelular"
        Me.cCelular.ReadOnly = true
        Me.cCelular.Visible = false
        '
        'cContato
        '
        Me.cContato.DataPropertyName = "PessoaContato"
        Me.cContato.HeaderText = "contato"
        Me.cContato.Name = "cContato"
        Me.cContato.ReadOnly = true
        Me.cContato.Visible = false
        '
        'cEndereco
        '
        Me.cEndereco.DataPropertyName = "endereço"
        Me.cEndereco.HeaderText = "endereco"
        Me.cEndereco.Name = "cEndereco"
        Me.cEndereco.ReadOnly = true
        Me.cEndereco.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cEndereco.Visible = false
        '
        'email
        '
        Me.email.DataPropertyName = "Email"
        Me.email.HeaderText = "E-mail"
        Me.email.Name = "email"
        Me.email.ReadOnly = true
        Me.email.Visible = false
        '
        'gvalorEmAberto
        '
        Me.gvalorEmAberto.DataPropertyName = "ValorEmAberto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0,00"
        Me.gvalorEmAberto.DefaultCellStyle = DataGridViewCellStyle3
        Me.gvalorEmAberto.HeaderText = "Vlr em Aberto"
        Me.gvalorEmAberto.Name = "gvalorEmAberto"
        Me.gvalorEmAberto.ReadOnly = true
        Me.gvalorEmAberto.Width = 105
        '
        'LocacaoClientesProcura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(218,Byte),Integer), CType(CType(201,Byte),Integer), CType(CType(186,Byte),Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(971, 578)
        Me.ControlBox = false
        Me.Controls.Add(Me.Fundo)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.KeyPreview = true
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "LocacaoClientesProcura"
        Me.HelpProvider1.SetShowHelp(Me, true)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Localizar Clientes -Nova Locação"
        Me.Fundo.ResumeLayout(false)
        Me.Fundo.PerformLayout
        Me.PanelEx1.ResumeLayout(false)
        Me.PanelEx1.PerformLayout
        Me.GroupPanel1.ResumeLayout(false)
        Me.GroupPanel1.PerformLayout
        CType(Me.Lista,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents A2 As System.Windows.Forms.RadioButton
    Friend WithEvents A1 As System.Windows.Forms.RadioButton
    Friend WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents A3 As System.Windows.Forms.RadioButton
    Friend WithEvents Lista As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtProcura As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents A4 As System.Windows.Forms.RadioButton
    Friend WithEvents A5 As System.Windows.Forms.RadioButton
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents xEndereço As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents xBloqueado As System.Windows.Forms.CheckBox
    Friend WithEvents xVendaCheque As System.Windows.Forms.CheckBox
    Friend WithEvents xVendaCrediario As System.Windows.Forms.CheckBox
    Friend WithEvents xVendaVista As System.Windows.Forms.CheckBox
    Friend WithEvents xMotivoBloqueado As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents xContato As System.Windows.Forms.Label
    Friend WithEvents xCelular As System.Windows.Forms.Label
    Friend WithEvents xTelefone As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents xCidade As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents xCpfCnpj As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents xCliente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents A3a As System.Windows.Forms.RadioButton
    Friend WithEvents Fechar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents A9 As System.Windows.Forms.RadioButton
    Friend WithEvents A11 As System.Windows.Forms.RadioButton
    Friend WithEvents A10 As System.Windows.Forms.RadioButton
    Friend WithEvents xEmail As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.TextBox
    Friend WithEvents btnCadClientes As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cCodigo As DataGridViewTextBoxColumn
    Friend WithEvents cNome As DataGridViewTextBoxColumn
    Friend WithEvents cFantasia As DataGridViewTextBoxColumn
    Friend WithEvents cCpfCnpj As DataGridViewTextBoxColumn
    Friend WithEvents cCidade As DataGridViewTextBoxColumn
    Friend WithEvents cAvista As DataGridViewCheckBoxColumn
    Friend WithEvents cCheque As DataGridViewCheckBoxColumn
    Friend WithEvents cCrediario As DataGridViewCheckBoxColumn
    Friend WithEvents cBloqueado As DataGridViewCheckBoxColumn
    Friend WithEvents cMotivo As DataGridViewTextBoxColumn
    Friend WithEvents cTelefone As DataGridViewTextBoxColumn
    Friend WithEvents cCelular As DataGridViewTextBoxColumn
    Friend WithEvents cContato As DataGridViewTextBoxColumn
    Friend WithEvents cEndereco As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents gvalorEmAberto As DataGridViewTextBoxColumn
End Class
