using System.Globalization;
using Congestion_tax_calculator_UI.Services;
using Domain.Entities.Abstract;
using Domain.Services.Concrete;

namespace Domain.Services.Abstract
{
    public class CityService
    {
        private readonly string _cityName;
        public CityService(string cityName)
        {
            _cityName = cityName;
        }
        public decimal CalcTax(string vehicleType,string plateNo,  List<DateTime> entriesTimes)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(vehicleType, plateNo, entriesTimes);
            City city = CityFactory.GetCity(_cityName);

            decimal tax = city.CalcTax(vehicle);
            return tax;
        }
    }
}
