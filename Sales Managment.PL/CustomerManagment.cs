using Sales_Managment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Managment.BusinessLogic.Repositories;

namespace Sales_Managment.PL
{
    public  class CustomerManagment
    {
        CustomerRepository customerRepository;
        public CustomerManagment()
        {
            customerRepository = new CustomerRepository();
        }
       
        public void RetrieveAllCustomers()
        {
           var customers =  customerRepository.GetAll();
            customerRepository.PrintCustomers(null , customers);
        }

        public  void Create(Customer customer)
        {
            if(customerRepository.GetById( c=> c.ID == customer.ID) == null)
            {
                customerRepository.Add(customer);
                Console.WriteLine("Customer Created Successfully");
            }
            else
            {
                Console.WriteLine("User Is Already Found! U cant Added Him Twice, Try Updating him Instead");
            }
        }
        public  void Update(int id  , Customer customerToUpdate)
        {
            
            if (customerRepository.GetById(c => c.ID == id) != null)
            {
                customerRepository.Update(customerToUpdate);
                Console.WriteLine("Customer Updated Successfully");
            }
            else
            {
                Console.WriteLine("Customer u wnat to update isn't found, please make sure of Customer id");
            }
        }
        public  void Delete(int id)
        {
            var CustomerToDelete = customerRepository.GetById(c => c.ID == id);
            if (CustomerToDelete != null)
            {
                customerRepository.Delete(CustomerToDelete);
                Console.WriteLine("Customer Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Customer U are tring To Delete is not Found. Please, Make sure Of Id And try Again.");
            }
        }

    }
}
