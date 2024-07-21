using MediatR;
using Realization.DBModels;
using Realization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Handlers
{
    public class CreateMedicalRequestHandler : IRequestHandler<MedicalCreateRequestModel>
    {
        public async Task Handle(MedicalCreateRequestModel request, CancellationToken cancellationToken)
        {
            using var _db = new officeContext();

            var medical = new DBModels.Medical
            {
                Userid = request.User,
                Datecreate = request.DateCreate,
                Dateend = request.DateEnd,
                Datestart = request.DateStart,
            };

            _db.Medicals.Add(medical);

            await _db.SaveChangesAsync();
        }
    }
}
