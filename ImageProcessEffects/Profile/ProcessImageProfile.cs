using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageProcessEffects.Core.DTO.ProcessImageDTO;
using ImageProcessEffects.DTO.Input;

namespace ImageProcessEffects.Profile
{
    public class ProcessImageProfile : AutoMapper.Profile
    {
        public ProcessImageProfile()
        {
            CreateMap<ProcessImagesInputDTO, ProcessDataImageDTO>();
        }
    }
}
