using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Commands.Countries
{
    public record DeleteCountryCommand(int CountryId) : IRequest;
    class DeleteCountryCommandHandler(ICountryRepository countryRepository)
        : IRequestHandler<DeleteCountryCommand>
    {
        public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            await countryRepository.DeleteCountryAsync(request.CountryId);
        }
    }
}
