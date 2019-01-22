using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDuckResturant.Core
{
    public class ServiceFactory
    {
        public UserService GetUserService()
        {
            return new UserService();
        }

        public FoodItemService GetFoodItemService()
        {
            return new FoodItemService();
        }

        public CustomerService GetCustomerService()
        {
            return new CustomerService();
        }

        public OrderService GetOrderService()
        {
            return new OrderService();
        }

        public InvoiceService GetInvoiceService()
        {
            return new InvoiceService();
        }
    }
}
