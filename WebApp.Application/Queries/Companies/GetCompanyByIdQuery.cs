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
    public record GetCompanyByIdQuery(int id):IRequest<CompanyEntity>;
    public class GetCompanyByIdQueryHandler(ICompanyRepository companyRepository)
        : IRequestHandler<GetCompanyByIdQuery, CompanyEntity>

    {
        public async Task<CompanyEntity> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            return await companyRepository.GetCompanyByIdAsync(request.id);
        }
    }
}
