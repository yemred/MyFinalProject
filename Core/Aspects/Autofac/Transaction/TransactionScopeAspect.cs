using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    //
                    // Method içindeki işlemlemler başarılıysa tamamla
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    //
                    // Method içindeki işlmelerde hata varsa iptal et. Dispose et
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
