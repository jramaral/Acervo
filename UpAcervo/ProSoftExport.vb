Public Class ProSoftExport

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btEscolherPasta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEscolherPasta.Click

        Dim fbd1 As New FolderBrowserDialog
        Dim myLocal As String = String.Empty

        fbd1.Description = "Selecione uma pasta para Salvar"
        fbd1.RootFolder = Environment.SpecialFolder.MyComputer
        fbd1.ShowNewFolderButton = True

        If fbd1.ShowDialog = Windows.Forms.DialogResult.OK Then
            myLocal = fbd1.SelectedPath
        End If
        Me.Local.Text = myLocal
        Me.Local.Focus()
    End Sub

    Private Sub EmpProSoft_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpProSoft.Leave
        Dim EmpresaProsoft As String = Me.EmpProSoft.Text
        Me.EmpProSoft.Text = EmpresaProsoft.PadLeft(3, "0")
    End Sub

    Private Sub btGerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGerar.Click
        'terceiros
        If Me.A1.Checked = True Then
            If Me.Local.Text = "" Then
                MsgBox("Favor informar o drive e local a ser gravado o arquivo.", 64, "Exporta��o")
                Me.Local.Focus()

                Exit Sub
            ElseIf Me.EmpUP.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no FOCUS.", 64, "Exporta��o")
                Me.EmpUP.Focus()
                Exit Sub
            ElseIf Me.EmpProSoft.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no ProSoft.", 64, "Exporta��o")
                Me.EmpProSoft.Focus()
                Exit Sub
            End If
            ExTerceiros()
        End If

        'produtos
        If Me.A2.Checked = True Then
            If Me.Local.Text = "" Then
                MsgBox("Favor informar o drive e local a ser gravado o arquivo.", 64, "Exporta��o")
                Me.Local.Focus()
                Exit Sub
            ElseIf Me.EmpUP.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no FOCUS.", 64, "Exporta��o")
                Me.EmpUP.Focus()
                Exit Sub
            ElseIf Me.EmpProSoft.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no ProSoft.", 64, "Exporta��o")
                Me.EmpProSoft.Focus()
                Exit Sub
            End If
            ExProdutos()
        End If

        'entrada
        If Me.A3.Checked = True Then
            If Me.Local.Text = "" Then
                MsgBox("Favor informar o drive e local a ser gravado o arquivo.", 64, "Exporta��o")
                Me.Local.Focus()
                Exit Sub
            ElseIf Me.EmpUP.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no FOCUS.", 64, "Exporta��o")
                Me.EmpUP.Focus()
                Exit Sub
            ElseIf Me.EmpProSoft.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no ProSoft.", 64, "Exporta��o")
                Me.EmpProSoft.Focus()
                Exit Sub
            ElseIf Me.DataInicial.Text = "" Then
                MsgBox("Favor informar a data inicial.", 64, "Exporta��o")
                Me.DataInicial.Focus()
                Exit Sub
            ElseIf Me.DataFinal.Text = "" Then
                MsgBox("Favor informar a Data Final.", 64, "Exporta��o")
                Me.DataFinal.Focus()
                Exit Sub
            End If
            ExportaEntradas()
        End If

        'iventario
        If Me.A4.Checked = True Then
            If Me.Local.Text = "" Then
                MsgBox("Favor informar o drive e local a ser gravado o arquivo.", 64, "Exporta��o")
                Me.Local.Focus()
                Exit Sub
            ElseIf Me.EmpUP.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no FOCUS.", 64, "Exporta��o")
                Me.EmpUP.Focus()
                Exit Sub
            ElseIf Me.EmpProSoft.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no ProSoft.", 64, "Exporta��o")
                Me.EmpProSoft.Focus()
                Exit Sub
            ElseIf Me.DataInicial.Text = "" Then
                MsgBox("Favor informar a data inicial.", 64, "Exporta��o")
                Me.DataInicial.Focus()
                Exit Sub
            ElseIf Me.DataFinal.Text = "" Then
                MsgBox("Favor informar a Data Final.", 64, "Exporta��o")
                Me.DataFinal.Focus()
                Exit Sub
            ElseIf Me.AnoInventario.Text = "" Then
                MsgBox("Favor informar o Ano.", 64, "Exporta��o")
                Me.AnoInventario.Focus()
                Exit Sub
            End If
            ExportaInventario()
        End If

        'Entrada  II
        If Me.A5.Checked = True Then
            If Me.Local.Text = "" Then
                MsgBox("Favor informar o drive e local a ser gravado o arquivo.", 64, "Exporta��o")
                Me.Local.Focus()
                Exit Sub
            ElseIf Me.EmpUP.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no FOCUS.", 64, "Exporta��o")
                Me.EmpUP.Focus()
                Exit Sub
            ElseIf Me.EmpProSoft.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no ProSoft.", 64, "Exporta��o")
                Me.EmpProSoft.Focus()
                Exit Sub
            ElseIf Me.DataInicial.Text = "" Then
                MsgBox("Favor informar a data inicial.", 64, "Exporta��o")
                Me.DataInicial.Focus()
                Exit Sub
            ElseIf Me.DataFinal.Text = "" Then
                MsgBox("Favor informar a Data Final.", 64, "Exporta��o")
                Me.DataFinal.Focus()
                Exit Sub
            End If
            ExportaEntradasII()
        End If

    End Sub

    Public Sub ExportaEntradasII()
        Dim ds As New DataSet

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT Compra.*, Fornecedor.CgcCpf, Fornecedor.Incri��oEstadual, Fornecedor.Estado, ItensCompra.*, ItensCompra.BaseCalcIcms as ItBaseCalcIcms,Produtos.*, 0 AS ItemDesdobramento FROM ((Compra INNER JOIN ItensCompra ON Compra.CompraInterno = ItensCompra.CompraInterno) INNER JOIN Fornecedor ON Compra.CodigoFornecedor = Fornecedor.C�digoFornecedor) INNER JOIN Produtos ON ItensCompra.CodigoProduto = Produtos.CodigoProduto WHERE (((Compra.DataLan�amento) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#) AND ((Compra.Confirmado)=True) AND ((Compra.Inativo)=False) AND ((Compra.Empresa)=" & Me.EmpUP.Text & ") AND ((Compra.Tipo)='NF') AND ((Compra.TpEntrada)='ENTRADA' Or (Compra.TpEntrada)='ENT. CONSERTO' Or (Compra.TpEntrada)='ENT BRINDE')) ORDER BY Compra.NotaFiscal, ItensCompra.CFOPent;"

        Dim daExport As New OleDb.OleDbDataAdapter(Sql, Cnn)
        daExport.Fill(ds, "TB")

        Sql = "SELECT Compra.NotaFiscal, ItensCompra.CFOPent FROM Compra INNER JOIN ItensCompra ON Compra.CompraInterno = ItensCompra.CompraInterno WHERE (((Compra.DataLan�amento) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#) AND ((Compra.Confirmado)=True) AND ((Compra.Inativo)=False) AND ((Compra.Empresa)=" & CodEmpresa & ") AND ((Compra.Tipo)='NF') AND ((Compra.TpEntrada)='ENTRADA' Or (Compra.TpEntrada)='ENT. CONSERTO' Or (Compra.TpEntrada)='ENT BRINDE')) GROUP BY Compra.NotaFiscal, ItensCompra.CFOPent ORDER BY Compra.NotaFiscal, ItensCompra.CFOPent;"
        Dim daQtdCfop As New OleDb.OleDbDataAdapter(Sql, Cnn)
        daQtdCfop.Fill(ds, "QtdCFOP")

        Dim NF As String = String.Empty
        Dim NFtemp As String = String.Empty
        Dim CFOP As String = String.Empty
        Dim CFOPTemp As String = String.Empty
        Dim It As Integer = 0

        'adiciona o item do desmembramento
        Dim Dv As DataView 'Cria o dataview para filtragem de dados e verificar se tem mais de um cfop

        Dim L As Integer = 0
        For L = 0 To ds.Tables("TB").Rows.Count - 1
            NFtemp = ds.Tables("TB").Rows(L)("NotaFiscal")

            If NF = NFtemp Then
                CFOPTemp = ds.Tables("TB").Rows(L)("CFOPent")
                If CFOP = CFOPTemp Then
                    ds.Tables("TB").Rows(L).BeginEdit()
                    ds.Tables("TB").Rows(L)("ItemDesdobramento") = It
                    ds.Tables("TB").Rows(L).EndEdit()
                    NF = ds.Tables("TB").Rows(L)("NotaFiscal")
                    CFOP = ds.Tables("TB").Rows(L)("CFOPent")
                Else
                    It += 1
                    ds.Tables("TB").Rows(L).BeginEdit()
                    ds.Tables("TB").Rows(L)("ItemDesdobramento") = It
                    ds.Tables("TB").Rows(L).EndEdit()
                    NF = ds.Tables("TB").Rows(L)("NotaFiscal")
                    CFOP = ds.Tables("TB").Rows(L)("CFOPent")
                End If
            Else

                Dv = New DataView(ds.Tables("QtdCFOP"), "NotaFiscal = '" & NFtemp & "'", "NotaFiscal ASC", DataViewRowState.OriginalRows)

                If Dv.Count = 1 Then
                    It = 0
                ElseIf Dv.Count > 1 Then
                    It = 1
                End If

                CFOPTemp = ds.Tables("TB").Rows(L)("CFOPent") & ""

                ds.Tables("TB").Rows(L).BeginEdit()
                ds.Tables("TB").Rows(L)("ItemDesdobramento") = It
                ds.Tables("TB").Rows(L).EndEdit()
                NF = ds.Tables("TB").Rows(L)("NotaFiscal")
                CFOP = ds.Tables("TB").Rows(L)("CFOPent") & ""
            End If

        Next L
        'Fim

        'Criar Cabe�alho para os desdobramentos

        Sql = "SELECT Compra.CFOP, Compra.ChaveNFe, Compra.EspecieDocumento, Fornecedor.C�digoFornecedor, Fornecedor.CgcCpf, Fornecedor.Incri��oEstadual, Fornecedor.Estado, '' AS ItemDesdobramento, Compra.NotaFiscal, Compra.Modelo, Compra.Serie, Compra.Subserie, Compra.DataCompra, Compra.DataEntrada, Compra.DataLan�amento, Compra.ValorDesconto, Compra.TotalProdutos, Compra.ValorIssqnRetido, Compra.ValorFrete,Compra.ValorOutros, Compra.ValorCompra, Compra.Icms, Compra.BaseCalcIcms, Compra.ValorIcms, Compra.IsentoIcms, Compra.ValorOutrosIcms, Compra.BaseCalcIpi, Compra.BaseCalcIcmsST, Compra.ValorIcmsST, Compra.Ipi, Compra.ValorIpi, Compra.ValorOutrosIpi, Compra.IsentoIpi, Compra.Confirmado, Compra.Inativo, Compra.Empresa, Compra.Tipo, Compra.FormaPagamento, Compra.Obs, Compra.ValorFrete, Compra.LancaItens, Compra.TpEntrada FROM Compra INNER JOIN Fornecedor ON Compra.CodigoFornecedor = Fornecedor.C�digoFornecedor WHERE (((Compra.TpEntrada)='Vazio'));"

        Dim daExportCab As New OleDb.OleDbDataAdapter(Sql, Cnn)
        daExportCab.Fill(ds, "TBCAB")

        For Each row As DataRow In ds.Tables("TB").Rows
            Dim DrNF() As DataRow
            DrNF = ds.Tables("TBCAB").Select("NotaFiscal = '" & row("NotaFiscal").ToString & "' and ItemDesdobramento = '" & row("ItemDesdobramento").ToString & "'")

            Dim VlrItemAgregados As Double
            If DrNF.Length = 0 Then

                VlrItemAgregados = CDbl(NzZero(row("ItensCompra.ValorIcmsST"))) + CDbl(NzZero(row("ValorFreteProduto"))) + CDbl(NzZero(row("vSeg"))) + CDbl(NzZero(row("vOutro"))) + CDbl(NzZero(row("ItensCompra.ValorIpi"))) ' teste- CDbl(NzZero(row("itensCompra.ValorDesconto")))

                Dim DRnovo As DataRow
                DRnovo = ds.Tables("TBCAB").NewRow()
                'DRnovo("CFOP") = row("ItensCompra.CFOP") corre��o referente cfop de entrada
                DRnovo("CFOP") = row("CFOPENT")
                DRnovo("C�digoFornecedor") = row("CodigoFornecedor")
                DRnovo("CgcCpf") = row("CgcCpf")
                DRnovo("Incri��oEstadual") = row("Incri��oEstadual")
                DRnovo("Estado") = row("Estado")
                DRnovo("ItemDesdobramento") = row("ItemDesdobramento")
                DRnovo("NotaFiscal") = row("NotaFiscal")
                DRnovo("ChaveNFe") = row("ChaveNFe")
                DRnovo("EspecieDocumento") = row("EspecieDocumento")
                DRnovo("Modelo") = row("Modelo")
                DRnovo("Serie") = row("Compra.Serie")
                DRnovo("SubSerie") = row("Compra.SubSerie")
                DRnovo("DataCompra") = row("DataCompra")
                DRnovo("DataEntrada") = row("DataEntrada")
                DRnovo("DataLan�amento") = row("DataLan�amento")
                DRnovo("ValorDesconto") = row("ItensCompra.ValorDesconto")
                DRnovo("TotalProdutos") = row("TotalProduto")
                DRnovo("ValorCompra") = row("TotalProduto") + VlrItemAgregados
                DRnovo("Icms") = row("IcmsProduto")
                If row("IcmsProduto") > 0 Then DRnovo("BaseCalcIcms") = row("ItBaseCalcIcms") '+ VlrItemAgregados
                DRnovo("ValorIcms") = row("ValorIcmsProduto")
                DRnovo("IsentoIcms") = row("ItensCompra.IsentoIcms")
                DRnovo("ValorOutrosIcms") = row("ItensCompra.ValorOutrosIcms")

                If row("ItensCompra.Ipi") > 0 Then DRnovo("BaseCalcIpi") = row("ItensCompra.BaseCalcIpi") Else DRnovo("BaseCalcIpi") = 0
                DRnovo("ValorIpi") = row("ItensCompra.ValorIpi")
                DRnovo("ValorOutrosIpi") = row("ItensCompra.ValorOutrosIpi")
                DRnovo("IsentoIpi") = row("ItensCompra.IsentoIpi")
                DRnovo("ValorFrete") = row("ValorFrete") 'row("ValorFreteProduto")
                DRnovo("BaseCalcIcmsST") = row("BaseCalcST")
                DRnovo("ValorIcmsST") = row("ItensCompra.ValorIcmsST")
                DRnovo("ValorOutros") = row("ValorOutros")
                ' DRnovo("ValorFrete") = row("ValorFrete")

                DRnovo("FormaPagamento") = row("FormaPagamento")

                ds.Tables("TBCAB").Rows.Add(DRnovo)

            Else

                DrNF(0).BeginEdit()

                VlrItemAgregados = CDbl(NzZero(row("ItensCompra.ValorIcmsST"))) + CDbl(NzZero(row("ValorFreteProduto"))) + CDbl(NzZero(row("vSeg"))) + CDbl(NzZero(row("vOutro"))) + CDbl(NzZero(row("ItensCompra.ValorIpi")))

                DrNF(0)("ValorDesconto") += row("ItensCompra.ValorDesconto")
                DrNF(0)("TotalProdutos") += row("TotalProduto")
                DrNF(0)("ValorCompra") += row("TotalProduto") + VlrItemAgregados

                If row("IcmsProduto") > 0 Then DrNF(0)("BaseCalcIcms") = NzZero(DrNF(0)("BaseCalcIcms")) + NzZero(row("ItBaseCalcIcms")) '+ NzZero(VlrItemAgregados)
                DrNF(0)("ValorIcms") += row("ValorIcmsProduto")
                DrNF(0)("IsentoIcms") += row("ItensCompra.IsentoIcms")
                DrNF(0)("ValorOutrosIcms") += row("ItensCompra.ValorOutrosIcms")

                If row("ItensCompra.Ipi") > 0 Then DrNF(0)("BaseCalcIpi") += row("ItensCompra.BaseCalcIpi") Else DrNF(0)("BaseCalcIpi") += 0
                DrNF(0)("ValorIpi") += row("ItensCompra.ValorIpi")
                DrNF(0)("ValorOutrosIpi") += NzZero(row("ItensCompra.ValorOutrosIpi"))
                DrNF(0)("IsentoIpi") += row("ItensCompra.IsentoIpi")

                ' DrNF(0)("ValorFrete") += row("ValorFreteProduto")
                DrNF(0)("BaseCalcIcmsST") += row("BaseCalcST")
                DrNF(0)("ValorIcmsST") += row("ItensCompra.ValorIcmsST")

                DrNF(0).EndEdit()

            End If

        Next

        Dim Linha As String = ""
        'FileOpen(1, Me.Local.Text & "\ENTRADA." & Me.EmpProSoft.Text, OpenMode.Append)
        FileOpen(1, Me.Local.Text & "\ENTRADA." & Me.EmpProSoft.Text, OpenMode.Output)
        For Each row As DataRow In ds.Tables("TBCAB").Rows

            Try
                Linha = Linha & RChr(" ", 4, " ", "D", False)                                                   'cp 1  - pos1   - Filter
                Linha = Linha & RChr(row("CgcCpf"), 14, 0, "E", True)                                           'cp 2  - pos5   - CNPJ do emitente
                Linha = Linha & RChr(Format(CDate(row("DataLan�amento")), "dd/MM/yy"), 6, 0, "E", True)            'cp 3  - pos19  - Data da Lan�amento = data entrada
                Linha = Linha & RChr(Format(CDate(row("DataCompra")), "dd/MM/yy"), 6, 0, "E", True)             'cp 4  - pos25  - Data da emiss�o
                Linha = Linha & RChr(row("NotaFiscal"), 6, 0, "E", False)                                       'cp 5  - pos31  - N�mero do documento
                Linha = Linha & RChr(" ", 3, " ", "D", True)                                                    'cp 6  - pos37  - Esp�cie do documento
                Linha = Linha & RChr("   ", 3, " ", "D", False)                                                 'cp 7  - pos40  - S�rie e subs�rie / esta sendo enviado na posi��o 864 e 867
                Linha = Linha & RChr(row("ItemDesdobramento"), 1, " ", "D", False)                              'cp 8  - pos43  - Item de desdobramento
                Linha = Linha & SChr("00000", 5, 0, "E", True)                                                  'cp 9  - pos44  - C�digo cont�bil (P.Contas)
                Linha = Linha & SChr("000", 3, 0, "E", True)                                                    'cp 10 - pos49  - CFOP antigo de 3 d�gitos

                'Alterado para linh abaixo dia 08/11/2014 a pedido Eliane/Fernando - Linha = Linha & SChr(FormatNumber(Nz(row("Valorcompra"), 3), 2), 14, 0, "E", True)              'cp 11 - pos52  - Valor total mercadorias
                Linha = Linha & SChr(FormatNumber(Nz(row("TotalProdutos"), 3), 2), 14, 0, "E", True)              'cp 11 - pos52  - Valor total mercadorias

                Linha = Linha & SChr(FormatNumber(Nz(row("BaseCalcIcms"), 3), 2), 14, 0, "E", True)             'cp 12 - pos66  - Base de c�lculo do ICMS
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorIcms"), 3), 2), 14, 0, "E", True)                'cp 13 - pos80  - ICMS creditado
                Linha = Linha & SChr(FormatNumber(Nz(row("IsentoIcms"), 3), 2), 14, 0, "E", True)               'cp 14 - pos94  - Isentas / n�o tributadas
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorOutrosIcms"), 3), 2), 14, 0, "E", True)          'cp 15 - pos108 - Outras
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 16 - pos122 - IPI n�o creditado
                Linha = Linha & SChr(FormatNumber(Nz(row("Icms"), 3), 2), 5, 0, "E", True)                      'cp 17 - pos136 - Al�quota do ICMS
                Linha = Linha & SChr(FormatNumber(Nz(row("BaseCalcIpi"), 3), 2), 14, 0, "E", True)              'cp 18 - pos141 - Base de c�lculo do IPI
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorIpi"), 3), 2), 14, 0, "E", True)                 'cp 19 - pos155 - IPI Creditado
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 20 - pos169 - IPI Creditado 50%
                Linha = Linha & SChr(FormatNumber(Nz(row("IsentoIpi"), 3), 2), 14, 0, "E", True)                'cp 21 - pos183 - Isentas / N�o tributadas
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorOutrosIpi"), 3), 2), 14, 0, "E", True)           'cp 22 - pos197 - Outras
                'Dim VlrLiquido As Double = NzZero(row("Valorcompra")) - NzZero(row("ValorDesconto"))
                'Linha = Linha & SChr(FormatNumber(Nz(VlrLiquido, 3), 2), 14, 0, "E", True) 'cp 23
                Dim VlrLiquido As Double = NzZero(row("Valorcompra")) - NzZero(row("ValorDesconto"))

                'Alterado para linh abaixo dia 08/11/2014 a pedido Eliane/Fernando -Linha = Linha & SChr(FormatNumber(Nz(row("TotalProdutos"), 3), 2), 14, 0, "E", True)              'cp 23 - pos211 - Val.total nota (Contabil)
                Linha = Linha & SChr(FormatNumber(Nz(row("Valorcompra"), 3), 2), 14, 0, "E", True)              'cp 23 - pos211 - Val.total nota (Contabil)

                Linha = Linha & RChr(row("FormaPagamento"), 1, 0, "E", False)                                   'cp 24 - pos225 - Condi��es de pagamento
                Linha = Linha & SChr(row("FormaPagamento"), 2, 0, "E", True)                                    'cp 25 - pos226 - Classif.Contab.-Integra��o (DESATIVADO) - VERIFICAR SE ESTA CORRETO

                Linha = Linha & SChr("0", 3, 0, "E", True)                                                      'cp 26 - pos228 - Sit especial c�digo utilziar a posi��o 1101 x4
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True)                                 'cp 27 - pos231 - Sit especial Valor 1
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True)                                 'cp 28 - pos243 - Sit especial Valor 2
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True)                                 'cp 29 - pos255 - Sit especial Valor 3
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True)                                 'cp 30 - pos267 - Sit especial Valor 4
                Linha = Linha & RChr(" ", 100, " ", "D", False)                                                 'cp 31 - pos279 - Observa��o
                Linha = Linha & RChr(" ", 6, " ", "D", False)                                                   'cp 32 - pos379 - Desativado
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 33 - pos385 - Desativado
                Linha = Linha & RChr(" ", 6, " ", "D", False)                                                   'cp 34 - pos399 - Desativado
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 35 - pos405 - Desativado
                Linha = Linha & RChr(" ", 6, " ", "D", False)                                                   'cp 36 - pos419 - Desativado
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 37 - pos425 - Desativado
                Linha = Linha & RChr(" ", 6, " ", "D", False)                                                   'cp 38 - pos439 - Desativado
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 39 - pos445 - Desativado
                Linha = Linha & RChr(" ", 6, " ", "D", False)                                                   'cp 40 - pos459 - Desativado
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 41 - pos465 - Desativado
                Linha = Linha & RChr(" ", 6, " ", "D", False)                                                   'cp 42 - pos479 - Desativado
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 43 - pos485 - Desativado
                Linha = Linha & RChr(row("Incri��oEstadual"), 18, " ", "D", False)                              'cp 44 - pos499 - Inscri��o estadual fornecedor
                Linha = Linha & RChr(row("Estado"), 2, " ", "D", False)                                         'cp 45 - pos517 - uf insc fornecedor estado
                Linha = Linha & RChr(" ", 1, " ", "D", False)                                                   'cp 46 - pos519 - tipo frete 1=cif , 2 = fob
                Linha = Linha & RChr(" ", 5, 0, "E", False)                                                     'cp 47 - pos520 - Sigla Sit.Trib.Saida (1)
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 48 - pos525 - Valor Sit.Trib.Saida (1)
                Linha = Linha & RChr(" ", 1, " ", "D", False)                                                   'cp 49 - pos539 - D�gito adicional para CFOP x99 no Estado de S�o Paulo
                ' Campos espec�ficos para o Estado de Minas Gerais.
                Linha = Linha & RChr(" ", 5, 0, "E", False)                                                     'cp 50 - pos540 - Sigla Sit.Trib.Saida (2)
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 51 - pos545 - Valor Sit.Trib.Saida (2)
                Linha = Linha & RChr(" ", 5, 0, "E", False)                                                     'cp 52 - pos559 - Sigla Sit.Trib.Saida (3)
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 53 - pos564 - Valor Sit.Trib.Saida (3)
                Linha = Linha & RChr(" ", 5, 0, "E", False)                                                     'cp 54 - pos578 - Sigla Sit.Trib.Saida (4)
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 55 - pos583 - Valor Sit.Trib.Saida (4)
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 56 - pos597 - Valor Parcela Isenta Sa�da
                Linha = Linha & RChr(" ", 3, " ", "D", False)                                                   'cp 57 - pos611 - D�gito adicional para CFOP x99 outros Estados - 01 a 99 - Deixar branco para outras CFOPs.
                Linha = Linha & RChr(" ", 4, " ", "D", False)                                                   'cp 58 - pos614 - Ano da AIDF
                Linha = Linha & RChr(" ", 6, " ", "D", False)                                                   'cp 59 - pos618 - N�mero da AIDF
                Linha = Linha & RChr(row("Cfop"), 4, " ", "D", True)                                            'cp 60 - pos624 - CFOP Novo de 4 d�gitos
                Linha = Linha & RChr(" ", 10, " ", "D", False)                                                  'cp 61 - pos628 - C�digo Munic�pio-Forneced.
                ' - TRANSPORTADOR - (S� COMBUST�VEIS)
                Linha = Linha & RChr(" ", 14, " ", "D", False)                                                  'cp 62 - pos638
                Linha = Linha & RChr(" ", 18, " ", "D", False)                                                  'cp 63 - pos652
                Linha = Linha & RChr(" ", 2, " ", "D", False)                                                   'cp 64 - pos670
                Linha = Linha & RChr(" ", 14, " ", "D", False)                                                  'cp 65 - pos672
                Linha = Linha & RChr(" ", 18, " ", "D", False)                                                  'cp 66 - pos686
                Linha = Linha & RChr(" ", 2, " ", "D", False)                                                   'cp 67 - pos704
                Linha = Linha & RChr(" ", 14, " ", "D", False)                                                  'cp 68 - pos706
                Linha = Linha & RChr(" ", 18, " ", "D", False)                                                  'cp 69 - pos720
                Linha = Linha & RChr(" ", 2, " ", "D", False)                                                   'cp 70 - pos738
                Linha = Linha & RChr(" ", 1, " ", "D", False)                                                   'cp 71 - pos740
                Linha = Linha & RChr(" ", 7, " ", "D", False)                                                   'cp 72 - pos741
                Linha = Linha & RChr(" ", 2, " ", "D", False)                                                   'cp 73 - pos748
                Linha = Linha & RChr(" ", 7, " ", "D", False)                                                   'cp 74 - pos750
                Linha = Linha & RChr(" ", 2, " ", "D", False)                                                   'cp 75 - pos757
                Linha = Linha & RChr(" ", 7, " ", "D", False)                                                   'cp 76 - pos759 - Placa 3  (7)
                Linha = Linha & RChr(" ", 2, " ", "D", False)                                                   'cp 77 - pos766 - UF da Placa 3 (2)
                Linha = Linha & RChr(" ", 1, " ", "D", False)                                                   'cp 78 - pos768 - Movimenta��o f�sica do combust�vel
                Linha = Linha & RChr(Nz(0, 3), 4, "0", "E", False)                                              'cp 79 - pos769 - Class.Contab.-Integra��o -
                Linha = Linha & RChr(" ", 2, " ", "D", False)                                                   'cp 80 - pos773 - C�digo da Dipam - C�digo Oficial da Dipam: 11,12,13,22,23,24,25,26,31,35,36,37 e 38
                Linha = Linha & SChr(row("BaseCalcIcmsST"), 14, "0", "E", True)                                 'cp 81 - pos775 - pos775   Base de C�lculo Subst. Tribut.
                Linha = Linha & SChr(row("ValorIcmsST"), 14, "0", "E", True)                                    'cp 82 - pos789 - Imposto Retido Subst. Tribut.

                Linha = Linha & RChr(" ", 6, " ", "D", False)                                                   'cp 83 - pos803 - C�digo Recolhimento PIS/COFINS - Se n�o for informado, deixar em branco
                Linha = Linha & RChr("0", 1, "", "D", False)                                                    'cp 84 - pos809 - Nota Cancelada 0- N�o cancelada e 1-Cancelada
                Linha = Linha & RChr(" ", 6, " ", "D", False)                                                   'cp 85 - pos810 - Espa�o Reservado
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorFrete")), 2), 14, 0, "E", True)               'cp 86 - pos816 - Valor Frete
                'Linha = Linha & SChr(FormatNumber(NzZero(row("Valorfrete")), 2), 14, "0", "E", True)    '816 pos teste (deu certo)
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)                                'cp 87 - pos830 - Valor do Seguro
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorOutros")), 2), 14, 0, "E", True)                                'cp 88 - pos844 - Valor Outras Despesas
                Linha = Linha & RChr(row("EspecieDocumento"), 5, " ", "D", False)                               'cp 89 - pos858 - Esp�cie do documento (Windows) (5) Alfanum�rico-0 a 9/A a Z
                Linha = Linha & RChr(" ", 1, " ", "D", False)                                                   'cp 90 - pos863 - IPI na Base do ICMS (1) 0-N�o, 1-Sim
                Linha = Linha & RChr(row("Serie"), 3, " ", "D", False)                                          'cp 91 - pos864 - S�rie
                Linha = Linha & RChr(row("SubSerie"), 2, " ", "D", False)                                       'cp 92 - pos867 - SubS�rie
                Linha = Linha & RChr(" ", 104, " ", "D", False)                                                 'Brancos-pos869
                Linha = Linha & RChr(row("ChaveNFe"), 44, " ", "D", False)                                      'cp 104- pos973 - SPED - Chave Fiscal Eletr�nica (44)
                Linha = Linha & RChr(" ", 109, " ", "D", False)                                                 'Branco- pos1017 at�1125
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorDesconto")), 2), 14, "0", "E", True)         'cp 117- pos1126- Valor de descontos

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.ToString)
            End Try
        Next

        'Notas sem Itens.....O arquivo de texto continua aberto para adi��o

        Sql = "SELECT Compra.*, Fornecedor.* FROM (Compra LEFT JOIN ItensCompra ON Compra.CompraInterno = ItensCompra.CompraInterno) INNER JOIN Fornecedor ON Compra.CodigoFornecedor = Fornecedor.C�digoFornecedor WHERE (((ItensCompra.CompraInterno) Is Null) AND ((Compra.DataLan�amento) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#) AND ((Compra.Confirmado)=True) AND ((Compra.Inativo)=False) AND ((Compra.Empresa)=" & CodEmpresa & ") AND ((Compra.Tipo)='NF') AND ((Compra.TpEntrada)='ENTRADA'));"
        Dim daNF1 As New OleDb.OleDbDataAdapter(Sql, Cnn)
        daNF1.Fill(ds, "NF1")

        For Each row As DataRow In ds.Tables("NF1").Rows
            Try

                Linha = Linha & RChr(" ", 4, " ", "D", False) 'cp 1
                Linha = Linha & RChr(row("CgcCpf"), 14, 0, "E", True) 'cp 2
                Linha = Linha & RChr(Format(CDate(row("DataLan�amento")), "dd/MM/yy"), 6, 0, "E", True) 'cp 3  = data entrada
                Linha = Linha & RChr(Format(CDate(row("DataCompra")), "dd/MM/yy"), 6, 0, "E", True)  'cp 4
                Linha = Linha & RChr(row("NotaFiscal"), 6, 0, "E", False) 'cp 5
                Linha = Linha & RChr(" ", 3, " ", "D", True)  'cp 6
                Linha = Linha & RChr("   ", 3, " ", "D", False) 'cp 7
                Linha = Linha & RChr("0", 1, " ", "D", False) 'cp 8
                Linha = Linha & SChr("00000", 5, 0, "E", True) 'cp 9
                Linha = Linha & SChr("000", 3, 0, "E", True) 'cp 10
                Linha = Linha & SChr(FormatNumber(Nz(row("TotalProdutos"), 3), 2), 14, 0, "E", True) 'cp 11
                Linha = Linha & SChr(FormatNumber(Nz(row("BaseCalcIcms"), 3), 2), 14, 0, "E", True) 'cp 12
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorIcms"), 3), 2), 14, 0, "E", True)  'cp 13
                Linha = Linha & SChr(FormatNumber(Nz(row("IsentoIcms"), 3), 2), 14, 0, "E", True)  'cp 14
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorOutrosIcms"), 3), 2), 14, 0, "E", True) 'cp 15
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 16
                Linha = Linha & SChr(FormatNumber(Nz(row("Icms"), 3), 2), 5, 0, "E", True)  'cp 17
                Linha = Linha & SChr(FormatNumber(Nz(row("BaseCalcIpi"), 3), 2), 14, 0, "E", True) 'cp 18
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorIpi"), 3), 2), 14, 0, "E", True) 'cp 19
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)  'cp 20
                Linha = Linha & SChr(FormatNumber(Nz(row("IsentoIpi"), 3), 2), 14, 0, "E", True) 'cp 21
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorOutrosIpi"), 3), 2), 14, 0, "E", True) 'cp 22
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorCompra"), 3), 2), 14, 0, "E", True) 'cp 23

                Linha = Linha & RChr(row("FormaPagamento"), 1, 0, "E", False) 'cp 24
                Linha = Linha & SChr(row("FormaPagamento"), 2, 0, "E", True)  'cp 25

                Linha = Linha & SChr("0", 3, 0, "E", True) 'cp 26
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 27
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 28
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 29
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 30
                Linha = Linha & RChr(" ", 100, " ", "D", False) 'cp 31
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 32
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 33
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 34
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 35
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 36
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 37
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 38
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 39
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 40
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 41
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 42
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 43
                Linha = Linha & RChr(row("Incri��oEstadual"), 18, " ", "D", False)  'cp 44
                Linha = Linha & RChr(row("Estado"), 2, " ", "D", False)  'cp 45
                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 46
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 47
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 48
                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 49
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 50
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 51
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 52
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 53
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 54
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 55
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 56
                Linha = Linha & RChr(" ", 3, " ", "D", False) 'cp 57
                Linha = Linha & RChr(" ", 4, " ", "D", False) 'cp 58
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 59
                Linha = Linha & RChr(row("Cfop"), 4, " ", "D", True)   'cp 60
                Linha = Linha & RChr(" ", 10, " ", "D", False) 'cp 61
                Linha = Linha & RChr(" ", 14, " ", "D", False) 'cp 62
                Linha = Linha & RChr(" ", 18, " ", "D", False) 'cp 63
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 64
                Linha = Linha & RChr(" ", 14, " ", "D", False) 'cp 65
                Linha = Linha & RChr(" ", 18, " ", "D", False) 'cp 66
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 67
                Linha = Linha & RChr(" ", 14, " ", "D", False) 'cp 68
                Linha = Linha & RChr(" ", 18, " ", "D", False) 'cp 69
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 70
                Linha = Linha & RChr(" ", 1, " ", "D", False) 'cp 71
                Linha = Linha & RChr(" ", 7, " ", "D", False) 'cp 72
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 73
                Linha = Linha & RChr(" ", 7, " ", "D", False) 'cp 74
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 75
                Linha = Linha & RChr(" ", 7, " ", "D", False) 'cp 76
                Linha = Linha & RChr(" ", 2, " ", "D", False)  'cp 77

                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 78
                Linha = Linha & RChr(Nz(0, 3), 4, "0", "E", False)  'cp 79
                Linha = Linha & RChr(" ", 2, " ", "D", False)  'cp 80
                Linha = Linha & RChr("0", 14, " ", "D", False) 'cp 81
                Linha = Linha & RChr("0", 14, " ", "D", False)  'cp 82

                Linha = Linha & RChr(" ", 6, " ", "D", False)  'cp 83
                Linha = Linha & RChr("0", 1, "", "D", False)  'cp 84
                Linha = Linha & RChr(" ", 6, " ", "D", False)  'cp 85
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 86
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 87
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 88
                Linha = Linha & RChr(row("EspecieDocumento"), 5, " ", "D", False)  'cp 89
                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 90
                Linha = Linha & RChr(row("Serie"), 3, " ", "D", False)  'cp 91
                Linha = Linha & RChr(row("SubSerie"), 2, " ", "D", False)  'cp 92
                Linha = Linha & RChr(" ", 104, " ", "D", False)  'Brancos
                Linha = Linha & RChr(row("ChaveNFe"), 44, " ", "D", False)  'Chave da NFe
                Linha = Linha & RChr(" ", 109, " ", "D", False)  'Branco
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorDesconto")), 2), 14, "0", "E", True)  '1126

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.ToString)
            End Try
        Next

        FileClose(1)

        'Come�a a exporta�ao dos itens

        Dim Agregados As Double
        Dim VlrDiv As Double

        Linha = ""
        'FileOpen(1, Me.Local.Text & "\ITEM_ENT." & Me.EmpProSoft.Text, OpenMode.Append)
        FileOpen(1, Me.Local.Text & "\ITEM_ENT." & Me.EmpProSoft.Text, OpenMode.Output)

        For Each row As DataRow In ds.Tables("TB").Rows
            Try
                'ValorIcmsST,ValorFreteProduto
                Agregados = CDbl(NzZero(row("ItensCompra.ValorIcmsST"))) + CDbl(NzZero(row("ValorFreteProduto"))) + CDbl(NzZero(row("vSeg"))) + CDbl(NzZero(row("vOutro"))) + NzZero(row("ItensCompra.ValorIpi"))
                VlrDiv = (Agregados / NzZero(row("Qtd")))

                Linha = Linha & RChr(row("CgcCpf"), 14, " ", "D", True) 'pos1
                Linha = Linha & RChr(Format(CDate(row("DataLan�amento")), "yyyy/MM/dd"), 8, " ", "D", True)   'pos15 = data entrada
                Linha = Linha & RChr(row("NotaFiscal"), 6, "0", "E", False) 'pos23
                Linha = Linha & RChr("   ", 3, " ", "D", False) 'pos29        S�rie e subs�rie
                Linha = Linha & RChr(row("ItemDesdobramento"), 1, 0, "E", False) 'pos32
                Linha = Linha & RChr(row("SeqNf"), 2, "0", "E", False) 'pos33
                Linha = Linha & RChr(row("ItensCompra.CodigoProduto"), 20, " ", "D", False) 'pos35
                Linha = Linha & RChr(row("CFOPent") & "", 4, " ", "D", True) 'pos55
                Linha = Linha & RChr(row("UnidadeMedida"), 3, " ", "D", False) 'pos59
                Linha = Linha & RChr(row("Produtos.Cst"), 3, "0", "E", False) 'pos62
                Linha = Linha & SChr(FormatNumber(NzZero(row("Qtd")), 3), 14, 0, "E", True) 'pos65
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorUnitario")), 4), 14, 0, "E", True) 'pos79

                Dim T As Double = (NzZero(row("ValorUnitario"))) * NzZero(row("Qtd")) - NzZero(row("ItensCompra.ValorDesconto")) 'Foi adicionado o desconto por causa do contador do fernando
                Linha = Linha & SChr(FormatNumber(NzZero(row("ItensCompra.ValorDesconto")), 2), 14, 0, "E", True) 'pos93
                Linha = Linha & SChr(FormatNumber(NzZero(T), 2), 14, 0, "E", True)  'pos107
                Linha = Linha & SChr(FormatNumber(row("ItensCompra.Ipi"), 2), 5, 0, "E", True)  'pos121 NzZero(row("ItensCompra.Ipi"))
                Linha = Linha & SChr(FormatNumber(row("ItensCompra.ValorIpi"), 2), 14, 0, "E", True)  'pos126 NzZero(row("ItensCompra.ValorIpi"))

                If NzZero(row("IcmsProduto")) > 0 Then
                    Linha = Linha & SChr(FormatNumber(row("ItensCompra.BaseCalcIcms"), 2), 14, 0, "E", True)  'pos140
                Else
                    Linha = Linha & SChr("0", 14, 0, "E", True)  'pos140
                End If

                Linha = Linha & SChr(FormatNumber(row("BaseCalcST"), 2), 14, 0, "E", True) 'pos154

                Linha = Linha & RChr(row("Descri��o"), 80, " ", "D", False) 'pos168
                Linha = Linha & RChr("0", 2, "0", "E", False) 'pos248  PRODUTO - Grupo do produto (DOS)
                Linha = Linha & RChr(row("Produtos.CF"), 10, " ", "D", False) 'pos250
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'pos260
                Linha = Linha & SChr(FormatNumber(0, 2), 5, 0, "E", True)  'pos262
                Linha = Linha & SChr(FormatNumber(0, 2), 5, 0, "E", True)  'pos267
                Linha = Linha & SChr(FormatNumber(0, 2), 14, 0, "E", True)  'pos272
                Linha = Linha & SChr(FormatNumber(Nz(row("Produtos.Ipi"), 3), 2), 5, 0, "E", True)  'pos286
                Linha = Linha & SChr("0", 2, 0, "E", True)  'pos291
                Linha = Linha & SChr(row("Produtos.Cst"), 3, 0, "E", True)  'pos293
                Linha = Linha & SChr(Mid(row("Descri��o"), 1, 30), 30, " ", "E", True)  'pos296
                Linha = Linha & SChr(" ", 3, " ", "E", True)  'pos326
                Linha = Linha & SChr("S", 1, " ", "E", True)  'pos329
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True)  'pos330

                Linha = Linha & SChr("O", 1, " ", "E", True)  'pos344
                Linha = Linha & SChr(FormatNumber(NzZero(row("IcmsProduto")), 2), 5, 0, "E", True)  'pos345
                Linha = Linha & SChr(FormatNumber(row("ValorIcmsProduto"), 2), 14, 0, "E", True)  'pos350
                Linha = Linha & SChr("O", 1, " ", "E", True)  'pos364
                Linha = Linha & SChr(FormatNumber(row("ItensCompra.ValorIcmsST"), 2), 14, 0, "E", True)  'pos365
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  'pos379
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  'pos393
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  'pos407
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  'pos421
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  'pos435
                Linha = Linha & RChr("0", 3, "0", "E", False) 'pos449
                Linha = Linha & RChr(" ", 2, " ", "E", False) 'pos452
                Linha = Linha & RChr(" ", 2, " ", "E", False) 'pos454
                Linha = Linha & RChr(" ", 96, " ", "D", False) 'pos456
                Linha = Linha & RChr(" ", 10, " ", "E", False) 'pos552
                Linha = Linha & RChr(" ", 8, " ", "E", False) 'pos562
                Linha = Linha & RChr(" ", 1, " ", "E", False) 'pos570
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) 'pos571
                Linha = Linha & RChr(" ", 2, " ", "E", False) 'pos585
                Linha = Linha & RChr("1", 1, " ", "E", False) 'pos587
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) 'pos588
                Linha = Linha & SChr(FormatNumber(row("ItensCompra.ValorOutrosIcms"), 2), 14, "0", "E", True) '602 retirado pelo para acerto referente outros icms
                'Linha = Linha & SChr(FormatNumber(row("vOutro"), 2), 14, "0", "E", True) 'pos602  - 
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) 'pos616
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) 'pos630
                Linha = Linha & RChr("0000", 4, "0", "E", False) 'pos644
                Linha = Linha & RChr(row("ItensCompra.Serie"), 3, " ", "D", False) 'pos648
                Linha = Linha & RChr(row("ItensCompra.SubSerie"), 2, " ", "D", False) 'pos651
                Linha = Linha & RChr("0", 10, "0", "E", False) 'pos653
                'Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) 'pos663 - Retirado 
                Linha = Linha & SChr(FormatNumber(row("vOutro"), 2), 14, "0", "E", True) '663
                Linha = Linha & RChr(row("Incri��oEstadual"), 18, " ", "E", True) 'pos677
                Linha = Linha & RChr(row("Estado"), 2, " ", "E", False) 'pos695
                Linha = Linha & RChr(row("CSTIPIent"), 2, " ", "E", False) 'pos697
                Linha = Linha & RChr(row("CSTPISent"), 2, " ", "E", False) 'pos699
                Linha = Linha & RChr(row("CSTCOFINSent"), 2, " ", "E", False) 'pos701

                Dim Brancos As String = RChr(" ", 327, " ", "D", False)     'qtd de espa�o em branco era 575
                Linha = Linha & Brancos

                ' Linha = Linha & SChr(FormatNumber(NzZero(row("ValorFrete")), 2), 14, "0", "E", True) 'pos1030
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorFreteProduto")), 2), 14, "0", "E", True) 'pos1030

                Brancos = RChr(" ", 234, " ", "D", False)     'novo valor para gerar espa�o em branco ap�s a inclus�o do valor de frete
                Linha = Linha & Brancos

                Linha = Linha & SChr(FormatNumber(NzZero(row("vBCpis")), 2), 14, "0", "E", True) 'pos1278
                Linha = Linha & SChr(FormatNumber(NzZero(row("PisProduto")), 4), 8, "0", "E", True) 'pos1292
                Linha = Linha & SChr(FormatNumber(NzZero(row("CofinsProduto")), 4), 8, "0", "E", True) 'pos1300
                Linha = Linha & RChr(" ", 30, " ", "E", False)
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorPisProduto")), 2), 14, "0", "E", True) 'pos1338
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorCofinsProduto")), 2), 14, "0", "E", True) 'pos1352
                Linha = Linha & RChr(" ", 48, " ", "E", False)

                Linha = Linha & RChr(row("CTB"), 12, " ", "E", False) 'pos1414
                Linha = Linha & RChr(row("cstPISentr"), 2, " ", "E", False) 'pos1426
                Linha = Linha & RChr(row("cstCOFINSentr"), 2, " ", "E", False) 'pos1428

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.Message)
            End Try
        Next
        FileClose(1)

        MsgBox("Exporta��o Concluida", 64, "Valida��o de Dados")

        daExport.Dispose()
        Cnn.Close()

    End Sub

    Public Sub ExportaInventario()

        If String.IsNullOrEmpty(Me.DataInicial.Text) Or String.IsNullOrEmpty(Me.DataFinal.Text) Then
            MsgBox("Aten��o! Datas incorretas, digite corretamente a data inicial e data final para gerar o relat�rio", 48, "Valida��o de dados")
            DataInicial.Focus()
            Return
        End If

        'conexao com db gestor
        Dim conn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        conn.Open()

        'conexao com db nfe
        Dim conNFe As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & LocalDBNFe & "NFe" & Me.AnoInventario.Text & ".mdb")

        Try
            conNFe.Open()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("Banco de Dados da NFe n�o encontrado, Favor Verificar.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.Message, "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try

        Dim cmdInventario As OleDb.OleDbCommand
        Dim DR As OleDb.OleDbDataReader
        Dim DRnfe As OleDb.OleDbDataReader
        Dim oDA As OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor

            oDA = New OleDb.OleDbDataAdapter("Select * from iventario", conn)
            oDA.Fill(DS, "Iventario")

            'gerar os dados para a tabela iventario entra.
            cmdInventario = New OleDb.OleDbCommand("SELECT Compra.Tipo, Produtos.CodigoNFE, Sum(ItensCompra.Qtd) AS SomaDeQtd, Produtos.CodigoProduto FROM (Compra INNER JOIN ItensCompra ON Compra.CompraInterno = ItensCompra.CompraInterno) INNER JOIN Produtos ON ItensCompra.CodigoProduto = Produtos.CodigoProduto WHERE (((Compra.DataLan�amento) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#)) And (Compra.Inativo = False) AND ((ItensCompra.CFOPent)<>'1551' AND (ItensCompra.CFOPent)<>'1556' AND (ItensCompra.CFOPent)<>'2910' AND (ItensCompra.CFOPent)<>'2550' And (ItensCompra.CFOPent)<>'2551' And (ItensCompra.CFOPent)<>'2552' And (ItensCompra.CFOPent)<>'2553' And (ItensCompra.CFOPent)<>'2554' And (ItensCompra.CFOPent)<>'2555' And (ItensCompra.CFOPent)<>'2556' And (ItensCompra.CFOPent)<>'2557') GROUP BY Compra.Tipo, Produtos.CodigoNFE, Produtos.CodigoProduto HAVING (((Compra.Tipo)='NF'))", conn)
            DR = cmdInventario.ExecuteReader

            Dim tb As DataTable
            tb = DS.Tables("Iventario")
            Dim linhaNew As DataRow

            While DR.Read()
                linhaNew = tb.NewRow
                linhaNew("CodigoNfe") = DR.Item(1)
                linhaNew("Qtde") = DR.Item(2)
                linhaNew("CodigoProduto") = DR.Item(3)
                tb.Rows.Add(linhaNew)
            End While
            cmdInventario = New OleDb.OleDbCommand("SELECT NFeItens.Cprod AS Produto, Sum([qCom]*-1) AS Qtd, Produtos.CodigoERP FROM Produtos INNER JOIN (NFe INNER JOIN NFeItens ON NFe.chaveAcesso = NFeItens.ChaveAcesso) ON Produtos.Cprod = NFeItens.Cprod WHERE (((Nfe.DataEmissao) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#) AND ((NFe.tpNF)='1')) and Nfe.StatusNFe = 'Autorizada'  GROUP BY NFeItens.Cprod, Produtos.CodigoERP HAVING ((Not (Produtos.CodigoERP) Is Null));", conNFe)

            DRnfe = cmdInventario.ExecuteReader

            While DRnfe.Read()
                linhaNew = tb.NewRow
                linhaNew("CodigoNfe") = DRnfe.Item("Produto")
                linhaNew("CodigoProduto") = DRnfe.Item("CodigoERP")
                linhaNew("Qtde") = DRnfe.Item("Qtd")
                tb.Rows.Add(linhaNew)
            End While

            Dim oCmdBder As New OleDb.OleDbCommandBuilder(oDA)
            oDA.Update(DS, "Iventario")

            
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader

        Cnn.Open()

        With Cmd
            .Connection = Cnn
            .CommandText = "SELECT Iventario.CodigoProduto, Sum(Iventario.Qtde) AS SomaDeQtde, Produtos.ValorCompra, Sum([ValorCompra]*[QTDE]) AS ValorTotal, Produtos.Descri��o, Produtos.C�digoGrupo, Produtos.CF, Produtos.UnidadeMedida, Grupos.Descri��o AS DescGrupo FROM (Iventario INNER JOIN Produtos ON Iventario.CodigoProduto = Produtos.CodigoProduto) INNER JOIN Grupos ON Produtos.C�digoGrupo = Grupos.C�digoGrupo GROUP BY Iventario.CodigoProduto, Produtos.ValorCompra, Produtos.Descri��o, Produtos.C�digoGrupo, Produtos.CF, Produtos.UnidadeMedida, Grupos.Descri��o;"
            .CommandType = CommandType.Text
        End With

        DataReader = Cmd.ExecuteReader

        Dim Linha As String = ""
        FileOpen(1, Me.Local.Text & "\INVENTARIO." & Me.EmpProSoft.Text, OpenMode.Append)
        While DataReader.Read
            Try
                Linha = Linha & RChr(Me.DataFinal.Text, 8, "", "E", True) '1
                Linha = Linha & RChr(CDate(Me.DataInicial.Text).Month & Mid(CDate(Me.DataInicial.Text).Year, 3), 4, 0, "E", True) '9
                Linha = Linha & RChr(CDate(Me.DataFinal.Text).Month & Mid(CDate(Me.DataFinal.Text).Year, 3), 4, 0, "E", True) '13
                Linha = Linha & RChr(DataReader.Item("CodigoProduto"), 20, " ", "D", False) '17
                Linha = Linha & RChr("1", 1, "", "D", False) '37
                Linha = Linha & RChr("00000000000000", 14, "", "D", False) '38
                Linha = Linha & RChr("", 20, " ", "D", False) '52
                Linha = Linha & RChr("", 2, " ", "D", False) '72
                Linha = Linha & RChr("", 5, " ", "D", False) '74
                Linha = Linha & SChr(FormatNumber(NzZero(DataReader.Item("SomaDeQtde")), 6), 16, "0", "E", True) '79
                Linha = Linha & SChr(FormatNumber(NzZero(DataReader.Item("ValorCompra")), 4), 17, "0", "E", True) '95
                Linha = Linha & SChr(FormatNumber(NzZero(DataReader.Item("ValorTotal")), 2), 17, "0", "E", True) '112
                Linha = Linha & SChr(FormatNumber(NzZero(0), 2), 17, "0", "E", True) '129
                Linha = Linha & RChr("", 60, " ", "D", False) '146
                Linha = Linha & RChr(DataReader.Item("Descri��o"), 80, " ", "D", False) '206
                Linha = Linha & RChr(DataReader.Item("C�digoGrupo"), 4, " ", "D", False) '286
                Linha = Linha & RChr(DataReader.Item("CF"), 10, " ", "D", False) '290
                Linha = Linha & RChr("", 30, " ", "D", False) '300
                Linha = Linha & RChr(DataReader.Item("UnidadeMedida"), 3, " ", "D", False) '330
                Linha = Linha & RChr(DataReader.Item("DescGrupo"), 30, " ", "D", False) '333

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.ToString)
                MsgBox("Verique o Cliente : " & DataReader.Item("Nome"))
            End Try
            MyBarra.PerformStep()
        End While
        FileClose(1)

        DataReader.Close()

        Dim cmdExclui As New OleDb.OleDbCommand("Delete * from Iventario", conn)
        cmdExclui.ExecuteNonQuery()
        cmdExclui.Dispose()

        Cnn.Close()
        conn.Close()
        conNFe.Close()
        Me.Cursor = Cursors.Default
        MsgBox("Exporta��o Concluida", 64, "Valida��o de Dados")
        Me.MyBarra.Visible = False
    End Sub
    Public Sub ExportaInventarioAgrupado()

        If String.IsNullOrEmpty(Me.DataInicial.Text) Or String.IsNullOrEmpty(Me.DataFinal.Text) Then
            MsgBox("Aten��o! Datas incorretas, digite corretamente a data inicial e data final para gerar o relat�rio", 48, "Valida��o de dados")
            DataInicial.Focus()
            Return
        End If

        'conexao com db gestor
        Dim conn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        conn.Open()

        'conexao com db nfe
        Dim conNFe As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & LocalDBNFe & "NFe" & Me.AnoInventario.Text & ".mdb")

        Try
            conNFe.Open()
        Catch ex As Exception
            If Err.Number = 5 Then
                MessageBox.Show("Banco de Dados da NFe n�o encontrado, Favor Verificar.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.Message, "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try

        Dim cmdInventario As OleDb.OleDbCommand
        Dim DR As OleDb.OleDbDataReader
        Dim DRnfe As OleDb.OleDbDataReader
        Dim oDA As OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor

            oDA = New OleDb.OleDbDataAdapter("Select * from iventario", conn)
            oDA.Fill(DS, "Iventario")

            'gerar os dados para a tabela iventario entra.
            cmdInventario = New OleDb.OleDbCommand("SELECT Compra.Tipo, Produtos.CodigoNFE, Sum(ItensCompra.Qtd) AS SomaDeQtd, Produtos.CodigoProduto FROM (Compra INNER JOIN ItensCompra ON Compra.CompraInterno = ItensCompra.CompraInterno) INNER JOIN Produtos ON ItensCompra.CodigoProduto = Produtos.CodigoProduto WHERE (((Compra.DataLan�amento) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#)) And (Compra.Inativo = False) AND ((ItensCompra.CFOPent)<>'1551' AND (ItensCompra.CFOPent)<>'1556' AND (ItensCompra.CFOPent)<>'2910' AND (ItensCompra.CFOPent)<>'2550' And (ItensCompra.CFOPent)<>'2551' And (ItensCompra.CFOPent)<>'2552' And (ItensCompra.CFOPent)<>'2553' And (ItensCompra.CFOPent)<>'2554' And (ItensCompra.CFOPent)<>'2555' And (ItensCompra.CFOPent)<>'2556' And (ItensCompra.CFOPent)<>'2557') GROUP BY Compra.Tipo, Produtos.CodigoNFE, Produtos.CodigoProduto HAVING (((Compra.Tipo)='NF'))", conn)
            DR = cmdInventario.ExecuteReader

            Dim tb As DataTable
            tb = DS.Tables("Iventario")
            Dim linhaNew As DataRow

            While DR.Read()
                linhaNew = tb.NewRow
                linhaNew("CodigoNfe") = DR.Item(1)
                linhaNew("Qtde") = DR.Item(2)
                linhaNew("CodigoProduto") = DR.Item(3)
                tb.Rows.Add(linhaNew)
            End While
            cmdInventario = New OleDb.OleDbCommand("SELECT NFeItens.Cprod AS Produto, Sum([qCom]*-1) AS Qtd, Produtos.CodigoERP FROM Produtos INNER JOIN (NFe INNER JOIN NFeItens ON NFe.chaveAcesso = NFeItens.ChaveAcesso) ON Produtos.Cprod = NFeItens.Cprod WHERE (((Nfe.DataEmissao) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#) AND ((NFe.tpNF)='1')) and Nfe.StatusNFe = 'Autorizada'  GROUP BY NFeItens.Cprod, Produtos.CodigoERP HAVING ((Not (Produtos.CodigoERP) Is Null));", conNFe)

            DRnfe = cmdInventario.ExecuteReader

            While DRnfe.Read()
                linhaNew = tb.NewRow
                linhaNew("CodigoNfe") = DRnfe.Item("Produto")
                linhaNew("CodigoProduto") = DRnfe.Item("CodigoERP")
                linhaNew("Qtde") = DRnfe.Item("Qtd")
                tb.Rows.Add(linhaNew)
            End While

            Dim oCmdBder As New OleDb.OleDbCommandBuilder(oDA)
            oDA.Update(DS, "Iventario")

        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

        conn.Close()
        conNFe.Close()
        Me.Cursor = Cursors.Default
        MsgBox("Dados Agrupados!", 64, "Valida��o de Dados")
        Me.MyBarra.Visible = False
    End Sub

    Public Sub ExTerceiros()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader

        Cnn.Open()

        With Cmd
            .Connection = Cnn
            '.CommandText = "SELECT Clientes.CpfCgc, Clientes.Nome, Clientes.NomeFantasia,Clientes.Logradouro, Clientes.Endere�o,Clientes.Nro, Clientes.Cidade, Clientes.Bairro, Clientes.Cep, Clientes.Estado, Clientes.cMun, Clientes.Telefone, Clientes.Insc, Clientes.Inativo, Clientes.Empresa, Clientes.TipoPessoa AS FJ ,'Cliente' AS TP FROM(Clientes) WHERE Clientes.Inativo = FALSE  AND Clientes.Empresa =" & CodEmpresa & " and Clientes.CpfCgc is not null  UNION SELECT Fornecedor.CgcCpf AS CpfCgc, Fornecedor.Raz�oSocial AS Nome, Fornecedor.NomeFantasia,Fornecedor.Logradouro, Fornecedor.Endere�o, Fornecedor.nro,Fornecedor.Cidade, '' AS Bairro, Fornecedor.Cep, Fornecedor.Estado, Fornecedor.cMun, Fornecedor.Telefone1 AS Telefone, Fornecedor.Incri��oEstadual AS Insc, Fornecedor.Inativo, Fornecedor.Empresa, Fornecedor.TipoFornecedor AS FJ, 'Fornecedor' AS TP FROM(Fornecedor) WHERE Fornecedor.Inativo=False AND Fornecedor.Empresa = " & CodEmpresa & " and Fornecedor.CgcCpf is not null;"
            .CommandText = "SELECT Clientes.CpfCgc, Clientes.Nome, Clientes.NomeFantasia,Clientes.Logradouro, Clientes.Endere�o,Clientes.Nro, Clientes.Cidade, Clientes.Bairro, Clientes.Cep, Clientes.Estado, Clientes.cMun, Clientes.Telefone, Clientes.Insc, Clientes.Inativo, Clientes.Empresa, Clientes.TipoPessoa AS FJ ,'Cliente' AS TP FROM(Clientes) WHERE Clientes.Inativo = FALSE  AND Clientes.Empresa =" & CodEmpresa & " and Clientes.CpfCgc is not null  UNION SELECT Fornecedor.CgcCpf AS CpfCgc, Fornecedor.Raz�oSocial AS Nome, Fornecedor.NomeFantasia,Fornecedor.Logradouro, Fornecedor.Endere�o, Fornecedor.nro,Fornecedor.Cidade, Fornecedor.Bairro, Fornecedor.Cep, Fornecedor.Estado, Fornecedor.cMun, Fornecedor.Telefone1 AS Telefone, Fornecedor.Incri��oEstadual AS Insc, Fornecedor.Inativo, Fornecedor.Empresa, Fornecedor.TipoFornecedor AS FJ, 'Fornecedor' AS TP FROM(Fornecedor) WHERE Fornecedor.Inativo=False AND Fornecedor.Empresa = " & CodEmpresa & " and Fornecedor.CgcCpf is not null;"
            .CommandType = CommandType.Text
        End With

        DataReader = Cmd.ExecuteReader

        Dim Linha As String = ""
        'FileOpen(1, Me.Local.Text & "\TERCEIROS." & Me.EmpProSoft.Text, OpenMode.Append)
        FileOpen(1, Me.Local.Text & "\TERCEIROS." & Me.EmpProSoft.Text, OpenMode.Output)
        While DataReader.Read
            Try
                Linha = Linha & "TRC" 'Cp1
                Linha = Linha & "     " 'cp2
                Linha = Linha & "  " 'Cp3

                Dim Personalidade As String = "2"

                Try
                    If DataReader.Item("FJ") = "F" Then
                        Personalidade = "1"
                    End If

                    If DataReader.Item("FJ") = "J" Then
                        Personalidade = "0"
                    End If
                Catch ex As Exception
                    Personalidade = "1"
                End Try
                Linha = Linha & Personalidade 'cp4

                Dim C As String = RChr(Trim(DataReader.Item("CpfCgc")), 14, "0", "E", True)

                Linha = Linha & C  'cp5
                Linha = Linha & RChr(DataReader.Item("Nome"), 60, " ", "D", False) 'cp6
                Linha = Linha & RChr(DataReader.Item("NomeFantasia"), 20, " ", "D", False) 'cp7
                ' Linha = Linha & RChr("", 10, " ", "D", False) 'cp8 tipo de logradouro

                Linha = Linha & RChr(DataReader.Item("logradouro"), 10, " ", "D", False) 'cp8
                Linha = Linha & RChr(DataReader.Item("Endere�o"), 60, " ", "D", False) 'cp9
                'Linha = Linha & RChr("", 10, " ", "D", False) 'cp10 - retirado por 
                Linha = Linha & RChr(DataReader.Item("Nro"), 10, " ", "D", False) 'cp10 - incluido por 11-06-2014
                Linha = Linha & RChr("", 20, " ", "D", False) 'cp11
                Linha = Linha & RChr(DataReader.Item("Cep"), 9, " ", "D", False) 'cp12
                Linha = Linha & RChr(DataReader.Item("Bairro"), 30, " ", "D", False) 'cp13
                Linha = Linha & RChr(DataReader.Item("Cidade"), 30, " ", "D", False) 'cp14
                Linha = Linha & RChr(DataReader.Item("Estado"), 2, " ", "D", False) 'cp15
                Linha = Linha & RChr(Format(CDate(Today), "yyyyMMdd"), 8, " ", "D", False) 'cp16 data de cadastro
                Linha = Linha & RChr("", 5, " ", "D", False) 'cp17 Telefone ddd
                Linha = Linha & RChr("", 10, " ", "D", False) 'cp18 telefone numero
                Linha = Linha & RChr("", 5, " ", "D", False) 'cp19 telefax ddd
                Linha = Linha & RChr("", 10, " ", "D", False) 'cp20 telefax numero
                Linha = Linha & RChr("", 50, " ", "D", False) 'cp21 email
                Linha = Linha & RChr("", 60, " ", "D", False) 'cp22 Home page
                Linha = Linha & RChr(DataReader.Item("Insc"), 20, " ", "D", False) 'cp23 inscricao estadual
                Linha = Linha & RChr("", 20, " ", "D", False) 'cp24 inscricao municipal
                Linha = Linha & RChr("", 10, " ", "D", False) 'cp25 cod ativ. economica
                Linha = Linha & RChr("", 18, " ", "D", False) 'cp26 rg numero pessoa fisica
                Linha = Linha & RChr("", 5, " ", "D", False) 'cp27 rg orgao emissor pessoa fisica
                Linha = Linha & RChr("", 2, " ", "D", False) 'cp28 rg estado emissor
                Linha = Linha & RChr("", 8, " ", "D", False) 'cp29 rg data da emiss�o
                Linha = Linha & RChr("", 1, " ", "D", False) 'cp30 sexo

                'Linha = Linha & RChr("", 4, " ", "D", False) 'cp31 codigo pais - retirado 
                'Linha = Linha & RChr("", 5, " ", "D", False) 'cp32 cod ibge    - retirado 

                Linha = Linha & RChr("1058", 4, " ", "D", False) 'cp31 codigo do pais
                Linha = Linha & RChr(Mid(DataReader.Item("cMUN"), 3, 5), 5, " ", "D", False) 'cp32 codigo do ibge

                Linha = Linha & RChr("", 86, " ", "D", False) 'cp33 filer em branco

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.ToString)
                MsgBox("Verique o Cliente : " & DataReader.Item("Nome"))
            End Try
            MyBarra.PerformStep()
        End While
        FileClose(1)

        DataReader.Close()
        Cnn.Close()

        MsgBox("Exporta��o Concluida", 64, "Valida��o de Dados")
        Me.MyBarra.Visible = False
    End Sub

    Public Sub ExProdutos()
        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader

        Cnn.Open()

        'Captura Qtd de Registro para definir a Barra
        Dim CmdTotalLinhas As New OleDb.OleDbCommand("SELECT Count(*) FROM Produtos WHERE Inativo = False and Descri��o is not null", Cnn)
        Dim TotalLinhas As Long = 0
        Try
            TotalLinhas = CInt(CmdTotalLinhas.ExecuteScalar())
        Catch
            TotalLinhas = 0
        End Try
        'Atualiza a barra de Progresso
        If TotalLinhas = 0 Then TotalLinhas = 1
        MyBarra.Visible = True
        MyBarra.Minimum = 1
        MyBarra.Maximum = TotalLinhas
        MyBarra.Value = 1
        MyBarra.Step = 1
        MyBarra.Visible = True
        'Fim dos dados da Barra de Progresso
        'fim

        With Cmd
            .Connection = Cnn
            .CommandText = "SELECT * from Produtos where Descri��o is not null and Inativo = false"
            .CommandType = CommandType.Text
        End With

        DataReader = Cmd.ExecuteReader

        Dim Linha As String = ""
        '  FileOpen(1, Me.Local.Text & "\PRODUTOS." & Me.EmpProSoft.Text, OpenMode.Append)
        FileOpen(1, Me.Local.Text & "\PRODUTOS." & Me.EmpProSoft.Text, OpenMode.Output)
        While DataReader.Read
            Try
                Linha = Linha & RChr(DataReader.Item("CodigoProduto"), 20, " ", "D", False) ' Campo 1  pos1
                Linha = Linha & RChr(UCase(DataReader.Item("Descri��o")), 80, " ", "D", False) ' Campo 2
                Linha = Linha & RChr("00", 2, " ", "D", False) ' Campo 3
                Linha = Linha & RChr(DataReader.Item("UnidadeMedida"), 3, " ", "D", False) ' Campo 4
                Linha = Linha & RChr(DataReader.Item("CF"), 10, " ", "E", False) ' Campo 5
                Linha = Linha & RChr(" ", 2, " ", "D", False) ' Campo 6
                Linha = Linha & RChr(FormatNumber(Nz(DataReader.Item("Icms"), 3), 2), 5, "0", "E", False) ' Campo 7
                Linha = Linha & RChr(FormatNumber(0, 2), 5, "0", "E", False) ' Campo 8
                Linha = Linha & RChr(FormatNumber(0, 2), 14, "0", "E", False) ' Campo 9
                Linha = Linha & RChr(DataReader.Item("Ipi"), 5, "0", "E", False) ' Campo 10
                Linha = Linha & RChr("0", 2, "0", "E", False) ' Campo 11
                Linha = Linha & RChr(DataReader.Item("Cst"), 3, "0", "E", False) ' Campo 12
                Linha = Linha & RChr("11", 2, " ", "D", False) ' Campo 13
                Linha = Linha & RChr(FormatNumber(0, 3), 14, "0", "E", False) ' Campo 14
                Linha = Linha & RChr(" ", 14, " ", "D", False) ' Campo 15
                Linha = Linha & RChr(" ", 7, " ", "D", False) ' Campo 16
                Linha = Linha & RChr(" ", 1, " ", "D", False) ' Campo 17
                Linha = Linha & RChr(" ", 5, " ", "D", False) ' Campo 18
                Linha = Linha & RChr(" ", 1, " ", "D", False) ' Campo 19
                Linha = Linha & RChr(" ", 4, " ", "D", False) ' Campo 20
                Linha = Linha & RChr(" ", 2, " ", "D", False) ' Campo 21
                Linha = Linha & RChr("0", 3, "0", "D", False) ' Campo 22
                Linha = Linha & RChr("0", 5, "0", "D", False) ' Campo 23
                Linha = Linha & RChr(FormatNumber(0, 3), 7, " ", "E", False) ' Campo 24
                Linha = Linha & RChr("0", 3, "0", "D", False) ' Campo 25
                Linha = Linha & RChr("0", 4, "0", "D", False) ' Campo 26
                Linha = Linha & RChr("0", 3, "0", "D", False) ' Campo 27
                Linha = Linha & RChr(FormatNumber(0, 2), 5, "0", "E", False) ' Campo 28
                Linha = Linha & RChr(FormatNumber(0, 2), 5, "0", "E", False) ' Campo 29
                Linha = Linha & RChr("0", 2, "0", "D", False) ' Campo 30
                Linha = Linha & RChr("0", 2, "0", "D", False) ' Campo 31
                Linha = Linha & RChr("0", 6, "0", "D", False) ' Campo 32
                Linha = Linha & RChr(" ", 30, " ", "D", False) ' Campo 33
                Linha = Linha & RChr(" ", 30, " ", "D", False) ' Campo 34
                Linha = Linha & RChr(" ", 4, " ", "D", False) ' Campo 35
                Linha = Linha & RChr("0", 4, "0", "D", False) ' Campo 36
                Linha = Linha & RChr(" ", 5, " ", "D", False) ' Campo 37
                Linha = Linha & RChr(FormatNumber(0, 4), 8, "0", "E", False) ' Pos 320
                Linha = Linha & RChr("N", 1, " ", "E", False) ' pos 328
                Linha = Linha & RChr("00", 2, " ", "E", False) ' pos 328
                Linha = Linha & RChr(" ", 84, " ", "D", False) ' campos vazios
                Linha = Linha & RChr(DataReader.Item("CodCTBEntrada"), 60, " ", "E", False) ' pos 415

                Linha = Linha & RChr(" ", 4, " ", "D", False) ' campos vazios

                Linha = Linha & RChr(DataReader.Item("cstpis"), 2, " ", "D", False) ' posicao 479
                Linha = Linha & RChr(DataReader.Item("cstcofins"), 2, " ", "D", False) ' posicao 481

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.ToString)
                MsgBox("Verique o Cliente : " & DataReader.Item("Nome"))
            End Try
            MyBarra.PerformStep()
        End While
        FileClose(1)

        DataReader.Close()
        Cnn.Close()

        MsgBox("Exporta��o Concluida", 64, "Valida��o de Dados")
        Me.MyBarra.Visible = False

    End Sub

    Public Sub ExportaEntradas()
        Dim ds As New DataSet

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT Compra.*, Fornecedor.CgcCpf, Fornecedor.Incri��oEstadual, Fornecedor.Estado, ItensCompra.*, ItensCompra.BaseCalcIcms as ItBaseCalcIcms,Produtos.*, 0 AS ItemDesdobramento FROM ((Compra INNER JOIN ItensCompra ON Compra.CompraInterno = ItensCompra.CompraInterno) INNER JOIN Fornecedor ON Compra.CodigoFornecedor = Fornecedor.C�digoFornecedor) INNER JOIN Produtos ON ItensCompra.CodigoProduto = Produtos.CodigoProduto WHERE (((Compra.DataLan�amento) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#) AND ((Compra.Confirmado)=True) AND ((Compra.Inativo)=False) AND ((Compra.Empresa)=" & Me.EmpUP.Text & ") AND ((Compra.Tipo)='NF') AND ((Compra.TpEntrada)='ENTRADA' Or (Compra.TpEntrada)='ENT. CONSERTO' Or (Compra.TpEntrada)='ENT BRINDE')) ORDER BY Compra.NotaFiscal, ItensCompra.CFOPent;"

        Dim daExport As New OleDb.OleDbDataAdapter(Sql, Cnn)
        daExport.Fill(ds, "TB")

        Sql = "SELECT Compra.NotaFiscal, ItensCompra.CFOPent FROM Compra INNER JOIN ItensCompra ON Compra.CompraInterno = ItensCompra.CompraInterno WHERE (((Compra.DataLan�amento) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#) AND ((Compra.Confirmado)=True) AND ((Compra.Inativo)=False) AND ((Compra.Empresa)=" & CodEmpresa & ") AND ((Compra.Tipo)='NF') AND ((Compra.TpEntrada)='ENTRADA' Or (Compra.TpEntrada)='ENT. CONSERTO' Or (Compra.TpEntrada)='ENT BRINDE')) GROUP BY Compra.NotaFiscal, ItensCompra.CFOPent ORDER BY Compra.NotaFiscal, ItensCompra.CFOPent;"
        Dim daQtdCfop As New OleDb.OleDbDataAdapter(Sql, Cnn)
        daQtdCfop.Fill(ds, "QtdCFOP")

        Dim NF As String = String.Empty
        Dim NFtemp As String = String.Empty
        Dim CFOP As String = String.Empty
        Dim CFOPTemp As String = String.Empty
        Dim It As Integer = 0

        'adiciona o item do desmembramento
        Dim Dv As DataView 'Cria o dataview para filtragem de dados e verificar se tem mais de um cfop

        Dim L As Integer = 0
        For L = 0 To ds.Tables("TB").Rows.Count - 1
            NFtemp = ds.Tables("TB").Rows(L)("NotaFiscal")

            If NF = NFtemp Then
                CFOPTemp = ds.Tables("TB").Rows(L)("CFOPent")
                If CFOP = CFOPTemp Then
                    ds.Tables("TB").Rows(L).BeginEdit()
                    ds.Tables("TB").Rows(L)("ItemDesdobramento") = It
                    ds.Tables("TB").Rows(L).EndEdit()
                    NF = ds.Tables("TB").Rows(L)("NotaFiscal")
                    CFOP = ds.Tables("TB").Rows(L)("CFOPent")
                Else
                    It += 1
                    ds.Tables("TB").Rows(L).BeginEdit()
                    ds.Tables("TB").Rows(L)("ItemDesdobramento") = It
                    ds.Tables("TB").Rows(L).EndEdit()
                    NF = ds.Tables("TB").Rows(L)("NotaFiscal")
                    CFOP = ds.Tables("TB").Rows(L)("CFOPent")
                End If
            Else

                Dv = New DataView(ds.Tables("QtdCFOP"), "NotaFiscal = '" & NFtemp & "'", "NotaFiscal ASC", DataViewRowState.OriginalRows)

                If Dv.Count = 1 Then
                    It = 0
                ElseIf Dv.Count > 1 Then
                    It = 1
                End If

                CFOPTemp = ds.Tables("TB").Rows(L)("CFOPent") & ""

                ds.Tables("TB").Rows(L).BeginEdit()
                ds.Tables("TB").Rows(L)("ItemDesdobramento") = It
                ds.Tables("TB").Rows(L).EndEdit()
                NF = ds.Tables("TB").Rows(L)("NotaFiscal")
                CFOP = ds.Tables("TB").Rows(L)("CFOPent") & ""
            End If

        Next L
        'Fim

        'Criar Cabe�alho para os desdobramentos

        Sql = "SELECT Compra.CFOP, Compra.ChaveNFe, Compra.EspecieDocumento, Fornecedor.C�digoFornecedor, Fornecedor.CgcCpf, Fornecedor.Incri��oEstadual, Fornecedor.Estado, '' AS ItemDesdobramento, Compra.NotaFiscal, Compra.Modelo, Compra.Serie, Compra.Subserie, Compra.DataCompra, Compra.DataEntrada, Compra.DataLan�amento, Compra.ValorDesconto, Compra.TotalProdutos, Compra.ValorIssqnRetido, Compra.ValorCompra, Compra.Icms, Compra.BaseCalcIcms, Compra.ValorIcms, Compra.IsentoIcms, Compra.ValorOutrosIcms, Compra.BaseCalcIpi, Compra.Ipi, Compra.ValorIpi, Compra.ValorOutrosIpi, Compra.IsentoIpi, Compra.Confirmado, Compra.Inativo, Compra.Empresa, Compra.Tipo, Compra.FormaPagamento, Compra.Obs, Compra.ValorFrete, Compra.LancaItens, Compra.TpEntrada FROM Compra INNER JOIN Fornecedor ON Compra.CodigoFornecedor = Fornecedor.C�digoFornecedor WHERE (((Compra.TpEntrada)='Vazio'));"

        Dim daExportCab As New OleDb.OleDbDataAdapter(Sql, Cnn)
        daExportCab.Fill(ds, "TBCAB")

        For Each row As DataRow In ds.Tables("TB").Rows
            Dim DrNF() As DataRow
            DrNF = ds.Tables("TBCAB").Select("NotaFiscal = '" & row("NotaFiscal").ToString & "' and ItemDesdobramento = '" & row("ItemDesdobramento").ToString & "'")

            Dim VlrItemAgregados As Double
            If DrNF.Length = 0 Then

                VlrItemAgregados = CDbl(NzZero(row("ItensCompra.ValorIcmsST"))) + CDbl(NzZero(row("ValorFreteProduto"))) + CDbl(NzZero(row("vSeg"))) + CDbl(NzZero(row("vOutro"))) + CDbl(NzZero(row("ItensCompra.ValorIpi")))

                Dim DRnovo As DataRow
                DRnovo = ds.Tables("TBCAB").NewRow()
                'DRnovo("CFOP") = row("ItensCompra.CFOP") corre��o referente cfop de entrada
                DRnovo("CFOP") = row("CFOPENT")
                DRnovo("C�digoFornecedor") = row("CodigoFornecedor")
                DRnovo("CgcCpf") = row("CgcCpf")
                DRnovo("Incri��oEstadual") = row("Incri��oEstadual")
                DRnovo("Estado") = row("Estado")
                DRnovo("ItemDesdobramento") = row("ItemDesdobramento")
                DRnovo("NotaFiscal") = row("NotaFiscal")
                DRnovo("ChaveNFe") = row("ChaveNFe")
                DRnovo("EspecieDocumento") = row("EspecieDocumento")
                DRnovo("Modelo") = row("Modelo")
                DRnovo("Serie") = row("Compra.Serie")
                DRnovo("SubSerie") = row("Compra.SubSerie")
                DRnovo("DataCompra") = row("DataCompra")
                DRnovo("DataEntrada") = row("DataEntrada")
                DRnovo("DataLan�amento") = row("DataLan�amento")
                DRnovo("ValorDesconto") = row("ItensCompra.ValorDesconto")
                DRnovo("TotalProdutos") = row("TotalProduto")
                DRnovo("ValorCompra") = row("TotalProduto") + VlrItemAgregados
                DRnovo("Icms") = row("IcmsProduto")
                If row("IcmsProduto") > 0 Then DRnovo("BaseCalcIcms") = row("ItBaseCalcIcms") + VlrItemAgregados 'row("TotalProduto") + VlrItemAgregados
                DRnovo("ValorIcms") = row("ValorIcmsProduto")
                DRnovo("IsentoIcms") = row("ItensCompra.IsentoIcms")
                DRnovo("ValorOutrosIcms") = row("ItensCompra.ValorOutrosIcms")

                If row("ItensCompra.Ipi") > 0 Then DRnovo("BaseCalcIpi") = row("TotalProduto") Else DRnovo("BaseCalcIpi") = 0
                DRnovo("ValorIpi") = row("ItensCompra.ValorIpi")
                DRnovo("ValorOutrosIpi") = row("ItensCompra.ValorOutrosIpi")
                DRnovo("IsentoIpi") = row("ItensCompra.IsentoIpi")
                DRnovo("FormaPagamento") = row("FormaPagamento")

                ds.Tables("TBCAB").Rows.Add(DRnovo)

            Else

                DrNF(0).BeginEdit()

                VlrItemAgregados = CDbl(NzZero(row("ItensCompra.ValorIcmsST"))) + CDbl(NzZero(row("ValorFreteProduto"))) + CDbl(NzZero(row("vSeg"))) + CDbl(NzZero(row("vOutro"))) + CDbl(NzZero(row("ItensCompra.ValorIpi")))

                DrNF(0)("ValorDesconto") += row("ItensCompra.ValorDesconto")
                DrNF(0)("TotalProdutos") += row("TotalProduto")
                DrNF(0)("ValorCompra") += row("TotalProduto") + VlrItemAgregados

                If row("IcmsProduto") > 0 Then DrNF(0)("BaseCalcIcms") = NzZero(DrNF(0)("BaseCalcIcms")) + NzZero(row("ItBaseCalcIcms")) + NzZero(VlrItemAgregados) ' CDbl(NzZero(DrNF(0)("BaseCalcIcms"))) + CDbl(NzZero(row("TotalProduto"))) + VlrItemAgregados
                DrNF(0)("ValorIcms") += row("ValorIcmsProduto")
                DrNF(0)("IsentoIcms") += row("ItensCompra.IsentoIcms")
                DrNF(0)("ValorOutrosIcms") += row("ItensCompra.ValorOutrosIcms")

                If row("ItensCompra.Ipi") > 0 Then DrNF(0)("BaseCalcIpi") += row("TotalProduto") Else DrNF(0)("BaseCalcIpi") += 0
                DrNF(0)("ValorIpi") += row("ItensCompra.ValorIpi")
                DrNF(0)("ValorOutrosIpi") += NzZero(row("ItensCompra.ValorOutrosIpi"))
                DrNF(0)("IsentoIpi") += row("ItensCompra.IsentoIpi")

                DrNF(0).EndEdit()

            End If

        Next

        Dim Linha As String = ""
        'FileOpen(1, Me.Local.Text & "\ENTRADA." & Me.EmpProSoft.Text, OpenMode.Append)
        FileOpen(1, Me.Local.Text & "\ENTRADA." & Me.EmpProSoft.Text, OpenMode.Output)
        For Each row As DataRow In ds.Tables("TBCAB").Rows

            Try
                Linha = Linha & RChr(" ", 4, " ", "D", False) 'cp 1
                Linha = Linha & RChr(row("CgcCpf"), 14, 0, "E", True) 'cp 2
                Linha = Linha & RChr(Format(CDate(row("DataLan�amento")), "dd/MM/yy"), 6, 0, "E", True) 'cp 3 = data entrada
                Linha = Linha & RChr(Format(CDate(row("DataCompra")), "dd/MM/yy"), 6, 0, "E", True)  'cp 4
                Linha = Linha & RChr(row("NotaFiscal"), 6, 0, "E", False) 'cp 5
                Linha = Linha & RChr(" ", 3, " ", "D", True)  'cp 6
                Linha = Linha & RChr("   ", 3, " ", "D", False) 'cp 7
                Linha = Linha & RChr(row("ItemDesdobramento"), 1, " ", "D", False) 'cp 8
                Linha = Linha & SChr("00000", 5, 0, "E", True) 'cp 9
                Linha = Linha & SChr("000", 3, 0, "E", True) 'cp 10

                Dim VlrLiquido As Double = NzZero(row("Valorcompra")) - NzZero(row("ValorDesconto"))
                'Alterado para linh abaixo dia 08/11/2014 a pedido Eliane/Fernando - Linha = Linha & SChr(FormatNumber(Nz(row("Valorcompra"), 3), 2), 14, 0, "E", True) 'cp 11
                Linha = Linha & SChr(FormatNumber(Nz(VlrLiquido, 3), 2), 14, 0, "E", True) 'cp 11

                Linha = Linha & SChr(FormatNumber(Nz(row("BaseCalcIcms"), 3), 2), 14, 0, "E", True) 'cp 12
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorIcms"), 3), 2), 14, 0, "E", True)  'cp 13
                Linha = Linha & SChr(FormatNumber(Nz(row("IsentoIcms"), 3), 2), 14, 0, "E", True)  'cp 14
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorOutrosIcms"), 3), 2), 14, 0, "E", True) 'cp 15
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 16
                Linha = Linha & SChr(FormatNumber(Nz(row("Icms"), 3), 2), 5, 0, "E", True)  'cp 17
                Linha = Linha & SChr(FormatNumber(Nz(row("BaseCalcIpi"), 3), 2), 14, 0, "E", True) 'cp 18
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorIpi"), 3), 2), 14, 0, "E", True) 'cp 19
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)  'cp 20
                Linha = Linha & SChr(FormatNumber(Nz(row("IsentoIpi"), 3), 2), 14, 0, "E", True) 'cp 21
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorOutrosIpi"), 3), 2), 14, 0, "E", True) 'cp 22

                'Alterado para linh abaixo dia 08/11/2014 a pedido Eliane/Fernando - Linha = Linha & SChr(FormatNumber(Nz(VlrLiquido, 3), 2), 14, 0, "E", True) 'cp 23
                Linha = Linha & SChr(FormatNumber(Nz(row("Valorcompra"), 3), 2), 14, 0, "E", True) 'cp 23

                Linha = Linha & RChr(row("FormaPagamento"), 1, 0, "E", False) 'cp 24
                Linha = Linha & SChr(row("FormaPagamento"), 2, 0, "E", True)  'cp 25

                Linha = Linha & SChr("0", 3, 0, "E", True) 'cp 26
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 27
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 28
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 29
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 30
                Linha = Linha & RChr(" ", 100, " ", "D", False) 'cp 31
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 32
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 33
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 34
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 35
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 36
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 37
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 38
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 39
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 40
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 41
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 42
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 43
                Linha = Linha & RChr(row("Incri��oEstadual"), 18, " ", "D", False)  'cp 44
                Linha = Linha & RChr(row("Estado"), 2, " ", "D", False)  'cp 45
                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 46
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 47
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 48
                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 49
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 50
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 51
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 52
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 53
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 54
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 55
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 56
                Linha = Linha & RChr(" ", 3, " ", "D", False) 'cp 57
                Linha = Linha & RChr(" ", 4, " ", "D", False) 'cp 58
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 59
                Linha = Linha & RChr(row("Cfop"), 4, " ", "D", True)   'cp 60
                Linha = Linha & RChr(" ", 10, " ", "D", False) 'cp 61
                Linha = Linha & RChr(" ", 14, " ", "D", False) 'cp 62
                Linha = Linha & RChr(" ", 18, " ", "D", False) 'cp 63
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 64
                Linha = Linha & RChr(" ", 14, " ", "D", False) 'cp 65
                Linha = Linha & RChr(" ", 18, " ", "D", False) 'cp 66
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 67
                Linha = Linha & RChr(" ", 14, " ", "D", False) 'cp 68
                Linha = Linha & RChr(" ", 18, " ", "D", False) 'cp 69
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 70
                Linha = Linha & RChr(" ", 1, " ", "D", False) 'cp 71
                Linha = Linha & RChr(" ", 7, " ", "D", False) 'cp 72
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 73
                Linha = Linha & RChr(" ", 7, " ", "D", False) 'cp 74
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 75
                Linha = Linha & RChr(" ", 7, " ", "D", False) 'cp 76
                Linha = Linha & RChr(" ", 2, " ", "D", False)  'cp 77

                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 78
                Linha = Linha & RChr(Nz(0, 3), 4, "0", "E", False)  'cp 79
                Linha = Linha & RChr(" ", 2, " ", "D", False)  'cp 80
                Linha = Linha & RChr("0", 14, " ", "D", False) 'cp 81
                Linha = Linha & RChr("0", 14, " ", "D", False)  'cp 82

                Linha = Linha & RChr(" ", 6, " ", "D", False)  'cp 83
                Linha = Linha & RChr("0", 1, "", "D", False)  'cp 84
                Linha = Linha & RChr(" ", 6, " ", "D", False)  'cp 85
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 86
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 87
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 88
                Linha = Linha & RChr(row("EspecieDocumento"), 5, " ", "D", False)  'cp 89
                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 90
                Linha = Linha & RChr(row("Serie"), 3, " ", "D", False)  '864
                Linha = Linha & RChr(row("SubSerie"), 2, " ", "D", False)  '867
                Linha = Linha & RChr(" ", 104, " ", "D", False)  'Brancos
                Linha = Linha & RChr(row("ChaveNFe"), 44, " ", "D", False)  '973
                Linha = Linha & RChr(" ", 109, " ", "D", False)  'Branco
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorDesconto")), 2), 14, "0", "E", True)  '1126

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.ToString)
            End Try
        Next

        'Notas sem Itens.....O arquivo de texto continua aberto para adi��o

        Sql = "SELECT Compra.*, Fornecedor.* FROM (Compra LEFT JOIN ItensCompra ON Compra.CompraInterno = ItensCompra.CompraInterno) INNER JOIN Fornecedor ON Compra.CodigoFornecedor = Fornecedor.C�digoFornecedor WHERE (((ItensCompra.CompraInterno) Is Null) AND ((Compra.DataLan�amento) Between #" & Format(CDate(Me.DataInicial.Text), "MM/dd/yyyy") & "# And #" & Format(CDate(Me.DataFinal.Text), "MM/dd/yyyy") & "#) AND ((Compra.Confirmado)=True) AND ((Compra.Inativo)=False) AND ((Compra.Empresa)=" & CodEmpresa & ") AND ((Compra.Tipo)='NF') AND ((Compra.TpEntrada)='ENTRADA'));"
        Dim daNF1 As New OleDb.OleDbDataAdapter(Sql, Cnn)
        daNF1.Fill(ds, "NF1")

        For Each row As DataRow In ds.Tables("NF1").Rows
            Try

                Linha = Linha & RChr(" ", 4, " ", "D", False) 'cp 1
                Linha = Linha & RChr(row("CgcCpf"), 14, 0, "E", True) 'cp 2
                Linha = Linha & RChr(Format(CDate(row("DataLan�amento")), "dd/MM/yy"), 6, 0, "E", True) 'cp 3 = data entrada
                Linha = Linha & RChr(Format(CDate(row("DataCompra")), "dd/MM/yy"), 6, 0, "E", True)  'cp 4
                Linha = Linha & RChr(row("NotaFiscal"), 6, 0, "E", False) 'cp 5
                Linha = Linha & RChr(" ", 3, " ", "D", True)  'cp 6
                Linha = Linha & RChr("   ", 3, " ", "D", False) 'cp 7
                Linha = Linha & RChr("0", 1, " ", "D", False) 'cp 8
                Linha = Linha & SChr("00000", 5, 0, "E", True) 'cp 9
                Linha = Linha & SChr("000", 3, 0, "E", True) 'cp 10
                Linha = Linha & SChr(FormatNumber(Nz(row("TotalProdutos"), 3), 2), 14, 0, "E", True) 'cp 11
                Linha = Linha & SChr(FormatNumber(Nz(row("BaseCalcIcms"), 3), 2), 14, 0, "E", True) 'cp 12
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorIcms"), 3), 2), 14, 0, "E", True)  'cp 13
                Linha = Linha & SChr(FormatNumber(Nz(row("IsentoIcms"), 3), 2), 14, 0, "E", True)  'cp 14
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorOutrosIcms"), 3), 2), 14, 0, "E", True) 'cp 15
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 16
                Linha = Linha & SChr(FormatNumber(Nz(row("Icms"), 3), 2), 5, 0, "E", True)  'cp 17
                Linha = Linha & SChr(FormatNumber(Nz(row("BaseCalcIpi"), 3), 2), 14, 0, "E", True) 'cp 18
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorIpi"), 3), 2), 14, 0, "E", True) 'cp 19
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True)  'cp 20
                Linha = Linha & SChr(FormatNumber(Nz(row("IsentoIpi"), 3), 2), 14, 0, "E", True) 'cp 21
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorOutrosIpi"), 3), 2), 14, 0, "E", True) 'cp 22
                Linha = Linha & SChr(FormatNumber(Nz(row("ValorCompra"), 3), 2), 14, 0, "E", True) 'cp 23

                Linha = Linha & RChr(row("FormaPagamento"), 1, 0, "E", False) 'cp 24
                Linha = Linha & SChr(row("FormaPagamento"), 2, 0, "E", True)  'cp 25

                Linha = Linha & SChr("0", 3, 0, "E", True) 'cp 26
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 27
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 28
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 29
                Linha = Linha & SChr(FormatNumber("0.00", 2), 12, 0, "E", True) 'cp 30
                Linha = Linha & RChr(" ", 100, " ", "D", False) 'cp 31
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 32
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 33
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 34
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 35
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 36
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 37
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 38
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 39
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 40
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 41
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 42
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 43
                Linha = Linha & RChr(row("Incri��oEstadual"), 18, " ", "D", False)  'cp 44
                Linha = Linha & RChr(row("Estado"), 2, " ", "D", False)  'cp 45
                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 46
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 47
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 48
                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 49
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 50
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 51
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 52
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 53
                Linha = Linha & RChr(" ", 5, 0, "E", False) 'cp 54
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 55
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 56
                Linha = Linha & RChr(" ", 3, " ", "D", False) 'cp 57
                Linha = Linha & RChr(" ", 4, " ", "D", False) 'cp 58
                Linha = Linha & RChr(" ", 6, " ", "D", False) 'cp 59
                Linha = Linha & RChr(row("Cfop"), 4, " ", "D", True)   'cp 60
                Linha = Linha & RChr(" ", 10, " ", "D", False) 'cp 61
                Linha = Linha & RChr(" ", 14, " ", "D", False) 'cp 62
                Linha = Linha & RChr(" ", 18, " ", "D", False) 'cp 63
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 64
                Linha = Linha & RChr(" ", 14, " ", "D", False) 'cp 65
                Linha = Linha & RChr(" ", 18, " ", "D", False) 'cp 66
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 67
                Linha = Linha & RChr(" ", 14, " ", "D", False) 'cp 68
                Linha = Linha & RChr(" ", 18, " ", "D", False) 'cp 69
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 70
                Linha = Linha & RChr(" ", 1, " ", "D", False) 'cp 71
                Linha = Linha & RChr(" ", 7, " ", "D", False) 'cp 72
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 73
                Linha = Linha & RChr(" ", 7, " ", "D", False) 'cp 74
                Linha = Linha & RChr(" ", 2, " ", "D", False) 'cp 75
                Linha = Linha & RChr(" ", 7, " ", "D", False) 'cp 76
                Linha = Linha & RChr(" ", 2, " ", "D", False)  'cp 77

                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 78
                Linha = Linha & RChr(Nz(0, 3), 4, "0", "E", False)  'cp 79
                Linha = Linha & RChr(" ", 2, " ", "D", False)  'cp 80
                Linha = Linha & RChr("0", 14, " ", "D", False) 'cp 81
                Linha = Linha & RChr("0", 14, " ", "D", False)  'cp 82

                Linha = Linha & RChr(" ", 6, " ", "D", False)  'cp 83
                Linha = Linha & RChr("0", 1, "", "D", False)  'cp 84
                Linha = Linha & RChr(" ", 6, " ", "D", False)  'cp 85
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 86
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 87
                Linha = Linha & SChr(FormatNumber("00.00", 2), 14, 0, "E", True) 'cp 88
                Linha = Linha & RChr(row("EspecieDocumento"), 5, " ", "D", False)  'cp 89
                Linha = Linha & RChr(" ", 1, " ", "D", False)  'cp 90
                Linha = Linha & RChr(row("Serie"), 3, " ", "D", False)  'cp 91
                Linha = Linha & RChr(row("SubSerie"), 2, " ", "D", False)  'cp 92
                Linha = Linha & RChr(" ", 104, " ", "D", False)  'Brancos
                Linha = Linha & RChr(row("ChaveNFe"), 44, " ", "D", False)  'Chave da NFe
                Linha = Linha & RChr(" ", 109, " ", "D", False)  'Branco
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorDesconto")), 2), 14, "0", "E", True)  '1126

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.ToString)
            End Try
        Next

        FileClose(1)

        'Come�a a exporta�ao dos itens

        Dim Agregados As Double
        Dim VlrDiv As Double

        Linha = ""
        'FileOpen(1, Me.Local.Text & "\ITEM_ENT." & Me.EmpProSoft.Text, OpenMode.Append)
        FileOpen(1, Me.Local.Text & "\ITEM_ENT." & Me.EmpProSoft.Text, OpenMode.Output)
        For Each row As DataRow In ds.Tables("TB").Rows
            Try
                'ValorIcmsST,ValorFreteProduto
                Agregados = CDbl(NzZero(row("ItensCompra.ValorIcmsST"))) + CDbl(NzZero(row("ValorFreteProduto"))) + CDbl(NzZero(row("vSeg"))) + CDbl(NzZero(row("vOutro"))) + NzZero(row("ItensCompra.ValorIpi"))
                VlrDiv = (Agregados / NzZero(row("Qtd")))

                Linha = Linha & RChr(row("CgcCpf"), 14, " ", "D", True) '1
                Linha = Linha & RChr(Format(CDate(row("DataLan�amento")), "yyyy/MM/dd"), 8, " ", "D", True)   '15 = dataentrada
                Linha = Linha & RChr(row("NotaFiscal"), 6, "0", "E", False) '23
                Linha = Linha & RChr("   ", 3, " ", "D", False) '29
                Linha = Linha & RChr(row("ItemDesdobramento"), 1, 0, "E", False) '32
                Linha = Linha & RChr(row("SeqNf"), 2, "0", "E", False) '33
                Linha = Linha & RChr(row("ItensCompra.CodigoProduto"), 20, " ", "D", False) '35
                Linha = Linha & RChr(row("CFOPent") & "", 4, " ", "D", True) '55
                Linha = Linha & RChr(row("UnidadeMedida"), 3, " ", "D", False) '59
                Linha = Linha & RChr(row("Produtos.Cst"), 3, "0", "E", False) '62
                Linha = Linha & SChr(FormatNumber(NzZero(row("Qtd")), 3), 14, 0, "E", True) '65
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorUnitario")) + VlrDiv, 4), 14, 0, "E", True) '79

                Dim T As Double = (NzZero(row("ValorUnitario")) + VlrDiv) * NzZero(row("Qtd")) - NzZero(row("ItensCompra.ValorDesconto")) 'Foi adicionado o desconto por causa do contador do fernando
                Linha = Linha & SChr(FormatNumber(NzZero(row("ItensCompra.ValorDesconto")), 2), 14, 0, "E", True) '93
                Linha = Linha & SChr(FormatNumber(NzZero(T), 2), 14, 0, "E", True)  '107
                Linha = Linha & SChr(FormatNumber(0, 2), 5, 0, "E", True)  '121 NzZero(row("ItensCompra.Ipi"))
                Linha = Linha & SChr(FormatNumber(0, 2), 14, 0, "E", True)  '126 NzZero(row("ItensCompra.ValorIpi"))

                If NzZero(row("IcmsProduto")) > 0 Then
                    Linha = Linha & SChr(FormatNumber(row("ItensCompra.BaseCalcIcms"), 2), 14, 0, "E", True)  '140
                Else
                    Linha = Linha & SChr("0", 14, 0, "E", True)  '140
                End If

                Linha = Linha & SChr(FormatNumber(0, 2), 14, 0, "E", True) '154

                Linha = Linha & RChr(row("Descri��o"), 80, " ", "D", False) '168
                Linha = Linha & RChr("0", 2, "0", "E", False) '248
                Linha = Linha & RChr(row("Produtos.CF"), 10, " ", "D", False) '250
                Linha = Linha & RChr(" ", 2, " ", "D", False) '260
                Linha = Linha & SChr(FormatNumber(0, 2), 5, 0, "E", True)  '262
                Linha = Linha & SChr(FormatNumber(0, 2), 5, 0, "E", True)  '267
                Linha = Linha & SChr(FormatNumber(0, 2), 14, 0, "E", True)  '272
                Linha = Linha & SChr(FormatNumber(Nz(row("Produtos.Ipi"), 3), 2), 5, 0, "E", True)  '286
                Linha = Linha & SChr("0", 2, 0, "E", True)  '291
                Linha = Linha & SChr(row("Produtos.Cst"), 3, 0, "E", True)  '293
                Linha = Linha & SChr(Mid(row("Descri��o"), 1, 30), 30, " ", "E", True)  '296
                Linha = Linha & SChr(" ", 3, " ", "E", True)  '326
                Linha = Linha & SChr("S", 1, " ", "E", True)  '329
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True)  '330

                Linha = Linha & SChr("O", 1, " ", "E", True)  '344
                Linha = Linha & SChr(FormatNumber(NzZero(row("IcmsProduto")), 2), 5, 0, "E", True)  '345
                Linha = Linha & SChr(FormatNumber(row("ValorIcmsProduto"), 2), 14, 0, "E", True)  '350
                Linha = Linha & SChr("O", 1, " ", "E", True)  '364
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  '365
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  '379
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  '393
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  '407
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  '421
                Linha = Linha & SChr(FormatNumber("0", 2), 14, 0, "E", True)  '435
                Linha = Linha & RChr("0", 3, "0", "E", False) '449
                Linha = Linha & RChr(" ", 2, " ", "E", False) '452
                Linha = Linha & RChr(" ", 2, " ", "E", False) '454
                Linha = Linha & RChr(" ", 96, " ", "D", False) '456
                Linha = Linha & RChr(" ", 10, " ", "E", False) '552
                Linha = Linha & RChr(" ", 8, " ", "E", False) '562
                Linha = Linha & RChr(" ", 1, " ", "E", False) '570
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) '571
                Linha = Linha & RChr(" ", 2, " ", "E", False) '585
                Linha = Linha & RChr("1", 1, " ", "E", False) '587
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) '588
                Linha = Linha & SChr(FormatNumber(row("ItensCompra.ValorOutrosIcms"), 2), 14, "0", "E", True) '602
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) '616
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) '630
                Linha = Linha & RChr("0000", 4, "0", "E", False) '644
                Linha = Linha & RChr(row("ItensCompra.Serie"), 3, " ", "D", False) '648
                Linha = Linha & RChr(row("ItensCompra.SubSerie"), 2, " ", "D", False) '651
                Linha = Linha & RChr("0", 10, "0", "E", False) '653
                Linha = Linha & SChr(FormatNumber(0, 2), 14, "0", "E", True) '663
                Linha = Linha & RChr(row("Incri��oEstadual"), 18, " ", "E", True) '677
                Linha = Linha & RChr(row("Estado"), 2, " ", "E", False) '695
                Linha = Linha & RChr(row("CSTIPIent"), 2, " ", "E", False) '697
                Linha = Linha & RChr(row("CSTPISent"), 2, " ", "E", False) '699
                Linha = Linha & RChr(row("CSTCOFINSent"), 2, " ", "E", False) '701

                Dim Brancos As String = RChr(" ", 575, " ", "D", False)
                Linha = Linha & Brancos

                Linha = Linha & SChr(FormatNumber(NzZero(row("vBCpis")), 2), 14, "0", "E", True) '1278
                Linha = Linha & SChr(FormatNumber(NzZero(row("PisProduto")), 4), 8, "0", "E", True) '1292
                Linha = Linha & SChr(FormatNumber(NzZero(row("CofinsProduto")), 4), 8, "0", "E", True) '1300
                Linha = Linha & RChr(" ", 30, " ", "E", False)
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorPisProduto")), 2), 14, "0", "E", True) '1338
                Linha = Linha & SChr(FormatNumber(NzZero(row("ValorCofinsProduto")), 2), 14, "0", "E", True) '1352
                Linha = Linha & RChr(" ", 48, " ", "E", False)

                Linha = Linha & RChr(row("CTB"), 12, " ", "E", False) '1414
                Linha = Linha & RChr(row("cstPISentr"), 2, " ", "E", False) '1426
                Linha = Linha & RChr(row("cstCOFINSentr"), 2, " ", "E", False) '1428

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.Message)
            End Try
        Next
        FileClose(1)

        MsgBox("Exporta��o Concluida", 64, "Valida��o de Dados")

        daExport.Dispose()
        Cnn.Close()

    End Sub

    Public Function SChr(ByVal Vlr As Object, ByVal Tamanho As Integer, ByVal StrInserir As String, ByVal DE As String, ByVal ReplaceCh As Boolean)
        Dim StrCerta As String
        Dim StrTemp As String

        Dim L As Integer  'Variavel definida para o loop do for

        If IsDBNull(Vlr) Then
            Vlr = ""
        End If
        StrTemp = Vlr

        If ReplaceCh = True Then
            StrTemp = StrTemp.Replace(".", "")
            StrTemp = StrTemp.Replace(",", ".")
        End If

        StrCerta = Mid(StrTemp, 1, Tamanho)

        If Len(StrCerta) < Tamanho Then
            For L = 1 To (Tamanho - (Len(StrCerta)))
                If DE = "D" Then
                    StrCerta = StrCerta.Insert(Len(StrCerta), StrInserir)
                Else
                    StrCerta = StrCerta.Insert(0, StrInserir)
                End If
            Next
        End If
        Return UCase(StrCerta)
    End Function

    Public Function RChr(ByVal Vlr As Object, ByVal Tamanho As Integer, ByVal StrInserir As String, ByVal DE As String, ByVal RetiraCh As Boolean)
        Dim StrCerta As String
        Dim StrTemp As String

        Dim L As Integer  'Variavel definida para o loop do for

        If IsDBNull(Vlr) Then
            Vlr = ""
        End If

        StrTemp = Vlr

        If RetiraCh = True Then
            StrTemp = StrTemp.Replace("-", "")
            StrTemp = StrTemp.Replace("x", "")
            StrTemp = StrTemp.Replace(".", "")
            StrTemp = StrTemp.Replace("/", "")
        End If

        StrCerta = Mid(StrTemp, 1, Tamanho)

        If Len(StrCerta) < Tamanho Then
            For L = 1 To (Tamanho - (Len(StrCerta)))
                If DE = "D" Then
                    StrCerta = StrCerta.Insert(Len(StrCerta), StrInserir)
                Else
                    StrCerta = StrCerta.Insert(0, StrInserir)
                End If
            Next
        End If
        Return UCase(StrCerta)
    End Function

    Private Sub A1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A1.CheckedChanged, A2.CheckedChanged, A3.CheckedChanged
        Me.Local.Focus()
    End Sub

    Private Sub EmpUP_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpUP.Enter
        If Me.EmpUP.Text = "" Then Me.EmpUP.Text = CodEmpresa
    End Sub

    Private Sub ProSoftExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AnoInventario_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AnoInventario.Validating
        If A4.Checked = True Then
            If Me.AnoInventario.Text <> "" Then
                Me.DataInicial.Text = "01/01/" & Me.AnoInventario.Text
                Me.DataFinal.Text = "31/12/" & Me.AnoInventario.Text
            End If
        End If
    End Sub

    Private Sub A5_CheckedChanged(sender As Object, e As EventArgs) Handles A5.CheckedChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        'iventario
        If Me.A4.Checked = True Then
            If Me.Local.Text = "" Then
                MsgBox("Favor informar o drive e local a ser gravado o arquivo.", 64, "Exporta��o")
                Me.Local.Focus()
                Exit Sub
            ElseIf Me.EmpUP.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no FOCUS.", 64, "Exporta��o")
                Me.EmpUP.Focus()
                Exit Sub
            ElseIf Me.EmpProSoft.Text = "" Then
                MsgBox("Favor informar o C�digo da empresa no ProSoft.", 64, "Exporta��o")
                Me.EmpProSoft.Focus()
                Exit Sub
            ElseIf Me.DataInicial.Text = "" Then
                MsgBox("Favor informar a data inicial.", 64, "Exporta��o")
                Me.DataInicial.Focus()
                Exit Sub
            ElseIf Me.DataFinal.Text = "" Then
                MsgBox("Favor informar a Data Final.", 64, "Exporta��o")
                Me.DataFinal.Focus()
                Exit Sub
            ElseIf Me.AnoInventario.Text = "" Then
                MsgBox("Favor informar o Ano.", 64, "Exporta��o")
                Me.AnoInventario.Focus()
                Exit Sub
            End If
            ExportaInventarioAgrupado()
        End If
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader

        Cnn.Open()

        With Cmd
            .Connection = Cnn
            .CommandText = "SELECT Iventario.CodigoProduto, Sum(Iventario.Qtde) AS SomaDeQtde, Produtos.ValorCompra, Sum([ValorCompra]*[QTDE]) AS ValorTotal, Produtos.Descri��o, Produtos.C�digoGrupo, Produtos.CF, Produtos.UnidadeMedida, Grupos.Descri��o AS DescGrupo FROM (Iventario INNER JOIN Produtos ON Iventario.CodigoProduto = Produtos.CodigoProduto) INNER JOIN Grupos ON Produtos.C�digoGrupo = Grupos.C�digoGrupo GROUP BY Iventario.CodigoProduto, Produtos.ValorCompra, Produtos.Descri��o, Produtos.C�digoGrupo, Produtos.CF, Produtos.UnidadeMedida, Grupos.Descri��o;"
            .CommandType = CommandType.Text
        End With

        DataReader = Cmd.ExecuteReader

        Dim Linha As String = ""
        FileOpen(1, Me.Local.Text & "\INVENTARIO." & Me.EmpProSoft.Text, OpenMode.Output, OpenAccess.Write)

        While DataReader.Read
            Try
                Linha = Linha & RChr(Me.DataFinal.Text, 8, "", "E", True) '1
                Linha = Linha & RChr(CDate(Me.DataInicial.Text).Month & Mid(CDate(Me.DataInicial.Text).Year, 3), 4, 0, "E", True) '9
                Linha = Linha & RChr(CDate(Me.DataFinal.Text).Month & Mid(CDate(Me.DataFinal.Text).Year, 3), 4, 0, "E", True) '13
                Linha = Linha & RChr(DataReader.Item("CodigoProduto"), 20, " ", "D", False) '17
                Linha = Linha & RChr("1", 1, "", "D", False) '37
                Linha = Linha & RChr("00000000000000", 14, "", "D", False) '38
                Linha = Linha & RChr("", 20, " ", "D", False) '52
                Linha = Linha & RChr("", 2, " ", "D", False) '72
                Linha = Linha & RChr("", 5, " ", "D", False) '74
                Linha = Linha & SChr(FormatNumber(NzZero(DataReader.Item("SomaDeQtde")), 6), 16, "0", "E", True) '79
                Linha = Linha & SChr(FormatNumber(NzZero(DataReader.Item("ValorCompra")), 4), 17, "0", "E", True) '95
                Linha = Linha & SChr(FormatNumber(NzZero(DataReader.Item("ValorTotal")), 2), 17, "0", "E", True) '112
                Linha = Linha & SChr(FormatNumber(NzZero(0), 2), 17, "0", "E", True) '129
                Linha = Linha & RChr("", 60, " ", "D", False) '146
                Linha = Linha & RChr(DataReader.Item("Descri��o"), 80, " ", "D", False) '206
                Linha = Linha & RChr(DataReader.Item("C�digoGrupo"), 4, " ", "D", False) '286
                Linha = Linha & RChr(DataReader.Item("CF"), 10, " ", "D", False) '290
                Linha = Linha & RChr("", 30, " ", "D", False) '300
                Linha = Linha & RChr(DataReader.Item("UnidadeMedida"), 3, " ", "D", False) '330
                Linha = Linha & RChr(DataReader.Item("DescGrupo"), 30, " ", "D", False) '333

                PrintLine(1, Linha)
                Linha = ""
            Catch XP As System.Exception
                MsgBox(XP.ToString)
                MsgBox("Verique o Cliente : " & DataReader.Item("Nome"))
            End Try
            MyBarra.PerformStep()
        End While
        FileClose(1)
        MsgBox("Arquivo gerado")

        Dim cmdExclui As New OleDb.OleDbCommand("Delete * from Iventario", Cnn)
        cmdExclui.ExecuteNonQuery()
        cmdExclui.Dispose()


        DataReader.Close()
        Cnn.Close()
    End Sub
End Class