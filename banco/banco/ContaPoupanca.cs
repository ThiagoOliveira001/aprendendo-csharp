using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class ContaPoupanca : Conta
    {

        public ContaPoupanca(int numero, double saldo,Cliente titular) :base(numero,saldo,titular)
        {
            this.Info = "Conta Poupanca";
        }

        public override void depositar(double valor)
        {
            this.Saldo += valor;
        }

        public override void sacar(double valor)
        {
            this.Saldo -= valor;
        }
        
    }
}
