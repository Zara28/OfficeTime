using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models
{
    public class DeleteUserRequestModel : IRequest
    {
        public int UserId { get; set; }
    }
}
