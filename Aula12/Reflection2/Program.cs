using System;

namespace Reflection2
{
    class Program
    {
        static void Main(string[] args)
        {
            var objeto1 = new Produto { Codigo = 1, Descricao = "Coca-cola", Preco = 5.5 };
            var tipo = objeto1.GetType();

            var prop = tipo.GetProperty("Descricao"); // interessante! obter uma propriedade por string

            Console.WriteLine($"{prop.Name}: {prop.GetValue(objeto1)}"); // isso já foi feito no outro projeto

            prop.SetValue(objeto1, "Coca-Cola 1L"); // para atribuir o valor a uma propriedade

            Console.WriteLine($"{prop.Name}: {prop.GetValue(objeto1)}");

            Console.WriteLine($"Nova descrição: {objeto1.Descricao}");

            Console.WriteLine($"Linha CSV: {RetornarLinhaCsv(objeto1, "Codigo;Descricao")}"); // Linha CSV: 1;Coca-Cola 1L
            // passa os campos de retorno



            var metodo = tipo.GetMethod("TornarDescricaoMaiuscula"); // chamar um método pelo nome dele. Também é Reflection
            metodo.Invoke(objeto1, null); // null pois não tem parâmetros
            Console.WriteLine($"Descricao após chamar o método: {objeto1.Descricao}");



            Console.ReadLine();


        }

        private static string RetornarLinhaCsv<T>(T objeto, string camposSeparadosPorPontoEVirgula)
        {
            var retorno = "";
            string[] nomesPropriedades = camposSeparadosPorPontoEVirgula.Split(';'); // new string[] {"Codigo", "Descricao"} - função split da classe string
            var separador = "";
            var tipo = typeof(T);

            foreach (var nomeProp in nomesPropriedades)
            {
                var prop = tipo.GetProperty(nomeProp); // pega a propriedade pelo nome dela
                if (prop != null)
                {
                    retorno += separador + prop.GetValue(objeto); // pega o valor da propriedade do objeto 
                    separador = ";";
                }
                
            }
            return retorno;
        }
    }
}
