using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartRazorPages.Domain;
using StartRazorPages.Persistence;
using Microsoft.AspNetCore.Authorization;

namespace StartRazorPages.Areas.Admin.Pages.Tenants
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly StartRazorPages.Persistence.ApplicationDbContext _context;

        public CreateModel(StartRazorPages.Persistence.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tenant Tenant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tenants.Add(Tenant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}