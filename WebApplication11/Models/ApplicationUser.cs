using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication11.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<PasswordEntry> PasswordEntries { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

        public ApplicationUser()
        {
            PasswordEntries = new List<PasswordEntry>();
            Categories = new List<Category>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}