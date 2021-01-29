using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkEDAO.Models
{
    class PedidoItem
    {
        public string PedidoItemId { get; set; }
        public string PedidoId { get; set; }
        public double Quantidade { get; set; }
        public string ProdutoId { get; set; }

        [NotMapped]
        public Produto Produto { get; set; }
        public double SubTotal => (Produto == null ? 0 : Quantidade * Produto.Preco);
    }
}
