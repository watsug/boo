#if DNXCORE50
namespace System.Security.Permissions
{
    /// <summary>Specifies whether a permission should have all or no access to resources at creation.</summary>
    [Serializable]
    public enum PermissionState
    {
        /// <summary>Full access to the resource protected by the permission.</summary>
        Unrestricted = 1,
        /// <summary>No access to the resource protected by the permission.</summary>
        None = 0
    }
}
#endif