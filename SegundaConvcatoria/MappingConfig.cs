using AutoMapper;
using SegundaConvcatoria.Models;
using SegundaConvcatoria.Models.Dto;
using System.Diagnostics;

namespace SegundaConvcatoria
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Pelicula, PeliculaDto>().ReverseMap();
            CreateMap<Pelicula, PeliculacreateDto>().ReverseMap();
            CreateMap<Pelicula, PeliculaUpdatedto>().ReverseMap();

            CreateMap<Genero, GeneroDto>().ReverseMap();
            CreateMap<Genero, GeneroCreateDto>().ReverseMap();
            CreateMap<Genero, GeneroUpdateDto>().ReverseMap();
        }

    }
}
