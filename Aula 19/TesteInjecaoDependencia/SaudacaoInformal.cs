using System;
using System.Collections.Generic;
using System.Text;

namespace TesteInjecaoDependencia
{
    class SaudacaoInformal : ISaudacao
    {
        public void Realizar(string nome)
        {
            Console.WriteLine($"E aí cara! {nome}, beleza?");
        }
    }
}
