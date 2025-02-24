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
    public record AddCountryCommand(CountryEntity Country) : IRequest<int>;
    public class AddCountryCommandHandler(ICountryRepository countryRepository)
        : IRequestHandler<AddCountryCommand, int>
    {
        public async Task<int> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {

            var country = await countryRepository.AddCountryAsync(request.Country);
            return country.CountryId;
        }


    }
}
