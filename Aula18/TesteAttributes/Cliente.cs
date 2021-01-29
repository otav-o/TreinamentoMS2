using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAttributes
{
    [Titulo("Cliente")] 
    class Cliente
    {
        [Titulo("Nome")] // passado por construtor
        public string Nome { get; set; }
        [Titulo("E-mail")]
        public string Email { get; set; }

    }
}
// Attributes em C#
// Anotations em Java
// Utilidade: Uma forma de colocar alguma instrução/informação encima de propriedades, classes, métodos e etc.