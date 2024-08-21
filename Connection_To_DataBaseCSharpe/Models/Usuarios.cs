using Connection_To_DataBaseCSharpe.DataBase;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.Models
{
    public class Usuarios
    {
        public Usuarios(string nome, string idade, string endereço) 
        {
            Nome = nome;
            Idade = idade;
            Endereço = endereço;
        }
        //Chave primária identificada como 'Id' no Entity

        //quando criamos uma primary key aqui, não precisamos repetir para o sql server a mesma definição.
        [Key]//indica que esta propriedade "IdUsuario" é uma chave primária.
        public int IdUsuario { get; set; }

        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Endereço { get; set; }

        public  virtual ICollection<Contas> Contas { get; set; }

    }
}
