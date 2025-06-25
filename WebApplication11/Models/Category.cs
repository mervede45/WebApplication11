using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<PasswordEntry> PasswordEntries { get; set; }
    }
}