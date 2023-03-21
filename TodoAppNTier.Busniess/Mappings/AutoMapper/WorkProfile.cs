﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Dtos.WorkDtos;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.Busniess.Mappings.AutoMapper
{
    public class WorkProfile: Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDto>().ReverseMap();// Tersinide yap
            CreateMap<Work, WorkUpdateDto>().ReverseMap();// Tersinide yap
            CreateMap<Work, WorkCreateDto>().ReverseMap();// Tersinide yap
            CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();// Tersinide yap
        }
    }
}
