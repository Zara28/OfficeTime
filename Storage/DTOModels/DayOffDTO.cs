using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.DTOModels
{
    public class DayOffDTO
    {
        public int Id { get; set; }

        public UserDTO User { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateCreate { get; set; }

        public bool IsApproved { get; set; }
    }
}
