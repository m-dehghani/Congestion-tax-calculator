using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Abstract;
using Microsoft.VisualBasic;

namespace Domain.Services.Concrete
{
    public class NewTaxCalculator
    {
        
        private City _city;


        public NewTaxCalculator(City city)
        {
            this._city = city;
        }

        public decimal GetTax(Vehicle vehicle)
        {
            if(_city.IsTollFreeVehicle(vehicle)) return 0;

            decimal sum = 0;
            var firstDate = vehicle.Entries[0];
            var secondDate = vehicle.Entries[1];
          
            sum = SumofDays(secondDate, firstDate, sum);

            var sumOfTrimmed = SumOfMinutes(firstDate, secondDate);
            sum += sumOfTrimmed >= _city.MaxTotalfeePerDay ? _city.MaxTotalfeePerDay : sumOfTrimmed ;

            return sum;
        }

        private decimal SumOfMinutes(DateTime firstDate, DateTime secondDate)
        {
            var trimmedByStartDate = _city.TaxLineItems.SkipWhile(c => c.End < TimeOnly.FromDateTime(firstDate));
            var trimmedByEndDate = trimmedByStartDate.TakeWhile(c => c.Start < TimeOnly.FromDateTime(secondDate));

            var sumOfTrimmed = trimmedByEndDate.Sum(s => s.TaxAmount);
            return sumOfTrimmed;
        }

        private decimal SumofDays(DateTime secondDate, DateTime firstDate, decimal sum)
        {
            var diffDays = (secondDate - firstDate).Days;

            if (diffDays > 0)
            {
                var notTollFreeDates = Enumerable.Range(0, diffDays).Select(r => firstDate.AddDays(r))
                    .Where(s => !_city.IsTollFreeDate(s));

                sum += notTollFreeDates.Count() * _city.MaxTotalfeePerDay;
            }

            return sum;
        }
    }
}
