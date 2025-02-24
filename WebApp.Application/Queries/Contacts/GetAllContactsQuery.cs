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
    public record GetAllContactsQuery() : IRequest<IEnumerable<ContactEntity>>;
    public class GetAllContactsQueryHandler(IContactRepository contactRepository)
        : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactEntity>>
    {
        public async Task<IEnumerable<ContactEntity>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            return await contactRepository.GetContacts();
        }
    }
}
