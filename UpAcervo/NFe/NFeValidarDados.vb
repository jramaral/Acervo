Imports System.Data.OleDb
Imports System.IO


Imports System.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports Microsoft.Win32


Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports


Public Class NFeValidarDados

    Dim IdEmitente As String
    Dim confINICIAL As String

    Dim Ped As Integer
    Public Property NumeroPedido() As Integer
        Get
            Return Ped
        End Get
        Set(ByVal Value As Integer)
            Ped = Value
        End Set
    End Property

    Dim Cli As Integer
    Public Property CodigoCliente() As Integer
        Get
            Return Cli
        End Get
        Set(ByVal Value As Integer)
            Cli = Value
        End Set
    End Property



    Dim QtdProd As Double
    Public Property QuantidadeProdutoEmitir() As Double
        Get
            Return QtdProd
        End Get
        Set(ByVal Value As Double)
            QtdProd = Value
        End Set
    End Property


    'Variaveis para geração da NFe Dados
    Dim StatusNFe As Object
    Dim VersaoXml As Object
    Dim verProc As Object
    Dim tpAmb As Object
    Dim procEmi As Object
    Dim modelo As Object
    Dim serie As Object
    Dim natOp As Object
    Dim tpNF As Object
    Dim tpImp As Object
    Dim indPag As Object
    Dim tpEmis As Object
    Dim finNfe As Object
    Dim cUF As Object
    Dim cMunFG As Object
    Dim AutenticadorNFe As Object
    Dim cNF As Object
    Dim cDv As Object
    Dim Chave_Acesso As String
    Dim nNF As Integer

    Dim DigestValue As Object

    Dim dEmi As Object
    Dim dSaiEnt As Object


    'Variaveis para Dados do Emitente
    Dim Emi_CNPJ As Object
    Dim Emi_IE As Object
    Dim Emi_IEstST As Object
    Dim Emi_IMunic As Object
    Dim Emi_CNAE As Object
    Dim Emi_Razao As Object
    Dim Emi_Fantasia As Object
    Dim Emi_Logradouro As Object
    Dim Emi_Nro As Object
    Dim Emi_Complemento As Object
    Dim Emi_Bairro As Object
    Dim Emi_Cep As Object
    Dim Emi_Telefone As Object
    Dim Emi_UF As Object
    Dim Emi_xUF As Object
    Dim Emi_Municipio As Object
    Dim Emi_Pais As Object
    Dim Emi_cPais As Object
    Dim Emi_CRT As Object

    'Variaveis pra Dados do Destinatario
    Dim Dest_CpfCnpj As Object
    Dim Dest_TipoDocumento As Object
    Dim Dest_RazãoSocial As Object
    Dim Dest_IncriçãoEstadual As Object
    Dim Dest_Logradouro As Object
    Dim Dest_NumeroEndereço As Object
    Dim Dest_Complemento As Object
    Dim Dest_Bairro As Object
    Dim Dest_Cep As Object
    Dim Dest_Pais As Object
    Dim Dest_cPais As Object
    Dim Dest_UF As Object
    Dim Dest_Municipio As Object
    Dim Dest_Telefone As Object
    Dim Dest_IsentoIcms As Object
    Dim Dest_Email As Object
    Dim Dest_indFinal As Object
    Dim Dest_IndIeDest As Object

    Dim NroLoteEnvio As String
    Dim cStat As String
    Dim xMotivo As String
    Dim nRecibo As String
    Dim StringRecibo As String
    Dim StringXMLAssinado As String
    Dim XmlAutorizaçaoUso As String
    Dim Protocolo As String
    Dim dhRecbto As String

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Wizard1_FinishButtonClick(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Wizard1.FinishButtonClick
        ValidarDadosNFe()
    End Sub

    Private Sub Wizard1_CancelButtonClick(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Wizard1.CancelButtonClick
        If MessageBox.Show("Finalizar o Gerador de NFe ?", "Gerardor de NFe", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.Close()
            Me.Dispose()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub NFeValidarDados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Pedido.Text = Ped 'Recebe o numero do pedido atraves da propriedade numeroPedido

        If Me.Pedido.Text = "" Then
            MessageBox.Show("Não foi informado o numero do Pedido para o sistema de validação", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        If Cli = 0 Then
            MessageBox.Show("Não foi informado o código do Cliente para o sistema de validação", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        CarregaListaProduto()

    End Sub

    Private Sub CarregaDadosEmitentePadrao()


        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        CNN.Open()

        Dim Sql As String = "SELECT EmitentePadrao.*, Emitente.codCRT, Emitente.ControlaPedido, EmitentePadrao.Emitente FROM EmitentePadrao INNER JOIN Emitente ON EmitentePadrao.emCpfCnpj = Emitente.CpfCnpj WHERE (((EmitentePadrao.Emitente)='PADRAO'));"
        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            IdEmitente = DR.Item("emCpfCnpj") & ""
            confINICIAL = DR.Item("confNFeInicial") & ""
        Else
            IdEmitente = ""

        End If
        DR.Close()
        CNN.Close()
    End Sub

    Private Sub ValidarDadosNFe()

        Dim ContarItens As Integer = 0
        For Each row As DataGridViewRow In Lista.Rows
            If row.Cells("cSelect").Value = True Then
                ContarItens += 1
            End If
        Next

        If ContarItens = 0 Then
            MessageBox.Show("Favor selecionar Produtos para emitir a NFe.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        Me.Msg.Visible = True
        'Me.Msg.Visible = True

        Dim DsErro As New DataSet
        Dim Erro As New ArrayList
        Dim ErroEmit As Integer = 0
        Dim ErroDest As Integer = 0
        Dim ErroProd As Integer = 0
        Dim ErroTran As Integer = 0

        CarregaDadosEmitentePadrao()

        DataNFe = Format(Today, "dd/MM/yyyy")



        'Validar dados do Emitente
        Dim Sql As String = String.Empty
        Dim ds As New DataSet
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        CNN.Open()


        Sql = "SELECT Emitente.*, UF.NomeUF, Municipio.NomeMunic FROM (Emitente LEFT JOIN UF ON Emitente.UF = UF.CodigoUF) LEFT JOIN Municipio ON Emitente.Municipio = Municipio.CodMunicipio WHERE (((Emitente.CpfCnpj)='" & IdEmitente & "'));"
        Dim CMD As New OleDbCommand(Sql, CNN)
        Dim DA As New OleDbDataAdapter(CMD)
        DA.Fill(ds, "Emitente")

        Application.DoEvents()
        Me.Msg.Text = "Validando dados do Emitente"
        If ds.Tables("Emitente").Rows.Count = 1 Then



            If ds.Tables("Emitente").Rows(0)("CpfCnpj") & "" = "" Then Erro.Add("O CNPJ do Emitente não foi informado") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("RazãoSocial") & "" = "" Then Erro.Add("A Razão Social do emitente não foi informada") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("IncriçãoEstadual") & "" = "" Then Erro.Add("a inscrição estadual do emitente não foi informada") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("Logradouro") & "" = "" Then Erro.Add("O Logradouro do emitente não foi informado") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("NumeroEndereço") & "" = "" Then Erro.Add("O numero do endereço do emitente não foi informado") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("Bairro") & "" = "" Then Erro.Add("O Bairro do emitente não foi informado") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("Cep") & "" = "" Then Erro.Add("O Cep do Emitente não foi informado") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("Pais") & "" = "" Then Erro.Add("O país do emitente não foi informado") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("UF") & "" = "" Then Erro.Add("A Uf do emitente não foi informado") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("Municipio") & "" = "" Then Erro.Add("O município do emitente não foi informado") : ErroEmit += 1
            If ds.Tables("Emitente").Rows(0)("Telefone") & "" = "" Then Erro.Add("O Telefone do emitente não foi informado") : ErroEmit += 1

            If ErroEmit > 0 Then

                Dim Dt As New DataTable
                Dt = New DataTable("Emitente")
                Dt.Columns.Add("xErro")
                DsErro.Tables.Add(Dt)

                For Each Str As String In Erro
                    Dim dr As DataRow = DsErro.Tables("Emitente").NewRow
                    dr("xErro") = Str
                    DsErro.Tables("Emitente").Rows.Add(dr)
                Next

            End If

        Else
            MessageBox.Show("Emitente não encontrado, favor verificar.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Me.Dispose()
            CNN.Close()
            Exit Sub
        End If

        'Validar Dados do Destinatario

        Dim CNNsql As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNNsql.Open()

        Sql = "SELECT * From Clientes Where Codigo = " & Cli
        Dim CMDsql As New OleDbCommand(Sql, CNNsql)
        Dim DAsql As New OleDbDataAdapter(CMDsql)
        DAsql.Fill(ds, "Destinatario")

        Application.DoEvents()
        Me.Msg.Text = "Validando dados do Destinatário"
        If ds.Tables("Destinatario").Rows.Count = 1 Then

            If ds.Tables("Destinatario").Rows(0)("CpfCgc") & "" = "" Then Erro.Add("Não foi informado o CPF/CNPJ do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("Nome") & "" = "" Then Erro.Add("Não foi informado o Nome do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("Insc") & "" = "" Then Erro.Add("Não foi informado o a Incrição do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("Endereço") & "" = "" Then Erro.Add("Não foi informado o endereço do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("Nro") & "" = "" Then Erro.Add("Não foi informado o numero do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("Bairro") & "" = "" Then Erro.Add("Não foi informado o Bairro do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("Cep") & "" = "" Then Erro.Add("Não foi informado o cep do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("Telefone") & "" = "" Then Erro.Add("Não foi informado o telefone do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("cUF") & "" = "" Then Erro.Add("Não foi informado o UF do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("Pais") & "" = "" Then Erro.Add("Não foi informado o Pais do destinatário") : ErroDest += 1
            If ds.Tables("Destinatario").Rows(0)("cMun") & "" = "" Then Erro.Add("Não foi informado o Municipio do destinatário") : ErroDest += 1

            If ErroDest > 0 Then

                Dim Dt As New DataTable
                Dt = New DataTable("Destinatario")
                Dt.Columns.Add("xErro")
                DsErro.Tables.Add(Dt)

                For Each Str As String In Erro
                    Dim dr As DataRow = DsErro.Tables("Destinatario").NewRow
                    dr("xErro") = Str
                    DsErro.Tables("Destinatario").Rows.Add(dr)
                Next

            End If


        Else
            MessageBox.Show("Destinatario não encontrado, favor verificar.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Me.Dispose()
            CNNsql.Close()
            Exit Sub
        End If


        If ErroDest = 0 Then
            Sql = "SELECT * From Clientes WHERE CpfCnpj = '" & ds.Tables("Destinatario").Rows(0)("CpfCgc") & "'"
            CMD = New OleDbCommand(Sql, CNN)
            Dim daDest As New OleDbDataAdapter(CMD)
            daDest.Fill(ds, "NFeDestinatario")

            Application.DoEvents()
            Me.Msg.Text = "Salvando Dados do Destinatário"
            If ds.Tables("NFeDestinatario").Rows.Count = 0 Then

                Dim DRnovo As DataRow
                DRnovo = ds.Tables("NFeDestinatario").NewRow

                DRnovo("CpfCnpj") = nzNUL(ds.Tables("Destinatario").Rows(0)("CpfCgc"))
                DRnovo("TipoDocumento") = nzNUL(ds.Tables("Destinatario").Rows(0)("TipoPessoa"))
                DRnovo("RazãoSocial") = nzNUL(ds.Tables("Destinatario").Rows(0)("Nome"))
                DRnovo("IncriçãoEstadual") = nzNUL(ds.Tables("Destinatario").Rows(0)("Insc"))
                DRnovo("Logradouro") = nzNUL(ds.Tables("Destinatario").Rows(0)("Endereço"))
                DRnovo("NumeroEndereço") = nzNUL(ds.Tables("Destinatario").Rows(0)("Nro"))
                DRnovo("Complemento") = nzNUL(ds.Tables("Destinatario").Rows(0)("xCpl"))
                DRnovo("Bairro") = nzNUL(ds.Tables("Destinatario").Rows(0)("Bairro"))
                DRnovo("Cep") = nzNUL(ds.Tables("Destinatario").Rows(0)("Cep"))
                DRnovo("Pais") = nzNUL(ds.Tables("Destinatario").Rows(0)("Pais"))
                DRnovo("UF") = nzNUL(ds.Tables("Destinatario").Rows(0)("cUF"))
                DRnovo("Municipio") = nzNUL(ds.Tables("Destinatario").Rows(0)("cMun"))
                DRnovo("Telefone") = nzNUL(ds.Tables("Destinatario").Rows(0)("Telefone"))
                If ds.Tables("Destinatario").Rows(0)("Insc") = "ISENTO" Then
                    DRnovo("IsentoIcms") = True
                Else
                    DRnovo("IsentoIcms") = False
                End If
                DRnovo("Email") = nzNUL(ds.Tables("Destinatario").Rows(0)("Email"))
                DRnovo("indFinal") = nzNUM(ds.Tables("Destinatario").Rows(0)("indFinal"))
                DRnovo("IndIeDest") = nzINT(ds.Tables("Destinatario").Rows(0)("IndIeDest"))

                ds.Tables("NFeDestinatario").Rows.Add(DRnovo)

                Dim ObjADD As New OleDbCommandBuilder(daDest)
                daDest.Update(ds, "NFeDestinatario")

                'Colhe os Dados do Emitente para gerar a NFe
                Dest_CpfCnpj = nzNUL(ds.Tables("Destinatario").Rows(0)("CpfCgc"))
                Dest_TipoDocumento = nzNUL(ds.Tables("Destinatario").Rows(0)("TipoPessoa"))
                Dest_RazãoSocial = nzNUL(ds.Tables("Destinatario").Rows(0)("Nome"))
                Dest_IncriçãoEstadual = nzNUL(ds.Tables("Destinatario").Rows(0)("Insc"))
                Dest_Logradouro = nzNUL(ds.Tables("Destinatario").Rows(0)("Endereço"))
                Dest_NumeroEndereço = nzNUL(ds.Tables("Destinatario").Rows(0)("Nro"))
                Dest_Complemento = nzNUL(ds.Tables("Destinatario").Rows(0)("xCpl"))
                Dest_Bairro = nzNUL(ds.Tables("Destinatario").Rows(0)("Bairro"))
                Dest_Cep = nzNUL(ds.Tables("Destinatario").Rows(0)("Cep"))
                Dest_Pais = nzNUL(ds.Tables("Destinatario").Rows(0)("Pais"))
                Dest_cPais = AchaCodigoPais(Dest_Pais)
                Dest_UF = nzNUL(ds.Tables("Destinatario").Rows(0)("cUF"))
                Dest_Municipio = nzNUL(ds.Tables("Destinatario").Rows(0)("cMun"))
                Dest_Telefone = nzNUL(ds.Tables("Destinatario").Rows(0)("Telefone"))
                If ds.Tables("Destinatario").Rows(0)("Insc") = "ISENTO" Then
                    Dest_IsentoIcms = True
                Else
                    Dest_IsentoIcms = False
                End If
                Dest_Email = nzNUL(ds.Tables("Destinatario").Rows(0)("Email"))
                Dest_indFinal = nzNUM(ds.Tables("Destinatario").Rows(0)("indFinal"))
                Dest_IndIeDest = nzINT(ds.Tables("Destinatario").Rows(0)("IndIeDest"))


            Else

                ds.Tables("NFeDestinatario").Rows(0).BeginEdit()
                ds.Tables("NFeDestinatario").Rows(0)("CpfCnpj") = nzNUL(ds.Tables("Destinatario").Rows(0)("CpfCgc"))
                ds.Tables("NFeDestinatario").Rows(0)("TipoDocumento") = nzNUL(ds.Tables("Destinatario").Rows(0)("TipoPessoa"))
                ds.Tables("NFeDestinatario").Rows(0)("RazãoSocial") = nzNUL(ds.Tables("Destinatario").Rows(0)("Nome"))
                ds.Tables("NFeDestinatario").Rows(0)("IncriçãoEstadual") = nzNUL(ds.Tables("Destinatario").Rows(0)("Insc"))
                ds.Tables("NFeDestinatario").Rows(0)("Logradouro") = nzNUL(ds.Tables("Destinatario").Rows(0)("Endereço"))
                ds.Tables("NFeDestinatario").Rows(0)("NumeroEndereço") = nzNUL(ds.Tables("Destinatario").Rows(0)("Nro"))
                ds.Tables("NFeDestinatario").Rows(0)("Complemento") = nzNUL(ds.Tables("Destinatario").Rows(0)("xCpl"))
                ds.Tables("NFeDestinatario").Rows(0)("Bairro") = nzNUL(ds.Tables("Destinatario").Rows(0)("Bairro"))
                ds.Tables("NFeDestinatario").Rows(0)("Cep") = nzNUL(ds.Tables("Destinatario").Rows(0)("Cep"))
                ds.Tables("NFeDestinatario").Rows(0)("Pais") = nzNUL(ds.Tables("Destinatario").Rows(0)("Pais"))
                ds.Tables("NFeDestinatario").Rows(0)("UF") = nzNUL(ds.Tables("Destinatario").Rows(0)("cUF"))
                ds.Tables("NFeDestinatario").Rows(0)("Municipio") = nzNUL(ds.Tables("Destinatario").Rows(0)("cMun"))
                ds.Tables("NFeDestinatario").Rows(0)("Telefone") = nzNUL(ds.Tables("Destinatario").Rows(0)("Telefone"))
                If ds.Tables("Destinatario").Rows(0)("Insc") = "ISENTO" Then
                    ds.Tables("NFeDestinatario").Rows(0)("IsentoIcms") = True
                Else
                    ds.Tables("NFeDestinatario").Rows(0)("IsentoIcms") = False
                End If
                ds.Tables("NFeDestinatario").Rows(0)("Email") = nzNUL(ds.Tables("Destinatario").Rows(0)("Email"))
                ds.Tables("NFeDestinatario").Rows(0)("indFinal") = nzINT(ds.Tables("Destinatario").Rows(0)("indFinal"))
                ds.Tables("NFeDestinatario").Rows(0)("IndIeDest") = nzINT(ds.Tables("Destinatario").Rows(0)("IndIeDest"))
                ds.Tables("NFeDestinatario").Rows(0).EndEdit()

                Dim ObjADD As New OleDbCommandBuilder(daDest)
                daDest.Update(ds, "NFeDestinatario")

                'Colhe os Dados do Emitente para gerar a NFe
                Dest_CpfCnpj = nzNUL(ds.Tables("Destinatario").Rows(0)("CpfCgc"))
                Dest_TipoDocumento = nzNUL(ds.Tables("Destinatario").Rows(0)("TipoPessoa"))
                Dest_RazãoSocial = nzNUL(ds.Tables("Destinatario").Rows(0)("Nome"))
                Dest_IncriçãoEstadual = nzNUL(ds.Tables("Destinatario").Rows(0)("Insc"))
                Dest_Logradouro = nzNUL(ds.Tables("Destinatario").Rows(0)("Endereço"))
                Dest_NumeroEndereço = nzNUL(ds.Tables("Destinatario").Rows(0)("Nro"))
                Dest_Complemento = nzNUL(ds.Tables("Destinatario").Rows(0)("xCpl"))
                Dest_Bairro = nzNUL(ds.Tables("Destinatario").Rows(0)("Bairro"))
                Dest_Cep = nzNUL(ds.Tables("Destinatario").Rows(0)("Cep"))
                Dest_Pais = nzNUL(ds.Tables("Destinatario").Rows(0)("Pais"))
                Dest_cPais = AchaCodigoPais(Dest_Pais)
                Dest_UF = nzNUL(ds.Tables("Destinatario").Rows(0)("cUF"))
                Dest_Municipio = nzNUL(ds.Tables("Destinatario").Rows(0)("cMun"))
                Dest_Telefone = nzNUL(ds.Tables("Destinatario").Rows(0)("Telefone"))
                If ds.Tables("Destinatario").Rows(0)("Insc") = "ISENTO" Then
                    Dest_IsentoIcms = True
                Else
                    Dest_IsentoIcms = False
                End If
                Dest_Email = nzNUL(ds.Tables("Destinatario").Rows(0)("Email"))
                Dest_indFinal = nzINT(ds.Tables("Destinatario").Rows(0)("indFinal"))
                Dest_IndIeDest = nzINT(ds.Tables("Destinatario").Rows(0)("IndIeDest"))

            End If
        End If


        'Verificação e Validação do Produto       
        Sql = "SELECT Produtos.* FROM Produtos INNER JOIN ItensPedido ON Produtos.CodigoProduto = ItensPedido.CodigoProduto WHERE (ItensPedido.PedidoSequencia = " & Me.Pedido.Text & ")"
        Dim CMDProd As New OleDbCommand(Sql, CNNsql)
        Dim DAProd As New OleDbDataAdapter(CMDProd)
        DAProd.Fill(ds, "Produtos")

        Application.DoEvents()
        Me.Msg.Text = "Validando dados dos Produtos"
        Dim M As String = String.Empty


        Dim cmdNFeProd As OleDbCommand
        Dim daNFeProd As OleDbDataAdapter

        Dim ErroProdAcumulado As Integer
        Erro.Clear()
        For Each Linha As DataRow In ds.Tables("Produtos").Rows
            M = Linha("CodigoProduto") & "-" & Linha("Descrição") & Chr(13) & Chr(13)

            If Linha("CodigoProduto") & "" = "" Then Erro.Add(M & "Não foi informado o código do Produto") : ErroProd += 1
            If Linha("Descrição") & "" = "" Then Erro.Add(M & "Não foi informado a descrição do produto") : ErroProd += 1
            If Linha.Item("CF") & "" = "" Then Erro.Add(M & "Não foi informado o NCM do Produto") : ErroProd += 1
            If Len(Linha.Item("CF")) < 8 Then Erro.Add(M & "Formato do NCM inválido") : ErroProd += 1

            If Linha("UnidadeMedida") & "" = "" Then Erro.Add(M & "Não foi informado a unidade de medida do produto") : ErroProd += 1

            If Linha("cfopVendaEstado") & "" = "" Then Erro.Add(M & "Não foi informado o CFOP de Venda no estado") : ErroProd += 1
            If Linha("cfopRevendaEstado") & "" = "" Then Erro.Add(M & "Não foi informado o CFOP de Revenda no estado") : ErroProd += 1
            If Linha("cfopVendaInterestado") & "" = "" Then Erro.Add(M & "Não foi informado o CFOP de Venda fora do Estado") : ErroProd += 1
            If Linha("cfopRevendaInterestado") & "" = "" Then Erro.Add(M & "Não foi informado o CFOP de Revenda Fora do Estado") : ErroProd += 1

            If Linha("Cst") & "" = "" Then Erro.Add(M & "Não foi informado o CST ICMS do produto") : ErroProd += 1
            If Linha("ModBcIcms") & "" = "" Then Erro.Add(M & "Não foi informado a modalidade de base de calculo do ICMS do Produto") : ErroProd += 1
            If Linha("OrigemIcms") & "" = "" Then Erro.Add(M & "Não foi informado a Origem do ICMS do Produto") : ErroProd += 1
            If Linha("Icms") & "" = "" Then Erro.Add(M & "Não foi informado o percentual do ICMS do Produto") : ErroProd += 1
            If Linha("cstIPI") & "" = "" Then Erro.Add(M & "Não foi informado o CST IPI do Produto") : ErroProd += 1
            If Linha("TcalcIPI") & "" = "" Then Erro.Add(M & "Não foi informado o Tipo de Calculo do IPI do Produto") : ErroProd += 1
            If Linha("Ipi") & "" = "" Then Erro.Add(M & "Não foi informado o percentual do IPI do Produto") : ErroProd += 1
            If Linha("cEnq") & "" = "" Then Erro.Add(M & "Não foi informado o código de Enquadramento do Produto") : ErroProd += 1
            If Linha("CstPIS") & "" = "" Then Erro.Add(M & "Não foi informado o CST PIS do Produto") : ErroProd += 1
            If Linha("pPIS") & "" = "" Then Erro.Add(M & "Não foi informado o percentual do PIS do Produto") : ErroProd += 1
            If Linha("cstCofins") & "" = "" Then Erro.Add(M & "Não foi informado o CST COFINS do produto") : ErroProd += 1
            If Linha("pCofins") & "" = "" Then Erro.Add(M & "Não foi informado o percentual de COFINS do Produto") : ErroProd += 1

            If Linha("Cst") & "" = "10" Then Erro.Add(M & "Não podemos gerar nfe com CST 10") : ErroProd += 1
            If Linha("Cst") & "" = "20" Then Erro.Add(M & "Não podemos gerar nfe com CST 20") : ErroProd += 1
            If Linha("Cst") & "" = "30" Then Erro.Add(M & "Não podemos gerar nfe com CST 30") : ErroProd += 1
            If Linha("Cst") & "" = "70" Then Erro.Add(M & "Não podemos gerar nfe com CST 70") : ErroProd += 1
            If Linha("Cst") & "" = "90" Then Erro.Add(M & "Não podemos gerar nfe com CST 90") : ErroProd += 1
            If Linha("Cst") & "" = "101" Then Erro.Add(M & "Não podemos gerar nfe com CST 101") : ErroProd += 1
            If Linha("Cst") & "" = "201" Then Erro.Add(M & "Não podemos gerar nfe com CST 201") : ErroProd += 1
            If Linha("Cst") & "" = "202" Then Erro.Add(M & "Não podemos gerar nfe com CST 202") : ErroProd += 1
            If Linha("Cst") & "" = "203" Then Erro.Add(M & "Não podemos gerar nfe com CST 203") : ErroProd += 1
            If Linha("Cst") & "" = "500" Then Erro.Add(M & "Não podemos gerar nfe com CST 500") : ErroProd += 1
            If Linha("Cst") & "" = "900" Then Erro.Add(M & "Não podemos gerar nfe com CST 900") : ErroProd += 1

            If Linha("cstIPI") & "" = "00" Then Erro.Add(M & "Não podemos gerar nfe com CSTIPI 00") : ErroProd += 1
            If Linha("cstIPI") & "" = "01" Then Erro.Add(M & "Não podemos gerar nfe com CSTIPI 01") : ErroProd += 1
            If Linha("cstIPI") & "" = "02" Then Erro.Add(M & "Não podemos gerar nfe com CSTIPI 02") : ErroProd += 1
            If Linha("cstIPI") & "" = "03" Then Erro.Add(M & "Não podemos gerar nfe com CSTIPI 03") : ErroProd += 1
            If Linha("cstIPI") & "" = "04" Then Erro.Add(M & "Não podemos gerar nfe com CSTIPI 04") : ErroProd += 1
            If Linha("cstIPI") & "" = "05" Then Erro.Add(M & "Não podemos gerar nfe com CSTIPI 05") : ErroProd += 1
            If Linha("cstIPI") & "" = "49" Then Erro.Add(M & "Não podemos gerar nfe com CSTIPI 49") : ErroProd += 1

            If IsDBNull(Linha("Tipo_Item")) Then
                Erro.Add(M & "Não podemos gerar nfe TipoVenda do Produto esta vazio") : ErroProd += 1


                If Linha("Tipo_Item") = "04" Then
                    If IsDBNull(Linha("cfopVendaEstado")) Then Erro.Add(M & "Não podemos gerar nfe Icms de Venda no estado esta vazio") : ErroProd += 1
                    If IsDBNull(Linha("cfopVendaInterestado")) Then Erro.Add(M & "Não podemos gerar nfe Icms Interestado esta vazio") : ErroProd += 1
                ElseIf Linha("Tipo_Item") = "00" Then
                    If IsDBNull(Linha("cfopRevendaEstado")) Then Erro.Add(M & "Não podemos gerar nfe Icms de Revenda no estado esta vazio") : ErroProd += 1
                    If IsDBNull(Linha("cfopRevendaInterestado")) Then Erro.Add(M & "Não podemos gerar nfe Icms de revenda interestado esta vazio") : ErroProd += 1
                End If
            End If


            Select Case Linha("CstPIS")
                Case "49", "50", "51", "52", "53", "54", "55", "56", "60", "61", "62", "63", "64", "65", "66", "67", "70", "71", "72", "73", "74", "75", "98", "99"
                    Erro.Add(M & "Não podemos gerar nfe com CSTPIS " & Linha("CstPIS")) : ErroProd += 1
            End Select

            Select Case Linha("cstCofins")
                Case "49", "50", "51", "52", "53", "54", "55", "56", "60", "61", "62", "63", "64", "65", "66", "67", "70", "71", "72", "73", "74", "75", "98", "99"
                    Erro.Add(M & "Não podemos gerar nfe com CSTCOFINS " & Linha("cstCofins")) : ErroProd += 1
            End Select




            If ErroProd = 0 Then

                Sql = "Select * From Produtos Where cprod = '" & Linha("CodigoProduto") & "'"
                cmdNFeProd = New OleDbCommand(Sql, CNN)
                daNFeProd = New OleDbDataAdapter(cmdNFeProd)
                daNFeProd.Fill(ds, "ProdutosNFe")

                If ds.Tables("ProdutosNFe").Rows.Count = 0 Then

                    Dim DRnovo As DataRow

                    DRnovo = ds.Tables("ProdutosNFe").NewRow()
                    DRnovo("CodigoERP") = Linha("CodigoProduto")
                    DRnovo("Cprod") = Linha("CodigoProduto")
                    DRnovo("xProd") = Linha("CodigoProduto")
                    DRnovo("cEAN") = Linha("Ean")
                    DRnovo("cEANTrib") = Linha("cEANTrib")
                    DRnovo("NCM") = Linha("CF")
                    DRnovo("uCom") = Linha("UnidadeMedida")
                    DRnovo("vUnCom") = Linha("ValorVenda")
                    DRnovo("uTrib") = Linha("UnidadeMedida")
                    DRnovo("qTrib") = 1
                    DRnovo("vUnTrib") = Linha("ValorVenda")
                    DRnovo("cstICMS") = Linha("Cst")
                    DRnovo("origemICMS") = Linha("OrigemIcms")
                    DRnovo("modBCicms") = Linha("ModBcIcms")
                    DRnovo("pICMS") = Linha("Icms")
                    DRnovo("cstIPI") = Linha("cstIPI")
                    DRnovo("tCalcIpi") = Linha("TcalcIPI")
                    DRnovo("cEnq") = Linha("cEnq")
                    DRnovo("pIPI") = Linha("Ipi")
                    DRnovo("cstPIS") = Linha("CstPIS")
                    DRnovo("pPIS") = Linha("pPIS")
                    DRnovo("cstCOFINS") = Linha("cstCofins")
                    DRnovo("pCOFINS") = Linha("pCofins")
                    DRnovo("CEST") = Linha("CEST")
                    DRnovo("Inativo") = False

                    ds.Tables("ProdutosNFe").Rows.Add(DRnovo)

                    Dim ObjADD As New OleDbCommandBuilder(daNFeProd)
                    daNFeProd.Update(ds, "ProdutosNFe")
                Else

                    ds.Tables("ProdutosNFe").Rows(0).BeginEdit()
                    ds.Tables("ProdutosNFe").Rows(0)("CodigoERP") = CStr(Linha("CodigoProduto"))
                    ds.Tables("ProdutosNFe").Rows(0)("xProd") = Linha("Descrição")
                    ds.Tables("ProdutosNFe").Rows(0)("cEAN") = Linha("Ean")
                    ds.Tables("ProdutosNFe").Rows(0)("cEANTrib") = Linha("cEANTrib")
                    ds.Tables("ProdutosNFe").Rows(0)("NCM") = Linha("CF")
                    ds.Tables("ProdutosNFe").Rows(0)("uCom") = Linha("UnidadeMedida")
                    ds.Tables("ProdutosNFe").Rows(0)("vUnCom") = Linha("ValorVenda")
                    ds.Tables("ProdutosNFe").Rows(0)("uTrib") = Linha("UnidadeMedida")
                    ds.Tables("ProdutosNFe").Rows(0)("qTrib") = 1
                    ds.Tables("ProdutosNFe").Rows(0)("vUnTrib") = Linha("ValorVenda")
                    ds.Tables("ProdutosNFe").Rows(0)("cstICMS") = Linha("Cst")
                    ds.Tables("ProdutosNFe").Rows(0)("origemICMS") = Linha("OrigemIcms")
                    ds.Tables("ProdutosNFe").Rows(0)("modBCicms") = Linha("ModBcIcms")
                    ds.Tables("ProdutosNFe").Rows(0)("pICMS") = Linha("Icms")
                    ds.Tables("ProdutosNFe").Rows(0)("cstIPI") = Linha("cstIPI")
                    ds.Tables("ProdutosNFe").Rows(0)("tCalcIpi") = Linha("TcalcIPI")
                    ds.Tables("ProdutosNFe").Rows(0)("cEnq") = Linha("cEnq")
                    ds.Tables("ProdutosNFe").Rows(0)("pIPI") = Linha("Ipi")
                    ds.Tables("ProdutosNFe").Rows(0)("cstPIS") = Linha("CstPIS")
                    ds.Tables("ProdutosNFe").Rows(0)("pPIS") = Linha("pPIS")
                    ds.Tables("ProdutosNFe").Rows(0)("cstCOFINS") = Linha("cstCofins")
                    ds.Tables("ProdutosNFe").Rows(0)("pCOFINS") = Linha("pCofins")
                    ds.Tables("ProdutosNFe").Rows(0)("CEST") = Linha("CEST")
                    ds.Tables("ProdutosNFe").Rows(0)("Inativo") = False
                    ds.Tables("ProdutosNFe").Rows(0).EndEdit()

                    Dim ObjADD As New OleDbCommandBuilder(daNFeProd)
                    daNFeProd.Update(ds, "ProdutosNFe")
                    daNFeProd.Dispose()
                End If

                cmdNFeProd.Dispose()
                daNFeProd.Dispose()

            Else
                ErroProdAcumulado += ErroProd
                ErroProd = 0
            End If

        Next

        If ErroProdAcumulado > 0 Then
            Dim Dt As New DataTable
            Dt = New DataTable("Produtos")
            Dt.Columns.Add("xErro")
            If Not DsErro.Tables.Contains("Produtos") Then DsErro.Tables.Add(Dt)

            For Each Str As String In Erro
                Dim dr As DataRow = DsErro.Tables("Produtos").NewRow
                dr("xErro") = Str
                DsErro.Tables("Produtos").Rows.Add(dr)
            Next
        End If

        Dim SomaErros As Integer = ErroDest + ErroEmit + ErroProdAcumulado + ErroTran

        If SomaErros > 0 Then
            MessageBox.Show("Foram encontrados erros nos cadastro, não pode gerar a NFe com estes erros, Favor verificar", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim LocalEXE As String = My.Application.Info.DirectoryPath
            DsErro.WriteXml(LocalEXE & "\Erros.xml")
            System.Diagnostics.Process.Start(LocalEXE & "\Erros.xml")
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If


        CNN.Close()
        CNNsql.Close()
        Application.DoEvents()
        Me.Msg.Text = "Fim da Validação"


        GerarNFe()

    End Sub

#Region "Rotinas para Gerar a NFe"

    Private Sub GerarNFe()

        Dim CarregaConfPadrao As Boolean = CarregaConfPadrãoNFe()
        If CarregaConfPadrao = False Then
            MessageBox.Show("Configuração de Autenticação não foi Iniciada. NFe não finalizada.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        nNF = GerarNumeroNFe()

        Dim CarregaEmitente As Boolean = AcharDadosEmitente()
        If CarregaEmitente = False Then
            MessageBox.Show("Erro ao Carregar dados do emitente. NFe não finalizada.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        cNF = GerarCodAcessoNF()

        dEmi = DataNFe & " " & TimeOfDay
        dSaiEnt = DataNFe & " " & TimeOfDay

        Chave_Acesso = GerarChaveAcesso(Emi_CNPJ, Emi_UF, nNF, cNF)

        If Len(Chave_Acesso) <> 44 Then
            MessageBox.Show("Erro ao Criar a chave da Nfe, NFe não finalizada.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        SalvaNFeInicio()

        Me.Close()
        Me.Dispose()

    End Sub

    Private Function CarregaConfPadrãoNFe() As Boolean

        Dim ArquivoExiste As String = Dir(LocalNomeNFeDB & Nome_BDNFe)

        If ArquivoExiste <> "" Then

            Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
            CNN.Open()


            Dim Sql As String = "SELECT * FROM NFeInicialConfiguracao WHERE cInicial ='" & confINICIAL & "'"

            Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
            Dim DR As OleDb.OleDbDataReader

            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then

                StatusNFe = DR.Item("StatusNFe")
                VersaoXml = DR.Item("VersaoXml")
                verProc = DR.Item("VersaoPRG")
                tpAmb = Mid(DR.Item("TipoAmbiente"), 1, 1)
                procEmi = DR.Item("ProcessoEmissao")
                modelo = DR.Item("ModeloNFe")
                serie = DR.Item("SerieNFe")
                natOp = DR.Item("NatOpe")
                tpNF = Mid(DR.Item("TipoDoc"), 1, 1)
                tpImp = Mid(DR.Item("TipoDanfe"), 1, 1)
                indPag = Mid(DR.Item("FormaPgto"), 1, 1)
                tpEmis = Mid(DR.Item("FormaEmissao"), 1, 1)
                finNfe = Mid(DR.Item("FinEmissao"), 1, 1)
                cUF = DR.Item("codUFocorrencia")
                cMunFG = AchaCodigoMunicipio(cUF, DR.Item("MunicOcorrencia"))
                AutenticadorNFe = Mid(DR.Item("Autenticador"), 1, 1)
                Return True
            Else
                Return False
            End If
            DR.Close()
            CNN.Close()

        Else
            Return False
            Exit Function
        End If
    End Function

    Private Function AchaCodigoMunicipio(_UF As String, _NomeMunicipio As String) As String

        Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        CNN.Open()


        Dim Sql As String = "SELECT * FROM Municipio WHERE UF ='" & _UF & "' and NomeMunic = '" & _NomeMunicipio & "'"

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Return DR.Item("CodMunicipio")
        Else
            Return ""
        End If
        DR.Close()
        CNN.Close()

    End Function

    Private Function AchaCodigoPais(_NomePais As String) As String

        Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        CNN.Open()


        Dim Sql As String = "SELECT * FROM Paises WHERE DescPais ='" & _NomePais & "'"

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Return DR.Item("CodPais")
        Else
            Return ""
        End If
        DR.Close()
        CNN.Close()

    End Function

    Private Function GerarNumeroNFe() As Integer

        'Inserir ultimo registro
        Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        Dim Cmd As New OleDbCommand()
        Dim DataReader As OleDbDataReader
        Dim Ult As Integer
        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "Select max(nNF) from NFe Where Autenticador = '" & AutenticadorNFe & "' and CNPJemitente = '" & IdEmitente & "'"
            .CommandType = CommandType.Text
        End With
        Try
            CNN.Open()
            DataReader = Cmd.ExecuteReader

            While DataReader.Read
                If Not IsDBNull(DataReader.Item(0)) Then
                    'Achou o iten procurado o iten as caixas serão preenchida
                    Ult = DataReader.Item(0)
                Else
                    Ult = NumeroAnoAnterior()
                End If
            End While
            DataReader.Close()

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                CNN.Close()
                Exit Function
            End If
        End Try
        CNN.Close()

        Return (Ult + 1)
        'fim inserir ultimo registro

    End Function

    Private Function NumeroAnoAnterior()

        Dim NomeAnterior As String = "NFe" & (YearWork - 1)
        Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        Dim Cmd As New OleDbCommand()
        Dim DataReader As OleDbDataReader
        Dim Ult As Integer
        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "Select max(nNF) from NFe Where Autenticador = '" & AutenticadorNFe & "' and CNPJemitente = '" & IdEmitente & "'"
            .CommandType = CommandType.Text
        End With
        Try
            CNN.Open()
            DataReader = Cmd.ExecuteReader

            While DataReader.Read
                If Not IsDBNull(DataReader.Item(0)) Then
                    'Achou o iten procurado o iten as caixas serão preenchida
                    Ult = DataReader.Item(0)
                Else

                End If
            End While
            DataReader.Close()

        Catch Merror As System.Exception
            Return 0
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                CNN.Close()
                Exit Function
            End If
        End Try
        CNN.Close()

        Return Ult
    End Function

    Private Function AcharDadosEmitente() As Boolean

        If IdEmitente = "" Then
            MsgBox("Não pode criar chave de acesso, não exite nenhum emitente selecionado", 64, "Validação de Dados")
            Return False
            Exit Function
        End If

        Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        CNN.Open()

        Dim Sql As String = "SELECT Emitente.CpfCnpj, Emitente.codCRT, Emitente.TipoDocumento, Emitente.RazãoSocial, Emitente.NomeFantasia, Emitente.IncriçãoEstadual, Emitente.IncriçãoMunicipal, Emitente.InscEstSubTrib, Emitente.Logradouro, Emitente.NumeroEndereço, Emitente.Complemento, Emitente.Bairro, Emitente.Cep, Emitente.Pais, Emitente.UF, UF.NomeUF, Emitente.Municipio, Municipio.NomeMunic, Emitente.Telefone, Emitente.CNAE, Emitente.Logotipo FROM (Emitente LEFT JOIN UF ON Emitente.UF = UF.CodigoUF) LEFT JOIN Municipio ON Emitente.Municipio = Municipio.CodMunicipio WHERE (((Emitente.CpfCnpj)='" & IdEmitente & "'));"

        Dim Cmd As New OleDbCommand(Sql, CNN)
        Dim DR As OleDbDataReader

        Dim Nmunicipio As String = ""

        Try
            DR = Cmd.ExecuteReader
            While DR.Read

                Emi_CNPJ = DR.Item("CpfCnpj") & ""
                Emi_IE = DR.Item("IncriçãoEstadual") & ""
                Emi_IEstST = DR.Item("InscEstSubTrib") & ""
                Emi_IMunic = DR.Item("IncriçãoMunicipal") & ""
                Emi_CNAE = DR.Item("CNAE") & ""
                Emi_Razao = DR.Item("RazãoSocial") & ""
                Emi_Fantasia = DR.Item("NomeFantasia") & ""
                Emi_Logradouro = DR.Item("Logradouro") & ""
                Emi_Nro = DR.Item("NumeroEndereço") & ""
                Emi_Complemento = DR.Item("Complemento") & ""
                Emi_Bairro = DR.Item("Bairro") & ""
                Emi_Cep = DR.Item("Cep") & ""
                Emi_Telefone = DR.Item("Telefone") & ""
                Emi_UF = DR.Item("UF") & ""
                Emi_xUF = DR.Item("NomeUF") & ""
                Emi_Municipio = AchaCodigoMunicipio(Emi_UF, DR.Item("NomeMunic"))
                Emi_Pais = DR.Item("Pais") & ""
                Emi_cPais = AchaCodigoPais(Emi_Pais)
                Emi_CRT = DR.Item("codCRT") & ""
            End While
            DR.Close()
            CNN.Close()
            Return True

        Catch Merror As System.Exception
            MsgBox(Merror.ToString)
            If ConnectionState.Open Then
                CNN.Close()
                Return False
                Exit Function
            End If
        End Try

    End Function

    Private Function GerarCodAcessoNF() As String

        Dim Num As New Random

        Dim Cod As String = String.Empty
        Cod = Num.Next(1, 99999999)
        Cod = Cod.PadLeft(8, "0")
        Return Cod

    End Function

    Private Function GerarChaveAcesso(CNPJ_Emit As String, UF_Emit As Integer, nNF As Integer, CodigoAcesso As String) As String


        'Variaveis para chave de acesso
        Dim anoMesVAR As String
        Dim modeloVAR As String
        Dim serieVAR As String
        Dim nNFVAR As String
        Dim tpEmisVAR As String



        'Retira Caracteres indesejados no cnpj do emitente
        CNPJ_Emit = CNPJ_Emit.Replace("-", "") : CNPJ_Emit = CNPJ_Emit.Replace("/", "") : CNPJ_Emit = CNPJ_Emit.Replace(".", "")



        anoMesVAR = Format(CDate(Mid(dEmi, 1, 10)), "yyMM")
        modeloVAR = modelo
        serieVAR = serie : serieVAR = serieVAR.PadLeft(3, "0")
        nNFVAR = nNF : nNFVAR = nNFVAR.PadLeft(9, "0")
        tpEmisVAR = tpEmis

        Dim ChaveAcessoVar As String = ""
        ChaveAcessoVar = UF_Emit & anoMesVAR & CNPJ_Emit & modeloVAR & serieVAR & nNFVAR & tpEmisVAR & CodigoAcesso

        If Len(ChaveAcessoVar) <> 43 Then
            MsgBox("Erro na Composição da chave de acesso para achar o digito verificador.", 64, "Validação de Dados")
            Return ""
            Exit Function
        End If

        cDv = AchaDV(ChaveAcessoVar)


        Return ChaveAcessoVar & cDv


    End Function

    Public Function AchaDV(ByVal strNumero As String) As String
        'Calculo modulo 11
        Dim I As Integer : Dim IntCont As Integer : Dim Vlr As Integer
        Dim Resto As Integer
        IntCont = 2
        Vlr = 0
        For I = Len(strNumero) To 1 Step -1
            Vlr = Vlr + (Val(Mid(strNumero, I, 1) * IntCont))
            IntCont = IIf(IntCont >= 9, 2, IntCont + 1)
        Next
        Resto = Vlr Mod 11
        Select Case Resto
            Case 0
                Resto = 0
            Case 1
                Resto = 0
            Case Is > 1
                Resto = Str(Val(11 - Resto))
        End Select
        Return Resto
    End Function


    Private Sub SalvaNFeInicio()


        Dim CNN As New OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        CNN.Open()

        Dim Sql As String = "Insert Into NFe (nNF, modelo, serie, PedidoErp, dEmi, dSaiEnt, natOp, tpNF, tpImp, tpEmis, indPag, finNfe, cUF, cMunFG, ChaveAcesso, StatusNFe, VersaoXml, cNF, cDv, tpAmb, procEmi, verProc, Autenticador, NFever, hSaiEnt, CNPJemitente, razaoEmi, fantasiaEmi, inscEstEmi, InscEstStEmi, InscMunicEmi, cnaeEmi, LogradouroEmi, NumeroEmi, CompEmi, BairroEmi, CepEmi, PaisEmi, cPaisEmi, ufEmi, MunicipioEmi, TelefoneEmi, CRT, CNPJDestinatario, tipoDocDest, razaoDest, InscEstDest, logradouroDest, NumeroDest, CompDest, BairroDest, CepDest, PaisDest, cPaisDest, ufDest, municipioDest, TelefoneDest, IsentoIcmsDest, IndIeDest, idDest, indFinal, indPres, infCpl) Values (@nNF, @modelo, @serie, @PedidoErp, @dEmi, @dSaiEnt, @natOp, @tpNF, @tpImp, @tpEmis, @indPag, @finNfe, @cUF, @cMunFG, @ChaveAcesso, @StatusNFe, @VersaoXml, @cNF, @cDv, @tpAmb, @procEmi, @verProc, @Autenticador, @NFever, @hSaiEnt, @CNPJemitente, @razaoEmi, @fantasiaEmi, @inscEstEmi, @InscEstStEmi, @InscMunicEmi, @cnaeEmi, @LogradouroEmi, @NumeroEmi, @CompEmi, @BairroEmi, @CepEmi, @PaisEmi, @cPaisEmi, @ufEmi, @MunicipioEmi, @TelefoneEmi, @CRT, @CNPJDestinatario, @tipoDocDest, @razaoDest, @InscEstDest, @logradouroDest, @NumeroDest, @CompDest, @BairroDest, @CepDest, @PaisDest, @cPaisDest, @ufDest, @municipioDest, @TelefoneDest, @IsentoIcmsDest, @IndIeDest, @idDest, @indFinal, @indPres, @infCpl)"
        Dim Cmd As New OleDbCommand(Sql, CNN)

        Cmd.Parameters.Add(New OleDb.OleDbParameter("@nNF", nzINT(nNF)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@modelo", nzNUL(modelo)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@serie", nzNUL(serie)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@PedidoErp", nzNUL(Me.Pedido.Text)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@dEmi", nzNUL(dEmi)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@dSaiEnt", nzNUL(dEmi)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@natOp", nzNUL(natOp)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@tpNF", nzNUL(tpNF)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@tpImp", nzNUL(tpImp)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@tpEmis", nzNUL(tpEmis)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@indPag", nzNUL(indPag)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@finNfe", nzNUL(finNfe)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@cUF", nzNUL(cUF)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@cMunFG", nzNUL(cMunFG)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@ChaveAcesso", nzNUL(Chave_Acesso)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@StatusNFe", nzNUL(StatusNFe)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@VersaoXml", nzNUL(VersaoXml)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@cNF", nzNUL(cNF)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@cDv", nzNUL(cDv)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@tpAmb", nzNUL(tpAmb)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@procEmi", nzNUL(procEmi)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@verProc", nzNUL(verProc)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@Autenticador", nzNUL(AutenticadorNFe)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@NFever", 2))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@hSaiEnt", System.DBNull.Value))

        Cmd.Parameters.Add(New OleDb.OleDbParameter("@CNPJemitente", nzNUL(Emi_CNPJ)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@razaoEmi", nzNUL(Emi_Razao)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@fantasiaEmi", nzNUL(Emi_Fantasia)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@inscEstEmi", nzNUL(Emi_IE)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@InscEstStEmi", nzNUL(Emi_IEstST)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@InscMunicEmi", nzNUL(Emi_IMunic)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@cnaeEmi", nzNUL(Emi_CNAE)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@LogradouroEmi", nzNUL(Emi_Logradouro)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@NumeroEmi", nzNUL(Emi_Nro)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@CompEmi", nzNUL(Emi_Complemento)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@BairroEmi", nzNUL(Emi_Bairro)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@CepEmi", nzNUL(Emi_Cep)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@PaisEmi", nzNUL(Emi_Pais)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@cPaisEmi", Emi_cPais))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@ufEmi", nzNUL(Emi_UF)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@MunicipioEmi", nzNUL(Emi_Municipio)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@TelefoneEmi", nzNUL(Emi_Telefone)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@CRT", nzNUL(Emi_CRT)))

        Cmd.Parameters.Add(New OleDb.OleDbParameter("@CNPJDestinatario", nzNUL(Dest_CpfCnpj)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@tipoDocDest", nzNUL(Dest_TipoDocumento)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@razaoDest", nzNUL(Dest_RazãoSocial)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@InscEstDest", nzNUL(Dest_IncriçãoEstadual)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@logradouroDest", nzNUL(Dest_Logradouro)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@NumeroDest", nzNUL(Dest_NumeroEndereço)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@CompDest", nzNUL(Dest_Complemento)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@BairroDest", nzNUL(Dest_Bairro)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@CepDest", nzNUL(Dest_Cep)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@PaisDest", nzNUL(Dest_Pais)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@cPaisDest", Dest_cPais))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@ufDest", nzNUL(Dest_UF)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@municipioDest", nzNUL(Dest_Municipio)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@TelefoneDest", nzNUL(Dest_Telefone)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@IsentoIcmsDest", nzBOL(Dest_IsentoIcms)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@IndIeDest", nzINT(Dest_IndIeDest)))

        Dim DestinoOperação As String = String.Empty
        If Dest_UF = Emi_UF Then
            DestinoOperação = 1
        Else
            DestinoOperação = 2
        End If
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@idDest", DestinoOperação))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@indFinal", nzINT(Dest_indFinal)))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@indPres", 1))
        Cmd.Parameters.Add(New OleDb.OleDbParameter("@infCpl", nzNUL(Me.infCpl.Text)))

        
        Try
            Cmd.ExecuteNonQuery()
            Cmd.Parameters.Clear()
        Catch ex As Exception
            MessageBox.Show("Erro ao Gerar a NFe....", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


        'Salvar os Itens da NFe

        Dim CNNItens As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNNItens.Open()

        Dim cmdItens As New OleDbCommand


        Dim Sequencia_Var As Integer

        Dim t_TotalNFe As Double = 0
        Dim t_TotalPRODUTOS As Double = 0
        Dim t_ValorDESCONTO As Double = 0
        Dim t_BaseCalcICMS As Double = 0
        Dim t_ValorICMS As Double = 0
        Dim t_ValorICMSst As Double = 0
        Dim t_ValorIPI As Double = 0
        Dim t_ValorPIS As Double = 0
        Dim t_ValorCOFINS As Double = 0
        Dim t_ValorOUTROS As Double = 0
        Dim t_ValorFRETE As Double = 0
        Dim t_ValorII As Double = 0

        For Each row As DataGridViewRow In Me.Lista.Rows

            If nzBOL(row.Cells("cSelect").Value) = True Then

                Sequencia_Var += 1

                cmdItens.CommandText = "SELECT ItensPedido.Id, ItensPedido.PedidoSequencia, ItensPedido.PedidoInterno, ItensPedido.CodigoProduto AS cProd, ItensPedido.EmitidoNf, ItensPedido.Qtd, ItensPedido.ValorUnitario, " & _
                                       "ItensPedido.ValorDesconto, ItensPedido.vDescontoEspecial, ItensPedido.TotalProduto, ItensPedido.Ipi AS pIPI, ItensPedido.ValorIpi, ItensPedido.Icms AS pICMS, ItensPedido.VlrBCicms, ItensPedido.VlrIcms, Produtos.* " & _
                                       "FROM ItensPedido INNER JOIN Produtos ON ItensPedido.CodigoProduto = Produtos.CodigoProduto WHERE (ItensPedido.PedidoSequencia = " & Me.Pedido.Text & ") AND (ItensPedido.CodigoProduto = " & row.Cells("cProduto").Value & ") ORDER BY ItensPedido.PedidoSequencia,  ItensPedido.CodigoProduto"
                cmdItens.Connection = CNNItens
                Dim Dr As OleDbDataReader

                Dr = cmdItens.ExecuteReader
                Dr.Read()

                If Dr.HasRows Then


                    Sql = "INSERT INTO NFeItens (ChaveAcesso, Cprod, cEAN, xProd, NCM, CEST,CFOP, uCom, qCom, vUnCom, vProd, uTrib, qTrib, vUnTrib, cEANTrib, cstIPI, tCalcIpi, cEnq, vBCipi, pIPI, vIPI, cstICMS, origemICMS, modBCicms, vBCicms, pICMS, vICMS, vBCSTRet, vICMSSTRet, pCredSN, vCredICMSSN, cstPIS, vBCpis, pPIS, vPis, cstCOFINS, vBCcofins, pCOFINS, vCOFINS, vDesc, vFrete, vOutro, vBCII, vDespAdu, vII, vIOF, aliqNac, aliqImp, vTotTrib, IdImposto, IndTot, Sequencia, Autenticador ) VALUES (@ChaveAcesso, @Cprod, @cEAN, @xProd, @NCM, @CEST, @CFOP, @uCom, qCom, @vUnCom, @vProd, @uTrib, @qTrib, @vUnTrib, @cEANTrib, @cstIPI, @tCalcIpi, @cEnq, @vBCipi, @pIPI, @vIPI, @cstICMS, @origemICMS, @modBCicms, @vBCicms, @pICMS, @vICMS, @vBCSTRet, @vICMSSTRet, @pCredSN, @vCredICMSSN, @cstPIS, @vBCpis, @pPIS, @vPis, @cstCOFINS, @vBCcofins, @pCOFINS, @vCOFINS, @vDesc, @vFrete, @vOutro, @vBCII, @vDespAdu, @vII, @vIOF, @aliqNac, @aliqImp, @vTotTrib, @IdImposto, @IndTot, @Sequencia, @Autenticador )"
                    Cmd.CommandText = Sql


                    Cmd.Parameters.Add("@ChaveAcesso", OleDbType.VarChar, 45).Value = Chave_Acesso
                    Cmd.Parameters.Add("@Cprod", OleDbType.VarChar, 20).Value = nzINT(Dr.Item("CodigoProduto"))
                    Cmd.Parameters.Add("@cEAN", OleDbType.VarChar, 13).Value = nzNUL(Dr.Item("Ean"))
                    Cmd.Parameters.Add("@xProd", OleDbType.VarChar, 80).Value = nzNUL(Dr.Item("Descrição"))
                    Cmd.Parameters.Add("@NCM", OleDbType.VarChar, 8).Value = nzNUL(Dr.Item("CF"))
                    Cmd.Parameters.Add("@CEST", OleDbType.VarChar, 7).Value = nzNUL(Dr.Item("CEST"))

                    Dim CFOPvar As String = String.Empty
                    Dim IcmsVar As Double = 0


                    If Dr.Item("Tipo_Item") = "04" Then    ' 04 - Produto acabado: o produto que possua as seguintes características, cumulativamente: oriundo do processo produtivo; produto final resultante do objeto da atividade econômica do contribuinte; e pronto para ser comercializado 
                        If DestinoOperação = 1 Then 'Operação no estado
                            CFOPvar = nzNUL(Dr.Item("cfopVendaEstado"))
                            IcmsVar = nzNUM(Dr.Item("ICMSVendaEstado"))
                        Else 'Operação fora do estado
                            CFOPvar = nzNUL(Dr.Item("cfopVendaInterestado"))
                            IcmsVar = nzNUM(Dr.Item("ICMSVendaInterestado"))
                        End If
                    End If


                    If Dr.Item("Tipo_Item") = "00" Then  ' 00 - Mercadoria para revenda: produto adquirido para comercialização 
                        If DestinoOperação = 1 Then 'Operação no estado
                            CFOPvar = nzNUL(Dr.Item("cfopRevendaEstado"))
                            IcmsVar = nzNUM(Dr.Item("ICMSRevendaEstado"))
                        Else 'Operação fora do estado
                            CFOPvar = nzNUL(Dr.Item("cfopRevendaInterestado"))
                            IcmsVar = nzNUM(Dr.Item("ICMSRevendaInterestado"))
                        End If
                    End If


                    Cmd.Parameters.Add("@CFOP", OleDbType.VarChar, 4).Value = nzNUL(CFOPvar)
                    Cmd.Parameters.Add("@uCom", OleDbType.VarChar, 6).Value = nzNUL(Dr.Item("UnidadeMedida"))
                    Cmd.Parameters.Add("@qCom", OleDbType.Double).Value = nzNUM(Dr.Item("Qtd"))
                    Cmd.Parameters.Add("@vUnCom", OleDbType.Double).Value = nzNUM(Dr.Item("ValorUnitario"))

                    Dim TotalProduto As Double = FormatNumber(NzZero(Dr.Item("TotalProduto")), 2)
                    Cmd.Parameters.Add("@vProd", OleDbType.Double).Value = nzNUM(TotalProduto)

                    Cmd.Parameters.Add("@uTrib", OleDbType.VarChar, 6).Value = nzNUL(Dr.Item("UnidadeMedida"))
                    Cmd.Parameters.Add("@qTrib", OleDbType.Double).Value = nzNUM(Dr.Item("Qtd"))
                    Cmd.Parameters.Add("@vUnTrib", OleDbType.Double).Value = nzNUM(Dr.Item("ValorUnitario"))
                    Cmd.Parameters.Add("@cEANTrib", OleDbType.VarChar, 13).Value = nzNUL(Dr.Item("cEanTrib"))


                    Dim ValorIpi As Double = 0
                    Select Case Dr.Item("cstIPI")
                        Case "50" 'IPI 50 - Saída Tributada
                            Cmd.Parameters.Add("@cstIPI", OleDbType.VarChar, 2).Value = Dr.Item("cstIPI")
                            Cmd.Parameters.Add("@tCalcIpi", OleDbType.VarChar, 6).Value = Dr.Item("tCalcIpi")
                            Cmd.Parameters.Add("@cEnq", OleDbType.VarChar, 3).Value = Dr.Item("cEnq")
                            Cmd.Parameters.Add("@vBCipi", OleDbType.Double).Value = TotalProduto
                            Cmd.Parameters.Add("@pIPI", OleDbType.Double).Value = Dr.Item("pIPI")
                            ValorIpi = FormatNumber(NzZero(Dr.Item("ValorIpi")), 2)
                            Cmd.Parameters.Add("@vIPI", OleDbType.Double).Value = ValorIpi
                        Case "51" 'IPI 51 - Saída tributada com alíquota zero
                            Cmd.Parameters.Add("@cstIPI", OleDbType.VarChar, 2).Value = Dr.Item("cstIPI")
                            Cmd.Parameters.Add("@tCalcIpi", OleDbType.VarChar, 6).Value = Dr.Item("tCalcIpi")
                            Cmd.Parameters.Add("@cEnq", OleDbType.VarChar, 3).Value = Dr.Item("cEnq")
                            Cmd.Parameters.Add("@vBCipi", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pIPI", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vIPI", OleDbType.Double).Value = 0
                        Case "52" 'IPI 52 - Saída isenta
                            Cmd.Parameters.Add("@cstIPI", OleDbType.VarChar, 2).Value = Dr.Item("cstIPI")
                            Cmd.Parameters.Add("@tCalcIpi", OleDbType.VarChar, 6).Value = Dr.Item("tCalcIpi")
                            Cmd.Parameters.Add("@cEnq", OleDbType.VarChar, 3).Value = Dr.Item("cEnq")
                            Cmd.Parameters.Add("@vBCipi", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pIPI", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vIPI", OleDbType.Double).Value = 0
                        Case "53" 'IPI 53 - Saída não-tributada
                            Cmd.Parameters.Add("@cstIPI", OleDbType.VarChar, 2).Value = Dr.Item("cstIPI")
                            Cmd.Parameters.Add("@tCalcIpi", OleDbType.VarChar, 6).Value = Dr.Item("tCalcIpi")
                            Cmd.Parameters.Add("@cEnq", OleDbType.VarChar, 3).Value = Dr.Item("cEnq")
                            Cmd.Parameters.Add("@vBCipi", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pIPI", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vIPI", OleDbType.Double).Value = 0
                        Case "54" 'IPI 54 - Saída imune
                            Cmd.Parameters.Add("@cstIPI", OleDbType.VarChar, 2).Value = Dr.Item("cstIPI")
                            Cmd.Parameters.Add("@tCalcIpi", OleDbType.VarChar, 6).Value = Dr.Item("tCalcIpi")
                            Cmd.Parameters.Add("@cEnq", OleDbType.VarChar, 3).Value = Dr.Item("cEnq")
                            Cmd.Parameters.Add("@vBCipi", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pIPI", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vIPI", OleDbType.Double).Value = 0
                        Case "55" 'IPI 55 - Saída com suspensão
                            Cmd.Parameters.Add("@cstIPI", OleDbType.VarChar, 2).Value = Dr.Item("cstIPI")
                            Cmd.Parameters.Add("@tCalcIpi", OleDbType.VarChar, 6).Value = Dr.Item("tCalcIpi")
                            Cmd.Parameters.Add("@cEnq", OleDbType.VarChar, 3).Value = Dr.Item("cEnq")
                            Cmd.Parameters.Add("@vBCipi", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pIPI", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vIPI", OleDbType.Double).Value = 0
                    End Select

                    Dim BcImcs As Double = 0
                    Dim TotalIcms As Double = 0
                    Select Case Dr.Item("Cst")
                        Case "00"
                            Cmd.Parameters.Add("@cstICMS", OleDbType.VarChar, 3).Value = Dr.Item("Cst")
                            Cmd.Parameters.Add("@origemICMS", OleDbType.VarChar, 1).Value = Dr.Item("OrigemIcms")
                            Cmd.Parameters.Add("@modBCicms", OleDbType.VarChar, 1).Value = Dr.Item("ModBcIcms")

                            If Dest_indFinal = 0 Then
                                BcImcs = FormatNumber(TotalProduto, 2)
                            Else
                                BcImcs = FormatNumber(TotalProduto + ValorIpi, 2)
                            End If
                            Cmd.Parameters.Add("@vBCicms", OleDbType.Double).Value = BcImcs
                            Cmd.Parameters.Add("@pICMS", OleDbType.Double).Value = IcmsVar
                            TotalIcms = FormatNumber((NzZero(BcImcs) * NzZero(IcmsVar)) / 100, 2)
                            Cmd.Parameters.Add("@vICMS", OleDbType.Double).Value = TotalIcms
                            Cmd.Parameters.Add("@vBCSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMSSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCredSN", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vCredICMSSN", OleDbType.Double).Value = 0

                        Case "10"
                        Case "20"
                        Case "30"
                        Case "40"
                            Cmd.Parameters.Add("@cstICMS", OleDbType.VarChar, 3).Value = Dr.Item("Cst")
                            Cmd.Parameters.Add("@origemICMS", OleDbType.VarChar, 1).Value = Dr.Item("OrigemIcms")
                            Cmd.Parameters.Add("@modBCicms", OleDbType.VarChar, 1).Value = Dr.Item("ModBcIcms")
                            Cmd.Parameters.Add("@vBCicms", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vBCSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMSSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCredSN", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vCredICMSSN", OleDbType.Double).Value = 0
                        Case "41"
                            Cmd.Parameters.Add("@cstICMS", OleDbType.VarChar, 3).Value = Dr.Item("Cst")
                            Cmd.Parameters.Add("@origemICMS", OleDbType.VarChar, 1).Value = Dr.Item("OrigemIcms")
                            Cmd.Parameters.Add("@modBCicms", OleDbType.VarChar, 1).Value = Dr.Item("ModBcIcms")
                            Cmd.Parameters.Add("@vBCicms", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vBCSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMSSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCredSN", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vCredICMSSN", OleDbType.Double).Value = 0
                        Case "50"
                            Cmd.Parameters.Add("@cstICMS", OleDbType.VarChar, 3).Value = Dr.Item("Cst")
                            Cmd.Parameters.Add("@origemICMS", OleDbType.VarChar, 1).Value = Dr.Item("OrigemIcms")
                            Cmd.Parameters.Add("@modBCicms", OleDbType.VarChar, 1).Value = Dr.Item("ModBcIcms")
                            Cmd.Parameters.Add("@vBCicms", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vBCSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMSSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCredSN", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vCredICMSSN", OleDbType.Double).Value = 0
                        Case "51"
                            Cmd.Parameters.Add("@cstICMS", OleDbType.VarChar, 3).Value = Dr.Item("Cst")
                            Cmd.Parameters.Add("@origemICMS", OleDbType.VarChar, 1).Value = Dr.Item("OrigemIcms")
                            Cmd.Parameters.Add("@modBCicms", OleDbType.VarChar, 1).Value = Dr.Item("ModBcIcms")
                            Cmd.Parameters.Add("@vBCicms", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vBCSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMSSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCredSN", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vCredICMSSN", OleDbType.Double).Value = 0
                        Case "60"
                            Cmd.Parameters.Add("@cstICMS", OleDbType.VarChar, 3).Value = Dr.Item("Cst")
                            Cmd.Parameters.Add("@origemICMS", OleDbType.VarChar, 1).Value = Dr.Item("OrigemIcms")
                            Cmd.Parameters.Add("@modBCicms", OleDbType.VarChar, 1).Value = Dr.Item("ModBcIcms")
                            Cmd.Parameters.Add("@vBCicms", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vBCSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMSSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCredSN", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vCredICMSSN", OleDbType.Double).Value = 0
                        Case "70"
                        Case "90"
                        Case "101"
                        Case "102", "103", "300", "400"
                            Cmd.Parameters.Add("@cstICMS", OleDbType.VarChar, 3).Value = Dr.Item("Cst")
                            Cmd.Parameters.Add("@origemICMS", OleDbType.VarChar, 1).Value = Dr.Item("OrigemIcms")
                            Cmd.Parameters.Add("@modBCicms", OleDbType.VarChar, 1).Value = Dr.Item("ModBcIcms")
                            Cmd.Parameters.Add("@vBCicms", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMS", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vBCSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vICMSSTRet", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCredSN", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@vCredICMSSN", OleDbType.Double).Value = 0
                        Case "201"
                        Case "202"
                        Case "203"
                        Case "500"
                        Case "900"
                    End Select

                    Dim ValorPis As Double = 0
                    Select Case Dr.Item("cstPIS")
                        Case "01"
                            Cmd.Parameters.Add("@cstPIS", OleDbType.VarChar, 2).Value = Dr.Item("cstPIS")
                            Cmd.Parameters.Add("@vBCpis", OleDbType.Double).Value = TotalProduto
                            Cmd.Parameters.Add("@pPIS", OleDbType.Double).Value = Dr.Item("pPIS")
                            ValorPis = FormatNumber((TotalProduto * NzZero(Dr.Item("pPIS"))) / 100, 2)
                            Cmd.Parameters.Add("@vPis", OleDbType.Double).Value = ValorPis
                        Case "02"
                            Cmd.Parameters.Add("@cstPIS", OleDbType.VarChar, 2).Value = Dr.Item("cstPIS")
                            Cmd.Parameters.Add("@vBCpis", OleDbType.Double).Value = TotalProduto
                            Cmd.Parameters.Add("@pPIS", OleDbType.Double).Value = Dr.Item("pPIS")
                            ValorPis = FormatNumber((TotalProduto * NzZero(Dr.Item("pPIS"))) / 100, 2)
                            Cmd.Parameters.Add("@vPis", OleDbType.Double).Value = ValorPis
                        Case "04"
                            Cmd.Parameters.Add("@cstPIS", OleDbType.VarChar, 2).Value = Dr.Item("cstPIS")
                            Cmd.Parameters.Add("@vBCpis", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pPIS", OleDbType.Double).Value = 0
                            ValorPis = 0
                            Cmd.Parameters.Add("@vPis", OleDbType.Double).Value = ValorPis
                        Case "05"
                            Cmd.Parameters.Add("@cstPIS", OleDbType.VarChar, 2).Value = Dr.Item("cstPIS")
                            Cmd.Parameters.Add("@vBCpis", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pPIS", OleDbType.Double).Value = 0
                            ValorPis = 0
                            Cmd.Parameters.Add("@vPis", OleDbType.Double).Value = ValorPis
                        Case "06"
                            Cmd.Parameters.Add("@cstPIS", OleDbType.VarChar, 2).Value = Dr.Item("cstPIS")
                            Cmd.Parameters.Add("@vBCpis", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pPIS", OleDbType.Double).Value = 0
                            ValorPis = 0
                            Cmd.Parameters.Add("@vPis", OleDbType.Double).Value = ValorPis
                        Case "07"
                            Cmd.Parameters.Add("@cstPIS", OleDbType.VarChar, 2).Value = Dr.Item("cstPIS")
                            Cmd.Parameters.Add("@vBCpis", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pPIS", OleDbType.Double).Value = 0
                            ValorPis = 0
                            Cmd.Parameters.Add("@vPis", OleDbType.Double).Value = ValorPis
                        Case "08"
                            Cmd.Parameters.Add("@cstPIS", OleDbType.VarChar, 2).Value = Dr.Item("cstPIS")
                            Cmd.Parameters.Add("@vBCpis", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pPIS", OleDbType.Double).Value = 0
                            ValorPis = 0
                            Cmd.Parameters.Add("@vPis", OleDbType.Double).Value = ValorPis
                        Case "09"
                            Cmd.Parameters.Add("@cstPIS", OleDbType.VarChar, 2).Value = Dr.Item("cstPIS")
                            Cmd.Parameters.Add("@vBCpis", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pPIS", OleDbType.Double).Value = 0
                            ValorPis = 0
                            Cmd.Parameters.Add("@vPis", OleDbType.Double).Value = ValorPis
                    End Select

                    Dim ValorCOFINS As Double = 0
                    Select Case Dr.Item("cstCOFINS")
                        Case "01"
                            Cmd.Parameters.Add("@cstCOFINS", OleDbType.VarChar, 2).Value = Dr.Item("cstCOFINS")
                            Cmd.Parameters.Add("@vBCcofins", OleDbType.Double).Value = TotalProduto
                            Cmd.Parameters.Add("@pCOFINS", OleDbType.Double).Value = Dr.Item("pCOFINS")
                            ValorCOFINS = FormatNumber((TotalProduto * NzZero(Dr.Item("pCOFINS"))) / 100, 2)
                            Cmd.Parameters.Add("@vCOFINS", OleDbType.Double).Value = ValorCOFINS
                        Case "02"
                            Cmd.Parameters.Add("@cstCOFINS", OleDbType.VarChar, 2).Value = Dr.Item("cstCOFINS")
                            Cmd.Parameters.Add("@vBCcofins", OleDbType.Double).Value = TotalProduto
                            Cmd.Parameters.Add("@pCOFINS", OleDbType.Double).Value = Dr.Item("pCOFINS")
                            ValorCOFINS = FormatNumber((TotalProduto * NzZero(Dr.Item("pCOFINS"))) / 100, 2)
                            Cmd.Parameters.Add("@vCOFINS", OleDbType.Double).Value = ValorCOFINS
                        Case "04"
                            Cmd.Parameters.Add("@cstCOFINS", OleDbType.VarChar, 2).Value = Dr.Item("cstCOFINS")
                            Cmd.Parameters.Add("@vBCcofins", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCOFINS", OleDbType.Double).Value = 0
                            ValorCOFINS = 0
                            Cmd.Parameters.Add("@vCOFINS", OleDbType.Double).Value = ValorCOFINS
                        Case "05"
                            Cmd.Parameters.Add("@cstCOFINS", OleDbType.VarChar, 2).Value = Dr.Item("cstCOFINS")
                            Cmd.Parameters.Add("@vBCcofins", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCOFINS", OleDbType.Double).Value = 0
                            ValorCOFINS = 0
                            Cmd.Parameters.Add("@vCOFINS", OleDbType.Double).Value = ValorCOFINS
                        Case "06"
                            Cmd.Parameters.Add("@cstCOFINS", OleDbType.VarChar, 2).Value = Dr.Item("cstCOFINS")
                            Cmd.Parameters.Add("@vBCcofins", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCOFINS", OleDbType.Double).Value = 0
                            ValorCOFINS = 0
                            Cmd.Parameters.Add("@vCOFINS", OleDbType.Double).Value = ValorCOFINS
                        Case "07"
                            Cmd.Parameters.Add("@cstCOFINS", OleDbType.VarChar, 2).Value = Dr.Item("cstCOFINS")
                            Cmd.Parameters.Add("@vBCcofins", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCOFINS", OleDbType.Double).Value = 0
                            ValorCOFINS = 0
                            Cmd.Parameters.Add("@vCOFINS", OleDbType.Double).Value = ValorCOFINS
                        Case "08"
                            Cmd.Parameters.Add("@cstCOFINS", OleDbType.VarChar, 2).Value = Dr.Item("cstCOFINS")
                            Cmd.Parameters.Add("@vBCcofins", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCOFINS", OleDbType.Double).Value = 0
                            ValorCOFINS = 0
                            Cmd.Parameters.Add("@vCOFINS", OleDbType.Double).Value = ValorCOFINS
                        Case "09"
                            Cmd.Parameters.Add("@cstCOFINS", OleDbType.VarChar, 2).Value = Dr.Item("cstCOFINS")
                            Cmd.Parameters.Add("@vBCcofins", OleDbType.Double).Value = 0
                            Cmd.Parameters.Add("@pCOFINS", OleDbType.Double).Value = 0
                            ValorCOFINS = 0
                            Cmd.Parameters.Add("@vCOFINS", OleDbType.Double).Value = ValorCOFINS
                    End Select


                    Cmd.Parameters.Add("@vDesc", OleDbType.Double).Value = NzZero(Dr.Item("ValorDesconto")) + NzZero(Dr.Item("vDescontoEspecial"))
                    Cmd.Parameters.Add("@vFrete", OleDbType.Double).Value = 0
                    Cmd.Parameters.Add("@vOutro", OleDbType.Double).Value = 0
                    Cmd.Parameters.Add("@vBCII", OleDbType.Double).Value = 0
                    Cmd.Parameters.Add("@vDespAdu", OleDbType.Double).Value = 0
                    Cmd.Parameters.Add("@vII", OleDbType.Double).Value = 0
                    Cmd.Parameters.Add("@vIOF", OleDbType.Double).Value = 0
                    Cmd.Parameters.Add("@aliqNac", OleDbType.Double).Value = 0 'Ibpt
                    Cmd.Parameters.Add("@aliqImp", OleDbType.Double).Value = 0 'Ibpt
                    Cmd.Parameters.Add("@vTotTrib", OleDbType.Double).Value = 0 'Ibpt

                    Cmd.Parameters.Add("@IdImposto", OleDbType.VarChar, 40).Value = "PADRÃO"
                    Cmd.Parameters.Add("@IndTot", OleDbType.VarChar, 1).Value = 1
                    Cmd.Parameters.Add("@Sequencia", OleDbType.Integer).Value = Sequencia_Var
                    Cmd.Parameters.Add("@Autenticador", OleDbType.VarChar, 1).Value = AutenticadorNFe


                    t_TotalPRODUTOS += TotalProduto
                    t_ValorOUTROS = 0
                    t_ValorFRETE = 0
                    t_ValorII = 0
                    t_ValorDESCONTO += FormatNumber(NzZero(Dr.Item("ValorDesconto")), 2)
                    t_BaseCalcICMS += FormatNumber(BcImcs, 2)
                    t_ValorICMS += FormatNumber(TotalIcms, 2)
                    t_ValorICMSst = 0
                    t_ValorIPI += FormatNumber(ValorIpi, 2)
                    t_ValorPIS += FormatNumber(ValorPis, 2)
                    t_ValorCOFINS += FormatNumber(ValorCOFINS, 2)



                    Try
                        Cmd.ExecuteNonQuery()
                        Cmd.Parameters.Clear()
                    Catch ex As Exception
                        MessageBox.Show("Erro ao Adicionar o item a NFe....", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                    Dr.Close()
                Else
                    Dr.Close()
                End If
            End If

        Next row


        t_TotalNFe = t_TotalPRODUTOS + t_ValorIPI - t_ValorDESCONTO + t_ValorFRETE + t_ValorOUTROS + t_ValorII

        'Salvar Totais da NFe

        Cmd.CommandText = "Update NFe set vProdTot = @1, vBCicmsTot = @2, vIcmsTot = @3, vBCSTtot = @4, vSTtot = @5, vFrete = @6, vSeg = @7, vDesc = @8, vII = @9, vIPI = @10, vPIS = @11, vCOFINS = @12, vOUTROS = @13, vNF = @14 Where ChaveAcesso = '" & Chave_Acesso & "'"

        Cmd.Parameters.Add("@1", OleDbType.Double).Value = nzNUM(t_TotalPRODUTOS)
        Cmd.Parameters.Add("@2", OleDbType.Double).Value = nzNUM(t_BaseCalcICMS)
        Cmd.Parameters.Add("@3", OleDbType.Double).Value = nzNUM(t_ValorICMS)
        Cmd.Parameters.Add("@4", OleDbType.Double).Value = nzNUM(0)
        Cmd.Parameters.Add("@5", OleDbType.Double).Value = nzNUM(t_ValorICMSst)
        Cmd.Parameters.Add("@6", OleDbType.Double).Value = nzNUM(t_ValorFRETE)
        Cmd.Parameters.Add("@7", OleDbType.Double).Value = nzNUM(0)
        Cmd.Parameters.Add("@8", OleDbType.Double).Value = nzNUM(t_ValorDESCONTO)
        Cmd.Parameters.Add("@9", OleDbType.Double).Value = nzNUM(t_ValorII)
        Cmd.Parameters.Add("@10", OleDbType.Double).Value = nzNUM(t_ValorIPI)
        Cmd.Parameters.Add("@11", OleDbType.Double).Value = nzNUM(t_ValorPIS)
        Cmd.Parameters.Add("@12", OleDbType.Double).Value = nzNUM(t_ValorCOFINS)
        Cmd.Parameters.Add("@13", OleDbType.Double).Value = nzNUM(t_ValorOUTROS)
        Cmd.Parameters.Add("@14", OleDbType.Double).Value = nzNUM(t_TotalNFe)
        Cmd.ExecuteNonQuery()

        CNN.Close()


        My.Forms.NFeFaturas.NFeNumero = nNF
        My.Forms.NFeFaturas.NFeChave = Chave_Acesso
        My.Forms.NFeFaturas.DataEmissao = dEmi
        My.Forms.NFeFaturas.ValorNFe = FormatNumber(t_TotalNFe, 2)
        My.Forms.NFeFaturas.ShowDialog()

        'System.Diagnostics.Process.Start(LocalExeNFe & "EFocusNFeV2.exe", "NF-" & nNF)
        Shell(LocalExeNFe & "EFocusNFeV2.exe /NF-" & nNF, AppWinStyle.NormalFocus, True)

        'Dim myProcess As Process = System.Diagnostics.Process.Start(LocalExeNFe & "EFocusNFeV2.exe", "/NF-" & nNF)
        'myProcess.WaitForExit()
        'myProcess.Close()


        CNN.Open()
        Sql = "Select * from NFe where ChaveAcesso = '" & Chave_Acesso & "'"
        Dim cmdConsulta As New OleDbCommand(Sql, CNN)
        Dim DrConsulta As OleDbDataReader

        DrConsulta = cmdConsulta.ExecuteReader
        DrConsulta.Read()

        Dim C_ChaveNFe As String = String.Empty
        Dim C_cState As String = String.Empty
        Dim C_xMotivo As String = String.Empty
        Dim C_NF As String = String.Empty
        If DrConsulta.HasRows Then
            C_ChaveNFe = DrConsulta.Item("ChaveAcesso") & ""
            C_cState = DrConsulta.Item("cStat") & ""
            C_xMotivo = DrConsulta.Item("xMotivo") & ""
            C_NF = DrConsulta.Item("nNF") & ""
            MessageBox.Show("NFe gerada com o Numero: " & C_NF & Chr(13) & "Chave de Acesso: " & C_ChaveNFe & Chr(13) & Chr(13) & "Status da NFe: " & C_cState & "-" & C_xMotivo, "Geração de NFe", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        DrConsulta.Close()
        CNN.Close()


        Dim CNNPedido As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNNPedido.Open()

        Sql = "Update Pedido Set NFe=@1,ChaveNFe=@2,cStat=@3,xMotivo=@4 Where Pedido.PedidoSequencia = " & Me.Pedido.Text

        Dim CmdPedido As New OleDb.OleDbCommand(Sql, CNNPedido)

        CmdPedido.Parameters.Add(New OleDb.OleDbParameter("@1", nzNUL(C_NF)))
        CmdPedido.Parameters.Add(New OleDb.OleDbParameter("@2", nzNUL(C_ChaveNFe)))
        CmdPedido.Parameters.Add(New OleDb.OleDbParameter("@3", nzNUL(C_cState)))
        CmdPedido.Parameters.Add(New OleDb.OleDbParameter("@4", nzNUL(C_xMotivo)))
        CmdPedido.ExecuteNonQuery()

        CNNPedido.Close()


        If My.Forms.PedidoOS.Visible = True Then
            My.Forms.PedidoOS.ChaveNFe.Text = "NFe: " & C_NF & " - " & C_ChaveNFe
            My.Forms.PedidoOS.cState.Text = "Status: " & C_cState & " - " & C_xMotivo
        End If

        If My.Forms.SellShoesGerarNFe.Visible = True Then
            My.Forms.SellShoesGerarNFe.ChaveNFe.Text = "NFe: " & C_NF & " - " & C_ChaveNFe
            My.Forms.SellShoesGerarNFe.cState.Text = "Status: " & C_cState & " - " & C_xMotivo
        End If

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub SalvaDadosComplementarNFe()

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        CNN.Open()

        Dim Sql As String = "Update NFe set DigestValue = @1, Protocolo = @2, nRec = @3, dhRecbto = @4, cStat = @5, xMotivo = @6, StatusNFe= @7, Tempo = @8, DanfeImpresso = @9, StringXMLAssinado = @10, AutorizaçaoStringXml = @11, StringRecibo = @12, DataEmissao = @13 Where ChaveAcesso = '" & Chave_Acesso & "'"
        Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

        cmd.Parameters.Add(New OleDb.OleDbParameter("@1", NzVlr(DigestValue)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@2", NzVlr(Protocolo & "")))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@3", NzVlr(nRecibo & "")))

        Dim dhRecbtoLimpo As String = ""
        If dhRecbto <> "" Then
            dhRecbtoLimpo = Mid(dhRecbto, 1, 19)
        End If

        cmd.Parameters.Add(New OleDb.OleDbParameter("@4", NzVlr(dhRecbtoLimpo & "")))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@5", NzVlr(cStat) & ""))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@6", NzVlr(xMotivo & "")))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@7", NzVlr(StatusNFe & "")))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@8", NzVlr("0")))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@9", NzVlr("N")))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@10", NzVlr(StringXMLAssinado & "")))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@11", NzVlr(XmlAutorizaçaoUso & "")))
        cmd.Parameters.Add(New OleDb.OleDbParameter("@12", NzVlr(StringRecibo & "")))
        Dim Dt As String = Format(CDate(Mid(dEmi, 1, 10)), "dd/MM/yyyy")
        cmd.Parameters.Add(New OleDb.OleDbParameter("@13", Dt))



        Try
            cmd.ExecuteNonQuery()
            CNN.Close()
        Catch x As Exception
            CNN.Close()
            MsgBox(x.Message)
            Exit Sub
        End Try


    End Sub

    Private Sub LoteSalvarNumeroRecibo(ByVal Lote As Integer, ByVal Recibo As String)
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBDNFe(LocalNomeNFeDB))
        CNN.Open()


        Dim Sql As String = "Update Lote set nRec = @1 where IdLote = " & Lote
        Dim Cmd1 As New OleDb.OleDbCommand(Sql, CNN)

        Cmd1.Parameters.Add(New OleDb.OleDbParameter("@1", Recibo & ""))

        Try
            Cmd1.ExecuteNonQuery()
            CNN.Close()
        Catch ex As Exception
            CNN.Close()
            MsgBox(ex.Message, 64, "Validação de Dados")
        End Try

    End Sub

#End Region


    Private Sub btSalvarInfCPL_Click(sender As Object, e As EventArgs) Handles btSalvarInfCPL.Click
        My.Forms.NFeSalvarInfCPL.ShowDialog()
    End Sub

    Private Sub btLocalizaInfAdicionais_Click(sender As Object, e As EventArgs) Handles btLocalizaInfAdicionais.Click
        My.Forms.NFeInfCPLProcura.ShowDialog()
    End Sub

    
    Public Function LocalizaUFDesc(cUFvar As String)

        If cUFvar = "" Then
            Return ""
            Exit Function
        End If

        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "Select * from UF where CodigoUF = '" & cUFvar & "'"
        Dim CMD As New OleDbCommand(Sql, CNN)
        Dim DR As OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows = True Then
            Return DR.Item("NomeUF") & ""
        Else
            Return ""
        End If

        DR.Close()
        CNN.Close()
    End Function

    Public Function LocalizaMunicipioUFDesc(cMunVar As String)

        If cMunVar = "" Then
            Return ""
            Exit Function
        End If

        Dim CNN As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "Select * from Municipio where CodMunicipio = '" & cMunVar & "'"
        Dim CMD As New OleDbCommand(Sql, CNN)
        Dim DR As OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows = True Then
            Return DR.Item("NomeMunic") & ""
        Else
            Return ""
        End If

        DR.Close()
        CNN.Close()
    End Function

    Private Sub CarregaListaProduto()

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        Sql = "SELECT ItensPedido.CodigoProduto, Produtos.Descrição, ItensPedido.Qtd, ItensPedido.ValorUnitario FROM ItensPedido INNER JOIN Produtos ON ItensPedido.CodigoProduto = Produtos.CodigoProduto WHERE (ItensPedido.PedidoSequencia = " & Me.Pedido.Text & ") Order by  ItensPedido.CodigoProduto"

        Dim da = New OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub btTodosProdutos_Click(sender As Object, e As EventArgs) Handles btTodosProdutos.Click

        For Each row As DataGridViewRow In Me.Lista.Rows
            row.Cells("cSelect").Value = True
        Next row

    End Sub

    Private Sub btLimparProdutos_Click(sender As Object, e As EventArgs) Handles btLimparProdutos.Click
        For Each row As DataGridViewRow In Me.Lista.Rows
            row.Cells("cSelect").Value = False
        Next row
    End Sub

    Private Sub Lista_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Lista.CellDoubleClick

        If Me.Lista.Rows(e.RowIndex).Cells("cSelect").Value = True Then
            Me.Lista.Rows(e.RowIndex).Cells("cSelect").Value = False
        Else
            Me.Lista.Rows(e.RowIndex).Cells("cSelect").Value = True
        End If

    End Sub

    Private Function RLiteral(ByVal Vlr As String)
        If Vlr.IndexOf("<") Then
            Vlr = Vlr.Replace("<", "&lt")
        End If
        If Vlr.IndexOf(">") Then
            Vlr = Vlr.Replace(">", "&gt")
        End If
        If Vlr.IndexOf("&") Then
            Vlr = Vlr.Replace("&", "&amp")
        End If
        If Vlr.IndexOf("""") Then
            Vlr = Vlr.Replace("""", "&quot")
        End If
        If Vlr.IndexOf("'") Then
            Vlr = Vlr.Replace("'", "&#39")
        End If

        Vlr = Trim(Vlr)
        Return Vlr
    End Function

    Public Function RChrAll(ByVal Vlr As Object)
        Dim StrTemp As String

        If IsDBNull(Vlr) Then
            Vlr = ""
        End If

        StrTemp = Vlr
        StrTemp = StrTemp.Replace("-", "")
        StrTemp = StrTemp.Replace("(", "")
        StrTemp = StrTemp.Replace(")", "")
        StrTemp = StrTemp.Replace(".", "")
        StrTemp = StrTemp.Replace("/", "")
        Return (StrTemp)
    End Function

    Public Function TrcVirgula(ByVal Vlr As String) As String

        Vlr = Vlr.Replace(".", "")
        Vlr = Vlr.Replace(",", ".")
        Return Vlr
    End Function

End Class