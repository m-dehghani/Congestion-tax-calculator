using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Car : Vehicle
    {
        public Car(string name, string description , DateTime[] entranceDates)
        {
            Name = name;
            Description = description;
            Dates = entranceDates;
        }
        public override string GetVehicleType()
        {
            return "Car";
        }
    }
}