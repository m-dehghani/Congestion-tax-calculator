using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Motorbike : Vehicle
    {
        public Motorbike(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public override string GetVehicleType()
        {
            return "Motorbike";
        }
    }
}