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
    public class DeleteHolidayRequestHandler : IRequestHandler<DeleteHolidayRequestModel>
    {
        public async Task Handle(DeleteHolidayRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var holiday = _db.Holidays.FirstOrDefault(h => h.Id == request.HolidayId);

            if (holiday == null)
                throw new ArgumentException();

            _db.Holidays.Remove(holiday);

            await _db.SaveChangesAsync();
        }
    }
}
