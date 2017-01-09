#if DNXCORE50
namespace System.Security
{
    [AttributeUsage(AttributeTargets.Module, AllowMultiple = true, Inherited = false)]
    public class UnverifiableCodeAttribute : Attribute
    {
    }
}
#endif