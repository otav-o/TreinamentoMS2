using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas.Classes_de_mensagens
{
    class CartaCobranca : IMensagemCobranca
    {
        public Pessoa Remetente { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Pessoa Destinatario { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double ValorCobranca { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public EnderecoModelo EnderecoDestino { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
