using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDuckResturant.Entity
{
    public class FoodItem
    {
        private int id;
        private string name;
        private int price;
        private int quantity;
        private int foodTypeId;

        public FoodItem() { }

        public FoodItem(int id)
        {
            this.id = id;
        }

        public FoodItem(int id, string name, int price, int quantity, int foodTypeId)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.foodTypeId = foodTypeId;
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

        public int Price
        {
            set { price = value; }
            get { return price; }
        }

        public int Quantity
        {
            set { quantity = value; }
            get { return quantity; }
        }

        public int FoodTypeId
        {
            set { foodTypeId = value; }
            get { return foodTypeId; }
        }
    }
}
