using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Commands.Companies
{
    public record AddCompanyCommand(CompanyEntity Company):IRequest<int>;
    public class AddCompanyCommandHandler(ICompanyRepository companyRepository)
        : IRequestHandler<AddCompanyCommand, int>
    {
        public async Task<int> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {

            var company = await companyRepository.AddCompanyAsync(request.Company);
            return company.CompanyId;
        }

        
    }
}
