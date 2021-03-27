using Core.CrossCuttingConcens.Caching;
using Core.CrossCuttingConcens.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        // Genel bağımlılıkları yüklüyoruz. Injectionları
        public void Load(IServiceCollection services)
        {
            //Startup ta yaptığımızı sildik burda yaptık. Çünkü bütün projelerde ortak
            services.AddMemoryCache(); // .Net kendisinin. MemoryCache in karşılığı

            //Arka planda bana HTTPContextAccessor instance oluştur demek
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();

            services.AddSingleton<Stopwatch>();

        }
    }
}
