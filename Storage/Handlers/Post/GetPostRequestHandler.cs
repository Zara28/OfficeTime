using MediatR;
using Microsoft.EntityFrameworkCore;
using Realization.DBModels;
using Realization.DTOModels;
using Realization.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handlers.Post
{
    public class GetPostRequestHandler : IRequestHandler<GetPostRequestModel, List<PostDTO>>
    {
        public Task<List<PostDTO>> Handle(GetPostRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var postDB = request.PostId == null ? _db.Posts.ToList() : 
                _db.Posts.Where(p => p.Id == request.PostId).ToList();

            var post = postDB.Select(p => new PostDTO
            {
                Id = p.Id,
                Description = p.Description,
                Salary = (double)p.Salary
            }).ToList();

            return Task.FromResult(post);
        }
    }

    public class GetPostListRequestHandler : IRequestHandler<GetListPostRequestModel, List<PostListDTO>>
    {
        public Task<List<PostListDTO>> Handle(GetListPostRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var postDB = request.PostId == null ? _db.Posts.ToList() :
                _db.Posts.Where(p => p.Id == request.PostId).ToList();

            var user = request.PostId == null ?  _db.Users.Include(u => u.Post).ToList() :
                _db.Users.Include(u => u.Post).Where(u => u.Postid == request.PostId).ToList();

            var post = postDB.Select(p => new PostListDTO
            {
                Id = p.Id,
                Description = p.Description,
                Salary = (double)p.Salary,
                Users = user.Where(u => u.Postid == p.Id).
                    Select(u => new UserDTO
                    {
                        Id = u.Id,
                        FIO = u.Fio,
                        DateBirth = (DateTime)u.Datebirth,
                        DateStart = (DateTime)u.Datestart,
                    }).ToList()
            }).ToList();

            return Task.FromResult(post);
        }
    }
}
