using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Managment.DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();  

        public OrderDetails OrderDetails { get; set; }

        public Carrier Carrier { get; set; }

        public DateTime OrderCreatedDateTime { get; set; } = DateTime.Now;

        public DateTime PredictedOrderDeliveryDateTime { get; set;} = DateTime.Now.AddDays(14);

        public string OrderStatus { get; set; }

        public Cart Cart { get; set; }

    }

    public enum OrderStatus:int
    {
        Processing = 1,
        Shipped = 2,
        Paid = 3,
        Cancelled = 4
    }
}
