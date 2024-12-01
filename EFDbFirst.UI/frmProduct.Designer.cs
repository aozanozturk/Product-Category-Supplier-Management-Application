
namespace EFDbFirst.UI
{
    partial class frmProduct
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstProducts = new ListBox();
            label1 = new Label();
            txtProductName = new TextBox();
            txtQuantity = new TextBox();
            cmbSuppliers = new ComboBox();
            cmbCategory = new ComboBox();
            nudUnitPrice = new NumericUpDown();
            nudUnitsInStock = new NumericUpDown();
            nudUnitsOnOrder = new NumericUpDown();
            nudReorderLevel = new NumericUpDown();
            cbxDiscontinued = new CheckBox();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            btnCreateProduct = new Button();
            btnUpdateProduct = new Button();
            btnDeleteProduct = new Button();
            btnAddCategory = new Button();
            btnAddSupplier = new Button();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitsInStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitsOnOrder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudReorderLevel).BeginInit();
            SuspendLayout();
            // 
            // lstProducts
            // 
            lstProducts.FormattingEnabled = true;
            lstProducts.ItemHeight = 15;
            lstProducts.Location = new Point(12, 96);
            lstProducts.Name = "lstProducts";
            lstProducts.Size = new Size(344, 664);
            lstProducts.TabIndex = 0;
            lstProducts.SelectedIndexChanged += lstProducts_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 73);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 1;
            label1.Text = "Product List:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(630, 121);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(200, 23);
            txtProductName.TabIndex = 2;
            txtProductName.KeyPress += txtProductName_KeyPress;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(630, 252);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(200, 23);
            txtQuantity.TabIndex = 3;
            // 
            // cmbSuppliers
            // 
            cmbSuppliers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuppliers.FormattingEnabled = true;
            cmbSuppliers.Location = new Point(630, 165);
            cmbSuppliers.Name = "cmbSuppliers";
            cmbSuppliers.Size = new Size(200, 23);
            cmbSuppliers.TabIndex = 4;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(630, 209);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(200, 23);
            cmbCategory.TabIndex = 5;
            // 
            // nudUnitPrice
            // 
            nudUnitPrice.Location = new Point(631, 298);
            nudUnitPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudUnitPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudUnitPrice.Name = "nudUnitPrice";
            nudUnitPrice.Size = new Size(200, 23);
            nudUnitPrice.TabIndex = 6;
            nudUnitPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudUnitsInStock
            // 
            nudUnitsInStock.Location = new Point(631, 352);
            nudUnitsInStock.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudUnitsInStock.Name = "nudUnitsInStock";
            nudUnitsInStock.Size = new Size(200, 23);
            nudUnitsInStock.TabIndex = 7;
            // 
            // nudUnitsOnOrder
            // 
            nudUnitsOnOrder.Location = new Point(631, 408);
            nudUnitsOnOrder.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudUnitsOnOrder.Name = "nudUnitsOnOrder";
            nudUnitsOnOrder.Size = new Size(200, 23);
            nudUnitsOnOrder.TabIndex = 8;
            // 
            // nudReorderLevel
            // 
            nudReorderLevel.Location = new Point(631, 461);
            nudReorderLevel.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudReorderLevel.Name = "nudReorderLevel";
            nudReorderLevel.Size = new Size(200, 23);
            nudReorderLevel.TabIndex = 9;
            // 
            // cbxDiscontinued
            // 
            cbxDiscontinued.AutoSize = true;
            cbxDiscontinued.Location = new Point(631, 527);
            cbxDiscontinued.Name = "cbxDiscontinued";
            cbxDiscontinued.Size = new Size(43, 19);
            cbxDiscontinued.TabIndex = 10;
            cbxDiscontinued.Text = "Yes";
            cbxDiscontinued.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(493, 124);
            label4.Name = "label4";
            label4.Size = new Size(114, 20);
            label4.TabIndex = 11;
            label4.Text = "Product Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(493, 165);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 11;
            label2.Text = "Supplier:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(493, 212);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 11;
            label3.Text = "Category:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.Location = new Point(493, 255);
            label5.Name = "label5";
            label5.Size = new Size(135, 20);
            label5.TabIndex = 11;
            label5.Text = "Quantity Per Unit:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(493, 301);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 11;
            label6.Text = "Unit Price:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.Location = new Point(493, 355);
            label7.Name = "label7";
            label7.Size = new Size(111, 20);
            label7.TabIndex = 11;
            label7.Text = "Units In Stock:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label8.Location = new Point(493, 411);
            label8.Name = "label8";
            label8.Size = new Size(119, 20);
            label8.TabIndex = 11;
            label8.Text = "Units On Order:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label9.Location = new Point(493, 459);
            label9.Name = "label9";
            label9.Size = new Size(109, 20);
            label9.TabIndex = 11;
            label9.Text = "Reorder Level:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label10.Location = new Point(493, 524);
            label10.Name = "label10";
            label10.Size = new Size(105, 20);
            label10.TabIndex = 11;
            label10.Text = "Discontinued:";
            // 
            // btnCreateProduct
            // 
            btnCreateProduct.BackColor = Color.FromArgb(0, 192, 0);
            btnCreateProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCreateProduct.Location = new Point(493, 625);
            btnCreateProduct.Name = "btnCreateProduct";
            btnCreateProduct.Size = new Size(130, 40);
            btnCreateProduct.TabIndex = 12;
            btnCreateProduct.Text = "Create Product";
            btnCreateProduct.UseVisualStyleBackColor = false;
            btnCreateProduct.Click += btnCreateProduct_Click;
            // 
            // btnUpdateProduct
            // 
            btnUpdateProduct.BackColor = Color.Olive;
            btnUpdateProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdateProduct.Location = new Point(629, 625);
            btnUpdateProduct.Name = "btnUpdateProduct";
            btnUpdateProduct.Size = new Size(130, 40);
            btnUpdateProduct.TabIndex = 13;
            btnUpdateProduct.Text = "Update Product";
            btnUpdateProduct.UseVisualStyleBackColor = false;
            btnUpdateProduct.Click += btnUpdateProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.BackColor = Color.FromArgb(192, 0, 0);
            btnDeleteProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDeleteProduct.Location = new Point(765, 625);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(130, 40);
            btnDeleteProduct.TabIndex = 14;
            btnDeleteProduct.Text = "Delete Product";
            btnDeleteProduct.UseVisualStyleBackColor = false;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.BackColor = Color.FromArgb(255, 128, 0);
            btnAddCategory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddCategory.Location = new Point(833, 11);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(135, 29);
            btnAddCategory.TabIndex = 15;
            btnAddCategory.Text = "Add Category";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.BackColor = Color.FromArgb(255, 128, 0);
            btnAddSupplier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddSupplier.ForeColor = SystemColors.ControlText;
            btnAddSupplier.Location = new Point(974, 12);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(134, 29);
            btnAddSupplier.TabIndex = 16;
            btnAddSupplier.Text = "Add Supplier";
            btnAddSupplier.UseVisualStyleBackColor = false;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // frmProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1131, 792);
            Controls.Add(btnAddSupplier);
            Controls.Add(btnAddCategory);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnUpdateProduct);
            Controls.Add(btnCreateProduct);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(cbxDiscontinued);
            Controls.Add(nudReorderLevel);
            Controls.Add(nudUnitsOnOrder);
            Controls.Add(nudUnitsInStock);
            Controls.Add(nudUnitPrice);
            Controls.Add(cmbCategory);
            Controls.Add(cmbSuppliers);
            Controls.Add(txtQuantity);
            Controls.Add(txtProductName);
            Controls.Add(label1);
            Controls.Add(lstProducts);
            Font = new Font("Segoe UI", 9F);
            Name = "frmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Page";
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitsInStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitsOnOrder).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudReorderLevel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private ListBox lstProducts;
        private Label label1;
        private TextBox txtProductName;
        private TextBox txtQuantity;
        private ComboBox cmbSuppliers;
        private ComboBox cmbCategory;
        private NumericUpDown nudUnitPrice;
        private NumericUpDown nudUnitsInStock;
        private NumericUpDown nudUnitsOnOrder;
        private NumericUpDown nudReorderLevel;
        private CheckBox cbxDiscontinued;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnCreateProduct;
        private Button btnUpdateProduct;
        private Button btnDeleteProduct;
        private Button btnAddCategory;
        private Button btnAddSupplier;
    }
}
