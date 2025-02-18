namespace TiendaServicis.Api.Libro.Modelo
{
    public class LibreriaMaterial
    {
        public string? LibreriaMaterialId { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }
    }
}
