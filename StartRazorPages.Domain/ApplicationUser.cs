using Microsoft.AspNetCore.Identity;

namespace StartRazorPages.Domain
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int TenantId { get; set; }

        public Tenant Tenant { get; set; }
    }
}
