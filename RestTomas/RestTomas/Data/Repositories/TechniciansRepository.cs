using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTomas.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace RestTomas.Data.Repositories
{
    public interface ITechnicianRepository
    {
        Task<Technician> GetAsync(int centerId, int technicianId);
        Task<List<Technician>> GetAsync(int centerId);
        Task InsertAsync(Technician technician);
        Task UpdateAsync(Technician technician);
        Task DeleteAsync(Technician technician);
    }

    public class TechniciansRepository : ITechnicianRepository
    {
        private readonly RestContext _demoRestContext;
        public TechniciansRepository(RestContext demoRestContext)
        {
            _demoRestContext = demoRestContext;
        }

        public async Task<Technician> GetAsync(int centerId, int technicianId)
        {
            return await _demoRestContext.Technicians.FirstOrDefaultAsync(o => o.CenterId == centerId && o.Id == technicianId);
        }

        public async Task<List<Technician>> GetAsync(int centerId)
        {
            return await _demoRestContext.Technicians.Where(o => o.CenterId == centerId).ToListAsync();
        }

        public async Task InsertAsync(Technician technician)
        {
            _demoRestContext.Technicians.Add(technician);
            await _demoRestContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Technician technician)
        {
            _demoRestContext.Technicians.Update(technician);
            await _demoRestContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Technician technician)
        {
            _demoRestContext.Technicians.Remove(technician);
            await _demoRestContext.SaveChangesAsync();
        }
    }
}
