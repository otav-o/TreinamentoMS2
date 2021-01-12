using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas.Classes_de_mensagens
{
    class NotaPromissoria : IMensagemCobranca
    {
        public Etiqueta Etiqueta { get; }
        public double Valor { get; }
        public DateTime DataVencimento { get; }

        public string MensagemGerada
        {
            get
            {
                string textoIntermediario = "";
                PessoaJuridica p;

                string nomeHumano = Etiqueta.Remetente.Nome; // na nota promissória, o remetente (que envia) é o devedor

                if (Etiqueta.Remetente is PessoaJuridica) 
                {
                    p = Etiqueta.Remetente as PessoaJuridica;
                    textoIntermediario = $"representante legal da empresa {p.Nome}, ";
                    nomeHumano = p.ContatoCobranca.Nome;
                }

                return $"Eu, {nomeHumano}, " + textoIntermediario + $"prometo pagar {Valor} para {Etiqueta.Destinatario.Nome} até a data {DataVencimento.Date}";
            }
        }

        public NotaPromissoria(Pessoa devedor, Pessoa credor, double valorCobranca, DateTime dataVencimento)
        {
            Etiqueta = new Etiqueta(credor, devedor);
            Valor = valorCobranca;
            DataVencimento = dataVencimento;
        }
        public NotaPromissoria(Divida d)
        {
            Etiqueta = new Etiqueta(d.Credor, d.Devedor);
            Valor = d.Valor;
            DataVencimento = d.Vencimento;
        }
    }
}
