using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StartRazorPages.Domain;
using StartRazorPages.Persistence;
using Microsoft.AspNetCore.Authorization;

namespace StartRazorPages.Areas.Admin.Pages.Tenants
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly StartRazorPages.Persistence.ApplicationDbContext _context;

        public IndexModel(StartRazorPages.Persistence.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Tenant> Tenant { get;set; }

        public async Task OnGetAsync()
        {
            Tenant = await _context.Tenants.ToListAsync();
        }
    }
}
