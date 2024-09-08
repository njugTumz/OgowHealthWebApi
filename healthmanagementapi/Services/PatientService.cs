using healthmanagementapi.DB;
using healthmanagementapi.Entities;
using healthmanagementapi.Repository;
using Microsoft.EntityFrameworkCore;

namespace healthmanagementapi.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task CreatePatientAsync(Patient facility);
        Task UpdatePatientAsync(Patient facility);
        Task DeletePatientAsync(int id);
    }

    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;
        private readonly HealthDbContext _context;

        public PatientService(HealthDbContext context, IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
            _context = context;
        }

        public async Task CreatePatientAsync(Patient patient)
        {
            await _patientRepository.InsertAsync(patient);
            await _patientRepository.SaveAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.delAsync(id);
            await _patientRepository.SaveAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _patientRepository.Update(patient);
            await _patientRepository.SaveAsync();
        }
    }
}
