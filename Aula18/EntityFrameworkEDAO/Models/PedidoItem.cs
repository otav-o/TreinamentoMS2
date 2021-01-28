using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkEDAO.Models
{
    class PedidoItem
    {
        public string PedidoItemId { get; set; }
        public string PedidoId { get; set; }
        public double Quantidade { get; set; }
        public Produto Produto { get; set; }
        public double SubTotal => (Produto == null ? 0 : Quantidade * Produto.Preco);
    }
}
