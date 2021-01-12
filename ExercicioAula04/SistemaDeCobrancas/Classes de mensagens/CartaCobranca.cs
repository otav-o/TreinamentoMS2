using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas.Classes_de_mensagens
{
    class CartaCobranca : IMensagemCobranca
    {
        public Etiqueta Etiqueta { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }

        public CartaCobranca(Pessoa credor, Pessoa devedor, double valorCobranca)
        {
            Etiqueta = new Etiqueta(devedor, credor);
            Valor = valorCobranca;

            // não sei se deveria usar propriedades próprias da classe que se comunicam com a etiqueta
            // ex.: public Pessoa Remetente { get => Etiqueta.Remetente; set => Etiqueta.Remetente = value; }
        }

        public CartaCobranca(Divida d)
        {
            Etiqueta = new Etiqueta(d.Devedor, d.Credor);
            Valor = d.Valor;
            DataVencimento = d.Vencimento;
        }

        public string MensagemGerada
        {
            get
            {
                if (Etiqueta.Destinatario is PessoaFisica)
                {
                    return $"Caro(a) {Etiqueta.Destinatario.Nome}, você me deve R${Valor:N2}!";
                }
                else
                {
                    var p = (PessoaJuridica)Etiqueta.Destinatario;
                    return $"Caro(a) {p.ContatoCobranca.Nome}, a empresa {p.Nome} me deve R${Valor:N2}!";
                }
            }
        }
    }
}
