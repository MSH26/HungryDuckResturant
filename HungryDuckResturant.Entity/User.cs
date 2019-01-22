using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDuckResturant.Entity
{
    public class User
    {
        private int id;
        private string name;
        private string address;
        private string dob;
        private string gender;
        private string bloodGroup;
        private string phone;
        private string job;
        private double salary;
        private string nid;
        private string bankAcc;
        private string password;
        private string status;
       
        public User(int id, string password)
        {
            this.id = id;
            this.password = password;
        }

        public User(int id, string name, string address, string dob, string gender, string bloodGroup, string phone, string job, double salary, string nid, string bankAcc, string password, string status)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.dob = dob;
            this.gender = gender;
            this.bloodGroup = bloodGroup;
            this.phone = phone;
            this.job = job;
            this.salary = salary;
            this.nid = nid;
            this.bankAcc = bankAcc;
            this.password = password;
            this.status = status;
        }

        public User(int id)
        {
            this.id = id;
            this.password = password;
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

        public string Address
        {
            set { address = value; }
            get { return address; }
        }
        public string Dob
        {
            set { dob = value; }
            get { return dob; }
        }
        public string Gender
        {
            set { gender = value; }
            get { return gender; }
        }
        public string BloodGroup
        {
            set { bloodGroup = value; }
            get { return bloodGroup; }
        }
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        public string Job
        {
            set { job = value; }
            get { return job; }
        }
        public string Nid
        {
            set { nid = value; }
            get { return nid; }
        }
        public string BankAcc
        {
            set { bankAcc = value; }
            get { return bankAcc; }
        }
        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public double Salary
        {
            set { salary = value; }
            get { return salary; }
        }

        public string Status
        {
            set { status = value; }
            get { return status; }
        }
    }
}
