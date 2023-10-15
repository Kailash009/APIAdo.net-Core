using Microsoft.Data.SqlClient;
using MYAPI.Models;
using System.Data;

namespace MYAPI.DAL
{
    public class DbCustomer
    {
        private readonly IConfiguration _configuration;
        public DbCustomer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Customer> GetCustomers()
        {
            string dbConn = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(dbConn);
            List<Customer> cusList = new List<Customer>();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select * from tbl_Customer";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Customer cus = new Customer();
                cus.Cid = (int)dr["Cid"];
                cus.Cname = dr["Cname"].ToString();
                cus.Age = (int)dr["age"];
                cus.MobileNo = dr["mobileno"].ToString();
                cus.City = dr["city"].ToString();
                cus.Salary = Convert.ToDecimal(dr["salary"]);
                cusList.Add(cus);
            }
            con.Close();
            return cusList;
        }
        public Customer GetCustomer(int cid)
        {
            string dbConn = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(dbConn);
            List<Customer> cusList = new List<Customer>();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select * from tbl_Customer where Cid=@cid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cid", cid);
            SqlDataReader dr = cmd.ExecuteReader();
            Customer cus = new Customer();
            if (dr.Read())
            {
                cus.Cid = (int)dr["Cid"];
                cus.Cname = dr["Cname"].ToString();
                cus.Age = (int)dr["age"];
                cus.MobileNo = dr["mobileno"].ToString();
                cus.City = dr["city"].ToString();
                cus.Salary = Convert.ToDecimal(dr["salary"]);
            }
            con.Close();
            return cus;
        }
        public bool addCustomer(Customer cusObj)
        {
            string dbConn = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(dbConn);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "insert into tbl_Customer(Cname,age,mobileno,city,salary) values(@name,@age,@mobileno,@city,@salary)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", cusObj.Cname);
            cmd.Parameters.AddWithValue("@age", cusObj.Age);
            cmd.Parameters.AddWithValue("@mobileno", cusObj.MobileNo);
            cmd.Parameters.AddWithValue("@city", cusObj.City);
            cmd.Parameters.AddWithValue("@salary", cusObj.Salary);
            int n=cmd.ExecuteNonQuery();
            con.Close();
            if (n!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool updateCustomer(Customer cusObj)
        {
            string dbConn = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(dbConn);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "update tbl_Customer set Cname=@name,age=@age,mobileno=@mobile,city=@city,salary=@salary where Cid=@cid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", cusObj.Cname);
            cmd.Parameters.AddWithValue("@age", cusObj.Age);
            cmd.Parameters.AddWithValue("@mobile", cusObj.MobileNo);
            cmd.Parameters.AddWithValue("@city", cusObj.City);
            cmd.Parameters.AddWithValue("@salary", cusObj.Salary);
            cmd.Parameters.AddWithValue("@cid", cusObj.Cid);
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteCustomer(int cid)
        {
            string dbConn = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(dbConn);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "delete from tbl_Customer where Cid=@cid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cid", cid);
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
