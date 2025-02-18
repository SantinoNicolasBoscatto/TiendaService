using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Aplicacion.dto;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDTO>
        {
            public int CarritoSesionId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, CarritoDTO>
        {
            private readonly ILibrosService librosService;
            private readonly CarritoContexto carritoContexto;
            public Manejador(ILibrosService librosService, CarritoContexto carritoContexto)
            {
                this.librosService = librosService;
                this.carritoContexto = carritoContexto;
            }

            public async Task<CarritoDTO> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await carritoContexto.CarritoSesion.Include(x => x.ListaDetalle)
                    .FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);
                if (carritoSesion == null) throw new Exception("Carrito Null");


                var carroDto = new CarritoDTO()
                {
                    CarritoId = request.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion   
                };
                foreach (var item in carritoSesion!.ListaDetalle!)
                {
                    var libro = await librosService.GetLibro(new Guid(item.ProductoSeleccionado!));
                    if(!libro.result) throw new Exception("Error en el Service");

                    var detalle = new CarritoDetalleDTO
                    {
                        AutorLibro = libro!.libro!.AutorLibro.ToString(),
                        FechaPublicacion = libro.libro.FechaPublicacion,
                        TituloLibro = libro.libro.Titulo,
                        LibroId = new Guid(libro.libro.LibreriaMaterialId!)
                    };
                    carroDto.ListaProductos!.Add(detalle);
                }
                return carroDto;
            }
        }
    }
}
