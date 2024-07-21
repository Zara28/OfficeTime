using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.DTOModels
{
    public class HolidayDTO
    {
        public int Id { get; set; }

        public UserDTO User { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateApprove { get; set; }

        public bool IsApprovedAdmin { get; set; }
        public bool IsApprovedDirector { get; set; }
        public bool IsPay { get; set; }
    }
}
