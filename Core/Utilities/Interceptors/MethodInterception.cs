using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {

        //
        // Invocation demek, o an hangi methodun üzerinde kullanıyorsan o method demektir.
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        //
        // Method = invocation
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            //
            // Methodun başında çalışır
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    //
                    // Method başarılı olursa
                    OnSuccess(invocation);
                }
            }
            //
            // Methodun sonunda çalışır
            OnAfter(invocation);
        }
    }
}
