using System;
using System.Globalization;
using System.Reflection;

namespace ErrorUnit.Injector_SimpleInjector
{
    /// <summary>
    /// By returning a Proxied Type we can indicate a special method of deserialization
    /// </summary>
    /// <seealso cref="System.Type" />
    public class ProxiedType : Type
    {
        private Type realType;
        public ProxiedType(Type realType)
        {
            this.realType = realType;
        }

        public override Assembly Assembly => realType.Assembly;

        public override string AssemblyQualifiedName => realType.AssemblyQualifiedName;

        public override Type BaseType => realType.BaseType;

        public override string FullName => realType.FullName;

        public override Guid GUID => realType.GUID;

        public override Module Module => realType.Module;

        public override string Name => realType.Name;

        public override string Namespace => realType.Namespace;

        public override Type UnderlyingSystemType => realType.UnderlyingSystemType;

        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr) => realType.GetConstructors(bindingAttr);

        public override object[] GetCustomAttributes(bool inherit) => realType.GetCustomAttributes(inherit);

        public override object[] GetCustomAttributes(Type attributeType, bool inherit) => realType.GetCustomAttributes(attributeType, inherit);

        public override Type GetElementType() => realType.GetElementType();

        public override EventInfo GetEvent(string name, BindingFlags bindingAttr) => realType.GetEvent(name, bindingAttr);

        public override EventInfo[] GetEvents(BindingFlags bindingAttr) => realType.GetEvents(bindingAttr);

        public override FieldInfo GetField(string name, BindingFlags bindingAttr) => realType.GetField(name, bindingAttr);

        public override FieldInfo[] GetFields(BindingFlags bindingAttr) => realType.GetFields(bindingAttr);

        public override Type GetInterface(string name, bool ignoreCase) => realType.GetInterface(name, ignoreCase);

        public override Type[] GetInterfaces() => realType.GetInterfaces();

        public override MemberInfo[] GetMembers(BindingFlags bindingAttr) => realType.GetMembers(bindingAttr);

        public override MethodInfo[] GetMethods(BindingFlags bindingAttr) => realType.GetMethods(bindingAttr);

        public override Type GetNestedType(string name, BindingFlags bindingAttr) => realType.GetNestedType(name, bindingAttr);

        public override Type[] GetNestedTypes(BindingFlags bindingAttr) => realType.GetNestedTypes(bindingAttr);

        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr) => realType.GetProperties(bindingAttr);

        public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
            => realType.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);

        public override bool IsDefined(Type attributeType, bool inherit) => realType.IsDefined(attributeType, inherit);

        protected override TypeAttributes GetAttributeFlagsImpl()
        {
            return (TypeAttributes)typeof(Type).GetMethod("GetAttributeFlagsImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { });
        }

        protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return (ConstructorInfo)typeof(Type).GetMethod("GetConstructorImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { bindingAttr, binder, callConvention, types, modifiers });
        }

        protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return (MethodInfo)typeof(Type).GetMethod("GetMethodImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { name, bindingAttr, binder, callConvention, types, modifiers });
        }

        protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return (PropertyInfo)typeof(Type).GetMethod("GetPropertyImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { name, bindingAttr, binder, returnType, types, modifiers });
        }

        protected override bool HasElementTypeImpl()
        {
            return (bool)typeof(Type).GetMethod("HasElementTypeImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { });
        }

        protected override bool IsArrayImpl()
        {
            return (bool)typeof(Type).GetMethod("IsArrayImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { });
        }

        protected override bool IsByRefImpl()
        {
            return (bool)typeof(Type).GetMethod("IsByRefImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { });
        }

        protected override bool IsCOMObjectImpl()
        {
            return (bool)typeof(Type).GetMethod("IsCOMObjectImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { });
        }

        protected override bool IsPointerImpl()
        {
            return (bool)typeof(Type).GetMethod("IsPointerImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { });
        }

        protected override bool IsPrimitiveImpl()
        {
            return (bool)typeof(Type).GetMethod("IsPrimitiveImpl", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(realType, new object[] { });
        }
    }
}
