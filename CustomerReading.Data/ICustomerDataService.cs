using CustomerReading.Entities;
using System.Collections.Generic;

namespace CustomerReading.Data
{
    public interface ICustomerDataService
    {
        int Create(Customer customer);
        List<Customer> GetCustomer();
        Customer GetCustomer(string id);
        int DeleteCustomer(string id);
    }
}