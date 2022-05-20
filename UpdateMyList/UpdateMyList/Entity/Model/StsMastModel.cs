using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class StsMastModel : BaseModel
    {
        public int stsId { get; set; }
        public string stsCode { get; set; }
        public string stsDesc { get; set; }
    }
}
