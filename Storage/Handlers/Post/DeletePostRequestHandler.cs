using MediatR;
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
    public class DeletePostRequestHandler : IRequestHandler<DeletePostRequestModel>
    {
        public async Task Handle(DeletePostRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var postDB = _db.Posts.Where(p => p.Id == request.Id).FirstOrDefault();

            _db.Posts.Remove(postDB);

            await _db.SaveChangesAsync();
        }
    }
}
