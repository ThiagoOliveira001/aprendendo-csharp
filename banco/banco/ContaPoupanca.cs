using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class ContaPoupanca : Conta
    {
        public ContaPoupanca(int numero, double saldo) :base(numero,saldo)
        {
        }

        public override void depositar(double valor)
        {
            this.saldo += valor;
        }

        public override void sacar(double valor)
        {
            this.saldo -= valor;
        }
        
    }
}
