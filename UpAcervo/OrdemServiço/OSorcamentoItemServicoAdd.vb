Public Class OSorcamentoItemServicoAdd
    Public xValorAntigo As String
    Public xServicoAntigo As String
    Dim xFunc As String
    Dim Status As String
    Public IdLinha As Integer
    Dim vValorSAntigo As Double = 0

    Public OperationItens As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2
    Dim Desc As Double = 0
    Private Sub btnFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFechar.Click
        If Status = "INSERT" Then
            My.Forms.PedidoOS.atGridServico()
        End If

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If Me.CodFuncionario.Text = "" Or Me.CodFuncionario.Text = String.Empty Then
            MsgBox("O funcion�rio n�o foi selecionado", 48, "Aten��o")

            Exit Sub
        Else
            OsFindServico.ShowDialog()
            Me.Qtd.Focus()
        End If


    End Sub

    Private Sub CodigoServico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CodigoServico.KeyDown
        If e.KeyCode = Keys.F5 Then
            OsFindServico.ShowDialog()
            Me.Qtd.Focus()
        End If
    End Sub



    Private Sub btProdutoFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btProdutoFind.Click
        OsFindFuncionario.ShowDialog()
        Me.CodigoServico.Focus()
    End Sub

    Private Sub CodFuncionario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CodFuncionario.KeyDown
        If e.KeyCode = Keys.F5 Then
            OsFindFuncionario.ShowDialog()
            Me.CodigoServico.Focus()
        End If
    End Sub

    Private Sub CodFuncionario_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodFuncionario.Leave
        'Dim v As String = Me.CodFuncionario.Text


        If String.CompareOrdinal(CodFuncionario.Text, xValorAntigo) = 0 Then
            'C�digo Igual n�o faz consulta
            If Me.CodFuncionario.Text = "" Then
                Me.NomeFuncionario.Clear()
                Me.CodigoServico.Clear()
                Me.NomeServico.Clear()
            End If
            Exit Sub
        Else
            'Codigo Diferente Refaz a consulta
            achaFunc(Me.CodFuncionario.Text, "F")

            Me.NomeServico.Clear()
            Me.CodigoServico.Clear()
        End If
    End Sub
    Sub achaFunc(ByVal xid As Integer, ByVal sTipo As String)
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

        Dim dr As OleDb.OleDbDataReader
        Try
            CNN.Open()

            Dim cmd As New OleDb.OleDbCommand
            With cmd
                Select Case sTipo
                    Case "F"
                        .CommandText = "SELECT Funcion�rios.C�digoFuncion�rio, Funcion�rios.Nome FROM FuncionarioServico INNER JOIN Funcion�rios ON FuncionarioServico.fs_codigoFuncionario = Funcion�rios.C�digoFuncion�rio WHERE Funcion�rios.C�digoFuncion�rio = " & xid
                    Case "S"
                        .CommandText = "SELECT Servicos.Serv_Codigo, Servicos.Serv_Descricao, Servicos.Serv_ValorServico, Servicos.Serv_DescontoMaximo FROM Servicos INNER JOIN FuncionarioServicoDetalhe ON Servicos.Serv_Codigo=FuncionarioServicoDetalhe.Sv_CodigoServico WHERE FuncionarioServicoDetalhe.Sv_CodigoFuncionario=" & Me.CodFuncionario.Text & " AND Servicos.Serv_Codigo=" & xid
                End Select

                .CommandType = CommandType.Text
                .Connection = CNN
                .ExecuteNonQuery()

                dr = .ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    Select Case sTipo
                        Case "F"
                            Me.NomeFuncionario.Text = dr.Item(1)
                        Case "S"

                            Me.NomeServico.Text = dr.Item(1)
                            Me.ValorUnitario.Text = dr.Item(2)
                            Desc = NzZero(dr.Item(3))
                            vValorSAntigo = Me.ValorUnitario.Text
                    End Select
                Else
                    MsgBox("Registro n�o encontrado", 48, "Aten��o")
                    If sTipo = "S" Then
                        Me.CodigoServico.Clear()
                        Me.NomeServico.Clear()
                        Me.CodigoServico.Focus()
                    Else
                        Me.CodFuncionario.Clear()
                        Me.NomeFuncionario.Clear()
                        Me.CodFuncionario.Focus()
                    End If
                End If

            End With
        Catch ex As Exception
            Throw ex
        Finally
            CNN.Close()
        End Try
    End Sub

    Private Sub CodFuncionario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodFuncionario.LostFocus

    End Sub
    Private Sub CodFuncionario_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CodFuncionario.Validating
        xValorAntigo = Me.CodFuncionario.Text
        If Me.CodFuncionario.Text = "" Then
            Me.NomeServico.Clear()
            Me.NomeFuncionario.Clear()
            Me.CodigoServico.Clear()
            Me.ValorUnitario.Clear()
            Me.Total.Clear()
        End If

    End Sub

    Private Sub CodigoServico_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodigoServico.Leave
        'Dim v As String = Me.CodFuncionario.Text
        If String.CompareOrdinal(CodigoServico.Text, NzZero(xServicoAntigo)) = 0 Then
            'C�digo Igual n�o faz consulta
            If Me.CodigoServico.Text = "" Then
                Me.NomeServico.Clear()
                Me.ValorUnitario.Clear()
            Else
                'Codigo Diferente Refaz a consulta
                achaFunc(Me.CodigoServico.Text, "S")
            End If

        Else
            'Codigo Diferente Refaz a consulta
            achaFunc(Me.CodigoServico.Text, "S")
        End If
    End Sub

    Private Sub CodigoServico_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CodigoServico.Validating
        xServicoAntigo = Me.CodigoServico.Text
        If Me.CodigoServico.Text = "" Then
            Me.NomeServico.Clear()
            Me.ValorUnitario.Clear()
            Me.Total.Clear()

        End If
    End Sub
    Private Sub ValorUnitario_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ValorUnitario.Validating
        If IsNumeric(Me.ValorUnitario.Text) Then
            If CDbl(Me.ValorUnitario.Text) < vValorSAntigo Then
                MsgBox("O valor unit�rio n�o pode ser menor que o valor do cadastro", 48, "Aten��o")
                Me.ValorUnitario.Text = vValorSAntigo
                Me.ValorUnitario.Focus()
                Exit Sub
            Else
                Me.Total.Text = FormatCurrency(NzZero(Me.ValorUnitario.Text) * NzZero(Me.Qtd.Text), 2)
            End If

        End If

    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click

        If Me.CodFuncionario.Text = "" Then
            MsgBox("N�o foi selecionado o funcion�rio", 48, "Aten��o")
            Exit Sub
        ElseIf Me.CodigoServico.Text = "" Then
            MsgBox("N�o foi selecionado o servi�o", 48, "Aten��o")
            Exit Sub
        ElseIf Me.Qtd.Text = "" Or Me.Qtd.Text = 0 Then
            MsgBox("A quantidade do servi�o foi selecionado", 48, "Aten��o")
            Exit Sub
        End If

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        If OperationItens = INS Then

            CNN.Open()

            Dim Sql As String = "INSERT INTO OrcamentoItemServico (CodigoOrcamento,CodigoServico,Funcionario,Qtd,ValorUnitario,Desconto,ValorDesconto,TotalServico,Comissao,ValorComissao) VALUES (?,?,?,?,?,?,?,?,?,?)"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)
            cmd.Parameters.Add(New OleDb.OleDbParameter("CodigoOrcamento", My.Forms.OSor�amento.CodOr�amento.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("CodigoServico", Me.CodigoServico.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("Funcionario", Me.CodFuncionario.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("Qtd", Me.Qtd.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("ValorUnitario", NzZero(Me.ValorUnitario.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("Desconto", NzZero(txtDesconto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("ValorDesconto", NzZero(Me.ValorDesconto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("TotalServico", Me.Total.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("Comissao", 0))
            cmd.Parameters.Add(New OleDb.OleDbParameter("ValorComissao", 0))

            Try
                cmd.ExecuteNonQuery()

                MsgBox("Registro adicionado com sucesso", 64, "Valida��o de Dados")

                ErroLivre = "Adicionou um Servi�o no Or�amento"
                GerarLog(Me.Text, A��oTP.Livre, Me.CodigoServico.Text)


            Catch ex As Exception
                MsgBox(ex.Message, 64, "Valida��o de Dados")
            End Try
            CNN.Close()

            Me.CodFuncionario.Clear()
            Me.NomeFuncionario.Clear()
            Me.CodigoServico.Clear()
            Me.NomeServico.Clear()
            Me.Qtd.Clear()
            Me.ValorUnitario.Clear()
            Me.Total.Clear()
            Me.ValorDesconto.Clear()
            Me.CodFuncionario.Focus()
            Me.txtDesconto.Clear()
            Status = "INSERT"
            My.Forms.OSor�amento.atGridServico()
        ElseIf OperationItens = UPD Then

            CNN.Open()

            Dim Sql As String = "UPDATE OrcamentoItemServico SET CodigoServico=?,Funcionario=?,Qtd=?,ValorUnitario=?,Desconto=?,ValorDesconto=?,TotalServico=?,Comissao=?,ValorComissao=? WHERE id=" & IdLinha
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)
            cmd.Parameters.Add(New OleDb.OleDbParameter("CodigoServico", Me.CodigoServico.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("Funcionario", Me.CodFuncionario.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("Qtd", Me.Qtd.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("ValorUnitario", Me.ValorUnitario.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("Desconto", NzZero(Me.ValorDesconto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("ValorDesconto", NzZero(Me.ValorDesconto.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("TotalServico", Me.Total.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("Comissao", 0))
            cmd.Parameters.Add(New OleDb.OleDbParameter("ValorComissao", 0))

            Try
                cmd.ExecuteNonQuery()

                MsgBox("Registro atualizado com sucesso", 64, "Valida��o de Dados")

                'ErroLivre = "Itens Alterados com sucesso"
                'GerarLog(Me.Text, A��oTP.Livre, Me.CodigoServico.Text)


            Catch ex As Exception
                MsgBox(ex.Message, 64, "Valida��o de Dados")
            End Try
            CNN.Close()
            My.Forms.OSor�amento.atGridServico()
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub PedOSServicoAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If OperationItens = UPD Then
            EditaIten()
        End If
        Me.CodFuncionario.Focus()
    End Sub
    Private Sub EditaIten()

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "SELECT OrcamentoItemServico.Id, OrcamentoItemServico.CodigoOrcamento, OrcamentoItemServico.CodigoServico, Servicos.Serv_Descricao, OrcamentoItemServico.Funcionario, Funcion�rios.Nome, OrcamentoItemServico.Qtd, OrcamentoItemServico.ValorUnitario, OrcamentoItemServico.ValorDesconto,  OrcamentoItemServico.TotalServico, OrcamentoItemServico.Desconto FROM (OrcamentoItemServico INNER JOIN Servicos ON OrcamentoItemServico.CodigoServico = Servicos.Serv_Codigo) INNER JOIN Funcion�rios ON OrcamentoItemServico.Funcionario = Funcion�rios.C�digoFuncion�rio WHERE (((OrcamentoItemServico.Id)=" & Me.IdLinha & "));"

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        Me.CodFuncionario.Text = DR.Item("Funcionario")
        Me.NomeFuncionario.Text = DR.Item("nome")
        Me.CodigoServico.Text = DR.Item("codigoservico")
        Me.NomeServico.Text = DR.Item("Serv_Descricao")
        Me.Qtd.Text = DR.Item("qtd")
        Me.ValorUnitario.Text = DR.Item("valorunitario")
        Me.ValorDesconto.Text = FormatCurrency(DR.Item("ValorDesconto"))
        Me.Total.Text = DR.Item("TotalServico")
        Me.txtDesconto.Text = FormatNumber(NzZero(DR.Item("Desconto")), 2)
        DR.Close()


    End Sub

    Private Sub CodFuncionario_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodFuncionario.Enter
        xValorAntigo = CodFuncionario.Text
    End Sub

    Private Sub CodFuncionario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodFuncionario.TextChanged

    End Sub

    Private Sub Total_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Total.Enter
        Me.Total.Text = FormatCurrency((NzZero(Me.Qtd.Text) * NzZero(Me.ValorUnitario.Text)) - NzZero(Me.ValorDesconto.Text), 2)
    End Sub

    Private Sub txtDesconto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDesconto.Validating
        Try
            Dim vDes As Double = 0
            vDes = FormatNumber((Me.txtDesconto.Text) * CDbl(Qtd.Text * NzZero(ValorUnitario.Text)) / 100, 2)
            'vDes = CDbl(NzZero((Me.ValorDesconto.Text)) * 100) / CDbl(Qtd.Text * NzZero(ValorUnitario.Text))
            If Desc > 0 Then
                If String.IsNullOrEmpty(UserSenhaDesconto.Text) Then
                    If txtDesconto.Text > Desc Then
                        MsgBox("Desconto ultrapassou o valor m�ximo", 48, "Aten��o")
                        Me.ValorDesconto.Text = "0,00"
                        Me.txtDesconto.Text = "0,00"
                        Me.Total.Text = FormatCurrency(Me.Qtd.Text * Me.ValorUnitario.Text)
                        Exit Sub
                    Else
                        ValorDesconto.Text = FormatCurrency(vDes, 2)
                    End If
                Else
                    ValorDesconto.Text = FormatCurrency(vDes, 2)
                End If


            Else
                ValorDesconto.Text = FormatCurrency(vDes, 2)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub txtDesconto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesconto.KeyDown
        If e.KeyCode = Keys.Insert Then
            My.Forms.PedidoVendaSenhaItem.ShowDialog()
        End If
    End Sub

    Private Sub ValorDesconto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ValorDesconto.Validating
        Dim vDes As Double = 0

        '
        If Me.ValorDesconto.Text = "" Then
            Me.ValorDesconto.Text = "0,00"
        End If
        '
        vDes = NzZero((Me.ValorDesconto.Text) * 100) / (Qtd.Text * ValorUnitario.Text)
        If vDes > 0 Then
            If Desc > 0 Then
                If vDes > Desc Then
                    MsgBox("Desconto ultrapassou o valor m�ximo", 48, "Aten��o")
                    Me.ValorDesconto.Text = "0,00"
                    Me.Total.Text = FormatCurrency(Me.Qtd.Text * Me.ValorUnitario.Text)
                    Exit Sub
                Else
                    txtDesconto.Text = FormatNumber(vDes, 4)
                    Total.Focus()
                End If
            Else
                txtDesconto.Text = FormatNumber(vDes, 4)
                Total.Focus()


            End If
        Else
            txtDesconto.Text = FormatNumber(vDes, 4)
            txtDesconto.Focus()
        End If

    End Sub

    Private Sub Qtd_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Qtd_Enter(sender As Object, e As EventArgs) Handles Qtd.Enter
        If NzZero(Me.Qtd.Text) = 0 Then
            Me.Qtd.Text = FormatNumber(1, 4)
        End If
    End Sub
End Class