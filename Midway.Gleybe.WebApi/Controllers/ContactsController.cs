using MediatR;
using Microsoft.AspNetCore.Mvc;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Call;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Delete;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Post;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Put;
using Midway.Gleybe.Application.CQRS.Queries.Contacts.GetAll;
using Midway.Gleybe.Application.CQRS.Queries.Contacts.GetById;
using Midway.Gleybe.Application.CQRS.Queries.GetByFilters;

namespace Midway.Gleybe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] PostContactCommand request)
        {
            var result = await mediator.Send(request);
            return result.HasError ? new BadRequestObjectResult(result) : Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts([FromQuery] GetAllContactsQuery request)
        {
            var result = await mediator.Send(request);
            return result.HasError ? new BadRequestObjectResult(result) : Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(Guid id)
        {
            var result = await mediator.Send(new GetContactsByIdQuery() { _Id = id });
            return result.HasError ? new BadRequestObjectResult(result) : Ok(result.Data);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterContacts([FromQuery] GetContactsByFiltersQuery request)
        {
            var result = await mediator.Send(request);
            return result.HasError ? new BadRequestObjectResult(result) : Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] PutContactCommand request)
        {
            request._Id = id;
            var result = await mediator.Send(request);
            return result.HasError ? new BadRequestObjectResult(result) : Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var result = await mediator.Send(new DeleteContactCommand { _Id = id });
            return result.HasError ? new BadRequestObjectResult(result) : Ok(result.Data);
        }

        [HttpPost("{id}/call")]
        public async Task<IActionResult> CallContact(Guid id)
        {
            var result = await mediator.Send(new CallContactCommand() { _Id = id, Topic = "call-contact" });
            return result.HasError ? new BadRequestObjectResult(result) : Ok(result.Data);
        }
    }
}