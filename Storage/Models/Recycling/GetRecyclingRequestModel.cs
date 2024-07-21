using MediatR;
using Realization.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.Recycling
{
    public class GetRecyclingRequestModel : IRequest<List<RecyclingDTO>>
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }

        public DateTime? DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
