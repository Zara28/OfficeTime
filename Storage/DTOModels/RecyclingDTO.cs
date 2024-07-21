using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.DTOModels
{
    public class RecyclingDTO
    {
        public int Id { get; set; }

        public UserDTO User { get; set; }

        public DateTime? Date { get; set; }

        public decimal? Hour { get; set; }

        public bool? Isapp { get; set; }

    }
}
