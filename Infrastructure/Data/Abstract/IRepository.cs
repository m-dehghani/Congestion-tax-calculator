using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Abstract;

namespace Infrastructure.Data.Abstract
{
    public interface IRepository
    {
        public Entity? Get(string key);
        public void Update(Entity entity);
        public void Delete(string key);
        public IEnumerable<Entity> GetAll();
        public void Create(Entity entity);

    }
}
