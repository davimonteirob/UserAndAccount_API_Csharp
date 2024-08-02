using Connection_To_DataBaseCSharpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.DataBase
{ //criamos uma classe abstrata pois nao queremos criar nenhum objeto a partir da classe DAL
    // O 'T' serve para dizermos que nossos métodos terão como retorno qualquer tipo. um tipo que será definido quando sobrescrito.
    internal abstract class DAL<T> where T : class //dizemos que os nossos métodos usarão o T do tipo classe. Assim podemos dizer
        //que listar será usado uma classe para definir o banco do tipo classe que será manipulado no context.classe
    {
        //DAL representa a nossa classe genericsDAL // métodos abstratos serve quando não queremos implementá-los aqui, mas em outra classe.

        private readonly GerenciadorContext context;

        protected DAL(GerenciadorContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar() 
        {
            // aqui queremos uma banco de dados genérico dps do context. Usamos o set<T>() para isso, pois dizemos que o tipo é genérico
            return context.Set<T>().ToList();
        } //também não é necessário as chaves de código quando é um método abstrato.
        public void Adicionar(T objeto) // aqui entra como parâmetro dados do tipo 'T' (classe nesse contexto)
        {
            context.Set<T>().Add(objeto); // aqui deve entrar um objeto instanciado do tipo correspondente a tabela do Db (Conta ou Usuario).
            context.SaveChanges();
        }
        public void  Atualizar(T objeto) 
        {
            context.Set<T>().Update(objeto); // aqui vc coloca a entidade modificada em Update. Lembre-se: modifique o objeto antes.
            context.SaveChanges();         
        }
        public void Remover(int id) 
        {
            // no set dizemos que o tipo que iremos usar é definido como uma
            // classe ( T ) que pode ser tanto Conta (representada como nossa tabela do Db no Entity) ou Usuario.
            var conta = context.Set<T>().Find(id);
            context.Set<T>().Remove(conta);
            context.SaveChanges();
        }

         // aqui temos um tipo que é uma função que nos permite fazer uma verificação.
         //Assim podemos criar uma condição antes de recuperarmos qualquer dados no Db, permitindo assim recuperar apenas o que 
         //foi satisfeito pela nossa condição.
        public T RecuperarPor(Func<T,bool> condicao) 
        {
            //queremos recuperar uma coluna do Db por um dado, seja nome, Id, saldo.. etc. 
            return context.Set<T>().FirstOrDefault(condicao);
        }


    }
}
