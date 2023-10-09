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
        public async Task<ActionResult<CenterDto>> Get(int id)
        {
            var center = await _centersRepository.Get(id);
            if (center == null) return NotFound($"Center with id '{id}' not found.");


            return Ok(_mapper.Map<CenterDto>(center));
        }

        [HttpPost]
        public async Task<ActionResult<CenterDto>> Post(CreateCenterDto centerDto)
        {
            var center = _mapper.Map<Center>(centerDto);

            await _centersRepository.Create(center);

            return Created($"/api/centers/{center.id}", _mapper.Map<CenterDto>(center));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CenterDto>> Put(int id, UpdateCenterDto centerDto)
        {
            var center = await _centersRepository.Get(id);
            if (center == null) return NotFound($"Center with id '{id}' not found.");

            //center.Name = centerDto.Name;
            _mapper.Map(centerDto, center);

            await _centersRepository.Put(center);

            return Ok(_mapper.Map<CenterDto>(center));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CenterDto>> Delete(int id)
        {
            var center = await _centersRepository.Get(id);
            if (center == null) return NotFound($"Center with id '{id}' not found.");

            await _centersRepository.Delete(center);

            //204
            return NoContent();
        }
    }
}
