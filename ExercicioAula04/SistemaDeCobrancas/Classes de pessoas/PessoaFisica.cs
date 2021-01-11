using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get => DataNascimento.Date; set { } }

        public PessoaFisica (string nome, string email, EnderecoModelo endereco, string cpf, DateTime dataNasc)
        {
            Nome = nome;
            Email = email;
            Endereco = endereco;
            Cpf = cpf;
            DataNascimento = dataNasc;
        }


    }
}
