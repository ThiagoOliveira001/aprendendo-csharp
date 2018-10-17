using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
    interface Tributo
    {
        double calculaTributo(double porcentagem, double valor);
    }
}
