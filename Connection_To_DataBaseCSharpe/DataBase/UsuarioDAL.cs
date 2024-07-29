using Connection_To_DataBaseCSharpe.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.DataBase
{
    internal class UsuarioDAL
    {
        //#########################     M É T O D O S    C O M    E N T I T Y  F R A M E W O R K   C O R E     #################################

        // para evitar de ficar repetindo o mesmo código como: var context = new UserContext() ... Podemos criar um campo para todos 
        //os métodos e assim estabelecer uma conexão sempre que chamar o método do objeto UsuarioDAL "EF".

        //criamos o campo e depois adicionamos no construtor do UsuarioDAL
        private readonly UserContext context;
        //adicionando no construtor.
        public UsuarioDAL(UserContext context)
        {
            this.context = context;
        }
        //pronto, não precisamos mais criar conexão do context em cada método, pois criamos um campo para isso em nossa classe.
               
        public IEnumerable<Usuarios> ListarUsuarios()
        {
  //          using var context = new UserContext();  << nao precisamos mais

            //informamos o que iremos fazer com o Usuarios digitando o "." Assim podemos dizer o que queremos retornar com a Tabela Usuarios.
            return context.Usuarios.ToList(); //estamos retornando da Tabela de Usuarios uma lista.

            //Where(x=> x.IdUsuario == 2) << podemos usar esse Where para filtrar o que queremos mostrar, (id usuario deve ser igual a 2)
        }

        public void AdicionarUsuario()
        {
            Console.Clear();
            Console.WriteLine("## ADICIONAR USUARIO ##");
            Console.WriteLine("\n");
            //queremos instanciar a nossa UserContext(),
            try
            {

                Console.WriteLine("Digite seu Nome");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite sua Idade");
                string idade = Console.ReadLine();
                Console.WriteLine("Digite seu Endereço");
                string endereço = Console.ReadLine();

                Usuarios novoUsuario = new Usuarios(nome, idade, endereço);

                context.Usuarios.Add(novoUsuario);
                context.SaveChanges(); //salvar as mudanças no banco de dados.

                Console.WriteLine("\n");
                Console.WriteLine("Usuario Adicionado!");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(10000);
            new MenuUser().Menu_();

        }   

        public void AtualizarUsuario()
        {
            Console.Clear();
            Console.WriteLine("## ATUALIZAR USUARIO ##");

            Console.WriteLine("Digite o Id do usuario que deseja atualizar:");
            int idUsuario = Convert.ToInt32(Console.ReadLine());

            var usuario_ = context.Usuarios.Find(idUsuario); // para encontrar o id do usuario e armazenar na variável

            if (usuario_ == null)
            {
                Console.WriteLine("Usuario não encontrado");
            }
            else
            {
                Console.WriteLine("Digite o nome que deseja atualizar");
                string novoNome = Console.ReadLine();

                usuario_.Nome = novoNome;

                context.SaveChanges();

                Console.WriteLine("\n");
                Console.WriteLine("Nome adicionado");
            }

            Thread.Sleep(10000);
            new MenuUser().Menu_();

        }

        public void RemoverUsuario()
        {
            Console.Clear();
            Console.WriteLine("## REMOVER USUARIO ##");

            Console.WriteLine("Digite o Id do usuario que deseja remover");
            int id = Convert.ToInt32(Console.ReadLine());
            var usuario = context.Usuarios.Find(id);
            Console.WriteLine("\n");

            if (usuario == null) 
            {
                Console.WriteLine("Usuario não encontrado");
            }
            else
            {
                context.Remove(usuario);
                context.SaveChanges();

                Console.WriteLine("Usuario removido com sucesso!");
            }

            Thread.Sleep(10000);
            new MenuUser().Menu_();

        }


        //--------------------------------------------------------------------------------------------------------------\\
        // USANDO CONEXÃO ADO.NET
        /*   public void AtualizarUsuario()
           {
               //obter a conexão

               Console.Clear();
               Console.WriteLine("## ATUALIZAR DADOS DE USUARIO ##");
               //Buscar os dados que queremos atualizar:
               Console.WriteLine("\n");
               Console.WriteLine("Digite o ID do usuario que deseja atualizar: ");
               int NomeParaAtt = Convert.ToInt32(Console.ReadLine());
               int usuarioID = NomeParaAtt;
               Console.WriteLine("Nova Idade para atualizar: ");
               string novaIdade = Console.ReadLine();
               Console.WriteLine($"Digite o Nome para atualizar: ");
               string novoNome = Console.ReadLine();
               Console.WriteLine("Novo Endereço para atualizar: ");
               string novoEndereco = Console.ReadLine();



               try
               {
                   var connection = new UserContext().ObterConexao();
                   connection.Open();

                   //definir o script do banco de dados
                   string sql = "UPDATE Usuarios SET Nome = @NomeAtt, Idade = @IdadeAtt, Endereço = @EnderecoAtt  WHERE IDUsuario = @IdUsuario";

                   //passar os dados de conexão e o script de comando no Objeto SqlCommand do ADO.NET
                   SqlCommand command = new SqlCommand(sql, connection);
                   command.Parameters.AddWithValue("@IdUsuario", usuarioID);
                   command.Parameters.AddWithValue("@NomeAtt", novoNome);
                   command.Parameters.AddWithValue("@IdadeAtt", novaIdade);
                   command.Parameters.AddWithValue("@EnderecoAtt", novoEndereco);

                   command.ExecuteNonQuery();
               }
               catch(Exception ex) 
               {
                   Console.WriteLine(ex.Message);
               }


               Console.WriteLine("\n");
               Console.WriteLine("Usuario Atualizado! Aguarde, logo retornaremos para o Menu principal");
               Thread.Sleep(18000);

               new Menu().Menu_();


           }
           //--------------------------------------------------------------------------------------------------------------\\

           public void DeletarUsuario()
           {
               Console.Clear();
               Console.WriteLine("## DELETAR USUARIO POR ID ##");
               Console.WriteLine("\n");
               Console.WriteLine("Digite o ID do Usuario que deseja deletar");

               try
               {
                   var connection = new UserContext().ObterConexao();// chamar nosso método obter conexão
                   connection.Open(); //para abrir nossa conexão

                   string sql = "DELETE FROM Usuarios WHERE IDUsuario = @IdUsuario";

                   Console.WriteLine("Digite o Id do Usuário: ");
                   int IdUsuario = Convert.ToInt32(Console.ReadLine());

                   SqlCommand command = new SqlCommand(sql,connection);// aqui passaremos os comandos do nosso database mais a conexão com o banco específico que estamos working
                   command.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                   // LEMBRE-SE, O ExecuteNonQuery() dá um retorno de linhas afetadas. armazene elas em uma variável para utilizá-las.
                   int retorno = command.ExecuteNonQuery();

                   Console.WriteLine();
                   Console.WriteLine($" Linhas afetadas com essa execução: {retorno}Linha(s).");
                   Console.WriteLine();


               }

               catch (Exception ex) 
               {
                   Console.WriteLine(ex.Message);
               }

               Console.WriteLine("\n");
               Console.WriteLine("Usuario Deletado com sucesso!");
               Thread.Sleep(10000);
               new Menu().Menu_();
           }

           //--------------------------------------------------------------------------------------------------------------\\
      */
    }
} 
