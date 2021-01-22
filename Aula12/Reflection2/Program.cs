using System;

namespace Reflection2
{
    class Program
    {
        static void Main(string[] args)
        {
            var objeto1 = new Produto { Codigo = 1, Descricao = "Coca-cola", Preco = 5.5 };
            var tipo = objeto1.GetType();

            var prop = tipo.GetProperty("Descricao"); // interessante!

            Console.WriteLine($"{prop.Name}: {prop.GetValue(objeto1)}"); // isso já foi feito no outro projeto

            prop.SetValue(objeto1, "Coca-Cola 1L"); // para atribuir o valor a uma propriedade

            Console.WriteLine($"{prop.Name}: {prop.GetValue(objeto1)}");

            Console.WriteLine($"Nova descrição: {objeto1.Descricao}");

            Console.ReadLine();
        }
    }
}
