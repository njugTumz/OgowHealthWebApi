using Microsoft.AspNetCore.Identity;
using System.Security;

namespace healthmanagementapi.Entities
{
    public class Role:IdentityRole
    {
        //public string Name { get; set; }  // e.g., Super Admin, Admin, Health Worker
        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Permission> Permissions { get; set; }
    }
}
