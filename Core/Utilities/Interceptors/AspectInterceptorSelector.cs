using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        //
        // Aşşağıda yazdığımız kod çalıştırmak istediğimiz methodun üstüne bakıyor, ordaki interceptorları ( ASPECT ) leri buluyor, onları çalıştırıyor.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //
            // Class'ın  attributlarını oku getir
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //
            // Methodun attributlarını oku getir
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            //
            // Bütün methodlara uygular istisnasız
            // classAttributes.Add(new ExceptionLogAspects(typeof(FileLogger)));

            //
            // Attribute çalışmasını sırasını priority'e göre yani önceliğe göre çalıştır
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
