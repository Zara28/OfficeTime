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
    public class GetDaysOffRequestHandle : IRequestHandler<GetDaysOffRequestModel, List<DayOffDTO>>
    {
        public GetDaysOffRequestHandle()
        {

        }
        public Task<List<DayOffDTO>> Handle(GetDaysOffRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                using var _db = new officeContext();

                var holidays = _db.Dayoffs
                    .Include(h => h.User)
                    .Where((h => (h.Date < request.Start || h.Date <= request.End)
                    && (request.id != null) && h.Userid == request.id))
                    .Select(h => new DayOffDTO
                    {
                        Id = h.Id,
                        User = new UserDTO
                        {
                            Id = (int)h.Userid,
                            FIO = h.User.Fio,
                            DateBirth = (DateTime)h.User.Datebirth,
                            DateStart = (DateTime)h.User.Datestart
                        },
                        IsApproved = (bool)h.Isapp,
                        Date = (DateTime)h.Datecreate,
                        DateCreate = (DateTime)h.Datecreate,
                    })
                    .ToList();

                if (request.Start != null || request.End != null)
                {
                    holidays = holidays.Where(h => h.Date > request.Start || h.Date < request.End).ToList();
                }
                else if (request.Start != null && request.End != null)
                {
                    holidays = holidays.Where(h => h.Date > request.Start && h.Date < request.End).ToList();
                }

                if (request.id != null)
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
