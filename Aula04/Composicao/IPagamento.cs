using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao
{
    interface IPagamento : IPagamentoInfo
    {
        double Valor { get; }
        void Pagar(double valor);
    }
}
// composição: geralmente cria uma interface e vai utilizar o objeto por ela