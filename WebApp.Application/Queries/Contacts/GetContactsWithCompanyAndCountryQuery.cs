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
        public record GetContactsWithCompanyAndCountryQuery() : IRequest<IEnumerable<ContactEntity>>;
        public class GetContactsWithCompanyAndCountryQueryHandler(IContactRepository contactRepository)
            : IRequestHandler<GetContactsWithCompanyAndCountryQuery, IEnumerable<ContactEntity>>
        {
            public async Task<IEnumerable<ContactEntity>> Handle(GetContactsWithCompanyAndCountryQuery request, CancellationToken cancellationToken)
            {
                return await contactRepository.GetContacts();
            }
        }
    
}
