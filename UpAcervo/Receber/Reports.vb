Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class Reports


#Region "Relatorios de Boletos"

    Public Sub BoletosEmitidosDia()

        Cursor.Show()
        Cursor.Current = Cursors.WaitCursor

        Dim Tel As New Form() ' Create a new instance of the form.

        Dim Vz As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim F As New Font("Comic Sans MS", 8, System.Drawing.GraphicsUnit.Point)

        Tel.Text = "Visualizador de Relatório - " & DataDia
        Tel.Size = New Size(576, 352)
        Tel.HelpButton = False
        Tel.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Tel.MaximizeBox = True
        Tel.MinimizeBox = True
        Tel.ControlBox = True
        Tel.Font = F
        Tel.StartPosition = FormStartPosition.CenterScreen
        Tel.ShowInTaskbar = True
        Tel.WindowState = FormWindowState.Maximized

        Vz.Dock = DockStyle.Fill


        'Carrega o relatorio
        Dim VerRelat As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        VerRelat.Load(DirRelat & "BoletosEmitidosDia.rpt")

        Dim Crypto As New ClCrypto

        Dim logOnInfo As New TableLogOnInfo()
        Dim i As Integer
        For i = 0 To VerRelat.Database.Tables.Count - 1
            logOnInfo.ConnectionInfo.ServerName = LocalBD & Nome_BD
            logOnInfo.ConnectionInfo.DatabaseName = LocalBD & Nome_BD
            logOnInfo.ConnectionInfo.UserID = ""
            logOnInfo.ConnectionInfo.Password = Crypto.clsCrypto(SenhaBancoDados, False)
            VerRelat.Database.Tables.Item(i).ApplyLogOnInfo(logOnInfo)
        Next i



        ' VerRelat.DataSourceConnections.Item(0).SetConnection(LocalBD, Nome_BD, False)
        'VerRelat.DataSourceConnections.Item(0).SetLogon("Administrador", Crypto.clsCrypto(SenhaBancoDados, False))
        'ServidorSQL, DBSQL, False
        '"", Crypto.clsCrypto(SenhaSQL, False

        Dim dInicial As Date = Format(CDate(My.Forms.RelatBoletoEmitidoDia.DataInicial.Text), "dd/MM/yyyy")
        Dim dFinal As Date = Format(CDate(My.Forms.RelatBoletoEmitidoDia.DataFinal.Text), "dd/MM/yyyy")

        Dim SelectFormula As String
        SelectFormula = CrDateBetween("{Comando.DataProcessamento}", My.Forms.RelatBoletoEmitidoDia.DataInicial.Text, My.Forms.RelatBoletoEmitidoDia.DataFinal.Text) & " and {Comando.Cancelado} = False"

        VerRelat.DataDefinition.RecordSelectionFormula = SelectFormula


        Vz.ReportSource = VerRelat

        Tel.Controls.Add(Vz)

        Tel.ShowDialog()

        Cursor.Current = Cursors.Default

    End Sub



