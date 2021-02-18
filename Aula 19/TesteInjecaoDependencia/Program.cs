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
                .AddSingleton<ISaudacao, SaudacaoAmigavel>(); // onde for esperado uma objeto ISaudacao, forneça uma instância de SaudacaoInformal
                                                              //.AddTrasient<IRecepcao, RecepcaoDireta>();

            var provedor = services.BuildServiceProvider(); // cria um provedor de serviços

            var saudacaoDI = provedor.GetService<ISaudacao>(); // provedor retorna instâncias de ISaudacao

            saudacaoDI.Realizar("Zé");

            // obs.: adicionar o Microsoft.Extensions.DependencyInjection pelo NuGet

            #endregion




            string nome;

            Console.Write("Informe o seu nome: ");

            nome = Console.ReadLine();

            RecepcaoDireta recepcao = new RecepcaoDireta(new SaudacaoInformal()); // agora é aqui que se define a saudação (e não na classe recepção)
            recepcao.Recepcionar(nome);
        }
    }
}
