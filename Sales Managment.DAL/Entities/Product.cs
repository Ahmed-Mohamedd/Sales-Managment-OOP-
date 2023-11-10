using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Managment.DAL.Entities
{
    public  class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }


        public override string ToString()
        {
            return $"Id : {Id} , name : {Name} , price : {Price.ToString("c")} , Category : {Category.Name} , Brand : {Brand.Name} ";
        }
    }
}
