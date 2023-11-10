
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
    public class ProductRepository:GenericRepositoy<Product>
    {
        private readonly List<Product> list;
        public ProductRepository()
        {
            list = DataStore<Product>.LoadData();
        }
        public void PrintProducts(Product OneProduct = null, IEnumerable<Product>? Products = null)
        {
            if (Products != null)
            {
                foreach (var Product in Products)
                {
                    Console.WriteLine(Product.ToString());
                    Console.WriteLine();
                }
            }
            if (OneProduct != null)
            {
                Console.WriteLine(OneProduct.ToString());
                 Console.WriteLine();
            }
        }

        public void Update(Product Product)
        {

            foreach (var ProductToUpdate in list)
            {
                if (ProductToUpdate.Id == Product.Id)
                {
                    if (Product.Name != null)
                        ProductToUpdate.Name = Product.Name;

                    if (Product.Price != null)
                        ProductToUpdate.Price = Product.Price;

                    if (Product.Category.Name != null)
                        ProductToUpdate.Category.Name = Product.Category.Name;

                    if (Product.Brand.Name != null)
                        ProductToUpdate.Brand.Name = Product.Brand.Name;
                }
            }
            DataStore<Product>.Save(list);
        }
    }
}
