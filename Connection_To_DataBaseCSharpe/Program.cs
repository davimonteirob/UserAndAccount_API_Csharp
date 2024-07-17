
using Connection_To_DataBaseCSharpe.DataBase;
using Connection_To_DataBaseCSharpe.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Usuario user = new Usuario("Roberto Carlos", "78", "Rua Florestino Gaviões, 78 , Florianopolis-PE");

        // OBS: agr que ja estabelecemos a nossa conexão no próprio método, não precisamos mais colocá-la aqui.
        // assim conectamos o nosso projeto com o banco de dados, usando o adonet, idbConnection e SqlConnection
        //try
        //{
        //A instrução using tem como objetivo principal garantir que objetos descartáveis sejam utilizados corretamente.
        //inserimos a instrução using pois podemos gerenciar os recursos de conexão
        //Neste exemplo utilizado no curso, a variável connection foi declarada como using,
        //portanto, será descartada ao finalizar a execução do try.
        //Com isso conseguimos aplicar uma boa prática e gerenciar melhor os recursos que estão sendo utilizados
        //e mantê-los somente quando estiverem sendo utilizados.
        //    using var connection = new Connection().ObterConexao();
        //    connection.Open();
        //    Console.WriteLine(connection.State);//uma verificação do status da nossa conexão, ele retorna o estado da nossa conexão
        //}
        //se der algo errado, e não realizar a nossa conexão, exibiremos uma mensagem:
        //catch(Exception ex)
        //{

        //    Console.WriteLine(ex.Message);
        //}
        //como não queremos ficar executando o menu toda hora enquanto testamos nossa conexão, iremos colocar um return depois do catch
        // para que o programa execute até esta parte e pare a execução quando chegar no return;
        //return;



        //o que vamos fazer agr é:

 

        Console.WriteLine("\n");
        Console.WriteLine("## Adicionando Usuário ##");
        Console.WriteLine("\n");
       

        user.Menu();
    }
}