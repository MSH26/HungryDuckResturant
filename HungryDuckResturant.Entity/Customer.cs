using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDuckResturant.Entity
{
    public class Customer
    {
        private int id;
        private string name;
        private string gender;
        private string phone;

        public Customer() { }

        public Customer(int id)
        {
            this.id = id;
        }

        public Customer(int id, string name, string gender, string phone)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.phone = phone;
        }
        public int Id
        {
            set { Id = value; }
            get { return id; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Gender
        {
            set { gender = value; }
            get { return gender; }
        }

        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
    }
}
