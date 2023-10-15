using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYAPI.BAL.Contract;
using MYAPI.Models;

namespace MYAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _cus;
        public CustomerController(ICustomer cus)
        {
            _cus = cus;
        }

        [HttpGet]
        public List<Customer> GetAll()
        {
            return _cus.GetCustomers();
        }

        [HttpGet("{cid}")]
        public Customer Get(int cid)
        {
            return _cus.GetCustomer(cid);
        }

        [HttpPost]
        public bool addCustomer(Customer cusObj)
        {
            return _cus.addCustomer(cusObj);
        }

        [HttpPut]
        public bool updateCustomer(Customer cusObj)
        {
            return _cus.updateCustomer(cusObj);
        }

        [HttpDelete]
        public bool deleteCustomer(int cid)
        {
            return _cus.deleteCustomer(cid);
        }
    }
}
