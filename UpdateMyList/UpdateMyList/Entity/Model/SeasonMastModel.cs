using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class SeasonMastModel : BaseModel
    {
        public int seasonId { get; set; }
        public string seasonCode { get; set; }
        public string seasonDesc { get; set; }
        public string seasonDisplay { get { return !string.IsNullOrEmpty(seasonCode) ? $"{seasonCode} - {seasonDesc}" : "--------Select--------" ; } }
    }
}
