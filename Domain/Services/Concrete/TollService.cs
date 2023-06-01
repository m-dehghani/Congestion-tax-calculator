using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Concrete
{
    public static class TollService
    {
        private static bool IsTollFreeVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return false;
            var vehicleType = vehicle.GetVehicleType();
            return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Military.ToString());
        }

        //TODO: these should be read from City in file
        public static int GetTollFee(DateTime date, Vehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            var hour = date.Hour;
            var minute = date.Minute;

            switch (hour)
            {
                case 6 when minute >= 0 && minute <= 29:
                    return 8;
                case 6 when minute >= 30 && minute <= 59:
                    return 13;
                case 7 when minute >= 0 && minute <= 59:
                    return 18;
                case 8 when minute >= 0 && minute <= 29:
                    return 13;
                case >= 8 and <= 14 when minute >= 30 && minute <= 59:
                    return 8;
                case 15 when minute >= 0 && minute <= 29:
                    return 13;
                case 15 when minute >= 0:
                case 16 when minute <= 59:
                    return 18;
                case 17 when minute >= 0 && minute <= 59:
                    return 13;
                case 18 when minute >= 0 && minute <= 29:
                    return 8;
                default:
                    return 0;
            }
        }

        private static Boolean IsTollFreeDate(DateTime date)
        {
            var year = date.Year;
            var month = date.Month;
            var day = date.Day;

            if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday) return true;

            if (year != 2013) return false;
            return month == 1 && day == 1 ||
                   month == 3 && day is 28 or 29 ||
                   month == 4 && day is 1 or 30 ||
                   month == 5 && day is 1 or 8 or 9 ||
                   month == 6 && day is 5 or 6 or 21 ||
                   month == 7 ||
                   month == 11 && day == 1 ||
                   month == 12 && day is 24 or 25 or 26 or 31;
        }
    }
}
