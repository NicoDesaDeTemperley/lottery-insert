using AutoMapper;
using loterry_console.Dto;
using loterry_console.Models;

namespace loterry_console.Map
{
    public class MapToBaseProfile : Profile
    {
        public MapToBaseProfile() 
        {
                CreateMap<Quiniela,DatosQuiniela>()
                .ForMember(dest => dest.Nombre, act => act.MapFrom(src => src.nombre_quiniela))
                .ForMember(dest => dest.Previa, act => act.MapFrom(src => src.previa))
                .ForMember(dest => dest.Primera, act => act.MapFrom(src => src.primera))
                .ForMember(dest => dest.Matutina, act => act.MapFrom(src => src.matutina))
                .ForMember(dest => dest.Vespertina, act => act.MapFrom(src => src.vespertina))
                .ForMember(dest => dest.Tarde, act => act.MapFrom(src => src.tarde))
                .ForMember(dest => dest.Nocturna, act => act.MapFrom(src => src.nocturna)); 

        }
    }
}
