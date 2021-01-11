using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas.Classes_de_mensagens
{
    class NotaPromissoria : IMensagemCobranca
    {
        public Etiqueta Cabecalho { get; set; }
        public double Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public string MensagemGerada
        {
            get
            {
                string textoFinal = "";
                string textoIntermediario = "";
                string nomeHumano = Cabecalho.Remetente.Nome;

                PessoaJuridica p;

                if (Cabecalho.Remetente is PessoaJuridica) // em uma nota promissória, o remetente é o devedor
                {
                    textoIntermediario = $" representante legal da empresa {Cabecalho.Remetente.Nome}, ";
                    p = Cabecalho.Remetente as PessoaJuridica;
                    nomeHumano = p.ContatoCobranca.Nome;
                }
                textoFinal = $"Eu, {nomeHumano}," + textoIntermediario + $" prometo pagar {Valor} até a data {DataVencimento}";
                //TODO resolver essa confusão entre nomes (p e Cabecalho.Remetente)

                return textoFinal;
            }
        }

        
    }
}
