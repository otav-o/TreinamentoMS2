using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeCobrancas
{
    abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public EnderecoModelo Endereco { get; set; }
        
    }
}
