using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTomas.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace RestTomas.Data.Repositories
{
    public interface IJobRepository
    {
        Task<Job> GetAsync(int centerId, int technicianId, int jobId);
        Task<List<Job>> GetAsync(int centerId, int technicianId);
        Task InsertAsync(Job job);
        Task UpdateAsync(Job job);
        Task DeleteAsync(Job job);
    }
    public class JobsRepository : IJobRepository
    {
        private readonly RestContext _demoRestContext;
        public JobsRepository(RestContext demoRestContext)
        {
            _demoRestContext = demoRestContext;
        }

        public async Task<Job> GetAsync(int centerId, int technicianId, int jobId)
        {
            return await _demoRestContext.Jobs.FirstOrDefaultAsync(o => o.CenterId == centerId && o.TechnicianId == technicianId && o.Id == jobId);
        }

        public async Task<List<Job>> GetAsync(int centerId, int technicianId)
        {
            return await _demoRestContext.Jobs.Where(o => o.CenterId == centerId && o.TechnicianId == technicianId).ToListAsync();

        }

        public async Task InsertAsync(Job job)
        {
            _demoRestContext.Jobs.Add(job);
            await _demoRestContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Job job)
        {
            _demoRestContext.Jobs.Update(job);
            await _demoRestContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Job job)
        {
            _demoRestContext.Jobs.Remove(job);
            await _demoRestContext.SaveChangesAsync();
        }
    }
}
