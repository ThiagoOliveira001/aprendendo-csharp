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

        public override bool sacar(double valor)
        {
            if (this.Saldo < valor) return false;
            this.Saldo -= this.taxa;
            this.Saldo -= valor;
            return true;
        }

    }
}
