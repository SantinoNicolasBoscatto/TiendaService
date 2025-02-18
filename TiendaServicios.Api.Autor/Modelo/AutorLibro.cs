namespace TiendaServicios.Api.Autor.Modelo
{
    public class AutorLibro
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? AutorLibroGuid { get; set; }

        public int AutorLibroId { get; set; }
        public ICollection<GradoAcademico>? GradosAcademicos { get; set; }
    }
}
