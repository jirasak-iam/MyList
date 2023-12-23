using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class SeasonMastModel : BaseModel
    {
        public int seaId { get; set; }
        public string seaCode { get; set; }
        public string seaDesc { get; set; }
        public string seasonDisplay { get { return !string.IsNullOrEmpty(seaCode) ? $"{seaCode} - {seaDesc}" : "--------Select--------" ; } }
    }
}
