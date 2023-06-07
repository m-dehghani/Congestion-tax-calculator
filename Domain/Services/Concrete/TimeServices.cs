//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.Services.Concrete
//{
//    public static class TimeServices
//    {
//        public static List<DateTime> CreateIntervals(DateTime start, DateTime end, int minutes)
//        {
//            if (end <= start || (end - start).TotalMinutes < minutes)
//            {
//                return new List<DateTime>();
//            }

//            var temp = Enumerable.Range(0, ((int)(end.Subtract(start).TotalMinutes / (minutes))));

//            static bool Filter(DateTime s)
//            {
//                var cond = (s.Hour, s.Minute) switch
//                {
//                    (7, 30) => false,
//                    { Hour: var x, Minute: var y } when x > 8 && (x <= 14) => false,
//                    { Hour: var x, Minute: var y } when x == 16 => false,
//                    (17, 30) => false,
//                    { Hour: var x, Minute: var y } when x >= 18 && x <= 23 => false,
//                    { Hour: var x, Minute: var y } when x >= 0 && x < 6 => false,
//                    _ => true
//                };
//                return cond;
//            }

//            return temp.Select(offset => start.AddMinutes(offset * minutes)).ToList().Where(Filter).ToList();
//        }
//    }
//}
