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
    public class GetHolidayRequestHandle : IRequestHandler<GetHolidaysRequsetModels, List<Realization.Database.Database.Models.Holiday>>
    {
        public GetHolidayRequestHandle()
        {

        }
        public Task<List<Realization.Database.Database.Models.Holiday>> Handle(GetHolidaysRequsetModels request, CancellationToken cancellationToken)
        {
            try
            {
                using var _db = new officeContext();

                var holidays = _db.Holidays
                    .Include(h => h.User)
                    .Where(h => h.Isdelete != true)
                    .OrderBy(h => h.Datestart)
                    .ToList();

                if(request.Start != null || request.End != null)
                {
                    holidays = holidays.Where(h => h.Datestart > request.Start || h.Dateend < request.End).ToList();
                }
                else if(request.Start != null && request.End != null)
                {
                    holidays = holidays.Where(h => h.Datestart > request.Start && h.Dateend < request.End).ToList();
                }

                if(request.id != null)
                {
                    holidays = holidays.Where(h => h.Userid == request.id).ToList();
                }

                return Task.FromResult(holidays);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
