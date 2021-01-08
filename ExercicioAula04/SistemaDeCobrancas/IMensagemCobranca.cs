﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    interface IMensagemCobranca
    {
        /// <summary>
        /// Pessoa que envia a mensagem
        /// </summary>
        public Pessoa Remetente { get; set; }

        /// <summary>
        /// Pessoa que recebe a mensagem
        /// </summary>
        public Pessoa Destinatario { get; set; }

        public double ValorCobranca { get; set; }

        /// <summary>
        /// Endereço do destinatário da mensagem
        /// </summary>
        public EnderecoModelo EnderecoDestino { get; set; }


    }
}
