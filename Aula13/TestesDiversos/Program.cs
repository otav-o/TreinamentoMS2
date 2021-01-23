using System;

namespace TestesDiversos
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataInicial = new DateTime(2020, 1, 19, 20, 21, 22);
            var dataFinal = DateTime.Now;

            TimeSpan intervaloDeTempo = (dataFinal - dataInicial); // TimeSpan: intervalo de tempo

            Console.WriteLine($"Data inicial: {dataInicial.ToShortDateString()} {dataInicial.ToLongTimeString()}");
            Console.WriteLine($"Data final: {dataFinal.ToShortDateString()} {dataFinal.ToLongTimeString()}");

            Console.WriteLine($"Diferença em anos: {intervaloDeTempo.TotalDays}");
        }
    }
}
