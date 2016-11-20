using ErrorUnit.Injector_SimpleInjector.InterceptionExtensions;
using ErrorUnit.Interfaces;
using ErrorUnit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ErrorUnit.Injector_SimpleInjector
{
    /// <summary>
    /// Creates an Error Precondition from a SimpleInjector error Interception.
    /// </summary>
    /// <seealso cref="ErrorUnit.Interfaces.aErrorPrecondition" />
    public class ErrorPrecondition : aErrorPrecondition
    {
        private IInvocation invocation = null;
        private MethodBase _methodBase = null;
        private MethodBase methodBase { get { return _methodBase ?? (_methodBase = invocation.GetConcreteMethod()); } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorPrecondition"/> class.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        public ErrorPrecondition(IInvocation invocation)
        {
            this.invocation = invocation;
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public override TypeNameAndObjectValue[] Arguments { get { return invocation.Arguments == null ? null : invocation.Arguments.Select(a => new TypeNameAndObjectValue(a == null ? "" : a.GetType().FullName, a)).ToArray(); } set { } }

        /// <summary>
        /// Gets the full type name of the class the method that failed is in.
        /// </summary>
        /// <value>
        /// The full type name of the class.
        /// </value>
        public override string InvocationClassName { get { return methodBase.ReflectedType.FullName;  } set { } }

        /// <summary>
        /// Gets the invocation class.
        /// </summary>
        /// <value>
        /// The invocation class.
        /// </value>
        public override TypeNameAndObjectValue InvocationClassValue { get { return invocation.InvocationTarget == null ? null : new TypeNameAndObjectValue(invocation.InvocationTarget.GetType().FullName, invocation.InvocationTarget);  } set { } }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        /// <value>
        /// The name of the method.
        /// </value>
        public override string MethodName { get { return methodBase.Name; } set { } }

    }
}
