﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class ContaCorrente : Conta
    {
        public double taxa { get; private set; } = 2;

        public ContaCorrente(int numero, double saldo) :base(numero,saldo)
        {
        }

        public override void depositar(double valor)
        {
            this.saldo += valor;
        }

        public override void sacar(double valor)
        {
            this.saldo -= this.taxa;
            this.saldo -= valor;
        }

        public override double getSaldo()
        {
            return this.saldo;
        }
    }
}
