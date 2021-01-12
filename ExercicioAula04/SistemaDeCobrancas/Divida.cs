using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    class Divida
    {
        /// <summary>
        /// Beneficiário - a quem se deve
        /// </summary>
        public Pessoa Credor { get; set; }
        public Pessoa Devedor { get; set; }
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }

        public Divida(Pessoa credor, Pessoa devedor, double valor, DateTime vencimento)
        {
            Credor = credor;
            Devedor = devedor;
            Valor = valor;
            Vencimento = vencimento;
        }
    }
}
