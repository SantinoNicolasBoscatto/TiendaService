using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDTO>
        {
            public string? AutorLibroGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDTO>
        {
            private readonly ContextoAutor contexto;
            private readonly IMapper mapper;
            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                this.contexto = contexto;
                this.mapper = mapper;
            }

            public async Task<AutorDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await contexto.AutorLibro
                    .ProjectTo<AutorDTO>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.AutorLibroGuid == request.AutorLibroGuid);
                if (autor == null) throw new Exception("El autor buscado no existe");
                return autor;
            }
        }
    }
}
