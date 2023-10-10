using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestTomas.Data.Entities;

namespace RestTomas.Data.Repositories
{
    public interface ITechninianRepository
    {
        Task<Techninian> GetAsync(int centerId, int techninianId);
        Task<List<Techninian>> GetAsync(int centerId);
        Task InsertAsync(Techninian technician);
        Task UpdateAsync(Techninian technician);
        Task DeleteAsync(Techninian technician);
    }

    public class TechniniansRepository : ITechninianRepository
    {
        private readonly RestContext _demoRestContext;
        public TechniniansRepository(RestContext demoRestContext)
        {
            _demoRestContext = demoRestContext;
        }

        public async Task<Techninian> GetAsync(int centerId, int techninianId)
        {
            return await _demoRestContext.Techninians.FirstOrDefaultAsync(o => o.CenterId == centerId && o.Id == techninianId);
        }

        public async Task<List<Techninian>> GetAsync(int centerId)
        {
            return await _demoRestContext.Techninians.Where(o => o.CenterId == centerId).ToListAsync();
        }

        public async Task InsertAsync(Techninian technician)
        {
            _demoRestContext.Techninians.Add(technician);
            await _demoRestContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Techninian technician)
        {
            _demoRestContext.Techninians.Update(technician);
            await _demoRestContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Techninian technician)
        {
            _demoRestContext.Techninians.Remove(technician);
            await _demoRestContext.SaveChangesAsync();
        }
    }
}
