Imports System.Data.OleDb
Imports System.Text

Public Class LocacaoClientesProcura
    Dim Retorno As Integer = 0
    Dim f As New Form
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal host As Form)
        InitializeComponent()
        f = host
    End Sub


    Private Sub TxtProcura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProcura.Leave
        If Me.TxtProcura.Text = "" Then
            Exit Sub
        End If

        If Me.A1.Checked = True Then BuscarCliente(1) 'busca por codigo do cliente
        If Me.A2.Checked = True Then BuscarCliente(2) 'busca por nome do cliente
        If Me.A3.Checked = True Then BuscarCliente(3) 'busca por cpf
        If Me.A3a.Checked = True Then BuscarCliente(3) 'busca por cnpj
        If Me.A5.Checked = True Then BuscarCliente(5) 'busca por nome fantasia
        If Me.A9.Checked = True Then BuscarCliente(9) 'busca por inativos  

        'If Me.A10.Checked = True Then BuscarCliente(10)
        If Me.A11.Checked = True Then BuscarCliente(11) 'busca por endereço

        Me.Lista.Focus()

    End Sub

    Private Sub BuscarCliente(ByVal Opt As String)

        Dim Cnn As New OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        Dim Sql As String = String.Empty

        dim sb as new StringBuilder
        dim sbFilter as new StringBuilder
        dim filter As String
        

        Select Case Opt
            Case 1 'codigo cliente
               ' Sql = "Select Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Cidade,Clientes.Endereço,Clientes.PessoaContato,Clientes.Celular,Clientes.Telefone,Clientes.MotivoBloqueado,Clientes.Bloqueado,Clientes.VendaCrediario,Clientes.VendaCheque,Clientes.VendaVista,Clientes.Email,  from Clientes  Where Clientes.Empresa = " & CodEmpresa & " And Codigo = " & Me.TxtProcura.Text & " And Clientes.Inativo = False Order by Clientes.Nome"
                sbFilter.Append("P.Codigo = " & Me.TxtProcura.Text &"")
            Case 2 'nome do cliente
                'Sql = "Select Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Cidade,Clientes.Endereço,Clientes.PessoaContato,Clientes.Celular,Clientes.Telefone,Clientes.MotivoBloqueado,Clientes.Bloqueado,Clientes.VendaCrediario,Clientes.VendaCheque,Clientes.VendaVista,Clientes.Email from Clientes  Where Clientes.Empresa = " & CodEmpresa & " And Nome Like '%" & Me.TxtProcura.Text & "%'  and Clientes.Inativo = False Order by Clientes.Nome"
                sbFilter.Append("P.Nome Like '%" & Me.TxtProcura.Text & "%'")
            Case 3 'cpf ou cnpj
                sbFilter.Append("P.CpfCgc Like '%" & Me.TxtProcura.Text & "%'")
               ' Sql = "Select Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Cidade,Clientes.Endereço,Clientes.PessoaContato,Clientes.Celular,Clientes.Telefone,Clientes.MotivoBloqueado,Clientes.Bloqueado,Clientes.VendaCrediario,Clientes.VendaCheque,Clientes.VendaVista,Clientes.Email from Clientes  Where Clientes.Empresa = " & CodEmpresa & " And CpfCgc like '%" & Me.TxtProcura.Text & "%'  and Clientes.Inativo = False Order by Clientes.Nome"
            Case 4 'todos
                sbFilter.Append("P.NomeFantasia Like '%%%'")
            Case 5 'nome fantasia
                sbFilter.Append("P.NomeFantasia Like '%" & Me.TxtProcura.Text & "%'")
             '   Sql = "Select Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Cidade,Clientes.Endereço,Clientes.PessoaContato,Clientes.Celular,Clientes.Telefone,Clientes.MotivoBloqueado,Clientes.Bloqueado,Clientes.VendaCrediario,Clientes.VendaCheque,Clientes.VendaVista,Clientes.Email from Clientes  Where Clientes.Empresa = " & CodEmpresa & " And NomeFantasia like '%" & Me.TxtProcura.Text & "%'  and Clientes.Inativo = False Order by Clientes.NomeFantasia"
            Case 9 'inativos
                sbFilter.Append("P.NomeFantasia Like '%" & Me.TxtProcura.Text & "%'")

                'Case 10
                '    Sql = "Select Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Cidade from Clientes  Where Clientes.Empresa = " & CodEmpresa & " And NomeFantasia like '%" & Me.TxtProcura.Text & "%'  and Clientes.Inativo = true Order by Clientes.NomeFantasia"
            Case 11 'endereco
                sbFilter.Append("P.Endereço Like '%" & Me.TxtProcura.Text & "%'")
               ' Sql = "Select Clientes.Codigo, Clientes.Nome, Clientes.NomeFantasia, Clientes.CpfCgc, Clientes.Cidade,Clientes.Endereço,Clientes.PessoaContato,Clientes.Celular,Clientes.Telefone,Clientes.MotivoBloqueado,Clientes.Bloqueado,Clientes.VendaCrediario,Clientes.VendaCheque,Clientes.VendaVista,Clientes.Email from Clientes  Where Clientes.Empresa = " & CodEmpresa & " And Clientes.Endereço like '%" & Me.TxtProcura.Text & "%'  and Clientes.Inativo = False Order by Clientes.Nome"

        End Select
        filter=sbFilter.ToString()
        sb.Append("Select P.Codigo, P.Nome, P.NomeFantasia, P.CpfCgc, P.Cidade,P.Endereço,P.PessoaContato,P.Celular,P.Telefone,P.MotivoBloqueado,P.Bloqueado,P.VendaCrediario,P.VendaCheque,P.VendaVista,P.Email,  ")
        sb.Append("(SELECT   Sum(C.ValorDocumento) FROM  Receber C WHERE C.CodCliente = P.Codigo And C.Recebimento Is Null) AS ValorEmAberto ")
        sb.Append("from Clientes P  Where P.Empresa = " & CodEmpresa & " And ")
        sb.Append( filter )
        sb.Append(" And P.Inativo = False Order by P.Nome")
        Sql = sb.ToString()


        Dim da = New OleDb.OleDbDataAdapter(Sql, Cnn)
        Dim ds As New DataSet
        da.Fill(ds, "Table")

        Me.Lista.DataSource = ds.Tables("Table").DefaultView
        sb.Clear()
        sbFilter.Clear()
        da.Dispose()
        Cnn.Close()

    End Sub

    Private Sub Fechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fechar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TelaProcura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtProcura.Focus()
        Me.A2.Checked = True
        If My.Forms.Clientes.Visible Then
            A9.Visible = True
        End If
    End Sub

    Private Sub CampoChave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles A1.Click, A2.Click, A3.Click
        Me.TxtProcura.Focus()
    End Sub

    Private Sub Lista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lista.CellDoubleClick

        ID.Text = CInt(Me.Lista.CurrentRow.Cells("cCodigo").Value)

        f.Controls.Add(ID)
        f.Controls.Add(xCliente)
        f.Controls.Add(xTelefone)
        f.Controls.Add(xCidade)



        'If My.Forms.Locacao.Visible = True Then My.Forms.Locacao.Cliente.Text = vID
        'If My.Forms. para()

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub A1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A1.CheckedChanged, A2.CheckedChanged, A3.CheckedChanged, A3a.CheckedChanged, A5.CheckedChanged, A9.CheckedChanged
        'codigo alterado pelo beto 31-10-2012:0954
        If Me.A1.Checked Then
            Me.TxtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.NumerosInteiros
            Me.TxtProcura.Clear()
            Me.TxtProcura.Focus()
        End If
        If Me.A3.Checked Then
            Me.TxtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cpf
            Me.TxtProcura.Clear()
            Me.TxtProcura.Focus()
        End If
        If Me.A3a.Checked = True Then
            Me.TxtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Cnpj
            Me.TxtProcura.Clear()
            Me.TxtProcura.Focus()
        End If
        If Me.A5.Checked Or A2.Checked Or A9.Checked Then
            Me.TxtProcura.TpFormatação = TexBoxFocusNet.TextBoxFocusNet.TpCaixa.Normal
            Me.TxtProcura.Clear()
            Me.TxtProcura.Focus()
        End If

    End Sub

    Private Sub A4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A4.CheckedChanged
        BuscarCliente(4) 'todos
    End Sub


    Private Sub Lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Lista.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (Lista.RowCount > 0) Then
                Dim vID As Integer
                vID = CInt(Me.Lista.CurrentRow.Cells("cCodigo").Value)
                Retorno = vID
                If My.Forms.Locacao.Visible = True Then My.Forms.Locacao.Cliente.Text = vID
                Me.Close()
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub Lista_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lista.SelectionChanged
        Try
            Dim vID As Integer
            vID = CInt(NzZero(Me.Lista.CurrentRow.Cells(0).Value))
            'Todas a vez que for retornar um valor da celula no datagriview deverá ser feita a devida conversão.
            Me.xCliente.Text = Me.Lista.CurrentRow.Cells("cCodigo").Value & "-" & Me.Lista.CurrentRow.Cells("cNome").Value
            Me.xEndereço.Text = Me.Lista.CurrentRow.Cells("cEndereco").Value & ""
            Me.xCpfCnpj.Text = Me.Lista.CurrentRow.Cells("cCpfCnpj").Value & ""
            Me.xCidade.Text = Me.Lista.CurrentRow.Cells("cCidade").Value & ""
            Me.xVendaVista.Checked = Me.Lista.CurrentRow.Cells("cAVista").Value & ""
            Me.xVendaCheque.Checked = Me.Lista.CurrentRow.Cells("cCheque").Value & ""
            Me.xVendaCrediario.Checked = Me.Lista.CurrentRow.Cells("cCrediario").Value & ""
            Me.xTelefone.Text = Convert.ToString(Me.Lista.CurrentRow.Cells("cTelefone").Value) & ""
            Me.xCelular.Text = Convert.ToString(Me.Lista.CurrentRow.Cells("cCelular").Value) & ""
            Me.xContato.Text = Convert.ToString(Me.Lista.CurrentRow.Cells("cContato").Value) & ""
            'Me.xMotivoBloqueado.Text = Me.Lista.CurrentRow.Cells("cMotivoBloqueado").Value & ""
            Me.xBloqueado.Checked = Me.Lista.CurrentRow.Cells("cBloqueado").Value
            Me.xEmail.Text = Me.Lista.CurrentRow.Cells("email").Value & ""

            If Me.xBloqueado.Checked = True Then
                Me.xMotivoBloqueado.Text = "Favor conduzir o cliente para Atualização Cadastral"
            Else
                Me.xMotivoBloqueado.Text = ""
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ClientesProcura_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Me.A1.Checked = True
                Me.TxtProcura.Focus()
            Case Keys.F4
                Me.A2.Checked = True
                Me.TxtProcura.Focus()
            Case Keys.F5
                Me.A5.Checked = True
                Me.TxtProcura.Focus()
            Case Keys.F6
                Me.A3.Checked = True
                Me.TxtProcura.Focus()
            Case Keys.F7
                Me.A3a.Checked = True
                Me.TxtProcura.Focus()
            Case Keys.F8
                Me.A4.Checked = True
                Me.TxtProcura.Focus()
        End Select
    End Sub

    Private Sub btnCadClientes_Click(sender As Object, e As EventArgs) Handles btnCadClientes.Click
        My.Forms.Clientes.ShowDialog()
    End Sub
End Class