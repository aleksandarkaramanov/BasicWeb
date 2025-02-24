using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;
using WebApp.Core.Interfaces;
using WebApp.Infrastructure.Data;

namespace WebApp.Infrastructure.Repositories
{
    public class CountryRepository(AppDbContext dbContext, ILogger<CountryRepository> logger) : ICountryRepository
    {
        public async Task<IEnumerable<CountryEntity>> GetCountries()
        {
            try
            {
                logger.LogInformation("Fetching all countries from the database.");
                var countries = await dbContext.Countries.ToListAsync();
                logger.LogInformation("Successfully retrieved {Count} countries.", countries.Count);
                return countries;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving countries.");
                throw new ApplicationException("An error occurred while retrieving countries.", ex);
            }
        }

        public async Task<CountryEntity> GetCountryByIdAsync(int id)
        {
            try
            {
                logger.LogInformation("Fetching country with ID: {CountryId}", id);
                var country = await dbContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

                if (country == null)
                {
                    logger.LogWarning("Country with ID {CountryId} not found.", id);
                }
                else
                {
                    logger.LogInformation("Successfully retrieved country with ID: {CountryId}", id);
                }

                return country;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving country with ID: {CountryId}", id);
                throw new ApplicationException($"An error occurred while retrieving the country with ID: {id}", ex);
            }
        }

        public async Task<CountryEntity> AddCountryAsync(CountryEntity entity)
        {
            try
            {
                logger.LogInformation("Adding a new country: {CountryName}", entity.CountryName);
                dbContext.Countries.Add(entity);
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Successfully added country with ID: {CountryId}", entity.CountryId);
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding a new country: {CountryName}", entity.CountryName);
                throw new ApplicationException("An error occurred while adding the country.", ex);
            }
        }

        public async Task<int> UpdateCountryAsync(int countryId, CountryEntity entity)
        {
            try
            {
                logger.LogInformation("Updating country with ID: {CountryId}", countryId);
                var country = await dbContext.Countries.FirstOrDefaultAsync(x => x.CountryId == countryId);

                if (country == null)
                {
                    logger.LogWarning("Country with ID {CountryId} not found.", countryId);
                    return 0;
                }

                country.CountryName = entity.CountryName;
                var affectedRows = await dbContext.SaveChangesAsync();
                logger.LogInformation("Successfully updated country with ID: {CountryId}. Rows affected: {AffectedRows}", countryId, affectedRows);
                return affectedRows;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating country with ID: {CountryId}", countryId);
                throw new ApplicationException($"An error occurred while updating the country with ID: {countryId}", ex);
            }
        }

        public async Task DeleteCountryAsync(int countryId)
        {
            try
            {
                logger.LogInformation("Attempting to delete country with ID: {CountryId}", countryId);

                var country = await dbContext.Countries.FindAsync(countryId);

                if (country == null)
                {
                    logger.LogWarning("Country with ID {CountryId} not found. No deletion performed.", countryId);
                    return;
                }

                dbContext.Countries.Remove(country);
                await dbContext.SaveChangesAsync();

                logger.LogInformation("Successfully deleted country with ID: {CountryId}", countryId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting country with ID: {CountryId}", countryId);
                throw new ApplicationException($"An error occurred while deleting the country with ID: {countryId}", ex);
            }
        }
    }
}
