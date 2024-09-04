namespace healthmanagementapi.Entities
{
    public class HealthWorker:BaseEntityCommon
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int? HealthFacilityID { get; set; }
        public virtual HealthFacility HealthFacility { get; set; }
    }
}
