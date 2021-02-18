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

            var recepcao = Instancia.Get<RecepcaoDireta>();

            recepcao.Recepcionar(nome);
        }
    }
}
