Imports Microsoft.Win32

Public Class Fornecedor

    Dim A��o As New TrfGerais()

    Private Operation As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2
    Const VAZ As Byte = 5

    Dim CNN As OleDb.OleDbConnection

    Private Sub FecharBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FecharBT.Click
        CNN.Close()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Fornecedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TeclasAtalho(sender, e)
    End Sub

    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EncheListaPais()
        EncheListaUF()
        EncheListaLogradouro()

        CNN = New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Degrade()
        A��o.Desbloquear_Controle(Me, False)
        CNN.Open()
        Me.Inativo.Enabled = False
    End Sub

    Private Sub EncheListaLogradouro()

        Dim Cnn1 As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "Select * From Logradouros"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn1)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Logradouro.DataSource = ds.Tables("Table").DefaultView
        Me.Logradouro.DisplayMember = "Descricao"
        Me.Logradouro.ValueMember = "Descricao"
        Me.Logradouro.SelectedValue = -1

        da.Dispose()
        Cnn1.Close()

    End Sub

    Private Sub NovoBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovoBT.Click
        A��o.LimpaTextBox(Me)
        Me.cMun.SelectedIndex = -1
        Me.cUF.SelectedIndex = -1
        Me.cPais.SelectedIndex = -1


        A��o.Desbloquear_Controle(Me, True)
        Me.C�digoFornecedor.Enabled = False
        Me.C�digoFornecedor.Text = "0000"

        My.Forms.FornecedorCPFCNPJ.ShowDialog()
        Operation = INS
        AchaCPFCNPJ()

        Me.TipoFornecedor.Focus()

        Me.Inativo.Enabled = False
    End Sub

    Private Sub EncheListaPais()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT * FROM Paises order by DescPais"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.cPais.DataSource = ds.Tables("Table").DefaultView
        Me.cPais.DisplayMember = "DescPais"
        Me.cPais.ValueMember = "CodPais"
        Me.cPais.SelectedValue = -1

        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub EncheListaUF()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT * FROM UF order by NomeUF"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.cUF.DataSource = ds.Tables("Table").DefaultView
        Me.cUF.DisplayMember = "NomeUF"
        Me.cUF.ValueMember = "CodigoUF"
        Me.cUF.SelectedValue = -1

        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub EncheListaMunicipio()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT * FROM Municipio where UF = '" & Me.cUF.SelectedValue & "' order by NomeMunic"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.cMun.DataSource = ds.Tables("Table").DefaultView
        Me.cMun.DisplayMember = "NomeMunic"
        Me.cMun.ValueMember = "CodMunicipio"
        Me.cMun.SelectedValue = -1

        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub SalvarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarBT.Click
        If Adi = False Then
            MsgBox("O usu�rio n�o tem permiss�o para esta opera��o. Verifique.", 64, "Valida��o de Dados")
            Exit Sub
        End If
        'Area destinada para as validacoes
        If Me.C�digoFornecedor.Text = "" Then
            MsgBox("O C�digo do fornecedor n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.C�digoFornecedor.Focus()
            Exit Sub
        ElseIf Me.Raz�oSocial.Text = "" Then
            MsgBox("O Nome do fornecedor n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.Raz�oSocial.Focus()
            Exit Sub
        ElseIf Me.NomeFantasia.Text = "" Then
            MsgBox("O Nome Fantasia do fornecedor n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.NomeFantasia.Focus()
            Exit Sub
        ElseIf Me.TipoFornecedor.Text = "" Then
            MsgBox("O Tipo do fornecedor n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.TipoFornecedor.Focus()
            Exit Sub
        ElseIf Me.CgcCpf.Text = "" Then
            MsgBox("O Cpf/Cnpj do Cliente n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.CgcCpf.Focus()
            Exit Sub
        End If

        If Me.cUF.Text = "" Then
            MsgBox("Favor informar a UF do endere�o do fornecedor.", 64, "Valida��o de Dados")
            Me.cUF.Focus()
            Exit Sub
        End If
        If Me.Nro.Text = "" Then
            MsgBox("Favor informar o numero do endere�o do fornecedor.", 64, "Valida��o de Dados")
            Me.Nro.Focus()
            Exit Sub
        End If
        If Me.cMun.Text = "" Then
            MsgBox("Favor informar o municipio do endere�o do fornecedor.", 64, "Valida��o de Dados")
            Me.cMun.Focus()
            Exit Sub
        End If

        If Me.Logradouro.Text = "" Then
            MsgBox("Favor informar o logradouro do endere�o do fornecedor.", 64, "Valida��o de Dados")
            Me.Logradouro.Focus()
            Exit Sub
        End If

        If Me.Endere�o.Text = "" Then
            MsgBox("Favor informar o endere�o do fornecedor.", 64, "Valida��o de Dados")
            Me.Endere�o.Focus()
            Exit Sub
        End If

        If Me.Nro.Text = "" Then
            MsgBox("Favor informar o numero do endere�o do fornecedor.", 64, "Valida��o de Dados")
            Me.cPais.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.Cep.Text) Then
            MsgBox("Favor informar o Cep do endere�o do fornecedor.", 64, "Valida��o de Dados")
            Me.cPais.Focus()
            Exit Sub
        End If
        'Fim da Area destinada para as validacoes

        'If A��o.ChecaInscrE(Me.Estado.Text, Me.Incri��oEstadual.Text) = False Then
        ' MsgBox("A Inscri��o Estadual informada n�o � v�lida !!!", vbCritical, "Valida��o de Dados")
        ' Me.Estado.Focus()
        ' Exit Sub
        ' End If


        Me.Cidade.Text = Me.cMun.Text

        If Operation = INS Then

            UltimoReg()

            Dim Sql As String = "INSERT INTO Fornecedor (C�digoFornecedor, TipoFornecedor, CgcCpf, Incri��oEstadual, Raz�oSocial, NomeFantasia, Endere�o, Cidade, Estado, Cep , Telefone1, Telefone2, Fone0800, Fax, Contato, Email, CartaoNatal, Empresa, Inativo, Bairro, Observa��o, EndCorrespondencia, CidCorrespondencia, UFCorrespondencia, BairroCorrespondencia, CepCorrespondencia, Banco, ContaCorrente, AgenciaBancaria, nro, xCpl, cMun, cPais, xPais, cUF, Logradouro, DataAbertura) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20, @21, @22, @23, @24, @25, @26, @27, @28, @29, @30, @31, @32, @33, @34, @35, @36,@37)"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.C�digoFornecedor.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.TipoFornecedor.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.CgcCpf.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.Incri��oEstadual.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.Raz�oSocial.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.NomeFantasia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.Endere�o.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.Cidade.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.Estado.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.Cep.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.Telefone1.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.Telefone2.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(Me.Fone0800.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.Fax.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.Contato.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.Email.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Me.CartaoNatal.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", CodEmpresa))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", Me.Inativo.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@20", Nz(Me.Bairro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@21", Nz(Me.Observa��o.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@22", Nz(Me.EndCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@23", Nz(Me.CidCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@24", Nz(Me.UFCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@25", Nz(Me.BairroCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@26", Nz(Me.CepCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@27", Nz(Me.Banco.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@28", Nz(Me.ContaCorrente.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@29", Nz(Me.AgenciaBancaria.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@30", Nz(Me.Nro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@31", Nz(Me.xCpl.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@32", Nz(Me.cMun.SelectedValue, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@33", Nz(Me.cPais.SelectedValue, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@34", Nz(Me.cPais.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@35", Nz(Me.cUF.SelectedValue, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@36", Nz(Me.Logradouro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@37", Nz(Me.DataAbertura.Text, 1)))


            Try
                cmd.ExecuteNonQuery()
                Operation = VAZ
                MsgBox("Registro adicionado com sucesso", 64, "Valida��o de Dados")
                GerarLog(Me.Text, A��oTP.Adicionou, Me.C�digoFornecedor.Text)
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Valida��o de Dados")
            End Try
            A��o.Desbloquear_Controle(Me, False)

        ElseIf Operation = UPD Then


            Dim Sql As String = "Update Fornecedor set TipoFornecedor = @3, CgcCpf = @4, Incri��oEstadual = @5, Raz�oSocial = @6, NomeFantasia = @7, Endere�o = @8, Cidade = @9, Estado = @10, Cep = @11, Telefone1 = @12, Telefone2 = @13, Fone0800 = @14, Fax = @15, Contato = @16, Email = @17, CartaoNatal = @18, Empresa = @19, Inativo = @20, Bairro = @21, Observa��o = @22, EndCorrespondencia = @23, CidCorrespondencia = @24, UFCorrespondencia = @25, BairroCorrespondencia = @26, CepCorrespondencia = @27, Banco = @28, ContaCorrente = @29, AgenciaBancaria = @30, nro = @31, xCpl = @32, cMun = @33, cPais = @34, xPais = @35, cUF = @36, Logradouro = @37, DataAbertura=@38 Where C�digoFornecedor = " & Me.C�digoFornecedor.Text
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.TipoFornecedor.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.CgcCpf.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.Incri��oEstadual.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.Raz�oSocial.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.NomeFantasia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.Endere�o.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.Cidade.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.Estado.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.Cep.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.Telefone1.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(Me.Telefone2.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.Fone0800.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.Fax.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.Contato.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Email.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", Me.CartaoNatal.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", CodEmpresa))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@20", Me.Inativo.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@21", Nz(Me.Bairro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@22", Nz(Me.Observa��o.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@23", Nz(Me.EndCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@24", Nz(Me.CidCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@25", Nz(Me.UFCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@26", Nz(Me.BairroCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@27", Nz(Me.CepCorrespondencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@28", Nz(Me.Banco.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@29", Nz(Me.ContaCorrente.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@30", Nz(Me.AgenciaBancaria.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@31", Nz(Me.Nro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@32", Nz(Me.xCpl.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@33", Nz(Me.cMun.SelectedValue, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@34", Nz(Me.cPais.SelectedValue, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@35", Nz(Me.cPais.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@36", Nz(Me.cUF.SelectedValue, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@37", Nz(Me.Logradouro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@38", Nz(Me.DataAbertura.Text, 1)))


            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro Atualizado com sucesso", 64, "Valida��o de Dados")
                GerarLog(Me.Text, A��oTP.Editou, Me.C�digoFornecedor.Text)
            Catch x As Exception
                MsgBox(x.Message)
                Exit Sub
            End Try
            A��o.Desbloquear_Controle(Me, False)
        End If

    End Sub

    Private Sub EditarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarBT.Click
        If Edi = False Then
            MsgBox("O usu�rio n�o tem permiss�o para esta opera��o. Verifique.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        If Me.C�digoFornecedor.Text = "" Then
            MsgBox("No existe Fornecedor para ser editado.", 64, "Valida��o de Dados")
            Exit Sub
        End If
        Operation = UPD
        A��o.Desbloquear_Controle(Me, True)
        Me.C�digoFornecedor.Enabled = False
        Me.TipoFornecedor.Focus()
        Me.Inativo.Enabled = False
    End Sub

    Private Sub LocalizarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalizarBT.Click
        If Con = False Then
            MsgBox("O usu�rio n�o tem permiss�o para esta opera��o. Verifique.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        A��o.Desbloquear_Controle(Me, False)
        My.Forms.TelaProcuraFor.ShowDialog()

        If Me.C�digoFornecedor.Text <> "" Then
            LocalizaDados()
            Me.C�digoFornecedor.Enabled = False
            Me.TipoFornecedor.Focus()
            Me.Inativo.Enabled = False
        End If
    End Sub

    Public Sub LocalizaDados()
        Me.cMun.SelectedIndex = -1
        Me.cUF.SelectedIndex = -1
        Me.cPais.SelectedIndex = -1

        Dim Sql As String = "Select * from Fornecedor where C�digoFornecedor = " & Me.C�digoFornecedor.Text
        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Me.C�digoFornecedor.Text = DR.Item("C�digoFornecedor") & ""
            Me.TipoFornecedor.Text = DR.Item("TipoFornecedor") & ""
            Me.CgcCpf.Text = DR.Item("CgcCpf") & ""
            Me.Incri��oEstadual.Text = DR.Item("Incri��oEstadual") & ""
            Me.Raz�oSocial.Text = DR.Item("Raz�oSocial") & ""
            Me.NomeFantasia.Text = DR.Item("NomeFantasia") & ""
            Me.Endere�o.Text = DR.Item("Endere�o") & ""
            Me.Cidade.Text = DR.Item("Cidade") & ""
            Me.Estado.Text = DR.Item("Estado") & ""
            Me.Cep.Text = DR.Item("Cep") & ""
            Me.Telefone1.Text = DR.Item("Telefone1") & ""
            Me.Telefone2.Text = DR.Item("Telefone2") & ""
            Me.Fone0800.Text = DR.Item("Fone0800") & ""
            Me.Fax.Text = DR.Item("Fax") & ""
            Me.Contato.Text = DR.Item("Contato") & ""
            Me.Email.Text = DR.Item("Email") & ""
            Me.CartaoNatal.Checked = DR.Item("CartaoNatal")
            Me.Inativo.Checked = DR.Item("Inativo")

            Me.Bairro.Text = DR.Item("Bairro") & ""
            Me.Observa��o.Text = DR.Item("Observa��o") & ""

            Me.EndCorrespondencia.Text = DR.Item("EndCorrespondencia") & ""
            Me.CidCorrespondencia.Text = DR.Item("CidCorrespondencia") & ""
            Me.UFCorrespondencia.Text = DR.Item("UFCorrespondencia") & ""
            Me.BairroCorrespondencia.Text = DR.Item("BairroCorrespondencia") & ""
            Me.CepCorrespondencia.Text = DR.Item("CepCorrespondencia") & ""

            Me.Banco.Text = DR.Item("Banco") & ""
            Me.ContaCorrente.Text = DR.Item("ContaCorrente") & ""
            Me.AgenciaBancaria.Text = DR.Item("AgenciaBancaria") & ""

            Me.Nro.Text = DR.Item("Nro") & ""
            Me.xCpl.Text = DR.Item("xCpl") & ""
            Me.cUF.SelectedValue = DR.Item("cUF") & ""
            Me.cPais.SelectedValue = DR.Item("cPais") & ""
            EncheListaMunicipio()
            Me.cMun.SelectedValue = DR.Item("cMun") & ""
            Me.Logradouro.SelectedValue = DR.Item("Logradouro") & ""
            Me.DataAbertura.Text = DR.Item("DataAbertura") & ""


            Operation = UPD
        End If
    End Sub

    Private Sub CgcCpf_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CgcCpf.Enter
        If Me.TipoFornecedor.Text = "" Then
            Me.TipoFornecedor.Focus()
            Exit Sub
        End If


        If Me.TipoFornecedor.Text = "F" Then
            Me.CgcCpf.TpFormata��o = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cpf
        End If

        If Me.TipoFornecedor.Text = "J" Then
            Me.CgcCpf.TpFormata��o = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cnpj
        End If

        If Me.TipoFornecedor.Text = "G" Then
            Me.CgcCpf.TpFormata��o = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cnpj
            Me.CgcCpf.Text = "00.000.000/0000-00"
        End If

    End Sub

    Public Sub UltimoReg()
        'Inserir ultimo registro

        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader
        Dim Ult As Integer
        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "Select max(C�digoFornecedor) from Fornecedor"
            .CommandType = CommandType.Text
        End With
        Try
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
                Exit Sub
            End If
        End Try

        Me.C�digoFornecedor.Text = Ult + 1
        Me.C�digoFornecedor.Refresh()
        Me.TipoFornecedor.Focus()
        'fim inserir ultimo registro

    End Sub

    Private Sub ExcluirBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirBT.Click
        MsgBox("Esta op��o n�o esta disponivel nesta vers�o do sistema.", 64, "Valida��o de Dados")
        Exit Sub
    End Sub

    Public Sub AchaCPFCNPJ()

        Me.cUF.SelectedIndex = -1

        Dim Sql As String = "Select * from Fornecedor where CgcCpf = '" & Me.CgcCpf.Text & "' and Empresa = " & CodEmpresa
        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            MsgBox("Existe um Fornecedor com este CPF/CNPJ o sistema ira preencher os dados.", 64, "Valida��o de Dados")
            Me.C�digoFornecedor.Text = DR.Item("C�digoFornecedor") & ""
            Me.TipoFornecedor.Text = DR.Item("TipoFornecedor") & ""
            Me.CgcCpf.Text = DR.Item("CgcCpf") & ""
            Me.Incri��oEstadual.Text = DR.Item("Incri��oEstadual") & ""
            Me.Raz�oSocial.Text = DR.Item("Raz�oSocial") & ""
            Me.NomeFantasia.Text = DR.Item("NomeFantasia") & ""
            Me.Endere�o.Text = DR.Item("Endere�o") & ""
            Me.Cidade.Text = DR.Item("Cidade") & ""
            Me.Estado.Text = DR.Item("Estado") & ""
            Me.Cep.Text = DR.Item("Cep") & ""
            Me.Telefone1.Text = DR.Item("Telefone1") & ""
            Me.Telefone2.Text = DR.Item("Telefone2") & ""
            Me.Fone0800.Text = DR.Item("Fone0800") & ""
            Me.Fax.Text = DR.Item("Fax") & ""
            Me.Contato.Text = DR.Item("Contato") & ""
            Me.Email.Text = DR.Item("Email") & ""
            Me.CartaoNatal.Checked = DR.Item("CartaoNatal")

            Me.Bairro.Text = DR.Item("Bairro") & ""
            Me.Observa��o.Text = DR.Item("Observa��o") & ""

            Me.EndCorrespondencia.Text = DR.Item("EndCorrespondencia") & ""
            Me.CidCorrespondencia.Text = DR.Item("CidCorrespondencia") & ""
            Me.UFCorrespondencia.Text = DR.Item("UFCorrespondencia") & ""
            Me.BairroCorrespondencia.Text = DR.Item("BairroCorrespondencia") & ""
            Me.CepCorrespondencia.Text = DR.Item("CepCorrespondencia") & ""

            Me.Banco.Text = DR.Item("Banco") & ""
            Me.ContaCorrente.Text = DR.Item("ContaCorrente") & ""
            Me.AgenciaBancaria.Text = DR.Item("AgenciaBancaria") & ""

            Me.DataAbertura.Text = DR.Item("DataAbertura") & ""

            Me.Nro.Text = DR.Item("Nro") & ""
            Me.xCpl.Text = DR.Item("xCpl") & ""
            Me.cUF.SelectedValue = DR.Item("cUF") & ""
            Me.cPais.SelectedValue = DR.Item("cPais") & ""
            EncheListaMunicipio()
            Me.cMun.SelectedValue = DR.Item("cMun") & ""
            Me.Logradouro.SelectedValue = DR.Item("Logradouro") & ""
            Me.DataAbertura.Text = DR.Item("DataAbertura") & ""


            Operation = UPD
        Else
            Operation = INS
        End If
    End Sub

    Private Sub TeclasAtalho(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.F7 Then
            LocalizarBT_Click(sender, e)
        End If

        If e.KeyCode = Keys.F8 Then
            ExcluirBT_Click(sender, e)
        End If

        If e.KeyCode = Keys.F9 Then
            NovoBT_Click(sender, e)
        End If

        If e.KeyCode = Keys.F10 Then
            SalvarBT_Click(sender, e)
        End If

        If e.KeyCode = Keys.F11 Then
            EditarBT_Click(sender, e)
        End If

        If e.KeyCode = Keys.F12 Then
            FecharBT_Click(sender, e)
        End If

    End Sub

    Private Sub InativarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InativarBT.Click
        If Exc = False Then
            MsgBox("O usu�rio n�o tem permiss�o para esta opera��o. Verifique.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        Dim HH As DateTime = Now
        'Dim CodSeguran�a As String = InputBox("Favor informar o C�digo de Seguran�a.", "Valida��o de Dados", 0)

        Dim Autorizado As Boolean = PedirPermissao(Me.Text, Me.C�digoFornecedor.Text)
        Autorizado = varAutorizado
        If Autorizado = False Then
            Exit Sub

            'If VerificaCodigoSeguran�a(CodSeguran�a) = False Then
            '    MsgBox("C�digo de Seguran�a inv�lido, Verifique.", 64, "Valida��o de Dados")
            '    Exit Sub
        Else
            Me.Inativo.Checked = True
            SalvarBT_Click(sender, e)
        End If

    End Sub

    Private Sub Degrade()
        Try

            Dim Key As RegistryKey = Registry.LocalMachine
            Dim PegaKeyPadr�o As RegistryKey = Key.OpenSubKey("Software\\UPTema\\Tema")

            Cor1TelaPrimaria = PegaKeyPadr�o.GetValue("Cor1TelaPrimaria", " ")
            Cor2TelaPrimaria = PegaKeyPadr�o.GetValue("Cor2TelaPrimaria", " ")

            Cor1TelaSecundaria = PegaKeyPadr�o.GetValue("Cor1TelaSecundaria", " ")
            Cor2TelaSecundaria = PegaKeyPadr�o.GetValue("Cor2TelaSecundaria", " ")


            Dim CCor() As String
            Dim corTemp As String

            corTemp = Cor1TelaPrimaria
            CCor = corTemp.Split(";")
            Me.Fundo.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(CCor(0), Byte), Integer), CType(CType(CCor(1), Byte), Integer), CType(CType(CCor(2), Byte), Integer), CType(CType(CCor(3), Byte), Integer))

            corTemp = Cor2TelaPrimaria
            CCor = corTemp.Split(";")
            Me.Fundo.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(CCor(0), Byte), Integer), CType(CType(CCor(1), Byte), Integer), CType(CType(CCor(2), Byte), Integer), CType(CType(CCor(3), Byte), Integer))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Incri��oEstadual_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Incri��oEstadual.Enter, DataAbertura.Enter
        If Me.TipoFornecedor.Text = "F" Then
            Me.Incri��oEstadual.Text = "ISENTO"
        End If
    End Sub

    Private Sub NomeFantasia_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NomeFantasia.Enter
        If Me.NomeFantasia.Text = "" Then
            Me.NomeFantasia.Text = Me.Raz�oSocial.Text
        End If
    End Sub

    

    Private Sub cMun_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cMun.Enter
        If Me.cUF.Text = "" Then
            MessageBox.Show("O usu�rio deve informar a Uf do endere�o, favor verificar...", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cMun.Focus()
            Exit Sub
        End If

        If String.CompareOrdinal(cMun.Text, cMun.OldValue) Then
            Me.cMun.Text = ""
            EncheListaMunicipio()
        Else
            'EncheListaMunicipio()
        End If


    End Sub

    Private Sub cUF_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cUF.Validated
        If String.CompareOrdinal(cUF.OldValue, cUF.Text) = 1 Then
            cMun.Text = ""
            EncheListaMunicipio()
        Else
            cMun.Text = ""
            EncheListaMunicipio()
        End If

    End Sub

    Private Sub btForCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btForCli.Click
        If Me.CgcCpf.Text = "" Then
            MessageBox.Show("Para transformar um Fornecedor em Cliente � necessario Cpf/Cnpj.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Me.TipoFornecedor.Text = "F" Then
            If Len(Me.CgcCpf.Text) <> 14 Then
                MessageBox.Show("Quantidade de caracteres invalido.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            If Len(Me.CgcCpf.Text) <> 18 Then
                MessageBox.Show("Quantidade de caracteres invalido.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If


        Dim CNNCli As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNNCli.Open()


        Dim Sql As String = "Select * from Clientes where CpfCgc = '" & Me.CgcCpf.Text & "'"
        Dim CMD As New OleDb.OleDbCommand(Sql, CNNCli)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            MessageBox.Show("Este Fornecedor j� esta cadastrado como Cliente.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        DR.Close()



        Sql = "INSERT INTO Clientes (TipoPessoa, CpfCgc, Insc, Nome, NomeFantasia, Endere�o, Cidade, Bairro, Cep, cUF, Telefone, PessoaContato, Email, Observa��o, DataCadastro, Empresa, Nro, xCpl, cMun, Pais, Estado, Logradouro, Telefone1, Fax, tpComercio, Indfinal ) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20, @21, @22, @23, @24, @25,@26)"
        Dim cmdCli As New OleDb.OleDbCommand(Sql, CNNCli)

        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.TipoFornecedor.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.CgcCpf.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.Incri��oEstadual.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.Raz�oSocial.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.NomeFantasia.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.Endere�o.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@7", Me.cMun.Text))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.Bairro.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.Cep.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@10", Me.cUF.SelectedValue))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.Telefone1.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.Contato.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(Me.Email.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.Observa��o.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(CStr(DataDia), 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@16", CodEmpresa))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Nro.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.xCpl.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@19", Me.cMun.SelectedValue))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@20", Me.cPais.Text))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@21", Me.cUF.SelectedValue))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@22", Me.Logradouro.Text))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@23", Nz(Me.Telefone2.Text, 1)))
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@24", Nz(Me.Fax.Text, 1)))
        'criado 23/09/2014 para enviar para o cadastro de cliente com o tipo de comercio
        Dim tpComercio As String = "VAREJO"
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@25", tpComercio))
        Dim indfinal As String = "1"
        cmdCli.Parameters.Add(New OleDb.OleDbParameter("@26", indfinal))
        '
        Try
            cmdCli.ExecuteNonQuery()
            MsgBox("Fornecedor transformado em Cliente com sucesso", 64, "Valida��o de Dados")
            GerarLog(Me.Text, A��oTP.Adicionou, Me.CgcCpf.Text)
            CNNCli.Close()
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Valida��o de Dados")
        End Try



    End Sub
End Class