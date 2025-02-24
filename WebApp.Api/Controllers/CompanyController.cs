using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.Commands.Companies;
using WebApp.Application.Commands;
using WebApp.Application.Queries.Companies;
using WebApp.Core.Entities;
using WebApp.Infrastructure.Data;


namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddCompanyAsync([FromBody] CompanyEntity company)
        {

            var result = await sender.Send(new AddCompanyCommand(company));
            return Ok(new { companyId = company.CompanyId });
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllCompanyAsync()
        {
            var result = await sender.Send(new GetAllCompaniesQuery());
            return Ok(result);
        }
        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetCompanyByIdAsync([FromRoute] int companyId)
        {
            var result = await sender.Send(new GetCompanyByIdQuery(companyId));
            return Ok(result);
        }

        [HttpPut("{companyId}")]
        public async Task<IActionResult> UpdateCompanyAsync([FromRoute] int companyId, [FromBody] CompanyEntity company)
        {
            var result = await sender.Send(new UpdateCompanyCommand(companyId, company));
            return Ok(new { affectedRows=result });
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCompanyAsync([FromRoute] int companyId)
        {
            await sender.Send(new DeleteCompanyCommand(companyId));
            return Ok();
        }


    }
}
