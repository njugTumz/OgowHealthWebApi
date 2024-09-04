using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace healthmanagementapi.Entities
{
    public class Permission
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }  // e.g., ManageHealthFacilities, ManagePatients
        public virtual ICollection<Role> Roles { get; set; }
    }
}
