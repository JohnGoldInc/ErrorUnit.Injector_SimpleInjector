using ErrorUnit.Interfaces;
//using ErrorUnit.Injector_SimpleInjector.InterceptionExtensions;
using SimpleInjector;

namespace ErrorUnit.Injector_SimpleInjector
{
    /// <summary>
    /// The Injector link for SimpleInjector
    /// </summary>
    public class ErrorUnitInjector : IInjector
    {
        private static Container container = null;
        /// <summary>
        /// The json serializer to use
        /// </summary>
        public static IErrorUnitCentral ErrorUnitCentral;

        /// <summary>
        /// Links the injector.
        /// </summary>
        /// <typeparam name="C"></typeparam>
        /// <param name="ioc">The ioc.</param>
        /// <param name="errorUnitCentral">The ErrorUnitCentral.Instance</param>
        /// <returns></returns>
        public C LinkInjector<C>(C ioc, IErrorUnitCentral errorUnitCentral)
        {
            container = ioc as Container;
            //container.InterceptWith<ErrorUnit.Models.ErrorUnitInterceptor>(t => t != typeof(ErrorUnit.Models.ErrorUnitInterceptor) );
            container.InterceptWithErrorUnit();
            ErrorUnitInjector.ErrorUnitCentral = errorUnitCentral;
            //ErrorUnitInjector.ErrorUnitCentral.serializerSettings.Converters.Add(new ProxiedTypeSerializer());
            return ioc;
        }
    }
}
