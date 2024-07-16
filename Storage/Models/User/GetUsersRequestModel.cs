using MediatR;
using Realization.Database.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models
{
    public class GetUsersRequestModel : IRequest<List<User>>
    {
        public int? id { get; set; }
    }
}
