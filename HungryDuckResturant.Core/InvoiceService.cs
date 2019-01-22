using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using HungryDuckResturant.Data;
using HungryDuckResturant.Entity;


namespace HungryDuckResturant.Core
{
    public class InvoiceService
    {
        public static InvoiceDataAccess invoiceDataAccess = null;

        public InvoiceService()
        {
            if (invoiceDataAccess == null)
            {
                invoiceDataAccess = new InvoiceDataAccess();
            }
        }
        public int GetInvoiceId() {
            return invoiceDataAccess.GetInvoiceIdData();
        }

        public bool StoreOrderInfo(Invoice inv)
        {
            if (invoiceDataAccess.SetInvoiceInfo(inv) == true)
            {
                return true;
            }
            return false;
        }

        public double GetRevenue()
        {
            return invoiceDataAccess.GetRevenueData();
        }
    }
}
