using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models
{
    public class PasswordEntry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Kayıt Tanımı")]
        public string Title { get; set; }

        [StringLength(500)]
        [Display(Name = "URL")]
        public string Url { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // YENİ ÖZELLİKLER
        public DateTime LastAccessDate { get; set; } = DateTime.Now;
        public bool IsFavorite { get; set; } = false;
        public int PasswordStrength { get; set; } = 0; // 0=Weak, 1=Medium, 2=Strong
    }
}