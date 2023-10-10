using RestTomas.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTomas.Data.Repositories;

namespace RestTomas.Data.Repositories
{

    public interface ICentersRepository
    {
        Task<IEnumerable<Center>> GetAll();
        Task<Center> Get(int id);
        Task<Center> Create(Center center);
        Task<Center> Put(Center center);
        Task Delete(Center center);
    }

    public class CentersRepository : ICentersRepository
    {
        private readonly RestContext _restContext;
        public CentersRepository(RestContext restContext)
        {
            _restContext = restContext;
        }

        public async Task<IEnumerable<Center>> GetAll()
        {
            return new List<Center>
            {
                new Center()
                {
                    Name = "name",
                    Description = "desc"
                },
                new Center()
                {
                    Name = "name",
                    Description = "desc"
                }
            };
        }

        public async Task<Center> Get(int id)
        {
            return new Center()
            {
                Name = "name",
                Description = "desc"
            };
        }

        public async Task<Center> Create(Center center)
        {
            _restContext.Centers.Add(center);
            await _restContext.SaveChangesAsync();

            return center;
        }

        public async Task<Center> Put(Center center)
        {
            return new Center()
            {
                Name = "name",
                Description = "desc"
            };
        }

        public async Task Delete(Center center)
        {

        }
    }
}