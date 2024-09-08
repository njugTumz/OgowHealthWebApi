namespace healthmanagementapi.Dtos
{
    public class PatientDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? HealthFacilityID { get; set; }
    }

}
