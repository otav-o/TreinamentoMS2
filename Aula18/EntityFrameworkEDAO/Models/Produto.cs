using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkEDAO.Models
{
    class Produto
    {
        public string ProdutoId { get; set; }
        public int Codigo { get; set; }

        [Required] // RequiredAttribute. Tem que importar o namespace. Diz que o campo não pode ser nulo
        public string Descricao { get; set; }
        public double Preco { get; set; }

        // mas é possível configurar o campo requerido diretamente no DbContext
    }
}
