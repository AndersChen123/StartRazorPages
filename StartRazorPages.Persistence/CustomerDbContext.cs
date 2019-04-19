using StartRazorPages.Application.Interfaces;
using StartRazorPages.Domain;
using Microsoft.EntityFrameworkCore;

namespace StartRazorPages.Persistence
{
    public class CustomerDbContext : DbContext
    {
        private readonly Tenant _tenant;

        //public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        //    : base(options)
        //{
        //}

        // Comment this ctor, use above ctor for migrations.
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options,
                            ITenantProvider tenantProvider)
            : base(options)
        {
            _tenant = tenantProvider.GetTenant();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Comment this for migrations.
            optionsBuilder.UseSqlServer(_tenant.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
