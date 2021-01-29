using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EntityFrameworkEDAO.Models
{
    class Pedido
    {
        public string PedidoId { get; set; }
        public int Numero { get; set; }
        public string ClienteId { get; set; }

        [NotMapped] // para não gravar o cliente, somente o ClienteId
        public Cliente Cliente { get; set; }
        public IList<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
        public double Total => Itens.Sum(x => x.SubTotal);
    }
}
