using AutoMapper;
using ControlCatedratico.Models;
using ControlCatedratico.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ControlCatedratico.Mapper
{
    public class CatedraticoMapper:Profile
    {
        public CatedraticoMapper()
        {
            CreateMap<CatedraticoModel, CatedraticoDtos>().ReverseMap();
            CreateMap<CatedraticoModel, CatedraticoSaveDtos>().ReverseMap();
        }
    }
}
