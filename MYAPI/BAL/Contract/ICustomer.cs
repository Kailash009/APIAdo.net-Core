using MYAPI.Models;

namespace MYAPI.BAL.Contract
{
    public interface ICustomer
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int cid);
        bool addCustomer(Customer cusObj);
        bool updateCustomer(Customer cusObj);
        bool deleteCustomer(int id);
    }
}
