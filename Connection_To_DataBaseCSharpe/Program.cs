
using Connection_To_DataBaseCSharpe.DataBase;
using Connection_To_DataBaseCSharpe.Models;

try
{
    using var connection = new Connection().ObterConexao();
    connection.Open();
    Console.WriteLine(connection.State);
}
catch(Exception ex)
{

    Console.WriteLine(ex.Message);
}
Usuario user = new Usuario("Roberto Carlos", 78, "Rua Florestino Gaviões, 78 , Florianopolis-PE");

user.Menu();

