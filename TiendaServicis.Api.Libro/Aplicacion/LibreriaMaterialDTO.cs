namespace TiendaServicis.Api.Libro.Aplicacion
{
    public class LibreriaMaterialDTO
    {
        public string? LibreriaMaterialId { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }
    }
}
