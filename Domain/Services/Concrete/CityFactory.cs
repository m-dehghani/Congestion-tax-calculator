using Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Concrete;

namespace Domain.Services.Concrete
{
    public static class CityFactory
    {
        static List<City> _cities = new List<City>();

        public static City GetCity(string name)
        {
            var city = _cities.FirstOrDefault(c => c.CityName == name);
            if (city == null)
            {
                switch (name.ToLower())
                {
                    case "guthenberg":
                        city = new GuthenbergCity();
                        // or city = repo.GetCity("guthenberg");
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            
            _cities.Add(city);
            return city;
        }
    }
}
