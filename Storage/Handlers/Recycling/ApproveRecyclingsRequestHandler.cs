using MediatR;
using Realization.DBModels;
using Realization.Models.Recycling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handlers.Recycling
{
    public class ApproveRecyclingsRequestHandler : IRequestHandler<ApproveRecyclingRequsetModel>
    {
        public async Task Handle(ApproveRecyclingRequsetModel request, CancellationToken cancellationToken)
        {
            try
            {
                using var _db = new officeContext();
                var rec = _db.Recyclings.Where(x => x.Id == request.Id).FirstOrDefault();

                rec.Isapp = true;

                _db.Recyclings.Update(rec);

                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
