using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Abstract
{
    public abstract class Vehicle : Entity
    {
        public Vehicle(List<DateTime> entriesDates, string plateNo, string description = "")
        {
            {
                PlateNo = plateNo;
                Description = description;
                Entries = entriesDates;
            }
        }

        [Key]
        public string PlateNo { get; set; }

        public abstract string GetVehicleType();

        public List<DateTime> Entries { get; set; } = new List<DateTime>();
    }
}