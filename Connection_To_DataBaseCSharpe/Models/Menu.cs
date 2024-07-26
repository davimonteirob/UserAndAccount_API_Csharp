using Connection_To_DataBaseCSharpe.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.Models
{
    internal class Menu
    {
        public void Menu_()
        {
            Console.Clear();
            Console.WriteLine("##  M E N U  ## ");
            Console.WriteLine("\n");
            Console.WriteLine("# Digite 1 para Adicionar um Usuário");
            Console.WriteLine("# Digite 2 para Exibir os Usuários");
            Console.WriteLine("# Digite 3 para Atualizar o Usuário");
            Console.WriteLine("# Digite 4 para Deletar um Usuário");
            Console.WriteLine("# Digite 0 para sair");
            int opçãoSelecionada = Convert.ToInt32(Console.ReadLine());

            switch (opçãoSelecionada)
            {
                case 1:
                    //INSTANCIAMOS e logo chamamos o método: usamos o new para isso.
                    new UsuarioDAL().AdicionarUsuario();
                    break;
                case 2:

                    Console.Clear();
                    try
                    {
                        var usuario01 = new UsuarioDAL().ListarUsuarios();
                        Console.WriteLine("## USUARIOS ##");
                        Console.WriteLine("\n");
                        foreach (var item in usuario01)
                        {
                            Console.WriteLine($"Id: {item.IdUsuario}. Nome: {item.Nome}. Idade: {item.Idade}. Endereço: {item.Endereço}.");
                            Console.WriteLine(" - ");
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
                    new UsuarioDAL().AtualizarUsuario();
                    break;
                case 4:
                    new UsuarioDAL().RemoverUsuario();
                    break;

                case 0: break;
            }
        }
    }
}
