namespace Cashiering_Lloren_IT13
{
    partial class ProductManagement
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

 

    
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            lblTitle = new Label();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            btnSaveAddNew = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(12, 200);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.Size = new Size(658, 300);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(324, 41);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Product Management";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProductName.Location = new Point(12, 65);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(146, 25);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Product Name:";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 11F);
            txtProductName.Location = new Point(164, 60);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(220, 32);
            txtProductName.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPrice.Location = new Point(12, 105);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(61, 25);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 11F);
            txtPrice.Location = new Point(164, 100);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(220, 32);
            txtPrice.TabIndex = 5;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQuantity.Location = new Point(12, 145);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(94, 25);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI", 11F);
            txtQuantity.Location = new Point(164, 140);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(220, 32);
            txtQuantity.TabIndex = 7;
            // 
            // btnSaveAddNew
            // 
            btnSaveAddNew.BackColor = Color.Green;
            btnSaveAddNew.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaveAddNew.ForeColor = Color.White;
            btnSaveAddNew.Location = new Point(400, 60);
            btnSaveAddNew.Name = "btnSaveAddNew";
            btnSaveAddNew.Size = new Size(130, 40);
            btnSaveAddNew.TabIndex = 8;
            btnSaveAddNew.Text = "Add Product";
            btnSaveAddNew.UseVisualStyleBackColor = false;
            btnSaveAddNew.Click += btnSaveAddNew_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Blue;
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(400, 105);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(130, 40);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(540, 60);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 40);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Archive";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ProductManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(689, 530);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSaveAddNew);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(txtProductName);
            Controls.Add(lblProductName);
            Controls.Add(lblTitle);
            Controls.Add(dataGridView1);
            Name = "ProductManagement";
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridView1;
        private Label lblTitle;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnSaveAddNew;
        private Button btnUpdate;
        private Button btnDelete;
    }
}
