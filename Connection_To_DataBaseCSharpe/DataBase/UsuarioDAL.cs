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
    internal class UsuarioDAL: DAL<Usuarios>
    {
        public UsuarioDAL(GerenciadorContext context) : base(context) { }
 
        //--------------------------------------------------------------------------------------------------------------------\\
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
