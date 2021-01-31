using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtividadeFinal_Modulo2_Otavio.Models
{
    public class Aluno
    {
        [Key]
        public int Matricula { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; } // mais de um endereço?
    }
}
