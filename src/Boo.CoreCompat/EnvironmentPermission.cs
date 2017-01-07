#if DNXCORE50
namespace System.Security.Permissions
{
    public sealed class EnvironmentPermission
    {
        private bool m_unrestricted;

        public EnvironmentPermission(PermissionState state)
        {
            if (state == PermissionState.Unrestricted)
            {
                this.m_unrestricted = true;
                return;
            }
            if (state == PermissionState.None)
            {
                this.m_unrestricted = false;
                return;
            }
            throw new ArgumentException("Argument_InvalidPermissionState");
        }
    }
}
#endif