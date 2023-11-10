using Sales_Managment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Managment.BusinessLogic.Repositories;

namespace Sales_Managment.PL
{
    public  class CartManagment
    {
        CartRepository CartRepository;
        public CartManagment()
        {
            CartRepository = new CartRepository();
        }
       
        public void RetrieveAllCarts()
        {
           var Carts =  CartRepository.GetAll();
           CartRepository.PrintCarts(null , Carts);
        }

        public void Create(Cart Cart)
        {
            if(CartRepository.GetById( c=> c.Id == Cart.Id ) == null)
            {
                CartRepository.Add(Cart);
                Console.WriteLine("Cart Created Successfully");
            }
            else
            {
                Console.WriteLine("Cart Is Already Found! U cant Added Him Twice, Try Updating him Instead");
            }
        }
        //public  void Update(int id  , Cart CartToUpdate)
        //{
            
        //    if (CartRepository.GetById(c => c.Id == id) != null)
        //    {
        //        //CartRepository.Update(CartToUpdate);
        //        Console.WriteLine("Cart Updated Successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Cart u wnat to update isn't found, please make sure of Cart id");
        //    }
        //}
        public  void Delete(int id)
        {
            var CartToDelete = CartRepository.GetById(c => c.Id  == id);
            if (CartToDelete != null)
            {
                CartRepository.Delete(CartToDelete);
                Console.WriteLine("Cart Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Cart U are tring To Delete is not Found. Please, Make sure Of Id And try Again.");
            }
        }

        public void IncreaseCountByOne(int CartId, int CustomertId, int Productid)
        {
            var CustomerCart = CartRepository.GetAll().Where(c => c.Id == CartId && c.CustomerId == CustomertId).FirstOrDefault();
            if(CustomerCart != null)
            {
                var ProductToIncreaseItsCount = CustomerCart.CartProducts.Where(p=> p.Id == Productid).FirstOrDefault();
                ProductToIncreaseItsCount.Count++;
            }
            CartRepository.Update(CustomerCart);
            Console.WriteLine("Product Count is Increased By one ");
        }

        public void DecreaseCountByOne(int CartId, int CustomertId, int Productid)
        {
            var CustomerCart = CartRepository.GetAll().Where(c => c.Id == CartId && c.CustomerId == CustomertId).FirstOrDefault();
            if (CustomerCart != null)
            {
                var ProductToIncreaseItsCount = CustomerCart.CartProducts.Where(p => p.Id == Productid).FirstOrDefault();
                ProductToIncreaseItsCount.Count--;
            }
            CartRepository.Update(CustomerCart);
            Console.WriteLine("Product Count is Decreased By one ");
        }
    }
}
