using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Queries.Companies
{
    public record GetAllCompaniesQuery():IRequest<IEnumerable<CompanyEntity>>;
    public class GetAllCompaniesQueryHandler(ICompanyRepository companyRepository)
        : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompanyEntity>>
    {
        public async Task<IEnumerable<CompanyEntity>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await companyRepository.GetCompanies();
        }
    }
}
