Imports System.Data.OleDb

Public Class NaturezaOperacaoSped
    Dim A��o As New TrfGerais()

    Private Operation As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2

    Dim Autorizado As Boolean

    Private Sub FecharBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FecharBT.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub NovoBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovoBT.Click
        A��o.LimpaTextBox(Me)
        A��o.Desbloquear_Controle(Me, True)
        Me.TxtProcura.Enabled = True

        Me.codigoNat.Focus()
        Operation = INS
    End Sub

    Private Sub EditarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarBT.Click
        If Me.codigoNat.Text = "" Then
            MsgBox("N�o existe Opera��o para ser editado.", 64, "Valida��o de Dados")
            Exit Sub
        End If
        Operation = UPD
        A��o.Desbloquear_Controle(Me, True)
        Me.TxtProcura.Enabled = True
        Me.codigoNat.Enabled = False
        Me.Descricao.Focus()
    End Sub

    Private Sub SalvarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarBT.Click

        If codigoNat.Text.ToString().Length < 4 Or codigoNat.Text.ToString().Length > 4 Then
            MsgBox("O C�digo Tem que ter 4 digitoso, favor verificar.", 64, "Valida��o de Dados")
            Me.codigoNat.Focus()
            Exit Sub
        End If

        'Area destinada para as validacoes
        If Me.codigoNat.Text = "" Then
            MsgBox("O C�digo da Opera��o n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.codigoNat.Focus()
            Exit Sub
        ElseIf Me.Descricao.Text = "" Then
            MsgBox("A  descri��o da Opera��o n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.Descricao.Focus()
            Exit Sub
        End If
        'Fim da Area destinada para as validacoes

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

        If Operation = INS Then
            CNN.Open()

            Dim Sql As String = "INSERT INTO NatOpSped (CodigoNat, DescricaoNat) VALUES (@1, @2)"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.codigoNat.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Descricao.Text, 1)))


            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro adicionado com sucesso", 64, "Valida��o de Dados")
                GerarLog(Me.Text, A��oTP.Adicionou, Me.codigoNat.Text)
            Catch ex As Exception
                MsgBox(ex.TargetSite.ToString(), 64, "Valida��o de Dados")
                Exit Sub
            End Try
            A��o.Desbloquear_Controle(Me, False)
            CNN.Close()

        ElseIf Operation = UPD Then
            CNN.Open()

            Dim Sql As String = "Update NatOpSped set DescricaoNat = @2  Where codigoNat = " & Me.codigoNat.Text
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Descricao.Text, 1)))


            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro Atualizado com sucesso", 64, "Valida��o de Dados")
                GerarLog(Me.Text, A��oTP.Editou, Me.codigoNat.Text)
            Catch x As Exception
                MsgBox(x.Message)
                Exit Sub
            End Try
            A��o.Desbloquear_Controle(Me, False)
            Me.TxtProcura.Enabled = True
            CNN.Close()
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
            .CommandText = "Select max(CodigoNat) from NatOpSped"
            .CommandType = CommandType.Text
        End With
        Try
            Cnn.Open()
            DataReader = Cmd.ExecuteReader

            While DataReader.Read
                If Not IsDBNull(DataReader.Item(0)) Then
                    'Achou o iten procurado o iten as caixas ser�o preenchida
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

        Me.codigoNat.Text = Ult + 1
        Me.codigoNat.Refresh()
        Me.Descricao.Focus()
        'fim inserir ultimo registro

    End Sub

    Private Sub NatOp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        A��o.Desbloquear_Controle(Me, False)
        TxtProcura.Enabled = True
    End Sub


    Private Sub ExcluirBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirBT.Click

        If Me.codigoNat.Text = "" Then Exit Sub

        Autorizado = PedirPermissao(Me.Text, Me.codigoNat.Text)
        If Autorizado = False Then
            Exit Sub
        End If


        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim SQL As String = "Select Top 1 NatOp From Compra Where NatOp = '" & Me.codigoNat.Text & "'"
        Dim Cmd As New OleDb.OleDbCommand(SQL, Cnn)
        Dim DR As OleDb.OleDbDataReader

        DR = Cmd.ExecuteReader
        DR.Read()

        If DR.HasRows = True Then
            MessageBox.Show("Este Opera��o n�o pode ser excluido, existe dependencia em Compras.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DR.Close()
            Cnn.Close()
            Exit Sub
        Else
            If MsgBox("Deseja realmente excluir esta Opera��o ?", 36, "Valida��o de Dados") = 6 Then
                SQL = "Delete * From NatOpSped Where CodigoNat = '" & Me.codigoNat.Text & "'"
                Dim cmdEXC As New OleDb.OleDbCommand(SQL, Cnn)
                cmdEXC.ExecuteNonQuery()
                MessageBox.Show("Registro excluido com sucesso.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GerarLog(Me.Text, A��oTP.Excluiu, Me.codigoNat.Text)
                NovoBT_Click(sender, e)
                Cnn.Close()
                Exit Sub
            End If
        End If
        DR.Close()


    End Sub

#Region "Rotina de Procura"

    Private Sub A1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A1.CheckedChanged, A2.CheckedChanged, A3.CheckedChanged
        If Me.A1.Checked = True Then
            Me.TxtProcura.Enabled = True
            Me.TxtProcura.Focus()
        End If
        If Me.A2.Checked = True Then
            Me.TxtProcura.Enabled = True
            Me.TxtProcura.Focus()
        End If
        If Me.A3.Checked = True Then
            Buscar(3)
        End If
    End Sub

    Private Sub Buscar(ByVal Opt As Integer)

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Select Case Opt
            Case 1
                Sql = "Select CodigoNat, DescricaoNat From NatOpSped Where CodigoNat = '" & Me.TxtProcura.Text & "' Order by DescricaoNat"
            Case 2
                Sql = "Select CodigoNat, DescricaoNat From NatOpSped  Where DescricaoNat like '%" & Me.TxtProcura.Text & "%' Order by DescricaoNat"
            Case 3
                Sql = "Select CodigoNat, DescricaoNat From NatOpSped  Order by DescricaoNat"
        End Select

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()
        Me.TxtProcura.Clear()

    End Sub

    Private Sub Lista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lista.CellDoubleClick

        Me.codigoNat.Text = CInt(Me.Lista.CurrentRow.Cells(0).Value)
        Me.Descricao.Text = Me.Lista.CurrentRow.Cells(1).Value
        Me.codigoNat.Enabled = False
        Me.Descricao.Enabled = False
        Operation = UPD

    End Sub

    Private Sub TxtProcura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProcura.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.A1.Checked = True Then
                Buscar(1)
            End If
            If Me.A2.Checked = True Then
                Buscar(2)
            End If
        End If
    End Sub

#End Region


    Private Sub codigoNat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles codigoNat.KeyPress
        Dim keyAscii As Short = CShort(Asc(e.KeyChar))

        keyAscii = CShort(OnlyNumber(keyAscii))
        If keyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
End Class