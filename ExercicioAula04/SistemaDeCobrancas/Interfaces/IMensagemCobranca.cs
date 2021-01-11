using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    interface IMensagemCobranca : IMensagem
    {
        /// <summary>
        /// Valor da dívida
        /// </summary>
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}
