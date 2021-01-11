using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas.Classes_de_mensagens
{
    class NotaPromissoria : IMensagemCobranca
    {
        public Pessoa Remetente { get; set; }
        public Pessoa Destinatario { get; set; }
        public double ValorCobranca { get; set; }
        public EnderecoModelo EnderecoDestino { get; set; }

        public string MensagemGerada => throw new NotImplementedException();
    }
}
