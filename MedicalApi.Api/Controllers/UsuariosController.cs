using System.Threading.Tasks;
using MediatR;
using MedicalApi.Application.Features;
using MedicalApi.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApi.Api.Controllers
{

    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        public readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateUsuarioCommand usuario)
        {
            var novoUsuarioId = await _mediator.Send(usuario);
            return CreatedAtAction(nameof(GetById), new { id = novoUsuarioId }, new { id = novoUsuarioId });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var request = new GetUsuarioByIdQuery(){
                Id = id
            };
            var user = await _mediator.Send(request);
            if(user is null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioCommand novoUsuario, [FromRoute] Guid id){ //tem q adicioanr o fro, toure obrigatoriamente? o from body tb? se sim pq no create nao me disse rpa adicionar o from body
            try
            {
                novoUsuario.Id = id;
                var usuario = await _mediator.Send(novoUsuario);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Opps nao sei como padronizar excecoes");
            }
        }

    }
}