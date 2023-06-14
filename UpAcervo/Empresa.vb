Imports System.IO
Public Class Empresa

    Dim CaminhoImagem As String = ""

    Dim Ação As New TrfGerais()

    Private Operation As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2

    Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

    Private Sub FecharBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FecharBT.Click
        CNN.Close()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub NovoBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovoBT.Click
        Ação.LimpaTextBox(Me)
        Ação.Desbloquear_Controle(Me, True)
        Me.CódigoEmpresa.Enabled = False
        Me.CódigoEmpresa.Text = "0000"
        Me.RazãoSocial.Focus()
        Operation = INS
    End Sub

    Private Sub SalvarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarBT.Click
        'Area destinada para as validacoes
        If Me.CódigoEmpresa.Text = "" Then
            MsgBox("O Código da Empresa não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.CódigoEmpresa.Focus()
            Exit Sub
        ElseIf Me.RazãoSocial.Text = "" Then
            MsgBox("A Razão Social da empresa não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.RazãoSocial.Focus()
            Exit Sub
        ElseIf Me.NomeFantasia.Text = "" Then
            MsgBox("O Nome Fantasia da Empresa não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.NomeFantasia.Focus()
            Exit Sub
        ElseIf Me.InçriçãoEstadual.Text = "" Then
            MsgBox("A Inscrição estadual da empresa não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.InçriçãoEstadual.Focus()
            Exit Sub
        ElseIf Me.Cgc.Text = "" Then
            MsgBox("O Cnpj da Empresa não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.Cgc.Focus()
            Exit Sub
        ElseIf Me.Estado.Text = "" Then
            MsgBox("A UF da Empresa não foi informado, favor verificar.", 64, "Validação de Dados")
            Me.Estado.Focus()
            Exit Sub
        End If

        'Fim da Area destinada para as validacoes

        If Operation = INS Then

            UltimoReg()

            Dim Sql As String = "INSERT INTO Empresa (CódigoEmpresa, Cgc, InçriçãoEstadual, RazãoSocial, NomeFantasia, Endereço, Cidade, Estado, Telefone, Mensagem, EsquemaTS, Cep, email, numero,bairro, site, codCRT) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12,@13, @14,@15,@16,@17,@18, @19)"
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.CódigoEmpresa.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Cgc.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.InçriçãoEstadual.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.RazãoSocial.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.NomeFantasia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.Endereço.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.Cidade.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.Estado.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.Telefone.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.Mensagem.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", Me.EsquemaTS.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.CEP.Text, 1)))
            cmd.Parameters.AddWithValue("@13", Nz(txtemail.Text, 1))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.txtNumero.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", CType(cMun.SelectedItem, cboItemData).ItemData))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", nzNUL(Me.IM.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", nzNUL(Me.txtbairro.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", nzNUL(Me.txtSite.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", CType(cboTipoTributacao.SelectedItem, cboItemData).ItemData))


            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro adicionado com sucesso", 64, "Validação de Dados")
                GerarLog(Me.Text, AçãoTP.Adicionou, Me.CódigoEmpresa.Text)
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Validação de Dados")
            End Try
            Ação.Desbloquear_Controle(Me, False)

        ElseIf Operation = UPD Then

            Dim Sql As String = "Update Empresa set Cgc = @2, InçriçãoEstadual = @3, RazãoSocial = @4, NomeFantasia = @5, Endereço = @6, Cidade = @7, Estado = @8, Telefone = @9, Mensagem = @10, EsquemaTS = @11, Cep = @12, email=@13, Numero = @14, COD_MUN=@15, IM=@16,Bairro=@17, site=@18, CodCRT=@19 Where CódigoEmpresa = " & Me.CódigoEmpresa.Text
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Cgc.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.InçriçãoEstadual.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.RazãoSocial.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.NomeFantasia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.Endereço.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.Cidade.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.Estado.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.Telefone.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.Mensagem.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", Me.EsquemaTS.Checked))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.CEP.Text, 1)))
            cmd.Parameters.AddWithValue("@13", Nz(txtemail.Text, 1))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.txtNumero.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", CType(cMun.SelectedItem, cboItemData).ItemData))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", nzNUL(Me.IM.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", nzNUL(Me.txtbairro.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", nzNUL(Me.txtSite.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", CType(cboTipoTributacao.SelectedItem, cboItemData).ItemData))

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro Atualizado com sucesso", 64, "Validação de Dados")
                GerarLog(Me.Text, AçãoTP.Editou, Me.CódigoEmpresa.Text)
            Catch x As Exception
                MsgBox(x.Message)
                Exit Sub
            End Try
            Ação.Desbloquear_Controle(Me, False)

        End If

    End Sub

    Private Sub EditarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarBT.Click
        If Me.CódigoEmpresa.Text = "" Then
            MsgBox("No existe Empresa para ser editado.", 64, "Validação de Dados")
            Exit Sub
        End If
        Operation = UPD
        Ação.Desbloquear_Controle(Me, True)
        Me.CódigoEmpresa.Enabled = False
        Me.RazãoSocial.Focus()
    End Sub

    Private Sub LocalizarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalizarBT.Click
        Ação.Desbloquear_Controle(Me, False)
        ChamaTelaProcura("Codigo", "Razão Social", "", "Empresa", "CódigoEmpresa", "RazãoSocial", "", False)
        Me.CódigoEmpresa.Text = RetornoProcura
        If Me.CódigoEmpresa.Text <> "" Then
            LocalizaDados()

            Me.CódigoEmpresa.Enabled = False
            Me.RazãoSocial.Focus()
        End If
    End Sub

    Public Sub LocalizaDados()
        Try
            Dim Sql As String = "Select * from Empresa where CódigoEmpresa = " & Me.CódigoEmpresa.Text
            Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
            Dim DR As OleDb.OleDbDataReader

            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                Me.CódigoEmpresa.Text = DR.Item("CódigoEmpresa") & ""
                Me.Cgc.Text = DR.Item("Cgc") & ""
                Me.InçriçãoEstadual.Text = DR.Item("InçriçãoEstadual") & ""
                Me.RazãoSocial.Text = DR.Item("RazãoSocial") & ""
                Me.NomeFantasia.Text = DR.Item("NomeFantasia") & ""
                Me.Endereço.Text = DR.Item("Endereço") & ""
                Me.Cidade.Text = DR.Item("Cidade") & ""
                Me.Estado.Text = DR.Item("Estado") & ""
                Me.Telefone.Text = DR.Item("Telefone") & ""
                Me.Mensagem.Text = DR.Item("Mensagem") & ""
                Me.EsquemaTS.Checked = DR.Item("EsquemaTS") & ""
                Me.CEP.Text = DR.Item("Cep") & ""
                Me.txtemail.Text = DR.Item("email").ToString()
                Me.txtNumero.Text = DR.Item("Numero").ToString()
                Me.cUF.Text = Me.Estado.Text
                MUNICIPIO_Preencher(Me.cUF, Me.cMun)
                Me.cMun.SelectedIndex = Me.cMun.FindStringExact(Me.Cidade.Text)
                Me.IM.Text = DR.Item("IM").ToString()
                Me.txtbairro.Text = DR.Item("Bairro").ToString()
                Me.txtSite.Text = DR.Item("Site") & ""
                Me.cboTipoTributacao.SelectedIndex = Me.cboTipoTributacao.FindString(DR.Item("CodCRT") & "")


            End If

            Operation = UPD
            DR.Close()
            VisualizaFoto()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ATENÇÃO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
       
    End Sub

    Public Sub UltimoReg()
        'Inserir ultimo registro
        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader
        Dim Ult As Integer
        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "Select max(CódigoEmpresa) from Empresa"
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
        CNN.Close()

        Me.CódigoEmpresa.Text = Ult + 1
        Me.CódigoEmpresa.Refresh()
        Me.RazãoSocial.Focus()
        'fim inserir ultimo registro

    End Sub

    Private Sub CapSalvaImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapSalvaImg.Click
        Dim OpenFileDialog1 As New OpenFileDialog()
        OpenFileDialog1.Filter = "(Jpeg Files) *.jpg | *.jpg"
        OpenFileDialog1.Title = "Selecione um arquivo JPG para inserir no campo Foto"
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName <> "" Then
            CaminhoImagem = OpenFileDialog1.FileName
            SalvaFoto()
            VisualizaFoto()
            'MsgBox("A imagem foi capturada, utilize o botão salvar para armazenar no banco de dados", 64, "Validação de Dados")
            Exit Sub
        End If

    End Sub

    Public Sub SalvaFoto()
        If Me.CódigoEmpresa.Text = "" Then
            MsgBox("Não pode selecionar uma foto sem uma empresa pré-Salva.", 64, "Validação de Dados")
            Exit Sub
        End If

        Dim arqImg As FileStream
        Dim rImg As StreamReader

        If Len(CaminhoImagem) <> 0 Then
            arqImg = New FileStream(CaminhoImagem, FileMode.Open, FileAccess.Read, FileShare.Read)
            rImg = New StreamReader(arqImg)
        Else
            MsgBox("Defina uma foto para inserir no Banco de dados.", 64, "Validação de Dados")
            Exit Sub
        End If

        Dim Cmd As New OleDb.OleDbCommand("Update Empresa Set Foto = ? where CódigoEmpresa = " & Me.CódigoEmpresa.Text, CNN)

        Try
            'declaramos um vetor de bytes para armazenar o conteúdo da imagem a ser salva
            Dim arqByteArray(arqImg.Length - 1) As Byte
            arqImg.Read(arqByteArray, 0, arqImg.Length)

            Cmd.Parameters.Add("@Foto", OleDb.OleDbType.Binary, arqImg.Length).Value = arqByteArray

            'Cmd.Connection.Open()
            Cmd.ExecuteNonQuery()

            MsgBox("Imagem incluida com sucesso !", 64, "Validação de Dados")

        Catch Ex As Exception
            MsgBox(Ex.Message, 64, "Validação de Dados")
        End Try

    End Sub

    Public Sub VisualizaFoto()

        Try
            'command para pegar os dados
            Dim Cmd As New OleDb.OleDbCommand("SELECT * From Empresa where CódigoEmpresa = " & Me.CódigoEmpresa.Text, CNN)
            'dataadapter para fazer a ligação dos dados
            Dim Da As New OleDb.OleDbDataAdapter(Cmd)
            'dataset para guardar em memória os dados
            Dim Ds As New DataSet()
            'preenche dataset com a tabela "ProdutosFotos"
            Da.Fill(Ds, "Empresa")
            'variavel para recebe a quantidade de linhas da tabela retornada
            Dim c As Integer = Ds.Tables(0).Rows.Count
            If c > 0 Then
                'array recebe a última linha do dataset, a imagem
                Dim ByteData() As Byte = Ds.Tables(0).Rows(c - 1).Item("Foto")
                'stream em memória recebe a imagem
                Dim ImgVer As New MemoryStream(ByteData)
                'a picturebox recebe imagem que usa o método FromStream para "ler" a stream que contém a imagem

                'Compara tamanhos para fazer ajustes no quadro de visualização
                Me.Display.Visible = True
                Me.Display.Image = Image.FromStream(ImgVer)
            End If
        Catch err As Exception
            Me.Display.Visible = False
        Finally
            'fecha a conexão
        End Try

    End Sub

    Private Sub Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Ação.Desbloquear_Controle(Me, False)
        CNN.Open()
        CarregaUF(Me.cUF)
        CODREGIME_Preencher(Me.cboTipoTributacao)

    End Sub
    Private Sub CarregaUF(ByVal Controle As CBOAutoCompleteFocus.CboFocus)
        Dim i As Integer
        For i = 0 To ufArray.Count - 1
            Controle.Items.Add(New cboItemData(ufArray(i).Valor, ufArray(i).Descrição))
        Next
    End Sub

    Private Sub ConfBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfBT.Click
        If Me.CódigoEmpresa.Text = "" Then
            MessageBox.Show("Não existe empresa para definir as configurações.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        My.Forms.EmpresaConfiguracao.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Me.CódigoEmpresa.Text = "" Then
            MessageBox.Show("Não existe empresa para definir as configurações.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        My.Forms.EmpresaDiaTrabalho.ShowDialog()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, Label5.Click, Label14.Click

    End Sub

    Private Sub cUF_Leave(sender As Object, e As EventArgs) Handles cUF.Leave
        If String.CompareOrdinal(cUF.OldValue, cUF.Text) = 1 Then
            cMun.Text = ""
            MUNICIPIO_Preencher(Me.cUF, Me.cMun)
        Else
            MUNICIPIO_Preencher(Me.cUF, Me.cMun)
        End If
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
    Private Sub CODREGIME_Preencher(ByVal ControleREGIME As CBOAutoCompleteFocus.CboFocus)
        If ControleREGIME.Text = "" Then
            ControleREGIME.Items.Clear()
        End If

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "SELECT * FROM CodCRT"
        Dim Cmd As New OleDb.OleDbCommand(Sql, Cnn)
        Dim DR As OleDb.OleDbDataReader

        Try
            DR = Cmd.ExecuteReader
            While DR.Read
                ControleREGIME.Items.Add(New cboItemData(DR.Item("codCRT"), DR.Item("codCRT") & " - " & DR.Item("DescricaoCRT")))
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

    Private Sub cMun_Enter(sender As Object, e As EventArgs) Handles cMun.Enter
        If String.CompareOrdinal(cMun.Text, cMun.OldValue) Then
            Me.cMun.Text = ""
        Else
            MUNICIPIO_Preencher(Me.cUF, Me.cMun)
        End If
    End Sub

    Private Sub cMun_Leave(sender As Object, e As EventArgs) Handles cMun.Leave
        If Me.Cidade.Text = String.Empty Then
            Me.Cidade.Text = Me.cMun.Text
        Else
            Me.Cidade.Text = Me.cMun.Text
        End If
    End Sub

End Class