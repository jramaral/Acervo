﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CentroCustoNewRelat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CentroCustoNewRelat))
        Me.Fundo = New DevComponents.DotNetBar.PanelEx()
        Me.btVisualizar = New DevComponents.DotNetBar.ButtonX()
        Me.btFechar = New DevComponents.DotNetBar.ButtonX()
        Me.PainelContaReceitaDespesa = New System.Windows.Forms.Panel()
        Me.Nivel3 = New System.Windows.Forms.RadioButton()
        Me.Nivel2 = New System.Windows.Forms.RadioButton()
        Me.Nivel1 = New System.Windows.Forms.RadioButton()
        Me.ContaCC = New TexBoxFocusNet.TextBoxFocusNet()
        Me.btFindCC = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ContaCCDesc = New TexBoxFocusNet.TextBoxFocusNet()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.A2 = New System.Windows.Forms.RadioButton()
        Me.A1 = New System.Windows.Forms.RadioButton()
        Me.PainelPeriodo = New System.Windows.Forms.Panel()
        Me.DataFinal = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DataInicial = New TexBoxFocusNet.TextBoxFocusNet()
        Me.Fundo.SuspendLayout()
        Me.PainelContaReceitaDespesa.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PainelPeriodo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fundo
        '
        Me.Fundo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Fundo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.Fundo.Controls.Add(Me.btVisualizar)
        Me.Fundo.Controls.Add(Me.btFechar)
        Me.Fundo.Controls.Add(Me.PainelContaReceitaDespesa)
        Me.Fundo.Controls.Add(Me.GroupBox1)
        Me.Fundo.Controls.Add(Me.PainelPeriodo)
        Me.Fundo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fundo.Location = New System.Drawing.Point(0, 0)
        Me.Fundo.Name = "Fundo"
        Me.Fundo.Size = New System.Drawing.Size(737, 221)
        Me.Fundo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Fundo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Fundo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Fundo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Fundo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Fundo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Fundo.Style.GradientAngle = 90
        Me.Fundo.TabIndex = 0
        '
        'btVisualizar
        '
        Me.btVisualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btVisualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btVisualizar.Location = New System.Drawing.Point(563, 181)
        Me.btVisualizar.Name = "btVisualizar"
        Me.btVisualizar.Size = New System.Drawing.Size(84, 28)
        Me.btVisualizar.TabIndex = 3
        Me.btVisualizar.Text = "Visualizar"
        '
        'btFechar
        '
        Me.btFechar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btFechar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btFechar.Location = New System.Drawing.Point(653, 181)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(72, 28)
        Me.btFechar.TabIndex = 4
        Me.btFechar.Text = "Fechar"
        '
        'PainelContaReceitaDespesa
        '
        Me.PainelContaReceitaDespesa.Controls.Add(Me.Nivel3)
        Me.PainelContaReceitaDespesa.Controls.Add(Me.Nivel2)
        Me.PainelContaReceitaDespesa.Controls.Add(Me.Nivel1)
        Me.PainelContaReceitaDespesa.Controls.Add(Me.ContaCC)
        Me.PainelContaReceitaDespesa.Controls.Add(Me.btFindCC)
        Me.PainelContaReceitaDespesa.Controls.Add(Me.Label7)
        Me.PainelContaReceitaDespesa.Controls.Add(Me.ContaCCDesc)
        Me.PainelContaReceitaDespesa.Location = New System.Drawing.Point(275, 46)
        Me.PainelContaReceitaDespesa.Name = "PainelContaReceitaDespesa"
        Me.PainelContaReceitaDespesa.Size = New System.Drawing.Size(459, 55)
        Me.PainelContaReceitaDespesa.TabIndex = 2
        Me.PainelContaReceitaDespesa.Visible = False
        '
        'Nivel3
        '
        Me.Nivel3.AutoSize = True
        Me.Nivel3.Checked = True
        Me.Nivel3.Location = New System.Drawing.Point(328, 6)
        Me.Nivel3.Name = "Nivel3"
        Me.Nivel3.Size = New System.Drawing.Size(57, 17)
        Me.Nivel3.TabIndex = 5
        Me.Nivel3.TabStop = True
        Me.Nivel3.Tag = "3"
        Me.Nivel3.Text = "Nivel 3"
        Me.Nivel3.UseVisualStyleBackColor = True
        '
        'Nivel2
        '
        Me.Nivel2.AutoSize = True
        Me.Nivel2.Location = New System.Drawing.Point(265, 6)
        Me.Nivel2.Name = "Nivel2"
        Me.Nivel2.Size = New System.Drawing.Size(57, 17)
        Me.Nivel2.TabIndex = 4
        Me.Nivel2.Tag = "2"
        Me.Nivel2.Text = "Nivel 2"
        Me.Nivel2.UseVisualStyleBackColor = True
        '
        'Nivel1
        '
        Me.Nivel1.AutoSize = True
        Me.Nivel1.Location = New System.Drawing.Point(202, 7)
        Me.Nivel1.Name = "Nivel1"
        Me.Nivel1.Size = New System.Drawing.Size(57, 17)
        Me.Nivel1.TabIndex = 3
        Me.Nivel1.Tag = "1"
        Me.Nivel1.Text = "Nivel 1"
        Me.Nivel1.UseVisualStyleBackColor = True
        '
        'ContaCC
        '
        Me.ContaCC.AceitaColarTexto = True
        Me.ContaCC.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.ContaCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContaCC.CasasDecimais = 0
        Me.ContaCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContaCC.CPObrigatorio = False
        Me.ContaCC.CPObrigatorioMsg = Nothing
        Me.ContaCC.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ContaCC.FlatBorder = True
        Me.ContaCC.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ContaCC.FocusColor = System.Drawing.Color.Empty
        Me.ContaCC.FocusColorEnd = System.Drawing.Color.Empty
        Me.ContaCC.GlowColor = System.Drawing.Color.Navy
        Me.ContaCC.HighlightBorderOnEnter = False
        Me.ContaCC.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ContaCC.Location = New System.Drawing.Point(113, 4)
        Me.ContaCC.MaxLength = 6
        Me.ContaCC.Name = "ContaCC"
        Me.ContaCC.PreencherZeroEsqueda = True
        Me.ContaCC.RegraValidação = Nothing
        Me.ContaCC.RegraValidaçãoMensagem = Nothing
        Me.ContaCC.Size = New System.Drawing.Size(57, 21)
        Me.ContaCC.TabIndex = 1
        Me.ContaCC.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ContaCC.ValorPadrao = Nothing
        '
        'btFindCC
        '
        Me.btFindCC.Image = CType(resources.GetObject("btFindCC.Image"), System.Drawing.Image)
        Me.btFindCC.Location = New System.Drawing.Point(176, 4)
        Me.btFindCC.Name = "btFindCC"
        Me.btFindCC.Size = New System.Drawing.Size(20, 23)
        Me.btFindCC.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(7, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Informe a Conta"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContaCCDesc
        '
        Me.ContaCCDesc.AceitaColarTexto = True
        Me.ContaCCDesc.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.ContaCCDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContaCCDesc.CasasDecimais = 0
        Me.ContaCCDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContaCCDesc.CPObrigatorio = False
        Me.ContaCCDesc.CPObrigatorioMsg = Nothing
        Me.ContaCCDesc.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.ContaCCDesc.FlatBorder = True
        Me.ContaCCDesc.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ContaCCDesc.FocusColor = System.Drawing.Color.Empty
        Me.ContaCCDesc.FocusColorEnd = System.Drawing.Color.Empty
        Me.ContaCCDesc.GlowColor = System.Drawing.Color.Navy
        Me.ContaCCDesc.HighlightBorderOnEnter = False
        Me.ContaCCDesc.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.ContaCCDesc.Location = New System.Drawing.Point(113, 30)
        Me.ContaCCDesc.MaxLength = 50
        Me.ContaCCDesc.Name = "ContaCCDesc"
        Me.ContaCCDesc.PreencherZeroEsqueda = False
        Me.ContaCCDesc.RegraValidação = Nothing
        Me.ContaCCDesc.RegraValidaçãoMensagem = Nothing
        Me.ContaCCDesc.Size = New System.Drawing.Size(343, 21)
        Me.ContaCCDesc.TabIndex = 6
        Me.ContaCCDesc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
        Me.ContaCCDesc.ValorPadrao = Nothing
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.A2)
        Me.GroupBox1.Controls.Add(Me.A1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 119)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecione a Opção"
        '
        'A2
        '
        Me.A2.AutoSize = True
        Me.A2.ForeColor = System.Drawing.Color.Black
        Me.A2.Location = New System.Drawing.Point(6, 42)
        Me.A2.Name = "A2"
        Me.A2.Size = New System.Drawing.Size(183, 17)
        Me.A2.TabIndex = 1
        Me.A2.TabStop = True
        Me.A2.Text = "Centro Custo Analítico por Conta"
        Me.A2.UseVisualStyleBackColor = True
        '
        'A1
        '
        Me.A1.AutoSize = True
        Me.A1.ForeColor = System.Drawing.Color.Black
        Me.A1.Location = New System.Drawing.Point(6, 19)
        Me.A1.Name = "A1"
        Me.A1.Size = New System.Drawing.Size(132, 17)
        Me.A1.TabIndex = 0
        Me.A1.TabStop = True
        Me.A1.Text = "Centro Custo Analítico"
        Me.A1.UseVisualStyleBackColor = True
        '
        'PainelPeriodo
        '
        Me.PainelPeriodo.Controls.Add(Me.DataFinal)
        Me.PainelPeriodo.Controls.Add(Me.Label9)
        Me.PainelPeriodo.Controls.Add(Me.DataInicial)
        Me.PainelPeriodo.Location = New System.Drawing.Point(275, 12)
        Me.PainelPeriodo.Name = "PainelPeriodo"
        Me.PainelPeriodo.Size = New System.Drawing.Size(459, 28)
        Me.PainelPeriodo.TabIndex = 1
        Me.PainelPeriodo.Visible = False
        '
        'DataFinal
        '
        Me.DataFinal.AceitaColarTexto = True
        Me.DataFinal.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DataFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataFinal.CasasDecimais = 0
        Me.DataFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataFinal.CPObrigatorio = False
        Me.DataFinal.CPObrigatorioMsg = Nothing
        Me.DataFinal.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataFinal.FlatBorder = True
        Me.DataFinal.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataFinal.FocusColor = System.Drawing.Color.Empty
        Me.DataFinal.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataFinal.GlowColor = System.Drawing.Color.Navy
        Me.DataFinal.HighlightBorderOnEnter = False
        Me.DataFinal.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataFinal.Location = New System.Drawing.Point(219, 3)
        Me.DataFinal.MaxLength = 10
        Me.DataFinal.Name = "DataFinal"
        Me.DataFinal.PreencherZeroEsqueda = False
        Me.DataFinal.RegraValidação = Nothing
        Me.DataFinal.RegraValidaçãoMensagem = Nothing
        Me.DataFinal.Size = New System.Drawing.Size(100, 21)
        Me.DataFinal.TabIndex = 2
        Me.DataFinal.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataFinal.ValorPadrao = Nothing
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Informe o Período"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataInicial
        '
        Me.DataInicial.AceitaColarTexto = True
        Me.DataInicial.BloquearCx = TexBoxFocusNet.TextBoxFocusNet.Bloquear.Não
        Me.DataInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataInicial.CasasDecimais = 0
        Me.DataInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DataInicial.CPObrigatorio = False
        Me.DataInicial.CPObrigatorioMsg = Nothing
        Me.DataInicial.EntrouCaixa = TexBoxFocusNet.TextBoxFocusNet.CaixaEntrou.Não
        Me.DataInicial.FlatBorder = True
        Me.DataInicial.FlatBorderColor = System.Drawing.Color.DimGray
        Me.DataInicial.FocusColor = System.Drawing.Color.Empty
        Me.DataInicial.FocusColorEnd = System.Drawing.Color.Empty
        Me.DataInicial.GlowColor = System.Drawing.Color.Navy
        Me.DataInicial.HighlightBorderOnEnter = False
        Me.DataInicial.HighlightBorderOnEnterColor = System.Drawing.Color.DimGray
        Me.DataInicial.Location = New System.Drawing.Point(113, 3)
        Me.DataInicial.MaxLength = 10
        Me.DataInicial.Name = "DataInicial"
        Me.DataInicial.PreencherZeroEsqueda = False
        Me.DataInicial.RegraValidação = Nothing
        Me.DataInicial.RegraValidaçãoMensagem = Nothing
        Me.DataInicial.Size = New System.Drawing.Size(100, 21)
        Me.DataInicial.TabIndex = 1
        Me.DataInicial.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Data
        Me.DataInicial.ValorPadrao = Nothing
        '
        'CentroCustoNewRelat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 221)
        Me.ControlBox = False
        Me.Controls.Add(Me.Fundo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CentroCustoNewRelat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatórios de Centro de Custo - T289"
        Me.Fundo.ResumeLayout(False)
        Me.PainelContaReceitaDespesa.ResumeLayout(False)
        Me.PainelContaReceitaDespesa.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PainelPeriodo.ResumeLayout(False)
        Me.PainelPeriodo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Fundo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents A1 As System.Windows.Forms.RadioButton
    Friend WithEvents PainelPeriodo As System.Windows.Forms.Panel
    Friend WithEvents DataFinal As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataInicial As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents A2 As System.Windows.Forms.RadioButton
    Friend WithEvents PainelContaReceitaDespesa As System.Windows.Forms.Panel
    Friend WithEvents ContaCC As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents btFindCC As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ContaCCDesc As TexBoxFocusNet.TextBoxFocusNet
    Friend WithEvents Nivel3 As System.Windows.Forms.RadioButton
    Friend WithEvents Nivel2 As System.Windows.Forms.RadioButton
    Friend WithEvents Nivel1 As System.Windows.Forms.RadioButton
    Private WithEvents btVisualizar As DevComponents.DotNetBar.ButtonX
    Private WithEvents btFechar As DevComponents.DotNetBar.ButtonX
End Class
