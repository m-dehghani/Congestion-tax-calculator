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
        public Car( DateTime[] entranceDates , string name ="", string description= "" )
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