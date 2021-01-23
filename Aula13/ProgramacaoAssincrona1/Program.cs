using System;

namespace ProgramacaoAssincrona1
{
    class Program
    {
        private const int MAX = 1000000000;
        private const int NUMERO_THREADS = 10;
        static void Main(string[] args)
        {
            Console.WriteLine($"Número: {ProcessamentoSincrono()} raízes inteiras de 0 a 1 bilhão."); // demorou cerca de 8 segundos para processar de forma síncrona
        }

        private static int ProcessamentoSincrono()
        {
            DateTime inicio = DateTime.Now;
            int cont = Processamento(0, MAX);
            Console.WriteLine($"Síncrono: {(DateTime.Now - inicio).TotalSeconds} segundos.");
            return cont;
        }

        private static int Processamento(int inicio, int fim)
        { // descobrir quantos números de 0 a 1 bilhão possuem a raíz inteira
            int cont = 0;
            double raiz;
            for (int i = inicio; i < fim; i++)
            {
                raiz = Math.Sqrt(i);
                if (raiz == Math.Floor(raiz)) // arredonda para baixo
                    cont++;
            }
            return cont;
        }
    }
}
