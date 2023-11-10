using Sales_Managment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Managment.BusinessLogic.Repositories;

namespace Sales_Managment.PL
{
    public  class ProductManagment
    {
        ProductRepository ProductRepository;
        CartManagment cartManagment;
        CartRepository CartRepository;
        public ProductManagment()
        {
            ProductRepository = new ProductRepository();
            cartManagment = new CartManagment();
            CartRepository = new CartRepository();
        }
       
        public void RetrieveAllProducts()
        {
           var Products =  ProductRepository.GetAll();
            ProductRepository.PrintProducts(null , Products);
        }

        public  void Create(Product Product)
        {
            if(ProductRepository.GetById( c=> c.Id == Product.Id ) == null)
            {
                ProductRepository.Add(Product);
                Console.WriteLine("Product Created Successfully");
            }
            else
            {
                Console.WriteLine("Product Is Already Found! U cant Added Him Twice, Try Updating him Instead");
            }
        }
        public  void Update(int id  , Product ProductToUpdate)
        {
            
            if (ProductRepository.GetById(c => c.Id == id) != null)
            {
                ProductRepository.Update(ProductToUpdate);
                Console.WriteLine("Product Updated Successfully");
            }
            else
            {
                Console.WriteLine("Product u wnat to update isn't found, please make sure of Product id");
            }
        }
        public  void Delete(int id)
        {
            var ProductToDelete = ProductRepository.GetById(c => c.Id  == id);
            if (ProductToDelete != null)
            {
                ProductRepository.Delete(ProductToDelete);
                Console.WriteLine("Product Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Product U are tring To Delete is not Found. Please, Make sure Of Id And try Again.");
            }
        }

        public void AddToCart(int CustomertId , int CartId , int Productid , int ? count = null )
        {
            var CustomerCart = CartRepository.GetAll().Where(c => c.Id == CartId && c.CustomerId == CustomertId).FirstOrDefault();
            var ProductToAddToCart = ProductRepository.GetById(p => p.Id == Productid);
            CartProduct CartProduct = null; 
            if (CustomerCart != null)
            {
                var prod = CustomerCart.CartProducts.Where(p => p.Id == Productid).FirstOrDefault();
                if (prod != null)
                {
                    if(count != null)
                        prod.Count = prod.Count + count;
                    prod.Count++;
                }
                else
                {
                    if (ProductToAddToCart != null)
                    {

                        CartProduct = new CartProduct()
                        {
                            Id  = ProductToAddToCart.Id,
                            Name = ProductToAddToCart?.Name,
                            Price = ProductToAddToCart.Price,
                            Category = ProductToAddToCart?.Category,
                            Brand = ProductToAddToCart?.Brand,
                        };

                        if (count != null)
                        {
                            CartProduct.Count = CartProduct.Count+count;
                        }
                        else
                        {
                            CartProduct.Count = CartProduct.Count;
                        }
                        CustomerCart.CartProducts.Add(CartProduct);
                        Console.WriteLine("Product Has been addeed To Cart Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Product U Are Tring To Cart Is Not Found.Please, Make Sure Of Product Id");
                    }
                }
                
                CartRepository.Update(CustomerCart);
                Console.WriteLine("Cart Has Been Updated");
            }
            else
            {
                if (ProductToAddToCart != null)
                {
                    CartProduct = new CartProduct()
                    {
                        Id  = ProductToAddToCart.Id,
                        Name = ProductToAddToCart?.Name,
                        Price = ProductToAddToCart.Price,
                        Category = ProductToAddToCart?.Category,
                        Brand = ProductToAddToCart?.Brand,
                    };

                    if (count != null)
                    {
                        CartProduct.Count = CartProduct.Count+count;
                    }
                    else
                    {
                        CartProduct.Count = CartProduct.Count;
                    }
          
                }
                else
                {
                    Console.WriteLine("Product U Are Tring To Cart Is Not Found.Please, Make Sure Of Product Id");
                }
                Console.WriteLine(" Cart Is not Found So It Will Be Created");
                cartManagment.Create(new Cart { Id = CartId , CustomerId = CustomertId , CartProducts = new List<CartProduct> { CartProduct} });
            }
            
        }

    }
}
