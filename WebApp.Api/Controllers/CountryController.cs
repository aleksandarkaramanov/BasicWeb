using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Commands.Countries;
using WebApp.Application.Queries.Companies;
using WebApp.Application.Queries.Countries;
using WebApp.Core.Entities;

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(ISender sender ) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddCountryAsync([FromBody] CountryEntity country)
        {
            var result = await sender.Send(new AddCountryCommand(country));
            return Ok(new { countryId = country.CountryId });
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllCountryAsync()
        {
            var result = await sender.Send(new GetAllCountriesQuery());
            return Ok(result);
        }
        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetCountryByIdAsync([FromRoute] int countryId)
        {
            var result = await sender.Send(new GetCompanyByIdQuery(countryId));
            return Ok(result);

        }

        [HttpPut("{countryId}")]
        public async Task<IActionResult> UpdateCountryAsync([FromRoute] int countryId, [FromBody] CountryEntity country)
        {
            var result = await sender.Send(new UpdateCountryCommand(countryId, country));
            return Ok(new { affectedRows = result });
        }

        [HttpDelete("{countryId}")]
        public async Task<IActionResult> DeleteCountryAsync([FromRoute] int countryId)
        {
            await sender.Send(new DeleteCountryCommand(countryId));
            return Ok();
        }


    }
}
