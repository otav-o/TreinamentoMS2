using SistemaDeCobrancas.Classes_de_mensagens;
using System;
using System.Collections.Generic;

namespace SistemaDeCobrancas
{
    class Program
    {
        static void Main()
        {
            Pessoa[] pessoas = CriarVetorPessoas();
            List<Divida> dividas = CriarDividasAleatorias(pessoas);
            ImprimirTudo(dividas);

            Console.ReadLine();
        }
        private static void ImprimirTudo(List<Divida> dividas)
        {
            foreach (Divida d in dividas)
            {
                var carta = new CartaCobranca(d);
                var etiquetaCarta = carta.Etiqueta.MensagemGerada;
                var nota = new NotaPromissoria(d);
                var etiquetaNota = nota.Etiqueta.MensagemGerada;

                Console.WriteLine();
                Console.WriteLine(etiquetaCarta);
                Console.WriteLine("    " + carta.MensagemGerada);
                Console.WriteLine(etiquetaNota);
                Console.WriteLine("    " + nota.MensagemGerada);
            }

        }

        /// <summary>
        /// Cria dívidas entre as pessoas de uma lista
        /// </summary>
        /// <param name="pessoas">Lista de pessoas</param>
        /// <returns></returns>
        private static List<Divida> CriarDividasAleatorias(Pessoa[] pessoas) 
        {
            List<Divida> dividas = new List<Divida>();
            Random random = new Random();
            int valor;
            for (int i = 0; i < pessoas.Length; i++)
            {
                for (int j = pessoas.Length - 1; j > 0; j--)
                {
                    valor = random.Next(1000);
                    dividas.Add(new Divida(pessoas[i], pessoas[j], valor, DateTime.Now.AddDays(180).Date));
                }
            }

            return dividas;
        }

        static Pessoa[] CriarVetorPessoas()
        {
            PessoaFisica pessoa1 =
                new PessoaFisica("Alfredo", "email@gmail.com",
                    new EnderecoModelo("Rio Branco", "Centro", "Juiz de Fora", 150, 320),
                    "123455123-18", new DateTime(2001, 05, 03)) ;

            PessoaJuridica pessoa2 =
                new PessoaJuridica("Cata Latinhas", "email@hotmail.com",
                    new EnderecoModelo("Av. Brasil", "Manoel Honório", "Juiz de Fora", 140, 212),
                    "1234567890", pessoa1);

            PessoaFisica pessoa3 =
                new PessoaFisica("Alice", "correio@gmail.com",
                    new EnderecoModelo("Av. Itamar Franco", "São Mateus", "Rio de Janeiro", 1550, 150),
                    "123455123-18", new DateTime(1995, 08, 28));

           return new Pessoa[3] { pessoa1, pessoa2, pessoa3 };
        }
    }
}
