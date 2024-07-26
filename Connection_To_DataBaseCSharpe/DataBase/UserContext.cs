using Connection_To_DataBaseCSharpe.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    internal class UserContext: DbContext
 // voce também pode consultar em um site confiável um link string de connection confiável que ja funciona,
 // apenas altere as opções importantes como id senha e nome.
         // Confira essas informações do string connection, como nome id e senha:
    {                                      //nome do servidor      Nome do Banco de Dados              Id do servidor e senha

        //Mapear o nome da classe como o nome da tabela através do DbSet.

        public DbSet<Usuarios> Usuarios { get; set; } //nessa propriedade informamos ao entity a tabela Usuarios que queremos consultar.
        //assim, informamos a nossa tabela de Usuarios.

        private string connectionString = "Server=DESKTOP-KM1NEG8;Database=TestConnectionToDataBase;User Id=sa;Password=123456;\r\n";


        //Agora estamos usando entity framework para conectar com o banco de daods, agora estaremos levando a string de conexão para o método
        //herdado da classe DbContext = sinonimo de conexão com banco de dados "Context"
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer(connectionString);
        }



    }
}
