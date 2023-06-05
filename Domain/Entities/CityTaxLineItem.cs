using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CityTaxLineItem
    {
        public int Id { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
