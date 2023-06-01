using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   
    public class City:Entity
    {
        public string CityName { get; set; }

        public DateTime[]? TollFreeDates { get; set; }
       
        //These can be read from file or DB
        public List<CityTaxLineItem> TaxLineItems { get; set; } = new List<CityTaxLineItem>();

        
    }
}
