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
    public record UpdateContactCommand(int ContactId, ContactEntity Contact) : IRequest<int>;

    public class UpdateContactCommandHandler(IContactRepository contactRepository)
        : IRequestHandler<UpdateContactCommand, int>
    {
        public async Task<int> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            return await contactRepository.UpdateContactAsync(request.ContactId, request.Contact);
        }
    }
}
