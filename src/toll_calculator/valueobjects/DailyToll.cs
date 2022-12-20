﻿namespace toll_calculator.valueobjects
{
    internal record DailyToll
    {
        private readonly TimeSpan start;
        private readonly TimeSpan end;

        public DailyToll(TimeSpan start, TimeSpan end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Contains(DateTime dateTime)
        {
            var timeOfDay = dateTime.TimeOfDay;
            var startOrGreater = start <= timeOfDay;
            var lowerThanEnd = timeOfDay < end;
            return startOrGreater && lowerThanEnd;
        }

        public static DailyToll _0000_0600 => new(new TimeSpan(0, 0, 0), new TimeSpan(6, 0, 0));
        public static DailyToll _0600_0630 => new(new TimeSpan(6, 0, 0), new TimeSpan(6, 30,0));
        public static DailyToll _0630_0700 => new(new TimeSpan(6, 30, 0), new TimeSpan(7, 0,0));
        public static DailyToll _0700_0800 => new(new TimeSpan(7, 0, 0), new TimeSpan(8, 0,0));
        public static DailyToll _0800_0830 => new(new TimeSpan(8, 0, 0), new TimeSpan(8, 30,0));
        public static DailyToll _0830_1500 => new(new TimeSpan(8, 30, 0), new TimeSpan(15, 00,0));
        public static DailyToll _1500_1530 => new(new TimeSpan(15, 0, 0), new TimeSpan(15, 30,0));
        public static DailyToll _1530_1700 => new(new TimeSpan(15, 30, 0), new TimeSpan(17, 00,0));
        public static DailyToll _1700_1800 => new(new TimeSpan(17, 0, 0), new TimeSpan(18, 0,0));
        public static DailyToll _1800_1830 => new(new TimeSpan(18, 0, 0), new TimeSpan(18, 30,0));
        public static DailyToll _1830_2400 => new(new TimeSpan(18, 30, 0), new TimeSpan(24, 0, 0));
        
    }
}
