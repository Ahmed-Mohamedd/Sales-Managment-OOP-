using Sales_Managment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Managment.BusinessLogic.Repositories;

namespace Sales_Managment.PL
{
    public  class BrandManagment
    {
        BrandRepository BrandRepository;
        public BrandManagment()
        {
            BrandRepository = new BrandRepository();
        }
       
        public void RetrieveAllBrands()
        {
           var Brands =  BrandRepository.GetAll();
            BrandRepository.PrintBrands(null , Brands);
        }

        public  void Create(Brand Brand)
        {
            if(BrandRepository.GetById( c=> c.Id == Brand.Id ) == null)
            {
                BrandRepository.Add(Brand);
                Console.WriteLine("Brand Created Successfully");
            }
            else
            {
                Console.WriteLine("Brand Is Already Found! U cant Added Him Twice, Try Updating him Instead");
            }
        }
        public  void Update(int id  , Brand BrandToUpdate)
        {
            
            if (BrandRepository.GetById(c => c.Id == id) != null)
            {
                BrandRepository.Update(BrandToUpdate);
                Console.WriteLine("Brand Updated Successfully");
            }
            else
            {
                Console.WriteLine("Brand u wnat to update isn't found, please make sure of Brand id");
            }
        }
        public  void Delete(int id)
        {
            var BrandToDelete = BrandRepository.GetById(c => c.Id  == id);
            if (BrandToDelete != null)
            {
                BrandRepository.Delete(BrandToDelete);
                Console.WriteLine("Brand Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Brand U are tring To Delete is not Found. Please, Make sure Of Id And try Again.");
            }
        }

    }
}
