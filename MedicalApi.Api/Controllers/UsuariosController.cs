using System.Threading.Tasks;
using MediatR;
using MedicalApi.Application.Features.Usuarios.Create;
using MedicalApi.Application.Features.Usuarios.Delete;
using MedicalApi.Application.Features.Usuarios.Update;
using MedicalApi.Application.Queries;
using MedicalApi.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApi.Api.Controllers
{

    [ApiController]
    [Route("usuarios")]
    public class UsuariosController(IMediator mediator) : ControllerBase
    {
        public readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create(CreateUsuarioCommand usuario)
        {
            try
            {
                var novoUsuario = await _mediator.Send(usuario);
                return Created($"usuarios/{novoUsuario.Id}", novoUsuario);
            }
            catch (EmailJaExisteException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (CpfJaExisteException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var request = new GetUsuarioByIdQuery()
            {
                Id = id
            };
            var user = await _mediator.Send(request);
            if (user is null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioCommand novoUsuario, [FromRoute] Guid id)
        {
            try
            {
                novoUsuario.Id = id;
                var usuario = await _mediator.Send(novoUsuario);
                return Ok(usuario);
            }
            catch (UsuarioNaoEncontradoException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (EmailJaExisteException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (CpfJaExisteException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 0,
                [FromQuery] int pageSize = 25)
        {
            var request = new GetAllUsuariosQuery()
            {
                Page = page,
                PageSize = pageSize
            };

            var users = await _mediator.Send(request);
            return Ok(users);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var command = new DeleteUsuarioCommand { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (UsuarioNaoEncontradoException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

    }
}