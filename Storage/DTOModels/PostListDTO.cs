using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.DTOModels
{
    public class PostListDTO : PostDTO
    {
        public List<UserDTO> Users { get; set; }
    }
}
