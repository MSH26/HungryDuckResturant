using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HungryDuckResturant.Core;
using HungryDuckResturant.Entity;


namespace HungryDuckResturant
{
    public partial class MessageForm : Form
    {
        ServiceFactory serviceFactory;
        User user;

        public MessageForm(User user)
        {
            InitializeComponent();
            serviceFactory = new ServiceFactory();
            this.user = user;
        }

        private void btnYES_Click(object sender, EventArgs e)
        {
            UserService userService = serviceFactory.GetUserService();
            if (userService.FireEmployeeUser(user) == true)
            {
                MessageBox.Show("Successfully fired!");
            }
            else {
                MessageBox.Show("Attempt unsuccessful!");
            }
            this.Dispose();
        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
