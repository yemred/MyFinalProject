using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        // Genel bağımlılıkları yüklüyoruz. Injectionları
        void Load(IServiceCollection serviceCollection);
    }
}
