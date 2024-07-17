using MediatR;
using Realization.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models
{
    public class GetHolidaysRequsetModels : IRequest<List<HolidayDTO>>
    {
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public int? id { get; set; }
    }
}
