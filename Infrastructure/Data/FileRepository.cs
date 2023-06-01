using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Entities;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public  class FileRepository:IRepository
    {
       public  City? GetCity(string name)
       {
          return JsonConvert.DeserializeObject(File.ReadAllText($@"Data\{name}")) as City;
        }

       public void UpdateCity(City city)
       {
           throw new NotImplementedException();
       }

       public void DeleteCity(City city)
       {
           throw new NotImplementedException();
       }

       public IEnumerable<City> GetAll()
       {
           throw new NotImplementedException();
       }

       public void Create(City city)
       {
           throw new NotImplementedException();
       }
    }
}
