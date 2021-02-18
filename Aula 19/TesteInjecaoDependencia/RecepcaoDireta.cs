using System;
using System.Collections.Generic;
using System.Text;

namespace TesteInjecaoDependencia
{
    class RecepcaoDireta
    {
        public RecepcaoDireta(ISaudacao saudacao) => this.saudacao = saudacao;
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
            if (nome == null)
                Console.WriteLine("Entre na fila à sua direita");
            else if (char.ToUpper(nome[0]) > 'K')
                Console.WriteLine("Siga para a sala 1");
            else
                Console.WriteLine("Siga para a sala 2");
        }

        private ISaudacao saudacao;
    }
}
