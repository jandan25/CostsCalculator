using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FoodCalculator.Data
{
    public class CostsService
    {
        private static IConfiguration _config;

        public CostsService(IConfiguration config){
            _config = config;
        }
        public static Task<DayInfo[]> GetRandomDaysAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, _config.GetValue<int>("DayData:DaysCount")).Select(index => new DayInfo
            {
                Date = startDate.AddDays(index),
                Day = GetDayOfWeek(startDate.AddDays(index)),
                BasePay = GetDayOfWeek(startDate.AddDays(index)) == DayType.WorkDay ? _config.GetValue<int>("DayData:BasePay") : _config.GetValue<int>("DayData:ZeroPay")
            }).ToArray());
        }

        private static DayType GetDayOfWeek(DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return DayType.Weekend;
            }
            return DayType.WorkDay;
        }

        private static DayInfo[] SetDoNotWorkDays(DayInfo[] mealsInfos)
        {
            if (mealsInfos.All(c => c.Day != DayType.FirstDay)) return mealsInfos;
            foreach (var mealsInfo in mealsInfos)
            {
                if (mealsInfo.Day != DayType.FirstDay)
                {
                    mealsInfo.Day = DayType.DontWork;
                    mealsInfo.BasePay = _config.GetValue<int>("DayData:ZeroPay");
                }
                else
                {
                    break;
                }
            }

            return mealsInfos;
        }

        private static DayInfo[] SetFiredDays(DayInfo[] mealsInfos)
        {
            var lastDaySelected = false;
            if (mealsInfos.All(c => c.Day != DayType.LastDay)) return mealsInfos;
            foreach (var mealsInfo in mealsInfos)
            {
                if (mealsInfo.Day == DayType.LastDay)
                {
                    lastDaySelected = true;
                    mealsInfo.Day = DayType.LastDay;
                    continue;
                }

                if (!lastDaySelected) continue;
                mealsInfo.Day = DayType.Fired;
                mealsInfo.BasePay = _config.GetValue<int>("DayData:ZeroPay");
            }
            
            return mealsInfos;
        }

        public static DayInfo[] SetFilter(DayInfo[] mealsInfos)
        {
            mealsInfos = SetDoNotWorkDays(mealsInfos);
            mealsInfos = SetFiredDays(mealsInfos);
            return mealsInfos;
        }
    }
}