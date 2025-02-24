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
    public class CompanyRepository(AppDbContext dbContext, ILogger<CompanyRepository> _logger) :ICompanyRepository
    {
        public async Task<IEnumerable<CompanyEntity>> GetCompanies()
        {
            try
            {
                _logger.LogInformation("Starting to retrieve companies");
                var companies = await dbContext.Companies.ToListAsync();

                _logger.LogInformation("Successfully retrieved {Count} companies", companies.Count);

                return companies;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving companies");
                throw new ApplicationException("An error occurred while retrieving companies", ex);
            }
        }
        public async Task<CompanyEntity?> GetCompanyByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching company with ID: {CompanyId}", id);

                var company = await dbContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == id);

                if (company == null)
                {
                    _logger.LogWarning("Company with ID: {CompanyId} not found", id);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved company: {CompanyName}", company.CompanyName);
                }

                return company;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching company with ID: {CompanyId}", id);
                throw new ApplicationException($"An error occurred while fetching the company with ID: {id}", ex);
            }
        }
        public async Task<CompanyEntity> AddCompanyAsync(CompanyEntity entity)
        {
            try
            {
                _logger.LogInformation("Adding a new company: {CompanyName}", entity.CompanyName);

                dbContext.Companies.Add(entity);
                await dbContext.SaveChangesAsync();

                _logger.LogInformation("Successfully added company with ID: {CompanyId}", entity.CompanyId);

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new company: {CompanyName}", entity.CompanyName);
                throw new ApplicationException($"An error occurred while adding the company: {entity.CompanyName}", ex);
            }
        }
        public async Task<int> UpdateCompanyAsync(int companyId, CompanyEntity entity)
        {
            try
            {
                _logger.LogInformation("Updating company with ID: {CompanyId}", companyId);

                var company = await dbContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == companyId);

                if (company == null)
                {
                    _logger.LogWarning("Company with ID: {CompanyId} not found", companyId);
                    return 0;
                }

                company.CompanyName = entity.CompanyName;
                var affectedRows = await dbContext.SaveChangesAsync();

                _logger.LogInformation("Successfully updated company with ID: {CompanyId}. Rows affected: {AffectedRows}", companyId, affectedRows);

                return affectedRows;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating company with ID: {CompanyId}", companyId);
                throw new ApplicationException($"An error occurred while updating the company with ID: {companyId}", ex);
            }
        }
        public async Task DeleteCompanyAsync(int companyId)
        {
            try
            {
                _logger.LogInformation("Deleting company with ID: {CompanyId}", companyId);

                var company = await dbContext.Companies.FindAsync(companyId);

                if (company == null)
                {
                    _logger.LogWarning("Company with ID: {CompanyId} not found", companyId);
                    return;
                }

                dbContext.Companies.Remove(company);
                await dbContext.SaveChangesAsync();

                _logger.LogInformation("Successfully deleted company with ID: {CompanyId}", companyId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting company with ID: {CompanyId}", companyId);
                throw new ApplicationException($"An error occurred while deleting the company with ID: {companyId}", ex);
            }
        }


    }

}
