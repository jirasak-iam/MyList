using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class ListTypeModel :BaseModel
    {
        public int listTypeId { get; set; }
        public string listTypeCode { get; set; }
        public string listTypeDesc { get; set; }
        public int sortSeq { get; set; }
    }
}
