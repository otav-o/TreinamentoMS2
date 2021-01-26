using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeFinal_Modulo2_Otavio.Models
{
    class Aluno
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
    }
}
