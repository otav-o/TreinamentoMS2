using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            var produto1 = new Produto { Codigo = 1, Descricao = "Coca-cola", Preco = 5.5 };
            var produto2 = new Produto { Codigo = 2, Descricao = "Pepsi", Preco = 2.5 };
            var produto3 = new Produto { Codigo = 3, Descricao = "Picanhaa", Preco = 50.5 };

            Console.WriteLine($"Produto: {RetornarLinhaCsv<Produto>(produto1)}");

            var cliente1 = new Cliente { Nome = "Ana", Email = "ana@email.com" };
            var cliente2 = new Cliente { Nome = "Bruno", Email = "bruno@email.com" };

            Console.WriteLine($"Cliente: {RetornarLinhaCsv<Cliente>(cliente1)}");

            var produtos = new Produto[] { produto1, produto2, produto3 };
            var clientes = new Cliente[] { cliente1, cliente2 };

            ExportarParaCsv(produtos);
            ExportarParaCsv(clientes);


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

        private static void ExportarParaCsv<T>(IEnumerable<T> objetos)
        {
            Console.WriteLine("Exportando...");
            var sb = new StringBuilder();
            var tipo = typeof(T);

            sb.Append(RetornarCabecalho(tipo)); // Append() pertence a StringBuilder e é melhor do que concatenar manualmente. ToString() retorna tudo

            foreach (var obj in objetos)
            {
                sb.Append(RetornarLinhaCsv(obj) + "\n");
            }

            File.WriteAllText(@$"D:\otavio\github\treinamentoms2\aula12\{tipo.Name}s.csv", sb.ToString());

            Console.WriteLine($"Dados exportados.");
        }

        private static string RetornarCabecalho(Type tipo) // retornar todas as propriedades
        {
            var retorno = "";
            var separador = "";
            foreach (var prop in tipo.GetProperties())
            {
                retorno += separador + prop.Name; // nome da propriedade
                separador = ";";
            }
            return retorno;
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
