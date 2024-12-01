namespace EFDbFirst.UI
{
    partial class frmSupplier
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
            lstSupplier = new ListBox();
            label1 = new Label();
            btnAddProductS = new Button();
            btnAddCategoryS = new Button();
            btnCreateSupplier = new Button();
            btnUpdateSupplier = new Button();
            btnDeleteSupplier = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            txtCompanyName = new TextBox();
            txtContactName = new TextBox();
            cmbContactTitle = new ComboBox();
            txtAddress = new TextBox();
            cmbCity = new ComboBox();
            cmbRegion = new ComboBox();
            txtPostalCode = new TextBox();
            cmbCountry = new ComboBox();
            msktxtFax = new MaskedTextBox();
            msktxtPhone = new MaskedTextBox();
            txtHomePage = new TextBox();
            SuspendLayout();
            // 
            // lstSupplier
            // 
            lstSupplier.FormattingEnabled = true;
            lstSupplier.ItemHeight = 15;
            lstSupplier.Location = new Point(12, 96);
            lstSupplier.Name = "lstSupplier";
            lstSupplier.Size = new Size(344, 664);
            lstSupplier.TabIndex = 0;
            lstSupplier.SelectedIndexChanged += lstSupplier_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 73);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 1;
            label1.Text = "Supplier List:";
            // 
            // btnAddProductS
            // 
            btnAddProductS.BackColor = Color.ForestGreen;
            btnAddProductS.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddProductS.Location = new Point(860, 35);
            btnAddProductS.Name = "btnAddProductS";
            btnAddProductS.Size = new Size(107, 36);
            btnAddProductS.TabIndex = 2;
            btnAddProductS.Text = "Add Product";
            btnAddProductS.UseVisualStyleBackColor = false;
            btnAddProductS.Click += btnAddProductS_Click;
            // 
            // btnAddCategoryS
            // 
            btnAddCategoryS.BackColor = Color.ForestGreen;
            btnAddCategoryS.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddCategoryS.Location = new Point(973, 35);
            btnAddCategoryS.Name = "btnAddCategoryS";
            btnAddCategoryS.Size = new Size(115, 36);
            btnAddCategoryS.TabIndex = 3;
            btnAddCategoryS.Text = "Add Category";
            btnAddCategoryS.UseVisualStyleBackColor = false;
            btnAddCategoryS.Click += btnAddCategoryS_Click;
            // 
            // btnCreateSupplier
            // 
            btnCreateSupplier.BackColor = Color.RoyalBlue;
            btnCreateSupplier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCreateSupplier.Location = new Point(488, 646);
            btnCreateSupplier.Name = "btnCreateSupplier";
            btnCreateSupplier.Size = new Size(123, 44);
            btnCreateSupplier.TabIndex = 4;
            btnCreateSupplier.Text = "Create Supplier";
            btnCreateSupplier.UseVisualStyleBackColor = false;
            btnCreateSupplier.Click += btnCreateSupplier_Click;
            // 
            // btnUpdateSupplier
            // 
            btnUpdateSupplier.BackColor = Color.Green;
            btnUpdateSupplier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdateSupplier.Location = new Point(617, 646);
            btnUpdateSupplier.Name = "btnUpdateSupplier";
            btnUpdateSupplier.Size = new Size(134, 44);
            btnUpdateSupplier.TabIndex = 5;
            btnUpdateSupplier.Text = "Update Supplier";
            btnUpdateSupplier.UseVisualStyleBackColor = false;
            btnUpdateSupplier.Click += btnUpdateSupplier_Click;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.BackColor = Color.OrangeRed;
            btnDeleteSupplier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDeleteSupplier.Location = new Point(757, 646);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(130, 44);
            btnDeleteSupplier.TabIndex = 6;
            btnDeleteSupplier.Text = "Delete Supplier";
            btnDeleteSupplier.UseVisualStyleBackColor = false;
            btnDeleteSupplier.Click += btnDeleteSupplier_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(497, 100);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 7;
            label2.Text = "Company Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(497, 144);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 7;
            label3.Text = "Contact Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(497, 195);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 7;
            label4.Text = "Contact Title:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.Location = new Point(497, 246);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 7;
            label5.Text = "Address:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(497, 290);
            label6.Name = "label6";
            label6.Size = new Size(40, 20);
            label6.TabIndex = 7;
            label6.Text = "City:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.Location = new Point(495, 388);
            label7.Name = "label7";
            label7.Size = new Size(95, 20);
            label7.TabIndex = 7;
            label7.Text = "Postal Code:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label8.Location = new Point(497, 339);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 7;
            label8.Text = "Region:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label9.Location = new Point(495, 432);
            label9.Name = "label9";
            label9.Size = new Size(70, 20);
            label9.TabIndex = 7;
            label9.Text = "Country:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label10.Location = new Point(495, 473);
            label10.Name = "label10";
            label10.Size = new Size(57, 20);
            label10.TabIndex = 7;
            label10.Text = "Phone:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label11.Location = new Point(495, 508);
            label11.Name = "label11";
            label11.Size = new Size(37, 20);
            label11.TabIndex = 7;
            label11.Text = "Fax:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label12.Location = new Point(495, 550);
            label12.Name = "label12";
            label12.Size = new Size(93, 20);
            label12.TabIndex = 7;
            label12.Text = "Home Page:";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(644, 101);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(209, 23);
            txtCompanyName.TabIndex = 8;
            txtCompanyName.KeyPress += txtCompanyName_KeyPress;
            // 
            // txtContactName
            // 
            txtContactName.Location = new Point(644, 141);
            txtContactName.Name = "txtContactName";
            txtContactName.Size = new Size(209, 23);
            txtContactName.TabIndex = 9;
            txtContactName.KeyPress += txtContactName_KeyPress;
            // 
            // cmbContactTitle
            // 
            cmbContactTitle.FormattingEnabled = true;
            cmbContactTitle.Location = new Point(644, 196);
            cmbContactTitle.Name = "cmbContactTitle";
            cmbContactTitle.Size = new Size(209, 23);
            cmbContactTitle.TabIndex = 10;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(644, 247);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(209, 23);
            txtAddress.TabIndex = 11;
            // 
            // cmbCity
            // 
            cmbCity.FormattingEnabled = true;
            cmbCity.Location = new Point(644, 291);
            cmbCity.Name = "cmbCity";
            cmbCity.Size = new Size(209, 23);
            cmbCity.TabIndex = 12;
            // 
            // cmbRegion
            // 
            cmbRegion.FormattingEnabled = true;
            cmbRegion.Location = new Point(644, 340);
            cmbRegion.Name = "cmbRegion";
            cmbRegion.Size = new Size(209, 23);
            cmbRegion.TabIndex = 13;
            // 
            // txtPostalCode
            // 
            txtPostalCode.Location = new Point(644, 388);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(209, 23);
            txtPostalCode.TabIndex = 14;
            // 
            // cmbCountry
            // 
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Location = new Point(644, 429);
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(209, 23);
            cmbCountry.TabIndex = 15;
            // 
            // msktxtFax
            // 
            msktxtFax.Location = new Point(644, 509);
            msktxtFax.Name = "msktxtFax";
            msktxtFax.Size = new Size(209, 23);
            msktxtFax.TabIndex = 16;
            // 
            // msktxtPhone
            // 
            msktxtPhone.Location = new Point(644, 470);
            msktxtPhone.Name = "msktxtPhone";
            msktxtPhone.Size = new Size(209, 23);
            msktxtPhone.TabIndex = 17;
            // 
            // txtHomePage
            // 
            txtHomePage.Location = new Point(644, 551);
            txtHomePage.Name = "txtHomePage";
            txtHomePage.Size = new Size(209, 23);
            txtHomePage.TabIndex = 18;
            txtHomePage.KeyPress += txtHomePage_KeyPress;
            // 
            // frmSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(1131, 792);
            Controls.Add(txtHomePage);
            Controls.Add(msktxtPhone);
            Controls.Add(msktxtFax);
            Controls.Add(cmbCountry);
            Controls.Add(txtPostalCode);
            Controls.Add(cmbRegion);
            Controls.Add(cmbCity);
            Controls.Add(txtAddress);
            Controls.Add(cmbContactTitle);
            Controls.Add(txtContactName);
            Controls.Add(txtCompanyName);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(btnDeleteSupplier);
            Controls.Add(btnUpdateSupplier);
            Controls.Add(btnCreateSupplier);
            Controls.Add(btnAddCategoryS);
            Controls.Add(btnAddProductS);
            Controls.Add(label1);
            Controls.Add(lstSupplier);
            Name = "frmSupplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Supplier Page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstSupplier;
        private Label label1;
        private Button btnAddProductS;
        private Button btnAddCategoryS;
        private Button btnCreateSupplier;
        private Button btnUpdateSupplier;
        private Button btnDeleteSupplier;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox txtCompanyName;
        private TextBox txtContactName;
        private ComboBox cmbContactTitle;
        private TextBox txtAddress;
        private ComboBox cmbCity;
        private ComboBox cmbRegion;
        private TextBox txtPostalCode;
        private ComboBox cmbCountry;
        private MaskedTextBox msktxtFax;
        private MaskedTextBox msktxtPhone;
        private TextBox txtHomePage;
    }
}