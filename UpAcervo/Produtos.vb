Imports System.Drawing.Printing
Imports System.Drawing.Printing.PrinterSettings
Imports Microsoft.Win32
Imports System.IO
Imports System.Threading
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class Produtos

    Private WithEvents PDoc As New PrintDocument()

    Dim CaminhoImagem As String = ""

    Dim A��o As New TrfGerais()

    Private OperationImage As Byte
    Private Operation As Byte
    Const INS As Byte = 0
    Const UPD As Byte = 1
    Const DEL As Byte = 2
    Const VAZ As Byte = 5

    Dim Tp As String


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Operation = VAZ
        CarregaComboProdutoTipo()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal cprod As String, ByVal ncm As String, ByVal vlr As Double)

        InitializeComponent()


        NovoBT_Click(Me, New EventArgs())
        CarregaComboProdutoTipo()


        Me.Descri��o.Text = cprod
        Me.ControlaEstoque.Text = "SIM"
        Me.Tipo.Text = "PRODUTO"
        Me.CF.Text = ncm
        Me.MostrarListaPreco.Text = "S"
        Me.ComissaoVenda.Text = "0,00"
        Me.EstoqueMinimo.Text = "0,00"
        Me.ValorVenda.Text = vlr.ToString()
        Me.ValorCompra.Text = vlr.ToString()
        Me.ValorVenda1.Text = "0,00"
        Me.ValorVenda2.Text = vlr.ToString()



    End Sub



    Private Enum TpRetornoCBO
        N�o = 0
        Sim = 1
    End Enum

    Private Sub FecharBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FecharBT.Click



        If (My.Forms.CompraXmlProdutoImportar.Visible And Operation <> INS) Then
            My.Forms.CompraXmlProdutoImportar.ListaItens.CurrentRow.Cells("cProdERP").Value = Me.CodigoProduto.Text
        End If


        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub NovoBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovoBT.Click
        If Adi = False Then
            MsgBox("O Usu�rio n�o tem permiss�o para Adicionar o registro, verifique com o Administrador.", 64, "Valida��o de Dados")
            A��o.Desbloquear_Controle(Me, False)
            Exit Sub
        End If

        A��o.LimpaTextBox(Me)
        Me.UltCompraTab.Visible = False


        Me.Tipo.SelectedValue = -1
        Me.ControlaEstoque.Text = ""
        Me.UnidadeMedida.Text = ""



        Me.TabOpcoes.SelectedTab = Me.TabOutras

        DesbloquearTextBox(Me, True)
        Me.CodigoProduto.Text = "0000"

        If UsarGrade = True Then
            Me.Multiplos.Text = 1
            Me.Multiplos.Enabled = False
        Else
            Me.Multiplos.Text = 0
            Me.Multiplos.Enabled = True
        End If

        Me.ControlaEstoque.Focus()
        Operation = INS

    End Sub

    Private Sub LocalizarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalizarBT.Click
        If Con = False Then
            MsgBox("O Usu�rio n�o tem permiss�o para Consultar registro, verifique com o Administrador.", 64, "Valida��o de Dados")
            A��o.Desbloquear_Controle(Me, False)
            Exit Sub
        End If

        My.Forms.ProcuraProduto.ShowDialog()


    End Sub

    Public Sub LocalizaDados()

        If Con = False Then
            MsgBox("O Usu�rio n�o tem permiss�o para Consultar registro, verifique com o Administrador.", 64, "Valida��o de Dados")
            A��o.Desbloquear_Controle(Me, False)
            Exit Sub
        End If

        If Me.CodigoProduto.Text = "" Then
            Exit Sub
        End If

        Dim tab As DevComponents.DotNetBar.TabItem = Me.TabOutras
        Me.TabOpcoes.SelectedTab = tab


        Me.Tipo.SelectedIndex = -1
        Me.UnidadeMedida.SelectedIndex = -1

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = "SELECT Produtos.*,Produtos.CodigoProduto, Marcas.Marca, Grupos.Descri��o, ProdutoLocal.SetorLocalDesc," _
                          & " Produtos.Cor, Cor.CorDesc, Produtos.TipoGrupo, TipoGrupo.TipoGrupoDesc, Produtos.SubGrupo, SubGrupo.SubGrupoDesc," _
                          & " Produtos.Referencia, CofinsCST.DescCSTcofins, IcmsCST.DescCSTicms, IcmsModalidadeBC.modBCDesc, IcmsOrigem.OrigemDesc, IpiCST.DescCSTipi, PisCST.DescCSTpis" _
                          & " FROM (((((((((((Produtos LEFT JOIN Grupos ON Produtos.C�digoGrupo = Grupos.C�digoGrupo)" _
                          & " LEFT JOIN Marcas ON Produtos.Marca = Marcas.Codigo)" _
                          & " LEFT JOIN ProdutoLocal ON Produtos.Localiza��o = ProdutoLocal.SetorLocal)" _
                          & " LEFT JOIN Cor ON Produtos.Cor = Cor.Codigo)" _
                          & " LEFT JOIN TipoGrupo ON Produtos.TipoGrupo = TipoGrupo.Codigo)" _
                          & " LEFT JOIN SubGrupo ON Produtos.SubGrupo = SubGrupo.Codigo)" _
                          & " LEFT JOIN CofinsCST ON Produtos.cstCofins = CofinsCST.CSTcofins)" _
                          & " LEFT JOIN IpiCST ON Produtos.CstIPI = IpiCST.CSTipi)" _
                          & " LEFT JOIN IcmsCST ON Produtos.Cst = IcmsCST.CSTicms)" _
                          & " LEFT JOIN IcmsOrigem ON Produtos.OrigemIcms = IcmsOrigem.Origem)" _
                          & " LEFT JOIN IcmsModalidadeBC ON Produtos.ModBcIcms = IcmsModalidadeBC.modBC)" _
                          & " LEFT JOIN PisCST ON Produtos.cstPis = PisCST.CSTpis" _
                          & " WHERE Produtos.CodigoProduto = " & Me.CodigoProduto.Text & " and Produtos.Inativo = False"

        Dim CMD As New OleDb.OleDbCommand(Sql, CNN)
        Dim DR As OleDb.OleDbDataReader

        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Me.CodigoProduto.Text = DR.Item("Produtos.CodigoProduto") & ""
            Me.Descri��o.Text = DR.Item("Produtos.Descri��o") & ""
            Me.Tipo.SelectedValue = DR.Item("Tipo")
            Me.ControlaEstoque.Text = DR.Item("ControlaEstoque") & ""
            Me.CodigoBarra.Text = DR.Item("CodigoBarra") & ""
            Me.UnidadeMedida.SelectedValue = (DR.Item("UnidadeMedida") & "")
            Me.Grupo.Text = DR.Item("C�digoGrupo") & ""
            Me.GrupoDesc.Text = DR.Item("Grupos.Descri��o") & ""
            Me.Marca.Text = DR.Item("Produtos.Marca") & ""
            Me.MarcaDesc.Text = DR.Item("Marcas.Marca") & ""
            Me.ValorCompra.Text = FormatCurrency(Nz(DR.Item("ValorCompra"), 3), 4)
            Me.ValorVenda.Text = FormatNumber(Nz(DR.Item("ValorVenda"), 3), 2)


            Me.Peso.Text = NzZero(DR.Item("Peso"))
            Me.DataUltimaCompra.Text = DR.Item("DataUltimaCompra") & ""
            Me.DataUltimaVenda.Text = DR.Item("DataUltimaVenda") & ""
            Me.CF.Text = Nz(DR.Item("CF"), 3)
            Me.ComissaoVenda.Text = NzZero(DR.Item("ComissaoVenda"))
            Me.Multiplos.Text = NzZero(DR.Item("Multiplos"))
            Me.EstoqueMinimo.Text = NzZero(DR.Item("EstoqueMinimo"))

            Me.MostrarListaPreco.Text = DR.Item("MostrarListaPreco") & ""

            txtValorCusto.Text = NzZero(DR.Item("Custo2"))

            Me.QuantidadeEstoque.Text = FormatNumber(Nz(DR.Item("QuantidadeEstoque"), 3), 4)

            Me.Localiza��o.Text = DR.Item("Localiza��o") & ""
            Me.Localiza��oDesc.Text = DR.Item("SetorLocalDesc") & ""
            Me.Referencia.Text = DR.Item("Produtos.Referencia") & ""
            Me.SubGrupo.Text = DR.Item("Produtos.SubGrupo") & ""
            Me.SubGrupoDesc.Text = DR.Item("SubGrupoDesc") & ""
            Me.TipoGrupo.Text = DR.Item("Produtos.TipoGrupo") & ""
            Me.TipoGrupoDesc.Text = DR.Item("TipoGrupoDesc") & ""
            Me.Cor.Text = DR.Item("Produtos.Cor") & ""
            Me.CorDesc.Text = DR.Item("CorDesc") & ""
            Me.TotalLocacao.Text = NzZero(DR.Item("QtdeLocado") & "")
            Me.ValorVenda1.Text = FormatNumber(NzZero(DR.Item("ValorVenda1") & ""), 2)
            Me.ValorVenda2.Text = FormatNumber(NzZero(DR.Item("ValorVenda2") & ""), 2)
            Me.ProdutoNaPromocao.Text = DR.Item("ProdutoNaPromocao") & ""
            Me.DataInicioPromocao.Text = DR.Item("DataInicioPromocao") & ""
            Me.DataFinalPromocao.Text = DR.Item("DataFinalPromocao") & ""
            Me.ValorPromocao.Text = FormatNumber(NzZero(DR.Item("ValorPromocao") & ""), 2)
            Me.txtEmLocacao.Text = FormatNumber(Nz(DR.Item("EmLocacao"), 3), 4)




            If UsarGrade = True Then
                Me.Multiplos.Enabled = False
            Else
                Me.Multiplos.Enabled = True
            End If



            DR.Close()

            Operation = UPD

            VisualizaFoto()

            Dim THRD As New Threading.Thread(AddressOf IniciaUltimasCompras)
            THRD.Priority = ThreadPriority.Highest
            THRD.IsBackground = True
            THRD.Start()
        Else

            A��o.LimpaTextBox(Me)
            Me.UltCompraTab.Visible = False


            Me.Tipo.SelectedValue = -1
            Me.ControlaEstoque.Text = ""
            Me.UnidadeMedida.Text = ""

            Me.TabOpcoes.SelectedTab = Me.TabOutras

            If UsarGrade = True Then
                Me.Multiplos.Text = 1
                Me.Multiplos.Enabled = False
            Else
                Me.Multiplos.Text = 0
                Me.Multiplos.Enabled = True
            End If
        End If

    End Sub

    Private Sub EditarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarBT.Click
        If Me.CodigoProduto.Text = "" Then
            MsgBox("N�o existe Produto para ser editado.", 64, "Valida��o de Dados")
            Exit Sub
        End If
        If Edi = False Then
            MsgBox("O Usu�rio n�o tem permiss�o para editar o registro, verifique com o Administrador.", 64, "Valida��o de Dados")
            A��o.Desbloquear_Controle(Me, False)
            Exit Sub
        End If
        Operation = UPD
        A��o.Desbloquear_Controle(Me, True)
        Me.Descri��o.Focus()
    End Sub

    Private Sub Grupo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grupo.KeyDown
        If e.KeyCode = Keys.F5 Then
            RetornoProcura = ""
            ChamaTelaProcura("Codigo", "Descric�o", "", "Grupos", "C�digoGrupo", "Descri��o", "", True)
            Me.Grupo.Text = RetornoProcura
            If Me.Grupo.Text <> "" Then
                A��o.Descri��o_ItenRegistro(Me.Grupo, Me.GrupoDesc, "Grupos", "C�digoGrupo", Me.Grupo.Text, "Descri��o", TrfGerais.TipoDados.Num�rico, True)
                Me.Grupo.Focus()
            End If
        End If
    End Sub

    Private Sub Marca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Marca.KeyDown
        If e.KeyCode = Keys.F5 Then
            RetornoProcura = ""
            ChamaTelaProcura("Codigo", "Descric�o", "", "Marcas", "Codigo", "Marca", "", True)
            Me.Marca.Text = RetornoProcura
            If Me.Marca.Text <> "" Then
                A��o.Descri��o_ItenRegistro(Me.Marca, Me.MarcaDesc, "Marcas", "Codigo", Me.Marca.Text, "Marca", TrfGerais.TipoDados.Num�rico, True)
                Me.Marca.Focus()
            End If
        End If
    End Sub

    Private Sub ValorVenda_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValorVenda.Leave
        If Me.ValorVenda.Text <> "" Then Me.ValorVenda.Text = FormatCurrency(Me.ValorVenda.Text, 4)
    End Sub

    Private Sub ValorCompra_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValorCompra.Leave
        If Me.ValorCompra.Text <> "" Then Me.ValorCompra.Text = FormatCurrency(Me.ValorCompra.Text, 4)
    End Sub

    Private Sub SalvarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarBT.Click
        'Area destinada para as validacoes

        If Me.CodigoProduto.Text = "" Then
            MsgBox("O C�digo do produto n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.CodigoProduto.Focus()
            Exit Sub
        ElseIf Me.Descri��o.Text = "" Then
            MsgBox("A descri��o do produto n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.Descri��o.Focus()
            Exit Sub
        ElseIf Me.Tipo.Text = "" Then
            MsgBox("O Tipo do produto n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.Tipo.Focus()
            Exit Sub
        ElseIf Me.CF.Text = "" Then
            MsgBox("O CF do produto n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.CF.Focus()
            Exit Sub
        ElseIf Me.UnidadeMedida.Text = "" Then
            MsgBox("A Unidade de Medida do Produto n�o foi informada o sistema ir� colocar a data atual de trabalho", 64, "Valida��o de Dados")
            Me.UnidadeMedida.Focus()
            Exit Sub
        ElseIf Me.Grupo.Text = "" Then
            MsgBox("O grupo do produto n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.Grupo.Focus()
            Exit Sub
        ElseIf Me.MostrarListaPreco.Text = "" Then
            MsgBox("O campo [Mostrar na Lista de Pre�o] n�o pode ser nulo, favor verificar.", 64, "Valida��o de Dados")
            Me.MostrarListaPreco.Focus()
            Exit Sub

        ElseIf Me.Marca.Text = "" Then
            MsgBox("A marca do produto n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.Marca.Focus()
            Exit Sub
        ElseIf Me.Cor.Text = "" Then
            MsgBox("A cor do produto n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.Cor.Focus()
            Exit Sub
        End If

        If Me.Tipo.Text = "" Then
            MessageBox.Show("O tipo do produto deve ser selecionado", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Tipo.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.ProdutoNaPromocao.Text) Then
            Me.ProdutoNaPromocao.Text = "N"
        End If



        If Me.ValorCompra.Text = "" Then
            Me.ValorCompra.Text = FormatCurrency(0, 2)
        End If

        If Me.ValorVenda.Text = "" Then
            MsgBox("O valor de venda do produto n�o foi informado, favor verificar.", 64, "Valida��o de Dados")
            Me.ValorVenda.Focus()
            Exit Sub
        End If


        If Me.Peso.Text = "" Then
            Me.Peso.Text = 0
        End If

        If Me.ControlaEstoque.Text = "" Then
            MessageBox.Show("O usu�rio deve definir se este item ser� ou n�o controlado o estoque.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ControlaEstoque.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(Multiplos.Text) Then
            MessageBox.Show("O usu�rio n�o pode definir Multiplos como vazio, Defina como zero ou com valores inteiros maiores que [0].", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Multiplos.Focus()
            Exit Sub
        End If





        If Me.ComissaoVenda.Text = "" Then Me.ComissaoVenda.Text = FormatNumber(0, 2)
        'Fim da Area destinada para as validacoes

        If Me.EstoqueMinimo.Text = "" Then Me.EstoqueMinimo.Text = FormatNumber(0, 4)

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

        If Operation = INS Then
            If Adi = False Then
                MsgBox("O Usu�rio n�o tem permiss�o para adicionar o registro, verifique com o Administrador.", 64, "Valida��o de Dados")
                Exit Sub
            End If
            CNN.Open()

            UltimoReg()

            If Me.CodigoProduto.Text = "0000" Then
                MsgBox("O sistema n�o conseguiu definir o ultimo c�digo para salvar o registro, verifique.", 64, "Valida��o de Dados")
                Exit Sub
            End If



            Dim Sql As String = "INSERT INTO Produtos (CodigoProduto, Descri��o, Tipo, ControlaEstoque, CodigoBarra, UnidadeMedida, C�digoGrupo, Marca, ValorCompra, ValorVenda, Peso, DataUltimaVenda, DataUltimaCompra, CF, QuantidadeEstoque, Empresa, Localiza��o, Referencia, Cor, ComissaoVenda, Multiplos, EstoqueMinimo, MostrarListaPreco, Atualizado, ValorVenda1, ValorVenda2, ProdutoNaPromocao, DataInicioPromocao, DataFinalPromocao, ValorPromocao)" _
                                           & " VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @22, @23, @24, @25, @26, @27, @28,@ProdutoNaPromocao, @DataInicioPromocao, @DataFinalPromocao, @ValorPromocao)"

            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.CodigoProduto.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Nz(Me.Descri��o.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Me.Tipo.SelectedValue))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.ControlaEstoque.Text, 1)))
            If Me.CodigoBarra.Text = "" Then
                Me.CodigoBarra.Text = Me.CodigoProduto.Text
            End If
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.CodigoBarra.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.UnidadeMedida.SelectedValue, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.Grupo.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.Marca.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", NzZero(Me.ValorCompra.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", NzZero(Me.ValorVenda.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.Peso.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.DataUltimaVenda.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(Me.DataUltimaCompra.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.CF.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", NzZero(Me.QuantidadeEstoque.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", CodEmpresa))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Localiza��o.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.Referencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@19", Nz(Me.Cor.Text, 1)))
        
            cmd.Parameters.Add(New OleDb.OleDbParameter("@22", NzZero(Me.ComissaoVenda.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@23", NzZero(Me.Multiplos.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@24", NzZero(Me.EstoqueMinimo.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@25", Nz(Me.MostrarListaPreco.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@26", True))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@27", NzZero(Me.ValorVenda1.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@28", NzZero(Me.ValorVenda2.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@ProdutoNaPromocao", Nz(Me.ProdutoNaPromocao.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@DataInicioPromocao", Nz(Me.DataInicioPromocao.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@DataFinalPromocao", Nz(Me.DataFinalPromocao.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@ValorPromocao", NzZero(Me.ValorPromocao.Text)))


            


            Try
                cmd.ExecuteNonQuery()
                MsgBox("Registro adicionado com sucesso", 64, "Valida��o de Dados")
                GerarLog(Me.Text, A��oTP.Adicionou, Me.CodigoProduto.Text)
                DesbloquearTextBox(Me, False)
                Operation = VAZ
            Catch ex As Exception
                MsgBox(ex.Message, 64, "Valida��o de Dados")
            End Try
            CNN.Close()

        ElseIf Operation = UPD Then
            If Edi = False Then
                MsgBox("O Usu�rio n�o tem permiss�o para editar o registro, verifique com o Administrador.", 64, "Valida��o de Dados")
                Exit Sub
            End If

            CNN.Open()

            Dim Sql As String = "UPDATE Produtos SET  Descri��o=@1, Tipo=@2, ControlaEstoque=@3, CodigoBarra=@4, UnidadeMedida=@5, C�digoGrupo=@6, Marca=@7, ValorCompra=@8, ValorVenda=@9, Peso=@10, " _
                              & "DataUltimaVenda=@11, DataUltimaCompra=@12, CF=@13, QuantidadeEstoque=@14, Empresa=@15, Localiza��o=@16, Referencia=@17, Cor=@18, " _
                              & "ComissaoVenda=@21, Multiplos=@22, EstoqueMinimo=@23, MostrarListaPreco=@24, Atualizado=@25, ValorVenda1=@26, ValorVenda2=@27,  ProdutoNaPromocao=@ProdutoNaPromocao, DataInicioPromocao=@DataInicioPromocao, DataFinalPromocao=@DataFinalPromocao, ValorPromocao=@ValorPromocao Where CodigoProduto = " & Me.CodigoProduto.Text
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.Parameters.Add(New OleDb.OleDbParameter("@1", Nz(Me.Descri��o.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@2", Me.Tipo.SelectedValue))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@3", Nz(Me.ControlaEstoque.Text, 1)))
            If Me.CodigoBarra.Text = "" Then
                Me.CodigoBarra.Text = Me.CodigoProduto.Text
            End If
            cmd.Parameters.Add(New OleDb.OleDbParameter("@4", Nz(Me.CodigoBarra.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@5", Nz(Me.UnidadeMedida.SelectedValue, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@6", Nz(Me.Grupo.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@7", Nz(Me.Marca.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@8", Nz(Me.ValorCompra.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@9", Nz(Me.ValorVenda.Text, 3)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@10", Nz(Me.Peso.Text, 3)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@11", Nz(Me.DataUltimaVenda.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@12", Nz(Me.DataUltimaCompra.Text, 1)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@13", Nz(Me.CF.Text, 1)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@14", Nz(Me.QuantidadeEstoque.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@15", CodEmpresa))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@16", Nz(Me.Localiza��o.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@17", Nz(Me.Referencia.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@18", Nz(Me.Cor.Text, 1)))
         




            cmd.Parameters.Add(New OleDb.OleDbParameter("@21", NzZero(Me.ComissaoVenda.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@22", NzZero(Me.Multiplos.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@23", NzZero(Me.EstoqueMinimo.Text)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@24", Nz(Me.MostrarListaPreco.Text, 1)))

            cmd.Parameters.Add(New OleDb.OleDbParameter("@25", True))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@26", NzZero(Me.ValorVenda1.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@27", NzZero(Me.ValorVenda2.Text)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@ProdutoNaPromocao", Nz(Me.ProdutoNaPromocao.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@DataInicioPromocao", Nz(Me.DataInicioPromocao.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@DataFinalPromocao", Nz(Me.DataFinalPromocao.Text, 1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@ValorPromocao", NzZero(Me.ValorPromocao.Text)))


            Try
                cmd.ExecuteNonQuery()




                Dim bt As Object = sender
                If (bt.Name.Equals("btMarkup")) Then
                    GerarLog(Me.Text, A��oTP.Editou, Me.CodigoProduto.Text)
                    Operation = VAZ
                Else
                    MsgBox("Registro Atualizado com sucesso", 64, "Valida��o de Dados")
                    GerarLog(Me.Text, A��oTP.Editou, Me.CodigoProduto.Text)
                    Operation = VAZ
                    DesbloquearTextBox(Me, False)
                End If

            Catch x As Exception
                MsgBox(x.Message)
                Exit Sub
            End Try
            ' A��o.Desbloquear_Controle(Me, False)

            CNN.Close()
        End If

    End Sub
    Dim pic As New PictureBox
    Private Sub btFotoProduto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFotoProduto.Click
        If Me.CodigoProduto.Text = "" Then
            MsgBox("O usu�rio deve selecionar um produto para Adionar/Visualizar/Editar a Foto.", 64, "Valida��o de Dados")
            Exit Sub
        End If
        Dim OpenFileDialog1 As New OpenFileDialog()
        OpenFileDialog1.Filter = "Image Files (*.PNG;*.JPG)| *.PNG;*.JPG"

        OpenFileDialog1.Title = "Selecione um arquivo PNG|JPG para inserir no campo Imagem"
        OpenFileDialog1.ShowDialog()


        If OpenFileDialog1.FileName <> "" Then
            CaminhoImagem = OpenFileDialog1.FileName
            pic.Load(OpenFileDialog1.FileName)

            Dim largura As Integer = pic.Image.Width
            Dim altura As Integer = pic.Image.Height

            If (largura > 300 And altura > 200) Then

                Dim imagemEscalonada As Image = Escala(pic.Image, 300, 200)
                pic.Image = imagemEscalonada

            End If


            SalvaFoto()
            VisualizaFoto()
            'MsgBox("A imagem foi capturada, utilize o bot�o salvar para armazenar no banco de dados", 64, TituloMsgBox)
            Exit Sub
        End If
    End Sub
    Private Function ConverterFotoParaByteArray() As Byte()
        Using stream = New System.IO.MemoryStream()
            pic.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
            stream.Seek(0, System.IO.SeekOrigin.Begin)
            Dim bArray As Byte() = New Byte(stream.Length - 1) {}
            stream.Read(bArray, 0, System.Convert.ToInt32(stream.Length))
            Return bArray
        End Using
    End Function



    Private Shared Function Escala(imgPhoto As Image, width As Integer, height As Integer) As Image

        Dim fonteLargura = imgPhoto.Width
        Dim fonteAltura = imgPhoto.Height
        Dim origemX As Integer = 0
        Dim origemY As Integer = 0

        Dim destX As Integer = 0
        Dim destY As Integer = 0

        'calcular altura
        Dim destWidth As Integer = width
        Dim destHeight As Integer = height

        'criar um novo objeot img
        Dim bmpImagem As New Bitmap(destWidth, destHeight, Imaging.PixelFormat.Format24bppRgb)

        bmpImagem.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)

        Dim grImagem As Graphics = Graphics.FromImage(bmpImagem)

        grImagem.InterpolationMode = InterpolationMode.HighQualityBicubic

        grImagem.DrawImage(imgPhoto,
                           New Rectangle(destX, destY, destWidth, destHeight),
                           New Rectangle(origemX, origemY, fonteLargura, fonteAltura), GraphicsUnit.Pixel)

        grImagem.Dispose()
        Return bmpImagem





    End Function




    Private Sub CodigoProduto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CodigoProduto.Validating
        If IsNumeric(CodigoProduto.Text) Then
            If Me.CodigoProduto.Text <> "0000" Then
                If String.CompareOrdinal(Me.CodigoProduto.Text, Me.CodigoProduto.TextoAntigo) Then
                    LocalizaDados()

                End If
            End If
        Else
            CodigoProduto.Clear()
        End If
    End Sub

    Public Sub VisualizaFoto()
        'Conexao
        Dim Cn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        'tratamento de erro
        Try
            'command para pegar os dados
            Dim Cmd As New OleDb.OleDbCommand("SELECT * From ProdutosFoto where CodigoProduto = " & Me.CodigoProduto.Text, Cn)
            'dataadapter para fazer a liga��o dos dados
            Dim Da As New OleDb.OleDbDataAdapter(Cmd)
            'dataset para guardar em mem�ria os dados
            Dim Ds As New DataSet()
            'abre conex�o
            Cn.Open()
            'preenche dataset com a tabela "ProdutosFotos"
            Da.Fill(Ds, "FotoProduto")
            'variavel para recebe a quantidade de linhas da tabela retornada
            Dim c As Integer = Ds.Tables(0).Rows.Count
            If c > 0 Then
                'array recebe a �ltima linha do dataset, a imagem
                Dim ByteData() As Byte = Ds.Tables(0).Rows(c - 1).Item("Foto")
                'stream em mem�ria recebe a imagem
                Dim ImgVer As New MemoryStream(ByteData)
                'a picturebox recebe imagem que usa o m�todo FromStream para "ler" a stream que cont�m a imagem

                'Compara tamanhos para fazer ajustes no quadro de visualiza��o
                Me.Display.Visible = True
                Me.Display.Image = Image.FromStream(ImgVer)
                OperationImage = UPD
            Else
                Me.Display.Image = Nothing
                OperationImage = INS
            End If
            Cn.Close()
        Catch err As Exception
            Me.Display.Visible = False
        Finally
            'fecha a conex�o
            Cn.Close()
        End Try

    End Sub

    Public Sub SalvaFoto()

        Dim arqImg As FileStream
        Dim rImg As StreamReader

        If Len(CaminhoImagem) <> 0 Then
            arqImg = New FileStream(CaminhoImagem, FileMode.Open, FileAccess.Read, FileShare.Read)
            rImg = New StreamReader(arqImg)
        Else
            MsgBox("Defina uma foto para inserir no Banco de dados.", 64, "Valida��o de Dados")
            Exit Sub
        End If

        Dim Conn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

        Dim Sql As String = ""

        If OperationImage = UPD Then
            Sql = "Update ProdutosFoto Set Foto = ? where CodigoProduto = " & Me.CodigoProduto.Text
        Else
            Sql = "INSERT INTO ProdutosFoto(CodigoProduto, Foto) VALUES (?,?)"
        End If

        Dim Cmd As New OleDb.OleDbCommand(Sql, Conn)

        Try
            'declaramos um vetor de bytes para armazenar o conte�do da imagem a ser salva
            Dim arqByteArray(arqImg.Length - 1) As Byte
            arqImg.Read(arqByteArray, 0, arqImg.Length)

            If OperationImage = UPD Then
                Cmd.Parameters.AddWithValue("@Foto", ConverterFotoParaByteArray())
            Else
                Cmd.Parameters.AddWithValue("@CodigoProduto", OleDb.OleDbType.Integer).Value = Me.CodigoProduto.Text
                Cmd.Parameters.AddWithValue("@Foto", ConverterFotoParaByteArray())
            End If

            Cmd.Connection.Open()
            Cmd.ExecuteNonQuery()
            Cmd.Connection.Close()
            Conn.Close()
            MsgBox("Imagem incluida/Alterada com sucesso !", 64, "Valida��o de Dados")

        Catch Ex As Exception
            MsgBox(Ex.Message, 64, "Valida��o de Dados")
        End Try

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
            .CommandText = "SELECT Max(Produtos.CodigoProduto) AS M�xDeCodigoProduto FROM(Produtos)"
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

        Me.CodigoProduto.Text = Ult + 1
        'fim inserir ultimo registro

    End Sub

    Private Sub InativarBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InativarBT.Click

        Dim HH As DateTime = Now

        Dim Autorizado As Boolean = PedirPermissao(Me.Text, Me.CodigoProduto.Text)
        Autorizado = varAutorizado
        If Autorizado = False Then
            Exit Sub
        End If
        ' cod seguran�a retirado lo
        ' Dim CodSeguran�a As String = InformaCodigoSeguranca()
        'If VerificaCodigoSeguran�a(CodSeguran�a) = False Then
        'MsgBox("C�digo de Seguran�a inv�lido, Verifique.", 64, "Valida��o de Dados")
        'Exit Sub
        'End If

        If MsgBox("Deseja realmente inativar este produto.", 36, "Valida��o de Dados") = 6 Then

            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()
            Dim Transacao As OleDb.OleDbTransaction = CNN.BeginTransaction()
            Try
                Dim Sql As String = "UPDATE Produtos SET Inativo = @1, Atualizado=@2 Where CodigoProduto = " & Me.CodigoProduto.Text
                Dim cmd As New OleDb.OleDbCommand(Sql, CNN, Transacao)

                cmd.Parameters.Add(New OleDb.OleDbParameter("@1", True))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@2", True))
                cmd.ExecuteNonQuery()

                'elimina  os registros na tabela prodEmit referente ao produto selecionado
                Sql = "DELETE * FROM prodEmit Where ProdErp ='" & Me.CodigoProduto.Text & "'"
                cmd = New OleDb.OleDbCommand(Sql, CNN, Transacao)
                cmd.ExecuteNonQuery()

                Transacao.Commit()
                MsgBox("Registro Inativado com sucesso", 64, "Valida��o de Dados")
                GerarLog(Me.Text, A��oTP.Inativou, Me.CodigoProduto.Text)
            Catch x As Exception
                Transacao.Rollback()
                MsgBox(x.Message)
                Exit Sub
            End Try

            CNN.Close()
            NovoBT_Click(sender, e)
        End If

    End Sub

    Private Sub Localiza��o_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Localiza��o.KeyDown
        If e.KeyCode = Keys.F5 Then
            RetornoProcura = ""
            ChamaTelaProcura("Setor", "Descric�o", "", "ProdutoLocal", "SetorLocal", "SetorLocalDesc", "", True)
            Me.Localiza��o.Text = RetornoProcura
            If Me.Localiza��o.Text <> "" Then
                A��o.Descri��o_ItenRegistro(Me.Localiza��o, Me.Localiza��oDesc, "ProdutoLocal", "SetorLocal", Me.Localiza��o.Text, "SetorLocalDesc", TrfGerais.TipoDados.AlfaNum�rico, True)
                Me.Localiza��o.Focus()
            End If
        End If
    End Sub

    Private Sub SubGrupo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SubGrupo.KeyDown
        If e.KeyCode = Keys.F5 Then
            RetornoProcura = ""
            ChamaTelaProcura("Codigo", "Descric�o", "", "SubGrupo", "Codigo", "SubGrupoDesc", "", True)
            Me.SubGrupo.Text = RetornoProcura
            Me.SubGrupo.Focus()
        End If
    End Sub

    Private Sub TipoGrupo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TipoGrupo.KeyDown
        If e.KeyCode = Keys.F5 Then
            RetornoProcura = ""
            ChamaTelaProcura("Codigo", "Descric�o", "", "TipoGrupo", "Codigo", "TipoGrupoDesc", "", True)
            Me.TipoGrupo.Text = RetornoProcura
            Me.TipoGrupo.Focus()
        End If
    End Sub

    Private Sub Cor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cor.KeyDown

        If e.KeyCode = Keys.F5 Then
            RetornoProcura = ""
            ChamaTelaProcura("Codigo", "Descric�o", "", "Cor", "Codigo", "CorDesc", "", True)
            Me.Cor.Text = RetornoProcura
            Me.Cor.Focus()
        End If
    End Sub

    Private Sub SubGrupo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubGrupo.Validated
        If Me.SubGrupo.Text <> "" Then
            A��o.Descri��o_ItenRegistro(Me.SubGrupo, Me.SubGrupoDesc, "SubGrupo", "Codigo", Me.SubGrupo.Text, "SubGrupoDesc", TrfGerais.TipoDados.Num�rico, True)
        Else
            Me.SubGrupoDesc.Text = ""
        End If

    End Sub

    Private Sub TipoGrupo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TipoGrupo.Validated
        If Me.TipoGrupo.Text <> "" Then
            A��o.Descri��o_ItenRegistro(Me.TipoGrupo, Me.TipoGrupoDesc, "TipoGrupo", "Codigo", Me.TipoGrupo.Text, "TipoGrupoDesc", TrfGerais.TipoDados.Num�rico, True)
        Else
            Me.TipoGrupoDesc.Text = ""
        End If
    End Sub




    Private Sub Produtos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CarregaComboUnidadeMedida() 'sped

    End Sub

    Private Function PegaVlrCombo(ByVal Cbo As CBOAutoCompleteFocus.CboFocus, ByVal Retorna_Descri��o As TpRetornoCBO)

        Dim Retorno As String = ""
        If Cbo.Text = "" Then
            Retorno = ""
        Else
            Cbo.SelectedIndex = Cbo.FindStringExact(Cbo.Text & "")
            If Retorna_Descri��o = TpRetornoCBO.N�o Then
                Retorno = CType(Cbo.SelectedItem, cboItemData).ItemData
            Else
                Retorno = CType(Cbo.SelectedItem, cboItemData).Name
            End If
        End If
        Return Retorno

    End Function

    Private Sub Localiza��o_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Localiza��o.Validated
        If Not Me.Localiza��o.Text = "" Then
            A��o.Descri��o_ItenRegistro(Me.Localiza��o, Me.Localiza��oDesc, "ProdutoLocal", "SetorLocal", Me.Localiza��o.Text, "SetorLocalDesc", TrfGerais.TipoDados.AlfaNum�rico, True)
        Else
            Me.Localiza��oDesc.Text = ""
        End If
    End Sub

    Private Sub Marca_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Marca.Validated
        If Not Me.Marca.Text = "" Then
            A��o.Descri��o_ItenRegistro(Me.Marca, Me.MarcaDesc, "Marcas", "Codigo", Me.Marca.Text, "Marca", TrfGerais.TipoDados.Num�rico, True)
        Else
            Me.MarcaDesc.Text = ""
        End If
    End Sub

    Private Sub Grupo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grupo.Validated
        If Not Me.Grupo.Text = "" Then
            A��o.Descri��o_ItenRegistro(Me.Grupo, Me.GrupoDesc, "Grupos", "C�digoGrupo", Me.Grupo.Text, "Descri��o", TrfGerais.TipoDados.Num�rico, True)
        Else
            Me.GrupoDesc.Text = ""
        End If
    End Sub


    Private Sub CarregaComboProdutoTipo()

        Dim Cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim DS As New DataSet
        Dim Sql As String = "Select * From ProdutoTipo Where CodTipoProduto <> 99"
        Dim daProdutoTipo As OleDb.OleDbDataAdapter

        daProdutoTipo = New OleDb.OleDbDataAdapter(Sql, Cnn)
        daProdutoTipo.Fill(DS, "ProdutoTipo")

        Me.Tipo.DataSource = DS.Tables("ProdutoTipo")
        Me.Tipo.ValueMember = "CodTipoProduto"
        Me.Tipo.DisplayMember = "DescTipoProduto"
        Me.Tipo.SelectedIndex = -1
        Cnn.Close()

    End Sub
    Private Sub CarregaComboUnidadeMedida()

        Dim Cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim DS As New DataSet
        Dim Sql As String = "Select * From UnidadeMedida order by DescricaoUnidade"
        Dim da As OleDb.OleDbDataAdapter

        da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        da.Fill(DS, "Uni")

        Me.UnidadeMedida.DataSource = DS.Tables(0).DefaultView
        Me.UnidadeMedida.DisplayMember = "DescricaoUnidade"
        Me.UnidadeMedida.ValueMember = "sigla"

        Me.UnidadeMedida.SelectedIndex = -1
        Cnn.Close()

    End Sub

    Private Sub Localiza��oToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Localiza��oToolStripMenuItem.Click
        My.Forms.ProdutoLocal.ShowDialog()
    End Sub

    Private Sub GruposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GruposToolStripMenuItem.Click
        My.Forms.Grupos.ShowDialog()
    End Sub

    Private Sub SubGruposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubGruposToolStripMenuItem.Click
        My.Forms.SubGrupo.ShowDialog()
    End Sub

    Private Sub MarcasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcasToolStripMenuItem.Click
        My.Forms.Marcas.ShowDialog()
    End Sub

    Private Sub TipoGruposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoGruposToolStripMenuItem.Click
        My.Forms.TipoGrupo.ShowDialog()
    End Sub

    Private Sub CoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoresToolStripMenuItem.Click
        My.Forms.Cor.ShowDialog()
    End Sub

    Private Sub Cor_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cor.Validated
        If Me.Cor.Text <> "" Then
            A��o.Descri��o_ItenRegistro(Me.Cor, Me.CorDesc, "Cor", "Codigo", Me.Cor.Text, "CorDesc", TrfGerais.TipoDados.Num�rico, True)
        Else
            Me.CorDesc.Clear()
        End If
    End Sub

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.CodigoProduto.Text = "" Then
            MessageBox.Show("Para adicionar um Produto de composi��o o usuario deve selecionar um produto principal antes.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        My.Forms.ProdutoComposicaoAdd.ShowDialog()
    End Sub


    Private Sub btEdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.CodigoProduto.Text = "" Then
            MessageBox.Show("Para adicionar um Produto de composi��o o usuario deve selecionar um produto principal antes.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim I As Integer = 0


        My.Forms.ProdutoComposicaoAdd.OperationItens = UPD
        My.Forms.ProdutoComposicaoAdd.ShowDialog()

    End Sub

    Private Sub MyLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        btEdd_Click(sender, e)
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.CodigoProduto.Text = "" Then
            MessageBox.Show("Para adicionar um Produto de composi��o o usuario deve selecionar um produto principal antes.", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim I As Integer = 0
        Dim Prod As String = String.Empty

        If Prod = "" Then
            MessageBox.Show("O usu�rio deve selecionar o item para excluir", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MsgBox("Deseja realmente excluir o registro selecionado.", 36, "Valida��o de Dados") = 6 Then
            Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
            CNN.Open()

            Dim Sql As String = "Delete * from ProdutoComposicao Where Produto = " & Me.CodigoProduto.Text & " and ProdComposicao = " & Prod
            Dim cmd As New OleDb.OleDbCommand(Sql, CNN)

            cmd.ExecuteNonQuery()
            MsgBox("Registro excluido com sucesso", 64, "Valida��o de Dados")
            CNN.Close()


        End If

    End Sub


    Private Sub btMarkup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMarkup.Click
        If Me.CodigoProduto.Text = "0000" Then
            MsgBox("O registro ainda n�o foi salvo, clique no bot�o salvar para poder lan�ar os valores de custo", 48, "Valida��o de dados")
            Exit Sub
        End If
        If Me.CodigoProduto.Text = "" Then
            Exit Sub
        End If
        SalvarBT_Click(sender, e)

        Dim f As New CompraAlterarCusto(Me.CodigoProduto.Text)
        f.ShowDialog()

        LocalizaDados()

    End Sub

#Region "Carrega dados das Compras"
    Delegate Sub myDelegate()

    Private Sub IniciaUltimasCompras()
        If Me.InvokeRequired Then
            Me.Invoke(New myDelegate(AddressOf EncheListaUltimaCompra))
        End If
    End Sub

    Private Sub EncheListaUltimaCompra()
        Dim CnnTRD As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CnnTRD.Open()

        Dim Sql As String = String.Empty

        Sql = "SELECT TOP 10 Compra.DataCompra, Compra.DataLan�amento, ItensCompra.CompraInterno, Compra.NotaFiscal, [C�digoFornecedor] & '-' & [Raz�oSocial] AS Fornecedor, ItensCompra.Qtd, ItensCompra.ValorUnitario, Compra.TpEntrada FROM (ItensCompra INNER JOIN Compra ON ItensCompra.CompraInterno = Compra.CompraInterno) INNER JOIN Fornecedor ON Compra.CodigoFornecedor = Fornecedor.C�digoFornecedor WHERE(((ItensCompra.CodigoProduto) = " & Me.CodigoProduto.Text & ") And ((Compra.Inativo) = False) And ((Compra.TpEntrada) = 'ENTRADA')) ORDER BY Compra.DataCompra DESC;"
        Dim da = New OleDb.OleDbDataAdapter(Sql, CnnTRD)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView

        da.Dispose()
        CnnTRD.Close()

        If Me.Lista.RowCount > 0 Then
            Me.UltCompraTab.Visible = True
        Else
            Me.UltCompraTab.Visible = False
        End If
    End Sub
#End Region

    Private Sub btGrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.CodigoProduto.Text = "" Then
            MessageBox.Show("N�o existe produto selecionado para visualiza��o ou cadastro da grade", "Valida��o de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        My.Forms.ProdutosGrade.ShowDialog()
    End Sub

    Private Sub btLocalizacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLocalizacao.Click
        RetornoProcura = ""
        ChamaTelaProcura("Setor", "Descric�o", "", "ProdutoLocal", "SetorLocal", "SetorLocalDesc", "", True)
        Me.Localiza��o.Text = RetornoProcura
        If Me.Localiza��o.Text <> "" Then
            A��o.Descri��o_ItenRegistro(Me.Localiza��o, Me.Localiza��oDesc, "ProdutoLocal", "SetorLocal", Me.Localiza��o.Text, "SetorLocalDesc", TrfGerais.TipoDados.AlfaNum�rico, True)
            Me.Localiza��o.Focus()
        End If
    End Sub

    Private Sub btGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrupo.Click
        RetornoProcura = ""
        ChamaTelaProcura("Codigo", "Descric�o", "", "Grupos", "C�digoGrupo", "Descri��o", "", True)
        Me.Grupo.Text = RetornoProcura
        If Me.Grupo.Text <> "" Then
            A��o.Descri��o_ItenRegistro(Me.Grupo, Me.GrupoDesc, "Grupos", "C�digoGrupo", Me.Grupo.Text, "Descri��o", TrfGerais.TipoDados.Num�rico, True)
            Me.Grupo.Focus()
        End If
    End Sub

    Private Sub btSubGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSubGrupo.Click
        RetornoProcura = ""
        ChamaTelaProcura("Codigo", "Descric�o", "", "SubGrupo", "Codigo", "SubGrupoDesc", "", True)
        Me.SubGrupo.Text = RetornoProcura
        If Me.SubGrupo.Text <> "" Then
            A��o.Descri��o_ItenRegistro(Me.SubGrupo, Me.SubGrupoDesc, "SubGrupo", "Codigo", Me.SubGrupo.Text, "SubGrupoDesc", TrfGerais.TipoDados.Num�rico, True)
            Me.SubGrupo.Focus()
        End If

    End Sub

    Private Sub BtMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMarca.Click
        RetornoProcura = ""
        ChamaTelaProcura("Codigo", "Descric�o", "", "Marcas", "Codigo", "Marca", "", True)
        Me.Marca.Text = RetornoProcura
        If Me.Marca.Text <> "" Then
            A��o.Descri��o_ItenRegistro(Me.Marca, Me.MarcaDesc, "Marcas", "Codigo", Me.Marca.Text, "Marca", TrfGerais.TipoDados.Num�rico, True)
            Me.Marca.Focus()
        End If
    End Sub

    Private Sub btTipoGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTipoGrupo.Click
        RetornoProcura = ""
        ChamaTelaProcura("Codigo", "Descric�o", "", "TipoGrupo", "Codigo", "TipoGrupoDesc", "", True)
        Me.TipoGrupo.Text = RetornoProcura
        If Me.TipoGrupo.Text <> "" Then
            A��o.Descri��o_ItenRegistro(Me.TipoGrupo, Me.TipoGrupoDesc, "TipoGrupo", "Codigo", Me.TipoGrupo.Text, "TipoGrupoDesc", TrfGerais.TipoDados.Num�rico, True)
            Me.TipoGrupo.Focus()
        End If

    End Sub

    Private Sub btCor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCor.Click
        RetornoProcura = ""
        ChamaTelaProcura("Codigo", "Descric�o", "", "Cor", "Codigo", "CorDesc", "", True)
        Me.Cor.Text = RetornoProcura

        If Me.Cor.Text <> "" Then
            A��o.Descri��o_ItenRegistro(Me.Cor, Me.CorDesc, "Cor", "Codigo", Me.Cor.Text, "CorDesc", TrfGerais.TipoDados.Num�rico, True)
            Me.Cor.Focus()
        End If

    End Sub

    Private Sub btRetiraImagem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRetiraImagem.Click

        Dim Conn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

        Dim Sql As String = "Delete * from ProdutosFoto where CodigoProduto = " & Me.CodigoProduto.Text

        Dim Cmd As New OleDb.OleDbCommand(Sql, Conn)

        Try

            Cmd.Connection.Open()
            Cmd.ExecuteNonQuery()
            Cmd.Connection.Close()
            Conn.Close()
            VisualizaFoto()
            MsgBox("Imagem Removida com sucesso !", 64, "Valida��o de Dados")

        Catch Ex As Exception
            MsgBox(Ex.Message, 64, "Valida��o de Dados")
        End Try

    End Sub

    Private Sub DescontoMaximo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.TabOpcoes.SelectedTab = Me.TabOutras
        End If
    End Sub

    Private Sub Referencia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Referencia.KeyDown
        If e.KeyCode = Keys.Return And Len(Me.Referencia.Text) = 0 Then
            Me.Peso.Focus()
        End If
    End Sub

    Private Sub Lista_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Lista.CellDoubleClick
        Dim vID As Integer
        vID = CInt(Me.Lista.CurrentRow.Cells("cId").Value)

        If vID > 0 Then
            RetornoProcura = vID
            My.Forms.Compra.LocalizaDados()
            My.Forms.Compra.ShowDialog()
        End If

    End Sub


    'Verificar se um produto foi cadastrado
    Private Sub EncontrouRegistro(ByVal cod As TextBox, ByVal FieldWhere As String)
        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Cmd As New OleDb.OleDbCommand()
        Dim DataReader As OleDb.OleDbDataReader
        With Cmd
            .Connection = CNN
            .CommandTimeout = 0
            .CommandText = "SELECT  CodigoProduto, CodigoFabrica, CodigoOriginal  FROM Produtos WHERE " & FieldWhere & "='" & cod.Text & "'"
            .CommandType = CommandType.Text
        End With
        Try
            DataReader = Cmd.ExecuteReader

            DataReader.Read()
            If DataReader.HasRows Then
                If Me.CodigoProduto.Text = DataReader.Item("CodigoProduto").ToString Then
                Else
                    MsgBox("Esse c�digo j� foi cadastrado para um outro produto", 48, "Valida��o de dados")
                    cod.Clear()

                End If
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
            If Not DataReader.HasRows Then
                MsgBox("NCM Inv�lido, verifique com seu contador", 48, "Valida��o de dados")
                Me.CF.Clear()
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
    Private Sub CF_Validated(sender As Object, e As EventArgs)

        EncontraNCM(Me.CF.Text)
    End Sub

    Private Sub Label74_Click(sender As Object, e As EventArgs)
        My.Forms.TabelaGen.ShowDialog()
    End Sub

    Private Sub NCMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NCMToolStripMenuItem.Click
        My.Forms.Ncm.ShowDialog()
    End Sub

    Private Sub btnHistorico_Click(sender As Object, e As EventArgs) Handles btnHistorico.Click
        If String.IsNullOrEmpty(CodigoProduto.Text) Then
            MessageBox.Show("Voc� precisa selecionar um produto!", "Aten��o!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        RelatorioCarregar = "RelHistoricoProduto"
        My.Forms.VisualizadorRelatorio.ShowDialog()
    End Sub
End Class