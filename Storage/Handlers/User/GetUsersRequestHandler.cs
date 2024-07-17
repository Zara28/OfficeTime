using MediatR;
using Realization.Database.Database.Models;
using Realization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handles
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequestModel, List<User>>
    {
        public GetUsersRequestHandler()
        {

        }
        public Task<List<User>> Handle(GetUsersRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var users = _db.Users.ToList();

            return Task.FromResult(request.id == null ? users : users.Where(u => u.Id == request.id).ToList());
        }
    }
}
