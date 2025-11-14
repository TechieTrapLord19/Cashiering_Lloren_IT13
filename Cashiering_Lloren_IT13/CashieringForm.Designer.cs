namespace Cashiering_Lloren_IT13
{
    partial class CashieringForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblSelectProduct = new Label();
            cmbProducts = new ComboBox();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            btnAddCart = new Button();
            lblCurrentSale = new Label();
            dgvCart = new DataGridView();
            lblTotal = new Label();
            btnFinalizeSale = new Button();
            btnManageProducts = new Button();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // lblSelectProduct
            // 
            lblSelectProduct.AutoSize = true;
            lblSelectProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSelectProduct.Location = new Point(15, 15);
            lblSelectProduct.Name = "lblSelectProduct";
            lblSelectProduct.Size = new Size(146, 25);
            lblSelectProduct.TabIndex = 0;
            lblSelectProduct.Text = "Select Product:";
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.Font = new Font("Segoe UI", 11F);
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(15, 45);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(280, 33);
            cmbProducts.TabIndex = 1;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQuantity.Location = new Point(15, 85);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(94, 25);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 11F);
            numQuantity.Location = new Point(15, 115);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 32);
            numQuantity.TabIndex = 3;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddCart
            // 
            btnAddCart.BackColor = Color.Green;
            btnAddCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddCart.ForeColor = Color.White;
            btnAddCart.Location = new Point(150, 115);
            btnAddCart.Name = "btnAddCart";
            btnAddCart.Size = new Size(145, 35);
            btnAddCart.TabIndex = 4;
            btnAddCart.Text = "Add to Cart";
            btnAddCart.UseVisualStyleBackColor = false;
            btnAddCart.Click += btnAddCart_Click;
            // 
            // lblCurrentSale
            // 
            lblCurrentSale.AutoSize = true;
            lblCurrentSale.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCurrentSale.Location = new Point(15, 160);
            lblCurrentSale.Name = "lblCurrentSale";
            lblCurrentSale.Size = new Size(127, 25);
            lblCurrentSale.TabIndex = 5;
            lblCurrentSale.Text = "Current Sale:";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCart.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCart.Location = new Point(15, 190);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.RowTemplate.Height = 28;
            dgvCart.Size = new Size(600, 250);
            dgvCart.TabIndex = 6;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.DarkGreen;
            lblTotal.Location = new Point(452, 46);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(163, 32);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "TOTAL: ₱0.00";
            // 
            // btnFinalizeSale
            // 
            btnFinalizeSale.BackColor = Color.Blue;
            btnFinalizeSale.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFinalizeSale.ForeColor = Color.White;
            btnFinalizeSale.Location = new Point(452, 111);
            btnFinalizeSale.Name = "btnFinalizeSale";
            btnFinalizeSale.Size = new Size(160, 45);
            btnFinalizeSale.TabIndex = 8;
            btnFinalizeSale.Text = "Finalize Sale";
            btnFinalizeSale.UseVisualStyleBackColor = false;
            btnFinalizeSale.Click += btnFinalizeSale_Click;
            // 
            // btnManageProducts
            // 
            btnManageProducts.BackColor = Color.Orange;
            btnManageProducts.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnManageProducts.ForeColor = Color.White;
            btnManageProducts.Location = new Point(15, 450);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(170, 40);
            btnManageProducts.TabIndex = 9;
            btnManageProducts.Text = "Manage Products";
            btnManageProducts.UseVisualStyleBackColor = false;
            btnManageProducts.Click += btnManageProducts_Click;
            // 
            // CashieringForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(627, 510);
            Controls.Add(btnManageProducts);
            Controls.Add(btnFinalizeSale);
            Controls.Add(lblTotal);
            Controls.Add(dgvCart);
            Controls.Add(lblCurrentSale);
            Controls.Add(btnAddCart);
            Controls.Add(numQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(cmbProducts);
            Controls.Add(lblSelectProduct);
            Font = new Font("Segoe UI", 10F);
            Name = "CashieringForm";
            Text = "Cashiering System";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectProduct;
        private ComboBox cmbProducts;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Button btnAddCart;
        private Label lblCurrentSale;
        private DataGridView dgvCart;
        private Label lblTotal;
        private Button btnFinalizeSale;
        private Button btnManageProducts;
    }
}