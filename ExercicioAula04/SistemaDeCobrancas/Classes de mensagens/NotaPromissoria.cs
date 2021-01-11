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
                string textoIntermediario = "";
                PessoaJuridica p;

                string nomeHumano = Remetente.Nome; // na nota promissória, o remetente é o devedor

                if (Remetente is PessoaFisica) 
                {
                    p = Remetente as PessoaJuridica;
                    textoIntermediario = $" representante legal da empresa {p.Nome}, ";
                    nomeHumano = p.ContatoCobranca.Nome;
                }

                return $"Eu, {nomeHumano}," + textoIntermediario + $" prometo pagar {Valor} até a data {DataVencimento}";
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
