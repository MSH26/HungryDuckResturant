using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using HungryDuckResturant.Entity;

namespace HungryDuckResturant.Data
{
    public class OrderDataAccess
    {
        public int GetOrderIdData()
        {
            string query = "select o_id from ordertab";
            SqlDataReader reader = DataAccess.GetData(query);

            int temp = 0;
            Order order;
            while (reader.Read())
            {
                order = new Order(Convert.ToInt32(reader["o_id"]));
                if (order.Id > temp)
                {
                    temp = order.Id;
                }
            }
            return (temp+1);
        }

        public bool SetOrderInfo(Order order)
        {
            string query = "insert into ordertab values (" + order.Id + " , '" + order.Details + "')";
            if (DataAccess.ExecuteQuery(query) == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteOrderInfoData(int id){
            string query = "delete from orderTab where o_Id="+ id +"";
            if(DataAccess.ExecuteQuery(query) == 1){
                return true;
            }
            return false;
        }
    }
}
