
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text
Imports System.Threading
Imports Agendamento
Imports ClassView
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Rendering
Imports DevComponents.DotNetBar.Schedule
Imports ExecProgram


Public Class MenuGeral
    Private TRD As Thread

    Dim Dt As DataTable
    Dim DtOrdemCompra As DataTable

    Dim NomeBot�o As String = ""
    Dim mouseBarraRapida As Double
    Dim Posi��oIcone As Boolean
    Dim ItensMenuRapido As String

    Dim Img1 As Bitmap
    Dim Img2 As Bitmap
    Dim Img3 As Bitmap
    Dim Img4 As Bitmap
    Dim Img5 As Bitmap
    Dim Img6 As Bitmap
    Dim Img7 As Bitmap
    Dim ImgAtalho As Bitmap
    Dim m_AlertOnLoad As Balloon
    Private Sub ShowLoadAlert(control As DataGridView)

        If Not IsNothing(m_AlertOnLoad) Then
            m_AlertOnLoad.Dispose()
        End If

        Dim texto1 = control.CurrentRow.Cells(0).Value
        Dim texto2 = control.CurrentRow.Cells(5).Value & " " & control.CurrentRow.Cells(4).Value
        Dim texto3 = control.CurrentRow.Cells(7).Value

        m_AlertOnLoad = New Alert(texto1, texto2, texto3)


        Dim r As Rectangle = Screen.GetWorkingArea(Me)
        m_AlertOnLoad.Location = New Point(MousePosition.X - 50, MousePosition.Y)
        m_AlertOnLoad.CaptionText = "Agendamento"
        m_AlertOnLoad.AutoClose = True
        m_AlertOnLoad.AutoCloseTimeOut = 3
        m_AlertOnLoad.ShowCloseButton = False
        m_AlertOnLoad.AlertAnimation = eAlertAnimation.LeftToRight
        m_AlertOnLoad.AlertAnimationDuration = 200

        m_AlertOnLoad.Show(True)
    End Sub

    Public Sub AtualizarAgenda()
        Dim THRD As New Thread(AddressOf AtualizaGridDia)
        THRD.Priority = ThreadPriority.Highest
        THRD.IsBackground = True
        THRD.Start()
    End Sub


    Public Sub AtualizaGridCor(ByRef data As DataGridView, ByVal namecol As String)
        For Each linha As DataGridViewRow In data.Rows
            If linha.Cells(namecol).Value.ToString().Contains("Entregar") Then
                linha.DefaultCellStyle.BackColor = Color.ForestGreen
            ElseIf linha.Cells(namecol).Value.ToString().Contains("Retirar") Then
                linha.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Public Sub AtualizaGridDia()

        Dim c = New Compromisso()
        Dim lista = c.Listar()

        Dim listaDom = From d In lista Where d.Tag = "DOMINGO" And d.DataCompromisso = lbldomingo.Text Select d
        Dim listaSeg = From d In lista Where d.Tag = "SEGUNDA" And d.DataCompromisso = lblsegunda.Text Select d
        Dim listaTer = From d In lista Where d.Tag = "TER�A" And d.DataCompromisso = lblterca.Text Select d
        Dim listaQua = From d In lista Where d.Tag = "QUARTA" And d.DataCompromisso = lblquarta.Text Select d
        Dim listaQui = From d In lista Where d.Tag = "QUINTA" And d.DataCompromisso = lblquinta.Text Select d
        Dim listaSex = From d In lista Where d.Tag = "SEXTA" And d.DataCompromisso = lblsexta.Text Select d
        Dim listaSab = From d In lista Where d.Tag = "S�BADO" And d.DataCompromisso = lblsabado.Text Select d

        dgvDom.DataSource = listaDom.ToList()
        dgvSeg.DataSource = listaSeg.ToList()
        dgvTer.DataSource = listaTer.ToList()
        dgvQua.DataSource = listaQua.ToList()
        dgvQui.DataSource = listaQui.ToList()
        dgvSex.DataSource = listaSex.ToList()
        dgvSab.DataSource = listaSab.ToList()

        'atualiza as cores
        AtualizaGridCor(dgvDom, "gstatus1")
        AtualizaGridCor(dgvSeg, "gstatus2")
        AtualizaGridCor(dgvTer, "gstatus3")
        AtualizaGridCor(dgvQua, "gstatus4")
        AtualizaGridCor(dgvQui, "gstatus5")
        AtualizaGridCor(dgvSex, "gstatus6")
        AtualizaGridCor(dgvSab, "gstatus7")

        Try
            dgvDom.CurrentCell.Selected = False
        Catch ex As Exception
        End Try
        Try
            dgvSeg.CurrentCell.Selected = False
        Catch ex As Exception
        End Try
        Try
            dgvTer.CurrentCell.Selected = False
        Catch ex As Exception
        End Try
        Try
            dgvQua.CurrentCell.Selected = False
        Catch ex As Exception
        End Try
        Try
            dgvQui.CurrentCell.Selected = False
        Catch ex As Exception
        End Try
        Try
            dgvSex.CurrentCell.Selected = False
        Catch ex As Exception
        End Try
        Try
            dgvSab.CurrentCell.Selected = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AtualizaDia()
        Dim d1 = CalendarView1.WeekViewStartDate.ToShortDateString()
        Dim d2 = DateTime.Parse(d1).AddDays(1).ToShortDateString()
        Dim d3 = DateTime.Parse(d2).AddDays(1).ToShortDateString()
        Dim d4 = DateTime.Parse(d3).AddDays(1).ToShortDateString()
        Dim d5 = DateTime.Parse(d4).AddDays(1).ToShortDateString()
        Dim d6 = DateTime.Parse(d5).AddDays(1).ToShortDateString()
        Dim d7 = CalendarView1.WeekViewEndDate.ToShortDateString()

        lbldomingo.Text = d1
        lblsegunda.Text = d2
        lblterca.Text = d3
        lblquarta.Text = d4
        lblquinta.Text = d5
        lblsexta.Text = d6
        lblsabado.Text = d7
    End Sub

    Private Sub FMenuGeral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CalendarView1.SelectedView = eCalendarView.Week

        AtualizaDia()
        AtualizaGridDia()

        'btCoresPersonalizadas.SelectedColor = Color.Blue
        'If TSesquema = False Then
        '    btCoresPersonalizadas.Enabled = True
        '    RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(Me, eOffice2007ColorScheme.Silver, Color.CadetBlue)
        'Else
        '    btCoresPersonalizadas.Enabled = False
        '    RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(Me, eOffice2007ColorScheme.Silver, Color.Black)
        'End If

        Select Case mMenuCarregar
            Case ""
                Me.MenuDisplay.Visible = True
            Case "MenuDisplay"
                TRVDados(UserAtivo, "MenuDisplay")
                If Ina = True Then
                    Me.MenuDisplay.Visible = False
                    ' MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
                    Exit Sub
                Else
                    'My.Forms.ProcuraProduto.ShowDialog()
                End If


                Me.MenuDisplay.Visible = True

                Me.MenuRibbon.SelectedRibbonTabItem = Me.mnu_rapido
                Me.mnu_rapido.Visible = True
            Case "MenuVendaShoes"
                Me.MenuRibbon.Visible = True
                Me.mnu_rapido.Visible = False

        End Select


        TamanhoTela = Screen.GetWorkingArea(Me)

        'Task.Factory.StartNew(sub()VerAgendaServi�o)

        'VerAgendaServi�o()

        Dim trd As Thread

        trd = New Thread(AddressOf ThreadTask)
        trd.IsBackground = True
        trd.Start()


        Me.Text = "Menu Geral - " & CodEmpresa & "-" & NomEmpresa & " - Data de Trabalho: " & DataDia & " - Usu�rio: " &
                  UserAtivo & "- v." & verVersao
        Me.DisplayCaixaAtivo.Text = "Caixa Ativo: " & CaixaAtivo

        Try
            AtualizarSystem()

        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
    End Sub

    Private Sub ThreadTask()
        UF_Preencher()
        CofinsCST_Preencher()
        IcmsCST_Preencher()
        IpiCST_Preencher()
        PisCST_Preencher()
        OrigemIcms_Preencher()
        IcmsModalidadeBC_Preencher()
        oDtCFOP()
    End Sub

    Private Sub ClientesToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles ClientesToolStripMenuItem1.Click
        TRVDados(UserAtivo, "Clientes")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Clientes.ShowDialog()
        End If
    End Sub

    Private Sub ProdutosToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "Produtos")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Produtos.ShowDialog()
        End If
    End Sub

    Private Sub FornecedoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles FornecedoresToolStripMenuItem1.Click
        TRVDados(UserAtivo, "Fornecedor")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Fornecedor.ShowDialog()
        End If
    End Sub

    Private Sub GruposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GruposToolStripMenuItem.Click
        TRVDados(UserAtivo, "Grupos")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Grupos.ShowDialog()
        End If
    End Sub

    Private Sub MarcasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcasToolStripMenuItem.Click
        TRVDados(UserAtivo, "Marcas")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Marcas.ShowDialog()
        End If
    End Sub

    Private Sub Hist�ricosDeDocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Hist�ricosDeDocumentosToolStripMenuItem.Click
        TRVDados(UserAtivo, "HistoricoPgtoReceb")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.HistoricoPgtoReceb.ShowDialog()
        End If
    End Sub

    Private Sub TransportadoraToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles TransportadoraToolStripMenuItem.Click
        TRVDados(UserAtivo, "Transportadora")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Transportadora.ShowDialog()
        End If
    End Sub

    Private Sub EmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpresaToolStripMenuItem.Click
        TRVDados(UserAtivo, "Empresa")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Empresa.ShowDialog()
        End If
    End Sub

    Private Sub CFOPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CFOPToolStripMenuItem.Click
        TRVDados(UserAtivo, "Cfop")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Cfop.ShowDialog()
        End If
    End Sub

    Private Sub ConsultaBaixaDeContasARceberToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ConsultaBaixaDeContasARceberToolStripMenuItem.Click
        TRVDados(UserAtivo, "Receber")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Receber.ShowDialog()
        End If
    End Sub

    Private Sub Relat�rioDeContasAReceberToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles Relat�rioDeContasAReceberToolStripMenuItem1.Click
        TRVDados(UserAtivo, "ReceberRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ReceberRelat.ShowDialog()
        End If
    End Sub

    Private Sub ConsultaBaixaDeContasAPagarToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ConsultaBaixaDeContasAPagarToolStripMenuItem.Click
        TRVDados(UserAtivo, "Pagar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Pagar.ShowDialog()
        End If
    End Sub

    Private Sub SenhaEUsu�rioToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SenhaEUsu�rioToolStripMenuItem.Click

        'Dim HH As DateTime = Now
        'Dim CodSeguran�a As String = InformaCodigoSeguranca()

        'If VerificaCodigoSeguran�a(CodSeguran�a) = False Then
        '    MsgBox("C�digo de Seguran�a inv�lido, Verifique.", 64, "Valida��o de Dados")
        '    Exit Sub
        'End If

        My.Forms.UserSenha.ShowDialog()
    End Sub

    Private Sub Configura��oDoBancoDeDadosAlternarToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Configura��oDoBancoDeDadosAlternarToolStripMenuItem.Click
        TRVDados(UserAtivo, "Cfg")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CFG.ShowDialog()
        End If
    End Sub

    Private Sub SobreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SobreToolStripMenuItem.Click
        My.Forms.Sobre.ShowDialog()
    End Sub

    Private Sub RelatorioDeContasAPagarToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles RelatorioDeContasAPagarToolStripMenuItem.Click
        TRVDados(UserAtivo, "PagarRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PagarRelat.ShowDialog()
        End If
    End Sub

    Private Sub CancelamentoDePedidoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "PedidoCancelamento")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PedidoCancelamentoOS.ShowDialog()
        End If
    End Sub

    Private Sub Reimpress�oDoPedidoVendaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "PedidoReImpress")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PedidoReImpress.ShowDialog()
        End If
    End Sub

    Private Sub PedidoToolStripMenuItem_Click(sender As Object, e As EventArgs)

        If UsaSellShoes = True Then
            TRVDados(UserAtivo, "SellShoesAutenticacao")
            If Ina = True Then
                MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
                Exit Sub
            Else
                My.Forms.SellShoesAutenticacao.ShowDialog()
            End If
        Else
            TRVDados(UserAtivo, "SellShoesAutenticacao")
            If Ina = True Then
                MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
                Exit Sub
            Else
                My.Forms.SellShoesAutenticacao.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ConsultarVendasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "PedidoVendaFaturamento")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PedidoVendaFaturamento.ShowDialog()
        End If
    End Sub

    Private Sub Funcion�riosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Funcion�riosToolStripMenuItem.Click
        TRVDados(UserAtivo, "Funcionarios")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Funcionarios.ShowDialog()
        End If
    End Sub

    Private Sub DepartamentosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles DepartamentosToolStripMenuItem.Click
        TRVDados(UserAtivo, "Departamentos")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Departamentos.ShowDialog()
        End If
    End Sub

    Private Sub Profiss�oToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Profiss�oToolStripMenuItem.Click
        TRVDados(UserAtivo, "Profissao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Profissao.ShowDialog()
        End If
    End Sub

    Private Sub Funcion�riosToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles Funcion�riosToolStripMenuItem1.Click
        TRVDados(UserAtivo, "FuncionariosRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.FuncionariosRelat.ShowDialog()
        End If
    End Sub

    Private Sub DepartamentosToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles DepartamentosToolStripMenuItem1.Click
        TRVDados(UserAtivo, "RelDepartamentos")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            RelatorioCarregar = "RelDepartamentos"
            My.Forms.VisualizadorRelatorio.ShowDialog()
        End If
    End Sub

    Private Sub Profiss�oToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles Profiss�oToolStripMenuItem1.Click
        TRVDados(UserAtivo, "RelProfiss�o")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            RelatorioCarregar = "RelProfiss�o"
            My.Forms.VisualizadorRelatorio.ShowDialog()
        End If
    End Sub

    Private Sub ReciboAvulsoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ReciboAvulsoToolStripMenuItem.Click
        TRVDados(UserAtivo, "ReciboAvulso")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ReciboAvulso.ShowDialog()
        End If
    End Sub

    Private Sub Or�amentosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesOrcamentoProcura")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesOrcamentoProcura.ShowDialog()
        End If
        'TRVDados(UserAtivo, "Or�amento")
        'If Ina = True Then
        ' MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
        ' Exit Sub
        ' Else
        ' My.Forms.Or�amento.ShowDialog()
        ' End If
    End Sub

    Private Sub VisualizadorDoCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles VisualizadorDoCaixaToolStripMenuItem.Click
        TRVDados(UserAtivo, "Caixa")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Caixa.ShowDialog()
        End If
    End Sub

    Private Sub CentralContaCorrenteToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CentralContaCorrenteToolStripMenuItem.Click
        TRVDados(UserAtivo, "BancoVisualizador")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.BancoVisualizador.ShowDialog()
        End If
    End Sub

    Private Sub MenuGeral_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.MaximizeBox = True
    End Sub

    Private Sub ChequePreClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ChequePreClientesToolStripMenuItem.Click
        TRVDados(UserAtivo, "ChequePreClientes")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else

            If Len(CaixaAtivo) <> 4 Then
                MessageBox.Show("O usuario deve selecionar um caixa antes de executar esta opera��o. Verifique",
                                "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("Deseja Ativar o caixa agora", 36, "Valida��o de Dados") = 6 Then
                    TRVDados(UserAtivo, "CaixaAtivarDesativar")
                    If Ina = True Then
                        MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
                        Exit Sub
                    Else
                        My.Forms.CaixaAtivarDesativar.ShowDialog()
                        ChequePreClientesToolStripMenuItem_Click(sender, e)
                    End If
                End If
                Exit Sub
            End If

            My.Forms.ChequePreClientes.ShowDialog()

        End If
    End Sub

    Private Sub ClienteEtiquetasNatalToolStripMenuItem_Click(sender As Object, e As EventArgs)
        RelatorioCarregar = "RelEtiquetaNatal"
        My.Forms.VisualizadorRelatorio.ShowDialog()
    End Sub

    Private Sub NotaFiscalDeServi�oToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "NFiscalServi�o")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.NFiscalServi�o.ShowDialog()
        End If
    End Sub

    Private Sub Configura��oDaNotaFiscalDeServi�oToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "NFCFGServi�o")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.NFCFGServi�o.ShowDialog()
        End If
    End Sub

    Private Sub RelatoriosDeVendasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "PedidoRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PedidoRelat.ShowDialog()
        End If
    End Sub

    Private Sub ContasAReceberNoPer�odoEValorToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ContasAReceberNoPer�odoEValorToolStripMenuItem.Click
        TRVDados(UserAtivo, "ReceberRelatPeriodoValor")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ReceberRelatPeriodoValor.ShowDialog()
        End If
    End Sub

    Private Sub Relat�riosToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles Relat�riosToolStripMenuItem1.Click
        TRVDados(UserAtivo, "ProdutoRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutoRelat.ShowDialog()
        End If
    End Sub

    Private Sub TipoDeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "TipoSolicita��o")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.TipoSolicita��o.ShowDialog()
        End If
    End Sub

    Private Sub ConsultaCepToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ConsultaCepToolStripMenuItem.Click
        My.Forms.CepLocalizar.ShowDialog()
    End Sub

    Private Sub ComprasOutrasEntradasToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ComprasOutrasEntradasToolStripMenuItem.Click
        TRVDados(UserAtivo, "Compra")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Compra.ShowDialog()
        End If
    End Sub



    Private Sub Relat�riosToolStripMenuItem6_Click(sender As Object, e As EventArgs) _
        Handles Relat�riosToolStripMenuItem6.Click
        TRVDados(UserAtivo, "ChequePreRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ChequePreRelat.ShowDialog()
        End If
    End Sub

    Private Sub Relat�riosToolStripMenuItem7_Click(sender As Object, e As EventArgs) _
        Handles Relat�riosToolStripMenuItem7.Click
        TRVDados(UserAtivo, "CaixaRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CaixaRelat.ShowDialog()
        End If
    End Sub

    Private Sub GerarC�digoDeSeguran�aDoDiaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles GerarC�digoDeSeguran�aDoDiaToolStripMenuItem.Click
        TRVDados(UserAtivo, "CodigoSeguran�a")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CodigoSeguran�a.ShowDialog()
        End If
    End Sub

    Private Sub AcompanhamentoDePedidoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "PedidoStatusAndamento")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PedidoStatusAndamento.ShowDialog()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs)
        Try
            Using cn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

                Dim Sql As String =
                        "SELECT Receber.Vencimento, Sum(Receber.ValorDocumento) AS SomaDeValorDocumento FROM(Receber) WHERE Receber.Empresa = " &
                        CodEmpresa &
                        " and Receber.Baixado = False And Receber.Inativo = False And Receber.ContaPerdida = False GROUP BY Receber.Vencimento HAVING Receber.Vencimento <= Date() ORDER BY Receber.Vencimento DESC"

                Dim cmd = New OleDbCommand(Sql, cn)
                Dt = New DataTable("LSTRECEBER")

                Dim DA = New OleDbDataAdapter(cmd)
                DA.Fill(Dt)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorToolStripMenuItem.Click
        TRVDados(UserAtivo, "Cor")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Cor.ShowDialog()
        End If
    End Sub

    Private Sub SubGrupoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SubGrupo")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SubGrupo.ShowDialog()
        End If
    End Sub

    Private Sub TipoGrupoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "TipoGrupo")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.TipoGrupo.ShowDialog()
        End If
    End Sub

    Private Sub CancelamentoDOrdemEmbarqueToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "OrdemEmbarqueCancelamento")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.OrdemEntregaCancelamento.ShowDialog()
        End If
    End Sub

    Private Sub ExtornoDeRecebimentoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ExtornoDeRecebimentoToolStripMenuItem.Click
        TRVDados(UserAtivo, "RecebidaVoltar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else

            If Len(CaixaAtivo) <> 4 Then
                MessageBox.Show("O usuario deve selecionar um caixa antes de executar esta opera��o. Verifique",
                                "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            My.Forms.RecebidaVoltar.ShowDialog()
        End If
    End Sub

    Private Sub ExtornoDePagamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ExtornoDePagamentoToolStripMenuItem.Click
        TRVDados(UserAtivo, "PagasVoltar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            If Len(CaixaAtivo) <> 4 Then
                MessageBox.Show("O usuario deve selecionar um caixa antes de executar esta opera��o. Verifique",
                                "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            My.Forms.PagasVoltar.ShowDialog()
        End If
    End Sub

    Private Sub TimerFechar_Tick(sender As Object, e As EventArgs) Handles TimerFechar.Tick
        TRD = New Thread(AddressOf FecharNoRelogio)
        TRD.IsBackground = True
        TRD.Start()
    End Sub

    Private Sub FecharNoRelogio()
        Dim HoraFechar = "23:00"
        Dim HoraAtual As String = FormatDateTime(DateTime.Now, DateFormat.ShortTime)

        If HoraFechar = HoraAtual Then
            End
        End If
    End Sub

    Private Sub Exporta��oParaNFEToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ExportarNFE")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ExportarNFE.ShowDialog()
        End If

        TRVDados(UserAtivo, "ExportarNFE")
    End Sub

#Region "Preenchimento de arrays"

    Private Sub UF_Preencher()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql = "SELECT * FROM UF order by NomeUF"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim DR As OleDbDataReader

        Try
            DR = Cmd.ExecuteReader
            While DR.Read
                UFArray.Add(New cboItemData(DR.Item("CodigoUF"), DR.Item("NomeUF")))
            End While
            DR.Close()

        Catch Merror As Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()
    End Sub

    Private Sub CofinsCST_Preencher()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql = "SELECT * FROM CofinsCST"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim DR As OleDbDataReader

        Try
            DR = Cmd.ExecuteReader
            While DR.Read
                CofinsCSTArray.Add(New cboItemData(DR.Item("CSTcofins"), DR.Item("DescCSTcofins")))
            End While
            DR.Close()

        Catch Merror As Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()
    End Sub

    Private Sub IcmsCST_Preencher()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql = "SELECT * FROM IcmsCST"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim DR As OleDbDataReader

        Try
            DR = Cmd.ExecuteReader
            While DR.Read
                IcmsArray.Add(New cboItemData(DR.Item("CSTicms"), DR.Item("DescCSTicms")))
            End While
            DR.Close()

        Catch Merror As Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()
    End Sub

    Private Sub IpiCST_Preencher()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql = "SELECT * FROM IpiCST"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim DR As OleDbDataReader

        Try
            DR = Cmd.ExecuteReader
            While DR.Read
                IpiArray.Add(New cboItemData(DR.Item("CSTipi"), DR.Item("DescCSTipi")))
            End While
            DR.Close()

        Catch Merror As Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()
    End Sub

    Private Sub PisCST_Preencher()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql = "SELECT * FROM PisCST"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim DR As OleDbDataReader

        Try
            DR = Cmd.ExecuteReader
            While DR.Read
                PisArray.Add(New cboItemData(DR.Item("CSTpis"), DR.Item("DescCSTpis")))
            End While
            DR.Close()

        Catch Merror As Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()
    End Sub

    Private Sub OrigemIcms_Preencher()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql = "SELECT * FROM IcmsOrigem"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim DR As OleDbDataReader

        Try
            DR = Cmd.ExecuteReader
            While DR.Read
                OrigemIcmsArray.Add(New cboItemData(DR.Item("Origem"), DR.Item("OrigemDesc")))
            End While
            DR.Close()

        Catch Merror As Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()
    End Sub

    Private Sub IcmsModalidadeBC_Preencher()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql = "SELECT * FROM IcmsModalidadeBC"
        Dim Cmd As New OleDbCommand(Sql, Cnn)
        Dim DR As OleDbDataReader

        Try
            DR = Cmd.ExecuteReader
            While DR.Read
                IcmsModalidadeBCArray.Add(New cboItemData(DR.Item("modBC"), DR.Item("modBCDesc")))
            End While
            DR.Close()

        Catch Merror As Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()
    End Sub

#End Region

#Region "Preenchimento de dataset"

    Private Sub oDtCFOP()
        'Criar conexao
        Dim cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        'Abrir conexao.
        cnn.Open()

        Dim sSql As String = String.Empty

        sSql = "SELECT * From CFOP"

        'Ap�s estabelecer uma conex�o, execute comandos e retorna o resultados de uma fonte de dados como uma SQL.
        Dim Cmd As New OleDbCommand(sSql, cnn)

        'Usa o DataAdapter para para se conectar ao objeto command
        Dim Adt As New OleDbDataAdapter(Cmd)

        'preenche dataset com a tabela
        Adt.Fill(Dst, "TbCFOP")

        cnn.Close()
    End Sub

#End Region

    Private Sub ChequePr�DevolvidosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ChequePr�DevolvidosToolStripMenuItem.Click
        TRVDados(UserAtivo, "ChequePreDevolver")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ChequePreDevolver.ShowDialog()
        End If
    End Sub

    Private Sub ToolStripMenuItem45_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "CriaAnoContabil")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CriaAnoContabil.ShowDialog()
        End If
    End Sub

    Private Sub LocalDePagamentoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "LocalPagamento")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.LocalPagamento.ShowDialog()
        End If
    End Sub

    Private Sub Relat�riosDeCadGeraisToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Relat�riosDeCadGeraisToolStripMenuItem.Click
        TRVDados(UserAtivo, "CadGeraisRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CadGeraisRelat.ShowDialog()
        End If
    End Sub

    Private Sub ToolStripMenuItem48_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem48.Click
        TRVDados(UserAtivo, "DocumentoEntrada")
        If Ina = True Then
            MsgBox("O usu�rio n�o est� autorizado a usar esta op��o do sistema.", 48, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.DocumentoEntrada.ShowDialog()
        End If
    End Sub

    Private Sub Relat�riosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Relat�riosToolStripMenuItem.Click
        TRVDados(UserAtivo, "RelClientes")
        If Ina = True Then
            MsgBox("O usu�rio n�o est� autorizado a usar esta op��o do sistema.", 48, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ClientesRalatorios.ShowDialog()
        End If
    End Sub

    Private Sub btMenuGeral_Click(sender As Object, e As EventArgs) Handles btMenuGeral.Click
        Dim X As New Point(Me.btMenuGeral.Width, 0)
        Me.MnGeral.Show(Me.btMenuGeral, X)
    End Sub

    Private Sub btPagarReceber_Click(sender As Object, e As EventArgs) Handles btPagarReceber.Click
        Dim X As New Point(Me.btPagarReceber.Width, 0)
        Me.MnCtpCtr.Show(Me.btPagarReceber, X)
    End Sub


    Private Sub btCaixaBanco_Click(sender As Object, e As EventArgs) Handles btCaixaBanco.Click
        Dim X As New Point(Me.btCaixaBanco.Width, 0)
        Me.MnCaixaBanco.Show(Me.btCaixaBanco, X)
    End Sub

    Private Sub btRH_Click(sender As Object, e As EventArgs) Handles btRH.Click
        Dim X As New Point(Me.btRH.Width, 0)
        Me.MnRH.Show(Me.btRH, X)
    End Sub

    Private Sub btConf_Click(sender As Object, e As EventArgs) Handles btConf.Click
        Dim X As New Point(Me.btConf.Width, 0)
        Me.MnConfigura��o.Show(Me.btConf, X)
    End Sub

    Private Sub ContaCorrenteToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ContaCorrenteToolStripMenuItem.Click
        TRVDados(UserAtivo, "BancosContaCorrente")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.BancosContaCorrente.ShowDialog()
        End If
    End Sub

    Private Sub CadastroDeBancoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CadastroDeBancoToolStripMenuItem.Click
        TRVDados(UserAtivo, "BancosCad")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.BancosCad.ShowDialog()
        End If
    End Sub

    Private Sub CriarEFecharDiaDeTrabalhoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CriarEFecharDiaDeTrabalhoToolStripMenuItem.Click
        TRVDados(UserAtivo, "DiaAbrirFechar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.DiaAbrirFechar.ShowDialog()
        End If
    End Sub

#Region "Rotinas para os Themas"

    Private m_ColorSelected As Boolean = False
    Dim m_BaseColorScheme As eOffice2007ColorScheme

    Private Sub btCoresPersonalizadas_ColorPreview(sender As Object, e As ColorPreviewEventArgs)
        RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(Me, eOffice2007ColorScheme.Silver, e.Color)
    End Sub

    Private Sub btCoresPersonalizadas_ExpandChange(sender As Object, e As EventArgs)
        'If btCoresPersonalizadas.Expanded Then
        '    ' Remember the starting color scheme to apply if no color is selected during live-preview
        '    m_ColorSelected = False
        '    m_BaseColorScheme = CType(GlobalManager.Renderer, Office2007Renderer).ColorTable.InitialColorScheme
        'Else
        '    If Not m_ColorSelected Then
        '        ' RibbonVisualizador.Office2007ColorTable = m_BaseColorScheme
        '    End If
        'End If
    End Sub

    Private Sub btCoresPersonalizadas_SelectedColorChanged(sender As Object, e As EventArgs)
        'm_ColorSelected = True ' Indicate that color was selected for buttonStyleCustom_ExpandChange method
        'btCoresPersonalizadas.CommandParameter = btCoresPersonalizadas.SelectedColor
    End Sub

#End Region

    Private Sub Localiza��oToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Localiza��oToolStripMenuItem.Click
        TRVDados(UserAtivo, "ProdutoLocal")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutoLocal.ShowDialog()
        End If
    End Sub

    Private Sub CadastroDeContasResultadoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CadastroDeContasResultadoToolStripMenuItem.Click
        TRVDados(UserAtivo, "BalanceteCadastro")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.BalanceteCadastro.ShowDialog()
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        TRVDados(UserAtivo, "CaixaAtivarDesativar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CaixaAtivarDesativar.ShowDialog()
        End If
    End Sub

    Private Sub FormaDePagamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles FormaDePagamentoToolStripMenuItem.Click
        TRVDados(UserAtivo, "FormaPgto")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.FormaPgto.ShowDialog()
        End If
    End Sub

    Private Sub AtualizadorDeEstoqueToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AtualizadorDeEstoqueToolStripMenuItem.Click
        TRVDados(UserAtivo, "ProdutoEstoqueAtualizar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutoEstoqueAtualizar.ShowDialog()
        End If
    End Sub

    Private Sub CadastroDeCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CadastroDeCaixaToolStripMenuItem.Click
        TRVDados(UserAtivo, "CaixaCadastro")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CaixaCadastro.ShowDialog()
        End If
    End Sub

    Private Sub ConsultaDeEstoqueToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ConsultaDeEstoqueToolStripMenuItem.Click
        TRVDados(UserAtivo, "ProdutoEstoqueConsulta")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutoEstoqueConsulta.ShowDialog()
        End If
    End Sub

    Private Sub MenuGeral_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Dim isControlPressed As Boolean = (ModifierKeys And Keys.Control) <> 0
        If isControlPressed = True Then
            If e.KeyCode = Keys.E Then
                My.Forms.ProdutoEstoqueConsulta.ShowDialog()
            End If

            If e.KeyCode = Keys.P Then

                'Incluido por 
                If UsaSellShoes = True Then
                    TRVDados(UserAtivo, "SellShoesAutenticacao")
                    If Ina = True Then
                        MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
                        Exit Sub
                    Else
                        My.Forms.SellShoesAutenticacao.ShowDialog()
                    End If
                Else
                    TRVDados(UserAtivo, "PedidoOs")
                    If Ina = True Then
                        MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
                        Exit Sub
                    Else
                        EntrarAchandoPedido = False
                        My.Forms.PedidoOS.ShowDialog()
                    End If
                End If

                'Retirado por                   'My.Forms.PedidoOS.ShowDialog()

            End If
            If e.KeyCode = Keys.F10 Then
                If Me.MenuDisplay.Visible = True Then
                    Me.MenuDisplay.Visible = False
                Else
                    Me.MenuDisplay.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub Relat�riosToolStripMenuItem2_Click(sender As Object, e As EventArgs) _
        Handles Relat�riosToolStripMenuItem2.Click
        TRVDados(UserAtivo, "FornecedorRelatorio")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.FornecedorRelatorio.ShowDialog()
        End If
    End Sub

    Private Sub SaldoDeEstoqueToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SaldoDeEstoqueToolStripMenuItem.Click
        TRVDados(UserAtivo, "ProdutoSaldoEstoque")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutoSaldoEstoque.ShowDialog()
        End If
    End Sub

    Private Sub Impress�oDeNPDuplicataDoPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ImprimirDuplicataNP")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ImprimirDuplicataNP.ShowDialog()
        End If
    End Sub

    Private Sub CaixasEmAbertosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CaixasEmAbertosToolStripMenuItem.Click
        TRVDados(UserAtivo, "CaixasAbertos")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CaixasAbertos.ShowDialog()
        End If
    End Sub

    Private Sub Servi�osToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "Servicos")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Servicos.ShowDialog()
        End If
    End Sub

    Private Sub OrdemDeProdu�ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "Producao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Producao.ShowDialog()
        End If
    End Sub

    Private Sub EtiquetasDeProdutoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles EtiquetasDeProdutoToolStripMenuItem.Click
        TRVDados(UserAtivo, "ProdutoEtiquetas")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutoEtiquetas.ShowDialog()
        End If
    End Sub

    Private Sub Regi�oToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Regi�oToolStripMenuItem.Click
        TRVDados(UserAtivo, "Regiao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Regiao.ShowDialog()
        End If
    End Sub

    Private Sub ConsultarProdutosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ConsultarProdutosToolStripMenuItem.Click
        ProcuraProduto.ShowDialog()
    End Sub

    Private Sub ConfirmarOrdemDeProdu��oNoEstoqueToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ProducaoEstoqueConfirmar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProducaoEstoqueConfirmar.ShowDialog()
        End If
    End Sub

    Private Sub AjusteEstoqueToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AjusteEstoqueToolStripMenuItem.Click
        TRVDados(UserAtivo, "ProdutoEstoqueAjuste")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutoEstoqueAjuste.ShowDialog()
        End If
    End Sub


    Private Sub AReceberAvulsoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AReceberAvulsoToolStripMenuItem.Click
        TRVDados(UserAtivo, "ReceberAvulso")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ReceberAvulso.ShowDialog()
        End If
    End Sub

    Private Sub CadastroDeObjetosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ObejtosCad")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ObjetosCad.ShowDialog()
        End If
    End Sub

    Private Sub Exporta��oPAFHToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ExportPAF")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ExportPAF.ShowDialog()
        End If
    End Sub

    Private Sub Relat�riosToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "BalanceteOrcamentarioRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.BalanceteOrcamentarioRelat.ShowDialog()
        End If
    End Sub

    Private Sub Comiss�oDeVendedoresToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ComissaoRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ComissaoRelat.ShowDialog()
        End If
    End Sub

    Private Sub btConsultaProduto_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesProdutoProcura")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesProdutoProcura.ShowDialog()
        End If
    End Sub

    Private Sub Cart�oDeFuncion�rioToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Cart�oDeFuncion�rioToolStripMenuItem.Click
        TRVDados(UserAtivo, "FuncionarioCartao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.FuncionarioCartao.ShowDialog()
        End If
    End Sub

    Private Sub AtualizarTabelasToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AtualizarTabelasToolStripMenuItem.Click
        My.Forms.AtTabelas.ShowDialog()
    End Sub

    Private Sub Funcion�riosEServi�osToolStripMenuItem_Click(sender As Object, e As EventArgs)
        My.Forms.ServicoFuncionario.ShowDialog()
    End Sub

    Private Sub OrdemServi�oToolStripMenuItem_Click(sender As Object, e As EventArgs)
        My.Forms.PedidoOS.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem36_Click(sender As Object, e As EventArgs)
        OSor�amento.ShowDialog()
    End Sub

    Private Sub EmitirDuplicataAvulsoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles EmitirDuplicataAvulsoToolStripMenuItem.Click
        TRVDados(UserAtivo, "DuplicataAvulso")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            DuplicataAvulso.ShowDialog()
        End If
    End Sub

    Private Sub VendaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesAutenticacao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesAutenticacao.ShowDialog()
        End If
    End Sub

    Private Sub ConsultaClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ConsultaClienteToolStripMenuItem.Click
        TRVDados(UserAtivo, "SellShoesClientesProcura")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesClientesProcura.ShowDialog()
        End If
    End Sub

    Private Sub ConsultaProodutoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ConsultaProodutoToolStripMenuItem.Click
        TRVDados(UserAtivo, "SellShoesProdutoProcura")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesProdutoProcura.ShowDialog()
        End If
    End Sub

    Private Sub FinalizarVendaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles FinalizarVendaToolStripMenuItem.Click
        TRVDados(UserAtivo, "SellShoesPendentes")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesPendentes.ShowDialog()
        End If
    End Sub

    Private Sub Devolu��oToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Devolu��oToolStripMenuItem.Click
        TRVDados(UserAtivo, "SellShoesDevolucao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesDevolucao.ShowDialog()
        End If
    End Sub

    Private Sub EntradaNotaFiscalToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles EntradaNotaFiscalToolStripMenuItem.Click
        TRVDados(UserAtivo, "SellShoesCompra")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            SellShoesCompra.ShowDialog()
        End If
    End Sub

    Private Sub BaixaRecebimentoEmLoteToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BaixaRecebimentoEmLoteToolStripMenuItem.Click
        TRVDados(UserAtivo, "ReceberBaixaLote")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ReceberBaixaLote.ShowDialog()
        End If
    End Sub

    Private Sub PedidoCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PedidoCompraToolStripMenuItem.Click
        TRVDados(UserAtivo, "SellShoesPedidoCompra")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesPedidoCompra.ShowDialog()
        End If

        'My.Forms.SellShoesPedidoCompra.ShowDialog()
    End Sub

    Private Sub Servi�osExecutadosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "RelServico")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.RelServico.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem14_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesClientesProcura")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesClientesProcura.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem15_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ProcuraProduto")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProcuraProduto.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem16_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesAutenticacao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesAutenticacao.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem17_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesDevolucao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesDevolucao.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem19_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesPendentes")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesPendentes.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub ButtonItem20_Click(sender As Object, e As EventArgs) Handles btnRecebimento.Click
        TRVDados(UserAtivo, "Receber")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Receber.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem21_Click(sender As Object, e As EventArgs) Handles btnIniciarcaixa.Click
        TRVDados(UserAtivo, "CaixaAtivarDesativar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CaixaAtivarDesativar.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem22_Click(sender As Object, e As EventArgs) Handles btnVisualizarCaixa.Click
        TRVDados(UserAtivo, "Caixa")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Caixa.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem23_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ReceberBaixaLote")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ReceberBaixaLote.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem18_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesOrcamentoProcura")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesOrcamentoProcura.ShowDialog()
        End If
    End Sub

    Private Sub GruposDeServi�osToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "GrupoServico")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.GrupoServico.ShowDialog()
        End If
    End Sub

    Private Sub BuscarObjetoPorPlacaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ObjetoLocalizarPlaca")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ObjetoLocalizarPlaca.ShowDialog()
        End If
    End Sub

    Private Sub mnuReltPedOS_Click(sender As Object, e As EventArgs)
        My.Forms.OsRelat.ShowDialog()
    End Sub

    Private Sub Tranfer�nciaDeEstoqueDep�ditoVendaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "EstoqueTransferencia")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.EstoqueTransferencia.ShowDialog()
        End If
    End Sub

    Private Sub CadastroDeContasDeResultadoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CadastroDeContasDeResultadoToolStripMenuItem.Click
        TRVDados(UserAtivo, "CentroCustoNew")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CentroCustoNew.ShowDialog()
        End If
    End Sub

    Private Sub TipoDePagamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles TipoDePagamentoToolStripMenuItem.Click
        TRVDados(UserAtivo, "TipoPgto")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.TipoPgto.ShowDialog()
        End If
    End Sub

    Private Sub AnexarCondPgtoAoTipoDePgtoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AnexarCondPgtoAoTipoDePgtoToolStripMenuItem.Click
        TRVDados(UserAtivo, "TipoFormaPgto")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.TipoFormaPgto.ShowDialog()
        End If
    End Sub

    Private Sub ContratosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ContratosToolStripMenuItem.Click
        TRVDados(UserAtivo, "Contrato")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Contrato.ShowDialog()
        End If
    End Sub

    Private Sub VerLimiteDeCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles VerLimiteDeCreditoToolStripMenuItem.Click
        TRVDados(UserAtivo, "ClientesVerSaldoCredito")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ClientesVerSaldoCredito.ShowDialog()
        End If
    End Sub

    Private Sub ProdutosInaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ProdutosInaToolStripMenuItem.Click
        TRVDados(UserAtivo, "ProdutosInativos")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutosInativos.ShowDialog()
        End If
    End Sub

    Private Sub ConsultarPre�oServi�oToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ServicoConsultaPreco")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ServicoConsultaPreco.ShowDialog()
        End If
    End Sub

    Private Sub AlterarPre�oServi�oListagemToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ServicoListagemAlterarPreco")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ServicoListagemAlterarPreco.ShowDialog()
        End If
    End Sub

    Private Sub AtualizarOSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AtualizarOSistemaToolStripMenuItem.Click
        Shell(Application.StartupPath & "\upUpdate.exe", AppWinStyle.NormalFocus, False)
        End
    End Sub

    Private Sub DocumentoDeEntradaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles DocumentoDeEntradaToolStripMenuItem.Click
        TRVDados(UserAtivo, "DocumentoEntrada")
        If Ina = True Then
            MsgBox("O usu�rio n�o est� autorizado a usar esta op��o do sistema.", 48, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.DocumentoEntrada.ShowDialog()
        End If
    End Sub

    Private Sub Fundo_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Permiss�esToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Permiss�esToolStripMenuItem.Click
        TRVDados(UserAtivo, "Permissoes")
        If Ina = True Then
            MsgBox("O usu�rio n�o est� autorizado a usar esta op��o do sistema.", 48, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Permissoes.ShowDialog()
        End If
    End Sub

    Private Sub Relat�rioDeProdutosGrade_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesRelProdutoGrade")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesRelProdutoGrade.ShowDialog()
        End If
    End Sub

    Private Sub PedidoCompraFinanceiroToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PedidoCompraFinanceiroToolStripMenuItem.Click
        TRVDados(UserAtivo, "PedCompraFinanceiro")
        If Ina = True Then
            MsgBox("O usu�rio n�o est� autorizado a usar esta op��o do sistema.", 48, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PedCompraFinanceiro.ShowDialog()
        End If
    End Sub

    Private Sub CoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ConsultaServicoPlaca")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ConsultaServicoPlaca.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem24_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesReimpressao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesReimpressao.ShowDialog()
        End If
    End Sub

    Private Sub Exporta��oPAFExclaimToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ExportPAF2")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ExportPAF2.ShowDialog()
        End If
    End Sub

    Private Sub Exporta��oProSoftToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ProSoftExport")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProSoftExport.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem25_Click(sender As Object, e As EventArgs)

        TRVDados(UserAtivo, "SellShoesAutenticacao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesAutenticacao.OpcConsVenda.Checked = True
            My.Forms.SellShoesAutenticacao.ShowDialog()

        End If

        'TRVDados(UserAtivo, "SellShoesResumoVenda")
        'If Ina = True Then
        '    MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
        '    Exit Sub
        'Else
        '    My.Forms.SellShoesResumoVenda.ShowDialog()
        'End If
    End Sub

    Private Sub ReimprimirReciboPagarReceberToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ReimprimirReciboPagarReceberToolStripMenuItem.Click

        TRVDados(UserAtivo, "ReimpressaoReciboPagarReceber")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ReimpressaoReciboPagarReceber.ShowDialog()

        End If
    End Sub

    Private Sub Loca��oDeCilindrosToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "LocacaoCilindro")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.LocacaoCilindro.ShowDialog()

        End If
    End Sub

    Private Sub Relat�rioCilindrosLocadosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        My.Forms.RelLocaoCilindro.ShowDialog()
    End Sub

    Private Sub Ivent�rioToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Ivent�rioToolStripMenuItem.Click
        TRVDados(UserAtivo, "Iventario")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Iventario.ShowDialog()

        End If
    End Sub

    Private Sub GerarEtiquetasToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles GerarEtiquetasToolStripMenuItem.Click
        TRVDados(UserAtivo, "ProdutoGerarEtiqueta")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutoGerarEtiqueta.ShowDialog()

        End If
    End Sub

    Private Sub CentralDeCart�oDeCr�ditoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CentralDeCart�oDeCr�ditoToolStripMenuItem.Click
        TRVDados(UserAtivo, "CartaoCreditoMenu")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CartaoCreditoMenu.ShowDialog()
        End If
    End Sub

    Private Sub CancelamentoVendaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CancelamentoVendaToolStripMenuItem.Click
        TRVDados(UserAtivo, "PedidoCancelamento")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PedidoCancelamentoOS.ShowDialog()
        End If
    End Sub

    Private Sub ToolStripMenuItem35_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem35.Click
        ''
        TRVDados(UserAtivo, "PedidoRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PedidoRelat.ShowDialog()
        End If
    End Sub

    Private Sub CadastroDeObjetoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ObejtosCad")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ObjetosCad.ShowDialog()
        End If
    End Sub

    Function GetRandomPassword(length As Integer) As String
        Static rand As New Random
        Dim password As New StringBuilder(length)

        For i = 1 To length
            Dim charIndex As Integer
            ' allow only digits and letters
            Do
                charIndex = rand.Next(48, 123)
            Loop Until (charIndex >= 48 AndAlso charIndex <= 57) OrElse (charIndex _
                                                                         >= 65 AndAlso charIndex <= 90) OrElse
                       (charIndex >= 97 AndAlso
                        charIndex <= 122)
            ' add the random char to the password being built
            password.Append(Convert.ToChar(charIndex))
        Next
        Return password.ToString()
    End Function

    Private Sub GerenciadorDePermiss�esToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles GerenciadorDePermiss�esToolStripMenuItem.Click
        TRVDados(UserAtivo, "PermissaoGetPost")
        If Ina = True Then
            MsgBox("O usu�rio n�o est� autorizado a usar esta op��o do sistema.", 48, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PermissaoGetPost.ShowDialog()
        End If
    End Sub

    Private Sub AjusteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "ProdutoGradeEstoqueAjuste")
        If Ina = True Then
            MsgBox("O usu�rio n�o est� autorizado a usar esta op��o do sistema.", 48, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProdutoGradeEstoqueAjuste.ShowDialog()
        End If
    End Sub

    Private Sub CadastroDeProdutosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CadastroDeProdutosToolStripMenuItem.Click
        TRVDados(UserAtivo, "Produtos")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            Dim f As New Produtos()
            My.Forms.Produtos.ShowDialog()
        End If
    End Sub

    Private Sub ItoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItoriaToolStripMenuItem.Click
        TRVDados(UserAtivo, "Auditor")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Auditor.ShowDialog()
        End If
    End Sub

    Private Sub HitoricoDeClientePedidoOSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "HistoricoOsPedido")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.HistoricoOsPedido.ShowDialog()
        End If
    End Sub

    Private Sub AgendaDeServi�osToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "AgendaServico")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.AgendaServico.ShowDialog()
        End If
    End Sub

    Private Sub AgendaServi�osToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AgendaServi�osToolStripMenuItem.Click
        TRVDados(UserAtivo, "AgendaServico")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.AgendaServico.ShowDialog()
        End If
    End Sub

    Private Async Sub VerAgendaServi�o()

        Try
            Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            Dim Sql As String = String.Empty

            Sql =
                "Select AgendaServico.Id, AgendaServico.ClienteDesc, AgendaServico.DataAgenda,AgendaServico.HorasCompromisso  from AgendaServico Where AgendaServico.Status <> 'Finalizado' and AgendaServico.Status <> 'Cancelado' order by Id"

            'Sql = "Select AgendaServico.Id, AgendaServico.ClienteDesc, AgendaServico.DataAgenda  from AgendaServico Where AgendaServico.Status <> 'Finalizado' and AgendaServico.Status <> 'Cancelado' And AgendaServico.Usuario = '" & UserAtivo & "' order by Id"

            Dim da = New OleDbDataAdapter(Sql, Cnn)
            Dim ds As New DataSet
            da.Fill(ds, "Table")

            Me.AgendaLista.DataSource = ds.Tables("Table").DefaultView

            da.Dispose()
            Cnn.Close()

            Dim I As Integer
            Dim S As Double
            For I = 0 To Me.AgendaLista.Columns.Count - 2
                S += AgendaLista.Columns(I).Width
            Next
            Dim TCol As Double = Me.AgendaLista.Width - S - 20
            Me.AgendaLista.Columns(1).Width += TCol

            If Me.AgendaLista.RowCount > 0 Then
                Me.AgendaPainel.Visible = True
            Else
                Me.AgendaPainel.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btAgendaFechar_Click(sender As Object, e As EventArgs) Handles btAgendaFechar.Click

        If Me.AgendaLista.Visible = True Then
            Me.AgendaLista.Visible = False
        Else
            Me.AgendaLista.Visible = True
        End If

        'If Me.AgendaPainel.Height > 30 Then

        '    While Me.AgendaPainel.Height > 30

        '        System.Windows.Forms.Application.DoEvents()

        '        Me.AgendaPainel.Height -= 1
        '        If Me.AgendaPainel.Height = 30 Then
        '            Me.btAgendaFechar.Image = Me.btAgendaFechar.InitialImage
        '            Exit While
        '        End If

        '    End While

        'Else

        '    Dim t As Integer = Me.Height - 188 - 40

        '    While Me.AgendaPainel.Height < t

        '        System.Windows.Forms.Application.DoEvents()

        '        Me.AgendaPainel.Height += 1
        '        If Me.AgendaPainel.Height = t Then
        '            Me.btAgendaFechar.Image = Me.btAgendaFechar.ErrorImage
        '            Exit While
        '        End If

        '    End While

        'End If
    End Sub

    Delegate Sub myDelegate()

    Private Sub IniciaVerAgenda()
        If Me.InvokeRequired Then
            Me.Invoke(New myDelegate(AddressOf AtualizaGridDia))
        End If
    End Sub

    Private Sub AgendaLista_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles AgendaLista.CellContentDoubleClick
        My.Forms.AgendaServicoAdd.Procurar = Me.AgendaLista.CurrentRow.Cells("cId").Value
        My.Forms.AgendaServicoAdd.ShowDialog()
    End Sub

    Private Sub CFOPEntradaESa�daToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CFOPEntradaESa�daToolStripMenuItem.Click
        TRVDados(UserAtivo, "CFOPse")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CFOPse.ShowDialog()
        End If
    End Sub

    Private Sub ReclacificarContasToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ReclacificarContasToolStripMenuItem.Click
        TRVDados(UserAtivo, "BalanceteEdit")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.BalanceteEdit.ShowDialog()
        End If
    End Sub

    Private Sub AgruparRecebimentoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AgruparRecebimentoToolStripMenuItem.Click
        TRVDados(UserAtivo, "ReceberAgrupar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ReceberAgrupar.ShowDialog()
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "AtualizarTributacaoProduto")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.AtualizarTributacaoProduto.ShowDialog()
        End If
    End Sub

    Private Sub Lan�arCreditoParaOClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Lan�arCreditoParaOClienteToolStripMenuItem.Click
        TRVDados(UserAtivo, "ClientesCred")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            '    My.Forms.ClientesCred.ShowDialog()
        End If
    End Sub

    Private Sub BaixarCr�ditoDoClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BaixarCr�ditoDoClienteToolStripMenuItem.Click
        TRVDados(UserAtivo, "ClientesCredBaixar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            '   My.Forms.ClientesCredBaixar.ShowDialog()
        End If
    End Sub

    Private Sub Exporta��oPAFG4ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        My.Forms.ExportaPAF3.ShowDialog()
    End Sub

    Private Sub AgruparPagamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles AgruparPagamentoToolStripMenuItem.Click
        TRVDados(UserAtivo, "PagarAgrupar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.PagarAgrupar.ShowDialog()
        End If
    End Sub

    Private Sub btnNotaFiscalEletronica_Click(sender As Object, e As EventArgs) Handles btnNotaFiscalEletronica.Click
        Dim X As New Point(Me.btnNotaFiscalEletronica.Width, 0)
        Me.MnNfe.Show(Me.btnNotaFiscalEletronica, X)
    End Sub


    Private Sub Relat�riosDeReceitasDespesasToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Relat�riosDeReceitasDespesasToolStripMenuItem.Click
        TRVDados(UserAtivo, "BalanceteRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.BalanceteRelat.ShowDialog()
        End If
    End Sub

    Private Sub Relat�risDeCentroDeCustoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Relat�risDeCentroDeCustoToolStripMenuItem.Click
        TRVDados(UserAtivo, "CentroCustoNewRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CentroCustoNewRelat.ShowDialog()
        End If
    End Sub

    Private Sub btStatusAndamentoPedido_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "AcompanharPedido")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.AcompanharPedido.ShowDialog()
        End If
    End Sub

    Private Sub Relat�riosToolStripMenuItem8_Click(sender As Object, e As EventArgs) _
        Handles Relat�riosToolStripMenuItem8.Click
    End Sub

    Private Sub VerificadorDeInconsist�nciaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles VerificadorDeInconsist�nciaToolStripMenuItem.Click
        TRVDados(UserAtivo, "BalanceteCentroCustoErro")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.BalanceteCentroCustoErro.ShowDialog()
        End If
    End Sub

    Private Sub Movimenta��oCaixaBancoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Movimenta��oCaixaBancoToolStripMenuItem.Click
        TRVDados(UserAtivo, "DiaConferenciaRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.DiaConferenciaRelat.ShowDialog()
        End If
    End Sub

    Private Sub Movimenta��oComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Movimenta��oComprasToolStripMenuItem.Click
        TRVDados(UserAtivo, "CompraDiaConferenciaRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CompraDiaConferenciaRelat.ShowDialog()
        End If
    End Sub

    Private Sub Movimenta��oCentroCustoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Movimenta��oCentroCustoToolStripMenuItem.Click
        TRVDados(UserAtivo, "CentroCustoDiaConferenciaRelat")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CentroCustoDiaConferenciaRelat.ShowDialog()
        End If
    End Sub

    Private Sub Relat�rioDeItensEmAbertoNoPedidoToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        'nome do relatorio
        RelatorioCarregar = "RelItensAbertoPedidos.rpt"

        'filtro do relatorio
        Dim filtro = "not {Pedido.Inativo} and not {Pedido.Confirmado}"

        'cria estancia da classe
        Dim f As New cView
        f.frm(DirRelat & RelatorioCarregar, LocalBD & Nome_BD, SenhaBancoDados, "Relat�rio de Itens em Aberto no Pedido",
              filtro, True)
    End Sub

    Private Sub CentralDeBoletosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CentralDeBoletosToolStripMenuItem.Click
        My.Forms.GeradorBoletos.ShowDialog()
    End Sub

    Private Sub btnItem_ConsCliente_Click(sender As Object, e As EventArgs) Handles btnItem_ConsCliente.Click

        My.Forms.ClientesProcura.ShowDialog()
    End Sub

    Private Sub btnItem_ConsProduto_Click(sender As Object, e As EventArgs) Handles btnItem_ConsProduto.Click
        TRVDados(UserAtivo, "ProcuraProduto")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ProcuraProduto.ShowDialog()
        End If
    End Sub

    Private Sub btnItem_Orcamento_Click(sender As Object, e As EventArgs)
        My.Forms.OSor�amento.ShowDialog()
    End Sub

    Private Sub btnItem_pedidoOS_Click(sender As Object, e As EventArgs)
        My.Forms.PedidoOS.ShowDialog()
    End Sub

    Private Sub btnSuporteRemoto_Click(sender As Object, e As EventArgs) Handles btnSuporteRemoto.Click
        Dim exec As New ClassExecProg
        exec.GetProgram()
    End Sub

    Private Sub ContabilistaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ContabilistaToolStripMenuItem.Click
        My.Forms.Contabilista.ShowDialog()
    End Sub

    Private Sub btVendaBrinde_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesAutenticacao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesAutenticacao.OpcBrinde.Checked = True
            My.Forms.SellShoesAutenticacao.ShowDialog()
        End If
    End Sub

    Private Sub btDebitoInterno_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesAutenticacao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesAutenticacao.OpcDebitoInterno.Checked = True
            My.Forms.SellShoesAutenticacao.ShowDialog()
        End If
    End Sub

    Private Sub ClientesAniversariantesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ClientesAniversariantesToolStripMenuItem.Click

        TRVDados(UserAtivo, "ClientesAniversariantes")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.ClientesAniversariantes.ShowDialog()
        End If
    End Sub

    Private Sub CadastroDeNCMToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CadastroDeNCMToolStripMenuItem.Click
        My.Forms.Ncm.ShowDialog()
    End Sub

    Private Sub btOrdemEntrega_Click_1(sender As Object, e As EventArgs)
        My.Forms.SellShoesOEProcura.ShowDialog()
    End Sub

    Private Sub NaturezaOpera��oSpedToolStripMenuItem_Click(sender As Object, e As EventArgs)
        My.Forms.NaturezaOperacaoSped.ShowDialog()
    End Sub

    Private Sub btNFe_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "SellShoesGerarNFe")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SellShoesGerarNFe.ShowDialog()
        End If
    End Sub

    Private Sub btMovimento_Click(sender As Object, e As EventArgs) Handles btMovimento.Click
        Dim X As New Point(Me.btCaixaBanco.Width, 0)
        Me.MnMovimento.Show(Me.btMovimento, X)
    End Sub

    Private Sub ButtonItem14_Click_1(sender As Object, e As EventArgs) Handles btnSeletor.Click
        TRVDados(UserAtivo, "LocacaoSeletor")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.LocacaoSeletor.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem17_Click_1(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "Locacao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Locacao.ShowDialog()
        End If
    End Sub

    Private Sub FreteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FreteToolStripMenuItem.Click
        TRVDados(UserAtivo, "Frete")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Frete.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem15_Click_1(sender As Object, e As EventArgs) Handles btnOrcamento.Click
        TRVDados(UserAtivo, "LocacaoOrcamentoProcurar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.LocacaoOrcamentoProcurar.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem16_Click_1(sender As Object, e As EventArgs) Handles btnRetorno.Click

        TRVDados(UserAtivo, "Devolucao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else

            My.Forms.Devolucao.ShowDialog()
        End If
    End Sub

    Private Sub Sa�daDeProdutosToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles Sa�daDeProdutosToolStripMenuItem.Click
        TRVDados(UserAtivo, "SaidaProdutos")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.SaidaProdutos.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem18_Click_1(sender As Object, e As EventArgs)
        My.Forms.ProcuraProdutoFoto.ShowDialog()
    End Sub

    Private Sub btnItemPagamento_Click(sender As Object, e As EventArgs) Handles btnPagamento.Click
        TRVDados(UserAtivo, "Pagar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Pagar.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem18_Click_2(sender As Object, e As EventArgs) Handles btnEntregar.Click
        TRVDados(UserAtivo, "LocacaoEntregar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.LocacaoEntregar.ShowDialog()
        End If
    End Sub

    Private Sub CancelarLoca��oToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CancelarLoca��oToolStripMenuItem.Click
        TRVDados(UserAtivo, "LocacaoCancelar")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.LocacaoCancelar.ShowDialog()
        End If
    End Sub

    Private Sub Relat�riosToolStripMenuItem3_Click_1(sender As Object, e As EventArgs) _
        Handles Relat�riosToolStripMenuItem3.Click

    End Sub

    Private Sub ButtonItem14_Click_2(sender As Object, e As EventArgs) Handles ButtonItem14.Click
        TRVDados(UserAtivo, "Locacao")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.Locacao.ShowDialog()
        End If
    End Sub

    Private Sub RetornoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetornoToolStripMenuItem.Click
        My.Forms.RetornoLocacao.ShowDialog()
    End Sub

    Private Sub MenuGeral_MenuStart(sender As Object, e As EventArgs) Handles Me.MenuStart
    End Sub

    Private Sub TimerAgenda_Tick(sender As Object, e As EventArgs) Handles TimerAgenda.Tick
        ''Task.Factory.StartNew(sub()VerAgendaServi�o)
        'Dim t As Task = Task.Run(Sub() VerAgendaServi�o)
        't.Wait()
        Dim THRD As New Thread(AddressOf IniciaVerAgenda)
        THRD.Priority = ThreadPriority.Highest
        THRD.IsBackground = True
        THRD.Start()
    End Sub

    Private Sub DateNavigator1_DateChanged(sender As Object, e As DateNavigator.DateChangedEventArgs) _
        Handles DateNavigator1.DateChanged
        AtualizaDia()
        AtualizaGridDia()
    End Sub

    Private Sub DateNavigator1_DateChanging(sender As Object, e As DateNavigator.DateChangingEventArgs) _
        Handles DateNavigator1.DateChanging
        AtualizaDia()
    End Sub


    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        CalendarView1.ShowDate(DateTime.Today)
        AtualizaDia()
    End Sub

    Private Sub BallonSow(control As DataGridView)
        Dim x = MousePosition.X
        Dim y = MousePosition.Y


        balloonTipFocus.Enabled = True
        Dim b = New Balloon()
        b.Style = eBallonStyle.Balloon

        b.CaptionText = "Agendamento"

        Dim msg = control.CurrentRow.Cells("gid").Value & "-" & control.CurrentRow.Cells("ghoracompromisso").Value &
                  vbCrLf & control.CurrentRow.Cells("gdescricao").Value

        b.Text = msg _
        '"Balloons are now enabled for Balloon"& vbCrLf &" Tip Test area. Hover mouse over the area and set the focus to any control."
        b.AlertAnimation = eAlertAnimation.TopToBottom
        b.Location = New Point(x - 30, y)
        b.AutoResize()
        b.ShowCloseButton = True
        b.AutoClose = True
        b.AutoCloseTimeOut = 4
        b.Show()
    End Sub

    Private Sub dgvDom_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvDom.CellContentClick

        ShowLoadAlert(dgvDom)
    End Sub

    Private Sub dgvSeg_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSeg.CellContentClick
        ShowLoadAlert(dgvSeg)
    End Sub

    Private Sub dgvTer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTer.CellContentClick
        ShowLoadAlert(dgvTer)
    End Sub
    Private Sub dgvQua_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQua.CellContentClick
        ShowLoadAlert(dgvQua)
    End Sub
    Private Sub dgvQui_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQui.CellContentClick
        ShowLoadAlert(dgvQui)
    End Sub
    Private Sub dgvSex_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSex.CellContentClick

        ShowLoadAlert(dgvSex)

    End Sub
    Private Sub dgvSab_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSab.CellContentClick
        ShowLoadAlert(dgvSab)
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        My.Forms.AddCompromisso.ShowDialog()
    End Sub

    Private Sub Loca��oToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Loca��oToolStripMenuItem1.Click
        My.Forms.LocacaoRelatorios.ShowDialog()
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem.Click

        My.Forms.ComprasRelat.ShowDialog()

    End Sub
End Class