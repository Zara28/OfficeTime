using MediatR;
using Microsoft.EntityFrameworkCore;
using Realization.DBModels;
using Realization.DTOModels;
using Realization.Models.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handlers.Medical
{
    public class GetMedicalRequestHandler : IRequestHandler<GetMedicalRequestModel, List<MedicalDTO>>
    {
        public GetMedicalRequestHandler()
        {

        }
        public Task<List<MedicalDTO>> Handle(GetMedicalRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var medical = _db.Medicals.Include(m => m.User)
                .Select(m => new MedicalDTO
                {
                    Id = m.Id,
                    DateCreate = (DateTime)m.Datecreate,
                    DateEnd = (DateTime)m.Dateend,
                    DateStart = (DateTime)m.Datestart,
                    User = new UserDTO
                    {
                        Id = (int)m.Userid,
                        FIO = m.User.Fio,
                        DateBirth = (DateTime)m.User.Datebirth,
                        DateStart = (DateTime)m.User.Datestart
                    }
                }).ToList();

            if (request.Start != null || request.End != null)
            {
                medical = medical.Where(h => h.DateStart > request.Start || h.DateEnd < request.End).ToList();
            }
            else if (request.Start != null && request.End != null)
            {
                medical = medical.Where(h => h.DateStart > request.Start && h.DateEnd < request.End).ToList();
            }

            if (request.UserId != null)
            {
                medical = medical.Where(h => h.User.Id == request.UserId).ToList();
            }

            return Task.FromResult(medical);
        }
    }
}
