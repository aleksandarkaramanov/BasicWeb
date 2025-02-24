using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Queries.Contacts
{
    public record FilterContactsQuery(int? CountryId, int? CompanyId) : IRequest<List<ContactEntity>>;
    public class FilterContactsQueryHandler(IContactRepository contactRepository)
        : IRequestHandler<FilterContactsQuery, List<ContactEntity>>
    {
        public async Task<List<ContactEntity>> Handle(FilterContactsQuery request, CancellationToken cancellationToken)
        {
            return await contactRepository.FilterContacts(request.CountryId,request.CompanyId);
        }
    }
}
