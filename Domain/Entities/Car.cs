using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : Vehicle
    {
        public Car(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public override string GetVehicleType()
        {
            return "Car";
        }

        public static void Enter(City guthenberg, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public static void Leave(City guthenberg, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}