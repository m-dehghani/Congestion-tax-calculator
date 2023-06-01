using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City:Entity
    {
        public string CityName;
        public string[][] Rules;

        public City(string cityName , string[][] rules)
        {
            CityName = cityName;
            Rules = rules;
        }
    }
}
