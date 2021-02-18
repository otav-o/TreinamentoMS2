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

            RecepcaoDireta recepcao = new RecepcaoDireta(new SaudacaoInformal()); // agora é aqui que se define a saudação (e não na classe recepção)
            recepcao.Recepcionar(nome);
        }
    }
}
