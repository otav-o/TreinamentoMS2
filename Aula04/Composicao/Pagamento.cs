using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao
{
    class Pagamento : IPagamentoInfo
    {
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public double ValorPago { get; set; }
        public DateTime DataEmissao
        {
            get => DataEmissao;
            set
            {
                if (DataVencimento.Year > 1 && value > DataVencimento)
                    throw new Exception("Data de emissão maior que a data de vencimento.");
                DataEmissao = value;
            }
        }
    }
}
