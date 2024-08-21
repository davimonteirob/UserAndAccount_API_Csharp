using Connection_To_DataBaseCSharpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.DataBase
{
    internal class DAL<T> where T : class
    {

        private readonly GerenciadorContext context;

        public DAL(GerenciadorContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar() 
        {
            var dbSet = context.Set<T>();
            if (dbSet == null)
            {
                throw new InvalidOperationException("O DbSet é nulo");
            }
            return dbSet.ToList();
        }
        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }
        public void  Atualizar(T objeto) 
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();         
        }
        public void Remover(int id)
        {
            var conta = context.Set<T>().Find(id);
            context.Set<T>().Remove(conta);
            context.SaveChanges();
        }
        public T RecuperarPor(Func<T,bool> condicao) 
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }

        //criar um método genérico que exiba o relacionamento entre Usuarios e Contas
        


    }
}
