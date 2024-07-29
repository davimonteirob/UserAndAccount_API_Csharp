using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.Models
{
    internal class Contas
    {
        public Contas(string titular, int numero, decimal saldo) 
        {
            Titular = titular;
            Numero = numero;
            Saldo = saldo;
        }

        [Key]
        public int Id { get; set; }
        public string Titular { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
    }
}
