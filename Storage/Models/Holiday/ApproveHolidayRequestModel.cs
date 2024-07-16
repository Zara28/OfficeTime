using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.Holiday
{
    public class ApproveHolidayRequestModel : IRequest
    {
        public int id;
        public bool isDirect;
    }
}
