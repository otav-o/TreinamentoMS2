using Microsoft.Extensions.DependencyInjection;
using System;

namespace TesteInjecaoDependencia
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Vou tirar isso daqui ainda

            IServiceCollection services = new ServiceCollection() // cria-se um objeto ServiceCollection
                .AddSingleton<ISaudacao, SaudacaoInformal>() // onde for esperado uma objeto ISaudacao, forneça uma instância de SaudacaoInformal
                .AddTransient<RecepcaoDireta, RecepcaoDireta>(); // quando for uma RecepcaoDireta, retorne uma RecepcaoDireta

            var provedor = services.BuildServiceProvider(); // cria um provedor de serviços

            // obs.: adicionar o Microsoft.Extensions.DependencyInjection pelo NuGet

            #endregion




            string nome;

            Console.Write("Informe o seu nome: ");

            nome = Console.ReadLine();

            var recepcao = provedor.GetService<RecepcaoDireta>(); 
            // pede uma instância de RecepcaoDireta
            // mandou-se instanciar RecepcaoDireta e ele conseguiu entender que, para fazer isso, deve-se passar um ISaudacao pelo construtor, instanciando SaudacaoInformal ou SaudacaoAmigavel (depende do que foi configurado)
            // no momento, o escopo desse provedor é o Main

            recepcao.Recepcionar(nome);
        }
    }
}
