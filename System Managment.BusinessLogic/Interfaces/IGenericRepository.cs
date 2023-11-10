using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Managment.BL.Interfaces
{
    public interface IGenericRepository<Entity>
    {

        void Add(Entity entity );
        void Delete(Entity entity);
        IEnumerable<Entity> GetAll();
        Entity GetById(Predicate<Entity> filter);
    }
}
