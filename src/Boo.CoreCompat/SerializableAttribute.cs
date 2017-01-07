#if DNXCORE50
namespace System
{
    public class SerializableAttribute : Attribute
    {
    }
}
namespace System.Runtime.Serialization
{
    using System;
    // to prevent treating this namespace as empty
    public class NoDeclaration
    {
    }
}
#endif