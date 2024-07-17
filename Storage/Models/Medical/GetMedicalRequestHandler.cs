using MediatR;
using Realization.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.Medical
{
    public class GetMedicalRequestHandler : IRequest<List<MedicalDTO>>
    {
        public int? UserId { get; set; }
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
