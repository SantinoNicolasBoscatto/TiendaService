using Microsoft.EntityFrameworkCore;
using TiendaServicis.Api.Libro.Modelo;

namespace TiendaServicis.Api.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria(DbContextOptions options) : base(options)
        {}

        public ContextoLibreria()
        {}

        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
