using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class BaseModel
    {
        private string formatDateStr = "dd/MM/yyyy HH:mm:ss";
        private CultureInfo culTH = new CultureInfo("th-TH");

        public string recStatus { get; set; }
        public string createBy { get; set; }
        public DateTime? createDate { get; set; }
        public string updateBy { get; set; }
        public DateTime? updateDate { get; set; }
        public string updateDateStr 
        {
            get { return updateDate != null ? updateDate?.ToString(formatDateStr, culTH) : DateTime.Now.ToString(formatDateStr, culTH); }
        }
    }
}
