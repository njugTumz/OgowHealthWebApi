using healthmanagementapi.DB;
using healthmanagementapi.Entities;
using healthmanagementapi.Repository;
using Microsoft.EntityFrameworkCore;

namespace healthmanagementapi.Services
{
    public interface IHealthWorkerService
    {
        Task<IEnumerable<HealthWorker>> GetAllHealthWorkersAsync();
        Task<HealthWorker> GetHealthWorkerByIdAsync(int id);
        Task CreateHealthWorkerAsync(HealthWorker facility);
        Task UpdateHealthWorkerAsync(HealthWorker facility);
        Task DeleteHealthWorkerAsync(int id);
    }

    public class HealthWorkerService : IHealthWorkerService
    {
        private readonly IRepository<HealthWorker> _hwRepository;
        private readonly HealthDbContext _context;

        public HealthWorkerService(HealthDbContext context, IRepository<HealthWorker> hwRepository)
        {
            _hwRepository = hwRepository;
            _context = context;
        }
        public async Task CreateHealthWorkerAsync(HealthWorker hw)
        {
            await _hwRepository.InsertAsync(hw);
            await _hwRepository.SaveAsync();
        }

        public async Task DeleteHealthWorkerAsync(int id)
        {
            await _hwRepository.delAsync(id);
            await _hwRepository.SaveAsync();
        }

        public async Task<IEnumerable<HealthWorker>> GetAllHealthWorkersAsync()
        {
            return await _context.HealthWorkers.ToListAsync();
        }

        public async Task<HealthWorker> GetHealthWorkerByIdAsync(int id)
        {
            return await _hwRepository.GetByIdAsync(id);
        }

        public async Task UpdateHealthWorkerAsync(HealthWorker hw)
        {
            _hwRepository.Update(hw);
            await _hwRepository.SaveAsync();
        }
    }
}
