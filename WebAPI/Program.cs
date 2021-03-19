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
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())     // Autofac eklemek için yazdýk. Ezberlenecek kod deðil. Ezberleme. Core altyapýnda IoC var onu kullanma Autofac kullan dioruz.
                .ConfigureContainer<ContainerBuilder>(builder =>                    // eklediðimiz IoC Container. Core'un kendi IoC sini kullanmadýðýmýz içiçn ekledik
                {                                                                   // eklediðimiz IoC Container. Core'un kendi IoC sini kullanmadýðýmýz içiçn ekledik
                    builder.RegisterModule(new AutofacBusinessModule());            // eklediðimiz IoC Container. Core'un kendi IoC sini kullanmadýðýmýz içiçn ekledik
                }                                                                   // eklediðimiz IoC Container. Core'un kendi IoC sini kullanmadýðýmýz içiçn ekledik
                )                                                                   // eklediðimiz IoC Container. Core'un kendi IoC sini kullanmadýðýmýz içiçn ekledik
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
