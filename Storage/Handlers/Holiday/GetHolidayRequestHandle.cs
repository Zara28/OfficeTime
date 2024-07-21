using MediatR;
using Microsoft.EntityFrameworkCore;
using Realization.DBModels;
using Realization.DTOModels;
using Realization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handles
{
    public class GetHolidayRequestHandle : IRequestHandler<GetHolidaysRequsetModels, List<HolidayDTO>>
    {
        public GetHolidayRequestHandle()
        {

        }
        public Task<List<HolidayDTO>> Handle(GetHolidaysRequsetModels request, CancellationToken cancellationToken)
        {
            try
            {
                using var _db = new officeContext();

                var holidays = _db.Holidays
                    .Include(h => h.User)
                    .Select(h => new HolidayDTO
                    {
                        Id = h.Id,
                        User = new UserDTO
                        {
                            Id = (int)h.Userid,
                            FIO = h.User.Fio,
                            DateBirth = (DateTime)h.User.Datebirth,
                            DateStart = (DateTime)h.User.Datestart
                        },
                        DateStart = (DateTime)h.Datestart,
                        DateEnd = (DateTime)h.Dateend,
                        DateApprove = h.Dateapp,
                        IsApprovedAdmin = (bool)h.Isappadmin,
                        IsApprovedDirector = (bool)h.Isappdirect,
                        IsPay   = (bool)h.Ispay,
                    })
                    .OrderBy(h => h.DateStart)
                    .ToList();

                if(request.Start != null || request.End != null)
                {
                    holidays = holidays.Where(h => h.DateStart > request.Start || h.DateEnd < request.End).ToList();
                }
                else if(request.Start != null && request.End != null)
                {
                    holidays = holidays.Where(h => h.DateStart > request.Start && h.DateEnd < request.End).ToList();
                }

                if(request.id != null)
                {
                    holidays = holidays.Where(h => h.User.Id == request.id).ToList();
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
