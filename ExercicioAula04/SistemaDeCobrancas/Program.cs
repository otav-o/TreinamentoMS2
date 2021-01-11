using SistemaDeCobrancas.Classes_de_mensagens;
using System;

namespace SistemaDeCobrancas
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa[] pessoas = CriarVetorPessoas();
            // ImprimirEtiquetas(pessoas);
            // ImprimirCartaCobranca(pessoas);
            ImprimirNotasPromissorias(pessoas);
            Console.ReadLine();
        }

        private static void ImprimirNotasPromissorias(Pessoa[] pessoas)
        {
            foreach (Pessoa p in pessoas)
            {
                IMensagem msg = new NotaPromissoria(p, pessoas[0], 1000);
                Console.WriteLine(msg.MensagemGerada);
            }
        }

        private static void ImprimirCartaCobranca(Pessoa[] pessoas)
        {
            throw new NotImplementedException();
        }

        private static void ImprimirEtiquetas(Pessoa[] pessoas)
        {
            throw new NotImplementedException();
        }

        static Pessoa[] CriarVetorPessoas()
        {
            PessoaFisica pessoa1 =
                new PessoaFisica("Alfredo", "email@gmail.com",
                    new EnderecoModelo("Rio Branco", "Centro", "Juiz de Fora", 150, 320),
                    "123455123-18", Convert.ToDateTime(10,02,2000)) ;

            PessoaJuridica pessoa2 =
                new PessoaJuridica("Cata Latinhas", "email@hotmail.com",
                    new EnderecoModelo("Av. Brasil", "Manoel Honório", "Juiz de Fora", 140, 212),
                    "1234567890", pessoa1);

            PessoaFisica pessoa3 =
                new PessoaFisica("Alice", "correio@gmail.com",
                    new EnderecoModelo("Av. Itamar Franco", "São Mateus", "Rio de Janeiro", 1550, 150),
                    "123455123-18", Convert.ToDateTime("13-06-1995"));

           return new Pessoa[3] { pessoa1, pessoa2, pessoa3 };
        }
    }
}
