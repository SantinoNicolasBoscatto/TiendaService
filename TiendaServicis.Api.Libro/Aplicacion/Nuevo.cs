using FluentValidation;
using MediatR;
using TiendaServicis.Api.Libro.Modelo;
using TiendaServicis.Api.Libro.Persistencia;

namespace TiendaServicis.Api.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string? Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public Guid? AutorLibro { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty().MinimumLength(5).WithMessage("Error Tests");
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.AutorLibro).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoLibreria contexto;
            public Manejador(ContextoLibreria contexto)
            {
                this.contexto = contexto;
            }

            public async Task Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = new LibreriaMaterial
                {
                    AutorLibro = request.AutorLibro,
                    FechaPublicacion = request.FechaPublicacion,
                    Titulo = request.Titulo,
                    LibreriaMaterialId = Guid.NewGuid().ToString()
                };
                contexto.LibreriaMaterial.Add(libro);
                var result = await contexto.SaveChangesAsync();
                if (result == 0) throw new Exception("Error al insertar libro");
            }
        }
    }
}
