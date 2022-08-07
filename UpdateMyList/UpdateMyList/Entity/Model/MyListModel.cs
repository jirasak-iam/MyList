using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class MyListModel :BaseModel
    {
        public int listId { get; set; }
        public int listTypeId { get; set; }
        public int? listCode { get; set; }
        public string listName { get; set; }
        public string listLink { get; set; }
        public string listEP { get; set; }
        public string listComment { get; set; }
        public int stsId { get; set; }
        public string stsDesc { get; set; }
        public int? seasonId { get; set; }
        public string seasonDesc { get; set; }
        public string genDesc { get; set; }
    }
}
