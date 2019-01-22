using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDuckResturant.Entity
{
    public class Invoice
    {
        private int id;
        private double bill;
        private int orderId;
        private int custId;
        private int userId;


        public Invoice() { }

        public Invoice(int id)
        {
            this.id = id;
        }

        public Invoice(int id, double bill, int orderId, int custId)
        {
            this.id = id;
            this.bill = bill;
            this.orderId = orderId;
            this.custId = custId;
        }

        public int Id
        {
            get { return id; }
        }

        public double Bill
        {
            set { bill = value; }
            get { return bill; }
        }

        public int OrderId
        {
            set { orderId = value; }
            get { return orderId; }
        }

        public int CustId
        {
            set { custId = value; }
            get { return custId; }
        }

        public int UserId
        {
            set { userId = value; }
            get { return userId; }
        }
    }
}
