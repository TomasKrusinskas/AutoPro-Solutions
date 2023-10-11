using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestTomas.Data.Entities;

namespace RestTomas.Data.Repositories
{
    public interface ITechnicianRepository
    {
        Task<Techninian> GetAsync(int centerId, int technicianId);
        Task<List<Techninian>> GetAsync(int centerId);
        Task InsertAsync(Techninian technician);
        Task UpdateAsync(Techninian technician);
        Task DeleteAsync(Techninian technician);
    }

    public class TechniniansRepository : ITechnicianRepository
    {
        private readonly RestContext _demoRestContext;
        public TechniniansRepository(RestContext demoRestContext)
        {
            _demoRestContext = demoRestContext;
        }

        public async Task<Techninian> GetAsync(int centerId, int technicianId)
        {
            return await _demoRestContext.Technicians.FirstOrDefaultAsync(o => o.CenterId == centerId && o.Id == technicianId);
        }

        public async Task<List<Techninian>> GetAsync(int centerId)
        {
            return await _demoRestContext.Technicians.Where(o => o.CenterId == centerId).ToListAsync();
        }

        public async Task InsertAsync(Techninian technician)
        {
            _demoRestContext.Technicians.Add(technician);
            await _demoRestContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Techninian technician)
        {
            _demoRestContext.Technicians.Update(technician);
            await _demoRestContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Techninian technician)
        {
            _demoRestContext.Technicians.Remove(technician);
            await _demoRestContext.SaveChangesAsync();
        }
    }
}
