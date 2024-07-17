using MediatR;
using Realization.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.Post
{
    public class GetPostRequestModel : IRequest<List<PostDTO>>
    {
        public int? PostId { get; set; } 
    }
}
