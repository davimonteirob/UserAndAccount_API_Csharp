using Connection_To_DataBaseCSharpe.DataBase;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.Models
{
    public class Usuario
    {
        Usuario[] usuarios = new Usuario[] { };
        public Usuario(string nome, string idade, string endereço)
        {
            Nome = nome;
            Idade = idade;
            Endereço = endereço;
        }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Endereço { get; set; }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("##  M E N U  ## ");
            Console.WriteLine("\n");
            Console.WriteLine("# Digite 1 para Adicionar um Usuário");
            Console.WriteLine("# Digite 2 para Exibir os Usuários");
            Console.WriteLine("# Digite 0 para sair");
            int opçãoSelecionada = Convert.ToInt32(Console.ReadLine());

            switch (opçãoSelecionada)
            {
                case 1:
                    AdicionarUsuario();
                    break;
                case 2:

                    Console.Clear();
                    var usuario01 = ListarUsuarios();
                    Console.WriteLine("## USUARIOS ##");
                    Console.WriteLine("\n");
                    foreach (var item in usuario01)
                    {
                        Console.WriteLine($"Nome: {item.Nome}. Idade: {item.Idade}. Endereço: {item.Endereço}.");
                        Console.WriteLine("-");
                    }
                    Thread.Sleep(18000);
                    Menu();
                    break;

                case 0: break;
            }
        }
            
        public void AdicionarUsuario()
        {
            
            //precisamos colocar um id no nosso usuario para facilitar a busca na list
            Console.Clear();
            Console.WriteLine("## ADICIONAR USUÁRIO ##");
            Console.WriteLine("\n");

            Console.WriteLine("Digite o Nome: ");
            string nome = Console.ReadLine();

            //correção do erro de conversão de idade string para int:
            
            Console.WriteLine("\nDigite a Idade: ");
            string idade = Console.ReadLine();

            Console.WriteLine("\n");
            Console.WriteLine("Digite o endereço");
            string endereço = Console.ReadLine();

            Usuario usuario01 = new Usuario(nome, idade, endereço);
            //------Adicionar Usuario ao DataBase------------------
            try                                                       
            {
                //agora precisamos dar um jeito de adicionar o usuario solicitado no método em nosso connection.
                var connection = new Connection();

                using var connectionObter = connection.ObterConexao();
                connectionObter.Open();
                // a funçãp do @, declarar uma variável
                string query = "INSERT INTO Usuarios (Nome, Idade, Endereço) VALUES (@Nome, @Idade, @Endereço)";
                SqlCommand command = new SqlCommand(query, connectionObter);

                command.Parameters.AddWithValue("@Nome", usuario01.Nome); // funciona como: var @Nome = usuario.Nome;
                command.Parameters.AddWithValue("@Idade", usuario01.Idade);
                command.Parameters.AddWithValue("@Endereço", usuario01.Endereço);
                command.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

            //-----------------------------------------------------
            Thread.Sleep(3000);
            Console.WriteLine("Dados do usuario adicionado com Sucesso!");

            Thread.Sleep(10000);
            Menu();

        }

        public IEnumerable<Usuario> ListarUsuarios()
        {
            var listaUsuario = new List<Usuario>();
            //Agora que temos a nossa lista, vamos fazer a conexão dentro do método Listar().
            //Ele será responsável por gerenciar a conexão. Toda vez que chamarmos esse método,
            //ele fará a conexão com o banco, e não uma conexão aberta permanentemente.
            Connection connection1 = new Connection();
            using var connection = connection1.ObterConexao();
            connection.Open(); //para abrir a nossa conexão

            string sql = "SELECT * FROM Usuarios";


            // agora que já temos o comando e a conexão para usar e consultar, devemos usar o nosso Objeto SqlCommand

            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader();
            //aqui colocamos uma verificação para definir o que a gente quer ler da nossa tabela
            while (dataReader.Read())// chamamos o método 'Read' no data Reade, que irá fazer a leitura >>
                                     // >> da informações que iremos passar.
            {//                                       aqui colocamos o nome que queremos que seja lido na tabela do Db
                string nomeUsuario = Convert.ToString(dataReader["Nome"]);//irá ler nome na tabela
                string idadeUsuario = Convert.ToString(dataReader["Idade"]);//..
                string endereçoUsuario = Convert.ToString(dataReader["Endereço"]);//..
                //feito isso, podemos criar o nosso usuario.
                Usuario usuario01 = new Usuario(nomeUsuario, idadeUsuario, endereçoUsuario);

                listaUsuario.Add(usuario01); //adicionamos o usuario01 que está recebendo a consulta do DataBase



            };

            //de acordo com o tipo de retorno do método, o valor a ser retornado deve ser uma lista (IEnumerable) do
            //objeto Usuario (IEnumerable<Usuario>), portanto, a nossa listaUsuario se adegua a nosso tipo de retorno.

            return listaUsuario;

        }

    }
}
