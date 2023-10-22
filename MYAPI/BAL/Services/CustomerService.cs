using MYAPI.BAL.Contract;
using MYAPI.DAL;
using MYAPI.Models;

namespace MYAPI.BAL.Services
{
    public class CustomerService : ICustomer
    {
        private DbCustomer _dbCus;
        public CustomerService(DbCustomer dbCus)
        {
            _dbCus = dbCus;
        }

        public bool addCustomer(Customer cusObj)
        {
            return _dbCus.addCustomer(cusObj);
        }

        public bool deleteCustomer(int id)
        {
            return _dbCus.deleteCustomer(id);
        }

        public Customer GetCustomer(int cid)
        {
            Customer sc = new Customer();
            Customer cus= _dbCus.GetCustomer(cid);
            return cus;
        }
        public List<Customer> GetCustomers()
        {
           return _dbCus.GetCustomers();
        }

        public bool updateCustomer(Customer cusObj)
        {
            return _dbCus.updateCustomer(cusObj);
        }
    }
}
