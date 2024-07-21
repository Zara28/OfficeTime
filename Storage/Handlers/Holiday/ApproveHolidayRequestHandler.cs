using MediatR;
using Realization.DBModels;
using Realization.Models.Holiday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handles.Holiday
{
    public class ApproveHolidayRequestHandler : IRequestHandler<ApproveHolidayRequestModel>
    {
        public async Task Handle(ApproveHolidayRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var holiday = _db.Holidays.FirstOrDefault(h => h.Id == request.id);

            if (holiday == null)
                throw new ArgumentException();

            if(request.isDirect)
            {
                holiday.Isappdirect = true;
            }
            else
            {
                holiday.Isappadmin = true;
            }

            _db.Holidays.Update(holiday);

            await _db.SaveChangesAsync();
        }
    }
}
