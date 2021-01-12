using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas.Classes_de_mensagens
{
    class CartaCobranca : IMensagemCobranca
    {
        public Pessoa Remetente { get; set; }
        public Pessoa Destinatario { get; set; }
        public EnderecoModelo EnderecoDestino { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }

        public CartaCobranca(Pessoa remetente, Pessoa destinatario, double valorCobranca)
        {
            Remetente = remetente;
            Destinatario = destinatario;
            Valor = valorCobranca;
            EnderecoDestino = Destinatario.Endereco; 
        }

        public CartaCobranca(Divida d)
        {
            Remetente = d.Credor;
            Destinatario = d.Devedor;
            Valor = d.Valor;
            EnderecoDestino = d.Devedor.Endereco;
            DataVencimento = d.Vencimento;
        }

        public string MensagemGerada
        {
            get
            {
                if (Destinatario is PessoaFisica)
                {
                    return $"Caro(a) {Destinatario.Nome}, você me deve R${Valor:N2}!";
                }
                else
                {
                    var p = (PessoaJuridica)Destinatario;
                    return $"Caro(a) {p.ContatoCobranca.Nome}, a empresa {p.Nome} me deve R${Valor:N2}!";
                }
            }
        }
    }
}
