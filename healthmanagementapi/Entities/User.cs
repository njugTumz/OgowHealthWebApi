using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthmanagementapi.Entities
{
    public class User:IdentityUser
    {
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public string Name { get; set; }

        [ForeignKey("Role")]
        public string? ApplicationRoleID { get; set; }
        public virtual Role Role { get; set; }


        [ForeignKey("HealthFacility")]
        public int? HealthFacilityID { get; set; }
        public HealthFacility HealthFacility { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
