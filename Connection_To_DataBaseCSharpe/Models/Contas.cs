using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.Models
{
    public class Contas
    {
        public Contas(string nome, int numero, decimal saldo) 
        {
            Nome = nome;
            Numero = numero;
            Saldo = saldo;
        }

        [Key]
        public int IdConta { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; set; }

        public int PIN { get; set; }

        // Chave estrangeira
        public int UsuarioId { get; set; }
        // Propriedade de navegação// Navegação para a entidade Usuario
        public Usuarios Usuarios { get; set; }

        //criamos as propriedades importantes para relação, agora precisamos definir essa relação no DbContext
        //depois precisamos salvar isso criando uma nova migrations e depois atualizando-a para assim manipular a relação com dados.
    }
}
