using AutoMapper;
using ProductosApi.DTOs;
using ProductosApi.Models;

namespace ProductosApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Producto, ProductoDTO>().ReverseMap();
        }
    }
}
