Imports System.Data.OleDb
Public Class BalanceteCentroCustoErro

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btVerificar_Click(sender As Object, e As EventArgs) Handles btVerificar.Click

        If Me.DataInicial.Text = "" Then
            MessageBox.Show("Favor informar a Data Inicial para a Pesquisa", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DataInicial.Focus()
            Exit Sub
        End If

        If Me.DataFinal.Text = "" Then
            MessageBox.Show("Favor informar a Data Final para a Pesquisa", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DataInicial.Focus()
            Exit Sub
        End If

        Dim cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        cnn.Open()

        Dim ds As New DataSet
        Dim Sql As String = String.Empty

        Sql = "SELECT Id, DataLancamento, ValorDocumento, TipoLancamento, ContaBalancete, IdLancamento, IdProcura, Tipo, DEV FROM LancamentoBanco WHERE (DataLancamento BETWEEN #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyy") & "# AND #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyy") & "#) AND (Empresa = " & CodEmpresa & ")"
        Dim daRD As New OleDbDataAdapter(Sql, cnn)
        daRD.Fill(ds, "RD")

        Sql = "SELECT * FROM CcLanc WHERE (DataLanc BETWEEN #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyy") & "# AND #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyy") & "#) Order by IdCaixaBanco"
        Dim daCC As New OleDbDataAdapter(Sql, cnn)
        daCC.Fill(ds, "CC")

        Dim TbErro As New DataTable
        TbErro.Columns.Add(New DataColumn("Identificador", GetType(String)))
        TbErro.Columns.Add(New DataColumn("Descrição", GetType(String)))

        Dim TotalLinhas As Integer = ds.Tables("RD").Rows.Count
        'Atualiza a barra de Progresso
        If TotalLinhas = 0 Then TotalLinhas = 1
        MyBarra.Visible = True
        MyBarra.Minimum = 1
        MyBarra.Maximum = TotalLinhas
        MyBarra.Value = 1
        MyBarra.Step = 1
        MyBarra.Text = "Aguarde...."

        Dim TxtErro As String = String.Empty
        Dim drValidar As DataRow
        For Each drValidar In ds.Tables("RD").Rows
            Application.DoEvents()

            Dim DRnovo As DataRow
            If drValidar("TipoLancamento") = "C" Then
                If NzZero(drValidar("ValorDocumento")) < 0 Then
                    If drValidar("DEV") = False Then
                        TxtErro = "Valor de um Credito lancado como negativo"
                        DRnovo = TbErro.NewRow()
                        DRnovo("Identificador") = "ID: " & drValidar("Id") & "    " & drValidar("IdLancamento") & "- Origem: " & drValidar("IdProcura")
                        DRnovo("Descrição") = TxtErro
                        TbErro.Rows.Add(DRnovo)
                        TxtErro = String.Empty
                    End If

                End If
                If IsDBNull(drValidar("ContaBalancete")) = True Then
                    TxtErro &= "Conta de Receita nao informado"

                    DRnovo = TbErro.NewRow()
                    DRnovo("Identificador") = "ID: " & drValidar("Id") & "    " & drValidar("IdLancamento") & "- Origem: " & drValidar("IdProcura")
                    DRnovo("Descrição") = TxtErro
                    TbErro.Rows.Add(DRnovo)
                    TxtErro = String.Empty

                End If

            End If

            If drValidar("TipoLancamento") = "D" Then
                If NzZero(drValidar("ValorDocumento")) > 0 Then
                    TxtErro = "Valor de um Debito lancado como Positivo"

                    DRnovo = TbErro.NewRow()
                    DRnovo("Identificador") = "ID: " & drValidar("Id") & "    " & drValidar("IdLancamento") & "- Origem: " & drValidar("IdProcura")
                    DRnovo("Descrição") = TxtErro
                    TbErro.Rows.Add(DRnovo)
                    TxtErro = String.Empty
                End If
                If IsDBNull(drValidar("ContaBalancete")) Then
                    TxtErro &= "Conta de Despesa nao informado"

                    DRnovo = TbErro.NewRow()
                    DRnovo("Identificador") = "ID: " & drValidar("Id") & "    " & drValidar("IdLancamento") & "- Origem: " & drValidar("IdProcura")
                    DRnovo("Descrição") = TxtErro
                    TbErro.Rows.Add(DRnovo)
                    TxtErro = String.Empty
                End If

                'Verificar centro de Custo
                Dim CCLinhas() As DataRow
                CCLinhas = ds.Tables("CC").Select("IdCaixaBanco = " & drValidar("Id"))

                If CCLinhas.Length > 0 Then

                    Dim SomaValor As Decimal
                    Dim I As Integer
                    For I = 0 To CCLinhas.Length - 1
                        SomaValor += CCLinhas(I)("ValorLanc")
                    Next
                    If FormatNumber(SomaValor, 2) <> FormatNumber((drValidar("ValorDocumento") * -1), 2) Then
                        TxtErro &= "Valor total lancado no centro de custo nao bate com o valor das despesas"

                        DRnovo = TbErro.NewRow()
                        DRnovo("Identificador") = "ID: " & drValidar("Id") & "    " & drValidar("IdLancamento") & "- Origem: " & drValidar("IdProcura")
                        DRnovo("Descrição") = TxtErro
                        TbErro.Rows.Add(DRnovo)
                        TxtErro = String.Empty
                    End If
                    SomaValor = 0

                    For I = 0 To CCLinhas.Length - 1
                        If drValidar("DataLancamento") <> CCLinhas(I)("DataLanc") Then
                            TxtErro &= "A Data de Lancamento do Centro de Custo esta diferente da Despesa"

                            DRnovo = TbErro.NewRow()
                            DRnovo("Identificador") = "ID: " & drValidar("Id") & "    " & drValidar("IdLancamento") & "- Origem: " & drValidar("IdProcura")
                            DRnovo("Descrição") = TxtErro
                            TbErro.Rows.Add(DRnovo)
                            TxtErro = String.Empty
                        End If
                    Next

                Else
                    If (drValidar("IdLancamento") & "") <> "TRANSFCAIXA" Then
                        If (drValidar("ContaBalancete") & "") <> "000000" Then
                            TxtErro &= "Sem centro de custo identificado"
                            DRnovo = TbErro.NewRow()
                            DRnovo("Identificador") = "ID: " & drValidar("Id") & "    " & drValidar("IdLancamento") & "- Origem: " & drValidar("IdProcura")
                            DRnovo("Descrição") = TxtErro
                            TbErro.Rows.Add(DRnovo)
                            TxtErro = String.Empty
                        End If
                    End If
                End If

            End If

            MyBarra.PerformStep()
        Next

        'Verificar se existe registro orfão

        Sql = "SELECT CCLanc.ID, CCLanc.IdCaixaBanco, CCLanc.ContaCC, CCLanc.DataLanc, CCLanc.ValorLanc FROM CCLanc LEFT JOIN LancamentoBanco ON CCLanc.IdCaixaBanco = LancamentoBanco.Id WHERE (((LancamentoBanco.Id) Is Null))"
        Dim daOrfão As New OleDbDataAdapter(Sql, cnn)
        daOrfão.Fill(ds, "Orfão")

        TotalLinhas = ds.Tables("Orfão").Rows.Count
        'Atualiza a barra de Progresso
        If TotalLinhas = 0 Then TotalLinhas = 1
        MyBarra.Visible = True
        MyBarra.Minimum = 1
        MyBarra.Maximum = TotalLinhas
        MyBarra.Value = 1
        MyBarra.Step = 1
        MyBarra.Text = "Aguarde...."

        Dim drOrfão As DataRow
        For Each drOrfão In ds.Tables("Orfão").Rows
            Application.DoEvents()

            'Dim DRnovo As DataRow

            'TxtErro = "Este Lancamento de centro de custo nao possui lancamento coincidente nas despesas"

            'DRnovo = TbErro.NewRow()
            'DRnovo("Identificador") = "ID ORFÃO: " & drOrfão("Id") & "    ID CAIXA/BANCO: " & drOrfão("IdCaixaBanco")
            'DRnovo("Descrição") = TxtErro
            'TbErro.Rows.Add(DRnovo)
            'TxtErro = String.Empty

            Dim cmd As New OleDbCommand("Delete from CCLanc Where Id = " & drOrfão("Id"), cnn)
            cmd.ExecuteNonQuery()
            MyBarra.PerformStep()
        Next

        ds.Tables.Add(TbErro)

        If TbErro.Rows.Count > 0 Then

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
            Vz.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

            'Carrega o relatorio
            Dim VerRelat As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            VerRelat.Load(DirRelat & "Erros.rpt")

            VerRelat.SetDataSource(ds.Tables("Table1"))
            Vz.ReportSource = VerRelat
            Tel.Controls.Add(Vz)

            Tel.ShowDialog()

            Cursor.Current = Cursors.Default
        Else
            MessageBox.Show("Validação não encontrou erro", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Close()
        Me.Dispose()

    End Sub

End Class