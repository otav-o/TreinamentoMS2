using System;

namespace TesteInjecaoDependencia
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome;

            Console.Write("Informe o seu nome: ");

            nome = Console.ReadLine();

            var recepcao = Instancia.Get<IRecepcao>(); // agora, até a classe program desconhece totalmente a recepção
            // classe recepção desconhece a saudação
            // a mágica está em configurar em Instancia, em apenas um ponto do códigoa

            recepcao.Recepcionar(nome);
        }
    }
}
