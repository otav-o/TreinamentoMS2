using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas.Classes_de_mensagens
{
    class Etiqueta : IMensagem
    {
        public Pessoa Remetente { get; set; }
        public Pessoa Destinatario { get; set; }
        public EnderecoModelo EnderecoDestino { get; set; }

        public Etiqueta(Pessoa remetente, Pessoa destinatario)
        {
            Remetente = remetente;
            Destinatario = destinatario;
            EnderecoDestino = Destinatario.Endereco;
        }
        public string MensagemGerada
        {
            get
            {
                string textoIntermediario = "";

                if (this.Destinatario is PessoaJuridica)
                {
                    PessoaJuridica p = (PessoaJuridica) this.Destinatario; // converter em PessoaJuridica para acessar ContatoCobranca na linha seguinte
                    textoIntermediario = $"Aos cuidados de {p.ContatoCobranca.Nome}\n";
                }
                
                string textoFinal = $"{this.Destinatario}\n" + textoIntermediario +
                    $"{this.EnderecoDestino.Rua}, {this.EnderecoDestino.Numero}/{this.EnderecoDestino.Complemento}\n" +
                    $"{this.EnderecoDestino.Bairro}, {this.EnderecoDestino.Cidade}.";

                return textoFinal;
            }
        }
    }
} // tentei deixar o código "genérico" para ser aplicado em várias UI (forms, console, etc.)
