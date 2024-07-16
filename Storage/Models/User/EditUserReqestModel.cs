using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realization.Models
{
    public class EditUserReqestModel : IRequest
    {
        public int Id { get; set; }
        public string Fio { get; set; }

        public DateTime? Datebirth { get; set; }

        public DateTime? Datestart { get; set; }

        public int? Telegramid { get; set; }
    }
}
