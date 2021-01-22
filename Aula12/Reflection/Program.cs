using System;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            object obj = new Produto { Codigo = 1, Descricao = "Coca-cola", Preco = 5.5 };

            var tipo = obj.GetType(); // como a classe não herda de ninguém, ela herda de Object
                // pega o tipo do objeto mesmo (Produto) e não o da variável obj (Object)

            Console.WriteLine($"Foi instanciado um objeto da classe '{tipo.Name}'");
            /*
            if (typeof(int) == idade.GetType()) // todo objeto em C# herda de Object, logo esse método é possível
                Console.WriteLine("A variável 'idade' é do tipo 'int'");
            else
                Console.WriteLine("A variável 'idade' não é do tipo 'int'");
            */

            Console.ReadKey();
        }
    }
}
