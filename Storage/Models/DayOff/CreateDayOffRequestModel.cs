using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.DayOff
{
    public class CreateDayOffRequestModel : IRequest
    {
        public int UserId { get; set; }

        public DateTime DateCreate { get; set; }

    }
}
