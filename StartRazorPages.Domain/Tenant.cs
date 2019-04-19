using System;
using System.ComponentModel.DataAnnotations;

namespace StartRazorPages.Domain
{
    public class Tenant
    {   
        public Tenant()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Host { get; set; }

        [Required]
        [MaxLength(255)]
        public string ConnectionString { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

    }
}
