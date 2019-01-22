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
    public partial class Owner : Form
    {
        #region UtilityVariables

        User user;
        List<FoodMenu> foodMenuList;
        List<FoodItem> foodItemList;
        List<FoodItem> orderfoodItemList = new List<FoodItem>();
        Login login;
        ServiceFactory serviceFactory;

        #endregion

        #region Component
        /*Owner*/
        private System.Windows.Forms.GroupBox grpBxOwnerOption;
        private System.Windows.Forms.Label lblRecruit;
        private System.Windows.Forms.Label lblFoodMenu;
        private System.Windows.Forms.Label lblEmpList;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.PictureBox picBxLogo;
        private System.Windows.Forms.Label lblTotalAmount;

        /*Total amount*/
        private System.Windows.Forms.GroupBox grpTotalAmount;
        private System.Windows.Forms.Label lblTAmount;
        private System.Windows.Forms.Label lblTAmountInf;

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


        /* Food Menu */
        private System.Windows.Forms.GroupBox grpBxFoodMenu;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Label lblFoodItem;
        private System.Windows.Forms.Label lblFood;
        private System.Windows.Forms.Label lblOrder;
        //private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.DataGridView dataGridViewOrderList;
        private System.Windows.Forms.DataGridViewTextBoxColumn foodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewButtonColumn cancel;
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



        /* Employee List */
        private System.Windows.Forms.GroupBox groupBoxEmpList;
        private System.Windows.Forms.Label lblSuggestion;
        private System.Windows.Forms.DataGridView dataGridViewEmpList;
        //private System.Windows.Forms.DataGridViewButtonColumn empFire;
        //private System.Windows.Forms.DataGridViewButtonColumn empPromote;
        //private System.Windows.Forms.DataGridViewTextBoxColumn empDesignation;
        //private System.Windows.Forms.DataGridViewTextBoxColumn empPhone;
        //private System.Windows.Forms.DataGridViewImageColumn empPicture;
        private System.Windows.Forms.TextBox txtBxSearch;
        private System.Windows.Forms.Button btnSearch;


        /* Employee Recruitment */
        private System.Windows.Forms.TextBox txtBoxNameInf;
        private System.Windows.Forms.Label lblRAddress;
        private System.Windows.Forms.TextBox txtBoxAddressInf;
        private System.Windows.Forms.Label lblREmail;
        private System.Windows.Forms.TextBox txtBoxEmailInf;
        private System.Windows.Forms.Label lblRPhone;
        private System.Windows.Forms.TextBox txtBoxPhoneInf;
        private System.Windows.Forms.Label lblRBloodGroup;
        private System.Windows.Forms.ComboBox cmBxBloodGroupInf;
        private System.Windows.Forms.Label lblRDOB;
        private System.Windows.Forms.Label lblRNID;
        private System.Windows.Forms.Label lblRName;
        private System.Windows.Forms.Label lblPicPath;
        private System.Windows.Forms.TextBox txtBxPicPath;
        private System.Windows.Forms.PictureBox picNewEmp;
        private System.Windows.Forms.GroupBox grpRGender;
        private System.Windows.Forms.RadioButton rdbtnOther;
        private System.Windows.Forms.RadioButton rdbtnFemale;
        private System.Windows.Forms.RadioButton rdbtnMale;
        private System.Windows.Forms.Label lblRDesignation;
        private System.Windows.Forms.Label lblRPassword;
        private System.Windows.Forms.Label lblRConfirmPassword;
        private System.Windows.Forms.DateTimePicker dateTimePickerRDOB;
        private System.Windows.Forms.TextBox txtBxNID;
        private System.Windows.Forms.TextBox txtBxRPassword;
        private System.Windows.Forms.TextBox txtBxRConfirmPassword;
        private System.Windows.Forms.Button btnRecruitEmp;
        private System.Windows.Forms.TextBox txtBxSalary;
        private System.Windows.Forms.TextBox txtBxBankACC;
        private System.Windows.Forms.Label lblRSalary;
        private System.Windows.Forms.ComboBox cmbBxDesignation;
        private System.Windows.Forms.Label lblRBankACC;
        private System.Windows.Forms.GroupBox grpBxRecruitEmp;

        /* BackgroundPicture */
        private System.Windows.Forms.PictureBox pictureBoxBack;

        #endregion


        #region Methods
        public Owner(User user, Login login)
        {
            InitializeComponent();
            InitializeOwnerFrameComponent();
            InitializeProfileComponent();
            grpProfile.Hide();
            InitializeFoodMenuComponent();
            grpBxFoodMenu.Hide();
            InitializeEmployeeList();
            groupBoxEmpList.Hide();
            InitializeRecruitmentComponent();
            grpBxRecruitEmp.Hide();
            InitializeTotalRevenueComponent();
            grpTotalAmount.Hide();
            InitializeBackgroundPicture();
            SetComponentBounds();

            this.user = user;
            this.login = login;
            serviceFactory = new ServiceFactory();
        }
        
        private void InitializeOwnerFrameComponent()
        {
            this.grpBxOwnerOption = new System.Windows.Forms.GroupBox();
            this.lblRecruit = new System.Windows.Forms.Label();
            this.lblFoodMenu = new System.Windows.Forms.Label();
            this.lblEmpList = new System.Windows.Forms.Label();
            this.lblProfile = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.picBxLogo = new System.Windows.Forms.PictureBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.grpBxOwnerOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecruit
            // 
            this.lblRecruit.AutoSize = true;
            this.lblRecruit.Location = new System.Drawing.Point(24, 126);
            this.lblRecruit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecruit.Name = "lblRecruit";
            this.lblRecruit.Size = new System.Drawing.Size(90, 13);
            this.lblRecruit.TabIndex = 6;
            this.lblRecruit.Text = "Recruit Employee";
            this.lblRecruit.Click += new System.EventHandler(this.lblRecruit_Click);
            // 
            // lblFoodMenu
            // 
            this.lblFoodMenu.AutoSize = true;
            this.lblFoodMenu.Location = new System.Drawing.Point(24, 99);
            this.lblFoodMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFoodMenu.Name = "lblFoodMenu";
            this.lblFoodMenu.Size = new System.Drawing.Size(61, 13);
            this.lblFoodMenu.TabIndex = 5;
            this.lblFoodMenu.Text = "Food Menu";
            this.lblFoodMenu.Click += new System.EventHandler(this.lblFoodMenu_Click);
            // 
            // lblEmpList
            // 
            this.lblEmpList.AutoSize = true;
            this.lblEmpList.Location = new System.Drawing.Point(24, 71);
            this.lblEmpList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpList.Name = "lblEmpList";
            this.lblEmpList.Size = new System.Drawing.Size(72, 13);
            this.lblEmpList.TabIndex = 4;
            this.lblEmpList.Text = "Employee List";
            this.lblEmpList.Click += new System.EventHandler(this.lblEmpList_Click);
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
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(24, 153);
            this.lblTotalAmount.Name = "lblProfile";
            this.lblTotalAmount.Size = new System.Drawing.Size(36, 13);
            this.lblTotalAmount.Text = "TotalAmount";
            this.lblTotalAmount.Click += new System.EventHandler(this.lblTotalAmount_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(38, 341);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(110, 25);
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
            this.picBxLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBxLogo.Name = "picBxLogo";
            this.picBxLogo.Size = new System.Drawing.Size(188, 119);
            this.picBxLogo.TabIndex = 1;
            this.picBxLogo.TabStop = false;
            // 
            // grpBxOwnerOption
            // 
            this.grpBxOwnerOption.BackColor = System.Drawing.Color.Red;
            //this.grpBxOwnerOption.Controls.Add(this.lblRecruit);
            this.grpBxOwnerOption.Controls.Add(this.lblFoodMenu);
            this.grpBxOwnerOption.Controls.Add(this.lblEmpList);
            this.grpBxOwnerOption.Controls.Add(this.lblProfile);
            this.grpBxOwnerOption.Controls.Add(this.lblTotalAmount);
            this.grpBxOwnerOption.Controls.Add(this.btnLogOut);
            this.grpBxOwnerOption.Location = new System.Drawing.Point(9, 151);
            this.grpBxOwnerOption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBxOwnerOption.Name = "grpBxOwnerOption";
            this.grpBxOwnerOption.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBxOwnerOption.Size = new System.Drawing.Size(197, 384);
            this.grpBxOwnerOption.TabIndex = 1;
            this.grpBxOwnerOption.TabStop = false;
            this.grpBxOwnerOption.Text = "Owner";
            // 
            // Owner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 631);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Controls.Add(this.grpBxOwnerOption);
            this.Controls.Add(this.picBxLogo);
            this.Name = "Owner";
            this.Text = "Owner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Owner_FormClosed);
            this.grpBxOwnerOption.ResumeLayout(false);
            this.grpBxOwnerOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLogo)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComponentBounds()
        {

            /* Admin */
            this.ClientSize = new System.Drawing.Size(1280, 720);

            /*groupbx option*/
            this.grpBxOwnerOption.Location = new System.Drawing.Point(5, 210);
            this.grpBxOwnerOption.Name = "grpBxOwnerOption";
            this.grpBxOwnerOption.Size = new System.Drawing.Size(250, this.Height - 260);

            /* picture logo */
            this.picBxLogo.Location = new System.Drawing.Point(5, 5);
            this.picBxLogo.Name = "picBxLogo";
            this.picBxLogo.Size = new System.Drawing.Size(250, 200);

            /*picture background */

            this.pictureBoxBack.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(this.Width, this.Height);
        }

        private void InitializeBackgroundPicture()
        {
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();

            this.pictureBoxBack.ErrorImage = global::HungryDuckResturant.Properties.Resources.BackGround;
            this.pictureBoxBack.Image = global::HungryDuckResturant.Properties.Resources.BackGround;
            this.pictureBoxBack.ImageLocation = "I:\\Project\\Project\\Pic\\Other\\BackGround.jpg";
            this.pictureBoxBack.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(1270, 695);
            this.pictureBoxBack.TabIndex = 0;
            this.pictureBoxBack.TabStop = false;
            this.Controls.Add(this.pictureBoxBack);
        }

        private void InitializeTotalRevenueComponent()
        {
            this.grpTotalAmount = new System.Windows.Forms.GroupBox();
            this.lblTAmount = new System.Windows.Forms.Label();
            this.lblTAmountInf = new System.Windows.Forms.Label();


            this.lblTAmount.Location = new System.Drawing.Point(450, 300);
            this.lblTAmount.Name = "lblTAmount";
            this.lblTAmount.Size = new System.Drawing.Size(100, 30);
            this.lblTAmount.Text = "Total Revenue :";

            this.lblTAmountInf.Location = new System.Drawing.Point(580, 300);
            this.lblTAmountInf.Name = "lblTAmountInf";
            this.lblTAmountInf.Size = new System.Drawing.Size(100, 30);
            this.lblTAmountInf.Text = "Total Revenue";

            this.grpTotalAmount.Controls.Add(this.lblTAmount);
            this.grpTotalAmount.Controls.Add(this.lblTAmountInf);

            this.grpTotalAmount.Location = new System.Drawing.Point(this.Width - (this.Width - 280), 5);
            this.grpTotalAmount.Name = "grpProfile";
            this.grpTotalAmount.Size = new System.Drawing.Size(1000, 715);
            this.grpTotalAmount.TabIndex = 1;
            this.grpTotalAmount.TabStop = false;
            this.grpTotalAmount.Text = "Revenue";

            this.Controls.Add(this.grpTotalAmount);
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

        private void InitializeFoodMenuComponent()
        {
            this.grpBxFoodMenu = new System.Windows.Forms.GroupBox();
            this.dataGridViewFoodItem = new System.Windows.Forms.DataGridView();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrderList = new System.Windows.Forms.DataGridView();
            this.btnInvoice = new System.Windows.Forms.Button();
            //this.btnAddOrder = new System.Windows.Forms.Button();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblFood = new System.Windows.Forms.Label();
            this.lblFoodItem = new System.Windows.Forms.Label();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.foodItem = new System.Windows.Forms.DataGridViewImageColumn();
            //this.foodItems = new System.Windows.Forms.DataGridViewImageColumn();
            //this.foodPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.availQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.orderedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.takeOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.foodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBxQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpBxFoodMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoodItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderList)).BeginInit();
            this.SuspendLayout();

            // grpBxFoodMenu
            // 
            this.grpBxFoodMenu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grpBxFoodMenu.Controls.Add(this.btnCancelOrder);
            this.grpBxFoodMenu.Controls.Add(this.lblFoodItem);
            this.grpBxFoodMenu.Controls.Add(this.lblFood);
            this.grpBxFoodMenu.Controls.Add(this.lblOrder);
            //this.grpBxFoodMenu.Controls.Add(this.btnAddOrder);
            this.grpBxFoodMenu.Controls.Add(this.btnInvoice);
            this.grpBxFoodMenu.Controls.Add(this.dataGridViewOrderList);
            this.grpBxFoodMenu.Controls.Add(this.dataGridViewItems);
            this.grpBxFoodMenu.Controls.Add(this.dataGridViewFoodItem);
            this.grpBxFoodMenu.Controls.Add(this.txtBxQuantity);
            this.grpBxFoodMenu.Controls.Add(this.lblQuantity);


            this.grpBxFoodMenu.Location = new System.Drawing.Point(this.Width - (this.Width - 280), 5);
            this.grpBxFoodMenu.Name = "grpBxFoodMenu";
            this.grpBxFoodMenu.Size = new System.Drawing.Size(1000, 715);
            this.grpBxFoodMenu.TabIndex = 1;
            this.grpBxFoodMenu.TabStop = false;
            this.grpBxFoodMenu.Text = "Food Menu";
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
            this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //this.foodItems,
            //this.foodPrice,
            //this.availQuantity,
            //this.orderedQuantity,
            //this.takeOrder
            });
            this.dataGridViewItems.Location = new System.Drawing.Point(400, 54);
            this.dataGridViewItems.Name = "dataGridView2";
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.Size = new System.Drawing.Size(350, 275);
            this.dataGridViewItems.TabIndex = 1;
            this.dataGridViewItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItems_CellClick);
            // 
            // dataGridViewOrderList
            this.dataGridViewOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //this.foodName,
            //this.quantity,
            //this.cancel
            });
            this.dataGridViewOrderList.Location = new System.Drawing.Point(400, 358);
            this.dataGridViewOrderList.Name = "dataGridView3";
            this.dataGridViewOrderList.RowTemplate.Height = 24;
            this.dataGridViewOrderList.Size = new System.Drawing.Size(400, 300);
            //this.dataGridViewOrderList.Columns[0].Width = 130;
            //this.dataGridViewOrderList.Columns[1].Width = 130;
            //this.dataGridViewOrderList.Columns[2].Width = 130;
            this.dataGridViewOrderList.TabIndex = 2;
            //// 
            //// btnAddOrder
            //// 
            //this.btnAddOrder.Location = new System.Drawing.Point(850, 520);
            //this.btnAddOrder.Name = "btnAddOrder";
            //this.btnAddOrder.Size = new System.Drawing.Size(105, 23);
            //this.btnAddOrder.TabIndex = 4;
            //this.btnAddOrder.Text = "Add Order";
            //this.btnAddOrder.UseVisualStyleBackColor = true;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(400, 338);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(45, 17);
            this.lblOrder.TabIndex = 5;
            this.lblOrder.Text = "Order";
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
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(850, 560);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(105, 23);
            this.btnCancelOrder.TabIndex = 8;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Location = new System.Drawing.Point(850, 600);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(105, 23);
            this.btnInvoice.TabIndex = 3;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            ////
            ////txtBxFSearch
            ////
            //this.txtBxQuantity.Location = new System.Drawing.Point(840, 55);
            //this.txtBxQuantity.Name = "txtBxFSearch";
            //txtBxQuantity.Text = "SearchD";
            //this.txtBxQuantity.Size = new System.Drawing.Size(150, 30);
            //this.txtBxQuantity.Click += new System.EventHandler(this.txtBxFSearch_Click);
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
            // FoodItem
            // 
            this.foodItem.HeaderText = "Items";
            this.foodItem.Name = "foodItem";
            this.foodItem.Width = 400;
            this.foodItem.ReadOnly = true;
            //// 
            //// foodItems
            //// 
            //this.foodItems.HeaderText = "Food";
            //this.foodItems.Name = "foodItems";
            //this.foodItems.ReadOnly = true;
            //// 
            //// foodPrice
            //// 
            //this.foodPrice.HeaderText = "Price";
            //this.foodPrice.Name = "foodPrice";
            //this.foodPrice.ReadOnly = true;
            //// 
            //// availQuantity
            //// 
            //this.availQuantity.HeaderText = "Available quantity";
            //this.availQuantity.Name = "availQuantity";
            //this.availQuantity.ReadOnly = true;
            //// 
            //// orderedQuantity
            //// 
            //this.orderedQuantity.HeaderText = "Ordered Quantity";
            //this.orderedQuantity.Name = "orderedQuantity";
            //// 
            //// takeOrder
            //// 
            //this.takeOrder.HeaderText = "Order";
            //this.takeOrder.Name = "takeOrder";
            //this.takeOrder.Text = "Order this";
            //this.takeOrder.ReadOnly = true;
            
            //// 
            //// foodName
            //// 
            //this.foodName.HeaderText = "Name";
            //this.foodName.Name = "foodName";
            //this.foodName.ReadOnly = true;
            //// 
            //// quantity
            //// 
            //this.quantity.HeaderText = "Quantity";
            //this.quantity.Name = "quantity";
            //// 
            //// cancel
            //// 
            //this.cancel.HeaderText = "Cancel";
            //this.cancel.Name = "cancel";
            //this.cancel.ReadOnly = true;
            // 
            // Admin
            // 
            this.Controls.Add(this.grpBxFoodMenu);
            this.grpBxFoodMenu.ResumeLayout(false);
            this.grpBxFoodMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoodItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderList)).EndInit();
            this.ResumeLayout(false);
        }

        private void InitializeEmployeeList()
        {
            this.groupBoxEmpList = new System.Windows.Forms.GroupBox();
            this.dataGridViewEmpList = new System.Windows.Forms.DataGridView();
            //this.empFire = new System.Windows.Forms.DataGridViewButtonColumn();
            //this.empPromote = new System.Windows.Forms.DataGridViewButtonColumn();
            //this.empDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.empPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.empPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblSuggestion = new System.Windows.Forms.Label();
            this.txtBxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBoxEmpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxEmpList
            // 
            this.groupBoxEmpList.Controls.Add(this.txtBxSearch);
            this.groupBoxEmpList.Controls.Add(this.btnSearch);
            this.groupBoxEmpList.Controls.Add(this.lblSuggestion);
            this.groupBoxEmpList.Controls.Add(this.dataGridViewEmpList);
            this.groupBoxEmpList.Location = new System.Drawing.Point(314, 28);
            this.groupBoxEmpList.Name = "groupBoxEmpList";
            this.groupBoxEmpList.BackColor = System.Drawing.Color.LightBlue;
            this.groupBoxEmpList.Size = new System.Drawing.Size(900, 650);
            this.groupBoxEmpList.TabIndex = 1;
            this.groupBoxEmpList.TabStop = false;
            this.groupBoxEmpList.Text = "Employee List";

            this.groupBoxEmpList.BackColor = System.Drawing.Color.Yellow;
            this.groupBoxEmpList.Location = new System.Drawing.Point(this.Width - (this.Width - 280), 5);
            this.groupBoxEmpList.Size = new System.Drawing.Size(1000, 715);
            // 
            // dataGridViewEmpList
            // 
            this.dataGridViewEmpList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmpList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //this.empFire,
            //this.empPromote
            //this.empDesignation,
            //this.empPhone,
            //this.empPicture
            });
            this.dataGridViewEmpList.Location = new System.Drawing.Point(21, 39);
            this.dataGridViewEmpList.Name = "dataGridView1";
            this.dataGridViewEmpList.RowTemplate.Height = 24;
            this.dataGridViewEmpList.Size = new System.Drawing.Size(812, 438);
            this.dataGridViewEmpList.TabIndex = 0;
            this.dataGridViewEmpList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmpList_CellClick);
            //// 
            //// empFire
            //// 
            //this.empFire.FillWeight = 250F;
            //this.empFire.HeaderText = "Fire";
            //this.empFire.Name = "empFire";
            //this.empFire.ReadOnly = true;
            //this.empFire.Width = 200;
            //this.empFire.Text = "Fire";
            //// 
            //// empPromote
            //// 
            //this.empPromote.FillWeight = 250F;
            //this.empPromote.HeaderText = "Promote";
            //this.empPromote.Name = "empPromote";
            //this.empPromote.Text = "Promote";
            //this.empPromote.ReadOnly = true;
            //this.empPromote.Width = 200;
            //// 
            //// empDesignation
            //// 
            //this.empDesignation.HeaderText = "Designation";
            //this.empDesignation.Name = "empDesignation";
            //this.empDesignation.ReadOnly = true;
            //this.empDesignation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //this.empDesignation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //// 
            //// empPhone
            //// 
            //this.empPhone.FillWeight = 120F;
            //this.empPhone.HeaderText = "Phone Number";
            //this.empPhone.Name = "empPhone";
            //this.empPhone.ReadOnly = true;
            //this.empPhone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //this.empPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //this.empPhone.Width = 120;
            //// 
            //// empPicture
            //// 
            //this.empPicture.FillWeight = 300F;
            //this.empPicture.HeaderText = "Picture";
            //this.empPicture.Name = "empPicture";
            //this.empPicture.ReadOnly = true;
            //this.empPicture.Width = 300;
            //// 
            // lblSuggestion
            // 
            this.lblSuggestion.AutoSize = true;
            this.lblSuggestion.Location = new System.Drawing.Point(18, 491);
            this.lblSuggestion.Name = "lblSuggestion";
            this.lblSuggestion.Size = new System.Drawing.Size(353, 17);
            this.lblSuggestion.TabIndex = 1;
            this.lblSuggestion.Text = "To fire any employee please click on that particular row!!**";
            //
            //txtBxSearch
            //
            this.txtBxSearch.Location = new System.Drawing.Point(200, 550);
            this.txtBxSearch.Name = "txtBxSearch";
            txtBxSearch.Text = "Please enter ID";
            this.txtBxSearch.Size = new System.Drawing.Size(300, 30);
            this.txtBxSearch.Click += new System.EventHandler(this.txtBxSearch_Click);
            //
            //btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(600, 550);
            this.btnSearch.Name = "btnRecruitEmp";
            this.btnSearch.Size = new System.Drawing.Size(150, 30);
            //this.btnSearch.TabIndex = 29;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.Controls.Add(this.groupBoxEmpList);
            this.groupBoxEmpList.ResumeLayout(false);
            this.groupBoxEmpList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpList)).EndInit();
            this.ResumeLayout(false);
        }

        private void InitializeRecruitmentComponent()
        {
            this.grpBxRecruitEmp = new System.Windows.Forms.GroupBox();
            this.picNewEmp = new System.Windows.Forms.PictureBox();
            this.txtBxPicPath = new System.Windows.Forms.TextBox();
            this.lblPicPath = new System.Windows.Forms.Label();
            this.lblRName = new System.Windows.Forms.Label();
            this.lblRNID = new System.Windows.Forms.Label();
            this.lblRBloodGroup = new System.Windows.Forms.Label();
            this.cmBxBloodGroupInf = new System.Windows.Forms.ComboBox();
            this.lblRDOB = new System.Windows.Forms.Label();
            this.txtBoxPhoneInf = new System.Windows.Forms.TextBox();
            this.lblRPhone = new System.Windows.Forms.Label();
            this.txtBoxEmailInf = new System.Windows.Forms.TextBox();
            this.lblREmail = new System.Windows.Forms.Label();
            this.txtBoxAddressInf = new System.Windows.Forms.TextBox();
            this.lblRAddress = new System.Windows.Forms.Label();
            this.txtBoxNameInf = new System.Windows.Forms.TextBox();
            this.grpRGender = new System.Windows.Forms.GroupBox();
            this.rdbtnMale = new System.Windows.Forms.RadioButton();
            this.rdbtnFemale = new System.Windows.Forms.RadioButton();
            this.rdbtnOther = new System.Windows.Forms.RadioButton();
            this.dateTimePickerRDOB = new System.Windows.Forms.DateTimePicker();
            this.lblRConfirmPassword = new System.Windows.Forms.Label();
            this.lblRPassword = new System.Windows.Forms.Label();
            this.lblRDesignation = new System.Windows.Forms.Label();
            this.txtBxNID = new System.Windows.Forms.TextBox();
            this.txtBxRConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtBxRPassword = new System.Windows.Forms.TextBox();
            this.lblRBankACC = new System.Windows.Forms.Label();
            this.cmbBxDesignation = new System.Windows.Forms.ComboBox();
            this.lblRSalary = new System.Windows.Forms.Label();
            this.txtBxBankACC = new System.Windows.Forms.TextBox();
            this.txtBxSalary = new System.Windows.Forms.TextBox();
            this.btnRecruitEmp = new System.Windows.Forms.Button();
            this.grpBxRecruitEmp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNewEmp)).BeginInit();
            this.grpRGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBxRecruitEmp
            // 
            this.grpBxRecruitEmp.Controls.Add(this.btnRecruitEmp);
            this.grpBxRecruitEmp.Controls.Add(this.txtBxSalary);
            this.grpBxRecruitEmp.Controls.Add(this.txtBxBankACC);
            this.grpBxRecruitEmp.Controls.Add(this.lblRSalary);
            this.grpBxRecruitEmp.Controls.Add(this.cmbBxDesignation);
            this.grpBxRecruitEmp.Controls.Add(this.lblRBankACC);
            this.grpBxRecruitEmp.Controls.Add(this.txtBxRPassword);
            this.grpBxRecruitEmp.Controls.Add(this.txtBxRConfirmPassword);
            this.grpBxRecruitEmp.Controls.Add(this.txtBxNID);
            this.grpBxRecruitEmp.Controls.Add(this.lblRDesignation);
            this.grpBxRecruitEmp.Controls.Add(this.lblRPassword);
            this.grpBxRecruitEmp.Controls.Add(this.lblRConfirmPassword);
            this.grpBxRecruitEmp.Controls.Add(this.lblRBloodGroup);
            this.grpBxRecruitEmp.Controls.Add(this.cmBxBloodGroupInf);
            this.grpBxRecruitEmp.Controls.Add(this.dateTimePickerRDOB);
            this.grpBxRecruitEmp.Controls.Add(this.grpRGender);
            this.grpBxRecruitEmp.Controls.Add(this.txtBoxNameInf);
            this.grpBxRecruitEmp.Controls.Add(this.lblRAddress);
            this.grpBxRecruitEmp.Controls.Add(this.txtBoxAddressInf);
            this.grpBxRecruitEmp.Controls.Add(this.lblREmail);
            this.grpBxRecruitEmp.Controls.Add(this.txtBoxEmailInf);
            this.grpBxRecruitEmp.Controls.Add(this.lblRPhone);
            this.grpBxRecruitEmp.Controls.Add(this.txtBoxPhoneInf);
            this.grpBxRecruitEmp.Controls.Add(this.lblRAddress);
            this.grpBxRecruitEmp.Controls.Add(this.lblRDOB);
            this.grpBxRecruitEmp.Controls.Add(this.lblRNID);
            this.grpBxRecruitEmp.Controls.Add(this.lblRName);
            this.grpBxRecruitEmp.Controls.Add(this.lblPicPath);
            this.grpBxRecruitEmp.Controls.Add(this.txtBxPicPath);
            this.grpBxRecruitEmp.Controls.Add(this.picNewEmp);
            this.grpBxRecruitEmp.Location = new System.Drawing.Point(this.Width - (this.Width - 280), 5);
            this.grpBxRecruitEmp.Name = "grpBxRecruitEmp";
            this.grpBxRecruitEmp.Size = new System.Drawing.Size(1000, 715);
            this.grpBxRecruitEmp.TabIndex = 2;
            this.grpBxRecruitEmp.TabStop = false;
            this.grpBxRecruitEmp.Text = "Recruit New Employee";
            this.grpBxRecruitEmp.BackColor = System.Drawing.Color.Gray;

            // 
            // picNewEmp
            // 
            this.picNewEmp.Location = new System.Drawing.Point(588, 34);
            this.picNewEmp.Name = "picNewEmp";
            this.picNewEmp.Size = new System.Drawing.Size(201, 179);
            this.picNewEmp.TabIndex = 0;
            this.picNewEmp.TabStop = false;
            // 
            // txtBxPicPath
            // 
            //this.txtBxPicPath.Location = new System.Drawing.Point(588, 232);
            //this.txtBxPicPath.Name = "txtBxPicPath";
            //this.txtBxPicPath.Size = new System.Drawing.Size(201, 22);
            //this.txtBxPicPath.TabIndex = 1;
            // 
            // lblPicPath
            // 
            //this.lblPicPath.AutoSize = true;
            //this.lblPicPath.Location = new System.Drawing.Point(646, 268);
            //this.lblPicPath.Name = "lblPicPath";
            //this.lblPicPath.Size = new System.Drawing.Size(100, 17);
            // this.lblPicPath.TabIndex = 2;
            //this.lblPicPath.Text = "Paste the path";
            // 
            // lblRName
            // 
            this.lblRName.AutoSize = true;
            this.lblRName.Location = new System.Drawing.Point(49, 63);
            this.lblRName.Name = "lblRName";
            this.lblRName.Size = new System.Drawing.Size(53, 17);
            this.lblRName.TabIndex = 3;
            this.lblRName.Text = "Name :";
            // 
            // lblRNID
            // 
            this.lblRNID.AutoSize = true;
            this.lblRNID.Location = new System.Drawing.Point(55, 478);
            this.lblRNID.Name = "lblRNID";
            this.lblRNID.Size = new System.Drawing.Size(39, 17);
            this.lblRNID.TabIndex = 4;
            this.lblRNID.Text = "NID :";

            //
            //lblRBloodGroup
            //

            this.lblRBloodGroup.AutoSize = true;
            this.lblRBloodGroup.Location = new System.Drawing.Point(55, 440);
            this.lblRBloodGroup.Name = "lblRBloodGroup";
            this.lblRBloodGroup.Size = new System.Drawing.Size(39, 17);
            this.lblRBloodGroup.Text = "Blood Group";
            //
            //cmBxBloodGroupInf
            //   
            this.cmBxBloodGroupInf.FormattingEnabled = true;
            this.cmBxBloodGroupInf.Location = new System.Drawing.Point(206, 444);
            this.cmBxBloodGroupInf.Name = "cmbBxDesignation";
            this.cmBxBloodGroupInf.Size = new System.Drawing.Size(200, 24);


            // 
            // lblRDOB
            // 
            this.lblRDOB.AutoSize = true;
            this.lblRDOB.Location = new System.Drawing.Point(56, 398);
            this.lblRDOB.Name = "lblRDOB";
            this.lblRDOB.Size = new System.Drawing.Size(46, 17);
            this.lblRDOB.TabIndex = 5;
            this.lblRDOB.Text = "DOB";

            // this.lblRDOB.Text = "DOB :";
            // txtBoxPhoneInf
            // 
            this.txtBoxPhoneInf.AutoSize = true;
            this.txtBoxPhoneInf.Location = new System.Drawing.Point(203, 232);
            this.txtBoxPhoneInf.Name = "txtBoxPhoneInf";
            this.txtBoxPhoneInf.Size = new System.Drawing.Size(206, 17);
            this.txtBoxPhoneInf.TabIndex = 6;
            this.txtBoxPhoneInf.Text = "Phone";
            // 
            // lblRPhone
            // 
            this.lblRPhone.AutoSize = true;
            this.lblRPhone.Location = new System.Drawing.Point(49, 232);
            this.lblRPhone.Name = "lblRPhone";
            this.lblRPhone.Size = new System.Drawing.Size(111, 17);
            this.lblRPhone.TabIndex = 7;
            this.lblRPhone.Text = "Phone Number :";
            // 
            // txtBoxEmailInf
            // 
            this.txtBoxEmailInf.AutoSize = true;
            this.txtBoxEmailInf.Location = new System.Drawing.Point(203, 172);
            this.txtBoxEmailInf.Name = "txtBoxEmailInf";
            this.txtBoxEmailInf.Size = new System.Drawing.Size(206, 17);
            this.txtBoxEmailInf.TabIndex = 8;
            this.txtBoxEmailInf.Text = "Email";
            // 
            // lblREmail
            // 
            this.lblREmail.AutoSize = true;
            this.lblREmail.Location = new System.Drawing.Point(49, 172);
            this.lblREmail.Name = "lblREmail";
            this.lblREmail.Size = new System.Drawing.Size(55, 17);
            this.lblREmail.TabIndex = 9;
            this.lblREmail.Text = "E-Mail :";
            // 
            // txtBoxAddressInf
            // 
            this.txtBoxAddressInf.AutoSize = true;
            this.txtBoxAddressInf.Location = new System.Drawing.Point(203, 113);
            this.txtBoxAddressInf.Name = "txtBoxAddressInf";
            this.txtBoxAddressInf.Size = new System.Drawing.Size(206, 17);
            this.txtBoxAddressInf.TabIndex = 10;
            this.txtBoxAddressInf.Text = "Address";
            // 
            // lblRAddress
            // 
            this.lblRAddress.AutoSize = true;
            this.lblRAddress.Location = new System.Drawing.Point(49, 113);
            this.lblRAddress.Name = "lblRAddress";
            this.lblRAddress.Size = new System.Drawing.Size(68, 17);
            this.lblRAddress.TabIndex = 11;
            this.lblRAddress.Text = "Address :";
            // 
            // txtBoxNameInf
            // 
            this.txtBoxNameInf.AutoSize = true;
            this.txtBoxNameInf.Location = new System.Drawing.Point(203, 63);
            this.txtBoxNameInf.Name = "txtBoxNameInf";
            this.txtBoxNameInf.Size = new System.Drawing.Size(206, 17);
            this.txtBoxNameInf.TabIndex = 12;
            this.txtBoxNameInf.Text = "Name";
            // 
            // grpRGender
            // 
            this.grpRGender.Controls.Add(this.rdbtnOther);
            this.grpRGender.Controls.Add(this.rdbtnFemale);
            this.grpRGender.Controls.Add(this.rdbtnMale);
            this.grpRGender.Location = new System.Drawing.Point(52, 268);
            this.grpRGender.Name = "grpRGender";
            this.grpRGender.Size = new System.Drawing.Size(86, 102);
            this.grpRGender.TabIndex = 16;
            this.grpRGender.TabStop = false;
            this.grpRGender.Text = "Gender :";
            // 
            // rdbtnMale
            // 
            this.rdbtnMale.AutoSize = true;
            this.rdbtnMale.Location = new System.Drawing.Point(6, 21);
            this.rdbtnMale.Name = "rdbtnMale";
            this.rdbtnMale.Size = new System.Drawing.Size(59, 21);
            this.rdbtnMale.TabIndex = 0;
            this.rdbtnMale.TabStop = true;
            this.rdbtnMale.Text = "Male";
            this.rdbtnMale.UseVisualStyleBackColor = true;
            // 
            // rdbtnFemale
            // 
            this.rdbtnFemale.AutoSize = true;
            this.rdbtnFemale.Location = new System.Drawing.Point(6, 48);
            this.rdbtnFemale.Name = "rdbtnFemale";
            this.rdbtnFemale.Size = new System.Drawing.Size(75, 21);
            this.rdbtnFemale.TabIndex = 1;
            this.rdbtnFemale.TabStop = true;
            this.rdbtnFemale.Text = "Female";
            this.rdbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rdbtnOther
            // 
            this.rdbtnOther.AutoSize = true;
            this.rdbtnOther.Location = new System.Drawing.Point(6, 75);
            this.rdbtnOther.Name = "rdbtnOther";
            this.rdbtnOther.Size = new System.Drawing.Size(65, 21);
            this.rdbtnOther.TabIndex = 2;
            this.rdbtnOther.TabStop = true;
            this.rdbtnOther.Text = "Other";
            this.rdbtnOther.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerRDOB
            // 
            this.dateTimePickerRDOB.Location = new System.Drawing.Point(206, 394);
            this.dateTimePickerRDOB.Name = "dateTimePickerRDOB";
            this.dateTimePickerRDOB.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerRDOB.TabIndex = 17;
            // 
            // lblRConfirmPassword
            // 
            this.lblRConfirmPassword.AutoSize = true;
            this.lblRConfirmPassword.Location = new System.Drawing.Point(56, 544);
            this.lblRConfirmPassword.Name = "lblRConfirmPassword";
            this.lblRConfirmPassword.Size = new System.Drawing.Size(129, 17);
            this.lblRConfirmPassword.TabIndex = 18;
            this.lblRConfirmPassword.Text = "Confirm Password :";
            // 
            // lblRPassword
            // 
            this.lblRPassword.AutoSize = true;
            this.lblRPassword.Location = new System.Drawing.Point(55, 510);
            this.lblRPassword.Name = "lblRPassword";
            this.lblRPassword.Size = new System.Drawing.Size(77, 17);
            this.lblRPassword.TabIndex = 19;
            this.lblRPassword.Text = "Password :";
            // 
            // lblRDesignation
            // 
            this.lblRDesignation.AutoSize = true;
            this.lblRDesignation.Location = new System.Drawing.Point(55, 578);
            this.lblRDesignation.Name = "lblRDesignation";
            this.lblRDesignation.Size = new System.Drawing.Size(77, 17);
            this.lblRDesignation.TabIndex = 20;
            this.lblRDesignation.Text = "Designation :";
            // 
            // txtBxNID
            // 
            this.txtBxNID.Location = new System.Drawing.Point(206, 478);
            this.txtBxNID.Name = "txtBxNID";
            this.txtBxNID.Size = new System.Drawing.Size(200, 22);
            this.txtBxNID.TabIndex = 21;
            // 
            // txtBxRConfirmPassword
            // 
            this.txtBxRConfirmPassword.Location = new System.Drawing.Point(206, 540);
            this.txtBxRConfirmPassword.Name = "txtBxRConfirmPassword";
            this.txtBxRConfirmPassword.Size = new System.Drawing.Size(200, 22);
            this.txtBxRConfirmPassword.TabIndex = 22;
            // 
            // txtBxRPassword
            // 
            this.txtBxRPassword.Location = new System.Drawing.Point(206, 510);
            this.txtBxRPassword.Name = "txtBxRPassword";
            this.txtBxRPassword.Size = new System.Drawing.Size(200, 22);
            this.txtBxRPassword.TabIndex = 23;
            // 
            // lblRBankACC
            // 
            this.lblRBankACC.AutoSize = true;
            this.lblRBankACC.Location = new System.Drawing.Point(55, 612);
            this.lblRBankACC.Name = "lblRBankACC";
            this.lblRBankACC.Size = new System.Drawing.Size(77, 17);
            this.lblRBankACC.TabIndex = 24;
            this.lblRBankACC.Text = "Bank ACC :";
            // 
            // cmbBxDesignation
            // 
            this.cmbBxDesignation.FormattingEnabled = true;
            this.cmbBxDesignation.Location = new System.Drawing.Point(206, 578);
            this.cmbBxDesignation.Name = "cmbBxDesignation";
            this.cmbBxDesignation.Size = new System.Drawing.Size(200, 22);
            this.cmbBxDesignation.TabIndex = 25;
            // 
            // lblRSalary
            // 
            this.lblRSalary.AutoSize = true;
            this.lblRSalary.Location = new System.Drawing.Point(55, 646);
            this.lblRSalary.Name = "lblRSalary";
            this.lblRSalary.Size = new System.Drawing.Size(77, 17);
            this.lblRSalary.TabIndex = 26;
            this.lblRSalary.Text = "Salary";
            // 
            // txtBxBankACC
            // 
            this.txtBxBankACC.Location = new System.Drawing.Point(206, 612);
            this.txtBxBankACC.Name = "txtBxBankACC";
            this.txtBxBankACC.Size = new System.Drawing.Size(200, 22);
            this.txtBxBankACC.TabIndex = 27;
            // 
            // txtBxSalary
            // 
            this.txtBxSalary.Location = new System.Drawing.Point(206, 646);
            this.txtBxSalary.Name = "txtBxSalary";
            this.txtBxSalary.Size = new System.Drawing.Size(200, 22);
            this.txtBxSalary.TabIndex = 28;
            // 
            // btnRecruitEmp
            // 
            this.btnRecruitEmp.Location = new System.Drawing.Point(588, 495);
            this.btnRecruitEmp.Name = "btnRecruitEmp";
            this.btnRecruitEmp.Size = new System.Drawing.Size(158, 34);
            this.btnRecruitEmp.TabIndex = 29;
            this.btnRecruitEmp.Text = "Recruit";
            this.btnRecruitEmp.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.Controls.Add(this.grpBxRecruitEmp);
            this.grpBxRecruitEmp.ResumeLayout(false);
            this.grpBxRecruitEmp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNewEmp)).EndInit();
            this.grpRGender.ResumeLayout(false);
            this.grpRGender.PerformLayout();
            this.ResumeLayout(false);
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

        private void ShowDetailsOfEmployeeList(List<User> userList) {
            dataGridViewEmpList.DataSource = userList;
        }

        private void ShowDetailsOfFoodMenu(List<FoodMenu> fMenuList) { 
            foodMenuList = fMenuList;
            dataGridViewFoodItem.RowTemplate.Height = 250;
            foreach (FoodMenu fm in foodMenuList)
            {
                Image img = Image.FromFile(@"I:\Project\Project\Pic\Food\Menu\" + fm.Name + ".jpg");
                dataGridViewFoodItem.Rows.Add(img);
            }
        }

        private void ShowDetailsOfFoodItems(List<FoodItem> fItemList) {
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

        private void SetOrderOfFoodItems(List<FoodItem> orderftemList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            foreach (FoodItem fi in orderftemList)
            {
                dt.Rows.Add(fi.Name, fi.Price, fi.Quantity);
            }

            dataGridViewOrderList.DataSource = dt;
        }

        
        #endregion

        #region Events
        private void lblProfile_Click(object sender, EventArgs e)
        {
            UserService userService = serviceFactory.GetUserService();
            user = userService.GetUserInfo(user);

            SetTextToProfileComponent();
            grpProfile.Show();
            grpBxFoodMenu.Hide();
            groupBoxEmpList.Hide();
            grpBxRecruitEmp.Hide();
            grpTotalAmount.Hide();
        }
        private void lblEmpList_Click(object sender, EventArgs e)
        {
            UserService userService = serviceFactory.GetUserService();

            ShowDetailsOfEmployeeList(userService.GetAllUserInfo());
            groupBoxEmpList.Show();
            grpProfile.Hide();
            grpBxFoodMenu.Hide();
            grpBxRecruitEmp.Hide();
            grpTotalAmount.Hide();
        }

        private void lblFoodMenu_Click(object sender, EventArgs e)
        {
            FoodItemService foodItemService = serviceFactory.GetFoodItemService();

            ShowDetailsOfFoodMenu(foodItemService.GetFoodMenu());

            grpBxFoodMenu.Show();
            grpProfile.Hide();
            groupBoxEmpList.Hide();
            grpBxRecruitEmp.Hide();
            grpTotalAmount.Hide();
        }

        private void lblRecruit_Click(object sender, EventArgs e)
        {
            //UserService userService = serviceFactory.GetUserService();

            //User user = 
            //userService

            grpBxRecruitEmp.Show();
            grpProfile.Hide();
            grpBxFoodMenu.Hide();
            groupBoxEmpList.Hide();
            grpTotalAmount.Hide();
        }

        private void lblTotalAmount_Click(object sender, EventArgs e) {
            InvoiceService invoiceService = serviceFactory.GetInvoiceService();
            
            lblTAmountInf.Text = invoiceService.GetRevenue().ToString();
            
            grpTotalAmount.Show();
            grpBxRecruitEmp.Hide();
            grpProfile.Hide();
            grpBxFoodMenu.Hide();
            groupBoxEmpList.Hide();
        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            new InvoiceFrame(orderfoodItemList).Show();
        }

        private void Owner_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtBxSearch_Click(object sender, EventArgs e)
        {
            if (txtBxSearch.Text.Equals("Please enter ID"))
            {
                txtBxSearch.Text = "";
            }
        }

        private void txtBxQuantity_Click(object sender, EventArgs e)
        {
            if (txtBxQuantity.Text.Equals("Enter quantity"))
            {
                txtBxSearch.Text = "";
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Dispose();
        }

        private void dataGridViewEmpList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            User usr = new User(Convert.ToInt32(dataGridViewEmpList["Id", e.RowIndex].Value));
            new MessageForm(usr).Show();
        }

        private void dataGridViewFoodItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FoodItemService foodItemService = serviceFactory.GetFoodItemService();

            ShowDetailsOfFoodItems(foodItemService.GetFoodItem(foodMenuList[e.RowIndex].Id));
            //MessageBox.Show("" + foodMenuList[e.RowIndex].Id + "," );
        }

        private void dataGridViewItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0){
                try
                {
                    if (orderfoodItemList.Count > 0)
                    {
                        int j = 0;
                        for (int i = 1; i <= orderfoodItemList.Count; i++)
                        {
                            if (orderfoodItemList[i-1].Id == foodItemList[e.RowIndex].Id)
                            {
                                orderfoodItemList[i-1].Quantity = orderfoodItemList[i-1].Quantity + Convert.ToInt32(txtBxQuantity.Text);
                                SetOrderOfFoodItems(orderfoodItemList);
                                j++;
                            }
                        }
                        if(j == 0){
                            FoodItem fi = foodItemList[e.RowIndex];
                            fi.Quantity = Convert.ToInt32(txtBxQuantity.Text);
                            orderfoodItemList.Add(fi);
                            SetOrderOfFoodItems(orderfoodItemList);
                            throw new ArithmeticException();
                        }
                    }
                    else {
                        FoodItem fi = foodItemList[e.RowIndex];
                        fi.Quantity = Convert.ToInt32(txtBxQuantity.Text);
                        orderfoodItemList.Add(fi);
                        SetOrderOfFoodItems(orderfoodItemList);
                        throw new ArithmeticException();
                    }
                    throw new ArithmeticException();
                }
                catch (ArithmeticException exc)
                {
                    //MessageBox.Show("Please enter an valid quantity!");
                }
                    
                
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            orderfoodItemList.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            foreach (FoodItem fi in orderfoodItemList)
            {
                dt.Rows.Add(fi.Name, fi.Price, fi.Quantity);
            }

            dataGridViewOrderList.DataSource = dt;
        }

        #endregion
    }
}
