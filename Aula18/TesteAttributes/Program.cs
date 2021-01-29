using System;
using System.Linq;
using System.Reflection;

namespace TesteAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            var cli = new Cliente { Nome = "Ana", Email = "ana@email.com" };

            Imprimir(cli);

            Console.ReadKey();
        }

        private static void Imprimir<T>(T cli)
        {
            var tipo = typeof(T);
            ImprimirTitulo(tipo);
            ImprimirPropriedades(tipo.GetProperties(), cli);
        }

        private static void ImprimirPropriedades(PropertyInfo[] propertyInfo, object obj)
        {
            foreach (var propInfo in propertyInfo)
            {
                var atributo = propInfo.GetCustomAttributes(typeof(TituloAttribute)).FirstOrDefault();
                if (atributo == null)
                    Console.Write($"  {propInfo.Name}: ");
                else
                    Console.Write($"  {((TituloAttribute)atributo).Titulo}: ");

                Console.WriteLine(propInfo.GetValue(obj));
            }
        }

        private static void ImprimirTitulo(Type tipo)
        {
            var atributosClasse = tipo.GetCustomAttributes(typeof(TituloAttribute), false);

            if (atributosClasse.Length > 0)
            {
                TituloAttribute atributo = (TituloAttribute)atributosClasse[0];
                Console.WriteLine($"{atributo.Titulo}:");
            }
            else
            {
                Console.WriteLine($"{tipo.Name}:");
            }
        }
    }
}
