using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get => DataNascimento.Date; set { } }

    }
}
