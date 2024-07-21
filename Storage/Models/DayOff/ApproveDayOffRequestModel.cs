using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.DayOff
{
    public class ApproveDayOffRequestModel : IRequest
    {
        public int DayOffId { get; set; }
    }
}
