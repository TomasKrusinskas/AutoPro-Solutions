using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestTomas.Data.Dtos.Techninians;
using RestTomas.Data.Entities;
using RestTomas.Data.Repositories;

namespace RestTomas.Controllers
{
    [ApiController]
    [Route("api/centers/{centerId}/technicians")]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechninianRepository _techninianRepository;
        private readonly IMapper _mapper;
        private readonly ICentersRepository _centersRepository;
        public TechniciansController(ITechninianRepository techninianRepository, IMapper mapper, ICentersRepository centersRepository)
        {
            _techninianRepository = techninianRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TechninianDto>> GetAllAsync(int centerid)
        {
            var centers = await _techninianRepository.GetAsync(centerid);
            return centers.Select(o => _mapper.Map<TechninianDto>(o));
        }

        // /api/centers/1/techninians/2
        [HttpGet("{techninianId}")]
        public async Task<ActionResult<TechninianDto>> GetAsync(int centerId, int techninianId)
        {
            var center = await _techninianRepository.GetAsync(centerId, techninianId);
            if (center == null) return NotFound();

            return Ok(_mapper.Map<TechninianDto>(center));
        }

        [HttpPost]
        public async Task<ActionResult<TechninianDto>> PostAsync(int centerId, CreateTechninianDto techninianDto)
        {
            var center = await _centersRepository.Get(centerId);
            if (center == null) return NotFound($"Couldn't find a center with id of {centerId}");

            var technician = _mapper.Map<Techninian>(techninianDto);
            technician.CenterId = centerId;

            await _techninianRepository.InsertAsync(technician);

            return Created($"/api/centers/{centerId}/technicians/{technician.Id}", _mapper.Map<TechninianDto>(technician));
        }


        [HttpPut("{techninianId}")]
        public async Task<ActionResult<TechninianDto>> PostAsync(int centerId, int techninianId ,UpdateTechninianDto techninianDto)
        {
            var center = await _centersRepository.Get(centerId);
            if (center == null) return NotFound($"Couldn't find a topic with id of {centerId}");

            var oldtechnician = await _techninianRepository.GetAsync(centerId, techninianId);
            if (oldtechnician == null)
                return NotFound();


            _mapper.Map(techninianDto, oldtechnician);

            await _techninianRepository.UpdateAsync(oldtechnician);

            return Ok(_mapper.Map<TechninianDto>(oldtechnician));
        }

        [HttpDelete("{techninianId}")]
        public async Task<ActionResult> DeleteAsync(int centerId, int techninianId)
        {
            var technician = await _techninianRepository.GetAsync(centerId, techninianId);
            if (technician == null)
                return NotFound();

            await _techninianRepository.DeleteAsync(technician);
            //204
            return NoContent();
        }
    }
}
