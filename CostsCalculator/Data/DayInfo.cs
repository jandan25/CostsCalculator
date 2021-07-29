using System;

namespace FoodCalculator.Data
{
    public class DayInfo
    {
        public DateTime Date { get; set; }

        public DayType Day { get; set; }

        public int BasePay { get; set; } = 200;
    }
}