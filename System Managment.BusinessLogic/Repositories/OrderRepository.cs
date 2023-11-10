using Sales_Managment.BL.Repositories;
using Sales_Managment.DAL.DataStore;
using Sales_Managment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Managment.BusinessLogic.Repositories
{
    public  class OrderRepository:GenericRepositoy<Order>
    {
        List<Order> orders;
        public OrderRepository()
        {
            orders = DataStore<Order>.LoadData();
        }

        public override void Add(Order order)
        {
            orders.Add(order);
        }

        public void ConfirmOrder(Order order)
        {

            DataStore<Order>.Save(orders);
        }


        public void PrintOrders(Order OneOrder = null, IEnumerable<Order>? Orders = null)
        {
            if (Orders != null)
            {
                foreach (var Order in Orders)
                {
                    Console.WriteLine(Order.ToString());
                    Console.WriteLine();
                }
            }
            if (OneOrder != null)
            {
                Console.WriteLine($"OrderId : {OneOrder.Id}\n" +
                    $" Customer Name : {OneOrder.OrderDetails.CustomerName}\t\tCustomer Number : {OneOrder.OrderDetails.CustomerNumber}\n" +
                    $" Country : {OneOrder.OrderDetails.Country}\t\tCity : {OneOrder.OrderDetails.City}\n" +
                    $" District : {OneOrder.OrderDetails.District}\tStreet : {OneOrder.OrderDetails.Street}\tPostalcode : {OneOrder.OrderDetails.PostalCode}\n" +
                    $" Price : {CalculateTotalPrice(OneOrder).ToString("c")}\t\tPrice After Tax : {(CalculateTotalPrice(OneOrder)*1.05).ToString("c")}\n" +
                    $" Shipment Fee : {50.ToString("c")}\n" +
                    $" Total Price : {((CalculateTotalPrice(OneOrder)*1.05)+50).ToString("c")}\n" +
                    $" Order Will Be Deliverd Within : {OneOrder.OrderCreatedDateTime} to {OneOrder.PredictedOrderDeliveryDateTime}\n" +
                    $" Delivery Info : \n" +
                    $" Name : {OneOrder.Carrier.Name}\t\tPhone Number : {OneOrder.Carrier.PhoneNumber}\n" +
                    $" Order Now Is In : {OneOrder.OrderStatus} Phase");
                Console.WriteLine();
            }
        }

        public double CalculateTotalPrice(Order order)
        {
            double totalPrice = 0;
            foreach (var product in order.Cart.CartProducts)
            {
                totalPrice += (double)(product.Price*product.Count);
            }
            return totalPrice;
        }


    }
}
