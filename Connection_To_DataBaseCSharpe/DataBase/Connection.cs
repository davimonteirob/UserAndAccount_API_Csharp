using Connection_To_DataBaseCSharpe.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.DataBase
{
    internal class Connection
 // voce também pode consultar em um site confiável um link string de connection confiável que ja funciona, apenas altere as opções importantes como id senha e nome.
         // Confira essas informações do string connection, como nome id e senha:
    {                                      //nome do servidor      Nome do Banco de Dados              Id do servidor e senha
        private string connectionString = "Server=DESKTOP-KM1NEG8;Database=TestConnectionToDataBase;User Id=sa;Password=123456;\r\n";

        //a função para usar o o link string para conectar o projeto com o banco de dados
        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
        // Agora queremos manipular nosso banco, já que agora temos uma conexão fluida. Queremos consultar tabela, alterar e tc..
        // vamos fazer isso agora tudo pelo nosso código.

        //vamos fazer um método para listar as informações do banco:
        public IEnumerable<Usuario> ListarUsuarios()
        {
            var lista = new List<Usuario>();
            //Agora que temos a nossa lista, vamos fazer a conexão dentro do método Listar().
            //Ele será responsável por gerenciar a conexão. Toda vez que chamarmos esse método,
            //ele fará a conexão com o banco, e não uma conexão aberta permanentemente.
            using var connection = ObterConexao();
            connection.Open(); //para abrir a nossa conexão

            string sql = "SELECT * FROM Usuarios";

            // agora que já temos o comando e a conexão para usar e consultar, devemos usar o nosso Objeto SqlCommand

            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader(); 
            //aqui colocamos uma verificação para definir o que a gente quer ler da nossa tabela
            while (dataReader.Read())// chamamos o método 'Read' no data Reade, que irá fazer a leitura
                //da informações que iremos passar.
            {//                                       aqui colocamos o nome que queremos que seja lido na tabela do Db
                string nomeUsuario = Convert.ToString(dataReader["Nome"]);
                int idadeUsuario = Convert.ToInt32(dataReader["Idade"]);
                string idUsuario = Convert.ToString(dataReader["Id"]);

                Usuario usuario01 = new(nomeUsuario, idadeUsuario) { Id = idUsuario };
            };
        }
    }
}
