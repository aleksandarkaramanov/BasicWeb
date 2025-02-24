using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;

namespace WebApp.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryEntity>> GetCountries();
        Task<CountryEntity> GetCountryByIdAsync(int id);
        Task<CountryEntity> AddCountryAsync(CountryEntity entity);
        Task<int> UpdateCountryAsync(int countryId, CountryEntity entity);
        Task DeleteCountryAsync(int countryId);
    }
}
