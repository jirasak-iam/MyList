using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Common
{
    public static class Constants
    {
        public static string[] badWord = { "no", "to" ,"!","@","#","$","%","&","*","(",")","-","_","+","=","is","am","are","1","2","3","4","5","6","7", "8", "9", "0","ภาค" };
        public static string UserApp = "C# Win App";
        /// <summary>
        /// A - เปิดใช้งาน
        /// </summary>
        [Description("A - เปิดใช้งาน")]
        public static string Active = "เปิดใช้งาน";
        /// <summary>
        /// C - ปิดใช้งาน
        /// </summary>
        [Description("C - ปิดใช้งาน")]
        public static string Close = "ปิดใช้งาน";
    }
    public class RecStatus
    {
        /// <summary>
        /// A - เปิดใช้งาน
        /// </summary>
        [Description("A - เปิดใช้งาน")]
        public const string Active = "A";
        /// <summary>
        /// C - ปิดใช้งาน
        /// </summary>
        [Description("C - ปิดใช้งาน")]
        public const string Close = "C";
    }
    public class MappingParam
    {
        /// <summary>
        /// STS - สถานะรายการ
        /// </summary>
        [Description("STS - สถานะรายการ")]
        public const string Status = "STS";
        /// <summary>
        /// LTYP - สถานะรายการ
        /// </summary>
        [Description("LTYP - สถานะรายการ")]
        public const string ListType = "LTYP";
        /// <summary>
        /// GEN - หมวดหมู่เนิ้อหา
        /// </summary>
        [Description("GEN - หมวดหมู่เนิ้อหา")]
        public const string Genre = "GEN";
        /// <summary>
        /// SEA - ฤดูกาล
        /// </summary>
        [Description("SEA - ฤดูกาล")]
        public const string Season = "SEA";
        /// <summary>
        /// MAP - Mapping Setting Parameters
        /// </summary>
        [Description("MAP - Mapping Setting Parameters")]
        public const string MapSetingParameter = "MAP";
    }
    public class SeasonValue
    {
        [Description("Winter")]
        public const string Winter = "1";
        [Description("Spring")]
        public const string Spring = "2";
        [Description("Summer")]
        public const string Summer = "3";
        [Description("Fall")]
        public const string Fall = "4";
    }
    public enum SeasonList
    {
        Winter =1,
        Spring=2,
        Summer=3,
        Fall=4
    }

}
