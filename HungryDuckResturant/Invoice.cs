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
    public partial class InvoiceFrame : Form
    {
        #region UtilityVariables

        ServiceFactory serviceFactory;
        List<FoodItem> orderfoodItemList;

        #endregion

        #region Component

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPaid;
        //private System.Windows.Forms.Button btnUnpaid;
        private System.Windows.Forms.Label lblResturantName;
        private System.Windows.Forms.GroupBox grpBxGender;
        private System.Windows.Forms.RadioButton rdbtnOthers;
        private System.Windows.Forms.RadioButton rdbtnFemale;
        private System.Windows.Forms.RadioButton rdbtnMale;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalInf;
        private System.Windows.Forms.TextBox txtBxCustomerName;
        private System.Windows.Forms.TextBox txtBxCustomerPhone;

        #endregion


        #region Method

        public InvoiceFrame(List<FoodItem> orderfoodItemList)
        {
            this.orderfoodItemList = orderfoodItemList;
            InitializeComponent();
            SetInitializeComponent();
            dataGridView1.DataSource = orderfoodItemList;
            serviceFactory = new ServiceFactory();
            double tempPrice = 0.0D;
            foreach(FoodItem fi in orderfoodItemList){
                tempPrice = tempPrice + (fi.Price * fi.Quantity);
            }
            lblTotalInf.Text = tempPrice.ToString();
        }

        private void SetInitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPaid = new System.Windows.Forms.Button();
            //this.btnUnpaid = new System.Windows.Forms.Button();
            this.lblResturantName = new System.Windows.Forms.Label();
            this.grpBxGender = new System.Windows.Forms.GroupBox();
            this.rdbtnOthers = new System.Windows.Forms.RadioButton();
            this.rdbtnFemale = new System.Windows.Forms.RadioButton();
            this.rdbtnMale = new System.Windows.Forms.RadioButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalInf = new System.Windows.Forms.Label();
            this.txtBxCustomerName = new System.Windows.Forms.TextBox();
            this.txtBxCustomerPhone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpBxGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(32, 97);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Customer Name";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(32, 134);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(49, 17);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Phone";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(187, 57);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(247, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 162);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(528, 399);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnPaid
            // 
            this.btnPaid.Location = new System.Drawing.Point(587, 492);
            this.btnPaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(115, 36);
            this.btnPaid.TabIndex = 4;
            this.btnPaid.Text = "Paid";
            this.btnPaid.UseVisualStyleBackColor = true;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            //// 
            //// btnUnpaid
            //// 
            //this.btnUnpaid.Location = new System.Drawing.Point(587, 553);
            //this.btnUnpaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            //this.btnUnpaid.Name = "btnUnpaid";
            //this.btnUnpaid.Size = new System.Drawing.Size(112, 36);
            //this.btnUnpaid.TabIndex = 5;
            //this.btnUnpaid.Text = "Unpaid";
            //this.btnUnpaid.UseVisualStyleBackColor = true;
            // 
            // lblResturantName
            // 
            this.lblResturantName.AutoSize = true;
            this.lblResturantName.Location = new System.Drawing.Point(281, 25);
            this.lblResturantName.Name = "lblResturantName";
            this.lblResturantName.Size = new System.Drawing.Size(156, 17);
            this.lblResturantName.TabIndex = 6;
            this.lblResturantName.Text = "Hungry Duck Resturant";
            // 
            // grpBxGender
            // 
            this.grpBxGender.Controls.Add(this.rdbtnOthers);
            this.grpBxGender.Controls.Add(this.rdbtnFemale);
            this.grpBxGender.Controls.Add(this.rdbtnMale);
            this.grpBxGender.Location = new System.Drawing.Point(600, 57);
            this.grpBxGender.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBxGender.Name = "grpBxGender";
            this.grpBxGender.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBxGender.Size = new System.Drawing.Size(83, 100);
            this.grpBxGender.TabIndex = 7;
            this.grpBxGender.TabStop = false;
            this.grpBxGender.Text = "Gender";
            // 
            // rdbtnOthers
            // 
            this.rdbtnOthers.AutoSize = true;
            this.rdbtnOthers.Location = new System.Drawing.Point(5, 73);
            this.rdbtnOthers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbtnOthers.Name = "rdbtnOthers";
            this.rdbtnOthers.Size = new System.Drawing.Size(65, 21);
            this.rdbtnOthers.TabIndex = 2;
            this.rdbtnOthers.TabStop = true;
            this.rdbtnOthers.Text = "Other";
            this.rdbtnOthers.UseVisualStyleBackColor = true;
            // 
            // rdbtnFemale
            // 
            this.rdbtnFemale.AutoSize = true;
            this.rdbtnFemale.Location = new System.Drawing.Point(5, 47);
            this.rdbtnFemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbtnFemale.Name = "rdbtnFemale";
            this.rdbtnFemale.Size = new System.Drawing.Size(75, 21);
            this.rdbtnFemale.TabIndex = 1;
            this.rdbtnFemale.TabStop = true;
            this.rdbtnFemale.Text = "Female";
            this.rdbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rdbtnMale
            // 
            this.rdbtnMale.AutoSize = true;
            this.rdbtnMale.Location = new System.Drawing.Point(5, 20);
            this.rdbtnMale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbtnMale.Name = "rdbtnMale";
            this.rdbtnMale.Size = new System.Drawing.Size(59, 21);
            this.rdbtnMale.TabIndex = 0;
            this.rdbtnMale.TabStop = true;
            this.rdbtnMale.Text = "Male";
            this.rdbtnMale.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(340, 572);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 17);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Total = ";
            // 
            // lblTotalInf
            // 
            this.lblTotalInf.AutoSize = true;
            this.lblTotalInf.Location = new System.Drawing.Point(427, 572);
            this.lblTotalInf.Name = "lblTotalInf";
            this.lblTotalInf.Size = new System.Drawing.Size(40, 17);
            this.lblTotalInf.TabIndex = 9;
            this.lblTotalInf.Text = "Total";
            // 
            // txtBxCustomerName
            // 
            this.txtBxCustomerName.Location = new System.Drawing.Point(187, 92);
            this.txtBxCustomerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBxCustomerName.Name = "txtBxCustomerName";
            this.txtBxCustomerName.Size = new System.Drawing.Size(313, 22);
            this.txtBxCustomerName.TabIndex = 10;
            // 
            // txtBxCustomerPhone
            // 
            this.txtBxCustomerPhone.Location = new System.Drawing.Point(187, 129);
            this.txtBxCustomerPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBxCustomerPhone.Name = "txtBxCustomerPhone";
            this.txtBxCustomerPhone.Size = new System.Drawing.Size(313, 22);
            this.txtBxCustomerPhone.TabIndex = 11;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(740, 615);
            this.Controls.Add(this.txtBxCustomerPhone);
            this.Controls.Add(this.txtBxCustomerName);
            this.Controls.Add(this.lblTotalInf);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.grpBxGender);
            this.Controls.Add(this.lblResturantName);
            //this.Controls.Add(this.btnUnpaid);
            this.Controls.Add(this.btnPaid);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Invoice";
            this.Text = "Invoice";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpBxGender.ResumeLayout(false);
            this.grpBxGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        #region Events

        private void btnPaid_Click(object sender, EventArgs e) {
            CustomerService customerService = serviceFactory.GetCustomerService();
            OrderService orderService = serviceFactory.GetOrderService();
            InvoiceService invoiceService = serviceFactory.GetInvoiceService();
            Customer customer;
            string temp = "";

            if (rdbtnMale.Checked == true)
            {
               customer = new Customer((customerService.GetCustId() + 1), txtBxCustomerName.Text, "Male", txtBxCustomerPhone.Text);
               foreach (FoodItem fi in orderfoodItemList)
               {
                   temp = temp + fi.Id;
               }
               if (customerService.StoreCustomerInfo(customer) == true)
               {
                   Order or = new Order((orderService.GetOrderId() + 1), temp);
                   if (orderService.StoreOrderInfo(or) == true)
                   {
                       Invoice inv = new Invoice((invoiceService.GetInvoiceId() + 1), Convert.ToDouble(lblTotalInf.Text), or.Id, customer.Id);
                       if (invoiceService.StoreOrderInfo(inv) == true)
                       {
                           MessageBox.Show("Attempt successfull");
                       }
                       else
                       {
                           customerService.DeleteCustomerInfo(or.Id);
                           orderService.DeleteOrderInfo(or.Id);
                           MessageBox.Show("Attempt unsuccessfull");
                       }
                   }
                   else {
                       customerService.DeleteCustomerInfo(or.Id);
                       MessageBox.Show("Attempt unsuccessfull");
                   }
               }
            }
            else if (rdbtnFemale.Checked == true)
            {
                customer = new Customer((customerService.GetCustId() + 1), txtBxCustomerName.Text, "Female", txtBxCustomerPhone.Text);
                foreach (FoodItem fi in orderfoodItemList)
                {
                    temp = temp + fi.Id;
                }
                if (customerService.StoreCustomerInfo(customer) == true)
                {
                    Order or = new Order((orderService.GetOrderId() + 1), temp);
                    if (orderService.StoreOrderInfo(or) == true)
                    {
                        Invoice inv = new Invoice((invoiceService.GetInvoiceId() + 1), Convert.ToDouble(lblTotalInf.Text), or.Id, customer.Id);
                        if (invoiceService.StoreOrderInfo(inv) == true)
                        {
                            MessageBox.Show("Attempt successfull");
                        }
                        else
                        {
                            customerService.DeleteCustomerInfo(or.Id);
                            orderService.DeleteOrderInfo(or.Id);
                            MessageBox.Show("Attempt unsuccessfull");
                        }
                    }
                    else
                    {
                        customerService.DeleteCustomerInfo(or.Id);
                        MessageBox.Show("Attempt unsuccessfull");
                    }
                }
            }
            else if(rdbtnOthers.Checked == true){
                customer = new Customer((customerService.GetCustId() + 1), txtBxCustomerName.Text, "Other", txtBxCustomerPhone.Text);
                foreach (FoodItem fi in orderfoodItemList)
                {
                    temp = temp + fi.Id;
                }
                if (customerService.StoreCustomerInfo(customer) == true)
                {
                    Order or = new Order((orderService.GetOrderId() + 1), temp);
                    if (orderService.StoreOrderInfo(or) == true)
                    {
                        Invoice inv = new Invoice((invoiceService.GetInvoiceId() + 1), Convert.ToDouble(lblTotalInf.Text), or.Id, customer.Id);
                        if (invoiceService.StoreOrderInfo(inv) == true)
                        {
                            MessageBox.Show("Attempt successfull");
                        }
                        else
                        {
                            customerService.DeleteCustomerInfo(or.Id);
                            orderService.DeleteOrderInfo(or.Id);
                            MessageBox.Show("Attempt unsuccessfull");
                        }
                    }
                    else
                    {
                        customerService.DeleteCustomerInfo(or.Id);
                        MessageBox.Show("Attempt unsuccessfull");
                    }
                }
            }
        }

        #endregion
    }
}
