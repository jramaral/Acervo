Imports System.Data.OleDb
Public Class BalanceteEditLancCC

    Private Operation As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2

    Public Property TipoOperação As Byte
        Get
            Return Operation
        End Get
        Set(ByVal Value As Byte)
            Operation = Value
        End Set
    End Property

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btNovo_Click(sender As Object, e As EventArgs) Handles btNovo.Click
        Me.Id.Clear()
        Me.DataLanc.Clear()
        Me.ValorLanc.Clear()
        Me.ContaCC.Clear()
        Me.ContaCCDesc.Clear()
        Me.Id.Text = "AUTO"
        Me.DataLanc.Focus()
    End Sub

    Private Sub btFindContaCC_Click(sender As Object, e As EventArgs) Handles btFindContaCC.Click
        My.Forms.CentroCustoNewLocalizar.ShowDialog()
        AchaContaCentroCusto(Me.ContaCC.Text, Me.ContaCCDesc)
        Me.ContaCC.Focus()
    End Sub

    Public Sub AchaContaCentroCusto(ByVal ContaCC As String, ByVal CampoParaRetornar As Control)

        If ContaCC = "" Then Exit Sub

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "Select * from Cc3 where ContaGrupo3 = '" & ContaCC & "' And Empresa = " & CodEmpresa
        Dim CMD As New OleDbCommand(Sql, Cnn)
        Dim DR As OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            CampoParaRetornar.Text = DR.Item("DescContaGrupo3") & ""
        End If
        Cnn.Close()

    End Sub

    Private Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click

        If Me.IdCaixaBanco.Text = "" Then
            MessageBox.Show("Não foi informado a relação com o caixa/banco, favor verificar.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            Me.DataLanc.Focus()
        End If

        If Me.DataLanc.Text = "" Then
            MessageBox.Show("Não foi informado a data de lançamento, favor verificar.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            Me.DataLanc.Focus()
        End If

        If Me.ValorLanc.Text = "" Then
            MessageBox.Show("Não foi informado o valor do lançamento, favor verificar.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            Me.DataLanc.Focus()
        End If

        If Me.ContaCC.Text = "" Then
            MessageBox.Show("Não foi informado a conta de centro de custo, favor verificar.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            Me.DataLanc.Focus()
        End If

        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        If Operation = INS Then

            Dim Sql As String = "INSERT INTO CCLanc (IdCaixaBanco, ContaCC, DataLanc,ValorLanc) VALUES (@IdCaixaBanco,@ContaCC,@DataLanc,@ValorLanc)"
            Dim cmd As New OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDbParameter("@IdCaixaBanco", nzINT(Me.IdCaixaBanco.Text)))
            cmd.Parameters.Add(New OleDbParameter("@ContaCC", nzNUL(Me.ContaCC.Text)))
            cmd.Parameters.Add(New OleDbParameter("@DataLanc", nzDAT(Me.DataLanc.Text)))
            cmd.Parameters.Add(New OleDbParameter("@ValorLanc", nzNUM(Me.ValorLanc.Text)))

            Try
                cmd.ExecuteNonQuery()

                cmd.CommandText = "SELECT @@IDENTITY"
                Me.Id.Text = cmd.ExecuteScalar.ToString
                CNN.Close()
                My.Forms.BalanceteEdit.CarregaListaCentroCusto()
                MsgBox("Registro adicionado com sucesso", 64, "Validação de Dados")
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Validação de Dados")
            End Try
            CNN.Close()

        ElseIf Operation = UPD Then

            Dim Sql As String = "Update CCLanc set ContaCC = @ContaCC, DataLanc = @DataLanc, ValorLanc = @ValorLanc Where Id = " & Me.Id.Text
            Dim cmd As New OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDbParameter("@ContaCC", nzNUL(Me.ContaCC.Text)))
            cmd.Parameters.Add(New OleDbParameter("@DataLanc", nzDAT(Me.DataLanc.Text)))
            cmd.Parameters.Add(New OleDbParameter("@ValorLanc", nzNUM(Me.ValorLanc.Text)))

            Try
                cmd.ExecuteNonQuery()
                CNN.Close()
                My.Forms.BalanceteEdit.CarregaListaCentroCusto()
                MsgBox("Registro Atualizado com sucesso", 64, "Validação de Dados")
            Catch x As Exception
                MsgBox(x.Message)
                Exit Sub
            End Try

        End If

    End Sub

    Private Sub BalanceteEditLancCC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Operation = UPD Then
            AcharRegistroLancamento()
        End If

        If Operation = INS Then
            Me.IdCaixaBanco.Text = My.Forms.BalanceteEdit.Id.Text
            Me.Id.Text = "AUTO"
        End If
    End Sub

    Private Sub AcharRegistroLancamento()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Ds As New DataSet

        Dim Transacao As OleDbTransaction = Cnn.BeginTransaction()
        Dim Cmd As OleDbCommand = Cnn.CreateCommand

        Cmd.Transaction = Transacao

        Cmd.CommandText = "Select * from CcLanc Where Id = " & Me.Id.Text
        Dim da As New OleDbDataAdapter(Cmd)
        da.Fill(Ds, "CCLanc")

        If Ds.Tables("CCLanc").Rows.Count <> 0 Then

            Me.Id.Text = Ds.Tables("CCLanc").Rows(0)("Id")
            Me.IdCaixaBanco.Text = Ds.Tables("CCLanc").Rows(0)("IdCaixaBanco")
            Me.ContaCC.Text = Ds.Tables("CCLanc").Rows(0)("ContaCC")
            Me.DataLanc.Text = Ds.Tables("CCLanc").Rows(0)("DataLanc")
            Me.ValorLanc.Text = Ds.Tables("CCLanc").Rows(0)("ValorLanc")

            Cnn.Close()
            AchaContaCentroCusto(Me.ContaCC.Text, Me.ContaCCDesc)
        End If
    End Sub

    Private Sub ContaCC_Validated(sender As Object, e As EventArgs) Handles ContaCC.Validated
        AchaContaCentroCusto(Me.ContaCC.Text, Me.ContaCCDesc)
    End Sub

    Private Sub btExcluir_Click(sender As Object, e As EventArgs) Handles btExcluir.Click

        If Me.IdCaixaBanco.Text = "" Then
            MessageBox.Show("Não foi informado a relação com o caixa/banco, favor verificar.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            Me.DataLanc.Focus()
        End If

        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "Delete from CCLanc  where Id = " & Me.Id.Text
        Dim cmd As New OleDbCommand(Sql, CNN)

        Try
            cmd.ExecuteNonQuery()
            CNN.Close()
            My.Forms.BalanceteEdit.CarregaListaCentroCusto()
            MsgBox("Registro excluido com sucesso", 64, "Validação de Dados")

            Me.Id.Clear()
            Me.DataLanc.Clear()
            Me.ValorLanc.Clear()
            Me.ContaCC.Clear()
            Me.ContaCCDesc.Clear()
            Me.Id.Text = "AUTO"
            Me.DataLanc.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, 64, "Validação de Dados")
        End Try


    End Sub
End Class