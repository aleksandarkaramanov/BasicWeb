using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Commands.Countries
{
    public record UpdateCountryCommand(int CountryId, CountryEntity Country) : IRequest<int>;

    public class UpdateCountryCommandHandler(ICountryRepository countryRepository)
        : IRequestHandler<UpdateCountryCommand, int>
    {
        public async Task<int> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            return await countryRepository.UpdateCountryAsync(request.CountryId, request.Country);
        }
    }
}
