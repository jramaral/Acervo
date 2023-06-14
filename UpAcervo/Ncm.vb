
Public Class Ncm
    Dim Ação As New TrfGerais()

    Private Operation As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2
    Dim Tp As String
    Private Sub codigo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles codigo.Validating
        If String.IsNullOrEmpty(codigo.Text) Then
            Exit Sub
        End If


        If Operation = INS Then
            If codigo.Text.Length < 8 Then
                'mensegem de advertencia
                MessageBox.Show("O codigo NCM tem que ter 8 digitos, você digitou " & codigo.Text.Length & " . Verifique!", "Validação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                codigo.Clear()
                codigo.Focus()
                Exit Sub
            ElseIf codigo.Text.Length = 8 Then
                'fazer um busca para verificar se já existe o codigo digitado
                EncontraNCM(codigo.Text)

            End If
        End If
    End Sub
    'Verificar se um ncm foi cadastrado
    Private Sub EncontraNCM(ByVal cod As String)

        If String.IsNullOrEmpty(cod) Then
            Exit Sub
        End If

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader
        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "SELECT  CodNCM FROM NCMTABELA WHERE CODNCM ='" & cod & "'"
            .CommandType = CommandType.Text
        End With
        Try
            DataReader = Cmd.ExecuteReader

            DataReader.Read()
            If DataReader.HasRows Then
                MsgBox("NCM já cadastrado, verifique!", 48, "Validação de dados")
                Me.codigo.Clear()
            End If
            'End While
            DataReader.Close()

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Exit Sub
            End If
        End Try

    End Sub

    Private Sub FecharBT_Click(sender As Object, e As EventArgs) Handles FecharBT.Click
        Me.DestroyHandle()
    End Sub

    Private Sub Ncm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.codigo.Enabled = False
        descricao.Enabled = False
    End Sub

    Private Sub NovoBT_Click(sender As Object, e As EventArgs) Handles NovoBT.Click
        Ação.LimpaTextBox(Me)
        DesbloquearTextBox(Me, True)
        Me.codigo.Text = ""
        Me.codigo.Focus()
        Operation = INS
    End Sub

    Private Sub SalvarBT_Click(sender As Object, e As EventArgs) Handles SalvarBT.Click
        'Area destinada para as validacoes

        If Me.codigo.Text = "" Then
            MsgBox("O Código do NCM não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.codigo.Focus()
            Exit Sub
        End If

        If Me.descricao.Text = "" Then
            MsgBox("A descrição do NCM não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.descricao.Focus()
            Exit Sub
        End If


        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

        If Operation = INS Then

            CNN.Open()


            Dim Sql As String = "INSERT INTO NCMTabela VALUES (@codNcm,@nomeNcm)"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@codNcm", (Me.codigo.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@nomeNcm", descricao.Text))


            Try
                cmd.ExecuteNonQuery()

                MsgBox("Registro adicionado com sucesso", 64, "Validação de Dados")
                GerarLog(Me.Text, AçãoTP.Confirmou, Me.codigo.Text)
                DesbloquearTextBox(Me, False)
                Operation = UPD
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Validação de Dados")
            End Try
            CNN.Close()

        ElseIf Operation = UPD Then

            CNN.Open()

            Dim Sql As String = "UPDATE NcmTabela SET  codNcm = @codNcm, nomeNcm = @nomeNcm Where CodNcm = '" & Me.codigo.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)


            cmd.Parameters.Add(New OleDb.OleDbParameter("@codncm", (Me.codigo.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@nomeNcm", Me.descricao.Text))

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro Atualizado com sucesso", 64, "Validação de Dados")
                GerarLog(Me.Text, AçãoTP.Editou, Me.codigo.Text)
                Operation = UPD
            Catch x As Exception
                MsgBox(x.Message)
                Exit Sub
            End Try
            ' Ação.Desbloquear_Controle(Me, False)
            DesbloquearTextBox(Me, False)
            CNN.Close()
        End If
    End Sub

    Private Sub EditarBT_Click(sender As Object, e As EventArgs) Handles EditarBT.Click
        If Me.codigo.Text = "" Then
            MsgBox("Não pode ser editado.", 64, "Validação de Dados")
            GerarLog(Me.Text, AçãoTP.Erro, Me.codigo.Text)
            Exit Sub
        End If

        Operation = UPD
        Me.descricao.Enabled = True
        Me.descricao.Focus()
    End Sub

    Private Sub ExcluirBT_Click(sender As Object, e As EventArgs) Handles ExcluirBT.Click
        If MessageBox.Show("Deseja excluir o Item.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
            Dim sql As String

            Dim sqlprod As String = "Select CF from produtos where cf='" & codigo.Text & "'"
            sql = "Delete * from NcmTabela where codNcm='" & Me.codigo.Text & "'"

            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()
            Dim cmd As New OleDb.OleDbCommand(sql, CNN)
            Dim cmd1 As New OleDb.OleDbCommand(sqlprod, CNN)

            Try
                Dim res As Integer = cmd1.ExecuteScalar()

                If (res > 0) Then
                    MessageBox.Show("Existem produtos cadastrados com esse ncm. Não será possivel a exclusão", "Validação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                Else
                    cmd.ExecuteNonQuery()
                    Operation = INS
                    Ação.Desbloquear_Controle(Me, False)
                    Ação.LimpaTextBox(Me)

                End If

               
            Catch ex As Exception
                Throw ex
            Finally
                CNN.Close()
            End Try
        End If
    End Sub

    Private Sub LocalizarBT_Click(sender As Object, e As EventArgs) Handles LocalizarBT.Click
        Operation = UPD
        My.Forms.NcmLocalizar.ShowDialog()
        Me.codigo.Enabled = False
        descricao.Enabled = False
    End Sub
End Class