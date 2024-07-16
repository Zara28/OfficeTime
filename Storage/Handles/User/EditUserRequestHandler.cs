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
    public class EditUserRequestHandler : IRequestHandler<EditUserReqestModel>
    {
        public async Task Handle(EditUserReqestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var oldUser = _db.Users.FirstOrDefault(x => x.Id == request.Id);
            if (oldUser == null)
            {
                throw new Exception();
            }

            oldUser.Fio = request.Fio;
            oldUser.Datestart = request.Datestart;
            oldUser.Datebirth = request.Datebirth;
            oldUser.Telegramid = request.Telegramid;

            _db.Users.Update(oldUser);

            await _db.SaveChangesAsync();
        }
    }
}
