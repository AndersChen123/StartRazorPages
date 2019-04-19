using System.ComponentModel.DataAnnotations;

namespace StartRazorPages.Domain
{
    public class Customer
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Company { get; set; }

        [StringLength(50)]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }
    }
}
