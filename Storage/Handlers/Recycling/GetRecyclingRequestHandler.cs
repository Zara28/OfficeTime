using MediatR;
using Microsoft.EntityFrameworkCore;
using Realization.DBModels;
using Realization.DTOModels;
using Realization.Models.Recycling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handlers.Recycling
{
    public class GetRecyclingRequestHandler : IRequestHandler<GetRecyclingRequestModel, List<RecyclingDTO>>
    {
        public Task<List<RecyclingDTO>> Handle(GetRecyclingRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                using var _db = new officeContext();

                var recyclings = _db.Recyclings
                    .Include(h => h.User)
                    .Select(h => new RecyclingDTO
                    {
                        Id = h.Id,
                        User = new UserDTO
                        {
                            Id = (int)h.Userid,
                            FIO = h.User.Fio,
                            DateBirth = (DateTime)h.User.Datebirth,
                            DateStart = (DateTime)h.User.Datestart
                        },
                        Date = h.Date,
                        Isapp = h.Isapp,
                    })
                    .OrderBy(h => h.Date)
                    .ToList();

                if (request.DateStart != null || request.DateEnd != null)
                {
                    recyclings = recyclings.Where(h => h.Date > request.DateStart || h.Date < request.DateEnd).ToList();
                }
                else if (request.DateStart != null && request.DateEnd != null)
                {
                    recyclings = recyclings.Where(h => h.Date > request.DateStart && h.Date < request.DateEnd).ToList();
                }

                if (request.Id != null)
                {
                    recyclings = recyclings.Where(h => h.User.Id == request.Id).ToList();
                }

                if(request.UserId != null)
                {
                    recyclings = recyclings.Where(h => h.User.Id == request.UserId).ToList();
                }

                return Task.FromResult(recyclings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
