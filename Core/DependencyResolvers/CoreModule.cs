using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        // Genel bağımlılıkları yüklüyoruz. Injectionları
        public void Load(IServiceCollection serviceCollection)
        {
            //Startup ta yaptığımızı sildik burda yaptık. Çünkü bütün projelerde ortak
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
