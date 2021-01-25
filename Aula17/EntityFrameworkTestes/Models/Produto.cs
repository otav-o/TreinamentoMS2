using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTestes.Models
{
    class Produto
    {
        public string ProdutoId { get; set; } // é bom ter uma chave primária gerada automaticamente, logo ProdutoId não será PK
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

    }
}
