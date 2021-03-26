using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    // Extension Methodu yazabilmemiz için, O Methodun static olması lazım
    public static class ServiceCollectionExtensions
    {
        // IServisColleciton = Asp Net uygulamızın (Apimizin) service bağımlılıklarını eklediğimiz
        // yada araya girmesini istediğimiz servicelerin kendisidir


        // IServiceCollection genişletmek istiyoruz. İstediğimiz kadar ICoreModule alabiliyoruz.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)  // istersek params olarakta yapabiliriz
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
