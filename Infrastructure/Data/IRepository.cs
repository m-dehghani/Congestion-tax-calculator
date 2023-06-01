using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IRepository
    {
        public City? GetCity(string name);
        public void UpdateCity(City city);
        public void DeleteCity(City city);
        public IEnumerable<City> GetAll();
        public void Create(City city);

    }
}
