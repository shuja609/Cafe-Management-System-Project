namespace cafeManagementSystem
{
    partial class Cashier_Payment
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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TotalAmount = new System.Windows.Forms.Label();
            this.EnterAmountLabel = new System.Windows.Forms.Label();
            this.EnteredAmount = new System.Windows.Forms.TextBox();
            this.CashBack = new System.Windows.Forms.Label();
            this.CashBackOutput = new System.Windows.Forms.Label();
            this.ShowAmount = new System.Windows.Forms.Label();
            this.BackButtom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(212, 174);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(2);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(153, 43);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // TotalAmount
            // 
            this.TotalAmount.AutoSize = true;
            this.TotalAmount.Location = new System.Drawing.Point(153, 42);
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Size = new System.Drawing.Size(70, 13);
            this.TotalAmount.TabIndex = 1;
            this.TotalAmount.Text = "Total Amount";
            this.TotalAmount.Click += new System.EventHandler(this.label1_Click);
            // 
            // EnterAmountLabel
            // 
            this.EnterAmountLabel.AutoSize = true;
            this.EnterAmountLabel.Location = new System.Drawing.Point(153, 77);
            this.EnterAmountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EnterAmountLabel.Name = "EnterAmountLabel";
            this.EnterAmountLabel.Size = new System.Drawing.Size(94, 13);
            this.EnterAmountLabel.TabIndex = 2;
            this.EnterAmountLabel.Text = "Enter Amount paid";
            // 
            // EnteredAmount
            // 
            this.EnteredAmount.Location = new System.Drawing.Point(329, 77);
            this.EnteredAmount.Margin = new System.Windows.Forms.Padding(2);
            this.EnteredAmount.Name = "EnteredAmount";
            this.EnteredAmount.Size = new System.Drawing.Size(121, 20);
            this.EnteredAmount.TabIndex = 3;
            this.EnteredAmount.TextChanged += new System.EventHandler(this.EnteredAmount_TextChanged);
            // 
            // CashBack
            // 
            this.CashBack.AutoSize = true;
            this.CashBack.Location = new System.Drawing.Point(153, 120);
            this.CashBack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CashBack.Name = "CashBack";
            this.CashBack.Size = new System.Drawing.Size(59, 13);
            this.CashBack.TabIndex = 4;
            this.CashBack.Text = "Cash Back";
            this.CashBack.Click += new System.EventHandler(this.label3_Click);
            // 
            // CashBackOutput
            // 
            this.CashBackOutput.AutoSize = true;
            this.CashBackOutput.Location = new System.Drawing.Point(349, 120);
            this.CashBackOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CashBackOutput.Name = "CashBackOutput";
            this.CashBackOutput.Size = new System.Drawing.Size(58, 13);
            this.CashBackOutput.TabIndex = 5;
            this.CashBackOutput.Text = "returnCash";
            this.CashBackOutput.Click += new System.EventHandler(this.CashBackOutput_Click);
            // 
            // ShowAmount
            // 
            this.ShowAmount.AutoSize = true;
            this.ShowAmount.Location = new System.Drawing.Point(349, 42);
            this.ShowAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShowAmount.Name = "ShowAmount";
            this.ShowAmount.Size = new System.Drawing.Size(70, 13);
            this.ShowAmount.TabIndex = 6;
            this.ShowAmount.Text = "Total Amount";
            this.ShowAmount.Click += new System.EventHandler(this.ShowAmount_Click);
            // 
            // BackButtom
            // 
            this.BackButtom.Location = new System.Drawing.Point(398, 252);
            this.BackButtom.Margin = new System.Windows.Forms.Padding(2);
            this.BackButtom.Name = "BackButtom";
            this.BackButtom.Size = new System.Drawing.Size(114, 24);
            this.BackButtom.TabIndex = 7;
            this.BackButtom.Text = "Back";
            this.BackButtom.UseVisualStyleBackColor = true;
            this.BackButtom.Click += new System.EventHandler(this.BackButtom_Click);
            // 
            // Cashier_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.BackButtom);
            this.Controls.Add(this.ShowAmount);
            this.Controls.Add(this.CashBackOutput);
            this.Controls.Add(this.CashBack);
            this.Controls.Add(this.EnteredAmount);
            this.Controls.Add(this.EnterAmountLabel);
            this.Controls.Add(this.TotalAmount);
            this.Controls.Add(this.ConfirmButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Cashier_Payment";
            this.Text = "Cashier_Payment";
            this.Load += new System.EventHandler(this.Cashier_Payment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label TotalAmount;
        private System.Windows.Forms.Label EnterAmountLabel;
        private System.Windows.Forms.TextBox EnteredAmount;
        private System.Windows.Forms.Label CashBack;
        private System.Windows.Forms.Label CashBackOutput;
        private System.Windows.Forms.Label ShowAmount;
        private System.Windows.Forms.Button BackButtom;
    }
}