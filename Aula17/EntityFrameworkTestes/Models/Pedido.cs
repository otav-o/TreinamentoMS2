using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTestes.Models
{
    class Pedido
    {
        public string PedidoId { get; set; }
        public int Numero { get; set; }
        public Cliente Cliente { get; set; }
        public IList<PedidoItem> Itens { get; set; }
        public double Total => Itens.Sum(x => x.SubTotal);
    }
}
