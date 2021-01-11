using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas.Classes_de_mensagens
{
    class NotaPromissoria : IMensagemCobranca
    {
        /// <summary>
        /// Pessoa/empresa que está devendo e promete pagar
        /// </summary>
        public Pessoa Remetente { get; set; }

        /// <summary>
        /// Pessoa que recebe a promessa de pagamento
        /// </summary>
        public Pessoa Destinatario { get; set; }
        public double Valor { get; set; }
        public EnderecoModelo EnderecoDestino { get; set; }

        public DateTime DataVencimento { get; set; }

        public string MensagemGerada
        {
            get
            {
                string textoFinal = "";
                string textoIntermediario = "";
                PessoaJuridica p;
                if (Remetente is PessoaFisica) 
                {
                    textoIntermediario = $" representante legal da empresa {nomeEmpresa}, ";
                    p = Remetente as PessoaJuridica;
                }
                
                textoFinal = $"Eu, {nomeHumano}," + textoIntermediario + $" prometo pagar {ValorCobranca} na data"
            }
        }

        public NotaPromissoria(Pessoa remetente, Pessoa destinatario, double valorCobranca)
        {
            Remetente = remetente;
            Destinatario = destinatario;
            Valor = valorCobranca;
            EnderecoDestino = destinatario.Endereco;
        }
    }
}
