using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.Recycling
{
    public class ApproveRecyclingRequsetModel : IRequest
    {
        public int Id { get; set; }
    }
}
