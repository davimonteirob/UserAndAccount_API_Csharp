using Connection_To_DataBaseCSharpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.DataBase
{
    internal class ContaDAL
    {
        private readonly GerenciadorContext context;

        public ContaDAL(GerenciadorContext context) 
        {
            this.context = context;
        }

        public void InformacoesConta()
        {
           
           var informacoesConta =  context.Contas.ToList();

            foreach (var item in informacoesConta) 
            {
                Console.WriteLine($"Id: {item.Id} - Titular da Conta: {item.Titular}. Saldo: {item.Saldo}. Número: {item.Numero}");
                Console.WriteLine(" - ");
            }

        }

        public void AdicionarConta()
        {
            Console.Clear();
            Console.WriteLine("## ADICIONAR CONTA ##");
            Console.WriteLine();
            Console.WriteLine("Digite o Titular da Conta");
            string titular = Console.ReadLine();
            Console.WriteLine("Digite o Numero da Conta");
            int numeroC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o Saldo");
            decimal saldo = Convert.ToDecimal(Console.ReadLine());
            var novaConta = new Contas(titular,numeroC,saldo);

            context.Contas.Add(novaConta);
            context.SaveChanges();

            Console.WriteLine();
            Console.WriteLine("Conta adicionada!");

            Thread.Sleep(1000);
            new MenuConta().Menu();
        }
        
        public void AtualizarConta()
        {
            Console.Clear();
            Console.WriteLine("## ADICIONAR CONTA ##");
            Console.WriteLine();



            Thread.Sleep(1000);
            new MenuConta().Menu();
        }

        public void RemoverConta()
        {

        }

    }
}
