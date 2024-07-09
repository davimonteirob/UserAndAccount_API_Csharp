
using Connection_To_DataBaseCSharpe.DataBase;
using Connection_To_DataBaseCSharpe.Models;

try
{
    //inserimos a instrução using pois podemos gerenciar os recursos de conexão
    using var connection = new Connection().ObterConexao();
    connection.Open();
    Console.WriteLine(connection.State);//uma verificação do status da nossa conexão, ele retorna o estado da nossa conexão
}
//se der algo errado, e não realizar a nossa conexão, exibiremos uma mensagem:
catch(Exception ex)
{

    Console.WriteLine(ex.Message);
}
//como não queremos ficar executando o menu toda hora enquanto testamos nossa conexão, iremos colocar um return depois do catch
// para que o programa execute até esta parte e pare a execução quando chegar no return;
return;

Usuario user = new Usuario("Roberto Carlos", 78, "Rua Florestino Gaviões, 78 , Florianopolis-PE");

user.Menu();

