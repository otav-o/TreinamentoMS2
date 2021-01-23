using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoAssincrona1
{
    class Program
    {
        private const int MAX = 1000000000;
        private const int NUMERO_THREADS = 10; // número de instâncias em paralelo
        static void Main(string[] args)
        {
            Console.WriteLine($"Número: {ProcessamentoSincrono()} raízes inteiras de 0 a 1 bilhão."); // demorou cerca de 8 segundos para processar de forma síncrona
            Console.WriteLine($"Número: {ProcessamentoAssincrono()}"); // 2.5 segundos!
        }

        private static int ProcessamentoAssincrono()
        {
            int div = MAX / NUMERO_THREADS; // dividir 1 bilhão de números por 10 threads. 
            DateTime inicio = DateTime.Now;

            int[] resultados = new int[NUMERO_THREADS]; // armazenar em cada posição do vetor o resultado de cada grupo de números (do processamento)
            int tot;

            Parallel.For(0, NUMERO_THREADS, i => resultados[i] = Processamento(i * div, (i + 1) * div)); 
            // chama a função de 0 a NUMERO_THREADS (10 vezes), i recebe os valores 0 a 9 
            // a questão é que o Parallel.For roda a Action em paralelo. Observe que a função Processamento tem um início e fim para o cálculo.
            // Parallel.For passa os 10 pedaços por parâmetro
 
            tot = resultados.Sum(); // soma o vetor de inteiros (LINQ) e dá o total de raízes inteiras

            Console.WriteLine($"Assíncrono: {(DateTime.Now - inicio).TotalSeconds} segundos.");
            
            return tot;
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
