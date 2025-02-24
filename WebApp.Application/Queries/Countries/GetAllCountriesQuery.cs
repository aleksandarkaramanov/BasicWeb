using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Queries.Countries
{
    public record GetAllCountriesQuery() : IRequest<IEnumerable<CountryEntity>>;
    public class GetAllCountriesQueryHandler(ICountryRepository countryRepository)
        : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryEntity>>
    {
        public async Task<IEnumerable<CountryEntity>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            return await countryRepository.GetCountries();
        }
    }
}
