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
        public Pessoa Credor { get; }
        public Pessoa Devedor { get; }
        public DateTime Vencimento { get; }
        public double Valor { get; }

        public Divida(Pessoa credor, Pessoa devedor, double valor, DateTime vencimento)
        {
            Credor = credor;
            Devedor = devedor;
            Valor = valor;
            Vencimento = vencimento;
        }
    }
}
