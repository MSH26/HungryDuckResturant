using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDuckResturant.Entity
{
    public class Order
    {
        private int id;
        private string details;

        public Order() { }

        public Order(int id)
        {
            this.id = id;
        }

        public Order(int id, string details)
        {
            this.id = id;
            this.details = details;
        }
        public int Id
        {
            get { return id; }
        }

        public string Details
        {
            set { details = value; }
            get { return details; }
        }
    }
}
