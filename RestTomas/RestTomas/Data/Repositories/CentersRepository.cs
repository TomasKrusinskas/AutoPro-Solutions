using System;
using RestTomas.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestTomas.Data.Dtos.Centers;

namespace RestTomas.Data.Repositories
{

    public interface ICentersRepository
    {
        Task<IEnumerable<CenterDto>> GetAll();
        Task<Center> Get(int id);
        Task<Center> Create(Center center);
        Task<Center> Put(Center center);
        Task Delete(Center center);
    }

    public class CentersRepository : ICentersRepository
    {
        private readonly RestContext _restContext;
        private readonly IMapper _mapper;
        public CentersRepository(RestContext restContext, IMapper mapper)
        {
            _restContext = restContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CenterDto>> GetAll()
        {
            var centers = await _restContext.Centers.ToListAsync();
            var centerDtos = _mapper.Map<IEnumerable<CenterDto>>(centers);

            return centerDtos;
        }
        public async Task<Center> Get(int id)
        {
            return new Center()
            {
                id = id,
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
            _restContext.Centers.Remove(center);
            await _restContext.SaveChangesAsync();
        }
    }
}