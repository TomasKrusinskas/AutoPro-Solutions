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
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IMapper _mapper;
        private readonly ICentersRepository _centersRepository;
        public TechniciansController(ITechnicianRepository technicianRepository, IMapper mapper, ICentersRepository centersRepository)
        {
            _technicianRepository = technicianRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TechnicianDto>> GetAllAsync(int centerid)
        {
            var centers = await _technicianRepository.GetAsync(centerid);
            return centers.Select(o => _mapper.Map<TechnicianDto>(o));
        }

        // /api/centers/1/techninians/2
        [HttpGet("{techninianId}")]
        public async Task<ActionResult<TechnicianDto>> GetAsync(int centerId, int techninianId)
        {
            var center = await _technicianRepository.GetAsync(centerId, techninianId);
            if (center == null) return NotFound();

            return Ok(_mapper.Map<TechnicianDto>(center));
        }

        [HttpPost]
        public async Task<ActionResult<TechnicianDto>> PostAsync(int centerId, CreateTechnicianDto technicianDto)
        {
            var center = await _centersRepository.Get(centerId);
            if (center == null) return NotFound($"Couldn't find a center with id of {centerId}");

            var technician = _mapper.Map<Technician>(technicianDto);
            technician.CenterId = centerId;

            await _technicianRepository.InsertAsync(technician);

            return Created($"/api/centers/{centerId}/technicians/{technician.Id}", _mapper.Map<TechnicianDto>(technician));
        }


        [HttpPut("{techninianId}")]
        public async Task<ActionResult<TechnicianDto>> PostAsync(int centerId, int techninianId ,UpdateTechnicianDto technicianDto)
        {
            var center = await _centersRepository.Get(centerId);
            if (center == null) return NotFound($"Couldn't find a topic with id of {centerId}");

            var oldtechnician = await _technicianRepository.GetAsync(centerId, techninianId);
            if (oldtechnician == null)
                return NotFound();


            _mapper.Map(technicianDto, oldtechnician);

            await _technicianRepository.UpdateAsync(oldtechnician);

            return Ok(_mapper.Map<TechnicianDto>(oldtechnician));
        }

        [HttpDelete("{techninianId}")]
        public async Task<ActionResult> DeleteAsync(int centerId, int technicianId)
        {
            var technician = await _technicianRepository.GetAsync(centerId, technicianId);
            if (technician == null)
                return NotFound();

            await _technicianRepository.DeleteAsync(technician);
            //204
            return NoContent();
        }
    }
}
