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
           base.depositar(this.Saldo * 0.005);
        }

        public override bool sacar(double valor)
        {
            if (this.Saldo < valor) return false;
            this.Saldo -= valor;
            return true;
        }
        
    }
}
