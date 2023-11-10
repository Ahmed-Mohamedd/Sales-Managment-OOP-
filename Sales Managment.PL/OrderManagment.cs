using Sales_Managment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Managment.BusinessLogic.Repositories;

namespace Sales_Managment.PL
{
    public  class OrderManagment
    {
        OrderRepository OrderRepository;
        CartRepository CartRepository;
        CustomerRepository CustomerRepository;
        public OrderManagment()
        {
            OrderRepository = new OrderRepository();
            CartRepository = new CartRepository();
            CustomerRepository = new CustomerRepository();
        }
       
        public void RetrieveAllOrders()
        {
           var Orders =  OrderRepository.GetAll();
           OrderRepository.PrintOrders(null , Orders);
        }

        public  void MakeOrder(int CartId , int CustomerId)
        {
            var cart = CartRepository.GetAll().Where(c=> c.Id==CartId && c.CustomerId == CustomerId).FirstOrDefault();
            if(cart != null)
            {
                var CustomerDetail = CustomerRepository.GetById(c => c.ID == CustomerId);
                var order = new Order
                {
                    OrderDetails = new OrderDetails
                    {
                        CustomerName = CustomerDetail.Name,
                        CustomerNumber = CustomerDetail.PhoneNumber,
                        Country = CustomerDetail.Address.Country,
                        City = CustomerDetail.Address.City,
                        District = CustomerDetail.Address.District,
                        PostalCode = CustomerDetail.Address.PostalCode
                    },
                    Carrier = new Carrier
                    {
                        Name = "Amgad",
                        PhoneNumber = "0120236541"
                    },
                    OrderStatus = OrderStatus.Processing.ToString(),
                    Cart    = cart
                };
                OrderRepository.Add(order);
                Console.WriteLine("This Is Order Summary : ");
                OrderRepository.PrintOrders(order);

                Console.WriteLine("Please Enter 1 For Order Confirmation Or 2 To Cancellled it");
                int ConfirmOrder;
                bool flag;
                do
                {
                    Console.WriteLine("Enter Your Answer Here :");
                    ConfirmOrder = 0;
                    flag = int.TryParse(Console.ReadLine(), out ConfirmOrder);
                } while (!flag || (ConfirmOrder>2 || ConfirmOrder < 1));
                if(ConfirmOrder == 1)
                {
                    OrderRepository.ConfirmOrder(order);
                    Console.WriteLine("Congratulations , Order Has Been confirmed Successfully");
                }
                else
                {
                    Console.WriteLine("Order Has Been Cancelled\tYou Are Welcome Anytime");
                }
                
            }
            //if(OrderRepository.GetById( c=> c.Id == Order.Id ) == null)
            //{
            //    OrderRepository.Add(Order);
            //    Console.WriteLine("Order Created Successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Order Is Already Found! U cant Added Him Twice, Try Updating him Instead");
            //}
        }
        //public  void Update(int id  , Order OrderToUpdate)
        //{
            
        //    if (OrderRepository.GetById(c => c.Id == id) != null)
        //    {
        //        OrderRepository.Update(OrderToUpdate);
        //        Console.WriteLine("Order Updated Successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Order u wnat to update isn't found, please make sure of Order id");
        //    }
        //}

        //public  void Delete(int id)
        //{
        //    var OrderToDelete = OrderRepository.GetById(c => c.Id  == id);
        //    if (OrderToDelete != null)
        //    {
        //        OrderRepository.Delete(OrderToDelete);
        //        Console.WriteLine("Order Deleted Successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Order U are tring To Delete is not Found. Please, Make sure Of Id And try Again.");
        //    }
        //}

        //public void ShowOrder(int id)
        //{
        //    var order = OrderRepository.GetById(o => o.Id == id);
        //    OrderRepository.PrintOrders(order);
        //}

    }
}
