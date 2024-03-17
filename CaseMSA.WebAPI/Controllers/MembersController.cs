using CaseMSA.Application.Members.Commands;
using CaseMSA.Application.Members.Queries;
using CaseMSA.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseMSA.WebAPI.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllMembers(int skip = 0, int take = 15)
        {
            var query = new GetMembersQuery() { Skip = skip, Take = take };

            var allMembers = await _mediator.Send(query);

            return Ok(allMembers);
        }

        [HttpGet("{id}")]
        [ActionName("GetMemberById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            var command = new GetMemberByIdQuery { Id = id };

            if (command is null) return BadRequest();

            return Ok(await _mediator.Send(command));

        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveMember(Guid id)
        {
            var command = new DeleteMemberCommand { Id = id };

            if (command is null) return BadRequest();

            await _mediator.Send(command);  

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateMember(UpdateMemberCommand command)
        {
            if (command is null) return BadRequest();

            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMember(CreateMemberCommand command)
        {
            if (command is null) return BadRequest();

            await _mediator.Send(command);

            return Ok();
        }
    }
}
