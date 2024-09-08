using System.ComponentModel.DataAnnotations.Schema;

namespace healthmanagementapi.Entities
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? HealthFacilityID { get; set; }
        public HealthFacility HealthFacility { get; set; }
    }
}
