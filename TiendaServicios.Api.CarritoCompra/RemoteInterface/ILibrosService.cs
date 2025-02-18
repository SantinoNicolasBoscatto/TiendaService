using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteInterface
{
    public interface ILibrosService
    {
        Task<(bool result, LibroRemote? libro, string? error)> GetLibro(Guid LibroId);
    }
}