#End Region


    Private Function CrDateBetween(ByVal CampoFiltro As String, ByVal DataInicial As String, ByVal DataFinal As String) As String
        Dim DInicial As Date, DFinal As Date
        DInicial = CDate(DataInicial)
        DFinal = CDate(DataFinal)
        Return CampoFiltro & " in DateTime (" & Year(DInicial) & "," & Month(DInicial) & "," & Microsoft.VisualBasic.Day(DInicial) & ", 0, 0, 0) to DateTime (" & Year(DFinal) & "," & Month(DFinal) & "," & Microsoft.VisualBasic.Day(DFinal) & ", 0, 0, 0)"
    End Function

    Private Sub TeclaAtalhoImprimir(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Dim isControlPressed As Boolean = (Control.ModifierKeys And Keys.Control) <> 0
        If isControlPressed = True Then
            If e.KeyCode = Keys.P Then
                CType(CType(sender, System.Windows.Forms.Form).Controls(0), CrystalDecisions.Windows.Forms.CrystalReportViewer).PrintReport()
            End If
            If e.KeyCode = Keys.O Then
                CType(CType(sender, System.Windows.Forms.Form).Controls(0), CrystalDecisions.Windows.Forms.CrystalReportViewer).PrintReport()
                CType(CType(sender, System.Windows.Forms.Form).Controls(0), CrystalDecisions.Windows.Forms.CrystalReportViewer).Dispose()
                CType(sender, System.Windows.Forms.Form).Close()
                CType(sender, System.Windows.Forms.Form).Dispose()
            End If
        End If

    End Sub

    Private Sub TraduzirCRV(ByVal Cntl As CrystalReportViewer)
        For Each Ctl As Control In Cntl.Controls
            'Aqui está o dicionário para fazer a trudução, para quem quiser o texto em portugues que vai permanecer é só alterar aqui.
            Dim Traducoes As New Dictionary(Of String, String)()
            Traducoes.Add("Export Report", "Exportar")
            Traducoes.Add("Print Report", "Imprimir")
            Traducoes.Add("Refresh", "Atualizar")
            Traducoes.Add("Toggle Parameter Panel", "Mostrar/Esconder Painel de parâmetros")
            Traducoes.Add("Toggle Group Tree", "Mostrar/Esconder árvore de grupos")
            Traducoes.Add("Go to First Page", "Primeira página")
            Traducoes.Add("Go to Previous Page", "Página anterior")
            Traducoes.Add("Go to Next Page", "Próxima página")
            Traducoes.Add("Go to Last Page", "Última página")
            Traducoes.Add("Go to Page", "Ir para página")
            Traducoes.Add("Find Text", "Procurar")
            Traducoes.Add("Zoom", "Zoom")
            Traducoes.Add("Close Current View", "Fechar")
            Traducoes.Add("Page Width", "Largura da página")
            Traducoes.Add("Whole Page", "Página Inteira")
            Traducoes.Add("Customize...", "Customizar...")
            Traducoes.Add("Current Page No.", "Nr. página atual")
            Traducoes.Add("Total Page No.", "Nr. Total páginas")
            Traducoes.Add("Zoom Factor", "Nível de zoom")

            'Alterando o texto da tabpage principal(Onde está escrito Main Report).
            If Ctl.GetType.ToString() = GetType(PageView).ToString Then
                Try
                    DirectCast(Ctl.Controls(0), TabControl).TabPages(0).Text = "Relatório"
                Catch
                End Try

                'Alterando o texto dos componente que ficam na barra superior.
            ElseIf Ctl.GetType.ToString() = GetType(System.Windows.Forms.ToolStrip).ToString Then
                For Each Ti As ToolStripItem In DirectCast(Ctl, ToolStrip).Items
                    If Ti.ToolTipText IsNot Nothing Then
                        Ti.ToolTipText = Traducoes(Ti.ToolTipText)
                        'Aqui eu escondo dois itens da barra superior que no meu contexto são irrelevantes o que mostra uma barra com os parametros
                        ' e o que mostra uma treeview com os grupos do relatório.
                        If Ti.ToolTipText = "Invisible" Then
                            Ti.Visible = False

                            'Aqui traduzindo os itens dentro do dropdown Zoom.
                        ElseIf Ti.ToolTipText = "Zoom" AndAlso Ti.GetType.ToString() = GetType(ToolStripDropDownButton).ToString Then
                            Dim ItensDD As String(,) = New String(29, 3) {}
                            For Each TiF As ToolStripItem In DirectCast(Ti, ToolStripDropDownButton).DropDownItems
                                Try
                                    TiF.Text = Traducoes(TiF.Text)
                                Catch
                                End Try
                            Next
                        End If
                    End If
                Next

                'Alterando os textos da status bar
            ElseIf Ctl.GetType.ToString() = GetType(StatusBar).ToString Then
                For Each StBrPnl As StatusBarPanel In DirectCast(Ctl, StatusBar).Panels
                    Dim Texto As String = StBrPnl.Text.Substring(0, StBrPnl.Text.IndexOf(":"))
                    StBrPnl.Text = StBrPnl.Text.Replace(Texto, Traducoes(Texto))
                Next
            End If
        Next
    End Sub

    'Private Sub frmRelatorio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Me.TraduzirCRV(Me.CrystalReportViewer1)
    'End Sub

End Class
