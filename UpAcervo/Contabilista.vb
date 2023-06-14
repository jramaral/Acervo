Public Class Contabilista
    Dim bs As New BindingSource
    Dim flag As Boolean = False
    Private Sub Contabilista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        encontrarReg()
        carregaComboMun()

    End Sub

    Sub carregaComboMun()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "SELECT * FROM Municipio order by NomeMunic"
        Dim Cmd As New OleDb.OleDbCommand(Sql, Cnn)
        Dim Da As New OleDb.OleDbDataAdapter(Cmd)

        Dim ds As New DataSet
        Da.Fill(ds, "Table")

        'Conecto meu BindinSource com meu DataSet
        bs.DataSource = ds.Tables(0).DefaultView
        Me.cMun.DataSource = bs
        Me.cMun.DisplayMember = "NomeMunic"
        Me.cMun.ValueMember = "CodMunicipio"

        If flag Then
            Me.cMun.SelectedValue = "5003702"
            Dim row As DataRow
            row = DirectCast(bs.Current, DataRowView).Row
            Me.Estado.Text = row.Item("nomeuf").ToString
            Me.cod_mun.Text = row.Item("CodMunicipio").ToString
        Else
            Me.cMun.SelectedIndex = -1
        End If

        Da.Dispose()

        Cnn.Close()
    End Sub

    Private Sub FecharBT_Click(sender As Object, e As EventArgs) Handles FecharBT.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cMun_Leave(sender As Object, e As EventArgs) Handles cMun.Leave
        Dim row As DataRow

        If Not String.IsNullOrEmpty(Me.cMun.Text) Then
            row = DirectCast(bs.Current, DataRowView).Row
            Me.Estado.Text = row.Item("nomeuf").ToString
            Me.cod_mun.Text = row.Item("CodMunicipio").ToString
        Else
            Me.Estado.Clear()
            Me.cod_mun.Clear()
        End If

    End Sub
    Sub encontrarReg()
        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Try
            Dim cmd As New OleDb.OleDbCommand("Select * from contabilista", Cnn)
            Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                flag = True

                Me.cpf.Text = String.Format("{0:000\.000\.000\-00}", Convert.ToUInt64(dr.Item("cpf")))
                Me.cnpj.Text = IIf(dr.Item("cnpj").Equals(""), "", String.Format("{0:00\.000\.000\/0000\-00}", Convert.ToUInt64(NzZero(dr.Item("cnpj")))))
                Me.crc.Text = dr.Item("crc") & ""
                Me.nome.Text = dr.Item("nome") & ""
                Me.ende.Text = dr.Item("ende") & ""
                Me.num.Text = dr.Item("num") & ""
                Me.bairro.Text = dr.Item("bairro") & ""
                Me.compl.Text = dr.Item("compl") & ""
                Me.cod_mun.Text = dr.Item("cod_mun") & ""
                Me.CEP.Text = IIf(dr.Item("cep").Equals(""), "", String.Format("{0:00000\-000}", Convert.ToUInt64(NzZero(dr.Item("cep")))))
                Me.email.Text = dr.Item("email") & ""
                Me.Telefone.Text = IIf(dr.Item("fone").Equals(""), "", String.Format("{0:(00\)0000\-0000}", Convert.ToUInt64(NzZero(dr.Item("fone")))))
                Me.fax.Text = IIf(dr.Item("fax").Equals(""), "", String.Format("{0:(00\)0000\-0000}", Convert.ToUInt64(NzZero(dr.Item("fax")))))

            Else
                flag = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub SalvarBT_Click(sender As Object, e As EventArgs) Handles SalvarBT.Click


        If String.IsNullOrEmpty(nome.Text) Then
            MessageBox.Show("O nome não pode ser nulo", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf (String.IsNullOrEmpty(cpf.Text)) Then
            MessageBox.Show("O cpf não pode ser nulo", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf (String.IsNullOrEmpty(crc.Text)) Then
            MessageBox.Show("O crc não pode ser nulo", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf (String.IsNullOrEmpty(cMun.Text)) Then
            MessageBox.Show("O Município não pode ser nulo", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf(String.IsNullOrEmpty(email.Text)) then
            MessageBox.Show("O email não pode ser nulo", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        If Not (flag) Then

            Dim Sql As String = "INSERT INTO Contabilista (reg, nome, cpf, crc, cnpj, cep, ende, compl, num, bairro, fone, fax, email, cod_mun) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12,@13, @14)"
            Dim cmd As New OleDb.OleDbCommand(Sql, Cnn)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.reg.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.nome.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", StrRemove(Me.cpf.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.crc.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", StrRemove(Me.cnpj.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", StrRemove(Me.CEP.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.ende.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.compl.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.num.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.bairro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", StrRemove(Me.Telefone.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", StrRemove(Me.fax.Text)))
            cmd.Parameters.AddWithValue("@13", Nz(email.Text, 1))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.cod_mun.Text, 1)))

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro adicionado com sucesso", 64, "Validação de Dados")
                flag = True
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Validação de Dados")
            End Try

        Else
            Dim Sql As String = "UPDATE Contabilista SET reg=@1, nome=@2, cpf=@3, crc=@4, cnpj=@5, cep=@6, ende=@7, compl=@8, num=@9, bairro=@10, fone=@11, fax=@12, email=@13, cod_mun=@14"
            Dim cmd As New OleDb.OleDbCommand(Sql, Cnn)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.reg.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.nome.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", StrRemove(Me.cpf.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.crc.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", StrRemove(Me.cnpj.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", StrRemove(Me.CEP.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.ende.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.compl.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.num.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.bairro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", StrRemove(Me.Telefone.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", StrRemove(Me.fax.Text)))
            cmd.Parameters.AddWithValue("@13", Nz(email.Text, 1))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.cod_mun.Text, 1)))

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro atualizado com sucesso", 64, "Validação de Dados")
                flag = True
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Validação de Dados")
            End Try

        End If
    End Sub

    Private Function StrRemove(ByVal s As String)

        s = s.Replace(".", "")
        s = s.Replace("-", "")
        s = s.Replace("/", "")
        s = s.Replace("(", "")
        s = s.Replace(")", "")

        Return s
    End Function
End Class