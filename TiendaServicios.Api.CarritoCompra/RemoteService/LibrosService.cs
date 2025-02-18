using Microsoft.AspNetCore.Http;
using System.Text.Json;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteService
{
    public class LibrosService : ILibrosService
    {
        private readonly IHttpClientFactory httpClient;
        private readonly ILogger<LibrosService> logger;

        public LibrosService(IHttpClientFactory httpClient, ILogger<LibrosService> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<(bool result, LibroRemote? libro, string? error)> GetLibro(Guid LibroId)
        {
            try
            {
                // El Nombre del HttpClient debera ser el que definimos en program
                var client = httpClient.CreateClient("Libros");
                // Aqui consultaremos al Client, le pasaremos la ruta completa del endpoint con los parametros.
                // Esto nos devolvera un HttpResponse que contendra un JSON
                var httpResponse = await client.GetAsync($"api/LibroMaterial/{LibroId}");

                if(httpResponse.IsSuccessStatusCode)
                {
                    // Si el resultado fue exitoso entonces guardo el Content como un Jsonstring
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    // Aqui casteo mi JSON a mi Clase LibroRemote
                    var result = JsonSerializer.Deserialize<LibroRemote>(content, options);
                    return (true, result, null);
                }
                return (false, null, httpResponse.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}
