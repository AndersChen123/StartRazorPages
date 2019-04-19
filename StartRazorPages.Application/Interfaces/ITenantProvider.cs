
using StartRazorPages.Domain;

namespace StartRazorPages.Application.Interfaces
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
    }
}
