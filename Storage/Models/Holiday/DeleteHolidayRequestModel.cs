using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.Holiday
{
    public class DeleteHolidayRequestModel : IRequest
    {
        public int HolidayId { get; set; }
    }
}
