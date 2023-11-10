
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
    public class BrandRepository:GenericRepositoy<Brand>
    {
        private readonly List<Brand> list;
        public BrandRepository()
        {
            list = DataStore<Brand>.LoadData();
        }
        public void PrintBrands(Brand OneBrand = null, IEnumerable<Brand>? Brands = null)
        {
            if (Brands != null)
            {
                foreach (var Brand in Brands)
                {
                    Console.WriteLine(Brand.ToString());
                    Console.WriteLine();
                }
            }
            if (OneBrand != null)
            {
                Console.WriteLine(OneBrand.ToString());
                 Console.WriteLine();
            }
        }

        public void Update(Brand Brand)
        {

            foreach (var BrandToUpdate in list)
            {
                if (BrandToUpdate.Id == Brand.Id)
                {
                    if (Brand.Name != null)
                        BrandToUpdate.Name = Brand.Name;

                }
            }
            DataStore<Brand>.Save(list);
        }
    }
}
