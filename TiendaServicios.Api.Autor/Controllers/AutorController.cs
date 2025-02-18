using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]Nuevo.Ejecuta ejecuta)
        {
            await _mediator.Send(ejecuta);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> Get()
        {
            var value = await _mediator.Send(new Consulta.ListaAutor());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDTO>> GetId(string id)
        {
            var value = await _mediator.Send(new ConsultaFiltro.AutorUnico() { AutorLibroGuid = id});
            return Ok(value);
        }
    }
}
