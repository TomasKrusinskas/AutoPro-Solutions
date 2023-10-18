using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestTomas.Data.Dtos.Jobs;
using RestTomas.Data.Entities;
using RestTomas.Data.Repositories;

namespace RestTomas.Controllers
{
    [ApiController]
    [Route("api/centers/{centerId}/technicians/{technicianId}/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IMapper _mapper;
        private readonly ICentersRepository _centersRepository;
        private readonly IJobRepository _jobRepository;

        public JobsController(ITechnicianRepository technicianRepository, IMapper mapper, ICentersRepository centersRepository, IJobRepository jobRepository)
        {
            _technicianRepository = technicianRepository;
            _mapper = mapper;
            _centersRepository = centersRepository;
            _jobRepository = jobRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<JobDto>> GetAllAsync(int centerId, int technicianId)
        {
            var technicians = await _jobRepository.GetAsync(centerId, technicianId);
            return technicians.Select(o => _mapper.Map<JobDto>(o));
        }

        // /api/centers/1/techninians/2/jobs/1
        [HttpGet("{jobId}")]
        public async Task<ActionResult<JobDto>> GetAsync(int centerId, int technicianId, int jobId)
        {
            var center = await _jobRepository.GetAsync(centerId, technicianId, jobId);
            if (center == null) return NotFound();

            return Ok(_mapper.Map<JobDto>(center));
        }

        [HttpPost]
        public async Task<ActionResult<JobDto>> PostAsync(int centerId,int technicianId, CreateJobDto jobDto)
        {
            var center = await _centersRepository.Get(centerId);
            if (center == null) return NotFound($"Couldn't find a center with id of {centerId}");

            var technician  = await _technicianRepository.GetAsync(technicianId);
            if (technician == null) return NotFound($"Couldn't find a technician with id of {technicianId}");


            var job = _mapper.Map<Job>(jobDto);
            job.TechnicianId = technicianId;

            await _jobRepository.InsertAsync(job);

            return Created($"/api/centers/{centerId}/technicians/{technicianId}/jobs/{job.Id}", _mapper.Map<JobDto>(job));
        }


        [HttpPut("{jobId}")]
        public async Task<ActionResult<JobDto>> PostAsync(int centerId, int technicianId, int jobId, UpdateJobDto jobDto)
        {
            var center = await _centersRepository.Get(centerId);
            if (center == null) return NotFound($"Couldn't find a topic with id of {centerId}");

            var technician = await _technicianRepository.GetAsync(technicianId);
            if (technician == null) return NotFound($"Couldn't find a technician with id of {technicianId}");

            var oldjob = await _jobRepository.GetAsync(centerId, technicianId, jobId);
            if (oldjob == null)
                return NotFound();


            _mapper.Map(jobDto, oldjob);

            await _jobRepository.UpdateAsync(oldjob);

            return Ok(_mapper.Map<JobDto>(oldjob));
        }

        [HttpDelete("{jobId}")]
        public async Task<ActionResult> DeleteAsync(int centerId, int technicianId, int jobId)
        {
            var job = await _jobRepository.GetAsync(centerId, technicianId, jobId);
            if (job == null)
                return NotFound();

            await _jobRepository.DeleteAsync(job);
            //204
            return NoContent();
        }
    }
}
