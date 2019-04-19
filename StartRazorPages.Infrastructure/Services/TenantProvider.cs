using StartRazorPages.Application.Interfaces;
using StartRazorPages.Domain;
using StartRazorPages.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace StartRazorPages.Infrastructure.Services
{
    public class TenantProvider : ITenantProvider
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private Tenant _tenant;
        private string _user;

        public TenantProvider(IHttpContextAccessor accessor, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;

            _user = accessor.HttpContext.User.Identity.Name;
        }

        public Tenant GetTenant()
        {
            if (_tenant != null) return _tenant;

            var user =  _userManager.FindByNameAsync(_user).Result;
            if (user != null)
            {
                _tenant = _dbContext.Tenants.FirstOrDefault(x => x.Id == user.TenantId);                
            }

            return _tenant;
        }
    }
}
