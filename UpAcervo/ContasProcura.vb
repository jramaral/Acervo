Public Class ContasProcura

    Public TipoConta As String
    Public strTag As String
    Public strNodeG1 As String
    Public strNodeG2 As String
    Public strNodeG3 As String
    Public NomeStr As String
    Public indexNode As Integer
    Public NameNode As String
    Public NodeDescricao As String

    Public nodeG1 As TreeNode = New TreeNode
    Public nodeG2 As TreeNode = New TreeNode
    Public nodeG3 As TreeNode = New TreeNode
    Public nodeG4 As TreeNode = New TreeNode

    Public Acao As Byte  '0 sem acao, 1 insert, 2 update, 3 delete

    Dim Arq_DB As String
    ' a conexao com o banco de dados
    Private con As OleDb.OleDbConnection

    Private NomeTabela As String

    Dim A��o As New TrfGerais
    Dim pGrupo As String
    Dim VetorConta() As String

    Enum Operacao

        INS = 0
        UPD = 1
        DEL = 2

    End Enum

    Public Sub MostrarTreeGrupo()



        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor


        ' Abre a conexao com o banco de dados
        con = New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

        Me.treeView1.Nodes.Clear()

        Try
            con.Open()

        Catch exConnection As System.Exception
            MessageBox.Show(exConnection.GetBaseException.ToString, "Erro ao Conectar com o Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Invocamos o m�todo BeginUpdate para iniciarmos a atualiza��o do controle TreeView
        'este m�todo permite que todas as modifica��es no controle sejam feitas e somente
        'sejam atualizadas na tela ap�s invocarmos o m�todo EndUpdate.

        Me.treeView1.BeginUpdate()

        Dim sql As String

        'sql = "SELECT ContasG1.ContaGrupo1, ContasG1.DescContaGrupo1, ContasG2.ContaGrupo2, ContasG2.DescContaGrupo2, ContasG3.ContaGrupo3, ContasG3.DescContaGrupo3, ContasG3.TipoLanc, ContasG3.Empresa FROM (ContasG1 INNER JOIN ContasG2 ON ContasG1.ContaGrupo1 = ContasG2.ContaGrupo1) INNER JOIN ContasG3 ON (ContasG2.ContaGrupo2 = ContasG3.ContaGrupo2) AND (ContasG2.ContaGrupo1 = ContasG3.ContaGrupo1) WHERE (((ContasG3.Empresa)=" & CodEmpresa & "));"
        'sql = "SELECT ContasG1.ContaGrupo1, ContasG1.DescContaGrupo1, ContasG2.ContaGrupo2, ContasG2.DescContaGrupo2, ContasG3.ContaGrupo3, ContasG3.DescContaGrupo3, ContasG3.TipoLanc, ContasG3.Empresa, ContasG1.Tipo FROM (ContasG1 INNER JOIN ContasG2 ON ContasG1.ContaGrupo1 = ContasG2.ContaGrupo1) INNER JOIN ContasG3 ON (ContasG2.ContaGrupo2 = ContasG3.ContaGrupo2) AND (ContasG2.ContaGrupo1 = ContasG3.ContaGrupo1) WHERE (((ContasG3.Empresa)=" & CodEmpresa & ") AND ((ContasG1.Tipo)='" & TipoConta & "'));"
        sql = "SELECT ContasG1.ContaGrupo1, ContasG1.DescContaGrupo1, ContasG2.ContaGrupo2, ContasG2.DescContaGrupo2, ContasG3.ContaGrupo3, ContasG3.DescContaGrupo3, ContasG3.TipoLanc, ContasG3.Empresa, ContasG1.Tipo FROM (ContasG1 INNER JOIN ContasG2 ON ContasG1.ContaGrupo1 = ContasG2.ContaGrupo1) INNER JOIN ContasG3 ON (ContasG2.ContaGrupo2 = ContasG3.ContaGrupo2) AND (ContasG2.ContaGrupo1 = ContasG3.ContaGrupo1) WHERE (((ContasG3.Empresa)=" & CodEmpresa & ") AND ((ContasG1.Tipo)='D')) ORDER BY ContasG1.ContaGrupo1, ContasG2.ContaGrupo2, ContasG3.ContaGrupo3;"

        Dim cmd As New OleDb.OleDbCommand(sql, con)
        'Esta � a vari�vel que armazenar� o objeto OleDbDataReader
        Dim dr As OleDb.OleDbDataReader
        'Carregaremos o objeto OleDbDataReader com os registros retornados pelo objeto 'OleDbCommand. Para isso ser� necess�rio invocarmos o m�todo ExecuteReader() do 'objeto OleDbCommand.
        dr = cmd.ExecuteReader()

        'Vari�veis utilizadas para cria��o dos "n�s" do TreeView
        Dim nodeG1 As TreeNode = New TreeNode
        Dim nodeG2 As TreeNode = New TreeNode
        Dim nodeG3 As TreeNode = New TreeNode
        Dim nodeG4 As TreeNode = New TreeNode


        '
        Dim strG1Atual As String = ""
        Dim strG2Atual As String = ""
        Dim strG3Atual As String = ""
        Dim strG4Atual As String = ""

        Dim strNodeG1 As String = ""
        Dim strNodeG2 As String = ""
        Dim strNodeG3 As String = ""
        Dim strNodeG4 As String = ""

        Dim nodeAtual As String = ""
        Dim nodeAtual1 As String = ""
        Dim nodeAtual2 As String = ""
        Dim nodeAtual3 As String = ""


        'TreeView - define o No Ra�z
        Dim Raiz As TreeNode
        Raiz = New TreeNode()
        Raiz.Tag = "Raiz"
        Raiz.Text = "Contas"
        Me.treeView1.Nodes.Add(Raiz)


        Dim Ind1 As Integer = 0
        Dim Ind2 As Integer = 0
        Dim Ind3 As Integer = 0
        Dim Ind4 As Integer = 0

        'Iniciamos o loop atrav�s dos registros contidos no OleDbDataReader

        While dr.Read()
            strNodeG1 = dr("ContaGrupo1")
            'Verificamos se o registro corresponde ao G1 ATUAL.
            If Not nodeAtual = strNodeG1 Then

                nodeG1 = New TreeNode()
                With nodeG1
                    .ImageIndex = 0
                    .Tag = "G1"
                    .Text = dr("ContaGrupo1") & "-" & dr("DescContaGrupo1")


                End With

                'Depois de criado o novo "n�" - adicionaremos-o ao controle TreeView
                treeView1.Nodes(0).Nodes.Add(nodeG1)

                'Adiciona no objeto name do node o codigo e um index.
                nodeG1.Name = dr("ContaGrupo1") & "/" & nodeG1.Index

                'Atualizamos a vari�vel com o c�digo do g1 atual
                nodeAtual = dr("ContaGrupo1")

            End If

            'Aqui iniciamos a cria��o dos "n�s" que exibir�o os g2 de cada g1.

            strNodeG2 = strNodeG1 & ";" & dr("ContaGrupo2") 'monta um string juntando  o codigo do G1 e o codigo G2.

            If Not nodeAtual1 = strNodeG2 Then 'Verifica se o NodeAtual � igual o node do G2.

                If IsDBNull(dr("DescContaGrupo2")) Then
                Else
                    nodeG2 = New TreeNode()
                    With nodeG2
                        .ImageIndex = 1
                        .Tag = "G2"
                        .Text = dr("ContaGrupo2") & "-" & dr("DescContaGrupo2") & ""
                    End With

                    'Adicionamos o "n�" do g2 para o g1 atual.
                    treeView1.Nodes(0).Nodes(nodeG1.Index).Nodes.Add(nodeG2)

                    'Adiciona no objeto name do node o codigo e um index.
                    nodeG2.Name = dr("ContaGrupo1") & "-" & dr("ContaGrupo2") & "/" & nodeG1.Index & ";" & nodeG2.Index

                    'Atualizamos a vari�vel para indicar qual � o g2 atual.
                    nodeAtual1 = strNodeG1 & ";" & dr("ContaGrupo2")

                End If
            End If


            'Aqui iniciamos a cria��o dos "n�s" que exibir�o os G3.

            strNodeG3 = strNodeG2 & ";" & dr("ContaGrupo3")

            If Not nodeAtual2 = strNodeG3 Then
                If IsDBNull(dr("DescContaGrupo3")) Then
                Else
                    nodeG3 = New TreeNode()
                    With nodeG3
                        .ImageIndex = 1
                        .Tag = "G3"
                        .Text = dr("ContaGrupo3") & "-" & dr("DescContaGrupo3") & ""

                    End With

                    'Adicionamos o "n�" do G3 para o g2 atual.
                    treeView1.Nodes(0).Nodes(nodeG1.Index).Nodes(nodeG2.Index).Nodes.Add(nodeG3)

                    'Adiciona no objeto name do node o codigo e um index.
                    nodeG3.Name = dr("ContaGrupo1") & "-" & dr("ContaGrupo2").ToString & "-" & dr("ContaGrupo3") & "/" & nodeG1.Index & ";" & nodeG2.Index & ";" & nodeG3.Index

                    'atualizamos a vari�vel para indicar qual � o g2 atual.
                    nodeAtual2 = strNodeG2 & ";" & dr("ContaGrupo3")


                End If
            End If

        End While


        'fechamos o objeto OleDbDataReader
        dr.Close()

        'fechamos a conex�o com o banco de dados
        con.Close()

        'restauramos o cursor 
        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        'invocamos o m�todo EndUpdate do controle TreeView para que as atualiza��es sejam
        'apresentadas ao usu�rio.
        Me.treeView1.EndUpdate()
        expNode()
    End Sub


    Private Sub treeView1_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeView1.AfterCollapse, treeView1.AfterCollapse
        'este � o c�digo para restaurar os �cones quando o usu�rio colapsar os "n�s"

        Select Case e.Node.Tag
            Case "Raiz"
                e.Node.ImageIndex = 0
            Case "G1"
                e.Node.ImageIndex = 0
            Case "G2"
                e.Node.ImageIndex = 0
            Case "G3"
                e.Node.ImageIndex = 0
        End Select
    End Sub

    Private Sub treeView1_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeView1.AfterExpand
        'este � o c�digo para alterarmos os �cones quando o usu�rio expande os "n�s"

        Select Case e.Node.Tag
            Case "Raiz"
                e.Node.ImageIndex = 1
            Case "G1"
                e.Node.ImageIndex = 1
            Case "G2"
                e.Node.ImageIndex = 1
            Case "G3"
                e.Node.ImageIndex = 1
        End Select
    End Sub

    Private Sub treeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles treeView1.NodeMouseClick

        NameNode = e.Node.Name
        strTag = e.Node.Tag
        strNodeG1 = ""
        NodeDescricao = ""

        Select Case e.Node.Tag
            'Case "G1"
            '    NomeStr = Mid(NameNode, 1, NameNode.IndexOf("/"))
            '    NodeDescricao = Mid(e.Node.Text, 6)

            '    strNodeG1 = NomeStr

            'Case "G2"
            '    NomeStr = Mid(NameNode, 1, NameNode.IndexOf("/"))
            '    strNodeG1 = NomeStr
            '    NodeDescricao = Mid(e.Node.Text, 6)
            Case "G3"
                NomeStr = Mid(NameNode, 1, NameNode.IndexOf("/"))
                NomeStr = Mid(NomeStr, 11)
                strNodeG1 = NomeStr
                NodeDescricao = Mid(e.Node.Text, 8)

        End Select

    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Dim i As Integer
        Dim str As String = ""
        If lstB_Filtro.Items.Count >= 1 Then
            For i = 0 To lstB_Filtro.Items.Count - 1
                If (i + 1) Mod lstB_Filtro.Items.Count > 0 Then
                    str = str & "{BalancetePeriodo.ContaBalancete}=" & "'" & lstB_Filtro.Items(i).ToString.Substring(0, 6) & "' OR "
                Else
                    str = str & "{BalancetePeriodo.ContaBalancete}=" & "'" & lstB_Filtro.Items(i).ToString.Substring(0, 6) & "'"
                End If
            Next

        End If
        BalanceteOrcamentarioRelat.strFiltro = str
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub expNode()


        Dim A1 As Integer = 0
        Dim A2 As Integer = 0
        Dim A3 As Integer = 0
        Dim A4 As Integer = 0
        Dim idNode(3) As String

        If NameNode = Nothing Then
        Else
            idNode = NameNode.Split("/")
            idNode = idNode(1).Split(";")
        End If



        Try
            Select Case strTag
                Case "G1"
                    A1 = idNode(0)
                    Me.treeView1.Nodes(0).Expand()

                Case "G2"
                    A1 = idNode(0)
                    A2 = idNode(1)
                    Me.treeView1.Nodes(0).Expand()
                    Me.treeView1.Nodes(0).Nodes(A1).Expand()

                Case "G3"
                    A1 = idNode(0)
                    A2 = idNode(1)
                    A3 = idNode(2)
                    Me.treeView1.Nodes(0).Expand()
                    Me.treeView1.Nodes(0).Nodes(A1).Expand()
                    Me.treeView1.Nodes(0).Nodes(A1).Nodes(A2).Expand()

                Case "G4"
                    If Acao = 3 Then  'delete
                        A1 = idNode(0)
                        A2 = idNode(1)
                        A3 = idNode(2)
                        Me.treeView1.Nodes(0).Expand()
                        Me.treeView1.Nodes(0).Nodes(A1).Expand()
                        Me.treeView1.Nodes(0).Nodes(A1).Nodes(A2).Expand()
                        Me.treeView1.Nodes(0).Nodes(A1).Nodes(A2).Nodes(A3).Expand()
                    Else
                        A1 = idNode(0)
                        A2 = idNode(1)
                        A3 = idNode(2)
                        Me.treeView1.Nodes(0).Expand()
                        Me.treeView1.Nodes(0).Nodes(A1).Expand()
                        Me.treeView1.Nodes(0).Nodes(A1).Nodes(A2).Expand()
                    End If

                Case Else
                    Me.treeView1.Nodes(0).Expand()
            End Select
            Acao = 0 'sem acao
        Catch ex As Exception

        End Try

    End Sub

    Public Sub pesquisarTree()
        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor


        ' Abre a conexao com o banco de dados
        con = New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))

        Me.treeView1.Nodes.Clear()

        Try
            con.Open()

        Catch exConnection As System.Exception
            MessageBox.Show(exConnection.GetBaseException.ToString, "Erro ao Conectar com o Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.treeView1.BeginUpdate()
        Dim Sql As String = String.Empty

        Sql = "SELECT ContasG1.ContaGrupo1, ContasG1.DescContaGrupo1, ContasG2.ContaGrupo2, ContasG2.DescContaGrupo2, ContasG3.ContaGrupo3, ContasG3.DescContaGrupo3, ContasG3.TipoLanc, ContasG3.Empresa FROM (ContasG1 INNER JOIN ContasG2 ON ContasG1.ContaGrupo1 = ContasG2.ContaGrupo1) INNER JOIN ContasG3 ON (ContasG2.ContaGrupo2 = ContasG3.ContaGrupo2) AND (ContasG2.ContaGrupo1 = ContasG3.ContaGrupo1) WHERE (((ContasG3.DescContaGrupo3) Like '%" & Me.txtPesquisa.Text & "%') And ContasG1.Tipo ='D' AND ((ContasG3.Empresa)=" & CodEmpresa & "));"

        Dim cmd As New OleDb.OleDbCommand(Sql, con)
        'Esta � a vari�vel que armazenar� o objeto OleDbDataReader
        Dim dr As OleDb.OleDbDataReader
        'Carregaremos o objeto OleDbDataReader com os registros retornados pelo objeto 'OleDbCommand. Para isso ser� necess�rio invocarmos o m�todo ExecuteReader() do 'objeto OleDbCommand.
        dr = cmd.ExecuteReader()

        'Vari�veis utilizadas para cria��o dos "n�s" do TreeView
        Dim nodeG1 As TreeNode = New TreeNode
        Dim nodeG2 As TreeNode = New TreeNode
        Dim nodeG3 As TreeNode = New TreeNode
        Dim nodeG4 As TreeNode = New TreeNode


        '
        Dim strG1Atual As String = ""
        Dim strG2Atual As String = ""
        Dim strG3Atual As String = ""
        Dim strG4Atual As String = ""

        Dim strNodeG1 As String = ""
        Dim strNodeG2 As String = ""
        Dim strNodeG3 As String = ""
        Dim strNodeG4 As String = ""

        Dim nodeAtual As String = ""
        Dim nodeAtual1 As String = ""
        Dim nodeAtual2 As String = ""
        Dim nodeAtual3 As String = ""


        'TreeView - define o No Ra�z
        Dim Raiz As TreeNode
        Raiz = New TreeNode()
        Raiz.Tag = "Raiz"
        Raiz.Text = "Contas"
        Me.treeView1.Nodes.Add(Raiz)


        Dim Ind1 As Integer = 0
        Dim Ind2 As Integer = 0
        Dim Ind3 As Integer = 0
        Dim Ind4 As Integer = 0

        'Iniciamos o loop atrav�s dos registros contidos no OleDbDataReader
        While dr.Read()
            strNodeG1 = dr("ContaGrupo1")
            'Verificamos se o registro corresponde ao G1 ATUAL.
            If Not nodeAtual = strNodeG1 Then

                nodeG1 = New TreeNode()
                With nodeG1
                    .ImageIndex = 0
                    .Tag = "G1"
                    .Text = dr("ContaGrupo1") & "-" & dr("DescContaGrupo1")


                End With

                'Depois de criado o novo "n�" - adicionaremos-o ao controle TreeView
                treeView1.Nodes(0).Nodes.Add(nodeG1)

                'Adiciona no objeto name do node o codigo e um index.
                nodeG1.Name = dr("ContaGrupo1") & "/" & nodeG1.Index

                'Atualizamos a vari�vel com o c�digo do g1 atual
                nodeAtual = dr("ContaGrupo1")

            End If

            'Aqui iniciamos a cria��o dos "n�s" que exibir�o os g2 de cada g1.

            strNodeG2 = strNodeG1 & ";" & dr("ContaGrupo2") 'monta um string juntando  o codigo do G1 e o codigo G2.

            If Not nodeAtual1 = strNodeG2 Then 'Verifica se o NodeAtual � igual o node do G2.

                If IsDBNull(dr("DescContaGrupo2")) Then
                Else
                    nodeG2 = New TreeNode()
                    With nodeG2
                        .ImageIndex = 1
                        .Tag = "G2"
                        .Text = dr("ContaGrupo2") & "-" & dr("DescContaGrupo2") & ""
                    End With
                    'Adicionamos o "n�" do g2 para o g1 atual.
                    treeView1.Nodes(0).Nodes(nodeG1.Index).Nodes.Add(nodeG2)

                    'Adiciona no objeto name do node o codigo e um index.
                    nodeG2.Name = dr("ContaGrupo1") & "-" & dr("ContaGrupo2") & "/" & nodeG1.Index & ";" & nodeG2.Index

                    'Atualizamos a vari�vel para indicar qual � o g2 atual.
                    nodeAtual1 = strNodeG1 & ";" & dr("ContaGrupo2")
                End If
            End If


            'Aqui iniciamos a cria��o dos "n�s" que exibir�o os G3.
            strNodeG3 = strNodeG2 & ";" & dr("ContaGrupo3")

            If Not nodeAtual2 = strNodeG3 Then
                If IsDBNull(dr("DescContaGrupo3")) Then
                Else
                    nodeG3 = New TreeNode()
                    With nodeG3
                        .ImageIndex = 1
                        .Tag = "G3"
                        .Text = dr("ContaGrupo3") & "-" & dr("DescContaGrupo3") & ""
                    End With
                    'Adicionamos o "n�" do G3 para o g2 atual.
                    treeView1.Nodes(0).Nodes(nodeG1.Index).Nodes(nodeG2.Index).Nodes.Add(nodeG3)

                    'Adiciona no objeto name do node o codigo e um index.
                    nodeG3.Name = dr("ContaGrupo1") & "-" & dr("ContaGrupo2").ToString & "-" & dr("ContaGrupo3") & "/" & nodeG1.Index & ";" & nodeG2.Index & ";" & nodeG3.Index

                    'atualizamos a vari�vel para indicar qual � o g2 atual.
                    nodeAtual2 = strNodeG2 & ";" & dr("ContaGrupo3")
                End If
            End If

        End While

        'fechamos o objeto OleDbDataReader
        dr.Close()
        'fechamos a conex�o com o banco de dados
        con.Close()

        'invocamos o m�todo EndUpdate do controle TreeView para que as atualiza��es sejam
        'apresentadas ao usu�rio.
        Me.treeView1.EndUpdate()

        'Expandimos todos os n�s da �rvore para mostrar.
        Me.treeView1.ExpandAll()

        'restauramos o cursor 
        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub btPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPesquisar.Click
        If Not String.IsNullOrEmpty(Me.txtPesquisa.Text) Then
            pesquisarTree()
        Else
            MessageBox.Show("N�o foi digitado um texto para filtrar", "ATEN��O", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub btTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTodos.Click
        MostrarTreeGrupo()
    End Sub
    Private Sub txtPesquisa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPesquisa.KeyDown
        If e.KeyCode = Keys.Enter Then
            btPesquisar_Click(sender, e)
        End If
    End Sub
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim VF As Boolean = False

        Dim i As Integer = 1

        If Not String.IsNullOrEmpty(strNodeG1) Then
            If lstB_Filtro.FindString(strNodeG1) Then 'se o findstring nao encontrou o valor da vareavel no listbox e verdadeiro
                VF = True
                lstB_Filtro.Items.Add(strNodeG1 & "-" & NodeDescricao)
            Else
                MessageBox.Show("Esta conta j� foi selecionada", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                VF = False
                Exit Sub
            End If
        End If


        'If lstB_Filtro.Items.Count > 0 And Not String.IsNullOrEmpty(strNodeG1) Then
        '    Do While i <= lstB_Filtro.Items.Count
        '        strCmp = lstB_Filtro.Items(i - 1).ToString.Substring(0, 6)
        '        If strNodeG1 = strCmp Then
        '            MessageBox.Show("Esta conta j� foi selecionada", "Valida��o de dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            VF = True
        '            Exit Sub
        '        End If
        '        i = i + 1
        '    Loop
        '    lstB_Filtro.Items.Add(strNodeG1 & "-" & NodeDescricao)
        'Else
        '    If Not String.IsNullOrEmpty(strNodeG1) Then
        '        lstB_Filtro.Items.Add(strNodeG1 & "-" & NodeDescricao)
        '    End If
        'End If


    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Dim i As Integer
        For i = 0 To lstB_Filtro.Items.Count - 1
            If lstB_Filtro.GetSelected(i) Then
                lstB_Filtro.Items.RemoveAt(i)
                Exit Sub
            End If
        Next
      
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        lstB_Filtro.Items.Clear()
    End Sub
End Class
