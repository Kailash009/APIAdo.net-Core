
using MYAPI.DAL;

namespace MYAPI.Models
{
    public class Customer:StatusCode
    {
        public int Cid { get; set; }
        public string ?Cname { get; set; }
        public int Age { get; set; }
        public string ?MobileNo { get; set; }
        public string ?City { get; set; }
        public decimal Salary { get; set; }

    }
}
