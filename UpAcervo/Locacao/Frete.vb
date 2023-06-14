Imports System.Math
Public Class Frete
    Dim Ação As New TrfGerais()

    Private Operation As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2

    Dim Autorizado As Boolean


    Private Sub txtDescricao_TextChanged(sender As Object, e As EventArgs) Handles txtDescricao.TextChanged, txtValorKM.TextChanged, txtValorFrete.TextChanged, txtQtdKM.TextChanged

    End Sub

    Private Sub Frete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Ação.Desbloquear_Controle(Me, False)
        Me.TxtProcura.Enabled = True
    End Sub

    Private Sub FecharBT_Click(sender As Object, e As EventArgs) Handles FecharBT.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub NovoBT_Click(sender As Object, e As EventArgs) Handles NovoBT.Click
        Ação.LimpaTextBox(Me)
        Ação.Desbloquear_Controle(Me, True)
        Me.TxtProcura.Enabled = True
        Me.txtcodigo.Text = "0000"
        Me.txtDescricao.Focus()
        Me.txtDescricao.Clear()
        Me.txtValorKM.Clear()
        Me.txtQtdKM.Clear()
        Me.txtValorFrete.Clear()
        Operation = INS
    End Sub

    Private Sub EditarBT_Click(sender As Object, e As EventArgs) Handles EditarBT.Click
        If Me.txtcodigo.Text = "" Then
            MsgBox("Não existe Grupo para ser editado.", 64, "Validação de Dados")
            Exit Sub
        End If
        Operation = UPD
        Ação.Desbloquear_Controle(Me, True)
        Me.TxtProcura.Enabled = True
        Me.txtDescricao.Enabled = False
        Me.txtDescricao.Focus()
    End Sub

    Private Sub SalvarBT_Click(sender As Object, e As EventArgs) Handles SalvarBT.Click
        'Area destinada para as validacoes

        If Me.txtDescricao.Text = "" Then
            MsgBox("A  descrição  não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.txtDescricao.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.txtValorKM.Text) Or nzNUM(Me.txtValorKM.Text) = 0 Then
            MsgBox("A  o valor do KM  não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.txtValorKM.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.txtQtdKM.Text) Or nzNUM(Me.txtQtdKM.Text) = 0 Then
            MsgBox("A  quantidade de KM  não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.txtQtdKM.Focus()
            Exit Sub
        End If
        'Fim da Area destinada para as validacoes

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

        If Operation = INS Then
            CNN.Open()

            UltimoReg()
            Dim Sql As String = "INSERT INTO Frete (CodigoFrete, DescricaoFrete, ValorKM, DistanciaKM, ValorFrete, Empresa) VALUES (@1, @2, @3, @4, @5, @6)"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.txtcodigo.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.txtDescricao.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.txtValorKM.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.txtQtdKM.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.txtValorFrete.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", CodEmpresa))

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro adicionado com sucesso", 64, "Validação de Dados")
                GerarLog(Me.Text, AçãoTP.Adicionou, Me.txtcodigo.Text)
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Validação de Dados")
            End Try
            Ação.Desbloquear_Controle(Me, False)
            CNN.Close()

        ElseIf Operation = UPD Then
            CNN.Open()

            Dim Sql As String = "Update Frete set DescricaoFrete = @2, ValorKM = @3, DistanciaKM=@4, ValorFrete=@5 Where codigoFrete = " & Me.txtcodigo.Text
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.txtDescricao.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.txtValorKM.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.txtQtdKM.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.txtValorFrete.Text, 1)))

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro Atualizado com sucesso", 64, "Validação de Dados")
                GerarLog(Me.Text, AçãoTP.Editou, Me.txtcodigo.Text)
            Catch x As Exception
                MsgBox(x.Message)
                Exit Sub
            End Try
            Ação.Desbloquear_Controle(Me, False)
            Me.TxtProcura.Enabled = True
            CNN.Close()
        End If

        If A3.Checked Then
            Buscar(3)
        End If

    End Sub
    Public Sub UltimoReg()
        'Inserir ultimo registro
        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader
        Dim Ult As Integer
        With Cmd
            .Connection = Cnn
            .CommandTimeout = 0
            .CommandText = "Select max(codigoFrete) from Frete"
            .CommandType = CommandType.Text
        End With
        Try
            Cnn.Open()
            DataReader = Cmd.ExecuteReader

            While DataReader.Read
                If Not IsDBNull(DataReader.Item(0)) Then
                    'Achou o iten procurado o iten as caixas serão preenchida
                    Ult = DataReader.Item(0)
                End If
            End While
            DataReader.Close()

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()

        Me.txtcodigo.Text = Ult + 1
        Me.txtcodigo.Refresh()
        Me.txtDescricao.Focus()
        'fim inserir ultimo registro

    End Sub

    Private Sub ExcluirBT_Click(sender As Object, e As EventArgs) Handles ExcluirBT.Click
        If Me.txtcodigo.Text = "" Then Exit Sub

        Autorizado = PedirPermissao(Me.Text, Me.txtcodigo.Text)
        If Autorizado = False Then
            Exit Sub
        End If


        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()
        Dim SQL As String


        If MsgBox("Deseja realmente excluir este Frete ?", 36, "Validação de Dados") = 6 Then
            SQL = "Delete * From Frete Where codigofrete = " & Me.txtcodigo.Text
            Dim cmdEXC As New OleDb.OleDbCommand(SQL, Cnn)
            cmdEXC.ExecuteNonQuery()
            MessageBox.Show("Registro excluido com sucesso.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GerarLog(Me.Text, AçãoTP.Excluiu, Me.txtcodigo.Text)
            If A3.Checked Then
                Buscar(3)
            End If

            NovoBT_Click(sender, e)
            Cnn.Close()
            Exit Sub
        End If


    End Sub
    Private Sub Buscar(ByVal Opt As Integer)

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Select Case Opt
            Case 1
                ' Sql = "Select Grupos.CódigoGrupo, Grupos.Descrição From Grupos Where Grupos.Empresa = " & CodEmpresa & " And CódigoGrupo = " & Me.TxtProcura.Text & " Order by Grupos.Descrição"
            Case 2
                Sql = "Select Frete.codigofrete, descricaofrete, valorkm, distanciakm, valorfrete From frete Where Empresa = " & CodEmpresa & "  And descricaofrete like '%" & Me.TxtProcura.Text & "%' Order by descricaofrete"
            Case 3
                Sql = "Select codigofrete, descricaofrete, valorkm, distanciakm, valorfrete From frete Where Empresa = " & CodEmpresa & " Order by descricaofrete"
        End Select

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()
        Me.TxtProcura.Clear()

    End Sub
    Private Sub A2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A2.CheckedChanged, A3.CheckedChanged

        If Me.A2.Checked = True Then
            Me.TxtProcura.Enabled = True
            Me.TxtProcura.Focus()
        End If
        If Me.A3.Checked = True Then
            Buscar(3)
        End If
    End Sub


    Private Sub TxtProcura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProcura.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.A2.Checked = True Then
                Buscar(2)
            End If
        End If
    End Sub

    Private Sub txtValorKM_Leave(sender As Object, e As EventArgs) Handles txtValorKM.Leave
        If String.IsNullOrEmpty(Me.txtQtdKM.Text) Then
            Me.txtQtdKM.Text = 0
            Me.txtValorFrete.Text = FormatCurrency(Me.txtQtdKM.Text * Me.txtValorKM.Text, 2)
        Else
            Me.txtValorFrete.Text = FormatCurrency(Math.Round((Me.txtQtdKM.Text * Me.txtValorKM.Text)), 2)
        End If
    End Sub

    Private Sub txtQtdKM_Leave(sender As Object, e As EventArgs) Handles txtQtdKM.Leave
        If String.IsNullOrEmpty(Me.txtValorKM.Text) Then
            Me.txtValorKM.Text = 0
            Me.txtValorFrete.Text = FormatCurrency(Me.txtQtdKM.Text * Me.txtValorKM.Text, 2)
        Else
            Me.txtValorFrete.Text = FormatCurrency(Math.Round((Me.txtQtdKM.Text * Me.txtValorKM.Text)), 2)
        End If
    End Sub

    Private Sub Lista_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Lista.CellContentClick
        Me.txtcodigo.Text = CInt(Me.Lista.CurrentRow.Cells(0).Value)
        Me.txtDescricao.Text = Me.Lista.CurrentRow.Cells(1).Value
        Me.txtValorKM.Text = Me.Lista.CurrentRow.Cells(2).Value
        Me.txtQtdKM.Text = Me.Lista.CurrentRow.Cells(3).Value
        Me.txtValorFrete.Text = Me.Lista.CurrentRow.Cells(4).Value
        Ação.Desbloquear_Controle(Me, True)
        Operation = UPD
    End Sub
End Class