using AutoMapper;
using Common.Models;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Color, ColorViewModel>();
        }
    }
}
