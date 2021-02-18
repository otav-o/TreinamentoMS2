using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace TesteInjecaoDependencia
{
    static class Instancia
    {
        static Instancia() // construtor estático - executado somente no primeiro uso da classe
        {
            IServiceCollection services = new ServiceCollection() // cria-se um objeto ServiceCollection
                .AddSingleton<ISaudacao, SaudacaoAmigavel>() // onde for esperado uma objeto ISaudacao, forneça uma instância de SaudacaoInformal
                .AddTransient<IRecepcao, RecepcaoDireta>(); // quando for uma IRecepcao, retorne uma RecepcaoDireta

            provedor = services.BuildServiceProvider(); // criação do provedor
        }

        public static T Get<T>() => provedor.GetService<T>(); // GetService é quem instancia T. Provedor foi criado no construtor

        private static ServiceProvider provedor;
    }
}
