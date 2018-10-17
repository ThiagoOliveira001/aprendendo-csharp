using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apostilaCaelum6._9
{
     public class Conta
     {
        private int numero;
        public int Numero
        {
            get
            {
                return this.numero;
            }
            set
            {
                if (value > 0)
                {
                    this.numero = value;
                }
            }
        }
        private Cliente titular;
        public Cliente Titular
        {
            get
            {
                return this.titular;
            }
            set
            {
                this.titular = value;
            }
        }
        public double Saldo { get; private set; }

        public Conta(Cliente titular, int numero, double saldo = 100)
        {
            this.titular = titular;
            this.numero = numero;
            this.Saldo = saldo;
        }

        public bool saca(double valor)
        {
            if (this.Saldo >= valor)
            {
                this.Saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void depositar(double valor)
        {
            this.Saldo += valor;
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
