using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Abstract;
using Domain.Enums;
using Domain.Services.Abstract;
using Domain.Services.Concrete;

namespace Domain.Entities.Concrete
{
    public class GuthenbergCity : City
    {

        private readonly ICalculator taxCalculator;
        public GuthenbergCity(ICalculator taxCalculator)
        {
            //These parameter should be read from DB repository 

            CityName = "Guthenberg";
            TollFreeDates = new List<DateTime>();
            TollFreeVehicles = TollFreeVehicles.Diplomat | TollFreeVehicles.Emergency | TollFreeVehicles.Foreign |
                               TollFreeVehicles.Military | TollFreeVehicles.Motorcycle | TollFreeVehicles.Tractor;
            taxCalculator = new NewTaxCalculator(this);
            MaxTotalfeePerDay = 60;
            TaxLineItems = new List<CityTaxLineItem>()
            {
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(6, 0, 0),
                    End = new TimeOnly(06, 29, 0),
                    TaxAmount = 8
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(6, 30, 0),
                    End = new TimeOnly(06, 59, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(7, 0, 0),
                    End = new TimeOnly(7, 59, 0),
                    TaxAmount = 18
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(8, 0, 0),
                    End = new TimeOnly(8, 29, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(8, 30, 0),
                    End = new TimeOnly(14, 59, 0),
                    TaxAmount = 8
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(15, 0, 0),
                    End = new TimeOnly(15, 29, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(15, 30, 0),
                    End = new TimeOnly(16, 59, 0),
                    TaxAmount = 18
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(17, 0, 0),
                    End = new TimeOnly(17, 29, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(18, 0, 0),
                    End = new TimeOnly(18, 29, 0),
                    TaxAmount = 8
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(18, 30, 0),
                    End = new TimeOnly(05, 59, 0),
                    TaxAmount = 0
                },

            };
        }
        
        public override decimal CalcTax(Vehicle vehicle)
        {
            return taxCalculator.GetTax(vehicle);
        }
    }
}
