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
    public record GetContactByIdQuery(int id) : IRequest<ContactEntity>;
    public class GetContactByIdQueryHandler(IContactRepository contactRepository)
        : IRequestHandler<GetContactByIdQuery, ContactEntity>

    {
        public async Task<ContactEntity> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            return await contactRepository.GetContactByIdAsync(request.id);
        }
    }
}
