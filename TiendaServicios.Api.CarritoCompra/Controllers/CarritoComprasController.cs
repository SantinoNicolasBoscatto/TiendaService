using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.CarritoCompra.Aplicacion;
using TiendaServicios.Api.CarritoCompra.Aplicacion.dto;

namespace TiendaServicios.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoComprasController : ControllerBase
    {
        private readonly IMediator mediator;
        public CarritoComprasController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Nuevo.Ejecuta data)
        {
            await mediator.Send(data);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarritoDTO>> GetCarrito(int id)
        {
            return await mediator.Send(new Consulta.Ejecuta { CarritoSesionId = id });
        }

    }
}
