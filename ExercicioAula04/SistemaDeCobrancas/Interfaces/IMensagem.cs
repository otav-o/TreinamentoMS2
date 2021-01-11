using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    interface IMensagem
    {
        /// <summary>
        /// Pessoa que envia a mensagem
        /// </summary>
        public Pessoa Remetente { get; set; }

        /// <summary>
        /// Pessoa que recebe a mensagem
        /// </summary>
        public Pessoa Destinatario { get; set; }

        /// <summary>
        /// Endereço do destinatário da mensagem
        /// </summary>
        public EnderecoModelo EnderecoDestino { get; set; }

        public string MensagemGerada { get; }

    }
} // no final, essa interface tornou-se inútil
