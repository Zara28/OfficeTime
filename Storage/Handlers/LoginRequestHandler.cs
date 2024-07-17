using MediatR;
using Microsoft.EntityFrameworkCore;
using Realization.DBModels;
using Realization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handles
{
    public class LoginRequestHandler : IRequestHandler<LoginRequestModel, bool>
    {
        public LoginRequestHandler()
        {
        }

        public Task<bool> Handle(LoginRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var user = _db.Users.Where(u => request.Login == u.Fio && request.Password == u.Password
                                        && u.Password != null).FirstOrDefault();

            return Task.FromResult(user != null);
        }
    }
}
