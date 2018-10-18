using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class CartaoDebito : Cartao
    {
        public CartaoDebito(int numero,Conta contaVinculada) : base(numero, contaVinculada)
        {

        }
    }
}
