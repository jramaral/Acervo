Public Class CompraXmlProdutoImportar


    Public CnpjEmitenteVar As String
    Dim dt As New DataTable()
    Public Property CnpjEmitente() As String
        Get
            Return CnpjEmitenteVar
        End Get
        Set(ByVal Value As String)
            CnpjEmitenteVar = Value
        End Set
    End Property

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click

        Dim QtdLinhas As Integer = 0

        For i As Integer = 0 To ListaItens.Rows.Count - 1
            If IsDBNull(ListaItens.Rows(i).Cells("cProdERP").Value) Then
                QtdLinhas += 1
            End If
        Next

        If QtdLinhas > 0 Then
            MessageBox.Show("Existe produtos que não foi criado relação com os produtos do ERP, os itens serão cancelados", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            My.Forms.Compra.ItensErrado = QtdLinhas
        End If

        Me.Close()
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' Cria as colunas em tempo de execução
    ''' </summary>
    ''' <param name="dgv">Controle que vai receber as colunas</param>
    ''' <returns>Retorna um DataGridView com colunas</returns>

    Public Function CreateCol(ByRef dgv As DataGridView)
        'Aqui definimos as nossa datagridview.
        Dim col As DataGridViewTextBoxColumn 'Importa a coluna textbox
        'Dim colCheck As DataGridViewCheckBoxColumn 'importa a coluna checkbox

        'Definir alguma propriedades da coluna TextBox
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "id"
        col.Name = "cdet"
        col.Width = 70
        col.Visible = True
        dgv.Columns.Add(col)

        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "Codigo"
        col.Name = "ccProd"
        col.Width = 70
        col.Visible = True
        dgv.Columns.Add(col)

        'colCheck = New DataGridViewCheckBoxColumn()
        'colCheck.HeaderText = "Sel"
        'colCheck.Name = "gselecao"
        'colCheck.Width = 30
        'dgv.Columns.Add(colCheck)

        'Numero Boleto
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "cod ERP"
        col.Name = "cProdERP"
        col.Width = 110
        dgv.Columns.Add(col)

        'Numero Documento
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "Descrição"
        col.Name = "xProd"
        col.Width = 110
        dgv.Columns.Add(col)

        'Nome do Sacado
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "U.M"
        col.Name = "cuCom"
        col.Width = 350
        ' col.ReadOnly = True
        dgv.Columns.Add(col)

        'CPF OU CNPJ
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "qCom"
        col.Name = "cqCom"
        col.Width = 130
        dgv.Columns.Add(col)

        'Vencimento
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "vUnCom"
        col.Name = "cvUnCom"
        col.Width = 90
        dgv.Columns.Add(col)    '

        'Valor do documento
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "vProd"
        col.Name = "cvProd"
        col.Width = 110
        col.DefaultCellStyle.Format = FormatCurrency(0, 2)
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns.Add(col)

        'Cancelado
        col = New DataGridViewTextBoxColumn()
        col.HeaderText = "CFOP"
        col.Name = "cCFOP"
        col.Width = 50
        dgv.Columns.Add(col)

        ''Pedido
        'col = New DataGridViewTextBoxColumn()
        'col.HeaderText = "Pedido"
        'col.Name = "gPedido"
        'col.Width = 110
        'col.DefaultCellStyle.Format = FormatCurrency(0, 2)
        'col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgv.Columns.Add(col)

        Return dgv
    End Function
    Private Sub CompraXmlProdutoImportar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Forms.Compra.TbIT.DefaultView.Sort = Nothing
        Me.ListaItens.DataSource = My.Forms.Compra.TbIT.DefaultView

        'CreateCol(Me.dgvListaItens)

        'For Each dr As DataRow In My.Forms.Compra.TbIT.Rows


        '    Dim row0 As String() = {dr.Item("cProd"),
        '                              dr.Item("ProdERP"),
        '                              dr.Item("xProd"),
        '                              dr.Item("uCom"),
        '                              dr.Item("qCom"),
        '                              dr.Item("vProd"),
        '                              dr.Item("vUnCom"),
        '                              dr.Item("CFOP"),
        '                              dr.Item("det"),
        '                              dr.Item("ncm")}

        '    With dgvListaItens.Rows
        '        .Add(row0)
        '    End With
        'Next


        'Dim row0 As String() = {.NossoNumero, dtVenc, .DataCredito, Doc, p_nome_sacado, .ContaCorrente, FormatCurrency(.ValorPago, 2), FormatCurrency(.ValorJurosPago, 2), FormatCurrency(.ValorMultaPaga, 2), FormatCurrency(.ValorCredito, 2), IIf(.Pagamento, "Sim", "Não"), idrec}
        ''Adiciona a linha no DataGridView
        'With dgv.Rows
        '    .Add(row0)
        'End With




        '        / Criar um DataTable com as 3 colunas...
        'DataTable dt = new DataTable();
        'dt.Columns.Add("Coluna1", typeof(tipodacoluna));
        'dt.Columns.Add("Coluna2", typeof(tipodacoluna));
        'dt.Columns.Add("Coluna3", typeof(tipodacoluna));

        '// Ai você percorre o DataTable com as cinquenta colunas
        '// e vai criando as linhas na tabela criada acima:
        'foreach(DataRow dr in DataTableComasColunas.Rows)
        '{
        '    dt.Rows.Add(new object[] {dr["Coluna1"], dr["Coluna2"], dr["Coluna3"]});
        '}




        'dt.Columns.Add("cProd", GetType(String))
        'dt.Columns.Add("ProdERP", GetType(String))
        'dt.Columns.Add("xProd", GetType(String))
        'dt.Columns.Add("uCom", GetType(String))
        'dt.Columns.Add("qCom", GetType(String))
        'dt.Columns.Add("vProd", GetType(String))
        'dt.Columns.Add("vUnCom", GetType(String))
        'dt.Columns.Add("CFOP", GetType(String))
        'dt.Columns.Add("det", GetType(String))
        'dt.Columns.Add("ncm", GetType(String))





        'For Each dr As DataRow In My.Forms.Compra.TbIT.Rows
        '    dt.Rows.Add(New Object() {dr.Item("cProd"),
        '                              dr.Item("ProdERP"),
        '                              dr.Item("xProd"),
        '                              dr.Item("uCom"),
        '                              dr.Item("qCom"),
        '                              dr.Item("vProd"),
        '                              dr.Item("vUnCom"),
        '                              dr.Item("CFOP"),
        '                              dr.Item("det"),
        '                              dr.Item("ncm")})
        'Next

        'Me.ListaItens.DataSource = dt.DefaultView


        'foreach(DataRow dr in DataTableComasColunas.Rows)
        '{
        '    dt.Rows.Add(new object[] {dr["Coluna1"], dr["Coluna2"], dr["Coluna3"]});
        '}









        Dim i As Integer

        For i = 0 To ListaItens.ColumnCount - 1

            If ListaItens.Columns(i).Name = "ccProd" Or ListaItens.Columns(i).Name = "cxProd" Or _
                ListaItens.Columns(i).Name = "cuCom" Or ListaItens.Columns(i).Name = "cqCom" Or ListaItens.Columns(i).Name = "cvProd" Or _
                ListaItens.Columns(i).Name = "cvUnCom" Or ListaItens.Columns(i).Name = "cDetalhe" Or ListaItens.Columns(i).Name = "cCFOP" _
                Or ListaItens.Columns(i).Name = "cCFOPe" Or ListaItens.Columns(i).Name = "cCTB" Or ListaItens.Columns(i).Name = "cProdERP" _
                Or ListaItens.Columns(i).Name = "cdet" Or ListaItens.Columns(i).Name = "cInativo" Or ListaItens.Columns(i).Name = "cNCM" Or ListaItens.Columns(i).Name = "cadProd" Then

                ListaItens.Columns(i).Visible = True

            Else
                ListaItens.Columns(i).Visible = False
            End If

        Next

    End Sub

    Private Sub btSalvarCodERP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvarCodERP.Click

        'Verificar se tem alguma coluna do codigo do ERP vazio
        For Each row As DataGridViewRow In Me.ListaItens.Rows
            If IsDBNull(row.Cells("cProdERP").Value) Then
                MessageBox.Show("Registros sem o código do ERP. Favor verificar", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next




        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim Sql As String = String.Empty
        Dim cmd As OleDb.OleDbCommand
        Dim Dr As OleDb.OleDbDataReader





        Dim Add As Boolean = False

        Try
            For Each row As DataGridViewRow In Me.ListaItens.Rows
                Dim CodProd As String = Aplic(row.Cells("ccProd").Value)


                Sql = "Select * from prodEmit Where CNPJemit = '" & CnpjEmitenteVar & "' And ProdEmit = " & CodProd
                cmd = New OleDb.OleDbCommand(Sql, CNN)
                Dr = cmd.ExecuteReader
                Dr.Read()
                If Dr.HasRows Then
                    Add = False
                Else
                    Add = True
                End If
                Dr.Close()

                If Add = True Then
                    Sql = "Insert Into prodEmit (CNPJemit, ProdEmit, ProdErp) Values (@CNPJemit, @ProdEmit, @ProdErp)"
                    cmd = New OleDb.OleDbCommand(Sql, CNN)

                    cmd.Parameters.Add(New OleDb.OleDbParameter("@CNPJemit", CnpjEmitenteVar))
                    cmd.Parameters.Add(New OleDb.OleDbParameter("@ProdEmit", Nz(row.Cells("ccProd").Value, 1)))
                    cmd.Parameters.Add(New OleDb.OleDbParameter("@ProdErp", Nz(row.Cells("cProdErp").Value, 1)))
                    cmd.ExecuteNonQuery()
                Else
                    Sql = "Update prodEmit set ProdErp = @ProdErp Where CNPJemit = '" & CnpjEmitenteVar & "' And ProdEmit = " & CodProd
                    cmd = New OleDb.OleDbCommand(Sql, CNN)

                    cmd.Parameters.Add(New OleDb.OleDbParameter("@ProdErp", Nz(row.Cells("cProdErp").Value, 1)))
                    cmd.ExecuteNonQuery()
                End If

            Next row
            MessageBox.Show("Registros Atualizado.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CNN.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    'faz a tratativa com aspas simples no meio do texto, criada pelo beto
    Public Function Aplic(ByVal strTexto As String) As String
        If InStr(strTexto, Chr(39)) Then
            Aplic = Chr(39) & Replace(strTexto, Chr(39), Chr(39) & Chr(39)) &
                    Chr(39)
        Else
            Aplic = Chr(39) & strTexto & Chr(39)
        End If
    End Function

    Private Function ValidarProdutoERP(Prod As String) As Boolean

        If Prod = "" Then Exit Function

        Dim Cnn As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Cnn.Open()

        Dim Sql As String = "Select * from Produtos where CodigoProduto = " & Prod
        Dim CMD As New OleDb.OleDbCommand(Sql, Cnn)
        Dim DR As OleDb.OleDbDataReader


        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            Return True
            Exit Function
        Else
            MessageBox.Show("Produto inexistente no cadastro, favor selecionar outro.", "Validação de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If

        DR.Close()
        Cnn.Close()
    End Function

    Private Sub ListaItens_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles ListaItens.CellEndEdit
        'Dim strProd = Me.ListaItens.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

        'If IsDBNull(strProd) Then Exit Sub

        'Dim existProd As Boolean = ValidarProdutoERP(strProd)

        'If existProd = False Then
        '    Me.ListaItens.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
        'End If
    End Sub

    Private Sub btCadProduto_Click(sender As Object, e As EventArgs)
        TRVDados(UserAtivo, "Produtos")
        If Ina = True Then
            MsgBox("O usuário não esta autorizado a usar esta opção do sistema.", 64, "Validação de Dados")
            Exit Sub
        Else
            My.Forms.Produtos.ShowDialog()
        End If
    End Sub

    Private Sub ListaItens_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ListaItens.CellContentClick

        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then

            If (IsDBNull(ListaItens.CurrentRow.Cells("cProdERP").Value)) Then

                Dim f As New Produtos.Produtos(ListaItens.CurrentRow.Cells("cxProd").Value, ListaItens.CurrentRow.Cells("cNCM").Value, ListaItens.CurrentRow.Cells("cvUnCom").Value)
                f.ShowDialog()
            End If

        End If
    End Sub
End Class