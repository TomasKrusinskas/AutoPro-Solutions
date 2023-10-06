using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestTomas.Data.Dtos.Centers;
using RestTomas.Data.Entities;
using RestTomas.Data.Repositories;

namespace RestTomas.Controllers
{
    [ApiController]
    [Route("api/Centers")]
    public class CentersController : ControllerBase
    {
        private readonly ICentersRepository _centersRepository;
        private readonly IMapper _mapper;
        public CentersController(ICentersRepository centersRepository, IMapper mapper)
        {
            _centersRepository = centersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CenterDto>> GetAll()
        {
            return (await _centersRepository.GetAll()).Select(o => _mapper.Map<CenterDto>(o));
        }

        [HttpGet("{id}")]
        public async Task<Center> Get(int id)
        {
            return await _centersRepository.Get(id);
        }
    }
}
