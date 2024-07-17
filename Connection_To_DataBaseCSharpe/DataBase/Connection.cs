using Connection_To_DataBaseCSharpe.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//      ###   CONEXÃO ADO.NET:   ###
//O ADO.NET é um conjunto de classes que permitem acesso a dados nas aplicações .NET.
// Através dele é possível acessar dados de maneira consistente e ainda fazer a separação e a manipulação dos dados.
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

    }
}
