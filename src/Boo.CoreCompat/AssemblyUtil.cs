#if DNXCORE50
namespace Boo.CoreCompat
{
    using System.Reflection;
    using System.Runtime.Loader;

    public class AssemblyUtil
    {
        private static AssemblyLoadContext LoadContext;
        static AssemblyUtil()
        {
            LoadContext = AssemblyLoadContext.GetLoadContext(typeof(AssemblyUtil).GetTypeInfo().Assembly);
        }

        public static Assembly LoadFrom(string assemblyPath)
        {
            return LoadContext.LoadFromAssemblyPath(assemblyPath);
        }
    }
}
#endif