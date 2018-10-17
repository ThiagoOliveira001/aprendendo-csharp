using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apostilaCaelum6._9
{
    class Conta
    {
        public int numero;
        public Cliente titular;
        public double saldo;

        public Conta(Cliente titular, int numero, double saldo = 100)
        {
            this.titular = titular;
            this.numero = numero;
            this.saldo = saldo;
        }

        public bool saca(double valor)
        {
            if (this.saldo >= valor)
            {
                this.saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void depositar(double valor)
        {
            this.saldo += valor;
        }

        public bool transfere(double valor, Conta destino)
        {
            if (this.saca(valor))
            {
                destino.depositar(valor);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
