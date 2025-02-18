namespace TiendaServicios.Api.CarritoCompra.Aplicacion.dto
{
    public class CarritoDetalleDTO
    {
        public Guid? LibroId { get; set; }
        public string? TituloLibro { get; set; }
        public string? AutorLibro { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}
