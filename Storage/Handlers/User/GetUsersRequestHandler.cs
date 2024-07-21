using MediatR;
using Microsoft.EntityFrameworkCore;
using Realization.DBModels;
using Realization.DTOModels;
using Realization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handles
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequestModel, List<UserDTO>>
    {
        public GetUsersRequestHandler()
        {

        }
        public Task<List<UserDTO>> Handle(GetUsersRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var usersDB = _db.Users.Include(u => u.Post).ToList();

            var users = usersDB.Select(u => new UserDTO
            {
                Id = u.Id,
                FIO = u.Fio,
                DateBirth = (DateTime)u.Datebirth,
                DateStart = (DateTime)u.Datestart,
                Post = new PostDTO
                {
                    Id = u.Post.Id,
                    Description = u.Post.Description,
                    Salary = (double)u.Post.Salary
                }
            }).ToList();

            return Task.FromResult(request.id == null ? users : users.Where(u => u.Id == request.id).ToList());
        }
    }
}
