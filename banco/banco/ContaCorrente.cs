using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class ContaCorrente : Conta
    {
        public double taxa { get; private set; } = 2;

        public ContaCorrente(int numero, double saldo,Cliente titular) :base(numero,saldo,titular)
        {
            this.Info = "Conta Corrente";
        }

        public override void depositar(double valor)
        {
            this.Saldo += valor;
        }

        public override void sacar(double valor)
        {
            this.Saldo -= this.taxa;
            this.Saldo -= valor;
        }

    }
}
