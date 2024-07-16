using MediatR;
using Microsoft.EntityFrameworkCore;
using Realization.Database.Database.Models;
using Realization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handles
{
    public class GetDaysOffRequestHandle : IRequestHandler<GetDaysOffRequestModel, List<Dayoff>>
    {
        public GetDaysOffRequestHandle()
        {

        }
        public Task<List<Dayoff>> Handle(GetDaysOffRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                using var _db = new officeContext();

                var holidays = _db.Dayoffs
                    .Include(h => h.User)
                    .Where((h => (h.Date < request.Start || h.Date <= request.End)
                    && (request.id != null) && h.Userid == request.id))
                    .ToList();

                return Task.FromResult(holidays);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
