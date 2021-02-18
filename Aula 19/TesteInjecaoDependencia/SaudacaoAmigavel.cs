using System;
using System.Collections.Generic;
using System.Text;

namespace TesteInjecaoDependencia
{
    class SaudacaoAmigavel : ISaudacao
    {
        public void Realizar(string nome)
        {
            Console.WriteLine($"Olá {nome}! Seja bem vindo(a)!");
        }
    }
}
