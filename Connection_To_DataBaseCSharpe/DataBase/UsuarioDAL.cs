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
        //Classe padrão de boas práticas para métodos que gerenciam o banco de dados.
        //Basicamente, o DAL representa a estrutura de acesso aos dados, independente do tipo de banco utilizado,
        //e o DAO é o objeto que representa o acesso a uma fonte de dados específica.
        //--------------------------------------------------------------------------------------------------------------\\
        /*       public void AdicionarUsuario()
               {

                   //Pegamos os dados dos usuarios:
                   Console.Clear();
                   Console.WriteLine("## ADICIONAR USUÁRIO ##");
                   Console.WriteLine("\n");

                   Console.WriteLine("Digite o Nome: ");
                   string nome = Console.ReadLine();

                   //correção do erro de conversão de idade string para int:

                   Console.WriteLine("\nDigite a Idade: ");
                   string idade = Console.ReadLine();

                   Console.WriteLine("\n");
                   Console.WriteLine("Digite o endereço");
                   string endereço = Console.ReadLine();

                   Usuario usuario01 = new Usuario(0, nome, idade, endereço);
                   //------Adicionar Usuario ao DataBase------------------
                   try
                   {
                       //agora precisamos dar um jeito de adicionar o usuario solicitado no método em nosso connection.
                       var connection = new UserContext();

                       using var connectionObter = connection.ObterConexao();
                       connectionObter.Open();
                       // a funçãp do @, declarar uma variável
                       string query = "INSERT INTO Usuarios (Nome, Idade, Endereço) VALUES (@Nome, @Idade, @Endereço)";
                       SqlCommand command = new SqlCommand(query, connectionObter);

                       // dizemos para qual coluna da tabela (Nome = "@Nome") queremos adicionar o  usuario01.Nome
                       command.Parameters.AddWithValue("@Nome", usuario01.Nome); // funciona como: var @Nome = usuario.Nome;
                       command.Parameters.AddWithValue("@Idade", usuario01.Idade);
                       command.Parameters.AddWithValue("@Endereço", usuario01.Endereço);

                       //aqui recebemos a quantidade de linhas que foram adicionados na tabela.
                       int retorno = command.ExecuteNonQuery();
                       Console.WriteLine("\n");
                       Console.WriteLine($"Quantidade linhas afetadas da Tabela: {retorno}Linha(s) Table - DataBase.");

                       command.ExecuteNonQuery();
                   }

                   catch (Exception ex)
                   {
                       Console.WriteLine(ex.Message);
                   }

                   //--------------------------------------------------
                   Thread.Sleep(3000);
                   Console.WriteLine("Dados do usuario adicionado com Sucesso! Aguarde até que volte para o Menu.");

                   Thread.Sleep(10000);
                   new Menu().Menu_();

               } */

        //--------------------------------------------------------------------------------------------------------------\\

        //#########################     M E T O D O S    C O M    E N T I T Y  F R A M E W O R K   C O R E       #################################
        public IEnumerable<Usuarios> ListarUsuarios()
        {
            using var context = new UserContext();

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
                using var context = new UserContext();

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
            new Menu().Menu_();

        }   

        public void AtualizarUsuario()
        {
            Console.Clear();
            Console.WriteLine("## ATUALIZAR USUARIO ##");
            using var context = new UserContext();

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
            new Menu().Menu_();

        }

        public void RemoverUsuario()
        {
            Console.Clear();
            Console.WriteLine("## REMOVER USUARIO ##");
            using var context = new UserContext();

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
            new Menu().Menu_();

        }
        //--------------------------------------------------------------------------------------------------------------\\

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
