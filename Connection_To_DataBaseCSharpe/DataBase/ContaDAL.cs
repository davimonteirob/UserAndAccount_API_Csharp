using Connection_To_DataBaseCSharpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.DataBase
{ // a utilidade do generics se dá quando entedemos que estamos com duas classes DAL com os mesmos códigos, mesmos métodos
  //se quisermos otimizar isso precisaremos da utilização do generics, genericsDAL
    internal class ContaDAL:DAL<Contas>
    {
        //no nosso construtor do contaDAL, vai receber o contexto da classe DAL, usamos a :base que representa a superclasse (DAL) e dizemos
        //que pegaremos o contexto de lá.
        public ContaDAL(GerenciadorContext context) : base(context) { }
    }
}
