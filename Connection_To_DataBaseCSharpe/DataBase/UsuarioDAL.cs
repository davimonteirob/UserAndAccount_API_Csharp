using Connection_To_DataBaseCSharpe.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.DataBase
{
    internal class UsuarioDAL
    {
        //Classe padrão de boas práticas para métodos que gerenciam o banco de dados.
        public void AdicionarUsuario()
        {

            //Pegamos os dados dos usuarios:
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

                // dizemos para qual coluna da tabela (Nome = "@Nome") queremos adicionar o  usuario01.Nome
                command.Parameters.AddWithValue("@Nome", usuario01.Nome); // funciona como: var @Nome = usuario.Nome;
                command.Parameters.AddWithValue("@Idade", usuario01.Idade);
                command.Parameters.AddWithValue("@Endereço", usuario01.Endereço);

                //aqui recebemos a quantidade de linhas que foram adicionados na tabela.
                int retorno = command.ExecuteNonQuery();
                Console.WriteLine("\n");
                Console.WriteLine($"Quantidade linhas afetadas da Tabela: {retorno}Linha(s) Table - DataBase.");

                command.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //-----------------------------------------------------
            Thread.Sleep(3000);
            Console.WriteLine("Dados do usuario adicionado com Sucesso! Aguarde até que volte para o Menu.");

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
