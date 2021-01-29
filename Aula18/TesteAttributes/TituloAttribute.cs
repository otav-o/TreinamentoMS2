using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAttributes
{
    class TituloAttribute : Attribute
    {
        public TituloAttribute(string titulo) => Titulo = titulo;
        public string Titulo { get; private set; }
    }
}
