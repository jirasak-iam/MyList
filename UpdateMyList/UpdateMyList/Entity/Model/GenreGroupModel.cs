using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class GenreGroupModel : BaseModel
    {
        public int gengroupId { get; set; }
        public int genId { get; set; }
        public string genCode { get; set; }
        public string genDesc { get; set; }
        public int listId { get; set; }
    }
}
