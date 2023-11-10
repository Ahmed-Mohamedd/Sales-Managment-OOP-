using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Managment.DAL.Entities
{
    public  class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $" Brand Name : {Name}";
        }
    }
}
