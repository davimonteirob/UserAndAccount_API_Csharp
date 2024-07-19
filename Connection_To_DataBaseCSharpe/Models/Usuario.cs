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
        public Usuario(int id, string nome, string idade, string endereço)
        {
            IDUsuario = id;
            Nome = nome;
            Idade = idade;
            Endereço = endereço;
        }
        public int IDUsuario { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Endereço { get; set; }
                   
    }
}
