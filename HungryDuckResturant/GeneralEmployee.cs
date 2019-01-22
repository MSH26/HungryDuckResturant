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
    public partial class GeneralEmployee : Form
    {
        #region UtilityVariables 

        List<FoodMenu> foodMenuList;
        List<FoodItem> foodItemList;

        User user;
        Login login;
        ServiceFactory serviceFactory;

        #endregion


        #region Component
        /**/
        private System.Windows.Forms.GroupBox grpBxGenEmpOption;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.PictureBox picBxLogo;

        /* Profile */
        private System.Windows.Forms.GroupBox grpProfile;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblPhoneInf;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblAddressInf;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblNameInf;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDesignationInf;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.PictureBox picBxProfile;
        private System.Windows.Forms.Label lblGenderInf;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDOBInfo;
        private System.Windows.Forms.Label lblBankACCInf;
        private System.Windows.Forms.Label lblBankAccNumber;
        private System.Windows.Forms.Label lblNIDInf;
        private System.Windows.Forms.Label lblNID;
        private System.Windows.Forms.Label lblPasswordInf;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblIDInf;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.Label lblBloodGroupInfo;


        /* Inventory */
        private System.Windows.Forms.GroupBox grpBxInventory;
        private System.Windows.Forms.Label lblFoodItem;
        private System.Windows.Forms.Label lblFood;
        private System.Windows.Forms.Label lblOrder;
        //private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        //private System.Windows.Forms.DataGridViewImageColumn foodItems;
        //private System.Windows.Forms.DataGridViewTextBoxColumn foodPrice;
        //private System.Windows.Forms.DataGridViewTextBoxColumn availQuantity;
        //private System.Windows.Forms.DataGridViewTextBoxColumn orderedQuantity;
        //private System.Windows.Forms.DataGridViewButtonColumn takeOrder;
        private System.Windows.Forms.DataGridView dataGridViewFoodItem;
        private System.Windows.Forms.DataGridViewImageColumn foodItem;
        private System.Windows.Forms.TextBox txtBxQuantity;
        private System.Windows.Forms.Label lblQuantity;

        #endregion


        #region Method
        public GeneralEmployee(User user, Login login)
        {
            this.user = user;
            this.login = login;
            serviceFactory = new ServiceFactory();


            InitializeComponent();
            InitializeGeneralEmployeeFrameComponent();
            InitializeProfileComponent();
            grpProfile .Hide();
            InitializeInventoryComponent();
            grpBxInventory.Hide();
            if (user.Job == "Waiter")
            {
                lblInventory.Hide();
            }
            InitializeBackgroundPicture();
            SetComponentBounds();
        }

        private void SetComponentBounds()
        {

            /* Admin */
            this.ClientSize = new System.Drawing.Size(1280, 720);

            /*groupbx option*/
            this.grpBxGenEmpOption.Location = new System.Drawing.Point(5, 210);
            this.grpBxGenEmpOption.Name = "grpBxGenEmpOption";
            this.grpBxGenEmpOption.Size = new System.Drawing.Size(250, this.Height - 210);


            /* picture logo */
            this.picBxLogo.Location = new System.Drawing.Point(5, 5);
            this.picBxLogo.Name = "picBxLogo";
            this.picBxLogo.Size = new System.Drawing.Size(250, 200);

            /*picture background */

            this.picBxProfile.Location = new System.Drawing.Point(0, 0);
            this.picBxProfile.Name = "picBxProfile";
            this.picBxProfile.Size = new System.Drawing.Size(this.Width, this.Height);
        }

        private void InitializeBackgroundPicture()
        {
            this.picBxProfile = new System.Windows.Forms.PictureBox();

            this.picBxProfile.ErrorImage = global::HungryDuckResturant.Properties.Resources.BackGround;
            this.picBxProfile.Image = global::HungryDuckResturant.Properties.Resources.BackGround;
            this.picBxProfile.ImageLocation = "I:\\Project\\Project\\Pic\\Other\\BackGround.jpg";
            
            this.picBxProfile.Location = new System.Drawing.Point(12, 12);
            this.picBxProfile.Name = "picBxProfile";
            this.picBxProfile.Size = new System.Drawing.Size(1270, 695);
            this.picBxProfile.TabIndex = 0;
            this.picBxProfile.TabStop = false;
            this.Controls.Add(this.picBxProfile);
        }

        private void InitializeGeneralEmployeeFrameComponent()
        {
            this.grpBxGenEmpOption = new System.Windows.Forms.GroupBox();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblProfile = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.picBxLogo = new System.Windows.Forms.PictureBox();
            this.grpBxGenEmpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBxGenEmpOption
            // 
            this.grpBxGenEmpOption.BackColor = System.Drawing.Color.Red;
            this.grpBxGenEmpOption.Controls.Add(this.lblInventory);
            this.grpBxGenEmpOption.Controls.Add(this.lblProfile);
            this.grpBxGenEmpOption.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.picBxLogo);
            this.grpBxGenEmpOption.Location = new System.Drawing.Point(21, 23);
            this.grpBxGenEmpOption.Name = "grpBxGenEmpOption";
            this.grpBxGenEmpOption.Size = new System.Drawing.Size(263, 576);
            this.grpBxGenEmpOption.TabIndex = 1;
            this.grpBxGenEmpOption.TabStop = false;
            this.grpBxGenEmpOption.Text = "General Employee";
            
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Location = new System.Drawing.Point(24, 99);
            this.lblInventory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInventory.Name = "lblFoodMenu";
            this.lblInventory.Size = new System.Drawing.Size(61, 13);
            this.lblInventory.TabIndex = 5;
            this.lblInventory.Text = "Food Inventory";
            this.lblInventory.Click += new System.EventHandler(this.lblInventory_Click);
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(24, 39);
            this.lblProfile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(36, 13);
            this.lblProfile.TabIndex = 3;
            this.lblProfile.Text = "Profile";
            this.lblProfile.Click += new System.EventHandler(this.lblProfile_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(64, 521);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(146, 31);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // picBxLogo
            // 
            this.picBxLogo.ErrorImage = global::HungryDuckResturant.Properties.Resources.Logo;
            this.picBxLogo.Image = global::HungryDuckResturant.Properties.Resources.Logo;
            this.picBxLogo.ImageLocation = "I:\\Project\\Project\\Pic\\Other\\Logo.jpg";
            this.picBxLogo.Location = new System.Drawing.Point(9, 10);
            this.picBxLogo.Name = "picBxLogo";
            this.picBxLogo.Size = new System.Drawing.Size(188, 119);
            this.picBxLogo.TabIndex = 1;
            this.picBxLogo.TabStop = false;
            // 
            // GeneralEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 641);
            this.Controls.Add(this.grpBxGenEmpOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GeneralEmployee";
            this.Text = "GeneralEmployee";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeneralEmployee_FormClosed);
            this.grpBxGenEmpOption.ResumeLayout(false);
            this.grpBxGenEmpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLogo)).EndInit();
            this.ResumeLayout(false);
        }

        private void InitializeProfileComponent()
        {

            this.grpProfile = new System.Windows.Forms.GroupBox();
            this.picBxProfile = new System.Windows.Forms.PictureBox();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.lblDesignationInf = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNameInf = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddressInf = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPhoneInf = new System.Windows.Forms.Label();
            this.lblDOBInfo = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblGenderInf = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblIDInf = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPasswordInf = new System.Windows.Forms.Label();
            this.lblNID = new System.Windows.Forms.Label();
            this.lblNIDInf = new System.Windows.Forms.Label();
            this.lblBankAccNumber = new System.Windows.Forms.Label();
            this.lblBankACCInf = new System.Windows.Forms.Label();
            this.lblBloodGroup = new System.Windows.Forms.Label();
            this.lblBloodGroupInfo = new System.Windows.Forms.Label();
            this.grpProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // grpProfile
            // 
            this.grpProfile.BackColor = System.Drawing.Color.Yellow;
            this.grpProfile.Controls.Add(this.lblBankACCInf);
            this.grpProfile.Controls.Add(this.lblBankAccNumber);
            this.grpProfile.Controls.Add(this.lblNIDInf);
            this.grpProfile.Controls.Add(this.lblNID);
            this.grpProfile.Controls.Add(this.lblPasswordInf);
            this.grpProfile.Controls.Add(this.lblPassword);
            this.grpProfile.Controls.Add(this.lblIDInf);
            this.grpProfile.Controls.Add(this.lblID);
            this.grpProfile.Controls.Add(this.lblGenderInf);
            this.grpProfile.Controls.Add(this.lblGender);
            this.grpProfile.Controls.Add(this.lblDOBInfo);
            this.grpProfile.Controls.Add(this.lblPhone);
            this.grpProfile.Controls.Add(this.lblPhoneInf);
            this.grpProfile.Controls.Add(this.lblDOB);
            this.grpProfile.Controls.Add(this.lblAddressInf);
            this.grpProfile.Controls.Add(this.lblAddress);
            this.grpProfile.Controls.Add(this.lblNameInf);
            this.grpProfile.Controls.Add(this.lblName);
            this.grpProfile.Controls.Add(this.lblDesignationInf);
            this.grpProfile.Controls.Add(this.lblDesignation);
            this.grpProfile.Controls.Add(this.lblBloodGroup);
            this.grpProfile.Controls.Add(this.lblBloodGroupInfo);
            this.grpProfile.Controls.Add(this.picBxProfile);


            this.grpProfile.Location = new System.Drawing.Point(this.Width - (this.Width - 280), 5);
            this.grpProfile.Name = "grpProfile";
            this.grpProfile.Size = new System.Drawing.Size(1000, 715);
            this.grpProfile.TabIndex = 1;
            this.grpProfile.TabStop = false;
            this.grpProfile.Text = "Profile";
            // 
            // picBxProfile
            // 
            this.picBxProfile.Location = new System.Drawing.Point(571, 44);
            this.picBxProfile.Name = "picBxProfile";
            this.picBxProfile.Size = new System.Drawing.Size(233, 206);
            this.picBxProfile.TabIndex = 0;
            this.picBxProfile.TabStop = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(45, 50);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(40, 40);
            this.lblID.TabIndex = 12;
            this.lblID.Text = "ID :";
            // 
            // lblIDInf
            // 
            this.lblIDInf.AutoSize = true;
            this.lblIDInf.Location = new System.Drawing.Point(145, 50);
            this.lblIDInf.Name = "lblIDInf";
            this.lblIDInf.Size = new System.Drawing.Size(50, 40);
            this.TabIndex = 13;
            this.lblIDInf.Text = "ID :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(45, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 40);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name :";
            // 
            // lblNameInf
            // 
            this.lblNameInf.AutoSize = true;
            this.lblNameInf.Location = new System.Drawing.Point(145, 90);
            this.lblNameInf.Name = "lblNameInf";
            this.lblNameInf.Size = new System.Drawing.Size(50, 40);
            this.lblNameInf.TabIndex = 4;
            this.lblNameInf.Text = "Name :";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(45, 130);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(40, 40);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address :";
            // 
            // lblAddressInf
            // 
            this.lblAddressInf.AutoSize = true;
            this.lblAddressInf.Location = new System.Drawing.Point(145, 130);
            this.lblAddressInf.Name = "lblAddressInf";
            this.lblAddressInf.Size = new System.Drawing.Size(50, 40);
            this.lblAddressInf.TabIndex = 6;
            this.lblAddressInf.Text = "Address :";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(45, 170);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(40, 40);
            this.lblDOB.TabIndex = 7;
            this.lblDOB.Text = "DOB :";
            // 
            // lblDOBInfo
            // 
            this.lblDOBInfo.AutoSize = true;
            this.lblDOBInfo.Location = new System.Drawing.Point(145, 170);
            this.lblDOBInfo.Name = "lblDOBInfo";
            this.lblDOBInfo.Size = new System.Drawing.Size(200, 30);
            this.lblDOBInfo.TabIndex = 9;
            this.lblDOBInfo.Text = "DOB :";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(45, 210);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(40, 40);
            this.lblGender.TabIndex = 10;
            this.lblGender.Text = "Gender :";
            // 
            // lblGenderInf
            // 
            this.lblGenderInf.AutoSize = true;
            this.lblGenderInf.Location = new System.Drawing.Point(145, 210);
            this.lblGenderInf.Name = "lblGenderInf";
            this.lblGenderInf.Size = new System.Drawing.Size(50, 40);
            this.lblGenderInf.TabIndex = 11;
            this.lblGenderInf.Text = "Gender :";
            //
            //lblBloodGroup
            //
            this.lblBloodGroup.AutoSize = true;
            this.lblBloodGroup.Location = new System.Drawing.Point(45, 250);
            this.lblBloodGroup.Name = "lblBloodGroup";
            this.lblBloodGroup.Size = new System.Drawing.Size(40, 40);
            this.lblBloodGroup.Text = "BloodGroup";
            //
            //lblBloodGroup
            //
            this.lblBloodGroupInfo.AutoSize = true;
            this.lblBloodGroupInfo.Location = new System.Drawing.Point(145, 245);
            this.lblBloodGroupInfo.Name = "lblBloodGroup";
            this.lblBloodGroupInfo.Size = new System.Drawing.Size(40, 40);
            this.lblBloodGroupInfo.Text = "BloodGroup";
            //
            //lblPhone
            //
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(45, 290);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(40, 40);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Phone";
            // 
            // lblPhoneInf
            // 
            this.lblPhoneInf.AutoSize = true;
            this.lblPhoneInf.Location = new System.Drawing.Point(145, 290);
            this.lblPhoneInf.Name = "lblPhoneInf";
            this.lblPhoneInf.Size = new System.Drawing.Size(50, 40);
            this.lblPhoneInf.TabIndex = 2;
            this.lblPhoneInf.Text = "lblPhoneInf";
            this.lblPhoneInf.Text = "Phone";
            // 
            // lblNID
            // 
            this.lblNID.AutoSize = true;
            this.lblNID.Location = new System.Drawing.Point(45, 330);
            this.lblNID.Name = "lblNID";
            this.lblNID.Size = new System.Drawing.Size(40, 40);
            this.lblNID.TabIndex = 16;
            this.lblNID.Text = "NID";
            // 
            // lblNIDInf
            // 
            this.lblNIDInf.AutoSize = true;
            this.lblNIDInf.Location = new System.Drawing.Point(145, 330);
            this.lblNIDInf.Name = "lblNIDInf";
            this.lblNIDInf.Size = new System.Drawing.Size(50, 40);
            this.lblNIDInf.TabIndex = 17;
            this.lblNIDInf.Text = "NID";
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Location = new System.Drawing.Point(45, 370);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(40, 40);
            this.lblDesignation.TabIndex = 3;
            this.lblDesignation.Text = "Designation :";
            // 
            // lblDesignationInf
            // 
            this.lblDesignationInf.AutoSize = true;
            this.lblDesignationInf.Location = new System.Drawing.Point(145, 370);
            this.lblDesignationInf.Name = "lblDesignationInf";
            this.lblDesignationInf.Size = new System.Drawing.Size(50, 40);
            this.lblDesignationInf.TabIndex = 4;
            this.lblDesignationInf.Text = "Designation :";
            // 
            // lblBankAccNumber
            // 
            this.lblBankAccNumber.AutoSize = true;
            this.lblBankAccNumber.Location = new System.Drawing.Point(45, 450);
            this.lblBankAccNumber.Name = "lblBankAccNumber";
            this.lblBankAccNumber.Size = new System.Drawing.Size(40, 40);
            this.lblBankAccNumber.TabIndex = 18;
            this.lblBankAccNumber.Text = "Bank ACC :";
            // 
            // lblBankACCInf
            // 
            this.lblBankACCInf.AutoSize = true;
            this.lblBankACCInf.Location = new System.Drawing.Point(145, 450);
            this.lblBankACCInf.Name = "lblBankACCInf";
            this.lblBankACCInf.Size = new System.Drawing.Size(50, 40);
            this.lblBankACCInf.TabIndex = 20;
            this.lblBankACCInf.Text = "Bank ACC :";
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(45, 490);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(40, 40);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password :";
            // 
            // lblPasswordInf
            // 
            this.lblPasswordInf.AutoSize = true;
            this.lblPasswordInf.Location = new System.Drawing.Point(145, 490);
            this.lblPasswordInf.Name = "lblPasswordInf";
            this.lblPasswordInf.Size = new System.Drawing.Size(50, 40);
            this.lblPasswordInf.TabIndex = 15;
            this.lblPasswordInf.Text = "Password :";
            //
            //Adding grpBxProfile
            //
            this.Controls.Add(this.grpProfile);
            this.grpProfile.ResumeLayout(false);
            this.grpProfile.PerformLayout();
        }

        private void InitializeInventoryComponent()
        {
            this.grpBxInventory = new System.Windows.Forms.GroupBox();
            this.dataGridViewFoodItem = new System.Windows.Forms.DataGridView();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.foodItem = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblFood = new System.Windows.Forms.Label();
            this.lblFoodItem = new System.Windows.Forms.Label();
            this.txtBxQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.grpBxInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoodItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.SuspendLayout();

            // grpBxFoodMenu
            // 
            this.grpBxInventory.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grpBxInventory.Controls.Add(this.lblFoodItem);
            this.grpBxInventory.Controls.Add(this.lblFood);
            this.grpBxInventory.Controls.Add(this.lblOrder);
            this.grpBxInventory.Controls.Add(this.dataGridViewItems);
            this.grpBxInventory.Controls.Add(this.dataGridViewFoodItem);
            this.grpBxInventory.Controls.Add(this.txtBxQuantity);
            this.grpBxInventory.Controls.Add(this.lblQuantity);
            // 
            // FoodItem
            // 
            this.foodItem.HeaderText = "Items";
            this.foodItem.Name = "foodItem";
            this.foodItem.Width = 400;
            this.foodItem.ReadOnly = true;

            this.grpBxInventory.Location = new System.Drawing.Point(this.Width - (this.Width - 280), 5);
            this.grpBxInventory.Name = "grpBxFoodMenu";
            this.grpBxInventory.Size = new System.Drawing.Size(1000, 715);
            this.grpBxInventory.TabIndex = 1;
            this.grpBxInventory.TabStop = false;
            this.grpBxInventory.Text = "Food inventory";
            // 
            // dataGridViewFoodItem
            // 
            this.dataGridViewFoodItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFoodItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.foodItem});
            this.dataGridViewFoodItem.Location = new System.Drawing.Point(15, 54);
            this.dataGridViewFoodItem.Name = "dataGridViewFoodItem";
            this.dataGridViewFoodItem.RowTemplate.Height = 24;
            this.dataGridViewFoodItem.Size = new System.Drawing.Size(350, 650);
            this.dataGridViewFoodItem.TabIndex = 0;
            this.dataGridViewFoodItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFoodItem_CellClick);
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            ////this.foodItems,
            ////this.foodPrice,
            ////this.availQuantity,
            ////this.orderedQuantity,
            ////this.takeOrder
            //});
            this.dataGridViewItems.Location = new System.Drawing.Point(400, 54);
            this.dataGridViewItems.Name = "dataGridView2";
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.Size = new System.Drawing.Size(350, 275);
            this.dataGridViewItems.TabIndex = 1;
            this.dataGridViewItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItems_CellClick);                       
            // 
            // lblFood
            // 
            this.lblFood.AutoSize = true;
            this.lblFood.Location = new System.Drawing.Point(400, 34);
            this.lblFood.Name = "lblFood";
            this.lblFood.Size = new System.Drawing.Size(46, 17);
            this.lblFood.TabIndex = 6;
            this.lblFood.Text = "Items";
            // 
            // lblFoodItem
            // 
            this.lblFoodItem.AutoSize = true;
            this.lblFoodItem.Location = new System.Drawing.Point(15, 34);
            this.lblFoodItem.Name = "lblFoodItem";
            this.lblFoodItem.Size = new System.Drawing.Size(70, 17);
            this.lblFoodItem.TabIndex = 7;
            this.lblFoodItem.Text = "Food Item";
            //
            //lblQuantity
            //
            this.lblQuantity.Location = new System.Drawing.Point(810, 200);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(90, 20);
            this.lblQuantity.TabIndex = 29;
            this.lblQuantity.Text = "Enter quantity";
            //this.lblQuantity.UseVisualStyleBackColor = true;
            //
            //txtBxQuantity
            //
            this.txtBxQuantity.Location = new System.Drawing.Point(810, 150);
            this.txtBxQuantity.Name = "txtBxQuantity";
            this.txtBxQuantity.Text = "1";
            this.txtBxQuantity.Size = new System.Drawing.Size(150, 30);
            this.txtBxQuantity.Click += new System.EventHandler(this.txtBxQuantity_Click);
            // 
            // Admin
            // 
            this.Controls.Add(this.grpBxInventory);
            this.grpBxInventory.ResumeLayout(false);
            this.grpBxInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoodItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.ResumeLayout(false);
        }


        private void ShowDetailsOfFoodMenu(List<FoodMenu> fMenuList)
        {
            foodMenuList = fMenuList;
            dataGridViewFoodItem.RowTemplate.Height = 250;
            foreach (FoodMenu fm in foodMenuList)
            {
                Image img = Image.FromFile(@"I:\Project\Project\Pic\Food\Menu\" + fm.Name + ".jpg");
                dataGridViewFoodItem.Rows.Add(img);
            }
        }

        private void ShowDetailsOfFoodItems(List<FoodItem> fItemList)
        {
            foodItemList = fItemList;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            foreach (FoodItem fi in foodItemList)
            {
                dt.Rows.Add(fi.Name, fi.Price, fi.Quantity);
            }

            dataGridViewItems.DataSource = dt;
        }

        private void SetTextToProfileComponent()
        {
            this.lblIDInf.Text = user.Id.ToString();
            this.lblNameInf.Text = user.Name;
            this.lblAddressInf.Text = user.Address;
            this.lblDOBInfo.Text = user.Dob;
            this.lblGenderInf.Text = user.Gender;
            this.lblBloodGroupInfo.Text = user.BloodGroup;
            this.lblPhoneInf.Text = user.Phone;
            this.lblNIDInf.Text = user.Nid;
            this.lblDesignationInf.Text = user.Job;
            this.lblBankACCInf.Text = user.BankAcc;
            this.lblPasswordInf.Text = user.Password;
        }

        #endregion



        #region Events

        private void lblProfile_Click(object sender, EventArgs e)
        {
            UserService userService = serviceFactory.GetUserService();
            user = userService.GetUserInfo(user);

            SetTextToProfileComponent();
            grpProfile.Show();
            grpBxInventory.Hide();
        }
        private void lblInventory_Click(object sender, EventArgs e)
        {
            FoodItemService foodItemService = serviceFactory.GetFoodItemService();

            ShowDetailsOfFoodMenu(foodItemService.GetFoodMenu());

            grpBxInventory.Show();
            grpProfile.Hide();
        }

        private void GeneralEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtBxQuantity_Click(object sender, EventArgs e)
        {
            if (txtBxQuantity.Text.Equals("Enter quantity"))
            {
                txtBxQuantity.Text = "";
            }
        }

        private void dataGridViewFoodItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FoodItemService foodItemService = serviceFactory.GetFoodItemService();

            ShowDetailsOfFoodItems(foodItemService.GetFoodItem(foodMenuList[e.RowIndex].Id));
        }

        private void dataGridViewItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Dispose();
        }

        #endregion
    }
}
