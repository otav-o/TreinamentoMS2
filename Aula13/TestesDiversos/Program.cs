using System;
using System.Threading.Tasks;

namespace TestesDiversos
{
    class Program
    {
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
        static void Main(string[] args)
        {
            int soma = 0;
            Console.WriteLine("Log: 1");

            var resultadoProcessamento = Processar();

            Console.ReadKey();

            Console.WriteLine("Log: 2");


            resultadoProcessamento.Wait(); // só passa para a próxima linha se o processamento terminar
            soma = resultadoProcessamento.Result;
            Console.WriteLine($"Soma: {soma}");




            //var dataInicial = DateTime.Now;
            //Console.WriteLine("Tecle <Enter> o mais rápido possível");
            //Console.ReadKey();
            //var dataFinal = DateTime.Now;

            //TimeSpan intervaloDeTempo = (dataFinal - dataInicial); // TimeSpan: intervalo de tempo

            //Console.WriteLine($"Data inicial: {dataInicial.ToShortDateString()} {dataInicial.ToLongTimeString()}");
            //Console.WriteLine($"Data final: {dataFinal.ToShortDateString()} {dataFinal.ToLongTimeString()}");

            //Console.WriteLine($"Diferença em segundos: {intervaloDeTempo.TotalSeconds}");
        }
    }
}
