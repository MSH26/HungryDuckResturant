namespace HungryDuckResturant
{
    partial class MessageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBxAsk = new System.Windows.Forms.TextBox();
            this.btnYES = new System.Windows.Forms.Button();
            this.btnNO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBxAsk
            // 
            this.txtBxAsk.Enabled = false;
            this.txtBxAsk.Location = new System.Drawing.Point(12, 21);
            this.txtBxAsk.Multiline = true;
            this.txtBxAsk.Name = "txtBxAsk";
            this.txtBxAsk.Size = new System.Drawing.Size(324, 42);
            this.txtBxAsk.TabIndex = 0;
            this.txtBxAsk.Text = "Are you sure? Press \"YES\" to fire or \"CANCEL\" to cancel";
            // 
            // btnYES
            // 
            this.btnYES.Location = new System.Drawing.Point(76, 90);
            this.btnYES.Name = "btnYES";
            this.btnYES.Size = new System.Drawing.Size(75, 23);
            this.btnYES.TabIndex = 1;
            this.btnYES.Text = "YES";
            this.btnYES.UseVisualStyleBackColor = true;
            this.btnYES.Click += new System.EventHandler(this.btnYES_Click);
            // 
            // btnNO
            // 
            this.btnNO.Location = new System.Drawing.Point(210, 90);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(75, 23);
            this.btnNO.TabIndex = 2;
            this.btnNO.Text = "NO";
            this.btnNO.UseVisualStyleBackColor = true;
            this.btnNO.Click += new System.EventHandler(this.btnNO_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 125);
            this.Controls.Add(this.btnNO);
            this.Controls.Add(this.btnYES);
            this.Controls.Add(this.txtBxAsk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBxAsk;
        private System.Windows.Forms.Button btnYES;
        private System.Windows.Forms.Button btnNO;
    }
}