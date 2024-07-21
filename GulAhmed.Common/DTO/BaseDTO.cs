using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulAhmed.TIS.Common.DTO
{
    public abstract class BaseDTO
    {
        public string CreatedBy  { get; set; }
        public DateTime CreatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
