using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    abstract class Conta
    {
        protected int numero;
        protected double saldo;

        public Conta(int numero, double saldo)
        {
            this.numero = numero;
            this.saldo = saldo;
        }

        public abstract void depositar(double valor);

        public abstract void sacar(double valor);

        public abstract double getSaldo();
    }
}
