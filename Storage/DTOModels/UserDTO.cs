using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.DTOModels
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        
        public PostDTO Post { get; set; }

        public DateTime DateBirth {get; set; }
        public DateTime DateStart {get; set; }

        public float? HourCount {get; set; }
    }
}
