using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using TiendaServicis.Api.Libro.Aplicacion;
using TiendaServicis.Api.Libro.Modelo;
using TiendaServicis.Api.Libro.Persistencia;
using static TiendaServicis.Api.Libro.Aplicacion.Consulta;

namespace TiendaServucuis.Api.Libro.Tests
{
    public class LibrosServiceTest
    {
        private ContextoLibreria GetContext()
        {
            var options = new DbContextOptionsBuilder<ContextoLibreria>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            return new ContextoLibreria(options);
        }

        

        [Fact]
        public async void AddLibro_ReturnsNotEmpty()
        {
            var dbContextFake = GetContext();
            var request = new Nuevo.Ejecuta { AutorLibro = Guid.NewGuid(), FechaPublicacion = DateTime.Now, Titulo = Guid.NewGuid().ToString() };
            var handler = new Nuevo.Manejador(dbContextFake);

            await handler.Handle(request, new CancellationToken());

            Assert.True(dbContextFake.LibreriaMaterial.Any());
        }
    }
}