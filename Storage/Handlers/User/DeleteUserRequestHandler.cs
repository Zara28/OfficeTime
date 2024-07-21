using MediatR;
using Realization.DBModels;
using Realization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handles
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequestModel>
    {
        public async Task Handle(DeleteUserRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var user = _db.Users.FirstOrDefault(u => u.Id == request.UserId);

            if (user == null)
                throw new ArgumentException();

            _db.Users.Remove(user);

            await _db.SaveChangesAsync();
        }
    }
}
