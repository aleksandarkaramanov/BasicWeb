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
    public record UpdateCompanyCommand(int CompanyId,CompanyEntity Company) : IRequest<int>;

    public class UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        : IRequestHandler<UpdateCompanyCommand, int>
    {
        public async Task<int> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            return await companyRepository.UpdateCompanyAsync(request.CompanyId,request.Company);
        }
    }
}