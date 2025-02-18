namespace TiendaServicios.Api.CarritoCompra.Aplicacion.dto
{
    public class CarritoDTO
    {
        public int CarritoId { get; set; }
        public DateTime? FechaCreacionSesion { get; set; }
        public List<CarritoDetalleDTO>? ListaProductos { get; set; } = new List<CarritoDetalleDTO>();
    }
}
