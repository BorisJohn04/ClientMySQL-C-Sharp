using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace estrutura
{
	class variaveis
	{
		public static int counter;
		public static string login;
		public static string password;
		public static string showData;
		public static long id;
		public static string buscador;
		public static int seletor;
		public static string nome;
		public static long senha;
		public static string email;
		public static long numero;
		public static string periodo;

	}
	class dados
	{
		public struct produto
		{
			public string numberPassword;
			public string numberLogin;
			public long numberId;
			public string nomeDiscente;
			public long senhaDiscente;
			public string emailDiscente;
			public long numeroDiscente;
			public string periodoDiscente;
		}
	}
	class metodos
	{
		public static void registro()
		{
			Console.WriteLine("==================");
			Console.WriteLine("ID de usuário    =");
			Console.WriteLine("==================");
			variaveis.id = int.Parse(Console.ReadLine());
			Console.WriteLine("==================");
			Console.WriteLine("Nome do discente =");
			Console.WriteLine("==================");
			variaveis.nome = Console.ReadLine();
			Console.WriteLine("==========================");
			Console.WriteLine("Crie uma senha de acesso =");
			Console.WriteLine("==========================");
			variaveis.senha = long.Parse(Console.ReadLine());
			Console.WriteLine("============================");
			Console.WriteLine("Insira um E-mail de acesso =");
			Console.WriteLine("============================");
			variaveis.email = Console.ReadLine();
			Console.WriteLine("===============================");
			Console.WriteLine("Insira um número para contato =");
			Console.WriteLine("===============================");
			variaveis.numero = long.Parse(Console.ReadLine());
			Console.WriteLine("==========================");
			Console.WriteLine("Informe o período letivo =");
			Console.WriteLine("==========================");
			variaveis.periodo = Console.ReadLine();
			Console.WriteLine("===============================");
			Console.WriteLine("Crie uma senha de acesso      =");
			Console.WriteLine("===============================");
			variaveis.password = Console.ReadLine();
			Console.WriteLine("==========================");
			Console.WriteLine("Crie um login de acesso  =");
			Console.WriteLine("==========================");
			variaveis.login = Console.ReadLine();
		}

		public static void Banco()
		{
			dados.produto datas;
			datas.numberLogin = variaveis.login;
			datas.numberPassword = variaveis.password;
			datas.numberId = variaveis.id;
			datas.nomeDiscente = variaveis.nome;
			datas.senhaDiscente = variaveis.senha;
			datas.emailDiscente = variaveis.email;
			datas.numeroDiscente = variaveis.numero;
			datas.periodoDiscente = variaveis.periodo;

			Console.WriteLine("-----------------------------------------");
			Console.WriteLine("=========/INFORMAÇÕES CADASTRADAS/=======");
			Console.WriteLine("ID de usuário: >> " + datas.numberId);
			Console.WriteLine("-----------------------------------------");
			Console.WriteLine("Nome cadastrado: >> " + datas.nomeDiscente);
			Console.WriteLine("-------------------------------------------");
			Console.WriteLine("Senha de usuário: >> " + datas.senhaDiscente);
			Console.WriteLine("---------------------------------------------");
			Console.WriteLine("Endereço de E-mail: >> " + datas.emailDiscente);
			Console.WriteLine("---------------------------------------------");
			Console.WriteLine("Número de contato: >> " + datas.numeroDiscente);
			Console.WriteLine("-------------------------------------------");
			Console.WriteLine("Período letivo: >> " + datas.periodoDiscente);
			Console.WriteLine("-------------------------------------------");
			Console.WriteLine("Senha cadastrada: >> " + datas.numberPassword);
			Console.WriteLine("-------------------------------------------");
			Console.WriteLine("Login cadastrado: >> " + datas.numberLogin);
			Console.WriteLine("-------------------------------------------");

		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			//conexão
			//=======
			dados.produto datas;
			metodos.registro();
			metodos.Banco();
			Console.WriteLine("=======================================================");
			Console.WriteLine("Deseja enviar essas informações para o banco de dados?=");
			Console.WriteLine("=======================================================");
			Console.WriteLine("==================");
			Console.WriteLine("1 - Sim, 2 - Não =");
			Console.WriteLine("==================");
			variaveis.seletor = int.Parse(Console.ReadLine());
			switch (variaveis.seletor)
			{
				case 1:
					ConectionToDataBase.mysqlBase();
					variaveis.counter = 1;
					break;
				case 2:
					Console.WriteLine("==================");
					Console.WriteLine("Dados não salvos =");
					Console.WriteLine("==================");
					break;
			}

			while (variaveis.counter == 1)
			{
				ConectionToDataBase.login();
			}
			//ConectionToDataBase.buscarDados();
		}
	}

	class ConectionToDataBase
	{
		public static void login()
		{
			//Faça login
			Console.WriteLine("Entrando no banco de dados");
			//=======================================================
			Console.WriteLine("LOGIN");
			variaveis.login = Console.ReadLine();
			//==================================
			Console.WriteLine("SENHA");
			variaveis.password = Console.ReadLine();

			if (variaveis.login != "" && variaveis.password != "")
			{
				string adressLogin = "server = localhost; User id = root; port 3306; password =; database = DataBase1";
				MySqlConnection conexao2;
				conexao2 = new MySqlConnection(adressLogin);
				conexao2.Open();
				if (conexao2.State == ConnectionState.Open)
				{
					string objCmd2 = "select * from datas3 where login = ?";//string que guarda o endereço de busca
					MySqlCommand comando0 = new MySqlCommand(objCmd2, conexao2);//Comando que instancia a instrução de incremento de dados no banco, junto com a conexão

					comando0.Parameters.Add("@login", MySqlDbType.VarChar).Value = variaveis.login;//linha de incremento na variável cdDados, do tipo varchar, herdando o dado da variável searching
					comando0.CommandType = CommandType.Text;//instancia do comando de texto

					//if (conexao.State == ConnectionState.Closed)//verifica se a conexão está fechada para abri-la novamente
					//{
					//conexao.Open();//abre a conexão
					//	}
					MySqlDataReader dr;//variável que recebe a leitura do que é encontrado dentro do banco
					dr = comando0.ExecuteReader();//herança do comando de leitura
												  //dr.Read();
												  //execução do método de leitura
					while (dr.Read())//repetição da exibição de resultados
					{
						if (variaveis.login == dr.GetString(7) && variaveis.password == dr.GetString(6))
						{
							//exibe o que foi encontrado de acordo com oque foi inserido na
							//Console.WriteLine("Seu resultado: >> " + dr.GetInt32("id"));
							Console.WriteLine("Seu nome: >>" + dr.GetString(1));//posições das coluna a parti de onde começará a exibição.
							Console.WriteLine("Seu E-Mail: >>" + dr.GetString(3));
							Console.WriteLine("Seu período: >>" + dr.GetString(5));
							break;
						}
						else
						{
							Console.WriteLine("Nome não encontrado no banco");
						}
					}
					Console.WriteLine("Deseja buscar mais algo?");
					string searching2 = Console.ReadLine();
					conexao2.Close();//encerra o banco de dados
				}
			}
		}
		public static void mysqlBase()//faz conexão e insere dados
		{
			MySqlConnection conexao; //atributo de conexão
			string dataSource = "server = 127.0.0.1; User id = root; port = 3306; password=; database = DataBase1";//endereço de conexão
			conexao = new MySqlConnection(dataSource);//conexão instancia uma nova conexão com datasource, acesando o endereço de conexão
			Console.WriteLine("Conexão com banco de dados bem sucedida");//avisa que a conexão foi bem sucedida
			string myDatas = "INSERT INTO datas3( id, nome, senha, email, numero, periodo, pass, login) values('" + variaveis.id + "', '" + variaveis.nome + "', '" + variaveis.senha + "', '" + variaveis.email + "', '" + variaveis.numero + "', '" + variaveis.periodo + "', '" + variaveis.password + "', '" + variaveis.login + "')";
			//myDatas é o endereço de alocação de dados, com ordem de variáveis e valores para onde cada dado deve ser enviado
			MySqlCommand comando = new MySqlCommand(myDatas, conexao);//Comando que instancia a instrução de incremento de dados no banco, junto com a conexão
			conexao.Open();//abre o banco de dados para ter acesso a ele
			comando.ExecuteNonQuery();//executa o comando de instrução
			conexao.Close();//encerra o banco de dados
		}

		public static void buscarDados()
		{
			int searching;//string de busca no banco
			MySqlConnection conexao; //atributo de conexão
			string dataSource = "server = 127.0.0.1; User id = root; port = 3306; password=; database = DataBase1";//endereço de conexão
			conexao = new MySqlConnection(dataSource);//conexão instancia uma nova conexão com datasource, acesando o endereço de conexão
			Console.WriteLine("Conexão com banco de dados bem sucedida");//avisa que a conexão foi bem sucedida
			conexao.Open();


			if (conexao.State == ConnectionState.Open)
			{
				Console.WriteLine("Buscar dados: ");//pergunta se você deseja pesquisar algo no banco
				searching = int.Parse(Console.ReadLine());//ler os dados do teclado
				string objCmd = "select * from datas3 where id = ?";//string que guarda o endereço de busca
				MySqlCommand comando4 = new MySqlCommand(objCmd, conexao);//Comando que instancia a instrução de incremento de dados no banco, junto com a conexão
				comando4.Parameters.Add("@id", MySqlDbType.Int32).Value = searching;//linha de incremento na variável cdDados, do tipo varchar, herdando o dado da variável searching
				comando4.CommandType = CommandType.Text;//instancia do comando de texto

				//if (conexao.State == ConnectionState.Closed)//verifica se a conexão está fechada para abri-la novamente
				//{
				//conexao.Open();//abre a conexão
				//	}
				MySqlDataReader dr;//variável que recebe a leitura do que é encontrado dentro do banco
				dr = comando4.ExecuteReader();//herança do comando de leitura
											  //dr.Read();
											  //execução do método de leitura
				while (dr.Read())//repetição da exibição de resultados
				{
					//exibe o que foi encontrado de acordo com oque foi inserido na
					//Console.WriteLine("Seu resultado: >> " + dr.GetInt32("id"));
					Console.WriteLine("Resultado: >>" + dr.GetString(0));//posições das coluna a parti de onde começará a exibição.
					Console.WriteLine("Resultado: >>" + dr.GetString(1));
					Console.WriteLine("Resultado: >>" + dr.GetString(2));
					Console.WriteLine("Resultado: >>" + dr.GetString(3));
					Console.WriteLine("Resultado: >>" + dr.GetString(4));
					Console.WriteLine("Resultado: >>" + dr.GetString(5));
					break;
				}
				Console.WriteLine("Deseja buscar mais algo?");
				string searching2 = Console.ReadLine();
				conexao.Close();//encerra o banco de dados
			}
		}
	}
}