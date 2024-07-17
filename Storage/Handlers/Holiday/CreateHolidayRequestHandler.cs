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
    public class CreateHolidayRequestHandler : IRequestHandler<CreateHolidayRequestModel>
    {
        public async Task Handle(CreateHolidayRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var user = _db.Users.FirstOrDefault(u => u.Id == request.Userid);

            var days = _db.Availabledays.Where(a => a.Fio == user.Fio).FirstOrDefault();

            if((request.Dateend - request.Datestart).Value.Days < days.Dates)
            {
                throw new ArgumentException("Не хватает дней");
            }

            _db.Holidays.Add(new Database.Database.Models.Holiday
            {
                Datecreate = DateTime.Now,
                Dateend = request.Dateend,
                Datestart = request.Datestart,
                Userid = request.Userid,
                Isdelete = false,
                Isappadmin = request.Isappadmin,
                Isappdirect = request.Isappdirect,
            });

            await _db.SaveChangesAsync();
        }
    }
}
