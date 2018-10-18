using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    abstract class Cartao
    {
        public int Numero { get; protected set; }
        public Conta ContaVinculada { get; protected set; }

        public Cartao(int numero, Conta contaVinculada)
        {
            this.Numero = numero;
            this.ContaVinculada = contaVinculada;
        }
        
        public virtual bool comprar(double valor)
        {
            if (this.ContaVinculada.Saldo >= valor)
            {
                this.ContaVinculada.sacar(valor);
                return true;
            }
            else
            {
                return false;
            }
                    
        }
    }
}
