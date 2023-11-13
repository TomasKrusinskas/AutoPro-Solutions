using AutoMapper;
using RestTomas.Data.Dtos.Centers;
using RestTomas.Data.Dtos.Technicians;
using RestTomas.Data.Dtos.Jobs;
using RestTomas.Data.Entities;
using RestTomas.Data.Dtos.Auth;

namespace RestTomas.Data
{
    public class RestProfile : Profile
    {
        public RestProfile()
        {
            CreateMap<Center, CenterDto>();
            CreateMap<CreateCenterDto, Center>();
            CreateMap<UpdateCenterDto, Center>();

            CreateMap<CreateTechnicianDto, Technician>();
            CreateMap<UpdateTechnicianDto, Technician>();
            CreateMap<Technician, TechnicianDto>();

            CreateMap<CreateJobDto, Job>();
            CreateMap<UpdateJobDto, Job>();
            CreateMap<Job, JobDto>();

            CreateMap<DemoRestUser, UserDto>();
        }
    }
}
