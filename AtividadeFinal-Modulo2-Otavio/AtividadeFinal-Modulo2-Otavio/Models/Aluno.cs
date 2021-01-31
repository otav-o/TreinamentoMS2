using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AtividadeFinal_Modulo2_Otavio.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public int Matricula { get; set; } // não consegui atribuir valor a Matricula quando ela era PK, por isso o criei o Id
        // matricula é definida como unique em ApplicationContext
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
