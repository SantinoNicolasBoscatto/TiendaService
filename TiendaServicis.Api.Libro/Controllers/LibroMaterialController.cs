using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicis.Api.Libro.Aplicacion;

namespace TiendaServicis.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {
        private readonly IMediator mediator;
        public LibroMaterialController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Nuevo.Ejecuta ejecuta)
        {
            await mediator.Send(ejecuta);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<LibreriaMaterialDTO>>> Get()
        {
            var list = await mediator.Send(new Consulta.Ejecuta());
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibreriaMaterialDTO>> GetId(string id)
        {
            var dto = await mediator.Send(new ConsultaFiltro.LibroUnico() { LibroId = id});
            return Ok(dto);
        }
    }
}
