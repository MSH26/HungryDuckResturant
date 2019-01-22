using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


using HungryDuckResturant.Entity;

namespace HungryDuckResturant.Data
{
    public class InvoiceDataAccess
    {
        public int GetInvoiceIdData()
        {
            string query = "select inv_id from invoice";
            SqlDataReader reader = DataAccess.GetData(query);

            int temp = 0;
            Invoice invoice;
            while (reader.Read())
            {
                invoice = new Invoice(Convert.ToInt32(reader["inv_id"]));
                if (invoice.Id > temp)
                {
                    temp = invoice.Id;
                }
            }
            return (temp+1);
        }

        public bool SetInvoiceInfo(Invoice inv)
        {
            string query = "insert into invoice values (" + inv.Id + " , " + inv.Bill + " , " + inv.OrderId+ " , " + inv.CustId + ")";
            if (DataAccess.ExecuteQuery(query) == 1)
            {
                return true;
            }
            return false;
        }

        public double GetRevenueData(){
            SqlDataReader reader = DataAccess.GetData("select inv_bill from invoice");
            double temp = 0;
            while(reader.Read())
            {
                temp = temp + Convert.ToDouble(reader["inv_bill"]);
            }
            return temp;
        }
    }
}
