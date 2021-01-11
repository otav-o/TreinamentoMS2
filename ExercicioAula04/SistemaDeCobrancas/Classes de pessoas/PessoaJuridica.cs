using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }

        /// <summary>
        /// Responsável financeiro pela empresa que receberá as cartas de cobrança.
        /// </summary>
        public PessoaFisica ContatoCobranca { get; set; }

        public PessoaJuridica (string nome, string email, EnderecoModelo endereco, string cnpj, PessoaFisica responsavel)
        {
            Nome = nome;
            Email = email;
            Endereco = endereco;
            Cnpj = cnpj;
            ContatoCobranca = responsavel;
        }
    }
}
