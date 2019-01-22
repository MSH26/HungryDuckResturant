using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HungryDuckResturant.Data;
using HungryDuckResturant.Entity;


namespace HungryDuckResturant.Core
{
    public class CustomerService
    {
        public static CustomerDataAccess customerDataAccess = null;

        public CustomerService()
        {
            if (customerDataAccess == null)
            {
                customerDataAccess = new CustomerDataAccess();
            }
        }
        public int GetCustId() {
            return customerDataAccess.GetCustIdData();
        }

        public bool StoreCustomerInfo(Customer customer)
        {
            if (customerDataAccess.SetCustomerInfo(customer) == true) {
                return true;
            }
            return false;
        }

        public bool DeleteCustomerInfo(int id)
        {
            if (customerDataAccess.DeleteCustomerInfoData(id) == true)
            {
                return true;
            }
            return false;
        }
    }
}
