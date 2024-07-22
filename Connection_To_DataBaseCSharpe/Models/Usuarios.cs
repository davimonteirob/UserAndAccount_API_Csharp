using Connection_To_DataBaseCSharpe.DataBase;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.Models
{
    public class Usuarios
    {
        public int IDUsuario { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Endereço { get; set; }
                   
    }
}
