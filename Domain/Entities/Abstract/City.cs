using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Services.Abstract;

namespace Domain.Entities.Abstract
{

    public abstract class City : Entity
    {
        public string CityName { get; set; }

        public List<DateTime> TollFreeDates { get; set; } = new List<DateTime>();
       
        public TollFreeVehicles TollFreeVehicles { get; set; }

        //These can be read from file or DB
        public List<CityTaxLineItem> TaxLineItems { get; set; } = new List<CityTaxLineItem>();

        public int MaxTotalfeePerDay { get; set; }

        public bool IsTollFreeDate(DateTime date) => TollFreeDates.Contains(date);

        public bool IsTollFreeVehicle(Vehicle vehicle)
        {
            TollFreeVehicles.TryParse(vehicle.GetVehicleType(), true, out TollFreeVehicles tl);

           return TollFreeVehicles.HasFlag(tl);
        }

        public abstract decimal CalcTax(Vehicle vehicle);
    }
}
