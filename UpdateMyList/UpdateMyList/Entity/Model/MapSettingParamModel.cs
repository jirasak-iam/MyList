using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class MapSettingParamModel : BaseModel
    {
        public int mapId { get; set; }
        public string mapCode { get; set; }
        public string mapDesc { get; set; }
        public string mapDisplay 
        { 
            get { return !string.IsNullOrEmpty(mapDesc) ?  $"{mapCode} - {mapDesc}({mapTbName})" : "------- Please Select -------"; } 
        }
        public string mapTbName { get; set; }
    }
}
