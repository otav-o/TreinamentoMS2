using System;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            var produto = new Produto { Codigo = 1, Descricao = "Coca-cola", Preco = 5.5 };

            Console.WriteLine($"Produto: {RetornarLinhaCsv<Produto>(produto)}");

            var cliente = new Cliente { Nome = "Ana", Email = "ana@email.com" };

            Console.WriteLine($"Cliente: {RetornarLinhaCsv<Cliente>(cliente)}");

            //var tipo = produto.GetType(); // como a classe não herda de ninguém, ela herda de Object
            //    // pega o tipo do objeto mesmo (Produto) e não o da variável obj (Object)

            //ImprimirTipo(produto);




            /*
            if (typeof(int) == idade.GetType()) // todo objeto em C# herda de Object, logo esse método é possível
                Console.WriteLine("A variável 'idade' é do tipo 'int'");
            else
                Console.WriteLine("A variável 'idade' não é do tipo 'int'");
            */

            Console.ReadKey();
        }
        private static string RetornarLinhaCsv<T>(T objeto)
        {
            string retorno = "";
            var tipo = typeof(T);
            var separador = "";
            foreach (var prop in tipo.GetProperties()) // para cada propriedade
            {
                retorno += separador + prop.GetValue(objeto); // pega o valor desta propriedade em "objeto'
                separador = ";";
            }
            return retorno;
        }
        private static void ImprimirTipo (Produto obj)
        {
            var tipo = obj.GetType();

            Console.WriteLine($"Tipo: {tipo.FullName}"); // nome completo da classe com o namespace (Reflection.Produto)

            var propriedades = tipo.GetProperties();
            foreach (var prop in propriedades)
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(obj)}"); // imprime as propriedades da classe Produto (Codigo, Descricao, Preco)
            }
        }
    }
}
