using Domain.Entities;
using Domain.Entities.Abstract;
using Domain.Entities.Concrete;

namespace Congestion_tax_calculator_UI.Services
{
    public static class VehicleFactory
    {
        static List<Vehicle> _vehicles = new List<Vehicle>();
        public static Vehicle CreateVehicle(string type,string plateNo, List<DateTime> dates)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.PlateNo == plateNo);
            if (vehicle == null) return vehicle;
           switch(type.ToLower())
           {
                case "car":
                    vehicle = new Car(dates, plateNo,"");
                    break;

                case "motorbike":
                    vehicle = new Motorbike(dates, plateNo, "");
                    break;

                default: throw new NotImplementedException();
            };
           _vehicles.Add(vehicle);
           return vehicle;
        }
    }
}
