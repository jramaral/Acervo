'Imports System.IO
Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.ServiceModel

Public Class Clientes

    Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

    Dim Ação As New TrfGerais()
    Dim NovoReg As Boolean = False

    Private Operation As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2
    Const CON As Byte = 3
    Dim TeveAcao As Boolean = False
    Dim Autorizado As Boolean

    Private Sub FecharBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FecharBT.Click
        CNN.Close()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Clientes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim i As Decimal = 1
        'For i = 1 To 0 Step -0.01
        'Me.Opacity = i
        'Application.DoEvents()
        'Next
    End Sub

    Private Sub Clientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Dim isControlPressed As Boolean = (Control.ModifierKeys And Keys.Control) <> 0
        If isControlPressed = True Then
            If e.KeyCode = Keys.M Then
                Dim KeyReg As RegistryKey = Registry.LocalMachine.OpenSubKey("Software", True)
                Dim Key As RegistryKey = KeyReg.CreateSubKey("UP")
                Dim PKey As RegistryKey = Key.CreateSubKey("Auxiliares")

                Dim XProcuração As String = ""
                Dim XPropriedade As String = ""
                Dim XComplemento As String = ""
                Dim XOcorrencia As String = ""

                If MsgBox("Deseja usar o botão de Procuração no Cadastro de Clientes.", 36, "Validação de Dados") = 6 Then XProcuração = "SIM" Else XProcuração = "NÃO"
                If MsgBox("Deseja usar o botão de Propriedades no Cadastro de Clientes.", 36, "Validação de Dados") = 6 Then XPropriedade = "SIM" Else XPropriedade = "NÃO"
                If MsgBox("Deseja usar o botão de Complemento no Cadastro de Clientes.", 36, "Validação de Dados") = 6 Then XComplemento = "SIM" Else XComplemento = "NÃO"
                If MsgBox("Deseja usar o botão de Ocorrência no Cadastro de Clientes.", 36, "Validação de Dados") = 6 Then XOcorrencia = "SIM" Else XOcorrencia = "NÃO"

                PKey.SetValue("ClienteUsarProcuração", XProcuração)
                PKey.SetValue("ClienteUsarPropriedade", XPropriedade)
                PKey.SetValue("ClienteUsarComplemento", XComplemento)
                PKey.SetValue("ClienteUsarOcorrencia", XOcorrencia)

                LerRegistro()

            End If
        End If


    End Sub

    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CNN.Open()
        'LerRegistro()
        CarregaUF(Me.cUF)
        Ação.Desbloquear_Controle(Me, False)
    End Sub

    Private Sub EncheIndicadorConsumidorFinal()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "Select * From IndicadorConsumidorFinal Order by Codigo"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")


        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub NovoBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovoBT.Click
        Ação.LimpaTextBox(Me)

        Me.cUF.SelectedIndex = -1
        Me.cMun.SelectedIndex = -1
        Me.Vendedor.SelectedIndex = -1


        Ação.Desbloquear_Controle(Me, True)


        Me.MalaDiretaAniversariante.Checked = False
        Me.MalaDiretaNatal.Checked = False
       
        Me.Codigo.Enabled = False
        Me.Codigo.Text = "0000"
      

        Operation = INS

        My.Forms.ClienteCPFCNPJ.ShowDialog()
        AchaCPFCNPJ()

        Me.TipoPessoa.Focus()

        If Me.TipoPessoa.Text = "F" Then
            Me.LegendaDataNascimento.Text = "Dta. Nasc."
        Else
            Me.LegendaDataNascimento.Text = "Dta. Abertura"
        End If


    End Sub

    Private Function VerDebito() As Double
        If Me.Codigo.Text = "" Then
            Exit Function
        End If

        Dim CnnFind As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CnnFind.Open()


        Dim sql As String = "SELECT Receber.CodCliente AS Cliente, Sum(Receber.ValorDocumento) AS Total FROM(Receber) WHERE (((InStr(1,[Documento],'-C'))=0) AND ((Receber.Recebimento) Is Null) AND ((Receber.Baixado)=False) AND ((Receber.Empresa)=" & CodEmpresa & ")) GROUP BY Receber.CodCliente HAVING (((Receber.CodCliente)=" & Me.Codigo.Text & ")); UNION SELECT ArquivoCheque.Cliente, Sum(ArquivoCheque.ValorCh) AS Total FROM ArquivoCheque WHERE (((ArquivoCheque.DataBaixa) Is Null) AND ((ArquivoCheque.Empresa)=" & CodEmpresa & ")) GROUP BY ArquivoCheque.Cliente HAVING (((ArquivoCheque.Cliente)=" & Me.Codigo.Text & "));"

        Dim CMD As New OleDb.OleDbCommand(sql, CnnFind)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        Dim VlrDebito As Double = 0

        While DR.Read
            VlrDebito += NzZero(DR.Item("Total"))
        End While

        Return FormatNumber(NzZero(VlrDebito), 2)

        DR.Close()
        CnnFind.Close()
    End Function

    Private Sub SalvarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarBT.Click


        If Adi = False Then
            MsgBox("O usuário não tem permissão para esta operação. Verifique.", 64, "Validação de Dados")
            Exit Sub
        End If

        'Area destinada para as validacoes
        If Me.Codigo.Text = "" Then
            MsgBox("O Código do Cliente não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.Codigo.Focus()
            Exit Sub
        ElseIf Me.Nome.Text = "" Then
            MsgBox("O Nome do Cliente não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.Nome.Focus()
            Exit Sub
       
        ElseIf Me.NomeFantasia.Text = "" Then
            MsgBox("O Nome Fantasia do Cliente não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.NomeFantasia.Focus()
            Exit Sub
        ElseIf Me.TipoPessoa.Text = "" Then
            MsgBox("O Tipo do Cliente não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.TipoPessoa.Focus()
            Exit Sub
        
        ElseIf Me.Endereço.Text = "" Then
            MsgBox("O endereço não foi informado, verifique!!!", 64, "Validação de Dados")

            Exit Sub
        ElseIf Me.cUF.Text = "" Then
            MsgBox("A Unidade de Federação não foi informada, verifique", 64, "Validação de Dados")
            Me.cUF.Focus()
            Exit Sub
       
        ElseIf Me.Nro.Text = "" Then
            MsgBox("O Numero do endereço não foi informado, verifique!!!", 64, "Validação de Dados")
            Me.Nro.Focus()
            Exit Sub
        ElseIf Me.cMun.Text = "" Then
            MsgBox("O município não foi informado, verifique!!!", 64, "Validação de Dados")
            Me.cMun.Focus()
            Exit Sub
        ElseIf Me.Pais.Text = "" Then
            Me.Pais.Text = "BRASIL"
        ElseIf String.IsNullOrEmpty(Me.Cep.Text) Then
            MsgBox("O cep não foi informado, verifique!!!", 64, "Validação de Dados")
            Me.Cep.Focus()
            Exit Sub
        ElseIf Me.DataCadastro.Text = "" Then
            Me.DataCadastro.Text = Format(CDate(DataDia), "dd/MM/yyyy")

        End If

        If NaoValidarDocumento = False Then
            If Me.CpfCgc.Text = "" Then
                MsgBox("O Cpf/Cnpj do Cliente não foi informado, favor verificar.", 64, "Validação de Dados")
                Me.CpfCgc.Focus()
                Exit Sub
            End If
        End If
        'apresenta erro em alguns estados como BA - Salvador
        'Select Case TipoPessoa.Text
        '    Case "J"
        '        If ChecaInscrE(Me.cUF.Text, Me.Insc.Text) = False Then
        '            MsgBox("A Inscrição Estadual informada não é válida !!!", vbCritical, "Validação de Dados")
        '            Me.cUF.Focus()
        '            Exit Sub
        '        End If
        'End Select

        


        If TipoPessoa.Text = "F" Then
            If String.IsNullOrEmpty(Me.DataNascimento.Text) Then
                MsgBox("O usuário deve informar a data de nascimento do cliente.", 64, "Validação de Dados")
                DataNascimento.Focus()
                Exit Sub
            End If
        End If

        'Fim da Area destinada para as validacoes



        If Operation = INS Then

            UltimoReg()

            Dim Sql As String = "INSERT INTO Clientes (Codigo, TipoPessoa, CpfCgc, DataNascimento, Nome, NomeFantasia, Endereço, Cidade, Bairro, Cep, cUF, Telefone, Telefone1, Fax, Celular, " _
                               & "PessoaContato, Email, MotivoBloqueado, Observação, DataCadastro, MalaDiretaNatal, MalaDiretaAniversariante, Empresa, Nro, xCpl, " _
                               & "cMun, Pais, Estado, RG, Vendedor, DataEmissaoRG, Atualizado, Decorador) " _
                               & "VALUES (@1, @2, @4, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @21, @22, @23, @24, @25, @26, @29, @30, @31, @32, @33, @34, @35, @41, @44, @decorador)"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.Codigo.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.TipoPessoa.Text, 1)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.CpfCgc.Text, 1)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.DataNascimento.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.Nome.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.NomeFantasia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.Endereço.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", PegaVlrCombo(Me.cMun, TpRetornoCBO.Sim)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.Bairro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.Cep.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@13", PegaVlrCombo(Me.cUF, TpRetornoCBO.Não)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.Telefone.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.Telefone1.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.Fax.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Celular.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.PessoaContato.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", Nz(Me.Email.Text, 1)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@21", Nz(Me.MotivoBloqueado.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@22", Nz(Me.Observação.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@23", Nz(Me.DataCadastro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@24", Me.MalaDiretaNatal.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@25", Me.MalaDiretaAniversariante.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@26", CodEmpresa))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@29", Nz(Me.Nro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@30", Nz(Me.xCpl.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@31", PegaVlrCombo(Me.cMun, TpRetornoCBO.Não)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@32", Nz(Me.Pais.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@33", PegaVlrCombo(Me.cUF, TpRetornoCBO.Sim)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@34", Nz(Me.RG.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@35", NzZero(Me.Vendedor.SelectedValue)))
           
            cmd.Parameters.Add(New OleDb.OleDbParameter("@41", Nz(Me.DataEmissaoRG.Text, 1)))
            
            cmd.Parameters.Add(New OleDb.OleDbParameter("@44", True))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@decorador", Nz(Me.Decorador.Text, 1)))


            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro adicionado com sucesso", 64, "Validação de Dados")
                GerarLog(Me.Text, AçãoTP.Adicionou, Me.Codigo.Text)
                Operation = UPD
                NovoReg = False
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Validação de Dados")
            End Try
            Ação.Desbloquear_Controle(Me, False)

        ElseIf Operation = UPD Then


            Dim Sql As String = "Update Clientes set TipoPessoa = @3, CpfCgc = @5, DataNascimento = @7, Nome = @8, NomeFantasia = @9, Endereço = @10, Cidade = @11, " _
                              & "Bairro = @12, Cep = @13, cuf = @14, Telefone = @15, Telefone1 = @16, Fax = @17, Celular = @18, PessoaContato = @19, Email = @20, MotivoBloqueado = @22, " _
                              & "Observação = @23, DataCadastro = @24, MalaDiretaNatal = @25, MalaDiretaAniversariante = @26, Empresa = @27, Nro=@30, xCpl=@31, cMun=@32, " _
                              & "Pais=@33, Estado=@34, RG = @35, Vendedor = @36, DataEmissaoRG = @42, " _
                              & "Atualizado = @45, Decorador=@decorador Where Codigo = " & Me.Codigo.Text
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.TipoPessoa.Text, 1)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.CpfCgc.Text, 1)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.DataNascimento.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.Nome.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.NomeFantasia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.Endereço.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", PegaVlrCombo(Me.cMun, TpRetornoCBO.Sim)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.Bairro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(Me.Cep.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", PegaVlrCombo(Me.cUF, TpRetornoCBO.Não)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.Telefone.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.Telefone1.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Fax.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.Celular.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", Nz(Me.PessoaContato.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@20", Nz(Me.Email.Text, 1)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@22", Nz(Me.MotivoBloqueado.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@23", Nz(Me.Observação.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@24", Nz(Me.DataCadastro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@25", Me.MalaDiretaNatal.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@26", Me.MalaDiretaAniversariante.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@27", CodEmpresa))
            
            cmd.Parameters.Add(New OleDb.OleDbParameter("@30", Nz(Me.Nro.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@31", Nz(Me.xCpl.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@32", PegaVlrCombo(Me.cMun, TpRetornoCBO.Não)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@33", Nz(Me.Pais.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@34", PegaVlrCombo(Me.cUF, TpRetornoCBO.Sim)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@35", Nz(Me.RG.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@36", NzZero(Me.Vendedor.SelectedValue)))
           
            cmd.Parameters.Add(New OleDb.OleDbParameter("@42", Nz(Me.DataEmissaoRG.Text, 1)))
            
            cmd.Parameters.Add(New OleDb.OleDbParameter("@45", True))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@decorador", Nz(Me.Decorador.Text, 1)))
            

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro Atualizado com sucesso", 64, "Validação de Dados")
                GerarLog(Me.Text, AçãoTP.Editou, Me.Codigo.Text)
                Operation = UPD
            Catch x As Exception
                MsgBox(x.Message)
                Exit Sub
            End Try
            Ação.Desbloquear_Controle(Me, False)
        End If

    End Sub

    Private Sub EditarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarBT.Click
        If Edi = False Then
            MsgBox("O usuário não tem permissão para esta operação. Verifique.", 64, "Validação de Dados")
            Exit Sub
        End If

        If Me.Codigo.Text = "0000" Then
            MsgBox("No existe Clientes para ser editado.", 64, "Validação de Dados")
            Exit Sub
        End If

        If Me.Codigo.Text = "" Then
            MsgBox("No existe Clientes para ser editado.", 64, "Validação de Dados")
            Exit Sub
        End If

        Operation = UPD
        Ação.Desbloquear_Controle(Me, True)

        Me.Codigo.Enabled = False
        Me.TipoPessoa.Focus()
    End Sub

    Private Sub LocalizarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalizarBT.Click
        If CON = False Then
            MsgBox("O usuário não tem permissão para esta operação. Verifique.", 64, "Validação de Dados")
            Exit Sub
        End If

        Ação.Desbloquear_Controle(Me, False)
        RetornoProcura = ""
        My.Forms.ClientesProcura.ShowDialog()
        If Me.Codigo.Text <> "" Then
            LocalizaDados()
            Me.Codigo.Enabled = False
            Me.TipoPessoa.Focus()
            Operation = CON
        End If

    End Sub
    'Localizar clientes com criterios
    Public Sub LocalizaDados()
        Me.cMun.SelectedIndex = -1
        Me.cUF.SelectedIndex = -1
        If Me.Codigo.Text = "" Then
            Exit Sub
        End If
        'String para filtragem de clientes na base de dados
        Dim Sql As String = "SELECT Clientes.*, Clientes.Empresa, Municipio.NomeMunic, UF.NomeUF FROM (Clientes LEFT JOIN UF ON Clientes.cUF = UF.CodigoUF) LEFT JOIN Municipio ON Clientes.cMun = Municipio.CodMunicipio WHERE (((Clientes.Empresa)=" & CodEmpresa & ") AND ((Clientes.Codigo)=" & Me.Codigo.Text & "));"


        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()


        If DR.HasRows Then
            Me.Codigo.Text = DR.Item("Codigo") & ""
            Me.TipoPessoa.Text = DR.Item("TipoPessoa") & ""

            Me.CpfCgc.Text = DR.Item("CpfCgc") & ""
            Me.RG.Text = DR.Item("RG") & ""
            Me.DataEmissaoRG.Text = DR.Item("DataEmissaoRG") & ""

            Me.Nome.Text = DR.Item("Nome") & ""
            Me.NomeFantasia.Text = DR.Item("NomeFantasia") & ""
            Me.Endereço.Text = DR.Item("Endereço") & ""
            Me.Cidade.Text = DR.Item("Cidade") & ""
            Me.Bairro.Text = DR.Item("Bairro") & ""
            Me.xCpl.Text = DR.Item("xCpl") & ""
            Me.Nro.Text = DR.Item("Nro") & ""
            Me.Cep.Text = DR.Item("Cep") & ""
            Me.cUF.SelectedIndex = Me.cUF.FindStringExact(DR.Item("NomeUf") & "")
            MUNICIPIO_Preencher(Me.cUF, Me.cMun)
            Me.cMun.SelectedIndex = Me.cMun.FindStringExact(DR.Item("NomeMunic") & "")
            Me.Pais.Text = DR.Item("Pais") & ""
            Me.Telefone.Text = DR.Item("Telefone") & ""
            Me.Telefone1.Text = DR.Item("Telefone1") & ""
            Me.Fax.Text = DR.Item("Fax") & ""
            Me.Celular.Text = DR.Item("Celular") & ""
            Me.PessoaContato.Text = DR.Item("PessoaContato") & ""
            Me.Email.Text = DR.Item("Email") & ""

            Me.MotivoBloqueado.Text = DR.Item("MotivoBloqueado") & ""
            Me.Observação.Text = DR.Item("Observação") & ""
            Me.DataCadastro.Text = DR.Item("DataCadastro") & ""
            Me.DataNascimento.Text = DR.Item("DataNascimento") & ""
            Me.MalaDiretaNatal.Checked = DR.Item("MalaDiretaNatal")
            Me.MalaDiretaAniversariante.Checked = DR.Item("MalaDiretaAniversariante")
          
            Me.Vendedor.SelectedValue = DR.Item("Vendedor")
            Me.Decorador.Text = DR.Item("Decorador") & ""
           



            If Me.TipoPessoa.Text = "F" Then
                Me.LegendaDataNascimento.Text = "Dta. Nasc."
            Else
                Me.LegendaDataNascimento.Text = "Dta. Abertura"
            End If

        End If
        Operation = UPD
        DR.Close()
        
    End Sub

    Public Sub UltimoReg()
        'Inserir ultimo registro

        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader
        Dim Ult As Integer
        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "Select max(Codigo) from Clientes"
            .CommandType = CommandType.Text
        End With
        Try
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
                Exit Sub
            End If
        End Try

        Me.Codigo.Text = Ult + 1
        Me.Codigo.Refresh()
        Me.TipoPessoa.Focus()
        'fim inserir ultimo registro

    End Sub

    Private Sub PropriedadesBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropriedadesBT.Click

        If Me.Codigo.Text = "" Then
            MsgBox("O usuário deve selecionar um cliente primeiro para poder editar as propriedades.", 64, "Validação de Dados")
            Exit Sub

        End If

        If Operation = INS Then
            MsgBox("O usuário ainda não salvou o cliente para poder lançar as propriedades.", 64, "Validação de Dados")
            Exit Sub
        End If
        'Seta a estancia do form Propreedade e carrega o campo cliente e abre o form
        Dim F_Propriedade As New ClientesPropriedades
        F_Propriedade.Cliente.Text = Me.Codigo.Text
        F_Propriedade.ShowDialog()

    End Sub

    Private Sub NomeFantasia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NomeFantasia.Enter
        'Se o cammpo nome fantasdia foir nulo ou vazio copia os dados do campo razao socila limitando-o a 50 chars.(b)
        If String.IsNullOrEmpty(Me.NomeFantasia.Text) Then
            Me.NomeFantasia.Text = Mid(Me.Nome.Text & "", 1, 50)
        End If
    End Sub

    Public Sub ExcluirCliente()
        Dim TemPedido As Boolean = Ação.TemValor("CódigoCliente", "Pedido", Me.Codigo.Text, False, True)
        Dim TemConta As Boolean = Ação.TemValor("CodCliente", "Receber", Me.Codigo.Text, False, True)

        If TemPedido = False Then
            If TemConta = False Then
                'Rotina para excluir
                If MsgBox("O usuário tem certeza que deseja excluir o Cliente selecionado.", 36, "Validação de Dados") = 6 Then

                    Dim Sql As String = "Delete * from Clientes Where Codigo = " & Me.Codigo.Text
                    Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

                    Try
                        cmd.ExecuteNonQuery()
                        Operation = INS
                        Ação.LimpaTextBox(Me)
                    Catch ex As Exception
                        MsgBox(ex.Message, 64, "Validação de Dados")
                    End Try

                End If
            Else
                MsgBox("O Cliente Selecionado contem movimento não pode ser excluido.", 64, "Validação de Dados")
                Exit Sub
            End If
        Else
            MsgBox("O Cliente Selecionado contem movimento não pode ser excluido.", 64, "Validação de Dados")
            Exit Sub
        End If
    End Sub
    Public Sub AchaCPFCNPJ()


        If Me.Codigo.Text = "" Then
            Exit Sub
        End If

        Dim Sql As String = "SELECT Clientes.*, Clientes.CpfCgc, Clientes.Empresa, UF.NomeUF, Municipio.NomeMunic FROM (Clientes LEFT JOIN UF ON Clientes.cUF = UF.CodigoUF) LEFT JOIN Municipio ON Clientes.cMun = Municipio.CodMunicipio WHERE (((Clientes.CpfCgc)='" & Me.CpfCgc.Text & "') And Clientes.Inativo=false AND ((Clientes.Empresa)=" & CodEmpresa & "));"

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            MsgBox("Existe um Cliente com este CPF/CNPJ o sistema ira preencher os dados.", 64, "Validação de Dados")
            Me.cMun.SelectedIndex = -1
            Me.cUF.SelectedIndex = -1

            Me.Codigo.Text = DR.Item("Codigo") & ""
            Me.TipoPessoa.Text = DR.Item("TipoPessoa") & ""

            If Me.TipoPessoa.Text = "F" Then
                Me.CpfCgc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cpf
            Else
                Me.CpfCgc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cnpj
            End If

            Me.CpfCgc.Text = DR.Item("Clientes.CpfCgc") & ""

            Me.RG.Text = DR.Item("RG") & ""
            Me.Nome.Text = DR.Item("Nome") & ""
            Me.NomeFantasia.Text = DR.Item("NomeFantasia") & ""
            Me.Endereço.Text = DR.Item("Endereço") & ""
            Me.Cidade.Text = DR.Item("Cidade") & ""
            Me.Bairro.Text = DR.Item("Bairro") & ""
            Me.Cep.Text = DR.Item("Cep") & ""
            Me.cUF.SelectedIndex = Me.cUF.FindStringExact(DR.Item("NomeUf") & "")
            MUNICIPIO_Preencher(Me.cUF, Me.cMun)
            Me.cMun.SelectedIndex = Me.cMun.FindStringExact(DR.Item("NomeMunic") & "")
            Me.xCpl.Text = DR.Item("xCpl") & ""
            Me.Telefone.Text = DR.Item("Telefone") & ""
            Me.Telefone1.Text = DR.Item("Telefone1") & ""
            Me.Fax.Text = DR.Item("Fax") & ""
            Me.Celular.Text = DR.Item("Celular") & ""
            Me.PessoaContato.Text = DR.Item("PessoaContato") & ""
            Me.Email.Text = DR.Item("Email") & ""

            Me.MotivoBloqueado.Text = DR.Item("MotivoBloqueado") & ""
            ' Me.Vendedor.Text = DR.Item("Vendedor") & ""
            Me.DataEmissaoRG.Text = DR.Item("DataEmissaoRg") & ""
          
            Me.DataNascimento.Text = DR("DataNascimento") & ""
            Me.Observação.Text = DR.Item("Observação") & ""
            Me.DataCadastro.Text = DR.Item("DataCadastro") & ""
            Me.MalaDiretaNatal.Checked = DR.Item("MalaDiretaNatal")
            Me.MalaDiretaAniversariante.Checked = DR.Item("MalaDiretaAniversariante")
            Me.Nro.Text = DR.Item("Nro") & ""
            Me.Pais.Text = DR.Item("Pais") & ""
           
            Operation = UPD
            Ação.Desbloquear_Controle(Me, False)
        Else
            Operation = INS
        End If
        DR.Close()


    End Sub

    Private Sub ExcluirBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirBT.Click
        MsgBox("Opção Indisponivel, verifique com o Administrador.", 64, "Validação de Dados")
        Exit Sub
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Opção indisponivel, verifique com o administrador.", 64, "Validação de Dados")
    End Sub

    Private Sub ComplementoBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComplementoBT.Click
        If Me.Codigo.Text = "" Then
            Exit Sub
        End If
        My.Forms.ClienteComplemento.ShowDialog()
    End Sub

    Private Sub BTOcorrencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTOcorrencia.Click
        If Me.Codigo.Text = "" Then
            Exit Sub
        End If
        RetornoProcura = Me.Codigo.Text
        My.Forms.ClienteCr.ShowDialog()

    End Sub

    Private Sub BTProcuração_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.Codigo.Text = "" Then
            MsgBox("Não foi informado o cliente para emitir uma procuração.", 64, "Validação de Dados")
            Exit Sub
        End If
        My.Forms.ClientesProcurador.ShowDialog()
    End Sub

    Private Sub LerRegistro()
        Dim Key As RegistryKey = Registry.LocalMachine

        Try
            Dim PegaKey As RegistryKey = Key.OpenSubKey("Software\\UP\\Auxiliares")
            If PegaKey.GetValue("ClienteUsarComplemento", "NÃO") = "SIM" Then Me.ComplementoBT.Visible = True Else Me.ComplementoBT.Visible = False
            If PegaKey.GetValue("ClienteUsarPropriedade", "NÃO") = "SIM" Then Me.PropriedadesBT.Visible = True Else Me.PropriedadesBT.Visible = False
            If PegaKey.GetValue("ClienteUsarOcorrencia", "NÃO") = "SIM" Then Me.BTOcorrencia.Visible = True Else Me.BTOcorrencia.Visible = False
        Catch ex As Exception
            Me.ComplementoBT.Visible = False

            Me.PropriedadesBT.Visible = False
            Me.BTOcorrencia.Visible = False
        End Try

    End Sub



#Region "Ação para as combos"

    Private Sub CarregaUF(ByVal Controle As CBOAutoCompleteFocus.CboFocus)
        Dim i As Integer
        For i = 0 To UFArray.Count - 1
            Controle.Items.Add(New cboItemData(UFArray(i).Valor, UFArray(i).Descrição))
        Next
    End Sub

    Private Sub MUNICIPIO_Preencher(ByVal ControleUF As CBOAutoCompleteFocus.CboFocus, ByVal ControleMunicipio As CBOAutoCompleteFocus.CboFocus)
        If ControleUF.Text = "" Then
            ControleMunicipio.Items.Clear()
            Exit Sub
        End If

        ControleMunicipio.Items.Clear()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "SELECT * FROM Municipio where UF = '" & CType(ControleUF.SelectedItem, cboItemData).ItemData & "' order by NomeMunic"
        Dim Cmd As New OleDb.OleDbCommand(Sql, Cnn)
        Dim DR As OleDb.OleDbDataReader

        Try
            DR = Cmd.ExecuteReader
            While DR.Read
                ControleMunicipio.Items.Add(New cboItemData(DR.Item("CodMunicipio"), DR.Item("NomeMunic")))
            End While
            DR.Close()

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                Cnn.Close()
                Exit Sub
            End If
        End Try
        Cnn.Close()

    End Sub

    Private Enum TpRetornoCBO
        Não = 0
        Sim = 1
    End Enum

    Private Function PegaVlrCombo(ByVal Cbo As CBOAutoCompleteFocus.CboFocus, ByVal Retorna_Descrição As TpRetornoCBO)

        Dim Retorno As String = ""
        If Cbo.Text = "" Then
            Retorno = ""

        Else
            Cbo.SelectedIndex = Cbo.FindStringExact(Cbo.Text & "")
            If Retorna_Descrição = TpRetornoCBO.Não Then
                Retorno = CType(Cbo.SelectedItem, cboItemData).ItemData
            Else
                Retorno = CType(Cbo.SelectedItem, cboItemData).Name
            End If
        End If
        Return Retorno

    End Function

#End Region



    Private Sub cUF_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cUF.Leave
        If String.CompareOrdinal(cUF.OldValue, cUF.Text) = 1 Then
            cMun.Text = ""
            MUNICIPIO_Preencher(Me.cUF, Me.cMun)
        Else
            MUNICIPIO_Preencher(Me.cUF, Me.cMun)
        End If

    End Sub

    Private Sub cMun_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cMun.Enter
        If String.CompareOrdinal(cMun.Text, cMun.OldValue) Then
            Me.cMun.Text = ""
        Else
            MUNICIPIO_Preencher(Me.cUF, Me.cMun)
        End If
    End Sub

    Private Sub Pais_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pais.Enter
        If Me.Pais.Text = String.Empty Then
            Me.Pais.Text = "BRASIL"

        End If
    End Sub
    Private Sub UsaSubstitucaoTributaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub CpfCgc_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CpfCgc.Enter
        If Me.TipoPessoa.Text = "" Then
            Me.TipoPessoa.Focus()
            Exit Sub
        End If
        If Me.TipoPessoa.Text = "F" Then
            If NaoValidarDocumento = False Then Me.CpfCgc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cpf
            If NaoValidarDocumento = True Then Me.CpfCgc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.CpfLivre
        Else
            If NaoValidarDocumento = False Then Me.CpfCgc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cnpj
            If NaoValidarDocumento = True Then Me.CpfCgc.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.CnpjLivre

        End If
    End Sub
    Private Sub CpfCgc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CpfCgc.Leave
        If Operation = INS Then
            AchaCPFCNPJ()
        End If
    End Sub



    Private Sub cMun_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cMun.Leave
        If Me.Cidade.Text = String.Empty Then
            Me.Cidade.Text = Me.cMun.Text
        Else
            Me.Cidade.Text = Me.cMun.Text
        End If

    End Sub

    Private Sub TipoPessoa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoPessoa.Leave
        If Me.TipoPessoa.Text = "F" Then
            Me.RG.Enabled = True
        Else
            Me.RG.Enabled = False
        End If
    End Sub
    Private Sub EncheListaVendedor()

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "Select Funcionários.CódigoFuncionário, Funcionários.Nome From Funcionários  Where Funcionários.Empresa = " & CodEmpresa & " And Funcionários.AdicionarEmVendas = True Order by Funcionários.Nome"

        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Vendedor.DataSource = ds.Tables("Table").DefaultView
        Me.Vendedor.DisplayMember = "Nome"
        Me.Vendedor.ValueMember = "CódigoFuncionário"
        Me.Vendedor.SelectedValue = -1

        da.Dispose()
        Cnn.Close()

    End Sub

#Region "Cliente para Fornecedor"

    Private Sub btCliFor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCliFor.Click

        If Me.CpfCgc.Text = "" Then
            MessageBox.Show("Para transformar um Cliente em Fornecedor é necessario Cpf/Cnpj.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim CNNFor As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNNFor.Open()


        Dim Sql As String = "Select * from Fornecedor where CgcCpf = '" & Me.CpfCgc.Text & "'"
        Dim CMD As New OleDb.OleDbCommand(Sql, CNNFor)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            MessageBox.Show("Este Cliente ja esta cadastrado como Fornecedor.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        DR.Close()


        Dim Ult As Integer = UltimoRegFornecedor()
        Sql = "INSERT INTO Fornecedor (CódigoFornecedor, TipoFornecedor, CgcCpf, IncriçãoEstadual, RazãoSocial, NomeFantasia, Endereço, Cidade, Estado, Cep , Telefone1, Telefone2, Fone0800, Fax, Contato, Email, CartaoNatal, Empresa, Inativo, Bairro, Observação, cUF, nro, Logradouro, cMun, xPais, cPais) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20, @21, @22, @23, @24, @25, @26, @27)"
        Dim CmdFor As New OleDb.OleDbCommand(Sql, CNNFor)

        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@1", Ult))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.TipoPessoa.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.CpfCgc.Text, 1)))

        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.Nome.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.NomeFantasia.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.Endereço.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.Cidade.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.cUF.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.Cep.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.Telefone1.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@12", System.DBNull.Value))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@13", System.DBNull.Value))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.Fax.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@15", Nz(Me.PessoaContato.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.Email.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@17", Me.MalaDiretaNatal.Checked))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@18", CodEmpresa))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@19", False))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@20", Nz(Me.Bairro.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@21", Nz(Me.Observação.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@22", PegaVlrCombo(Me.cUF, TpRetornoCBO.Não)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@23", Nz(Me.Nro.Text, 1)))

        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@25", PegaVlrCombo(Me.cMun, TpRetornoCBO.Não)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@26", Nz(Me.Pais.Text, 1)))
        CmdFor.Parameters.Add(New OleDb.OleDbParameter("@27", Nz("1058", 1)))

        Try
            CmdFor.ExecuteNonQuery()
            MsgBox("Cliente transformado em Fornecedor com sucesso", 64, "Validação de Dados")
        Catch ex As Exception
            MsgBox(ex.Message, 64, "Validação de Dados")
        End Try

        CNNFor.Close()
    End Sub

    Public Function UltimoRegFornecedor()
        'Inserir ultimo registro

        Dim CNNFor As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNNFor.Open()

        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader
        Dim Ult As Integer
        With Cmd
            .Connection = CNNFor
            .CommandTimeout = 0
            .CommandText = "Select max(CódigoFornecedor) from Fornecedor"
            .CommandType = CommandType.Text
        End With
        Try
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
                Return 1
                Exit Function
            End If
        End Try

        Return (Ult + 1)
        'fim inserir ultimo registro

    End Function
