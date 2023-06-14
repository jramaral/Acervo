Public Class CentroCustoDiaConferenciaRelat

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btVisualizar_Click(sender As Object, e As EventArgs) Handles btVisualizar.Click

        If Me.DataInicial.Text = "" Then
            MessageBox.Show("Favor informar a Data para gerar o relatório", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

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
        VerRelat.Load(DirRelat & "CentroCustoConferencia.rpt")

        Dim Crypto As New ClCrypto
        VerRelat.DataSourceConnections.Item(0).SetConnection(LocalBD & Nome_BD, LocalBD & Nome_BD, False)
        VerRelat.DataSourceConnections.Item(0).SetLogon("", Crypto.clsCrypto(SenhaBancoDados, False))

        Dim T As CrystalDecisions.CrystalReports.Engine.TextObject
        T = VerRelat.ReportDefinition.ReportObjects.Item("Titulo")
        T.Text = "Centro Custo Conferência dia: " & Me.DataInicial.Text

        Dim SelectFormula As String
        SelectFormula = "{LancamentoBanco.DataLancamento} = Date (" & Format(CDate(Me.DataInicial.Text), "yyyy,MM,dd") & ") And {LancamentoBanco.TipoLancamento} <>'C' and {LancamentoBanco.Empresa} = " & CodEmpresa
        VerRelat.DataDefinition.RecordSelectionFormula = SelectFormula


        Vz.ReportSource = VerRelat

        Tel.Controls.Add(Vz)

        Tel.ShowDialog()

        Cursor.Current = Cursors.Default


    End Sub

   
End Class