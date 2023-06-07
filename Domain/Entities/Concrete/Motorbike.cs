using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Domain.Entities.Concrete
{
    public class Motorbike : Vehicle
    {
        public Motorbike(List<DateTime> entriesDates, string plateNo = "", string description = ""): base(entriesDates, plateNo, description)
        {
        }

        public override string GetVehicleType()
        {
            return "Motorbike";
        }
    }
}