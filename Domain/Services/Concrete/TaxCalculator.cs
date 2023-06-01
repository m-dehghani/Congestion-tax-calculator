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
        private City _city;

        public TaxCalculator(City city)
        {
            this._city = city;
        }

        public int GetTax(Vehicle vehicle)
        {
            var dates = vehicle.Dates;
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates.Skip(1))
            {
                //TODO: These should be read from City.GetTollFee()
                int nextFee = TollService.GetTollFee(date, vehicle);
                int tempFee = TollService.GetTollFee(intervalStart, vehicle);

                var diff = date - intervalStart;
                var minutes = diff.TotalMinutes;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += (diff.Days * 60);
                    var intervals = TimeServices.CreateIntervals(intervalStart, date, 30);
                    totalFee += intervals.Select(i => TollService.GetTollFee(i, vehicle)).Sum();
                }
            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }
    }
}
