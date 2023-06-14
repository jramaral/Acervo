Imports System.Data.OleDb
Imports ClassView
Public Class PagarBaixa

    Dim DS As New DataSet()

    Dim A��o As New TrfGerais()

    Public IdContaLanc As String 'JUROS/MULTA/DESCONTO/VALORDOC

    Dim cbJuros As String = String.Empty
    Dim cbMulta As String = String.Empty
    Dim cbDesco As String = String.Empty
    Dim cbValor As String = String.Empty

    Dim ContaCCJ As String = String.Empty
    Dim ContaCCM As String = String.Empty
    Dim ContaCCD As String = String.Empty
    Dim extenso As New ActiveIT.cExtenso


    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub LocalizaDadosEmpresa()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "Select * from Empresa where C�digoEmpresa = " & CodEmpresa
        Dim CMD As New OleDb.OleDbCommand(Sql, Cnn)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            cbJuros = DR.Item("cJurosPagar") & ""
            cbMulta = DR.Item("cMultaPagar") & ""
            cbDesco = DR.Item("cDescPagar") & ""
            cbValor = DR.Item("cValorPagar") & ""

            ContaCCJ = DR.Item("ContaCCJuros") & ""
            ContaCCM = DR.Item("ContaCCMulta") & ""
            ContaCCD = DR.Item("ContaCCDescConcedido") & ""
        End If
        DR.Close()

    End Sub


    Public Sub AchaRegistro(ByVal IdPagar As String)

        CarregaComboBox()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Cmd As New OleDb.OleDbCommand()
        Dim DR As OleDb.OleDbDataReader

        Cnn.Open()

        With Cmd
            .Connection = Cnn
            .CommandTimeout = 0
            .CommandText = "SELECT Pagar.* FROM Pagar WHERE Pagar.Id = " & IdPagar
            .CommandType = CommandType.Text
        End With

        Try

            DR = Cmd.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                Me.CodFornecedor.Text = DR.Item("CodFornecedor")
                Me.Fornecedor.Text = DR.Item("Fornecedor")
                Me.Id.Text = DR.Item("Id")
                Me.Documento.Text = DR.Item("Documento") & ""
                Me.DataDocumento.Text = DR.Item("DataDocumento")
                Me.Vencimento.Text = DR.Item("Vencimento")
                Me.Juros.Text = FormatCurrency(NzZero(DR.Item("Juros")), 2)
                Me.Multa.Text = FormatCurrency(Nz(DR.Item("Multa"), 3), 2)
                Me.ValorDocumento.Text = FormatCurrency(DR.Item("ValorDocumento"), 2)
                Me.Desconto.Text = FormatCurrency(NzZero(DR.Item("Desconto")), 2)
                Me.ValorLiquido.Text = FormatCurrency(NzZero(DR.Item("ValorLiquido")), 2)
                Me.Pagamento.Text = DR.Item("Pagamento") & ""
                Me.LocalPgto.Text = UCase(DR.Item("LocalPgto") & "")
                Me.Banco.Text = DR.Item("Banco") & ""
                Me.DocRecebBanco.Text = DR.Item("DocRecebBanco") & ""
                Me.Referencia.Text = DR.Item("Referencia") & ""
                Me.Destino.Text = DR.Item("Destino") & ""
                Me.Baixado.Checked = DR.Item("Baixado")
                Me.NotaFiscal.Text = DR.Item("NotaFiscal") & ""

                Me.IdCompra.Text = DR.Item("IdCompra") & ""
                Me.IdCompraCtrlPedido.Text = DR.Item("IdCompraCtrlPedido") & ""

                Me.ContaValorBaixado.Text = DR.Item("ContaValorBaixado") & ""
                Me.Conta1.Text = DR.Item("Conta1") & ""
                Me.Conta2.Text = DR.Item("Conta2") & ""
                Me.Conta3.Text = DR.Item("Conta3") & ""
                Me.Conta4.Text = DR.Item("Conta4") & ""
                Me.Conta5.Text = DR.Item("Conta5") & ""
                Me.Conta6.Text = DR.Item("Conta6") & ""

                Me.Percent1.Text = FormatNumber(nzNUM(DR.Item("Percent1")), 2)
                Me.Percent2.Text = FormatNumber(nzNUM(DR.Item("Percent2")), 2)
                Me.Percent3.Text = FormatNumber(nzNUM(DR.Item("Percent3")), 2)
                Me.Percent4.Text = FormatNumber(nzNUM(DR.Item("Percent4")), 2)
                Me.Percent5.Text = FormatNumber(nzNUM(DR.Item("Percent5")), 2)
                Me.Percent6.Text = FormatNumber(nzNUM(DR.Item("Percent6")), 2)

            End If

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()

        AchaContaBalancete(Me.ContaValorBaixado.Text, Me.ContaValorBaixadoDesc)
        AchaContaCC(Me.Conta1.Text, Me.Conta1Desc)
        AchaContaCC(Me.Conta2.Text, Me.Conta2Desc)
        AchaContaCC(Me.Conta3.Text, Me.Conta3Desc)
        AchaContaCC(Me.Conta4.Text, Me.Conta4Desc)
        AchaContaCC(Me.Conta5.Text, Me.Conta5Desc)
        AchaContaCC(Me.Conta6.Text, Me.Conta6Desc)
    End Sub

    Private Sub Desconto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Desconto.Enter
        If Me.Desconto.Text = "" Then Me.Desconto.Text = FormatCurrency(0, 2)
    End Sub

    Private Sub Juros_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Juros.Enter
        If Me.Juros.Text = "" Then Me.Juros.Text = FormatCurrency(0, 2)
    End Sub

    Private Sub ValorLiquido_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValorLiquido.Enter
        If Me.Desconto.Text = "" Then Me.Desconto.Text = FormatCurrency(0, 2)
        If Me.Juros.Text = "" Then Me.Juros.Text = FormatCurrency(0, 2)
        If Me.Multa.Text = "" Then Me.Multa.Text = FormatCurrency(0, 2)
        Me.ValorLiquido.Text = FormatCurrency(CDbl(Me.ValorDocumento.Text) + CDbl(Me.Juros.Text) + CDbl(Me.Multa.Text) - CDbl(Me.Desconto.Text), 2)
    End Sub

    Private Sub LocalPgto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LocalPgto.Leave

        Dim DrRow() As DataRow
        DrRow = DS.Tables("LocalPgto").Select("LocalPgto = '" & Me.LocalPgto.Text & "'")

        If DrRow.Length > 0 Then
            If Me.LocalPgto.Text = "BANCO" Then
                Me.Banco.Visible = True
                Me.DocRecebBanco.Visible = True
                Me.BancoDesc.Visible = True
                Me.LabelBanco.Visible = True
                Me.LabelDocCheque.Visible = True
                Me.PanelPreDatado.Visible = True
                Me.Banco.Focus()
            Else
                Me.Banco.Visible = False
                Me.DocRecebBanco.Visible = False
                Me.BancoDesc.Visible = False
                Me.LabelBanco.Visible = False
                Me.LabelDocCheque.Visible = False
                Me.PanelPreDatado.Visible = False
                Me.Pagamento.Focus()
            End If
        End If
    End Sub

    Private Sub btBaixa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBaixa.Click

        If CaixaAtivo = "" Then
            MsgBox("A usu�rio deve informar o caixa para o lan�amento.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If CDbl(NzZero(Me.Juros.Text)) > 0 Then
            If ContaCCD = "" Then
                MessageBox.Show("N�o foi definido conta para Juros, o juros n�o pode ser aplicado.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Juros.Text = FormatNumber(0, 2)
                Exit Sub
            End If
        End If
        If CDbl(NzZero(Me.Multa.Text)) > 0 Then
            If ContaCCM = "" Then
                MessageBox.Show("N�o foi definido conta para Multa, a multa n�o pode ser aplicada.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Multa.Text = FormatNumber(0, 2)
                Exit Sub
            End If
        End If
        If CDbl(NzZero(Me.Desconto.Text)) > 0 Then
            If ContaCCD = "" Then
                MessageBox.Show("N�o foi definido conta para Desconto, o Desconto n�o pode ser aplicado.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Desconto.Text = FormatNumber(0, 2)
                Exit Sub
            End If
        End If

        If Me.Pagamento.Text = "" Then
            MsgBox("A data de Pagamento n�o foi informada, verifique", 64, "Valida��o de Dados")
            Me.Pagamento.Focus()
            Exit Sub
        End If

        If CDate(Me.Pagamento.Text) <> CDate(DataDia) Then
            MsgBox("A data de baixa do documento est� diferente da data de trabalho", 64, "Valida��o de Dados")
            Exit Sub
        End If
        If Me.NotaFiscal.Text = "" Then Me.NotaFiscal.Text = 0

        If Me.Baixado.Checked = True Then
            MsgBox("O documento ja foi baixado, escolha outro", 64, "Valida��o de Dados")
            Exit Sub
        End If


        If Me.LocalPgto.Text = "BANCO" Then
            If Me.Banco.Text = "" Then
                MsgBox("Para pagamento em banco a conta corrente n�o pode ser nula", 64, "Valida��o de Dados")
                Me.Banco.Focus()
                Exit Sub
            End If
            ''
            If Me.Banco.Text = "0" Then
                MsgBox("Para pagamento em banco a conta corrente n�o pode ser nula", 64, "Valida��o de Dados")
                Me.Banco.Focus()
                Exit Sub
            End If
            ''
            If Me.DocRecebBanco.Text = "" Then
                MsgBox("Para pagamento em banco o documento de recebimento em banco n�o pode ser nulo", 64, "Valida��o de Dados")
                Me.DocRecebBanco.Focus()
                Exit Sub
            End If

            If Me.PagoComPreDatado.Checked = True Then
                If Me.DataPreDatado.Text = "" Then
                    MessageBox.Show("A data de Vencimento do Cheque-pr� n�o foi informada, Verifique.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DataPreDatado.Focus()
                    Exit Sub
                End If
                If Me.DocRecebBanco.Text = "" Then
                    MessageBox.Show("O numero do Cheque-pr� n�o foi informada, Verifique.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DocRecebBanco.Focus()
                    Exit Sub
                End If
            End If
        End If


        If FormatCurrency(Me.Juros.Text, 2) > FormatCurrency(0, 2) And Me.ContaJuros.Text = "" Then
            MessageBox.Show("O usu�rio deve informar a conta de lan�amento para os Juros.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ContaJuros.Focus()
            Exit Sub
        End If
        If FormatCurrency(Me.Multa.Text, 2) > FormatCurrency(0, 2) And Me.ContaMulta.Text = "" Then
            MessageBox.Show("O usu�rio deve informar a conta de lan�amento para a Multa.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ContaMulta.Focus()
            Exit Sub
        End If
        If FormatCurrency(Me.Desconto.Text, 2) > FormatCurrency(0, 2) And Me.ContaDesconto.Text = "" Then
            MessageBox.Show("O usu�rio deve informar a conta de lan�amento para os Descontos.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ContaDesconto.Focus()
            Exit Sub
        End If


        If CDbl(NzZero(Me.Vlr1.Text)) > 0 Then
            If Me.Conta1.Text = "" Then
                MessageBox.Show("Favor informar a conta de centro custo", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Conta1.Focus()
            End If
        End If

        If CDbl(NzZero(Me.Vlr2.Text)) > 0 Then
            If Me.Conta2.Text = "" Then
                MessageBox.Show("Favor informar a conta de centro custo", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Conta2.Focus()
            End If
        End If

        If CDbl(NzZero(Me.Vlr3.Text)) > 0 Then
            If Me.Conta3.Text = "" Then
                MessageBox.Show("Favor informar a conta de centro custo", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Conta3.Focus()
            End If
        End If

        If CDbl(NzZero(Me.Vlr4.Text)) > 0 Then
            If Me.Conta4.Text = "" Then
                MessageBox.Show("Favor informar a conta de centro custo", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Conta4.Focus()
            End If
        End If

        If CDbl(NzZero(Me.Vlr5.Text)) > 0 Then
            If Me.Conta5.Text = "" Then
                MessageBox.Show("Favor informar a conta de centro custo", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Conta5.Focus()
            End If
        End If

        If CDbl(NzZero(Me.Vlr6.Text)) > 0 Then
            If Me.Conta6.Text = "" Then
                MessageBox.Show("Favor informar a conta de centro custo", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Conta6.Focus()
            End If
        End If



        If CDbl(NzZero(Me.TotalCC.Text)) <> FormatNumber(CDbl(NzZero(Me.ValorDocBaixar.Text) + CDbl(NzZero(Me.Multa.Text) + CDbl(NzZero(Me.Juros.Text) - CDbl(NzZero(Me.Desconto.Text))))), 2) Then
            MessageBox.Show("O Valor para lan�amento no centro de custo esta diferente do valor de baixa do Documento.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ValorDocumento.Focus()
            Exit Sub
        End If



        Dim Vlr_Liq As Double = FormatNumber(CDbl(NzZero(Me.ValorLiquido.Text)), 2)
        Dim Vlr_Soma As Double = FormatNumber(CDbl(NzZero(Me.ValorDocumento.Text)) + CDbl(NzZero(Me.Multa.Text)) + CDbl(NzZero(Me.Juros.Text)) - CDbl(NzZero(Me.Desconto.Text)), 2)

        If Vlr_Liq > Vlr_Soma Then
            MessageBox.Show("O valor a ser pago n�o pode ser maior que a soma dos valores.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If CDbl(NzZero(Me.ValorLiquido.Text)) = 0 Then
            MessageBox.Show("N�o pode baixar um documento com valor zero", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Me.Refresh()


        If DiaFechado = False Then

            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()

            Dim Transacao As OleDbTransaction = CNN.BeginTransaction()

            Dim CmdBanco As OleDbCommand = CNN.CreateCommand
            Dim CmdJuros As OleDbCommand = CNN.CreateCommand
            Dim CmdMulta As OleDbCommand = CNN.CreateCommand
            Dim CmdDesconto As OleDbCommand = CNN.CreateCommand
            Dim CmdBaixa As OleDbCommand = CNN.CreateCommand
            Dim CmdBaixaParcial As OleDbCommand = CNN.CreateCommand

            CmdBanco.Transaction = Transacao
            CmdJuros.Transaction = Transacao
            CmdMulta.Transaction = Transacao
            CmdDesconto.Transaction = Transacao
            CmdBaixa.Transaction = Transacao
            CmdBaixaParcial.Transaction = Transacao


            Try

                Dim TotalDoc As Double
                TotalDoc = FormatNumber(CDbl(Me.ValorDocumento.Text) + CDbl(Me.Multa.Text) + CDbl(Me.Juros.Text), 2)

                Dim VarLiquido As Double = CDbl(Me.ValorLiquido.Text)
                If TotalDoc < 0 Then
                    VarLiquido = VarLiquido * -1
                    TotalDoc = TotalDoc * -1
                End If

                If CDbl(TotalDoc) > CDbl(VarLiquido) + CDbl(Me.Desconto.Text) Then
                    MsgBox("O valor do documento esta diferente do total, ser� criado um documento com a diferen�a: " & FormatCurrency(CDbl(Me.ValorDocumento.Text) - CDbl(Me.ValorLiquido.Text), 2), 64, "Valida��o de Dados")

                    Dim Diferen�a As Double = CDbl(Me.ValorDocumento.Text) - (CDbl(Me.ValorLiquido.Text) + CDbl(Me.Desconto.Text) - CDbl(Me.Juros.Text) - CDbl(Me.Multa.Text))

                    CmdBaixaParcial.CommandText = "INSERT INTO Pagar (Fornecedor, CodFornecedor, DataDocumento, Documento, Empresa, ValorDocumento, Vencimento, LocalPgto, NotaFiscal, VinculoBXPARCIAL, Destino, ContaValorBaixado, Conta1, Conta2, Conta3, Conta4, Conta5, Conta6, Percent1, Percent2, Percent3, Percent4, Percent5, Percent6, Idcompra,IdCompraCtrlPedido) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20, @21, @22, @23, @24, @25, @26)"

                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.Fornecedor.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.CodFornecedor.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.DataDocumento.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.Documento.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@5", CodEmpresa))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@6", Diferen�a))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.Vencimento.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.LocalPgto.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.NotaFiscal.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.Id.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.Destino.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.ContaValorBaixado.Text, 1)))

                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(Me.Conta1.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.Conta2.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.Conta3.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.Conta4.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Conta5.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.Conta6.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@19", Nz(Me.Percent1.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@20", Nz(Me.Percent2.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@21", Nz(Me.Percent3.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@22", Nz(Me.Percent4.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@23", Nz(Me.Percent5.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@24", Nz(Me.Percent6.Text, 1)))

                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@25", Nz(Me.IdCompra.Text, 1)))
                    CmdBaixaParcial.Parameters.Add(New OleDb.OleDbParameter("@26", Nz(Me.IdCompraCtrlPedido.Text, 1)))

                    CmdBaixaParcial.ExecuteNonQuery()
                End If



                Dim Tp As String = String.Empty : Dim CC As String = String.Empty : Dim DOC As String = String.Empty
                Dim xCompensado As String = String.Empty

                If Me.LocalPgto.Text = "BANCO" Then
                    Tp = "BANCO"
                    CC = Me.Banco.Text
                    DOC = Me.DocRecebBanco.Text
                    xCompensado = "N"
                Else
                    Tp = "CAIXA"
                    CC = CaixaAtivo
                    DOC = Me.Documento.Text
                    xCompensado = "S"
                End If

                CmdBanco.CommandText = "INSERT INTO LancamentoBanco (DataLancamento, DataDocumento, TipoLancamento, ContaCorrente, Favorecido, Documento, ValorDocumento, EmitirCheque, ConfirmadoLancamento, Empresa, Historico, CaiuBanco, DocumentoExterno, ContaBalancete, Tipo, IdLancamento, IdProcura, PreDatado, DataPreDatado) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19)"
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@1", DataDia))
                Dim ValorLanc As Double = (CDbl(NzZero(Me.ValorLiquido.Text)) + CDbl(NzZero(Me.Desconto.Text)) - CDbl(NzZero(Me.Juros.Text)) - CDbl(NzZero(Me.Multa.Text)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.DataDocumento.Text, 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@3", Nz("D", 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(CC, 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.Fornecedor.Text, 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(DOC, 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@7", ValorLanc * -1))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@8", Nz("N", 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@9", True))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@10", CodEmpresa))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@11", Nz("PGTO. DOC N� " & DOC & ":" & "NF" & ": " & Me.NotaFiscal.Text & " Fornecedor: " & CodFornecedor.Text & "-" & Me.Fornecedor.Text, 1))) 'Nz(Me.Referencia.Text, 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(xCompensado, 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@13", True))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.ContaValorBaixado.Text, 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Tp, 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@16", "PAGAR"))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Id.Text, 1)))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@18", Me.PagoComPreDatado.Checked))
                CmdBanco.Parameters.Add(New OleDb.OleDbParameter("@19", Nz(Me.DataPreDatado.Text, 1)))
                CmdBanco.ExecuteNonQuery()

                CmdBanco.CommandText = "SELECT @@IDENTITY"
                Dim IdLancBancoCaixa As Integer = CmdBanco.ExecuteScalar.ToString


                'Verifica se no banco o valor de juros for maior que zero.
                Dim IdJurosBancoCaixa As Integer
                If CDbl(Me.Juros.Text) > 0 Then

                    CmdJuros.CommandText = "INSERT INTO LancamentoBanco (DataLancamento, DataDocumento, TipoLancamento, ContaCorrente, Favorecido, Documento, ValorDocumento, EmitirCheque, ConfirmadoLancamento, Empresa, Historico, CaiuBanco, DocumentoExterno, ContaBalancete, Tipo, IdLancamento, IdProcura) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17)"
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@1", DataDia))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.DataDocumento.Text, 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@3", Nz("D", 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(CC, 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@5", Nz("PAGAMENTO JUROS", 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(DOC, 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@7", NzZero(Me.Juros.Text) * -1))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@8", Nz("N", 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@9", True))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@10", CodEmpresa))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@11", "JUROS PAGO DOC : " & Nz(DOC, 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(xCompensado, 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@13", True))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.ContaJuros.Text, 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Tp, 1)))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@16", "PAGAR"))
                    CmdJuros.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Id.Text, 1)))
                    CmdJuros.ExecuteNonQuery()

                    CmdJuros.CommandText = "SELECT @@IDENTITY"
                    IdJurosBancoCaixa = CmdJuros.ExecuteScalar.ToString


                End If

                'Rotina para multas se for lan�amento em banco.
                Dim IdMultaBancoCaixa As Integer
                If CDbl(Me.Multa.Text) > 0 Then

                    CmdMulta.CommandText = "INSERT INTO LancamentoBanco (DataLancamento, DataDocumento, TipoLancamento, ContaCorrente, Favorecido, Documento, ValorDocumento, EmitirCheque, ConfirmadoLancamento, Empresa, Historico, CaiuBanco, DocumentoExterno, ContaBalancete, Tipo, IdLancamento, IdProcura) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17)"
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@1", DataDia))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.DataDocumento.Text, 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@3", Nz("D", 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(CC, 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@5", Nz("PAGAMENTO MULTA", 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(DOC, 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@7", NzZero(Me.Multa.Text) * -1))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@8", Nz("N", 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@9", True))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@10", CodEmpresa))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@11", "MULTA PAGA DOC: " & Nz(DOC, 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(xCompensado, 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@13", True))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.ContaMulta.Text, 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Tp, 1)))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@16", "PAGAR"))
                    CmdMulta.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Id.Text, 1)))
                    CmdMulta.ExecuteNonQuery()

                    CmdMulta.CommandText = "SELECT @@IDENTITY"
                    IdMultaBancoCaixa = CmdMulta.ExecuteScalar.ToString
                End If

                'Rotina para Desconto se for lan�amento em banco.
                Dim IdDescontoBancoCaixa As Integer
                If CDbl(Me.Desconto.Text) > 0 Then

                    CmdDesconto.CommandText = "INSERT INTO LancamentoBanco (DataLancamento, DataDocumento, TipoLancamento, ContaCorrente, Favorecido, Documento, ValorDocumento, EmitirCheque, ConfirmadoLancamento, Empresa, Historico, CaiuBanco, DocumentoExterno, ContaBalancete, Tipo, IdLancamento, IdProcura) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17)"
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@1", DataDia))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.DataDocumento.Text, 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@3", Nz("C", 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(CC, 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@5", Nz("DESCONTO RECEBIDO", 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(DOC, 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.Desconto.Text, 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@8", Nz("N", 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@9", True))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@10", CodEmpresa))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@11", "DESC. RECEB. DOC: " & Nz(DOC, 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(xCompensado, 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@13", True))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.ContaDesconto.Text, 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Tp, 1)))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@16", "PAGAR"))
                    CmdDesconto.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Id.Text, 1)))
                    CmdDesconto.ExecuteNonQuery()

                    CmdDesconto.CommandText = "SELECT @@IDENTITY"
                    IdDescontoBancoCaixa = CmdDesconto.ExecuteScalar.ToString
                End If

                'Baixar o documento
                Me.Baixado.Checked = True
                CmdBaixa.CommandText = "Update Pagar set CodFornecedor = @1, Fornecedor = @2, Documento = @3, DataDocumento = @4, Vencimento = @5, Juros = @6, ValorDocumento = @7, Desconto = @8, ValorLiquido = @9, Pagamento = @10, LocalPgto = @11, Banco = @12, DocRecebBanco = @13, Referencia = @14, Baixado = @15, Multa = @16, PagoComChequeNumero = @17, CaixaBaixado = @18, PagoComPreDatado = @19, DataPreDatado = @20 Where Id = " & Me.Id.Text

                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.CodFornecedor.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Fornecedor.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.Documento.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.DataDocumento.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.Vencimento.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.Juros.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.ValorDocumento.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.Desconto.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.ValorLiquido.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.Pagamento.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.LocalPgto.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.Banco.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(Me.DocRecebBanco.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.Referencia.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@15", Me.Baixado.Checked))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.Multa.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.DocRecebBanco.Text, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(CaixaAtivo, 1)))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@19", Me.PagoComPreDatado.Checked))
                CmdBaixa.Parameters.Add(New OleDb.OleDbParameter("@20", Nz(Me.DataPreDatado.Text, 1)))
                CmdBaixa.ExecuteNonQuery()


                'Rotina para Gerar os balancetes Novos
                Dim CmdConta1 As OleDbCommand = CNN.CreateCommand
                Dim CmdConta2 As OleDbCommand = CNN.CreateCommand
                Dim CmdConta3 As OleDbCommand = CNN.CreateCommand
                Dim CmdConta4 As OleDbCommand = CNN.CreateCommand
                Dim CmdConta5 As OleDbCommand = CNN.CreateCommand
                Dim CmdConta6 As OleDbCommand = CNN.CreateCommand
                Dim CmdJ As OleDbCommand = CNN.CreateCommand
                Dim CmdM As OleDbCommand = CNN.CreateCommand
                Dim CmdD As OleDbCommand = CNN.CreateCommand

                CmdConta1.Transaction = Transacao
                CmdConta2.Transaction = Transacao
                CmdConta3.Transaction = Transacao
                CmdConta4.Transaction = Transacao
                CmdConta5.Transaction = Transacao
                CmdConta6.Transaction = Transacao
                CmdJ.Transaction = Transacao
                CmdM.Transaction = Transacao
                CmdD.Transaction = Transacao

               
                If Me.Conta1.Text <> "" Then
                    CmdConta1.CommandText = "INSERT INTO CcLanc (IdCaixaBanco, ContaCC, DataLanc, ValorLanc) VALUES (@1, @2, @3, @4)"
                    CmdConta1.Parameters.Add(New OleDbParameter("@1", nzINT(IdLancBancoCaixa)))
                    CmdConta1.Parameters.Add(New OleDbParameter("@2", nzNUL(Me.Conta1.Text)))
                    CmdConta1.Parameters.Add(New OleDbParameter("@3", nzDAT(DataDia)))
                    CmdConta1.Parameters.Add(New OleDbParameter("@4", nzNUM(Me.Vlr1.Text)))
                    CmdConta1.ExecuteNonQuery()
                End If

                If Me.Conta2.Text <> "" Then
                    CmdConta2.CommandText = "INSERT INTO CcLanc (IdCaixaBanco, ContaCC, DataLanc, ValorLanc) VALUES (@1, @2, @3, @4)"
                    CmdConta2.Parameters.Add(New OleDbParameter("@1", nzINT(IdLancBancoCaixa)))
                    CmdConta2.Parameters.Add(New OleDbParameter("@2", nzNUL(Me.Conta2.Text)))
                    CmdConta2.Parameters.Add(New OleDbParameter("@3", nzDAT(DataDia)))
                    CmdConta2.Parameters.Add(New OleDbParameter("@4", nzNUM(Me.Vlr2.Text)))
                    CmdConta2.ExecuteNonQuery()
                End If

                If Me.Conta3.Text <> "" Then
                    CmdConta3.CommandText = "INSERT INTO CcLanc (IdCaixaBanco, ContaCC, DataLanc, ValorLanc) VALUES (@1, @2, @3, @4)"
                    CmdConta3.Parameters.Add(New OleDbParameter("@1", nzINT(IdLancBancoCaixa)))
                    CmdConta3.Parameters.Add(New OleDbParameter("@2", nzNUL(Me.Conta3.Text)))
                    CmdConta3.Parameters.Add(New OleDbParameter("@3", nzDAT(DataDia)))
                    CmdConta3.Parameters.Add(New OleDbParameter("@4", nzNUM(Me.Vlr3.Text)))
                    CmdConta3.ExecuteNonQuery()
                End If

                If Me.Conta4.Text <> "" Then
                    CmdConta4.CommandText = "INSERT INTO CcLanc (IdCaixaBanco, ContaCC, DataLanc, ValorLanc) VALUES (@1, @2, @3, @4)"
                    CmdConta4.Parameters.Add(New OleDbParameter("@1", nzINT(IdLancBancoCaixa)))
                    CmdConta4.Parameters.Add(New OleDbParameter("@2", nzNUL(Me.Conta4.Text)))
                    CmdConta4.Parameters.Add(New OleDbParameter("@3", nzDAT(DataDia)))
                    CmdConta4.Parameters.Add(New OleDbParameter("@4", nzNUM(Me.Vlr4.Text)))
                    CmdConta4.ExecuteNonQuery()

                End If

                If Me.Conta5.Text <> "" Then
                    CmdConta5.CommandText = "INSERT INTO CcLanc (IdCaixaBanco, ContaCC, DataLanc, ValorLanc) VALUES (@1, @2, @3, @4)"
                    CmdConta5.Parameters.Add(New OleDbParameter("@1", nzINT(IdLancBancoCaixa)))
                    CmdConta5.Parameters.Add(New OleDbParameter("@2", nzNUL(Me.Conta5.Text)))
                    CmdConta5.Parameters.Add(New OleDbParameter("@3", nzDAT(DataDia)))
                    CmdConta5.Parameters.Add(New OleDbParameter("@4", nzNUM(Me.Vlr5.Text)))
                    CmdConta5.ExecuteNonQuery()
                End If

                If Me.Conta6.Text <> "" Then
                    CmdConta6.CommandText = "INSERT INTO CcLanc (IdCaixaBanco, ContaCC, DataLanc, ValorLanc) VALUES (@1, @2, @3, @4)"
                    CmdConta6.Parameters.Add(New OleDbParameter("@1", nzINT(IdLancBancoCaixa)))
                    CmdConta6.Parameters.Add(New OleDbParameter("@2", nzNUL(Me.Conta6.Text)))
                    CmdConta6.Parameters.Add(New OleDbParameter("@3", nzDAT(DataDia)))
                    CmdConta6.Parameters.Add(New OleDbParameter("@4", nzNUM(Me.Vlr6.Text)))
                    CmdConta6.ExecuteNonQuery()
                End If

                If CDbl(Me.Juros.Text) > 0 Then
                    CmdJ.CommandText = "INSERT INTO CcLanc (IdCaixaBanco, ContaCC, DataLanc, ValorLanc) VALUES (@1, @2, @3, @4)"
                    CmdJ.Parameters.Add(New OleDbParameter("@1", nzINT(IdJurosBancoCaixa)))
                    CmdJ.Parameters.Add(New OleDbParameter("@2", nzNUL(ContaCCJ)))
                    CmdJ.Parameters.Add(New OleDbParameter("@3", nzDAT(DataDia)))
                    CmdJ.Parameters.Add(New OleDbParameter("@4", nzNUM(Me.Juros.Text)))
                    CmdJ.ExecuteNonQuery()
                End If

                If CDbl(Me.Multa.Text) > 0 Then
                    CmdM.CommandText = "INSERT INTO CcLanc (IdCaixaBanco, ContaCC, DataLanc, ValorLanc) VALUES (@1, @2, @3, @4)"
                    CmdM.Parameters.Add(New OleDbParameter("@1", nzINT(IdMultaBancoCaixa)))
                    CmdM.Parameters.Add(New OleDbParameter("@2", nzNUL(ContaCCM)))
                    CmdM.Parameters.Add(New OleDbParameter("@3", nzDAT(DataDia)))
                    CmdM.Parameters.Add(New OleDbParameter("@4", nzNUM(Me.Multa.Text)))
                    CmdM.ExecuteNonQuery()
                End If

                If CDbl(Me.Desconto.Text) > 0 Then
                    CmdD.CommandText = "INSERT INTO CcLanc (IdCaixaBanco, ContaCC, DataLanc, ValorLanc) VALUES (@1, @2, @3, @4)"
                    CmdD.Parameters.Add(New OleDbParameter("@1", nzINT(IdDescontoBancoCaixa)))
                    CmdD.Parameters.Add(New OleDbParameter("@2", nzNUL(ContaCCD)))
                    CmdD.Parameters.Add(New OleDbParameter("@3", nzDAT(DataDia)))
                    CmdD.Parameters.Add(New OleDbParameter("@4", nzNUM(Me.Desconto.Text)))
                    CmdD.ExecuteNonQuery()
                End If

                'Fim

                Transacao.Commit()
                CNN.Close()
                MsgBox("Documento Baixado com sucesso.", 64, "Valida��o de Dados")
                GerarLog(Me.Text, A��oTP.Confirmou, Me.Documento.Text)
                If MsgBox("Deseja imprimir o recibo", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Recibo") = MsgBoxResult.Yes Then

                    RelatorioCarregar = "ReciboPagar.rpt"
                    Dim strFormula As String = "{Pagar.Id}=" & Me.Id.Text
                    'chama a classe e passa os parametros para o relatorio
                    Dim f As New cView
                    Dim str As String = extenso.Executar(Me.ValorLiquido.Text)
                    'adiciona valores para as formulas no contrato
                    f.AddFormula("strExtenso", str)

                    'executa o relatorio
                    f.frm(DirRelat & RelatorioCarregar, LocalBD & Nome_BD, SenhaBancoDados, "rrr", strFormula, False)


                End If

                My.Forms.Pagar.EncheLista()
                Me.Close()
                Me.Dispose()
            Catch ex As Exception
                Transacao.Rollback()
                MsgBox(ex.Message, 64, "Valida��o de Dados")
                MsgBox("Erro na Baixa do Documento.", 64, "Valida��o de Dados")
                MsgBox(ex.Message, 64, "Valida��o de Dados")
                CNN.Close()
            End Try

        Else
            MsgBox("O lan�amento n�o pode ser feito em um caixa ja fechado", 64, "Valida��o de Dados")
            Me.Pagamento.Clear()
            Me.Baixado.Checked = False
            Me.Documento.Focus()
        End If

    End Sub

    Private Sub ValorLiquido_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValorLiquido.Leave
        If Me.ValorLiquido.Text = "" Then
            Me.ValorLiquido.Text = FormatCurrency(0, 2)
        Else
            Me.ValorLiquido.Text = FormatCurrency(Me.ValorLiquido.Text, 2)
        End If

        If CDbl(NzZero(Me.ValorLiquido.Text)) > 0 And CDbl(NzZero(Me.ValorDocumento.Text)) < 0 Then
            MessageBox.Show("O usu�rio n�o pode usar valores positivo em baixas negativas", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ValorLiquido.Text = Me.ValorLiquido.Text * -1
            Me.ValorLiquido.Focus()
        End If
    End Sub

    Private Sub Multa_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Multa.Enter
        If Me.Multa.Text = "" Then Me.Multa.Text = FormatCurrency(0, 2)
    End Sub

    Private Sub Banco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Banco.KeyDown
        If e.KeyCode = Keys.F5 Then
            'ChamaTelaProcura("Codigo", "Descri��o", "", "Banco", "Codigo", "ContaCorrente", "", True)
            My.Forms.BancoBuscaConta.ShowDialog()
            Me.Banco.Text = RetornoProcura
        End If
    End Sub

    Private Sub Banco_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Banco.Leave
        AchaContaBanco()
    End Sub

    Private Sub AchaContaBanco()

        If Me.Banco.Text = "" Or Me.Banco.Text = 0 Then Exit Sub

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Cmd As New OleDb.OleDbCommand()
        Dim DR As OleDb.OleDbDataReader

        Cnn.Open()

        With Cmd
            .Connection = Cnn
            .CommandTimeout = 0
            .CommandText = "SELECT * FROM Banco WHERE Codigo = '" & Me.Banco.Text & "' And Banco.Inativo = False"
            .CommandType = CommandType.Text
        End With

        Try

            DR = Cmd.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                Me.BancoDesc.Text = DR.Item("ContaCorrente") & "-" & DR.Item("NomeBanco")
            Else
                MessageBox.Show("Conta n�o encontrada.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Banco.Clear()
                Me.Banco.Focus()
                Exit Sub
            End If

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
        End Try
        Cnn.Close()
    End Sub

    Private Sub CarregaComboBox()

        Dim Cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "SELECT * FROM (LocalPagamento) WHERE ((LocalPagamento.Empresa)= " & CodEmpresa & ") AND ((LocalPagamento.LocalPgto)='BANCO' Or (LocalPagamento.LocalPgto)='CARTEIRA');"
        Dim daLocalPgto As OleDb.OleDbDataAdapter

        daLocalPgto = New OleDb.OleDbDataAdapter(Sql, Cnn)
        daLocalPgto.Fill(DS, "LocalPgto")

        Me.LocalPgto.DataSource = DS.Tables("LocalPgto")
        Me.LocalPgto.ValueMember = "LocalPgto"
        Me.LocalPgto.DisplayMember = "LocalPgto"
        Cnn.Close()

    End Sub

    Private Sub Pagamento_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pagamento.Enter
        If Me.Pagamento.Text = "" Then Me.Pagamento.Text = DataDia
    End Sub

    Private Sub ContaJuros_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ContaJuros.KeyDown
        If e.KeyCode = Keys.F5 Then
            IdContaLanc = "JUROS" 'JUROS/MULTA/DESCONTO/VALORDOC
            My.Forms.BalanceteContasProcura.TipoConta = "D"
            My.Forms.BalanceteContasProcura.ShowDialog()
        End If
    End Sub

    Private Sub ContaMulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ContaMulta.KeyDown
        If e.KeyCode = Keys.F5 Then
            IdContaLanc = "MULTA" 'JUROS/MULTA/DESCONTO/VALORDOC
            My.Forms.BalanceteContasProcura.TipoConta = "D"
            My.Forms.BalanceteContasProcura.ShowDialog()
        End If
    End Sub

    Private Sub ContaDesconto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ContaDesconto.KeyDown
        If e.KeyCode = Keys.F5 Then
            IdContaLanc = "DESCONTO" 'JUROS/MULTA/DESCONTO/VALORDOC
            My.Forms.BalanceteContasProcura.TipoConta = "C"
            My.Forms.BalanceteContasProcura.ShowDialog()
        End If
    End Sub

    Private Sub ContaValorBaixado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F5 Then
            IdContaLanc = "VALORDOC" 'JUROS/MULTA/DESCONTO/VALORDOC
            My.Forms.BalanceteContasProcura.TipoConta = "D"
            My.Forms.BalanceteContasProcura.ShowDialog()
        End If
    End Sub


    Private Sub ContaJuros_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContaJuros.Leave
        If String.CompareOrdinal(Me.ContaJuros.Text, Me.ContaJuros.TextoAntigo) Then
            AchaContaBalancete(Me.ContaJuros.Text, Me.ContaJurosDesc)
        End If
    End Sub

    Private Sub ContaMulta_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContaMulta.Leave
        If String.CompareOrdinal(Me.ContaMulta.Text, Me.ContaMulta.TextoAntigo) Then
            AchaContaBalancete(Me.ContaMulta.Text, Me.ContaMultaDesc)
        End If
    End Sub

    Private Sub ContaDesconto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContaDesconto.Leave
        If String.CompareOrdinal(Me.ContaDesconto.Text, Me.ContaDesconto.TextoAntigo) Then
            AchaContaBalancete(Me.ContaDesconto.Text, Me.ContaDescontoDesc)
        End If
    End Sub


    Public Sub AchaContaBalancete(ByVal ContaBalancete As String, ByVal CampoParaRetornar As Control)

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()
        Dim Sql As String = "Select * from ContasG3 where ContaGrupo3 = '" & ContaBalancete & "' And Empresa = " & CodEmpresa
        Dim CMD As New OleDb.OleDbCommand(Sql, Cnn)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            CampoParaRetornar.Text = DR.Item("DescContaGrupo3") & ""
        End If
        Cnn.Close()
    End Sub

    Private Sub ContaJuros_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContaJuros.Enter
        If Me.Juros.Text <> 0 And Me.ContaJuros.Text = "" Then
            Me.ContaJuros.Text = cbJuros
        End If
    End Sub

    Private Sub ContaMulta_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContaMulta.Enter
        If Me.Multa.Text <> 0 And Me.ContaMulta.Text = "" Then
            Me.ContaMulta.Text = cbMulta
        End If
    End Sub

    Private Sub ContaDesconto_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContaDesconto.Enter
        If Me.Desconto.Text <> 0 And Me.ContaDesconto.Text = "" Then
            Me.ContaDesconto.Text = cbDesco
        End If
    End Sub

    Private Sub Juros_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Juros.Validated
        If Me.Juros.Text = "" Then Me.Juros.Text = FormatNumber(0, 2)
        If Me.Juros.Text = 0 Then
            Me.ContaJuros.Clear()
            Me.ContaJurosDesc.Clear()
        End If
    End Sub

    Private Sub Multa_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Multa.Validated
        If Me.Multa.Text = "" Then Me.Multa.Text = FormatNumber(0, 2)
        If Me.Multa.Text = 0 Then
            Me.ContaMulta.Clear()
            Me.ContaMultaDesc.Clear()
        End If
    End Sub

    Private Sub Desconto_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Desconto.Validated
        If Me.Desconto.Text = "" Then Me.Desconto.Text = FormatNumber(0, 2)
        If Me.Desconto.Text = 0 Then
            Me.ContaDesconto.Clear()
            Me.ContaDescontoDesc.Clear()
        End If
    End Sub

    Private Sub ValorLiquido_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValorLiquido.Validated
        If Me.ValorLiquido.Text = "" Then Me.ValorLiquido.Text = FormatNumber(0, 2)

        Me.ValorDocBaixar.Text = FormatCurrency((CDbl(Me.ValorLiquido.Text) - CDbl(Me.Juros.Text) - CDbl(Me.Multa.Text) + CDbl(Me.Desconto.Text)), 2)


        If Me.Conta1.Text <> "" Then
            Me.Vlr1.Text = FormatNumber((CDbl(NzZero(Me.ValorDocBaixar.Text)) * CDbl(NzZero(Me.Percent1.Text))) / 100, 2)
        End If
        If Me.Conta2.Text <> "" Then
            Me.Vlr2.Text = FormatNumber((CDbl(NzZero(Me.ValorDocBaixar.Text)) * CDbl(NzZero(Me.Percent2.Text))) / 100, 2)
        End If
        If Me.Conta3.Text <> "" Then
            Me.Vlr3.Text = FormatNumber((CDbl(NzZero(Me.ValorDocBaixar.Text)) * CDbl(NzZero(Me.Percent3.Text))) / 100, 2)
        End If
        If Me.Conta4.Text <> "" Then
            Me.Vlr4.Text = FormatNumber((CDbl(NzZero(Me.ValorDocBaixar.Text)) * CDbl(NzZero(Me.Percent4.Text))) / 100, 2)
        End If
        If Me.Conta5.Text <> "" Then
            Me.Vlr5.Text = FormatNumber((CDbl(NzZero(Me.ValorDocBaixar.Text)) * CDbl(NzZero(Me.Percent5.Text))) / 100, 2)
        End If
        If Me.Conta6.Text <> "" Then
            Me.Vlr6.Text = FormatNumber((CDbl(NzZero(Me.ValorDocBaixar.Text)) * CDbl(NzZero(Me.Percent6.Text))) / 100, 2)
        End If
        SomaCC()
    End Sub

    Private Sub btFindJuros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFindJuros.Click
        IdContaLanc = "JUROS" 'JUROS/MULTA/DESCONTO/VALORDOC
        My.Forms.BalanceteContasProcura.TipoConta = "D"
        My.Forms.BalanceteContasProcura.ShowDialog()
        AchaContaBalancete(Me.ContaJuros.Text, Me.ContaJurosDesc)
        Me.ContaJuros.Focus()
    End Sub

    Private Sub btFindMulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFindMulta.Click
        IdContaLanc = "MULTA" 'JUROS/MULTA/DESCONTO/VALORDOC
        My.Forms.BalanceteContasProcura.TipoConta = "D"
        My.Forms.BalanceteContasProcura.ShowDialog()
        AchaContaBalancete(Me.ContaMulta.Text, Me.ContaMultaDesc)
        Me.ContaMulta.Focus()
    End Sub

    Private Sub btFindDesconto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFindDesconto.Click
        IdContaLanc = "DESCONTO" 'JUROS/MULTA/DESCONTO/VALORDOC
        My.Forms.BalanceteContasProcura.TipoConta = "C"
        My.Forms.BalanceteContasProcura.ShowDialog()
        AchaContaBalancete(Me.ContaDesconto.Text, Me.ContaDescontoDesc)
        Me.ContaDesconto.Focus()
    End Sub


    Private Sub PagarBaixa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LocalizaDadosEmpresa()
        Me.DisplayCaixa.Text = "Caixa Ativo: " & CaixaAtivo & "-" & CaixaNomeVar
    End Sub

    Private Sub Referencia_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Referencia.Enter
        If Me.Referencia.Text = "" Then
            Me.Referencia.Text = "BAIXA DOC: " & Me.Documento.Text
            Me.Referencia.SelectionStart = Len(Me.Referencia.Text)
        End If
    End Sub

    Private Sub DataPreDatado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataPreDatado.Validated
        If String.IsNullOrEmpty(Me.DataPreDatado.Text) = False Then
            Me.PagoComPreDatado.Checked = True
        Else
            Me.PagoComPreDatado.Checked = False
        End If
    End Sub

    Private Sub PagarBaixa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            My.Forms.CaixaAtivarDesativar.ShowDialog()
            Me.DisplayCaixa.Text = "Caixa Ativo: " & CaixaAtivo
        End If
    End Sub

    Private Sub btFindValorBaixado_Click(sender As Object, e As EventArgs) Handles btFindValorBaixado.Click
        IdContaLanc = "VALORDOC" 'JUROS/MULTA/DESCONTO/VALORDOC
        My.Forms.BalanceteContasProcura.TipoConta = "D"
        My.Forms.BalanceteContasProcura.ShowDialog()
        AchaContaBalancete(Me.ContaValorBaixado.Text, Me.ContaValorBaixadoDesc)
        Me.ContaDesconto.Focus()
    End Sub

    Private Sub ContaValorBaixado_KeyDown_1(sender As Object, e As KeyEventArgs) Handles ContaValorBaixado.KeyDown
        If e.KeyCode = Keys.F5 Then
            IdContaLanc = "VALORDOC" 'JUROS/MULTA/DESCONTO/VALORDOC
            My.Forms.BalanceteContasProcura.TipoConta = "D"
            My.Forms.BalanceteContasProcura.ShowDialog()
        End If
    End Sub

    Public Sub AchaContaCC(ByVal Conta As String, ByVal CampoParaRetornar As Control)

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()
        Dim Sql As String = "Select * from CC3 where ContaGrupo3 = '" & Conta & "' And Empresa = " & CodEmpresa
        Dim CMD As New OleDb.OleDbCommand(Sql, Cnn)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            CampoParaRetornar.Text = DR.Item("DescContaGrupo3") & ""
        Else
            CampoParaRetornar.Text = ""
            CampoParaRetornar.Focus()
            Exit Sub
        End If
        Cnn.Close()
    End Sub
    Private Sub btCC1_Click(sender As Object, e As EventArgs) Handles btCC1.Click, btCC2.Click, btCC3.Click, btCC4.Click, btCC5.Click, btCC6.Click
        Select Case CType(sender, Label).Name
            Case "btCC1"
                IdContaLanc = "ContaCC1"
                My.Forms.CentroCustoNewLocalizar.ShowDialog()
                AchaContaCC(Me.Conta1.Text, Me.Conta1Desc)
                Me.Conta1.Focus()
            Case "btCC2"
                IdContaLanc = "ContaCC2"
                My.Forms.CentroCustoNewLocalizar.ShowDialog()
                AchaContaCC(Me.Conta2.Text, Me.Conta2Desc)
                Me.Conta2.Focus()
            Case "btCC3"
                IdContaLanc = "ContaCC3"
                My.Forms.CentroCustoNewLocalizar.ShowDialog()
                AchaContaCC(Me.Conta3.Text, Me.Conta3Desc)
                Me.Conta3.Focus()
            Case "btCC4"
                IdContaLanc = "ContaCC1"
                My.Forms.CentroCustoNewLocalizar.ShowDialog()
                AchaContaCC(Me.Conta4.Text, Me.Conta4Desc)
                Me.Conta4.Focus()
            Case "btCC5"
                IdContaLanc = "ContaCC1"
                My.Forms.CentroCustoNewLocalizar.ShowDialog()
                AchaContaCC(Me.Conta5.Text, Me.Conta5Desc)
                Me.Conta5.Focus()
            Case "btCC6"
                IdContaLanc = "ContaCC1"
                My.Forms.CentroCustoNewLocalizar.ShowDialog()
                AchaContaCC(Me.Conta6.Text, Me.Conta6Desc)
                Me.Conta6.Focus()
        End Select

    End Sub

    Private Sub Conta1_KeyDown(sender As Object, e As KeyEventArgs) Handles Conta1.KeyDown, Conta2.KeyDown, Conta3.KeyDown, Conta4.KeyDown, Conta5.KeyDown, Conta6.KeyDown
        If e.KeyCode = Keys.F5 Then
            Select Case CType(sender, TextBox).Name
                Case "Conta1"
                    IdContaLanc = "ContaCC1"
                    My.Forms.CentroCustoNewLocalizar.ShowDialog()
                    AchaContaCC(Me.Conta1.Text, Me.Conta1Desc)
                    Me.Conta1.Focus()
                Case "Conta2"
                    IdContaLanc = "ContaCC2"
                    My.Forms.CentroCustoNewLocalizar.ShowDialog()
                    AchaContaCC(Me.Conta2.Text, Me.Conta2Desc)
                    Me.Conta2.Focus()
                Case "Conta3"
                    IdContaLanc = "ContaCC3"
                    My.Forms.CentroCustoNewLocalizar.ShowDialog()
                    AchaContaCC(Me.Conta3.Text, Me.Conta3Desc)
                    Me.Conta3.Focus()
                Case "Conta4"
                    IdContaLanc = "ContaCC1"
                    My.Forms.CentroCustoNewLocalizar.ShowDialog()
                    AchaContaCC(Me.Conta4.Text, Me.Conta4Desc)
                    Me.Conta4.Focus()
                Case "Conta5"
                    IdContaLanc = "ContaCC1"
                    My.Forms.CentroCustoNewLocalizar.ShowDialog()
                    AchaContaCC(Me.Conta5.Text, Me.Conta5Desc)
                    Me.Conta5.Focus()
                Case "Conta6"
                    IdContaLanc = "ContaCC1"
                    My.Forms.CentroCustoNewLocalizar.ShowDialog()
                    AchaContaCC(Me.Conta6.Text, Me.Conta6Desc)
                    Me.Conta6.Focus()
            End Select
        End If
    End Sub

    Private Sub Conta1_Validated(sender As Object, e As EventArgs) Handles Conta1.Validated, Conta2.Validated, Conta3.Validated, Conta4.Validated, Conta5.Validated, Conta6.Validated
        Select Case CType(sender, TextBox).Name
            Case "Conta1"
                AchaContaCC(Me.Conta1.Text, Me.Conta1Desc)
            Case "Conta2"
                AchaContaCC(Me.Conta2.Text, Me.Conta2Desc)
            Case "Conta3"
                AchaContaCC(Me.Conta3.Text, Me.Conta3Desc)
            Case "Conta4"
                AchaContaCC(Me.Conta4.Text, Me.Conta4Desc)
            Case "Conta5"
                AchaContaCC(Me.Conta5.Text, Me.Conta5Desc)
            Case "Conta6"
                AchaContaCC(Me.Conta6.Text, Me.Conta6Desc)
        End Select
    End Sub


    Private Sub SomaCC()
        Me.TotalCC.Text = FormatNumber(CDbl(NzZero(Me.Vlr1.Text)) + CDbl(NzZero(Me.Vlr2.Text)) + CDbl(NzZero(Me.Vlr3.Text)) + CDbl(NzZero(Me.Vlr4.Text)) + CDbl(NzZero(Me.Vlr5.Text)) + CDbl(NzZero(Me.Vlr6.Text)), 2)
    End Sub
    
    Private Sub Vlr1_Validated(sender As Object, e As EventArgs) Handles Vlr1.Validated, Vlr2.Validated, Vlr3.Validated, Vlr4.Validated, Vlr5.Validated, Vlr6.Validated
        SomaCC()

        If CDbl(NzZero(Me.ValorLiquido.Text)) = 0 Then
            Me.Pagamento.Focus()
            Exit Sub
        End If
        Select Case CType(sender, TextBox).Name
            Case "Vlr1"

                If String.CompareOrdinal(Me.Vlr1.Text, Me.Vlr1.TextoAntigo) Then
                    If CDbl(NzZero(Me.Vlr1.Text)) > 0 Then
                        Dim Resta As Double = CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text))
                        If Resta <> 0 Then
                            If CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) < 0 Then
                                MessageBox.Show("A Soma dos Valores de Lan�amento � maio que a do Pedido.", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Vlr1.Focus()
                                Exit Sub
                            End If

                            Me.Vlr2.Text = FormatNumber(0, 2) 'CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text))
                            Me.Vlr3.Text = FormatNumber(0, 2)
                            Me.Vlr4.Text = FormatNumber(0, 2)
                            Me.Vlr5.Text = FormatNumber(0, 2)
                            Me.Vlr6.Text = FormatNumber(0, 2)
                        End If
                    End If
                End If

            Case "Vlr2"
                If String.CompareOrdinal(Me.Vlr2.Text, Me.Vlr2.TextoAntigo) Then
                    If CDbl(NzZero(Me.Vlr2.Text)) > 0 Then
                        Dim Resta As Double = CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text))
                        If Resta <> 0 Then
                            If (CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text))) < 0 Then
                                MessageBox.Show("A Soma dos Valores de Lan�amento � maio que a do Pedido.", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Vlr2.Focus()
                                Exit Sub
                            End If

                            Me.Vlr3.Text = FormatNumber(0, 2) 'CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text))
                            Me.Vlr4.Text = FormatNumber(0, 2)
                            Me.Vlr5.Text = FormatNumber(0, 2)
                            Me.Vlr6.Text = FormatNumber(0, 2)
                        End If
                    End If
                End If
            Case "Vlr3"
                If String.CompareOrdinal(Me.Vlr3.Text, Me.Vlr3.TextoAntigo) Then
                    If CDbl(NzZero(Me.Vlr3.Text)) > 0 Then
                        Dim Resta As Double = CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text))
                        If Resta <> 0 Then
                            If (CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text))) < 0 Then
                                MessageBox.Show("A Soma dos Valores de Lan�amento � maio que a do Pedido.", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Vlr3.Focus()
                                Exit Sub
                            End If

                            Me.Vlr4.Text = FormatNumber(0, 2) 'CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text))
                            Me.Vlr5.Text = FormatNumber(0, 2)
                            Me.Vlr6.Text = FormatNumber(0, 2)
                        End If
                    End If
                End If
            Case "Vlr4"
                If String.CompareOrdinal(Me.Vlr4.Text, Me.Vlr4.TextoAntigo) Then
                    If CDbl(NzZero(Me.Vlr4.Text)) > 0 Then
                        Dim Resta As Double = CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text)) - CDbl(NzZero(Me.Vlr4.Text))
                        If Resta <> 0 Then
                            If (CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text)) - CDbl(NzZero(Me.Vlr4.Text))) < 0 Then
                                MessageBox.Show("A Soma dos Valores de Lan�amento � maio que a do Pedido.", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Vlr4.Focus()
                                Exit Sub
                            End If

                            Me.Vlr5.Text = FormatNumber(0, 2) 'CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text)) - CDbl(NzZero(Me.Vlr4.Text))
                            Me.Vlr5.Text = FormatNumber(0, 2)
                            Me.Vlr5.Focus()
                        End If
                    End If
                End If
            Case "Vlr5"
                If String.CompareOrdinal(Me.Vlr5.Text, Me.Vlr5.TextoAntigo) Then
                    If CDbl(NzZero(Me.Vlr5.Text)) > 0 Then
                        Dim Resta As Double = CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text)) - CDbl(NzZero(Me.Vlr4.Text)) - CDbl(NzZero(Me.Vlr5.Text))
                        If Resta <> 0 Then
                            If (CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text)) - CDbl(NzZero(Me.Vlr4.Text)) - CDbl(NzZero(Me.Vlr5.Text))) < 0 Then
                                MessageBox.Show("A Soma dos Valores de Lan�amento � maio que a do Pedido.", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Vlr5.Focus()
                                Exit Sub
                            End If

                            Me.Vlr6.Text = FormatNumber(0, 2) 'CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text)) - CDbl(NzZero(Me.Vlr4.Text)) - CDbl(NzZero(Me.Vlr5.Text))
                            Me.Vlr5.Focus()
                        End If
                    End If
                End If
            Case "Vlr6"
                If (CDbl(NzZero(Me.ValorLiquido.Text)) - CDbl(NzZero(Me.Vlr1.Text)) - CDbl(NzZero(Me.Vlr2.Text)) - CDbl(NzZero(Me.Vlr3.Text)) - CDbl(NzZero(Me.Vlr4.Text)) - CDbl(NzZero(Me.Vlr5.Text)) - CDbl(NzZero(Me.Vlr6.Text))) < 0 Then
                    MessageBox.Show("A Soma dos Valores de Lan�amento � maio que a do Pedido.", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Vlr6.Focus()
                    Exit Sub
                End If

        End Select


        If CDbl(NzZero(Me.ValorLiquido.Text)) < (CDbl(NzZero(Me.Vlr1.Text)) + CDbl(NzZero(Me.Vlr2.Text)) + CDbl(NzZero(Me.Vlr3.Text)) + CDbl(NzZero(Me.Vlr4.Text)) + CDbl(NzZero(Me.Vlr5.Text)) + CDbl(NzZero(Me.Vlr6.Text))) Then
            MessageBox.Show("O Valor dos Lan�amentos esta maior que o valor do Documento, verifique...", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CType(sender, TextBox).Focus()
            Exit Sub
        End If
    End Sub

    Private Sub Juros_Leave(sender As Object, e As EventArgs) Handles Juros.Leave
        If CDbl(NzZero(Me.Juros.Text)) > 0 Then
            If ContaCCD = "" Then
                MessageBox.Show("N�o foi definido conta para Juros, o juros n�o pode ser aplicado.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Juros.Text = FormatNumber(0, 2)
            End If
        End If
    End Sub

    Private Sub Multa_Leave(sender As Object, e As EventArgs) Handles Multa.Leave
        If CDbl(NzZero(Me.Multa.Text)) > 0 Then
            If ContaCCM = "" Then
                MessageBox.Show("N�o foi definido conta para Multa, a multa n�o pode ser aplicada.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Multa.Text = FormatNumber(0, 2)
            End If
        End If
    End Sub

    Private Sub Desconto_Leave(sender As Object, e As EventArgs) Handles Desconto.Leave
        If CDbl(NzZero(Me.Desconto.Text)) > 0 Then
            If ContaCCD = "" Then
                MessageBox.Show("N�o foi definido conta para Desconto, o Desconto n�o pode ser aplicado.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Desconto.Text = FormatNumber(0, 2)
            End If
        End If
    End Sub

    Private Sub bt1_Click(sender As Object, e As EventArgs) Handles bt1.Click, bt2.Click, bt3.Click, bt4.Click
        TRVDados(UserAtivo, "BalanceteCadastro")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.BalanceteCadastro.ShowDialog()
        End If
    End Sub

    
    Private Sub btCC_Click(sender As Object, e As EventArgs) Handles btCC.Click
        TRVDados(UserAtivo, "CentroCustoNew")
        If Ina = True Then
            MsgBox("O usu�rio n�o esta autorizado a usar esta op��o do sistema.", 64, "Valida��o de Dados")
            Exit Sub
        Else
            My.Forms.CentroCustoNew.ShowDialog()
        End If
    End Sub

    Private Sub ContaValorBaixado_Validated(sender As Object, e As EventArgs) Handles ContaValorBaixado.Validated
        AchaContaBalancete(Me.ContaValorBaixado.Text, Me.ContaValorBaixadoDesc)
    End Sub
End Class