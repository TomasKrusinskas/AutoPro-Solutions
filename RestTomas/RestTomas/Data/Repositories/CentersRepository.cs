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
        Task<Center> Create();
        Task<Center> Put();
        Task Delete();
    }

    public class CentersRepository : ICentersRepository
    {
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

        public async Task<Center> Create()
        {
            return new Center()
            {
                Name = "name",
                Description = "desc"
            };
        }

        public async Task<Center> Put()
        {
            return new Center()
            {
                Name = "name",
                Description = "desc"
            };
        }

        public async Task Delete()
        {

        }
    }
}