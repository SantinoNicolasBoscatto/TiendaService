using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicis.Api.Libro.Persistencia;

namespace TiendaServicis.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibreriaMaterialDTO>
        {
            public string? LibroId { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibreriaMaterialDTO>
        {
            private readonly ContextoLibreria contexto;
            private readonly IMapper mapper;
            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                this.contexto = contexto;
                this.mapper = mapper;
            }

            public async Task<LibreriaMaterialDTO> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await contexto.LibreriaMaterial
                                    .ProjectTo<LibreriaMaterialDTO>(mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync(x => x.LibreriaMaterialId == request.LibroId);
                if (libro == null) throw new Exception("Error, libro no encontrado");
                return libro;
            }
        }
    }
}
