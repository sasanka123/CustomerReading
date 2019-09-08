using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CustomerReading.Entities;


namespace CustomerReading.Data
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly DataConnectionFactory connectionFactory;

        public CustomerDataService(DataConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
        public int Create(Customer customer)
        {
            using (var con = connectionFactory.Get())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SAVE_CUSTOMER", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", customer.Id);
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@ContactNo", customer.ContactNo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {

                }
            }
            return 1;
        }
        public List<Customer> GetCustomer()
        {
            List<Customer> cList = new List<Customer>();
            using (var con = connectionFactory.Get())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GET_ALL_CUSTOMERS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Customer cust = new Customer();
                        cust.Id = Convert.ToInt32(rdr["Id"]);
                        cust.FirstName = rdr["FirstName"].ToString();
                        cust.LastName = rdr["LastName"].ToString();
                        cust.Email = rdr["Email"].ToString();
                        cust.Address = rdr["Address"].ToString();
                        cust.ContactNo = rdr["ContactNo"].ToString();
                        cList.Add(cust);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {

                }
            }
            return cList;
        }




        public Customer GetCustomer(string id)
        {
            Customer cust = new Customer();
            using (var con = connectionFactory.Get())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GET_CUSTOMER_BY_ID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        cust.Id = Convert.ToInt32(rdr["Id"]);
                        cust.FirstName = rdr["FirstName"].ToString();
                        cust.LastName = rdr["LastName"].ToString();
                        cust.Email = rdr["Email"].ToString();
                        cust.Address = rdr["Address"].ToString();
                        cust.ContactNo = rdr["ContactNo"].ToString();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {

                }
            }
            return cust;
        }

        public int DeleteCustomer(string id)
        {
            using (var con = connectionFactory.Get())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE_CUSTOMER", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {

                }
            }
            return 10;
        }
    }
}
