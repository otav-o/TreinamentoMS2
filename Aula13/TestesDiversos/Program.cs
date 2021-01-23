using System;

namespace TestesDiversos
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataInicial = DateTime.Now;
            Console.WriteLine("Tecle <Enter> o mais rápido possível");
            Console.ReadKey();
            var dataFinal = DateTime.Now;

            TimeSpan intervaloDeTempo = (dataFinal - dataInicial); // TimeSpan: intervalo de tempo

            Console.WriteLine($"Data inicial: {dataInicial.ToShortDateString()} {dataInicial.ToLongTimeString()}");
            Console.WriteLine($"Data final: {dataFinal.ToShortDateString()} {dataFinal.ToLongTimeString()}");

            Console.WriteLine($"Diferença em segundos: {intervaloDeTempo.TotalSeconds}");
        }
    }
}
