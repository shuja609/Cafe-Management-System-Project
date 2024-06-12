namespace cafeManagementSystem
{
    partial class foodSectionCustomerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(foodSectionCustomerView));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FoodSection = new System.Windows.Forms.DataGridView();
            this.Item_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Des = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availibality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_to_Cart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Remove_From_Cart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PlaceOrder = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FoodSection)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkOrange;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(13, 393);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 22);
            this.button2.TabIndex = 1;
            this.button2.Text = "log out";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 450);
            this.panel1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkOrange;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(134, 395);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 22);
            this.button3.TabIndex = 4;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // FoodSection
            // 
            this.FoodSection.BackgroundColor = System.Drawing.SystemColors.Info;
            this.FoodSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FoodSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item_ID,
            this.item_name,
            this.Item_Des,
            this.availibality,
            this.Price,
            this.cart,
            this.Add_to_Cart,
            this.Remove_From_Cart});
            this.FoodSection.Location = new System.Drawing.Point(127, 52);
            this.FoodSection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FoodSection.Name = "FoodSection";
            this.FoodSection.RowHeadersWidth = 62;
            this.FoodSection.RowTemplate.Height = 28;
            this.FoodSection.Size = new System.Drawing.Size(595, 331);
            this.FoodSection.TabIndex = 5;
            this.FoodSection.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FoodSection_CellClick);
            this.FoodSection.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FoodSection_CellContentClick);
            // 
            // Item_ID
            // 
            this.Item_ID.FillWeight = 30F;
            this.Item_ID.HeaderText = "Item ID";
            this.Item_ID.MinimumWidth = 8;
            this.Item_ID.Name = "Item_ID";
            this.Item_ID.Width = 40;
            // 
            // item_name
            // 
            this.item_name.FillWeight = 30F;
            this.item_name.HeaderText = "Item Name";
            this.item_name.MinimumWidth = 8;
            this.item_name.Name = "item_name";
            this.item_name.Width = 70;
            // 
            // Item_Des
            // 
            this.Item_Des.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item_Des.HeaderText = "Item Descreption";
            this.Item_Des.MinimumWidth = 8;
            this.Item_Des.Name = "Item_Des";
            // 
            // availibality
            // 
            this.availibality.FillWeight = 30F;
            this.availibality.HeaderText = "Availibality";
            this.availibality.MinimumWidth = 8;
            this.availibality.Name = "availibality";
            this.availibality.Width = 70;
            // 
            // Price
            // 
            this.Price.FillWeight = 40F;
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            this.Price.Width = 50;
            // 
            // cart
            // 
            this.cart.FillWeight = 30F;
            this.cart.HeaderText = "Cart";
            this.cart.MinimumWidth = 8;
            this.cart.Name = "cart";
            this.cart.ToolTipText = "Add";
            this.cart.Width = 40;
            // 
            // Add_to_Cart
            // 
            this.Add_to_Cart.FillWeight = 30F;
            this.Add_to_Cart.HeaderText = "Add to Cart";
            this.Add_to_Cart.MinimumWidth = 8;
            this.Add_to_Cart.Name = "Add_to_Cart";
            this.Add_to_Cart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add_to_Cart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Add_to_Cart.Text = "Add";
            this.Add_to_Cart.UseColumnTextForButtonValue = true;
            this.Add_to_Cart.Width = 50;
            // 
            // Remove_From_Cart
            // 
            this.Remove_From_Cart.FillWeight = 30F;
            this.Remove_From_Cart.HeaderText = "Remove from Cart";
            this.Remove_From_Cart.MinimumWidth = 8;
            this.Remove_From_Cart.Name = "Remove_From_Cart";
            this.Remove_From_Cart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove_From_Cart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Remove_From_Cart.Text = "Remove";
            this.Remove_From_Cart.UseColumnTextForButtonValue = true;
            this.Remove_From_Cart.Width = 50;
            // 
            // PlaceOrder
            // 
            this.PlaceOrder.BackColor = System.Drawing.Color.DarkOrange;
            this.PlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlaceOrder.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaceOrder.Location = new System.Drawing.Point(602, 387);
            this.PlaceOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PlaceOrder.Name = "PlaceOrder";
            this.PlaceOrder.Size = new System.Drawing.Size(73, 38);
            this.PlaceOrder.TabIndex = 2;
            this.PlaceOrder.Text = "Place Order";
            this.PlaceOrder.UseVisualStyleBackColor = false;
            this.PlaceOrder.Click += new System.EventHandler(this.button4_Click);
            // 
            // foodSectionCustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(761, 444);
            this.Controls.Add(this.PlaceOrder);
            this.Controls.Add(this.FoodSection);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "foodSectionCustomerView";
            this.Text = "foodSection";
            this.Load += new System.EventHandler(this.foodSectionCustomerView_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FoodSection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView FoodSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Des;
        private System.Windows.Forms.DataGridViewTextBoxColumn availibality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn cart;
        private System.Windows.Forms.DataGridViewButtonColumn Add_to_Cart;
        private System.Windows.Forms.DataGridViewButtonColumn Remove_From_Cart;
        private System.Windows.Forms.Button PlaceOrder;
    }
}