using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UpdateMyList.Common;
using UpdateMyList.Entity;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GenreMast, GenreMast>();
            CreateMap<SeasonMast, SeasonMast>();
        }
    }
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
        public static List<SeasonMastModel> GetSeasonalList()
        {
            var result = new List<SeasonMastModel>();
            result.Add(
               new SeasonMastModel
               {
                   seaCode = SeasonValue.Winter,
                   seaDesc = SeasonList.Winter.ToString(),
               });
            result.Add(
               new SeasonMastModel
               {
                   seaCode = SeasonValue.Spring,
                   seaDesc = SeasonList.Spring.ToString(),
               });
            result.Add(
               new SeasonMastModel
               {
                   seaCode = SeasonValue.Summer,
                   seaDesc = SeasonList.Summer.ToString(),
               });
            result.Add(
               new SeasonMastModel
               {
                   seaCode = SeasonValue.Fall,
                   seaDesc = SeasonList.Fall.ToString(),
               });
            return result.OrderBy(o => o.seaCode).ToList();
        }
        public static DateTime ConvertDateTHToEn(string dateStr)
        {
            var dateTime = DateTime.Now;
            var dateTimeArray = dateStr.Split(' ');
            try
            {
                if (dateTimeArray.Length == 2)
                {
                    var date = dateTimeArray[0].Split('/');
                    var time = dateTimeArray[1].Split(':');

                    var day = Convert.ToInt32(date[0]);
                    var month = Convert.ToInt32(date[1]);
                    var year = Convert.ToInt32(date[2]) - 543;

                    var hour = Convert.ToInt32(time[0]);
                    var minute = Convert.ToInt32(time[1]);
                    var sec = Convert.ToInt32(time[2]);

                    dateTime = new DateTime(year, month, day, hour, minute, sec);
                }
            }
            catch (Exception)
            {
                dateTime = DateTime.Now;
            }
            return dateTime;
        }
    }
}
