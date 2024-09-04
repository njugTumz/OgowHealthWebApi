using System.ComponentModel.DataAnnotations.Schema;

namespace healthmanagementapi.Entities
{
    public class UserRole:BaseEntityCommon
    {
        [ForeignKey("User")]
        public string ApplicationUserID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Role")]
        public string ApplicationRoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
