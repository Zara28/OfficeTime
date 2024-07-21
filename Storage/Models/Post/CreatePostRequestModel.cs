using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.Post
{
    public class CreatePostRequestModel : IRequest
    {
        public string Description { get; set; }

        public float? Salary { get; set; }
    }
}
