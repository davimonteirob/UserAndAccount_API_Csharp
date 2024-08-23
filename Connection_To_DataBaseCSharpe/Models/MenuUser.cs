using Connection_To_DataBaseCSharpe.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Connection_To_DataBaseCSharpe.Models
{
    internal class MenuUser
    {
        private readonly GerenciadorContext _context;

        public MenuUser(GerenciadorContext context)
        {
            this._context = context;
        }
       
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
            Console.WriteLine(" Digite 7 para ver Contas de Usuario");
            Console.WriteLine("# Digite 0 para sair");
            int opçãoSelecionada = Convert.ToInt32(Console.ReadLine());

            switch (opçãoSelecionada)
            {// passe o parâmetro do construto para a Classe UsuarioDAL
                case 1:
                    AdicionarAssociacao();
                    break;
 
                case 2:
                    Console.Clear();
                    Console.WriteLine("## LISTA DE USUARIOS ##");
                    Console.WriteLine();
                    try
                    {
                        var info = new DAL<Usuarios>(new GerenciadorContext()).Listar();

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
                    Console.WriteLine("## ATUALIZAR USUARIO ##");
                    Console.WriteLine();

                    Console.WriteLine("Digite o nome do Usuario");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite a idade");
                    string idade = Console.ReadLine();
                    Console.WriteLine("Digite o endereço");
                    string endereco = Console.ReadLine();

                    var contaAtualizada = new Usuarios(nome, idade, endereco);
                    new DAL<Usuarios>(new GerenciadorContext()).Atualizar(contaAtualizada);

                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("## REMOVER USUARIO ##");
                    Console.WriteLine();

                    Console.WriteLine("Digite o Id dO que deseja remover");
                    int id = Convert.ToInt32(Console.ReadLine());

                    if (id != null)
                    {
                        new DAL<Usuarios>(new GerenciadorContext()).Remover(id);
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
                case 7:
                    Console.Clear();
                    Console.WriteLine("## EXIBIR CONTAS VINCULADA AO USUARIO ##");
                    Console.WriteLine();

                    Console.WriteLine("Digite o Id do Usuario que deseja");
                    int id_ = Convert.ToInt32(Console.ReadLine());

                    new DAL<Usuarios>(new GerenciadorContext()).ExibirContasDeUsuario(id_);

                    Console.WriteLine();
                    Console.WriteLine(" ---------------------------------------------------  ");
                    Thread.Sleep(10000);
                    Menu_();


                    break;

                case 0: break;
            }
        }
        public void AdicionarAssociacao()
        {
            Console.Clear();
            Console.WriteLine("## ADICIONAR USUARIO ##");
            Console.WriteLine();
            Console.WriteLine("# Digite o Nome");
            string nome = Console.ReadLine();
            Console.WriteLine("# Digite a Idade");
            string idade = Console.ReadLine();
            Console.WriteLine("# Digite o EWndereço");
            string endereco = Console.ReadLine();

            var novoUsuario = new Usuarios(nome, idade, endereco);
            new DAL<Usuarios>(new GerenciadorContext()).Adicionar(novoUsuario);

            Console.WriteLine("Usuario Adicionado!..");
            Thread.Sleep(18000);

            Console.Clear();
            Console.WriteLine("## ADICIONAR CONTA ASSOCIADA AO USUARIO CRIADO ##");
            Console.WriteLine();
            Console.WriteLine("# Digite o Nome do Titular da conta");
            string _nome = Console.ReadLine();
            Console.WriteLine("# Digite o Número da conta");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("# Digite o saldo da conta");
            decimal saldo = Convert.ToDecimal(Console.ReadLine());


            try
            {
                var novaConta = new Contas(_nome, numero, saldo) 
                { 
                    IdUsuario = novoUsuario.IdUsuario // Associa a conta ao usuário
                };
                
                _context.Add(novaConta);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Conta adicionada! ");
            Thread.Sleep(10000);
            Menu_();
        }
    }
}
