using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Model
{
    public class ConsumeTypeModel : BaseModel
    {
        public int consumeTypeId { get; set; }
        public string consumeTypeCode { get; set; }
        public string consumeTypeDesc { get; set; }
        public string consumeTypDisplay { get { return string.IsNullOrEmpty(consumeTypeCode) ? consumeTypeDesc : $"{consumeTypeCode} - {consumeTypeDesc}"; } }
    }
}
