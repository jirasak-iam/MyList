using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class SeasonGroupModel : BaseModel
    {
        public int seagroupId { get; set; }
        public int seaId { get; set; }
        public int listTypeId { get; set; }
    }
}
