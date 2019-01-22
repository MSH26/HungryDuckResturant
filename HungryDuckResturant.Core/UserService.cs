using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HungryDuckResturant.Data;
using HungryDuckResturant.Entity;


namespace HungryDuckResturant.Core
{
    public class UserService
    {
        public static UserDataAccess userDataAccess = null;

        public UserService()
        {
            if (userDataAccess == null)
            {
                userDataAccess = new UserDataAccess();
            }
        }

        public bool GetLoggedIn(User user)
        {
            if (userDataAccess.GetLog(user) == true)
            {
                return true;
            }
            return false;
        }

        public User GetUserInfo(User user)
        {
            return userDataAccess.GetUserInfoData(user);
        }

        public List<User> GetAllUserInfo() {
            return userDataAccess.GetAllUserInfoData();
        }

        public bool FireEmployeeUser(User user) {
            if(userDataAccess.FireEmployeeUserDataAccess(user) == true){

                return true;
            }
            return false;
        }

        //public bool RecruitEmp() { 
        //    userDataAccess.
        //}
    }
}
