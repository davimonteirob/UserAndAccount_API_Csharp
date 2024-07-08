using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.DataBase
{
    internal class Connection
    {
        private string connectionString = "Data Source=DESKTOP-KNM3SP8;Initial Catalog=ConnectionToDataBaseCSharp;User ID=sa;Password=********;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //a função para usar o o link string para conectar o projeto com o banco de dados
        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}
