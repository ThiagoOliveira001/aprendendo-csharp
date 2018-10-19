using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class CartaoCredito : Cartao
    {
        public int Limite { get; private set; }
        public double Debito { get; private set; } = 0;

        public CartaoCredito(int numero,Conta contaVinculada, int limite) : base(numero,contaVinculada)
        {
            this.Limite = limite;
        }
     
        public override bool comprar(double valor)
        {
            if (this.Limite >= (this.Debito + valor))
            {
                this.Debito += valor;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
