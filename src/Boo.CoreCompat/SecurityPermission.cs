#if DNXCORE50
namespace System.Security.Permissions
{
    public sealed class SecurityPermission
    {
        private SecurityPermissionFlag m_flags;

        public SecurityPermission(SecurityPermissionFlag flag)
        {
            //this.VerifyAccess(flag);
            //this.SetUnrestricted(false);
            this.m_flags = flag;
        }
    }
}
#endif