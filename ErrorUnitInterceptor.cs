using ErrorUnit.Injector_SimpleInjector.InterceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErrorUnit.Injector_SimpleInjector
{
    internal class ErrorUnitInterceptor : IInterceptor
    {
        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        public void Intercept(IInvocation invocation)
        {
            var stackInfo = new ErrorPrecondition(invocation);
            ErrorUnitInjector.ErrorUnitCentral.CurrentStack_Add(stackInfo);
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                ErrorUnitInjector.ErrorUnitCentral.ThrowErrorStack(ex);
            }
            finally
            {
                stackInfo.End = DateTime.Now;
            }
            ErrorUnitInjector.ErrorUnitCentral.CleanUp(stackInfo.End.Value);
        }

    }
}