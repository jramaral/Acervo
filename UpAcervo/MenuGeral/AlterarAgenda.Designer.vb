<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlterarAgenda
    Inherits  DevComponents.DotNetBar.Office2007Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlterarAgenda))
        Me.novadata = New System.Windows.Forms.DateTimePicker()
        Me.novahora = New System.Windows.Forms.DateTimePicker()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.lblcodigo = New DevComponents.DotNetBar.LabelX()
        Me.cboStatus = New CBOAutoCompleteFocus.CboFocus()
        Me.txtDescricao = New TexBoxFocusNet.TextBoxFocusNet()
        Me.txtAgendarTo = New TexBoxFocusNet.TextBoxFocusNet()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout
        '
        'novadata
        '
        Me.novadata.CalendarFont = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.novadata.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.novadata.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.novadata.Location = New System.Drawing.Point(108, 14)
        Me.novadata.MinDate = New Date(2018, 1, 1, 0, 0, 0, 0)
        Me.novadata.Name = "novadata"
        Me.novadata.Size = New System.Drawing.Size(133, 26)
        Me.novadata.TabIndex = 0
        '
        'novahora
        '
        Me.novahora.CalendarFont = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.novahora.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.novahora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.novahora.Location = New System.Drawing.Point(380, 14)
        Me.novahora.Name = "novahora"
        Me.novahora.ShowUpDown = true
        Me.novahora.Size = New System.Drawing.Size(90, 26)
        Me.novahora.TabIndex = 1
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelX1.Location = New System.Drawing.Point(16, 20)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(56, 23)
        Me.LabelX1.TabIndex = 9
        Me.LabelX1.Text = "Data"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelX2.Location = New System.Drawing.Point(303, 20)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(56, 18)
        Me.LabelX2.TabIndex = 8
        Me.LabelX2.Text = "Hora"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = CType(resources.GetObject("ButtonX1.Image"),System.Drawing.Image)
        Me.ButtonX1.Location = New System.Drawing.Point(111, 217)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(94, 30)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 5
        Me.ButtonX1.Text = "Confirmar"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = CType(resources.GetObject("ButtonX2.Image"),System.Drawing.Image)
        Me.ButtonX2.Location = New System.Drawing.Point(211, 217)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(105, 30)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 6
        Me.ButtonX2.Text = "Cancelar"
        '
        'lblcodigo
        '
        '
        '
        '
        Me.lblcodigo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblcodigo.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblcodigo.Location = New System.Drawing.Point(413, 226)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(57, 18)
        Me.lblcodigo.TabIndex = 7
        Me.lblcodigo.Text = "Hora"
        Me.lblcodigo.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'cboStatus
        '
        Me.cboStatus.Auto_Complete = true
        Me.cboStatus.AutoLimitar_Lista = true
        Me.cboStatus.BloquearCx = CBOAutoCompleteFocus.CboFocus.Bloquear.Não
        Me.cboStatus.CPObrigatorio = false
        Me.cboStatus.CPObrigatorioMsg = Nothing
        Me.cboStatus.FlatBorder = true
        Me.cboStatus.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboStatus.Font = New System.Drawing.Font("Comic Sans MS", 8.25!)
        Me.cboStatus.FormattingEnabled = true
        Me.cboStatus.HighlightBorderColor = System.Drawing.Color.Empty
        Me.cboStatus.HighlightBorderOnEnter = false
        Me.cboStatus.Items.AddRange(New Object() {"(Nenhum)", "Entregar", "Retirar"})
        Me.cboStatus.Location = New System.Drawing.Point(108, 79)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(362, 23)
        Me.cboStatus.TabIndex = 3
        '
        'txtDescricao
        '
        Me.txtDescricao.AceitaColarTexto = false
        Me.txtDescricao.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtDescricao.CasasDecimais = 0
        Me.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescricao.CPObrigatorio = false
        Me.txtDescricao.CPObrigatorioMsg = Nothing
        Me.txtDescricao.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtDescricao.FlatBorder = false
        Me.txtDescricao.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtDescricao.FocusColor = System.Drawing.Color.MistyRose
        Me.txtDescricao.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtDescricao.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDescricao.HighlightBorderOnEnter = false
        Me.txtDescricao.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtDescricao.Location = New System.Drawing.Point(108, 108)
        Me.txtDescricao.MaxLength = 250
        Me.txtDescricao.Multiline = true
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.PreencherZeroEsqueda = false
        Me.txtDescricao.RegraValidação = ""
        Me.txtDescricao.RegraValidaçãoMensagem = ""
        Me.txtDescricao.Size = New System.Drawing.Size(362, 94)
        Me.txtDescricao.TabIndex = 4
        Me.txtDescricao.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtDescricao.ValorPadrao = Nothing
        '
        'txtAgendarTo
        '
        Me.txtAgendarTo.AceitaColarTexto = false
        Me.txtAgendarTo.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.txtAgendarTo.CasasDecimais = 0
        Me.txtAgendarTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAgendarTo.CPObrigatorio = false
        Me.txtAgendarTo.CPObrigatorioMsg = Nothing
        Me.txtAgendarTo.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.txtAgendarTo.FlatBorder = false
        Me.txtAgendarTo.FlatBorderColor = System.Drawing.Color.DimGray
        Me.txtAgendarTo.FocusColor = System.Drawing.Color.MistyRose
        Me.txtAgendarTo.FocusColorEnd = System.Drawing.Color.Empty
        Me.txtAgendarTo.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtAgendarTo.HighlightBorderOnEnter = false
        Me.txtAgendarTo.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.txtAgendarTo.Location = New System.Drawing.Point(108, 46)
        Me.txtAgendarTo.MaxLength = 150
        Me.txtAgendarTo.Multiline = true
        Me.txtAgendarTo.Name = "txtAgendarTo"
        Me.txtAgendarTo.PreencherZeroEsqueda = false
        Me.txtAgendarTo.RegraValidação = ""
        Me.txtAgendarTo.RegraValidaçãoMensagem = ""
        Me.txtAgendarTo.Size = New System.Drawing.Size(362, 27)
        Me.txtAgendarTo.TabIndex = 2
        Me.txtAgendarTo.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.txtAgendarTo.ValorPadrao = Nothing
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelX4.Location = New System.Drawing.Point(16, 108)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(72, 23)
        Me.LabelX4.TabIndex = 10
        Me.LabelX4.Text = "Descrição"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelX5.Location = New System.Drawing.Point(16, 79)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(86, 23)
        Me.LabelX5.TabIndex = 11
        Me.LabelX5.Text = "Status"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelX3.Location = New System.Drawing.Point(16, 50)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(86, 23)
        Me.LabelX3.TabIndex = 12
        Me.LabelX3.Text = "Agendar para"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelX6.Location = New System.Drawing.Point(380, 226)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(22, 18)
        Me.LabelX6.TabIndex = 13
        Me.LabelX6.Text = "ID:"
        Me.LabelX6.TextLineAlignment = System.Drawing.StringAlignment.Far
        '
        'AlterarAgenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 256)
        Me.ControlBox = false
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtAgendarTo)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.lblcodigo)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.novahora)
        Me.Controls.Add(Me.novadata)
        Me.DoubleBuffered = true
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "AlterarAgenda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alterar Agenda"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents novadata As DateTimePicker
    Friend WithEvents novahora As DateTimePicker
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblcodigo As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboStatus As CBOAutoCompleteFocus.CboFocus
    Friend WithEvents txtDescricao As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents txtAgendarTo As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
End Class
