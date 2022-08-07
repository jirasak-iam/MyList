using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateMyList.Entity.Model
{
    public class DataGridViewModel
    {
        public int? listCode { get; set; }
        public string listName { get; set; }
        public string listLink { get; set; }
        public string stsDesc { get; set; }
        public string listEP { get; set; }
        public string seasonDesc { get; set; }
        public string genreDesc { get; set; }
        public string updateDateStr { get; set; }
    }
}
