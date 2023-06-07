//using System;
//using System.Reflection.Metadata.Ecma335;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Runtime.InteropServices.JavaScript;

//public class CongestionTaxCalculator
//{
//    /**
//         * Calculate the total toll fee for one day
//         *
//         * @param vehicle - the vehicle
//         * @param dates   - date and time of all passes on one day
//         * @return - the total congestion tax for that day
//         */

//    public int GetTax(Vehicle vehicle, DateTime[] dates)
//    {
//        DateTime intervalStart = dates[0];
//        int totalFee = 0;
//        foreach (DateTime date in dates.Skip(1))
//        {
//            int nextFee = GetTollFee(date, vehicle);
//            int tempFee = GetTollFee(intervalStart, vehicle);

//            var diff = date - intervalStart;
//            var minutes = diff.TotalMinutes;

//            if (minutes <= 60)
//            {
//                if (totalFee > 0) totalFee -= tempFee;
//                if (nextFee >= tempFee) tempFee = nextFee;
//                totalFee += tempFee;
//            }
//            else
//            {
//                totalFee += (diff.Days * 60);
//                var intervals = CreateIntervals(intervalStart, date, 30);
//                totalFee += intervals.Select(i => GetTollFee(i, vehicle)).Sum();
//            }
//        }
//        if (totalFee > 60) totalFee = 60;
//        return totalFee;
//    }

//    private List<DateTime> CreateIntervals(DateTime start, DateTime end, int minutes)
//    {
//        if (end <= start || (end - start).TotalMinutes < minutes)
//        {
//            return new List<DateTime>();
//        }

//        var temp = Enumerable.Range(0,((int)(end.Subtract(start).TotalMinutes/(minutes))));
//        bool Filter(DateTime s)
//        {
//            var cond = (s.Hour, s.Minute) switch
//            {
//                (7, 30) => false,
//                { Hour: var x, Minute: var y } when x > 8 && (x <= 14) => false,
//                { Hour: var x, Minute: var y } when x == 16 => false,
//                (17, 30) => false,
//                { Hour: var x, Minute: var y } when x >= 18  && x <= 23 => false,
//                { Hour: var x, Minute: var y } when x >= 0 && x < 6 => false,
//                _ => true
//            };
//            return cond;
//        } 

//        return temp.Select(offset => start.AddMinutes(offset * minutes)).ToList().Where(Filter).ToList();
//    }

//    private bool IsTollFreeVehicle(Vehicle vehicle)
//    {
//        if (vehicle == null) return false;
//        String vehicleType = vehicle.GetVehicleType();
//        return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
//               vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
//               vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
//               vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
//               vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
//               vehicleType.Equals(TollFreeVehicles.Military.ToString());
//    }

//    public int GetTollFee(DateTime date, Vehicle vehicle)
//    {
//        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

//        int hour = date.Hour;
//        int minute = date.Minute;

//        if (hour == 6 && minute >= 0 && minute <= 29) return 8;
//        else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
//        else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
//        else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
//        else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
//        else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
//        else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
//        else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
//        else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
//        else return 0;
//    }

//    private Boolean IsTollFreeDate(DateTime date)
//    {
//        int year = date.Year;
//        int month = date.Month;
//        int day = date.Day;

//        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

//        if (year == 2013)
//        {
//            if (month == 1 && day == 1 ||
//                month == 3 && (day == 28 || day == 29) ||
//                month == 4 && (day == 1 || day == 30) ||
//                month == 5 && (day == 1 || day == 8 || day == 9) ||
//                month == 6 && (day == 5 || day == 6 || day == 21) ||
//                month == 7 ||
//                month == 11 && day == 1 ||
//                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
//            {
//                return true;
//            }
//        }
//        return false;
//    }

//    private enum TollFreeVehicles
//    {
//        Motorcycle = 0,
//        Tractor = 1,
//        Emergency = 2,
//        Diplomat = 3,
//        Foreign = 4,
//        Military = 5
//    }
//}