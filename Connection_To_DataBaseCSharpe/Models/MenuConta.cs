using Connection_To_DataBaseCSharpe.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.Models
{
    internal class MenuConta
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("##  M E N U   C O N T A S  ## ");
            Console.WriteLine("\n");
            Console.WriteLine("# Digite 1 para Adicionar uma Conta");
            Console.WriteLine("# Digite 2 para Exibir as Contas");
            Console.WriteLine("# Digite 3 para Atualizar a Conta");
            Console.WriteLine("# Digite 4 para Deletar uma Conta");
            Console.WriteLine("# Digite 5 para Recuperar uma Conta");
            Console.WriteLine("# Digite 6 para Voltar ao Menu de Usuarios");
            Console.WriteLine("# Digite 0 para sair");
            int opçãoSelecionada = Convert.ToInt32(Console.ReadLine());

            switch (opçãoSelecionada)
            {
                case 1:
                 
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("## LISTAR CONTAS ##");
                    Console.WriteLine();
                    try
                    {
                        
                        var info = new DAL<Contas>(new GerenciadorContext()).Listar();

                        foreach (var item in info) 
                        {
                            Console.WriteLine($" {item.Nome}, {item.Numero}, Id: {item.IdConta}");
                        }
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Thread.Sleep(10000);
                    new MenuConta().Menu();


                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("## ATUALIZAR CONTAS ##");
                    Console.WriteLine();

                    Console.WriteLine("Digite o nome do titular da conta");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite o numero da conta");
                    int numero = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o Saldo da conta");
                    decimal saldo = Convert.ToDecimal(Console.ReadLine());

                    var contaAtualizada = new Contas(nome,numero,saldo);
                    new DAL<Contas>(new GerenciadorContext()).Atualizar(contaAtualizada);

                    Thread.Sleep(10000);
                    new MenuConta().Menu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("## REMOVER CONTA ##");
                    Console.WriteLine();

                    Console.WriteLine("Digite o Id da conta que deseja remover");
                    int id =  Convert.ToInt32(Console.ReadLine());

                    if (id != null)
                    {
                        new DAL<Contas>(new GerenciadorContext()).Remover(id);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Conta removida!");
                    Thread.Sleep(10000);
                    new MenuConta().Menu();
                    break;
                case 5:
                    break;
                case 6:
                    new MenuUser(new GerenciadorContext()).Menu_();
                    break;

                case 0: break;
            }
        }
    }
}
