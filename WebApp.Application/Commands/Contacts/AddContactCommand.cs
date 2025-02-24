using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Entities;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Commands.Contacts
{
    public record AddContactCommand(ContactEntity Contact) : IRequest<int>;
    public class AddContactCommandHandler(IContactRepository contactRepository)
        : IRequestHandler<AddContactCommand, int>
    {
        public async Task<int> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {

            var contact = await contactRepository.AddContactAsync(request.Contact);
            return contact.ContactId;
        }


    }
}
