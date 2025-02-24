using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Commands.Contacts
{
    public record DeleteContactCommand(int ContactId) : IRequest;
    class DeleteContactCommandHandler(IContactRepository contactRepository)
        : IRequestHandler<DeleteContactCommand>
    {
        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            await contactRepository.DeleteContactAsync(request.ContactId);
        }
    }
}
