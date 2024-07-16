using MediatR;
using Realization.Database.Database.Models;
using Realization.Models.Holiday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handles.Holiday
{
    public class UpdateHolidayRequestHandler : IRequestHandler<UpdateHolidayRequestModel>
    {
        public async Task Handle(UpdateHolidayRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var holiday = _db.Holidays.Where(x => x.Id == request.Id).FirstOrDefault();

            if (holiday == null)
                throw new ArgumentException();

            holiday.Datestart = request.Datestart;
            holiday.Dateend = request.Dateend;
            holiday.Datecreate = DateTime.Now;
            holiday.Isappadmin = request.Isappadmin;
            holiday.Isappdirect = request.Isappdirect;

            _db.Holidays.Update(holiday);

            await _db.SaveChangesAsync();
        }
    }
}
