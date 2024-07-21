using MediatR;
using Realization.DBModels;
using Realization.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handlers.Post
{
    public class CreatePostRequestHandler : IRequestHandler<CreatePostRequestModel>
    {
        public async Task Handle(CreatePostRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var post = new DBModels.Post
            {
                Description = request.Description,
                Salary = request.Salary,
            };

            _db.Posts.Add(post);

            await _db.SaveChangesAsync();
        }
    }
}
