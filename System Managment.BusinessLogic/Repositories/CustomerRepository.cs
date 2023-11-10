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
    public class CustomerRepository: GenericRepositoy<Customer>
    {
        private readonly List<Customer> list;
        public CustomerRepository()
        {
            list = DataStore<Customer>.LoadData();
        }
        public void PrintCustomers(Customer Onecustomer = null ,IEnumerable<Customer>? customers = null)
        {
            if(customers != null)
            {
                foreach(var customer in customers)
                {
                    Console.WriteLine($" ID:{customer.ID} \n Name:{customer.Name} \n PhoneNumber:{customer.PhoneNumber} \n " +
                        $"Address:\tCountry:{customer.Address.Country}\t City:{customer.Address.City} \t District:{customer.Address.District} \t Street:{customer.Address.Street}\t PostalCode:{customer.Address.PostalCode}");
                    Console.WriteLine() ;
                }
            }
            if(Onecustomer != null)
            {
                Console.WriteLine($" ID:{Onecustomer.ID} \n Name:{Onecustomer.Name} \n PhoneNumber:{Onecustomer.PhoneNumber} \n " +
                        $"Address:\tCountry:{Onecustomer.Address.Country}\t City:{Onecustomer.Address.City} \t District:{Onecustomer.Address.District} \t Street:{Onecustomer.Address.Street}\t PostalCode:{Onecustomer.Address.PostalCode}");
                Console.WriteLine();
            }
        }

        public void Update(Customer customer)
        {
          
                foreach(var CustomerToUpdate in list )
                {
                    if(CustomerToUpdate.ID == customer.ID )
                {
                    if (customer.Name != null)
                         CustomerToUpdate.Name = customer.Name; 

                    if (customer.PhoneNumber != null)
                        CustomerToUpdate.PhoneNumber = customer.PhoneNumber;

                    if (customer.Address.Country != null)
                        CustomerToUpdate.Address.Country = customer.Address.Country;

                    if (customer.Address.City != null)
                        CustomerToUpdate.Address.City = customer.Address.City;

                    if (customer.Address.District != null)
                        CustomerToUpdate.Address.District = customer.Address.District;

                    if (customer.Address.Street != null)
                        CustomerToUpdate.Address.Street = customer.Address.Street;

                    CustomerToUpdate.Address.PostalCode = customer.Address.PostalCode;
                    
                }
                }
                DataStore<Customer>.Save(list);
        }
    }
}
