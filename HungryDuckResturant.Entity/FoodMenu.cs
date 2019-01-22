using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDuckResturant.Entity
{
    public class FoodMenu
    {
        private int id;
        private string name;

        public FoodMenu()
        {
        }

        public FoodMenu(int id) {
            this.id = id;
        }

        public FoodMenu(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }
    }
}
