using Sales_Managment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Managment.BusinessLogic.Repositories;

namespace Sales_Managment.PL
{
    public  class CategoryManagment
    {
        CategoryRepository CategoryRepository;
        public CategoryManagment()
        {
            CategoryRepository = new CategoryRepository();
        }
       
        public void RetrieveAllCategorys()
        {
           var Categorys =  CategoryRepository.GetAll();
            CategoryRepository.PrintCategorys(null , Categorys);
        }

        public  void Create(Category Category)
        {
            if(CategoryRepository.GetById( c=> c.Id == Category.Id ) == null)
            {
                CategoryRepository.Add(Category);
                Console.WriteLine("Category Created Successfully");
            }
            else
            {
                Console.WriteLine("Category Is Already Found! U cant Added Him Twice, Try Updating him Instead");
            }
        }
        public  void Update(int id  , Category CategoryToUpdate)
        {
            
            if (CategoryRepository.GetById(c => c.Id == id) != null)
            {
                CategoryRepository.Update(CategoryToUpdate);
                Console.WriteLine("Category Updated Successfully");
            }
            else
            {
                Console.WriteLine("Category u wnat to update isn't found, please make sure of Category id");
            }
        }
        public  void Delete(int id)
        {
            var CategoryToDelete = CategoryRepository.GetById(c => c.Id  == id);
            if (CategoryToDelete != null)
            {
                CategoryRepository.Delete(CategoryToDelete);
                Console.WriteLine("Category Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Category U are tring To Delete is not Found. Please, Make sure Of Id And try Again.");
            }
        }

    }
}
