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

            RecepcaoDireta recepcao = new RecepcaoDireta();
            recepcao.Recepcionar(nome);
        }
    }
}
