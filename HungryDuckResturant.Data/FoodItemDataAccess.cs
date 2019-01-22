using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using HungryDuckResturant.Entity;

namespace HungryDuckResturant.Data
{
    public class FoodItemDataAccess
    {
        public List<FoodMenu> GetFoodMenuData()
        {
            string query = "select * from food_menu";
            SqlDataReader reader = DataAccess.GetData(query); 

            FoodMenu foodMenu = null;
            List<FoodMenu> foodMenuList = new List<FoodMenu>();
            while (reader.Read())
            {
                foodMenu = new FoodMenu(Convert.ToInt32(reader["f_Id"]), reader["f_Name"].ToString());
                foodMenuList.Add(foodMenu);
            }
            return foodMenuList;
        }

        public List<FoodItem> GetFoodItemData(int id) {
            string query = "select * from food_item where f_Id="+ id +"";
            SqlDataReader reader = DataAccess.GetData(query);

            FoodItem foodItem = null;
            List<FoodItem> foodItemList = new List<FoodItem>();
            while (reader.Read())
            {
                foodItem = new FoodItem(Convert.ToInt32(reader["i_Id"]), reader["i_Name"].ToString(), Convert.ToInt32(reader["i_price"]),Convert.ToInt32(reader["i_availableQuantity"]), Convert.ToInt32(reader["f_Id"]));
                foodItemList.Add(foodItem);
            }
            return foodItemList;
        }
    }
}
