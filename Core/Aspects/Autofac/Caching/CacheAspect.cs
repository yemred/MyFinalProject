using Castle.DynamicProxy;
using Core.CrossCuttingConcens.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //
            // Methodun ismini buluyoruz.
            //     NOT: ReflectedType namespace.İnterfaceAdı demektir.
            // Alt satırdaki namespace+interfaceAdı+methodName(parametre)  
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            //
            // Parametrelerin her biri için aralarına , koy demek. ?? varsa sol taraf yok ise sağ taraf eklenecek
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            //
            // Bellekte böyle bir cache anahtarı var mı
            if (_cacheManager.IsAdd(key))
            {
                //
                // Methodu hiç çalıştırmadan geri döndür demek. Çünkü zaten cache de var. Methodun return değeri, cache deki data olsun demek
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            //
            // Methodu devam ettit demek. Bu üstüne yazdığımı methoddan kastımız
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
