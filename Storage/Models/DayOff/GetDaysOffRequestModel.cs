using MediatR;
using Realization.Database.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models
{
    public class GetDaysOffRequestModel:IRequest<List<Dayoff>>
    {
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public int? id { get; set; }
    }
}
