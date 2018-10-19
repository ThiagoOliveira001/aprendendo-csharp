using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    abstract class Conta
    {
        public int Numero { get; protected set; }
        public double Saldo { get; protected set; }
        public Cliente Titular { get; protected set; }
        public string Info { get; protected set; }

        public Conta(int numero, double saldo, Cliente titular)
        {
            this.Numero = numero;
            this.Saldo = saldo;
            this.Titular = titular;
        }

        public virtual void depositar(double valor)
        {
            this.Saldo += valor;
        }

        public abstract bool sacar(double valor);
    }
}
