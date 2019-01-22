using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using HungryDuckResturant.Entity;

namespace HungryDuckResturant.Data
{
    public class UserDataAccess
    {
        public bool GetLog(User user)
        {
            string query = "select password,Job from userInfo where id=" + user.Id + "";
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader["password"].ToString().Equals(user.Password))
            {
                user.Job = reader["job"].ToString();
                return true;
            }
            return false;
        }

        public User GetUserInfoData(User user)
        {
            string query = "select * from userInfo where id=" + user.Id + "";
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (Convert.ToInt32(reader["id"].ToString()) == user.Id)
            {
                user.Name = reader["name"].ToString();
                user.Address = reader["address"].ToString();
                user.Dob = reader["dob"].ToString();
                user.Gender = reader["gender"].ToString();
                user.BloodGroup = reader["bloodGroup"].ToString();
                user.Phone = reader["phone"].ToString();
                user.Nid = reader["nid"].ToString();
                user.Job = reader["job"].ToString();
                if (user.Job == "Owner")
                {
                    user.Salary = 0;
                    user.Password = reader["password"].ToString();
                    user.BankAcc = reader["bankAcc"].ToString();
                    user.Status = reader["status"].ToString();
                }
                else
                {
                    user.Salary = Convert.ToInt32(reader["salary"]);
                    user.Password = reader["password"].ToString();
                    user.BankAcc = reader["bankAcc"].ToString(); ;
                    user.Status = reader["status"].ToString();
                }
            }
            return user;
        }

        public List<User> GetAllUserInfoData() { 
            string query = "select * from userInfo";
            SqlDataReader reader = DataAccess.GetData(query);         

            User user = null;
            List<User> userList = new List<User>();
            while (reader.Read())
            {
                user = new User(Convert.ToInt32(reader["id"]));
                user.Job = reader["job"].ToString();
                if (user.Job != "Owner")
                {
                    user.Name = reader["name"].ToString();
                    user.Address = reader["Address"].ToString();
                    user.Dob = reader["dob"].ToString();
                    user.Gender = reader["gender"].ToString();
                    user.BloodGroup = reader["bloodGroup"].ToString();
                    user.Phone = reader["phone"].ToString();
                    user.Nid = reader["nid"].ToString();
                    user.Salary = Convert.ToInt32(reader["salary"]);
                    user.Password = reader["password"].ToString();
                    user.BankAcc = reader["bankAcc"].ToString(); ;
                    user.Status = reader["status"].ToString();

                    userList.Add(user);
                }
            }
            return userList;
        }

        public bool FireEmployeeUserDataAccess(User user) {
            string query = "delete from userInfo where id="+ user.Id +"";
            if (DataAccess.ExecuteQuery(query) == 1)
            {
                return true;   
            }
            return false;
        }

        //public bool RecruitEmpData(User user) {
        //    string query = "insert into ";
        //    SqlDataReader reader = DataAccess.GetData(query);

        //    User user = null;
        //    List<User> userList = new List<User>();
        //    while (reader.Read())
        //    {
        //        user = new User(Convert.ToInt32(reader["id"]));
        //        user.Job = reader["job"].ToString();
        //        if (user.Job != "Owner")
        //        {
        //            user.Name = reader["name"].ToString();
        //            user.Address = reader["Address"].ToString();
        //            user.Dob = reader["dob"].ToString();
        //            user.Gender = reader["gender"].ToString();
        //            user.BloodGroup = reader["bloodGroup"].ToString();
        //            user.Phone = reader["phone"].ToString();
        //            user.Nid = reader["nid"].ToString();
        //            user.Salary = Convert.ToInt32(reader["salary"]);
        //            user.Password = reader["password"].ToString();
        //            user.BankAcc = reader["bankAcc"].ToString(); ;
        //            user.Status = reader["status"].ToString();

        //            userList.Add(user);
        //        }
        //    }
        //    return userList;

        //    return false;
        //}
    }
}
