using healthmanagementapi.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthmanagementapi.Dtos
{
    public class AssignRoleModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }

}
