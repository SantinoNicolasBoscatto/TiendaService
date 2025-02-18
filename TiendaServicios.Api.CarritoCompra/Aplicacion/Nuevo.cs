using MediatR;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }
            public List<string>? ProductoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContexto contexto;
            public Manejador(CarritoContexto contexto)
            {
                this.contexto = contexto;
            }

            public async Task Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                using (var transaction = await contexto.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var carritoSesion = new CarritoSesion
                        {
                            FechaCreacion = request.FechaCreacionSesion,
                        };
                        await contexto.CarritoSesion.AddAsync(carritoSesion);
                        var val = await contexto.SaveChangesAsync();
                        if (val != 1) throw new Exception("error en la creacion del Carrito Sesion");

                        int id = carritoSesion.CarritoSesionId;
                        foreach (var item in request.ProductoLista!)
                        {
                            await contexto.CarritoSesionDetalle.AddAsync(new CarritoSesionDetalle
                            {
                                CarritoSesionId = id,
                                FechaCreacion = DateTime.Now,
                                ProductoSeleccionado = item
                            });
                        }
                        var result = await contexto.SaveChangesAsync();
                        if (result != request.ProductoLista.Count) throw new Exception("Error al insertar productos");

                        // Commit the transaction
                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
        }

    }
}
