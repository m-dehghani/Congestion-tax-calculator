using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Abstract;
using Domain.Enums;

namespace Domain.Entities.Concrete
{
    public class Car : Vehicle
    {
        public Car(List<DateTime> entriesDates, string plateNo, string description = "") : base(entriesDates, plateNo, description)
        {

        }
        
        public override string GetVehicleType()
        {
            return "Car";
        }
    }
}