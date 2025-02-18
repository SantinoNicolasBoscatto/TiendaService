using AutoMapper;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AutorLibro, AutorDTO>();
        }
    }
}
