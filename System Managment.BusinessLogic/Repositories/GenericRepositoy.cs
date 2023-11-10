using Sales_Managment.BL.Interfaces;
using Sales_Managment.DAL.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Managment.BL.Repositories
{
    public class GenericRepositoy<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private  List<Entity> list;
        public GenericRepositoy()
        {
            list = DataStore<Entity>.LoadData();
        }

        public virtual void Add(Entity entity)
        {
                list.Add(entity);
                DataStore<Entity>.Save(list);
        }

        public void Delete(Entity entity)
        {
            
            list.Remove(entity);
            DataStore<Entity>.Save(list);
        }

        public IEnumerable<Entity> GetAll()
        {
            return list;
        }

        public Entity GetById( Predicate<Entity> filter)//p=> p.id==1

        {
            return list.Find(filter);
        }

        
    }
}
