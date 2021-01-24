using System;
using System.Threading.Tasks;

namespace TestesDiversos
{
    class Program
    {
        async static Task BaixarArquivo(string url, string caminho)
        {
            Console.WriteLine($"Baixando arquivo '{url}'...");
            await Task.Run( () =>  // ponto de saída, não trava o programa
            {
                System.Threading.Thread.Sleep(2000); // espera 2 segundos
                Console.WriteLine($"Arquivo '{url}' baixado em '{caminho}");
            });
        } // tirando o async e await, vira um método síncrono
        
        static void Main(string[] args)
        {
            var url = "http://exemplo.com/arquivo.zip";
            var caminho = @"C:\Temp\caminho.zip"; // ou coloca um @ (para não ter caracteres de escape) ou usa \\

            Console.WriteLine("Programa iniciou o download...");

            var tarefaBaixar = BaixarArquivo(url, caminho);

            Console.WriteLine("Programa fez algo.");
            Console.WriteLine("Programa fez outra coisa.");
            Console.WriteLine("Agora o programa aguardará o término do download.");

            tarefaBaixar.Wait(5); // timeout: não espera/trava mais que isso, continua a execução
            Console.WriteLine("Fim do programa");

            Console.ReadKey();




            //int soma = 0;
            //Console.WriteLine("Log: 1");

            //var resultadoProcessamento = Processar();

            //Console.ReadKey();

            //Console.WriteLine("Log: 2");

            //resultadoProcessamento.Wait(); // só passa para a próxima linha se o processamento terminar
            //soma = resultadoProcessamento.Result;
            //Console.WriteLine($"Soma: {soma}");




            //var dataInicial = DateTime.Now;
            //Console.WriteLine("Tecle <Enter> o mais rápido possível");
            //Console.ReadKey();
            //var dataFinal = DateTime.Now;

            //TimeSpan intervaloDeTempo = (dataFinal - dataInicial); // TimeSpan: intervalo de tempo

            //Console.WriteLine($"Data inicial: {dataInicial.ToShortDateString()} {dataInicial.ToLongTimeString()}");
            //Console.WriteLine($"Data final: {dataFinal.ToShortDateString()} {dataFinal.ToLongTimeString()}");

            //Console.WriteLine($"Diferença em segundos: {intervaloDeTempo.TotalSeconds}");
        }

        async static Task<int> Processar()
        {
            Console.WriteLine("Log 1.1");

            int soma = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    if (i % 7 == 0)
                        soma += i;
                }
            });
            Console.WriteLine("Log 1.2");
            return soma;

        }
    }
}
