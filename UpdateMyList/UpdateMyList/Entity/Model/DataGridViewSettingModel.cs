using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpdateMyList.Common;

namespace UpdateMyList.Entity.Model
{
    public class DataGridViewSettingModel
    {
        public string code { get; set; }
        public string desc { get; set; }
        public string recStatus { get; set; }
        public string updateDate { get; set; }
        public int? sortSeq { get; set; }
    }
}
