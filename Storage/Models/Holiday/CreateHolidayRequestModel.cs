using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models.Holiday
{
    public class CreateHolidayRequestModel : IRequest
    {

        public DateTime? Datestart { get; set; }

        public DateTime? Dateend { get; set; }

        public bool? Isappadmin { get; set; }

        public bool? Isappdirect { get; set; }

        public int? Userid { get; set; }

        public DateTime? Datecreate { get; set; }

        public bool? Isdelete { get; set; }
    }
}
