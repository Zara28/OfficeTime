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
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequestModel>
    {
        public CreateUserRequestHandler()
        {
        }

        public async Task Handle(CreateUserRequestModel request, CancellationToken cancellationToken)
        {
            using var db = new officeContext();
            var newUser = new User
            {
                Fio = request.Fio,
                Datebirth = request.Datebirth,
                Datestart = request.Datestart,
                Telegramid = request.Telegramid,
                Postid = request.postId
            };
            await db.Users.AddAsync(newUser);
            await db.SaveChangesAsync();
        }
    }
}
