using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueTypes;

namespace Domain.Services.Concrete
{
    public class TaxCalculator
    {
        private const int MAXTOTALFEEPERDAY = 60;
        private City _city;


        public TaxCalculator(City city)
        {
            this._city = city;
        }

        public int GetTax(Vehicle vehicle)
        {
            int totalFee = CalcTotalFee(vehicle, vehicle.Dates);
            return totalFee > MAXTOTALFEEPERDAY ? MAXTOTALFEEPERDAY : totalFee;
        }

        private static int CalcTotalFee(Vehicle vehicle, DateTime[] dates)
        {
            var totalFee = 0;
            DateTime intervalStart = dates[0];
            foreach (DateTime date in dates.Skip(1))
            {
                //TODO: These should be read from City.GetTollFee()
               totalFee += GetFeeOfMinutes(vehicle, date, intervalStart, totalFee, TollService.GetTollFee(intervalStart, vehicle), TollService.GetTollFee(date, vehicle));
            }

            return totalFee;
        }

        private static int GetFeeOfMinutes(Vehicle vehicle, DateTime intervalEnd, DateTime intervalStart, int totalFee, int tempFee,
            int nextFee)
        {
            var diff = intervalEnd - intervalStart;
            if (diff.TotalMinutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += (diff.Days * MAXTOTALFEEPERDAY);
                var intervals = TimeServices.CreateIntervals(intervalStart, intervalEnd, 30);
                totalFee += intervals.Select(i => TollService.GetTollFee(i, vehicle)).Sum();
            }

            return totalFee;
        }
    }
}
