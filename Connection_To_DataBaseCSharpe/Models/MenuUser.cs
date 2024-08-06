using Connection_To_DataBaseCSharpe.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Connection_To_DataBaseCSharpe.Models
{
    internal class MenuUser
    {
        public void Menu_()
        {
            Console.Clear();
            Console.WriteLine("##  M E N U   U S U A R I O S  ## ");
            Console.WriteLine("\n");
            Console.WriteLine("# Digite 1 para Adicionar um Usuário");
            Console.WriteLine("# Digite 2 para Exibir os Usuários");
            Console.WriteLine("# Digite 3 para Atualizar o Usuário");
            Console.WriteLine("# Digite 4 para Deletar um Usuário");
            Console.WriteLine("# Digite 5 para Recuperar um Usuário");
            Console.WriteLine("# Digite 6 para entrar no Menu de Contas");
            Console.WriteLine("# Digite 0 para sair");
            int opçãoSelecionada = Convert.ToInt32(Console.ReadLine());

            switch (opçãoSelecionada)
            {// passe o parâmetro do construto para a Classe UsuarioDAL
                case 1:
                    Console.Clear();
                    Console.WriteLine("## ADICIONAR CONTA ##");
                    Console.WriteLine();
                    Console.WriteLine("# Digite o Nome do Titular da conta");
                    string nome = Console.ReadLine();
                    Console.WriteLine("# Digite o Número da conta");
                    string idade = Console.ReadLine();
                    Console.WriteLine("# Digite o saldo da conta");
                    string endereco = Console.ReadLine();

                    var novoUsuario = new Usuarios(nome,idade, endereco);
                    new DAL(new GerenciadorContext()).Adicionar(novoUsuario);

                    Console.WriteLine("Conta adicionada!..");
                    Thread.Sleep(18000);
                    Menu_();

                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("## LISTA DE USUARIOS ##");
                    Console.WriteLine();
                    try
                    {
                        var info = new UsuarioDAL(new GerenciadorContext()).Listar();

                        foreach (var item in info)
                        {
                            Console.WriteLine($" {item.Nome}, {item.Endereço},{item.Idade}, Id: {item.IdUsuario}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Thread.Sleep(18000);
                    Menu_();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("## ATUALIZAR CONTAS ##");
                    Console.WriteLine();

                    Console.WriteLine("Digite o nome do titular da conta");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite o numero da conta");
                    idade = Console.ReadLine();
                    Console.WriteLine("Digite o Saldo da conta");
                    endereco = Console.ReadLine();

                    var contaAtualizada = new Usuarios(nome, idade, endereco);

                    new UsuarioDAL(new GerenciadorContext()).Atualizar(contaAtualizada);
                    Menu_();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("## REMOVER USUARIO ##");
                    Console.WriteLine();

                    Console.WriteLine("Digite o Id dO que deseja remover");
                    int id = Convert.ToInt32(Console.ReadLine());

                    if (id != null)
                    {
                        new UsuarioDAL(new GerenciadorContext()).Remover(id);
                    }else
                    {
                        Console.WriteLine("Id não encontrado");
                    }

                    Console.WriteLine();
                    Console.WriteLine(" Usuario removido!");
                    Thread.Sleep(10000);
                    Menu_();


                    break;
                case 5:
                    
                    break;
                case 6:
                    new MenuConta().Menu();
                    break;

                case 0: break;
            }
        }
    }
}
