using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaApi.Commands;
using AgendaApi.Models;
using AgendaApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var query = new GetAllContactsQuery();
            var contacts = await _mediator.Send(query);
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var query = new GetContactByIdQuery(id);
            var contact = await _mediator.Send(query);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact([FromBody] AddContactCommand command)
        {
            var contact = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, [FromBody] UpdateContactCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var updatedContact = await _mediator.Send(command);

            if (updatedContact == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var command = new DeleteContactCommand(id);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
