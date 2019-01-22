using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HungryDuckResturant.Data;
using HungryDuckResturant.Entity;

namespace HungryDuckResturant.Core
{
    public class OrderService
    {
        public static OrderDataAccess orderDataAccess = null;

        public OrderService()
        {
            if (orderDataAccess == null)
            {
                orderDataAccess = new OrderDataAccess();
            }
        }
        public int GetOrderId() {
            return orderDataAccess.GetOrderIdData();
        }

        public bool StoreOrderInfo(Order order)
        {
            if (orderDataAccess.SetOrderInfo(order) == true)
            {
                return true;
            }
            return false;
        }

        public bool DeleteOrderInfo(int id){
            if(orderDataAccess.DeleteOrderInfoData(id) == true){
                return true;
            }
            return false;
        }
    }
}
