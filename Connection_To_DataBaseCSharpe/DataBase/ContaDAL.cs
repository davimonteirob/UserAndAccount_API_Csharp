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

        public IEnumerable<Contas> InformacoesConta()
        {
                var informacoesConta = context.Contas.ToList();

            return informacoesConta;

        }

        public void AdicionarConta()
        {
            Console.Clear();
            Console.WriteLine("## ADICIONAR CONTA ##");
            Console.WriteLine();
            Console.WriteLine("Digite o Titular da Conta");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o Numero da Conta");
            int numeroC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o Saldo");
            decimal saldo = Convert.ToDecimal(Console.ReadLine());
            var novaConta = new Contas(nome,numeroC,saldo);

            try
            {
                context.Contas.Add(novaConta);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine();
            Console.WriteLine("Conta adicionada!");

            Thread.Sleep(15000);
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
            Console.Clear();
            try
            {
                string nome = "Clodovil";
                var nomeDb = context.Contas.Find(nome);

                context.Contas.Remove(nomeDb);
                context.SaveChanges();
                Console.WriteLine("removida com sucesso!");

            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
