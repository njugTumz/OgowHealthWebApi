using healthmanagementapi.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthmanagementapi.Dtos
{
    public class HealthWorkerDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? HealthFacilityID { get; set; }
      
    }

}
