using AutoMapper;
using TiendaServicis.Api.Libro.Modelo;

namespace TiendaServicis.Api.Libro.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibreriaMaterialDTO>();
        }
    }
}
