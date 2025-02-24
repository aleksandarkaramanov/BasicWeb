using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;

namespace WebApp.Core.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactEntity>> GetContacts();
        Task<ContactEntity> GetContactByIdAsync(int id);
        Task<ContactEntity> AddContactAsync(ContactEntity entity);
        Task<int> UpdateContactAsync(int contactId, ContactEntity entity);
        Task<bool> DeleteContactAsync(int id);
        Task<List<ContactEntity>> GetContactsWithCompanyAndCountry();
        Task<List<ContactEntity>> FilterContacts(int? countryId, int? companyId);
    }
}
