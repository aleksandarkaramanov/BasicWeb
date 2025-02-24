using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;

namespace WebApp.Core.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyEntity>> GetCompanies();
        Task<CompanyEntity> GetCompanyByIdAsync(int id);
        Task<CompanyEntity> AddCompanyAsync(CompanyEntity entity);
        Task<int> UpdateCompanyAsync(int companyId,CompanyEntity entity);
        Task DeleteCompanyAsync(int companyId);
    }
}