#End Region


    Private Sub IsentoInscricao_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub btnImprimirficha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirficha.Click
        Try
            Dim Conect As New DataDynamics.ActiveReports.DataSources.OleDBDataSource
            Conect.ConnectionString = New Conectar().ConectarBD(LocalBD & Nome_BD)

            Conect.SQL = "Select * from clientes where codigo=" & Me.Codigo.Text

            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()
            'Dim oDA As New OleDb.OleDbDataAdapter("Select * from empresa", CNN)
            'Dim oDs As New DataSet
            'oDA.Fill(oDs, "T1")

            Dim rpt As New RelFichaCadastral
            rpt.DataSource = Conect
            'rpt.T1.Text = oDs.Tables(0).Rows(0).Item("razãosocial")


            ViewReport.VerRelat.Document = rpt.Document
            rpt.Run()
            ViewReport.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btRota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRota.Click
        My.Forms.WebGoogleMaps.Dest = Me.Endereço.Text & "," & Me.Nro.Text & "," & Me.Bairro.Text & "," & Me.cMun.Text & "," & Me.cUF.Text
        My.Forms.WebGoogleMaps.ShowDialog()
    End Sub

    Private Sub Endereço_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Endereço.KeyPress
        If e.KeyChar = ";" Then
            e.KeyChar = ":"
        ElseIf e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub

    Private Sub btnCrediarioBloqueio_Click(sender As Object, e As EventArgs)


        Dim cmd As New OleDbCommand("SELECT Pedido.PedidoSequencia FROM Pedido WHERE (((Pedido.Confirmado)=False) AND ((Pedido.Inativo)=False) AND ((Pedido.CódigoCliente)=" & Me.Codigo.Text & "))", CNN)
        Dim dr As OleDbDataReader = cmd.ExecuteReader()

        dr.Read()
        If dr.HasRows Then
            MessageBox.Show("Você não pode fazer alterção neste momento, pois" _
                & Microsoft.VisualBasic.ControlChars.CrLf & "" _
                & Microsoft.VisualBasic.ControlChars.CrLf & "existem pedidos em aberto para este cliente.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If



        Dim FoiConfirmado As Boolean = False
        Autorizado = PedirPermissao(Me.Text, Me.Codigo.Text)
        Autorizado = varAutorizado
        If Autorizado = False Then
            Exit Sub
        End If

        GerarLog(Me.Text, AçãoTP.Editou, Me.Codigo.Text)
    End Sub

    Private Sub PictureBox_Click(sender As Object, e As EventArgs) Handles PictureBox.Click

        'Rotima para consultar webservice conrreios

        Try
            Dim consulta As New Correios.AtendeClienteClient("AtendeClientePort")

            Dim resultado As Object = consulta.consultaCEP(Me.Cep.Text)

            If Not IsDBNull(resultado) Then
                Me.Endereço.Text = resultado.end
                Me.Bairro.Text = resultado.bairro
                Me.cUF.Text = resultado.uf
                Me.cMun.Text = resultado.cidade
                Me.Cidade.Text = resultado.cidade

                cUF_Leave(sender, e)

            End If

        Catch ex As FaultException
            MessageBox.Show("CEP NÃO ENCONTRADO OU INVALIDO.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cep.Clear()
            Cep.Focus()

        Catch ex As EndpointNotFoundException
            MessageBox.Show("Não foi possivel completar a operação\nVerifique sua conexão com a internet.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cep.Clear()

        End Try
    End Sub
End Class