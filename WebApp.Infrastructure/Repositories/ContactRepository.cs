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
    public class ContactRepository(AppDbContext dbContext, ILogger<ContactRepository> logger):IContactRepository
    {
        public async Task<IEnumerable<ContactEntity>> GetContacts()
        {
            return await dbContext.Contacts
                .Include(c => c.Company)
                .Include(c => c.Country)
                .ToListAsync();
        }

        public async Task<ContactEntity> GetContactByIdAsync(int id)
        {
            return await dbContext.Contacts
                .Include(c => c.Company)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(x => x.ContactId == id);
        }

        public async Task<ContactEntity> AddContactAsync(ContactEntity entity)
        {
            logger.LogInformation("Attempting to add a new contact with Name: {ContactName}", entity.ContactName);

            var existingCompany = await dbContext.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CompanyId == entity.CompanyId);

            var existingCountry = await dbContext.Countries
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CountryId == entity.CountryId);

            if (existingCompany == null || existingCountry == null)
            {
                logger.LogWarning("Failed to add contact. Company ID: {CompanyId} or Country ID: {CountryId} does not exist.",
                    entity.CompanyId, entity.CountryId);
                throw new Exception("Company or Country does not exist.");
            }
            entity.Company = null;
            entity.Country = null;
            dbContext.Contacts.Add(entity);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Successfully added contact with ID: {ContactId}", entity.ContactId);

            return entity;
        }
        public async Task<int> UpdateContactAsync(int contactId, ContactEntity entity)
        {
            var contact = await dbContext.Contacts
                .Include(c => c.Company)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(x => x.ContactId == contactId);

            if (contact is not null)
            {

                contact.ContactName = entity.ContactName;

                if (contact.CompanyId != entity.CompanyId)
                {
                    var company = await dbContext.Companies.FindAsync(entity.CompanyId);
                    if (company != null)
                    {
                        contact.CompanyId = entity.CompanyId; 
                        contact.Company = company; 
                    }
                }

                if (contact.CountryId != entity.CountryId)
                {
                    var country = await dbContext.Countries.FindAsync(entity.CountryId);
                    if (country != null)
                    {
                        contact.CountryId = entity.CountryId;
                        contact.Country = country;
                    }
                }

                var affectedRows = await dbContext.SaveChangesAsync();
                return affectedRows;
            }
            return 0;
        }


        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = await dbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == id);
            if (contact is not null)
            {
                dbContext.Contacts.Remove(contact);
                return await dbContext.SaveChangesAsync()>0;
            }
            return false;
        }

        public async Task<List<ContactEntity>> GetContactsWithCompanyAndCountry()
        {
            return await dbContext.Contacts
                .Include(c => c.Company) // Вклучи ја компанијата
                .Include(c => c.Country) // Вклучи ја земјата
                .ToListAsync();
        }
        public async Task<List<ContactEntity>> FilterContacts(int? countryId, int? companyId)
        {
            var query = dbContext.Contacts.AsQueryable();

            // Филтрирање по земја ако countryId е даден
            if (countryId.HasValue && countryId.Value > 0)
            {
                logger.LogInformation("Filtering contacts by CountryId: {CountryId}", countryId.Value);
                query = query.Where(c => c.CountryId == countryId.Value);
            }

            // Филтрирање по компанија ако companyId е даден
            if (companyId.HasValue && companyId.Value > 0)
            {
                logger.LogInformation("Filtering contacts by CompanyId: {CompanyId}", companyId.Value);
                query = query.Where(c => c.CompanyId == companyId.Value);
            }

            // Вклучување на компанија и земја
            query = query.Include(c => c.Company).Include(c => c.Country);

            return await query.ToListAsync();
        }
    }
}
