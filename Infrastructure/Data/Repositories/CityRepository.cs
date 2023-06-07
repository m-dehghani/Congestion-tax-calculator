using Infrastructure.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Infrastructure.Data.Repositories
{
    public class CityRepository: IRepository
    {
        public Entity? Get(string key)
        {
            
            throw new NotImplementedException();
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
