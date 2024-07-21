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
    public class UpdatePostRequestHandler : IRequestHandler<UpdatePostRequestModel>
    {
        public async Task Handle(UpdatePostRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var postOld = _db.Posts.Where(p => p.Id == request.Id).FirstOrDefault();

            postOld.Description = request.Description;
            postOld.Salary = request.Salary;

            _db.Posts.Update(postOld);

            await _db.SaveChangesAsync();
        }
    }
}
