using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HungryDuckResturant.Entity;
using HungryDuckResturant.Core;


namespace HungryDuckResturant
{
    public partial class Login : Form
    {
        #region UtilityVariables


        ServiceFactory serviceFactory;

        #endregion

        #region Component

        private System.Windows.Forms.PictureBox pictureBoxLogin;
        private System.Windows.Forms.TextBox txtBxPassword;
        private System.Windows.Forms.TextBox txtBxID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnLogIn;

        #endregion


        #region Method
        public Login()
        {
            InitializeComponent();
            this.SetComponentBounds();
            serviceFactory = new ServiceFactory();
        }

        private void SetComponentBounds()
        {
            this.txtBxPassword = new System.Windows.Forms.TextBox();
            this.txtBxID = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.pictureBoxLogin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.Location = new System.Drawing.Point(640, 320);
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.Size = new System.Drawing.Size(250, 40);
            this.txtBxPassword.TabIndex = 5;
            this.txtBxPassword.Text = "*********";
            this.txtBxPassword.PasswordChar = '*';
            this.txtBxPassword.Click += new System.EventHandler(this.txtBxPassword_Click);
            // 
            // txtBxID
            // 
            this.txtBxID.Location = new System.Drawing.Point(640, 220);
            this.txtBxID.Name = "txtBxID";
            this.txtBxID.Size = new System.Drawing.Size(250, 40);
            this.txtBxID.TabIndex = 4;
            this.txtBxID.Text = "Enter your ID";
            this.txtBxID.Click += new System.EventHandler(this.txtBxID_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(350, 320);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(250, 40);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password :";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(350, 220);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(250, 40);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID :";
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLogIn.Location = new System.Drawing.Point(490, 420);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(300, 30);
            this.btnLogIn.TabIndex = 1;
            this.btnLogIn.Text = "Log in";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // pictureBoxLogin
            // 
            this.pictureBoxLogin.ErrorImage = global::HungryDuckResturant.Properties.Resources.BackGround;
            this.pictureBoxLogin.Image = global::HungryDuckResturant.Properties.Resources.BackGround;
            this.pictureBoxLogin.ImageLocation = "I:\\Project\\Project\\Pic\\Other\\BackGround.jpg";
            this.pictureBoxLogin.Location = new System.Drawing.Point(-2, -3);
            this.pictureBoxLogin.Name = "pictureBoxLogin";
            this.pictureBoxLogin.Size = new System.Drawing.Size(1280, 720);
            this.pictureBoxLogin.TabIndex = 0;
            this.pictureBoxLogin.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.txtBxPassword);
            this.Controls.Add(this.txtBxID);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.pictureBoxLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Login";
            this.Text = "Hungry Duck Resturant";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HungryDuckResturant_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Events

        private void txtBxID_Click(object sender, EventArgs e)
        {
            if (txtBxID.Text.Equals("Enter your ID"))
            {
                txtBxID.Text = "";
            }
        }

        private void txtBxPassword_Click(object sender, EventArgs e)
        {
            if (txtBxPassword.Text.Equals("*********"))
            {
                txtBxPassword.Text = "";
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            UserService userService = serviceFactory.GetUserService();

            User user = new User(Int32.Parse(txtBxID.Text), txtBxPassword.Text);

            if (userService.GetLoggedIn(user) == true)
            {
                if (user.Job.Equals("Owner"))
                {
                    new Owner(user, this).Show();
                    this.Hide();
                    txtBxID.Text = "Enter your ID";
                    txtBxPassword.Text = "*********";
                }
                else if (user.Job.Equals("Manager") || user.Job.Equals("Cashier"))
                {
                    new Admin(user, this).Show();
                    this.Hide();
                    txtBxID.Text = "Enter your ID";
                    txtBxPassword.Text = "*********";
                }
                else if (user.Job.Equals("Cheff") || user.Job.Equals("Waiter"))
                {
                    new GeneralEmployee(user, this).Show();
                    this.Hide();
                    txtBxID.Text = "Enter your ID";
                    txtBxPassword.Text = "*********";
                }
                else
                {
                    MessageBox.Show("Login error!");
                }
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void HungryDuckResturant_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
