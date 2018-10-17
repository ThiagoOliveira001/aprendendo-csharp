using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    class Simulador : Tributo
    {
        public Simulador()
        {
                
        }

        public double calculaTributo(double porcentagem, double valor)
        {
            return  (porcentagem / 100) * valor;
        }

        public double calculaInvestimentoTesouro(double valor, int meses)
        { 
            for (int i = 0; i < meses; i++)
            {
                valor += valor * 0.02;
            }
            valor -= calculaTributo(2,valor);
            return valor;
        }

        public double calculaInvestimentoBolsa(double valor, double[] ultimosMeses)
        {
            double acm = 0;
            foreach (double vl in ultimosMeses)
            {
                acm += vl;
            }
            if (acm < 0)
            {
                valor -= valor * ((acm / ultimosMeses.Length) / 100);
            }
            else
            {
                valor += valor * ((acm / ultimosMeses.Length) / 100);
            }
            valor -= calculaTributo(5, valor);
            return valor;
        }

        public double calculaInvestimentoBolsa(double valor, double expectativa)
        {
            valor += valor * (expectativa / 100);
            valor -= calculaTributo(5,valor);
            return valor;
        }
    }
}
