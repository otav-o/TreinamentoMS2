using System;
using System.Collections.Generic;
using System.Text;

namespace TesteInjecaoDependencia
{
    class RecepcaoIndireta : IRecepcao
    {
        public RecepcaoIndireta(ISaudacao saudacao) => this.saudacao = saudacao;
        public void Recepcionar(string nome)
        {
            Cumprimentar(nome);
            Direcionar(nome);
        }

        private void Cumprimentar(string nome)
        {
            saudacao.Realizar(nome);
        }

        private void Direcionar(string nome)
        {
            if (nome == null || nome.Length < 7)
                Console.WriteLine("Por favor, entre na fila à sua direita ->");
            else
                Console.WriteLine("<- Por favor, entre na fila à sua esquerda");
        }

        private ISaudacao saudacao;
    }
}
