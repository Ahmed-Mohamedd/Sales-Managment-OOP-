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
    public class CartRepository:GenericRepositoy<Cart>
    {

        private readonly List<Cart> list;
      
        CustomerRepository customerRepository;
        public CartRepository()
        {
            list = DataStore<Cart>.LoadData();
           
            customerRepository = new CustomerRepository();
        }
        public void PrintCarts(Cart OneCart = null, IEnumerable<Cart>? Carts = null)
        {
            if (Carts != null)
            {
                foreach (var Cart in Carts)
                {
                    string CustomerName = customerRepository.GetById(c => c.ID == Cart.CustomerId).Name;
                    Console.WriteLine($" CustomerName : {CustomerName}\n CartId : {Cart.Id}");
                    if(Cart.CartProducts!= null)
                    {
                        Console.WriteLine($" Cart Products :");
                        foreach (var item in Cart.CartProducts)
                        {
                            Console.WriteLine( $"       {item.ToString()}");
                            Console.WriteLine();
                        }
                        Console.WriteLine("-------------------------------------");
                    }
                }
            }
            if (OneCart != null)
            {
                string CustomerName = customerRepository.GetById(c => c.ID == OneCart.CustomerId).Name;
                Console.WriteLine($" CustomerName : {CustomerName}\n CartId : {OneCart.Id}\n");
                foreach (var item in OneCart.CartProducts)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine();
            }
        }

        public void Update(Cart Cart)
        {

            foreach (var CartToUpdate in list)
            {
                if (CartToUpdate.Id == Cart.Id)
                {
                    if (Cart.CustomerId != null)
                        CartToUpdate.CustomerId = Cart.CustomerId;

                    if (Cart.CartProducts != null)
                    {
                        CartToUpdate.CartProducts = Cart.CartProducts;
                    }
                    
                }
            }
            DataStore<Cart>.Save(list);
        }

    }
}
