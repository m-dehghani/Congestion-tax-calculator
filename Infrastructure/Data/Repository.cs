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
    public static class FileRepository
    {
       public static City? GetCity(string name)
       {
          return JsonConvert.DeserializeObject(File.ReadAllText($@"{name}")) as City;
        }
    }
}
