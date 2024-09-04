using healthmanagementapi.DB;
using healthmanagementapi.Entities;
using healthmanagementapi.Repository;
using Microsoft.EntityFrameworkCore;

namespace healthmanagementapi.Services
{
    public interface IHealthFacilityService
    {
        Task<IEnumerable<HealthFacility>> GetAllFacilitiesAsync();
        Task<HealthFacility> GetFacilityByIdAsync(int id);
        Task CreateFacilityAsync(HealthFacility facility);
        Task UpdateFacilityAsync(HealthFacility facility);
        Task DeleteFacilityAsync(int id);
    }
    public class HealthFacilityService: IHealthFacilityService
    {
        private readonly IRepository<HealthFacility> _facilityRepository;
        private readonly HealthDbContext _context;

        public HealthFacilityService(HealthDbContext context,IRepository<HealthFacility> facilityRepository)
        {
            _facilityRepository = facilityRepository;
            _context = context;
        }

        public async Task<IEnumerable<HealthFacility>> GetAllFacilitiesAsync()
        {
            var res = await _context.HealthFacilities.ToListAsync();
            return res;
        }

        public async Task<HealthFacility> GetFacilityByIdAsync(int id)
        {
            return await _facilityRepository.GetByIdAsync(id);
        }

        public async Task CreateFacilityAsync(HealthFacility facility)
        {
            await _facilityRepository.InsertAsync(facility);
            await  _facilityRepository.SaveAsync();
        }

        public async Task UpdateFacilityAsync(HealthFacility facility)
        {
            _facilityRepository.Update(facility);
            await _facilityRepository.SaveAsync();
        }

        public async Task DeleteFacilityAsync(int id)
        {
            await _facilityRepository.delAsync(id);
            await _facilityRepository.SaveAsync();
        }
    }

}
