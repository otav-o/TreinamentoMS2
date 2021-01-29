using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAttributes
{
    class Produto
    {
        [Titulo("Código")]
        public int Codigo { get; set; }
        [Titulo("Descrição")]
        public string Descricao { get; set; }
        [Titulo("Preço")]
        public double Preco { get; set; }
    }
}
