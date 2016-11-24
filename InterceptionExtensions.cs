using System;
using System.Linq.Expressions;
using Castle.DynamicProxy;
using SimpleInjector;

public static class InterceptorExtensions
{
    private static readonly ProxyGenerator generator = new ProxyGenerator();

    private static readonly Func<Type, object, IInterceptor, object> createProxy =
        (p, t, i) => generator.CreateInterfaceProxyWithTarget(p, t, i);

    public static void InterceptWith<TInterceptor>(this Container c,
        Predicate<Type> predicate)
        where TInterceptor : class, IInterceptor
    {
        c.ExpressionBuilt += (s, e) =>
        {
            if (predicate(e.RegisteredServiceType))
            {
                var interceptorExpression =
                    c.GetRegistration(typeof(TInterceptor), true).BuildExpression();

                e.Expression = Expression.Convert(
                    Expression.Invoke(Expression.Constant(createProxy),
                        Expression.Constant(e.RegisteredServiceType, typeof(Type)),
                        e.Expression,
                        interceptorExpression),
                    e.RegisteredServiceType);
            }
        };
    }

    private static readonly Func<object, object> createErrorUnitProxy =
        (o) => typeof(ErrorUnit.ErrorUnitCentral).GetMethod("Wrap")
                                                 .MakeGenericMethod(o.GetType())
                                                 .Invoke(null, new object[] { o });

    public static void InterceptWithErrorUnit(this Container c)
    {
        c.ExpressionBuilt += (s, e) =>
        {
            e.Expression = Expression.Convert(
                    Expression.Invoke(Expression.Constant(createErrorUnitProxy),
                        e.Expression),
                    e.RegisteredServiceType);

        };

    }

}