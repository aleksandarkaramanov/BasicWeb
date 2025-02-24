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
    public record GetCountryByIdQuery(int id) : IRequest<CountryEntity>;
    public class GetCountryByIdQueryHandler(ICountryRepository countryRepository)
        : IRequestHandler<GetCountryByIdQuery, CountryEntity>

    {
        public async Task<CountryEntity> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            return await countryRepository.GetCountryByIdAsync(request.id);
        }
    }
}
