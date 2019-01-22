using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using HungryDuckResturant.Entity;


namespace HungryDuckResturant.Data
{
    public class CustomerDataAccess
    {
        public int GetCustIdData() {
            string query = "select cust_Id from customer";
            SqlDataReader reader = DataAccess.GetData(query);
            int temp = 0;
            Customer customer;
            while (reader.Read())
            {
                customer = new Customer(Convert.ToInt32(reader["cust_Id"]));
                if(customer.Id>temp){
                    temp = customer.Id;
                }
            }
            return (temp+1);
        }

        public bool SetCustomerInfo(Customer customer)
        {
            string query = "insert into customer values (" + customer.Id + " , '" + customer.Name + "' , '" + customer.Phone + "' , '" + customer.Gender + "')";
            if (DataAccess.ExecuteQuery(query) == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCustomerInfoData(int id)
        {
            string query = "delete from orderTab where o_Id=" + id + "";
            if (DataAccess.ExecuteQuery(query) == 1)
            {
                return true;
            }
            return false;
        }
    }
}
