using SistemaDeCobrancas.Classes_de_mensagens;
using System;
using System.Collections.Generic;

namespace SistemaDeCobrancas
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa[] pessoas = CriarVetorPessoas();

            List<Divida> dividas = criarDividasAleatorias(pessoas);

            ImprimirCartaCobranca(dividas);

            ImprimirNotasPromissorias(pessoas);

            

            Console.ReadLine();
        }

        private static List<Divida> criarDividasAleatorias(Pessoa[] pessoas) 
        {
            List<Divida> dividas = new List<Divida>();
            Random random = new Random();
            int valor;
            for (int i = 0; i < pessoas.Length; i++)
            {
                for (int j = 0; j < pessoas.Length; j++)
                {
                    valor = random.Next(1000);
                    dividas.Add(new Divida(pessoas[i], pessoas[j], valor, DateTime.Now.AddDays(180).Date));
                }
            }

            return dividas;
        }

        private static void ImprimirNotasPromissorias(Pessoa[] pessoas)
        {
            foreach (Pessoa p in pessoas)
            {
                IMensagem msg = new NotaPromissoria(p, pessoas[0], 1000, new DateTime(2021, 04, 01));
                Console.WriteLine(msg.MensagemGerada);
            }
        }

        private static void ImprimirCartaCobranca(List<Divida> dividas)
        {
            foreach(Divida d in dividas)
            {
                IMensagem msg = new CartaCobranca(d);
                Console.WriteLine(msg.MensagemGerada);
                // msg = new Etiqueta(d);
            }
        }

        private static void ImprimirEtiquetas(List<Divida> dividas)
        {
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
