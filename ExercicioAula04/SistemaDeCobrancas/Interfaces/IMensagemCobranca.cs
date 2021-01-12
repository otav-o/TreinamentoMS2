using SistemaDeCobrancas.Classes_de_mensagens;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    interface IMensagemCobranca
    {
        /// <summary>
        /// Cabeçalho que contém endereço, remetente e destinatário
        /// </summary>
        public Etiqueta Etiqueta { get; }
        /// <summary>
        /// Valor da dívida
        /// </summary>
        public double Valor { get; }
        public DateTime DataVencimento { get; }

    }
}
