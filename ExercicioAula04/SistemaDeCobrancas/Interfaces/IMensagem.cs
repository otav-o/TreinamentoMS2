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
        public Pessoa Remetente { get; }

        /// <summary>
        /// Pessoa que recebe a mensagem
        /// </summary>
        public Pessoa Destinatario { get; }

        /// <summary>
        /// Endereço do destinatário da mensagem
        /// </summary>
        public EnderecoModelo EnderecoDestino { get; }

        public string MensagemGerada { get; }

    }
}
