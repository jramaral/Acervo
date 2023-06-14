Imports System.Data.OleDb

Public Class NFeFaturas

    Dim NFe_NumeroVar As Integer
    Public Property NFeNumero() As Integer
        Get
            Return NFe_NumeroVar
        End Get
        Set(ByVal Value As Integer)
            NFe_NumeroVar = Value
        End Set
    End Property

    Dim ChaveNFe_Var As String
    Public Property NFeChave() As String
        Get
            Return ChaveNFe_Var
        End Get
        Set(ByVal Value As String)
            ChaveNFe_Var = Value
        End Set
    End Property

    Dim dEmiss As Date
    Public Property DataEmissao() As Date
        Get
            Return dEmiss
        End Get
        Set(ByVal Value As Date)
            dEmiss = Value
        End Set
    End Property

    Dim vNFe As Decimal
    Public Property ValorNFe() As Decimal
        Get
            Return vNFe
        End Get
        Set(ByVal Value As Decimal)
            vNFe = Value
        End Set
    End Property



    Private Operation As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2
    Const CON As Byte = 3

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click

        If Me.Avista.Checked = True Then
            Me.Close()
            Me.Dispose()
        End If

        If Me.APrazo.Checked = True Then
            If FormatNumber(CDbl(Me.NFeValor.Text), 2) = FormatNumber(CDbl(Me.ValorGerado.Text), 2) Then
                Me.Close()
                Me.Dispose()
            End If
        End If

    End Sub

    Private Sub Avista_CheckedChanged(sender As Object, e As EventArgs) Handles Avista.CheckedChanged
        If Me.Avista.Checked = True Then
            Me.PainelParcelas.Visible = False
            Me.btFechar.Enabled = True
        End If
        If Me.APrazo.Checked = True Then
            Me.PainelParcelas.Visible = True
            If FormatNumber(CDbl(Me.NFeValor.Text), 2) <> FormatNumber(CDbl(Me.ValorGerado.Text), 2) Then
                Me.btFechar.Enabled = False
            End If
            Me.Parcela.Focus()
        End If
    End Sub

    Private Sub NFeFaturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.nNF.Text = NFe_NumeroVar
        Me.NFeValor.Text = FormatNumber(vNFe, 2)
    End Sub

    Private Sub dVenc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dVenc.Validating
        If CDate(Me.dVenc.Text) < CDate(dEmiss) Then
            MessageBox.Show("A data de vencimento da Parcela não pode ser menor que a data e emissão", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dVenc.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click

        'Area destinada para as validacoes

        If Me.vDup.Text = "" Then
            MsgBox("O Valor da documento não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.vDup.Focus()
            Exit Sub
        ElseIf Me.dVenc.Text = "" Then
            MsgBox("A data de vencimento não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.dVenc.Focus()
            Exit Sub
        ElseIf Me.Parcela.Text = "" Then
            MsgBox("O numero da parcela não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.Parcela.Focus()
            Exit Sub
        End If
        'Fim da Area destinada para as validacoes

        Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        CNN.Open()

        If Operation = INS Then


            Dim Sql As String = "INSERT INTO NFeDuplicatas (ChaveAcesso, nDup, dVenc, vDup) VALUES (@1, @2, @3, @4)"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUL(ChaveNFe_Var)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", nzNUL(Me.nNF.Text & "-" & Me.Parcela.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", nzDAT(Me.dVenc.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", nzNUM(Me.vDup.Text)))

            Try
                cmd.ExecuteNonQuery()
                CNN.Close()
                CarregaListaReceber()
                Me.Parcela.Clear()
                Me.dVenc.Clear()
                Me.vDup.Clear()
                Operation = INS
                Me.Parcela.Focus()

            Catch ex As Exception
                MsgBox(ex.Message, 64, "Validação de Dados")
                CNN.Close()
            End Try

        ElseIf Operation = UPD Then

            Dim Dup As String = Me.nNF.Text & "-" & Me.Parcela.Text
            Dim Sql As String = "Update NFeDuplicatas set ChaveAcesso = @1, nDup = @2, dVenc = @3, vDup = @4 Where nDup = '" & Dup & "' And ChaveAcesso = '" & ChaveNFe_Var & "'"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", nzDAT(Me.dVenc.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", nzNUM(Me.vDup.Text)))

            Try
                cmd.ExecuteNonQuery()
                CarregaListaReceber()
                CNN.Close()
                Me.Parcela.Clear()
                Me.dVenc.Clear()
                Me.vDup.Clear()
                Operation = INS
                Me.Parcela.Focus()

            Catch x As Exception
                MsgBox(x.Message)
                CNN.Close()
            End Try

        End If

    End Sub

    Private Sub CarregaListaReceber()

        Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        Dim Sql As String = String.Empty

        Sql = "SELECT * From NFeDuplicatas WHERE ChaveAcesso = '" & ChaveNFe_Var & "'"

        Dim da = New OleDbDataAdapter(Sql, CNN)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.ListaReceber.DataSource = ds.Tables("Table").DefaultView


        Me.ValorGerado.Text = FormatNumber(NzZero(ds.Tables("table").Compute("SUM(vDup)", "")), 2)

        If NzZero(Me.ValorGerado.Text) <> NzZero(Me.NFeValor.Text) Then
            Me.ValorGerado.ForeColor = Color.Maroon
        Else
            Me.ValorGerado.ForeColor = Color.Navy
            Me.btFechar.Enabled = True
        End If

        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub ExcluitDuplicataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluitDuplicataToolStripMenuItem.Click

        If MsgBox("Deseja realmente excluir todos item da lista de Duplicatas.", 36, "Validação de Dados") = 6 Then

            Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
            CNN.Open()
            Dim Sql As String = "Delete * from NFeDuplicatas where ChaveAcesso = '" & ChaveNFe_Var & "'"
            Dim CMD As New OleDb.OleDbCommand(Sql, CNN)

            CMD.ExecuteNonQuery()

            CNN.Close()

            CarregaListaReceber()
        End If
        
    End Sub
End Class