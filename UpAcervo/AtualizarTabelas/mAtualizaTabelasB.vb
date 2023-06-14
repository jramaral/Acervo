Imports System.IO
Imports System.Data.OleDb

Module mAtualizaTabelasB
    Public Sub AtualizaTabelasB()

        'Todas as Informações contigdas neste modulo se diz respeito as alterações 
        'feitas pelo Beto.

        '*******************Rotina Criada por *******************************
        '* Mesmo que a rotina seja executada varias vezes os erros serao somente   *
        '* erros dizendo que o o objeto ja existe portanto a rotina pode ser       *
        '* executada ate o final, a cada alteraçao tera que ser criada uma nova    *
        '* linha para execuçao dos dados necessarios.                              *
        '* Ex:                                                                     *
        '* ALTER TABLE empregados ADD cpf TEXT(20),rg TEXT(15)                     *
        '* ALTER TABLE empregados ALTER COLUMN sexo TEXT(30)                       *
        '* ALTER TABLE empregados DROP COLUMN sexo                                 *
        '*                                                                         *
        '* COUNTER = AutoNumeraçao                                                 *
        '* TEXT    = Texto                                                         *
        '* INTEGER= iNTEIRO                                                       *
        '* DATETIME= Data/Hora                                                     *
        '* CURRENCY= Moeda                                                         *
        '* MEMO= Memo                                                              *
        '* DOUBLE= Duplo                                                           *
        '* Sim/Não= YesNo                                                          *
        '***************************************************************************
        '*********************Rotina de Criação de Tabela Feita Pelo: e Beto***
        'CREATE TABLE NomeTabela (campo1 TEXT(10), campo2 TEXT(20), Constraint NomeTabela_PK Primary Key(Campo1))
        '********************************************************************************************************

        Dim CNN As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN.Open()

        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = CNN


        '01/06/2019  -- colocar os valores em aberto do contas a receber
        '01/06/2019  -- colocar os valores em aberto do contas a receber
        Try
            cmd.CommandText = "ALTER TABLE Clientes ADD ValorEmAberto CURRENCY"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        '03062019 - correção dos valores para produtos com avarias
        Try
            cmd.CommandText = "UPDATE Locacao INNER JOIN (Produtos INNER JOIN LocacaoItens ON Produtos.CodigoProduto = LocacaoItens.Produto) ON Locacao.IdLoc = LocacaoItens.IdLocacao SET LocacaoItens.ValorUnitarioAvarias = [Produtos].[ValorVenda2] WHERE (((Locacao.StatusLoc)='LOCADO'));"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        
        '14/12/2018
        Try
            cmd.CommandText = "ALTER TABLE LocacaoOrcamento ADD DataOrcamento DATETIME"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        '14/12/2018
        Try
            cmd.CommandText = "UPDATE LocacaoOrcamento SET DataOrcamento=DataFechamento where DataOrcamento Is Null"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        '14/12/2018
        Try
            cmd.CommandText = "UPDATE LocacaoOrcamento SET DataOrcamento=DataLoc where DataOrcamento Is Null"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        '05/12/2018
        Try
            cmd.CommandText = "ALTER TABLE Produtos ADD Origem TEXT(25)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            cmd.CommandText = "UPDATE Produtos Set Origem='(NENHUM)' WHERE Origem Is Null"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try



        '16/06/2017
        Try
            cmd.CommandText = "ALTER TABLE Locacao ADD ValorEntrada CURRENCY"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        '16/06/2017
        Try
            cmd.CommandText = "UPDATE Locacao Set ValorEntrada=0 WHERE ValorEntrada Is Null"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        '11/03/2017
        Try
            cmd.CommandText = "ALTER TABLE Produtos ADD EmLocacao Integer"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        '02/03/2017
        Try
            cmd.CommandText = "ALTER TABLE Locacao ADD ProdutosEntregue YesNo"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try



        Try
            cmd.CommandText = "ALTER TABLE Locacao ADD OutrosAjustes DOUBLE"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        'Criação da Table LocacaoOrcamento
        Try
            cmd.CommandText = "CREATE TABLE LocacaoOrcamento (IdLoc COUNTER,DataLoc DateTime, NomeCliente Text(100), Telefone TExt(15), Cidade TExt(50), UF Text(2), HoraLoc Text(8),DataRetorno DateTime,HoraRetorno Text(8),Frete Text(50),StatusLoc Text(10),Cliente Integer,ObsLoc Memo,DiariaAmais Integer,ValorFrete Double,TotalItens Double,TotalDesconto double,TotalDiarias double,TotalAvarias Double,TotalLoc Double,FormaPgto Text(20), LocalPgto Text(20), QtdParcelas integer, Empresa integer, CodigoTransportadora INTEGER, NomeTransportadora TEXT(50), Placa TEXT(7), LocalEntrega TEXT(100), Contato TEXT(50), DataFechamento DATETIME, Entrega Text(20), Devolve Text(20), CodigoVendedor Integer, NomeVendedor Text(60), TransformadoEmLocacao YesNo, Constraint PrimaryKeyLocacao Primary Key(IdLoc))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'Criação da table LocacaoItensOrcamento
        Try
            cmd.CommandText = "CREATE TABLE LocacaoItensOrcamento (IdItem COUNTER,IdLocacao Integer,Produto Integer,Qtd Double,DiariaAmais Integer,ValorUnitarioLoc Double,ValorDescontoLoc Double,TotalDiarias Double,TotalLoc Double,QtdDev Double,QtdAvarias Double,ValorUnitarioAvarias Double,TotalAvarias Double, Disponibilidade Text(1), Constraint PrimaryKeyLocacaoItens Primary Key(IdItem), FOREIGN KEY (IdLocacao) REFERENCES LocacaoOrcamento (IdLoc) ON DELETE CASCADE ON UPDATE CASCADE)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'Alteração cadastro de Produtos para gerenciar as promoções
        Try
            cmd.CommandText = "ALTER TABLE Locacao ADD CodigoTransportadora INTEGER, NomeTransportadora TEXT(50), Placa TEXT(7), LocalEntrega TEXT(100), Contato TEXT(50), DataFechamento DATETIME, Entrega Text(20), Devolve Text(20), CodigoVendedor Integer, NomeVendedor Text(60), NumeroOrcamento Integer, DataEfetivaRetorno DateTime"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        ''' <summary>
        ''' Criação da tebela de frete para a locação
        ''' 13/11/2016
        ''' </summary>
        Try
            cmd.CommandText = "CREATE TABLE Frete (codigoFrete COUNTER, DescricaoFrete TEXT(50), ValorKM CURRENCY, DistanciaKM INTEGER, ValorFrete CURRENCY, Empresa INTEGER, Primary Key(DescricaoFrete))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'Alteração Clientes, identifica se é decorador
        Try
            cmd.CommandText = "ALTER TABLE CLIENTES ADD Decorador Text(1)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'Alteração cadastro de Produtos para gerenciar as promoções
        Try
            cmd.CommandText = "ALTER TABLE PRODUTOS ADD ProdutoNaPromocao Text(1), DataInicioPromocao DateTime, DataFinalPromocao DateTime, ValorPromocao CURRENCY"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'Alteração cadastro de Produtos para gerenciar as promoções
        Try
            cmd.CommandText = "UPDATE PRODUTOS SET ProdutoNaPromocao='N' WHERE ProdutoNaPromocao Is Null"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'Alteração cadastro de Produtos para gerenciar as promoções
        Try
            cmd.CommandText = "UPDATE PRODUTOS SET ValorPomocao=0 WHERE ValorPomocao Is Null"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'Alteração cadastro de Clientes Decorador
        Try
            cmd.CommandText = "UPDATE CLIENTES SET Decorador='N' WHERE Decorador Is Null"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try




        'Empresa Alteraçoes de Tabelas

        Try
            cmd.CommandText = "ALTER TABLE EMPRESA ADD CodCRT Text(1)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try



        'CRIA TABELA PARA INDICAR A TRIBUTAÇÃO DA EMPRESA
        Try
            cmd.CommandText = "CREATE TABLE CodCRT (codCRT Text(1), DescricaoCRT Text(60), Primary Key(codCRT))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'FAZ INSERT DAS INFORMAÇÕES NECESSÁRIAS PARA A TABELA  QUE VAI SER USANDA NO PERFIL DE TRIBUTAÇÃO DA EMPRESA
        Try
            cmd.CommandText = "INSERT INTO CodCRT (codCRT, DescricaoCRT) Values ('1','SIMPLES NACIONAL');"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO CodCRT (codCRT, DescricaoCRT) Values ('2','SIMPLES NACIONAL - EXESSO DE SUBLIMITE DE RECEITA BRUTA');"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO CodCRT (codCRT, DescricaoCRT) Values ('3','REGIME NORMAL');"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
        End Try





        '19-08-2016
        Try
            cmd.CommandText = "Alter Table Receber ADD VendedorComissao Currency"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            cmd.CommandText = "Alter Table Receber ADD VendedorComissao Currency"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        Try
            cmd.CommandText = "Alter Table Receber ADD cAprazoReceber Currency"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            cmd.CommandText = "Alter Table Receber ALTER COLUMN cAprazoReceber Currency"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        '19-08-2016
        Try
            cmd.CommandText = "Alter Table Boletos ADD UserGerouBoleto Text(50), DataHoraGerou DateTime"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            cmd.CommandText = "Alter Table Boletos DROP COLUMN ValorJurosPagaoRetorno"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            cmd.CommandText = "Alter Table Boletos ADD ValorJurosPagaRetorno Currency"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        '19-08-2016
        Try
            cmd.CommandText = "Alter Table Boletos ADD UserGerouRemessa Text(50), DataHoraGeradoRemessa DateTime"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        '29-07-2016
        Try
            cmd.CommandText = "Alter Table Clientes ADD IndIeDest Text(4)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        '29-07-2016
        'Try
        ' cmd.CommandText = "Alter Table Clientes ADD IndicadorIE Text(4)"
        ' cmd.ExecuteNonQuery()
        'Catch ex As Exception
        'End Try


        '12-07-2016
        Try
            cmd.CommandText = "Alter Table Empresa ADD Site Text(60)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        '22-07-2015
        Try
            cmd.CommandText = "Alter Table Empresa ADD ImpressoraPedido Text(50), ImpressoraOrcamento Text(50)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        'CRIA ALGUNS CAMPOS PARA SPED
        Try
            cmd.CommandText = "Alter Table Produtos ADD Tipo_Item Text(2), Cod_Gen Text(2), Cod_LST Text(4), Cod_EX_TIPI Text(3)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        'CRIA A TABELA GEN
        Try
            cmd.CommandText = "CREATE Table TabelaGen (CodigoGen Text(2), DescricaoGen Text(220), Primary Key(CodigoGen))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'ATUALIZA AS UNIDADES DE MEDIAS PARA MAIUSCULAS
        Try
            cmd.CommandText = "UPDATE produtos SET produtos.UnidadeMedida = UCase([unidademedida]);"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'Alteração na tabela Empresa
        Try
            cmd.CommandText = "Alter Table Empresa ADD COD_VER Text(3), SUFRAMA Text(9), IND_PERFIL TEXT(1), IND_ATIV TEXT(1)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'CRIAÇÃO DA TABELA UNIDADE MEDIDA
        Try
            cmd.CommandText = "create table UnidadeMedida(sigla Text(4), DescricaoUnidade Text(60), primary key (sigla))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'CRIAÇÃO DE INDEX UNIDADE MEDIDA
        Try
            cmd.CommandText = "CREATE INDEX Descr ON UnidadeMedida(DescricaoUnidade)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'CRIA O CAMPO DATA DE ABERTURA NA TABELA FORNECEDOR
        Try
            cmd.CommandText = "ALTER TABLE Fornecedor ADD DataAbertura DateTime"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try 'Altera BoletoContasCorrentes - - José Roberto
            cmd.CommandText = "ALTER TABLE BoletoContasCorrentes ALTER COLUMN ChaveContaCorrente TEXT(4)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try 'Altera BoletoContasCorrentes - - José Roberto
            cmd.CommandText = "ALTER TABLE Boletos ALTER COLUMN ChaveContaCorrente TEXT(4)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try 'Altera TABLE Banco - - José Roberto
            cmd.CommandText = "ALTER TABLE Banco ALTER COLUMN Codigo TEXT(4)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try 'Altera TABLE Empresa - - José Roberto
            cmd.CommandText = "ALTER TABLE Empresa ADD COD_MUN TEXT(7), IM text(30)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        Try 'Altera TABLE Empresa - - José Roberto
            cmd.CommandText = "ALTER TABLE Compra ADD ValorPIS currency, ValorCofins currency, ValorPisST Currency, ValorCofinsST Currency, ModFrete Text(1), ValorSeguro Currency"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try 'Altera TABLE Empresa - - José Roberto
            cmd.CommandText = "ALTER TABLE Compra ADD NatOp Text(10)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try 'Altera TABLE Empresa - - José Roberto
            cmd.CommandText = "ALTER TABLE Compra ADD Atualizado YesNo"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        'CRIA A TABELA NATUREZA OPERAÇÃO REG0400 SPED
        Try
            cmd.CommandText = "CREATE Table NatOpSped (CodigoNat Text(10), DescricaoNat Text(60), Primary Key(CodigoNat))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'CRIA A TABELA NATUREZA OPERAÇÃO REG0400 SPED
        Try
            cmd.CommandText = "INSERT into NatOpSped (CodigoNat, DescricaoNat) Values ('1000','ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO ESTADO');"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT into NatOpSped (CodigoNat, DescricaoNat) Values ('2000','ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DE OUTROS ESTADOS');"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        'Atualizar os campos NatOp e ModFrete da compra
        Try
            cmd.CommandText = "UPDATE Compra INNER JOIN Fornecedor ON Compra.CodigoFornecedor = Fornecedor.CódigoFornecedor SET Compra.NatOp = '2000', Compra.ModFrete = '0' WHERE (((Fornecedor.cUF)<>'50'));"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE Compra INNER JOIN Fornecedor ON Compra.CodigoFornecedor = Fornecedor.CódigoFornecedor SET Compra.NatOp = '1000', Compra.ModFrete = '0' WHERE (((Fornecedor.cUF)='50'));"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        Try

            cmd.CommandText = "SELECT Sum(ItensCompra.ValorPisProduto) AS ValorPis, Sum(ItensCompra.ValorCofinsProduto) AS ValorCofins, ItensCompra.CompraInterno FROM ItensCompra INNER JOIN Compra ON ItensCompra.CompraInterno = Compra.CompraInterno WHERE(((Compra.Atualizado) = False)) GROUP BY ItensCompra.CompraInterno;"


            Dim reader As OleDbDataReader
            reader = cmd.ExecuteReader()

            Dim cmdCompra As New OleDbCommand()
            cmdCompra.Connection = CNN

            While reader.Read()
                cmdCompra.CommandText = "Update compra set ValorPis=@1, ValorCofins=@2, Atualizado=@3 where comprainterno=" & reader.Item("CompraInterno")
                cmdCompra.Parameters.AddWithValue("@1", nzNUM(reader.Item("ValorPis")))
                cmdCompra.Parameters.AddWithValue("@2", nzNUM(reader.Item("ValorCofins")))
                cmdCompra.Parameters.AddWithValue("@3", True)
                cmdCompra.ExecuteNonQuery()
                cmdCompra.Parameters.Clear()
            End While
            reader.Close()
        Catch ex As Exception

        End Try


        Try 'Altera TABLE Pedido - - José Roberto
            cmd.CommandText = "ALTER TABLE Pedido ADD NumeroOrcamento INTEGER"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try 'Altera TABLE Pedido - - José Roberto
            cmd.CommandText = "ALTER TABLE Produtos ADD Cest Text(7)"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try





        'fecha a conexao cnn
        CNN.Close()


        '---------------------------------'
        'inserir informações para conexxao cnn1 daqui pra baixo

        'INSERE AS INFORMAÇÕES DA TABELA GEN
        Dim CNN1 As New OleDb.OleDbConnection(New Conectar().ConectarBD(LocalBD & Nome_BD))
        CNN1.Open()
        Dim myTrans As OleDbTransaction
        myTrans = CNN1.BeginTransaction
        Try

            cmd.Connection = CNN1
            cmd.Transaction = myTrans
            cmd.CommandText = "insert into TabelaGen VALUES ('01','Animais vivos')"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into TabelaGen VALUES ('02','Carnes e miudezas, comestíveis')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('03','Peixes e crustáceos, moluscos e os outros invertebrados aquáticos')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('04','Leite e laticínios; ovos de aves; mel natural; produtos comestíveis de origem animal, não especificados nem compreendidos em outros Capítulos da TIPI')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('05','Outros produtos de origem animal, não especificados nem compreendidos em outros Capítulos da TIPI')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('06','Plantas vivas e produtos de floricultura')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('07','Produtos hortícolas, plantas, raízes e tubérculos, comestíveis')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('08','Frutas; cascas de cítricos e de melões')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('09','Café, chá, mate e especiarias')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('10','Cereais')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('11','Produtos da indústria de moagem; malte; amidos e féculas; inulina; glúten de trigo')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('12','Sementes e frutos oleaginosos; grãos, sementes e frutos diversos; plantas industriais ou medicinais; palha e forragem')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('13','Gomas, resinas e outros sucos e extratos vegetais')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('14','Matérias para entrançar e outros produtos de origem vegetal, não especificadas nem compreendidas em outros Capítulos da NCM')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('15','Gorduras e óleos animais ou vegetais; produtos da sua dissociação; gorduras alimentares elaboradas; ceras de origem animal ou vegetal')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('16','Preparações de carne, de peixes ou de crustáceos, de moluscos ou de outros invertebrados aquáticos')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('17','Açúcares e produtos de confeitaria')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('18','Cacau e suas preparações')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('19','Preparações à base de cereais, farinhas, amidos, féculas ou de leite; produtos de pastelaria')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('20','Preparações de produtos hortícolas, de frutas ou de outras partes de plantas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('21','Preparações alimentícias diversas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('22','Bebidas, líquidos alcoólicos e vinagres')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('23','Resíduos e desperdícios das indústrias alimentares; alimentos preparados para animais')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('24','Fumo (tabaco) e seus sucedâneos, manufaturados')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('25','Sal; enxofre; terras e pedras; gesso, cal e cimento')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('26','Minérios, escórias e cinzas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('27','Combustíveis minerais, óleos minerais e produtos de sua destilação; matérias betuminosas; ceras minerais')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('28','Produtos químicos inorgânicos; compostos inorgânicos ou orgânicos de metais preciosos, de elementos radioativos, de metais das terras raras ou de isótopos')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('29','Produtos químicos orgânicos')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('30','Produtos farmacêuticos')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('31','Adubos ou fertilizantes')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('32','Extratos tanantes e tintoriais; taninos e seus derivados; pigmentos e outras matérias corantes, tintas e vernizes, mástiques; tintas de escrever')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('33','Óleos essenciais e resinóides; produtos de perfumaria ou de toucador preparados e preparações cosméticas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('35','Matérias albuminóides; produtos à base de amidos ou de féculas modificados; colas; enzimas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('36','Pólvoras e explosivos; artigos de pirotecnia; fósforos; ligas pirofóricas; matérias inflamáveis')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('37','Produtos para fotografia e cinematografia')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('38','Produtos diversos das indústrias químicas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('39','Plásticos e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('40','Borracha e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('41','Peles, exceto a peleteria (peles com pêlo*), e couros')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('42','Obras de couro; artigos de correeiro ou de seleiro; artigos de viagem, bolsas e artefatos semelhantes; obras de tripa')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('43','Peleteria (peles com pêlo*) e suas obras; peleteria (peles com pêlo*) artificial')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('44','Madeira, carvão vegetal e obras de madeira')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('45','Cortiça e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('46','Obras de espartaria ou de cestaria')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('47','Pastas de madeira ou de outras matérias fibrosas celulósicas; papel ou cartão de reciclar (desperdícios e aparas)')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('48','Papel e cartão; obras de pasta de celulose, de papel ou de cartão')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('49','Livros, jornais, gravuras e outros produtos das indústrias gráficas; textos manuscritos ou datilografados, planos e plantas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('50','Seda')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('51','Lã e pêlos finos ou grosseiros; fios e tecidos de crina')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('52','Algodão')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('53','Outras fibras têxteis vegetais; fios de papel e tecido de fios de papel')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('54','Filamentos sintéticos ou artificiais')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('55','Fibras sintéticas ou artificiais, descontínuas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('56','Pastas (ouates), feltros e falsos tecidos; fios especiais; cordéis, cordas e cabos; artigos de cordoaria')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('57','Tapetes e outros revestimentos para pavimentos, de matérias têxteis')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('58','Tecidos especiais; tecidos tufados; rendas; tapeçarias; passamanarias; bordados')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('59','Tecidos impregnados, revestidos, recobertos ou estratificados; artigos para usos técnicos de matérias têxteis')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('60','Tecidos de malha')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('61','Vestuário e seus acessórios, de malha')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('62','Vestuário e seus acessórios, exceto de malha')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('63','Outros artefatos têxteis confeccionados; sortidos; artefatos de matérias têxteis, calçados, chapéus e artefatos de uso semelhante, usados; trapos')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('64','Calçados, polainas e artefatos semelhantes, e suas partes')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('65','Chapéus e artefatos de uso semelhante, e suas partes')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('66','Guarda-chuvas, sombrinhas, guarda-sóis, bengalas, bengalas-assentos, chicotes, e suas partes')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('67','Penas e penugem preparadas, e suas obras; flores artificiais; obras de cabelo')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('68','Obras de pedra, gesso, cimento, amianto, mica ou de matérias semelhantes')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('69','Produtos cerâmicos')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('70','Vidro e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('71','Pérolas naturais ou cultivadas, pedras preciosas ou semipreciosas e semelhantes, metais preciosos, metais folheados ou chapeados de metais preciosos, e suas obras; bijuterias; moedas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('72','Ferro fundido, ferro e aço')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('73','Obras de ferro fundido, ferro ou aço')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('74','Cobre e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('75','Níquel e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('76','Alumínio e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('77','(Reservado para uma eventual utilização futura no SH)')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('78','Chumbo e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('79','Zinco e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('80','Estanho e suas obras')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('81','Outros metais comuns; ceramais (cermets); obras dessas matérias')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('82','Ferramentas, artefatos de cutelaria e talheres, e suas partes, de metais comuns')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('83','Obras diversas de metais comuns')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('84','Reatores nucleares, caldeiras, máquinas, aparelhos e instrumentos mecânicos, e suas partes')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('85','Máquinas, aparelhos e materiais elétricos, e suas partes; aparelhos de gravação ou de reprodução de som, aparelhos de gravação ou de reprodução de imagens e de som em televisão, e suas partes e acessórios')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('86','Veículos e material para vias férreas ou semelhantes, e suas partes; aparelhos mecânicos (incluídos os eletromecânicos) de sinalização para vias de comunicação')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('87','Veículos automóveis, tratores, ciclos e outros veículos terrestres, suas partes e acessórios')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('88','Aeronaves e aparelhos espaciais, e suas partes')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('89','Embarcações e estruturas flutuantes')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('90','Instrumentos e aparelhos de óptica, fotografia ou cinematografia, medida, controle ou de precisão; instrumentos e aparelhos médico-cirúrgicos; suas partes e acessórios')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('91','Aparelhos de relojoaria e suas partes')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('92','Instrumentos musicais, suas partes e acessórios')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('93','Armas e munições; suas partes e acessórios')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('94','Móveis, mobiliário médico-cirúrgico; colchões; iluminação e construção pré-fabricadas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('95','Brinquedos, jogos, artigos para divertimento ou para esporte; suas partes e acessórios')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('96','Obras diversas')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('97','Objetos de arte, de coleção e antiguidades')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('98','(Reservado para usos especiais pelas Partes Contratantes)')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into TabelaGen VALUES('99','Operações especiais (utilizado exclusivamente pelo Brasil para classificar operações especiais na exportação)')"
            cmd.ExecuteNonQuery()

            myTrans.Commit()

            'FIM DA INSERÇÃO

        Catch ex As Exception
            myTrans.Rollback()
        End Try


        myTrans = CNN1.BeginTransaction
        Try

            cmd.Connection = CNN1
            cmd.Transaction = myTrans
            cmd.CommandText = "Insert into UnidadeMedida Values ('CX','CAIXA')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('FD','FARDO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('FRC','FRASCO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('KG','KILO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('SC','SACO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('PÇ','PEÇA')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('UN','UNIDADE')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('CJ','CONJUNTO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('M','METRO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('M2','METRO QUADRADO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('MI','MILHEIRO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('PCT','PACOTE')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('RL','ROLO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('VOL','VOLUME')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('L','LITRO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('M3','METRO CUBICO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('PTE','POTE')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('BD','BALDE')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('BR','BARRA')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('LTA','LATA')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('KIT','KITE')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('CT','CARTELA')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Insert into UnidadeMedida Values('BJ','BANDEJA')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into UnidadeMedida Values('GL','GALAO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into UnidadeMedida Values('DZ','DUZIA')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into UnidadeMedida Values('JG','JOGO')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into UnidadeMedida Values('PAR','PARES')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into UnidadeMedida Values('PLA','PLACA')"
            cmd.ExecuteNonQuery()
            myTrans.Commit()


        Catch ex As Exception
            myTrans.Rollback()
        End Try
        CNN1.Close()
        'FIM DA INSERÇÃO









        CNN1 = Nothing
        cmd = Nothing
        CNN = Nothing
    End Sub

End Module
