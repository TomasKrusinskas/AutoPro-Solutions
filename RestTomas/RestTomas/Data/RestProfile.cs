﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestTomas.Data.Dtos.Centers;
using RestTomas.Data.Dtos.Techninians;
using RestTomas.Data.Entities;

namespace RestTomas.Data
{
    public class RestProfile : Profile
    {
        public RestProfile()
        {
            CreateMap<Center, CenterDto>();
            CreateMap<CreateCenterDto, Center>();
            CreateMap<UpdateCenterDto, Center>();

            CreateMap<CreateTechninianDto, Techninian>();
            CreateMap<UpdateTechninianDto, Techninian>();
            CreateMap<Techninian, TechninianDto>();
        }
    }
}
