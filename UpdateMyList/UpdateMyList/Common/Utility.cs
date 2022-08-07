using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Common
{
    public class Utility
    {
        public static string SetRecDesc(string recStatus)
        {
            var result = string.Empty;
            if (RecStatus.Active.Equals(recStatus))
            {
                result = Constants.Active;
            }
            else if(RecStatus.Close.Equals(recStatus))
            {
                result = Constants.Close;
            }
            return result;
        }

        public static List<RecStatusModel> GetRecStatus()
        {
            var result = new List<RecStatusModel>();
            result.Add(
               new RecStatusModel
               { 
                   recStatus = RecStatus.Active,
                   recDesc = Constants.Active
               });
            result.Add(
               new RecStatusModel
               {
                   recStatus = RecStatus.Close,
                   recDesc = Constants.Close
               });
            return result.OrderBy(o => o.recStatus).ToList();
        }
    }
}
