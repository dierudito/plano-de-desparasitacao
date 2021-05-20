using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DM.Desparasitacao.CrossCutting.Filters.Reflection
{
    public static class AssemblyHelper
    {
        public static string GetAssemblyVersion()
        {
            var assembly = Assembly.GetEntryAssembly();
            if ((object)assembly == null)
                assembly = Assembly.GetCallingAssembly();
            return AssemblyHelper.GetAssemblyVersion(assembly);
        }

        public static string GetAssemblyVersion(Assembly assembly)
        {
            var str = (string)null;
            try
            {
                str = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
            }
            catch
            {
                str = (string)null;
            }
            return str;
        }

        public static IEnumerable<Tuple<Type, Type>> GetTypesThatImplementsInterface(
            Assembly assembly,
            Func<Type, bool> interfaceTypeCriteria)
        {
            return ((IEnumerable<Type>)assembly.GetExportedTypes()).Where<Type>((Func<Type, bool>)(t => !t.IsAbstract && !t.IsValueType && !t.IsInterface)).SelectMany<Type, Tuple<Type, Type>>((Func<Type, IEnumerable<Tuple<Type, Type>>>)(t => AssemblyHelper.GetMappings(t, interfaceTypeCriteria)));
        }

        private static IEnumerable<Tuple<Type, Type>> GetMappings(
            Type implementationType,
            Func<Type, bool> interfaceTypeCriteria)
        {
            return ((IEnumerable<Type>)implementationType.GetInterfaces()).Where<Type>((Func<Type, bool>)(interfaceType => interfaceTypeCriteria(interfaceType))).Select<Type, Tuple<Type, Type>>((Func<Type, Tuple<Type, Type>>)(interfaceType => new Tuple<Type, Type>(interfaceType, implementationType)));
        }

        public static bool HasBaseInterface(Type interfaceType, Type baseInterfaceType) => ((IEnumerable<Type>)interfaceType.GetInterfaces()).Any<Type>((Func<Type, bool>)(i =>
        {
            if (i.IsGenericType && i.GetGenericTypeDefinition() == baseInterfaceType)
                return true;
            return !i.IsGenericType && i == baseInterfaceType;
        }));
    }
}
