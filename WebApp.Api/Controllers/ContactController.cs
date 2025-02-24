using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Commands.Contacts;
using WebApp.Application.Queries.Contacts;
using WebApp.Core.DTOs;
using WebApp.Core.Entities;

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddContactAsync([FromBody] ContactEntity contact)
        {
            contact.Company = null;
            contact.Country = null;
            var result = await sender.Send(new AddContactCommand(contact));
            return Ok(contact.ContactId);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllContactAsync()
        {
            var result = await sender.Send(new GetAllContactsQuery());
            return Ok(result);
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContactByIdAsync([FromRoute] int contactId)
        {
            var result = await sender.Send(new GetContactByIdQuery(contactId));
            return Ok(result);
        }

        [HttpPut("{contactId}")]
        public async Task<IActionResult> UpdateContactAsync([FromRoute] int contactId, [FromBody] ContactEntity contact)
        {
            var result = await sender.Send(new UpdateContactCommand(contactId, contact));
            return Ok(new { affectedRows = result });
        }
        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteContactAsync([FromRoute] int contactId)
        {
            await sender.Send(new DeleteContactCommand(contactId));
            return Ok();
        }
        [HttpGet("contactsWithDetails")]
        public async Task<IActionResult> GetAllContactsWithDetailsAsync()
        {
            var result = await sender.Send(new GetContactsWithCompanyAndCountryQuery());

            var contactsWithDetails = result.Select(contact => new ContactWithDetailsDTO
            {
                ContactId = contact.ContactId,
                ContactName = contact.ContactName,
                CompanyName = contact.Company.CompanyName,
                CountryName = contact.Country.CountryName
            });

            return Ok(contactsWithDetails);
        }
        [HttpGet("filter")]
        [Authorize]
        public async Task<IActionResult> FilterContactsAsync([FromQuery] int? countryId, [FromQuery] int? companyId)
        {
            var result = await sender.Send(new FilterContactsQuery(countryId, companyId));
            return Ok(result);
        }
    }
}
