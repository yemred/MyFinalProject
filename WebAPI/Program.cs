using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())     // Autofac eklemek i�in yazd�k. Ezberlenecek kod de�il. Ezberleme. Core altyap�nda IoC var onu kullanma Autofac kullan dioruz.
                .ConfigureContainer<ContainerBuilder>(builder =>                    // ekledi�imiz IoC Container. Core'un kendi IoC sini kullanmad���m�z i�i�n ekledik
                {                                                                   // ekledi�imiz IoC Container. Core'un kendi IoC sini kullanmad���m�z i�i�n ekledik
                    builder.RegisterModule(new AutofacBusinessModule());            // ekledi�imiz IoC Container. Core'un kendi IoC sini kullanmad���m�z i�i�n ekledik
                }                                                                   // ekledi�imiz IoC Container. Core'un kendi IoC sini kullanmad���m�z i�i�n ekledik
                )                                                                   // ekledi�imiz IoC Container. Core'un kendi IoC sini kullanmad���m�z i�i�n ekledik
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
