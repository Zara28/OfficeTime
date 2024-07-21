using MediatR;
using Realization.DBModels;
using Realization.Models.DayOff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handlers.DayOff
{
    public class ApproveDayOffRequestHandle : IRequestHandler<ApproveDayOffRequestModel>
    {
        public ApproveDayOffRequestHandle()
        {

        }
        public async Task Handle(ApproveDayOffRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var day = _db.Dayoffs.Where(d => d.Id == request.DayOffId).FirstOrDefault();

            day.Isapp = true;

            day.Dateapp = DateTime.Now;

            _db.Dayoffs.Update(day);

            await _db.SaveChangesAsync();
        }
    }
}
