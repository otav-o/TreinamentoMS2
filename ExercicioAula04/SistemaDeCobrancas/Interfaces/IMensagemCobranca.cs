using SistemaDeCobrancas.Classes_de_mensagens;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    interface IMensagemCobranca
    {
        /// <summary>
        /// Valor da dívida
        /// </summary>
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        /// <summary>
        /// Possui informações do remetente, destinatário e endereço de destino
        /// </summary>
        public Etiqueta Cabecalho { get; set; }


    }
}
