using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Commands.Companies
{
    public record DeleteCompanyCommand(int CompanyId):IRequest;
    class DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        : IRequestHandler<DeleteCompanyCommand>
    {
        public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            await companyRepository.DeleteCompanyAsync(request.CompanyId);
        }
    }
}
