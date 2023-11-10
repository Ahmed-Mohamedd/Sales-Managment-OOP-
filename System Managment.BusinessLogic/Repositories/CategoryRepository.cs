
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
    public class CategoryRepository:GenericRepositoy<Category>
    {
        private readonly List<Category> list;
        public CategoryRepository()
        {
            list = DataStore<Category>.LoadData();
        }
        public void PrintCategorys(Category OneCategory = null, IEnumerable<Category>? Categorys = null)
        {
            if (Categorys != null)
            {
                foreach (var Category in Categorys)
                {
                    Console.WriteLine(Category.ToString());
                    Console.WriteLine();
                }
            }
            if (OneCategory != null)
            {
                Console.WriteLine(OneCategory.ToString());
                 Console.WriteLine();
            }
        }

        public void Update(Category Category)
        {

            foreach (var CategoryToUpdate in list)
            {
                if (CategoryToUpdate.Id == Category.Id)
                {
                    if (Category.Name != null)
                        CategoryToUpdate.Name = Category.Name;

                }
            }
            DataStore<Category>.Save(list);
        }
    }
}
