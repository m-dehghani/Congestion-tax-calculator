using Domain.Entities;

namespace Congestion_tax_calculator_UI.Services
{
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(string type, DateTime[] dates)
        {
            return type switch
            {
                "car" => new Car(dates),
                "motorbike" => new Motorbike(dates),
                _ => throw new NotImplementedException()
            };
        }
    }
}
