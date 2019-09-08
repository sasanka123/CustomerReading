using CustomerReading.Data;
using CustomerReading.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerReading.Bussiness
{
    public class CustomerRepo
    {
        private readonly ICustomerDataService customerDataService;

        public CustomerRepo(ICustomerDataService customerDataService)
        {
            this.customerDataService = customerDataService;
        }

        public List<Customer> GetCustomer() {
            return customerDataService.GetCustomer();
        }

        public Customer GetCustomer(string id)
        {
            return customerDataService.GetCustomer(id);
        }

        public int CreateCustomer(Customer customer)
        {
            return customerDataService.Create(customer);
        }

        public int DeleteCustomer(string id)
        {
            return customerDataService.DeleteCustomer(id);
        }
    }
}
