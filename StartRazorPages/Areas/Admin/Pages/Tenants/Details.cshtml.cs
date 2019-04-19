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
    public class DetailsModel : PageModel
    {
        private readonly StartRazorPages.Persistence.ApplicationDbContext _context;

        public DetailsModel(StartRazorPages.Persistence.ApplicationDbContext context)
        {
            _context = context;
        }

        public Tenant Tenant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tenant = await _context.Tenants.FirstOrDefaultAsync(m => m.Id == id);

            if (Tenant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
