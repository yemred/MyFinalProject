using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //
    // Class larda geçerli, Methodlarda geçerli, Birden fazla kullanılabilir demek
    //AutoFac AoP altyapısını sağlar. Bu yüzden Core katmanınada AutoFac paketlerini manage nuget dan yükle
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {

        // Hangi attriube önce çalışsın. Loglama,validation
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
