using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Managment.DAL.Entities
{
    public  class CartProduct:Product
    {
        public int? Count { get; set; } = 1;

        public override string ToString()
        {
            return $"Id : {Id} , name : {Name} , price : {Price.ToString("c")} , Category : {Category.Name} , Brand : {Brand.Name} , Count : {Count} ";
        }
    }
}
