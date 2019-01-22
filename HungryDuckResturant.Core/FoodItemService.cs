using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using HungryDuckResturant.Data;
using HungryDuckResturant.Entity;


namespace HungryDuckResturant.Core
{
    public class FoodItemService
    {
        public static FoodItemDataAccess foodItemDataAccess = null;
        public FoodItemService() {
            if (foodItemDataAccess == null)
            {
                foodItemDataAccess = new FoodItemDataAccess();
            }
        }

        public List<FoodMenu> GetFoodMenu() { 
            return foodItemDataAccess.GetFoodMenuData();
        }

        public List<FoodItem> GetFoodItem(int id) {
            return foodItemDataAccess.GetFoodItemData(id);
        }
    }
}
