using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Managment.DAL.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();  
        public int CustomerId { get; set; }


        

    }
}
