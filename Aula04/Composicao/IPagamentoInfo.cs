using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao
{
    interface IPagamentoInfo
    {
        DateTime DataVencimento { get; set; }
        DateTime DataEmissao { get; set; }
        DateTime DataPagamento { get; set; }
        double ValorPago { get; set; }

        
    }
}
