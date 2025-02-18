using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicis.Api.Libro.Persistencia;

namespace TiendaServicis.Api.Libro.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibreriaMaterialDTO>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<LibreriaMaterialDTO>>
        {
            private readonly ContextoLibreria contexto;
            private readonly IMapper mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                this.contexto = contexto;
                this.mapper = mapper;
            }

            public async Task<List<LibreriaMaterialDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                return await contexto.LibreriaMaterial
                    .ProjectTo<LibreriaMaterialDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
