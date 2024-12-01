using EFDbFirst.UI.Model;
using EFDbFirst.UI.Repositories.Abstract;
using EFDbFirst.UI.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDbFirst.UI
{
    public partial class frmCategory : Form
    {
        private readonly IRepository<Product> productRepo;
        private readonly IRepository<Category> categoryRepo;
        private readonly IRepository<Supplier> supplierRepo;
        public frmCategory()
        {
            InitializeComponent();
            productRepo = new Repository<Product>();
            categoryRepo = new Repository<Category>();
            supplierRepo = new Repository<Supplier>();
            btnUpdateCategory.Enabled = false;
            btnDeleteCategory.Enabled = false;
            lstAddCategoryNames();
            lstCategory.SelectedIndex = -1;//İlk açıldığında hiçbir kategori seçili olmasın ki update ve delete butonları kapalı gelsin
            ClearForm();
        }

        private void InitializeComponent()
        {
            lstCategory = new ListBox();
            label1 = new Label();
            btnAddProduct = new Button();
            btnAddSupplier = new Button();
            label2 = new Label();
            label3 = new Label();
            txtCategoryName = new TextBox();
            richtxtDescription = new RichTextBox();
            btnCreateCategory = new Button();
            btnUpdateCategory = new Button();
            btnDeleteCategory = new Button();
            SuspendLayout();
            // 
            // lstCategory
            // 
            lstCategory.FormattingEnabled = true;
            lstCategory.ItemHeight = 20;
            lstCategory.Location = new Point(12, 72);
            lstCategory.Name = "lstCategory";
            lstCategory.Size = new Size(326, 584);
            lstCategory.TabIndex = 0;
            lstCategory.SelectedIndexChanged += lstCategory_SelectedIndexChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 49);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 1;
            label1.Text = "Category List:";
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.Goldenrod;
            btnAddProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddProduct.Location = new Point(833, 11);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(135, 29);
            btnAddProduct.TabIndex = 2;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.BackColor = Color.Goldenrod;
            btnAddSupplier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddSupplier.Location = new Point(974, 12);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(135, 29);
            btnAddSupplier.TabIndex = 3;
            btnAddSupplier.Text = "Add Supplier";
            btnAddSupplier.UseVisualStyleBackColor = false;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(471, 241);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 4;
            label2.Text = "Category Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(501, 308);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 5;
            label3.Text = "Description:";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(600, 242);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(314, 27);
            txtCategoryName.TabIndex = 6;
            txtCategoryName.KeyPress += txtCategoryName_KeyPress;
            // 
            // richtxtDescription
            // 
            richtxtDescription.Location = new Point(600, 308);
            richtxtDescription.Name = "richtxtDescription";
            richtxtDescription.Size = new Size(314, 175);
            richtxtDescription.TabIndex = 7;
            richtxtDescription.Text = "";
            richtxtDescription.KeyPress += richtxtDescription_KeyPress;
            // 
            // btnCreateCategory
            // 
            btnCreateCategory.BackColor = Color.CornflowerBlue;
            btnCreateCategory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCreateCategory.Location = new Point(493, 625);
            btnCreateCategory.Name = "btnCreateCategory";
            btnCreateCategory.Size = new Size(137, 40);
            btnCreateCategory.TabIndex = 8;
            btnCreateCategory.Text = "Create Category";
            btnCreateCategory.UseVisualStyleBackColor = false;
            btnCreateCategory.Click += btnCreateCategory_Click;
            // 
            // btnUpdateCategory
            // 
            btnUpdateCategory.BackColor = Color.Green;
            btnUpdateCategory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdateCategory.Location = new Point(636, 625);
            btnUpdateCategory.Name = "btnUpdateCategory";
            btnUpdateCategory.Size = new Size(137, 40);
            btnUpdateCategory.TabIndex = 9;
            btnUpdateCategory.Text = "Update Category";
            btnUpdateCategory.UseVisualStyleBackColor = false;
            btnUpdateCategory.Click += btnUpdateCategory_Click;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.BackColor = Color.LightCoral;
            btnDeleteCategory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDeleteCategory.Location = new Point(777, 625);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(137, 40);
            btnDeleteCategory.TabIndex = 10;
            btnDeleteCategory.Text = "Delete Category";
            btnDeleteCategory.UseVisualStyleBackColor = false;
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // frmCategory
            // 
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(1131, 792);
            Controls.Add(btnDeleteCategory);
            Controls.Add(btnUpdateCategory);
            Controls.Add(btnCreateCategory);
            Controls.Add(richtxtDescription);
            Controls.Add(txtCategoryName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnAddSupplier);
            Controls.Add(btnAddProduct);
            Controls.Add(label1);
            Controls.Add(lstCategory);
            Font = new Font("Segoe UI", 11F);
            Name = "frmCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Category Page";
            ResumeLayout(false);
            PerformLayout();
        }

        public void lstAddCategoryNames()
        {
            List<Category> categories = categoryRepo.GetAll();  //Category listesi


            lstCategory.DataSource = categories;
            lstCategory.DisplayMember = "CategoryName";  // Gösterilecek property
            lstCategory.ValueMember = "CategoryId";     //Id ile ilişkilendiriyorum ki categorye tıkladığımda diğer bilgilere erişebileyim
            lstCategory.SelectedIndex = -1;//Başlangıçta hiçbir categorynin seçili olmamasını sağlıyorum ki update ve delete butonları aktif olmasın
        }


        private ListBox lstCategory;
        private Label label1;
        private Button btnAddProduct;
        private Button btnAddSupplier;
        private Label label2;
        private Label label3;
        private TextBox txtCategoryName;
        private RichTextBox richtxtDescription;
        private Button btnCreateCategory;
        private Button btnUpdateCategory;
        private Button btnDeleteCategory;

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            //CategoryName ve Description TextBoxlarından gelen verileri alalım
            string categoryName = txtCategoryName.Text;
            string description = richtxtDescription.Text;

            //CategoryName boş mu kontrol eder
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("You can't leave Category Name empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Description boş mu kontrol et
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("You can't leave Description empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool categoryExists = categoryRepo.GetAll().Any(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            if (categoryExists)//Category varsa error veriyor
            {
                MessageBox.Show("A category with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                //Yeni Category oluşturur
                var newCategory = new Category
                {
                    CategoryName = categoryName,
                    Description = description
                };


                bool result = categoryRepo.Create(newCategory); //Yeni Categoryi ekler

                if (result)
                {
                    MessageBox.Show("Category Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstAddCategoryNames();//ListBox'ı güncellemek için kategori isimlerini yeniden listele
                    
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Error Occurred While Adding New Category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An Error Occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Hata olursa gösterir
            }



        }
        private void ClearForm()
        {
            txtCategoryName.Clear();
            richtxtDescription.Clear();
        }

        private void txtCategoryName_KeyPress(object sender, KeyPressEventArgs e)//Sadece harf girilebilir
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;//Yukarıdaki koşullara uyan bir şey girilirse engeller
            }
        }

        private void richtxtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            //Kategori adı boş geçilemez kontrolü
            string categoryName = txtCategoryName.Text;
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("You can't leave Category Name empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int categoryId = (int)lstCategory.SelectedValue; //ListBoxtan seçilen kategori idsini al

            //Mevcut kategori adını güncel kategoriden hariç tutarak kontrol et
            bool categoryExists = categoryRepo.GetAll()
                .Any(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase) && c.CategoryId != categoryId);

            if (categoryExists) // Aynı isimde başka bir kategori var mı diye kontrol
            {
                MessageBox.Show("A category with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Açıklama boş geçilemez kontrolü
            string description = richtxtDescription.Text;
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("You can't leave Description empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Kategoriyi idsine göre veritabanından al
                var existingCategory = categoryRepo.GetById(categoryId);

                if (existingCategory != null) //Kategori varsa
                {
                    //Veritabanından alınan kategoriyi güncelle
                    existingCategory.CategoryName = categoryName;
                    existingCategory.Description = description;

                    //Kategoriyi güncelle
                    bool result = categoryRepo.Update(existingCategory);

                    if (result)
                    {
                        MessageBox.Show("Category Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lstAddCategoryNames(); //Kategoriler listesine yeni haliyle ekle
                        ClearForm(); //Formu temizle
                    }
                    else
                    {
                        MessageBox.Show("Error Occurred While Updating Category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //Kategori yoksa
                {
                    MessageBox.Show("Category not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstCategory.SelectedIndex != -1)
            {
                //Seçilen kategoriyi alıyoruz
                var selectedCategory = lstCategory.SelectedItem as Category;

                if (selectedCategory != null)
                {
                    //Kategori bilgilerini forma doldur
                    txtCategoryName.Text = selectedCategory.CategoryName;
                    richtxtDescription.Text = selectedCategory.Description ?? "No description available"; // Description boşsa, yedeğe sahip olacak

                    //Butonları aktifleştirir
                    btnUpdateCategory.Enabled = true;
                    btnDeleteCategory.Enabled = true;
                }
            }
            else
            {
                //Eğer hiçbir kategori seçilmediyse butonları devre dışı bırak
                btnUpdateCategory.Enabled = false;
                btnDeleteCategory.Enabled = false;
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            var selectedCategory = lstCategory.SelectedItem as Category;

            if (selectedCategory != null)
            {
                //Onay isteme
                var confirmResult = MessageBox.Show("Are you sure you want to delete this category?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);//Soru soruyor ve cevaba göre siliyor yada silmiyor

                if (confirmResult == DialogResult.Yes)//Yes seçerse sil
                {

                    bool deleteResult = categoryRepo.Delete(selectedCategory);

                    if (deleteResult)
                    {
                        MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //ListBoxı yeniden yükle
                        lstAddCategoryNames();
                       
                    }
                    else //No seçerse error ver
                    {
                        MessageBox.Show("Error deleting the category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else
            {
                MessageBox.Show("Please select a category to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmProduct productForm = new frmProduct();//Product formu oluşturdum
            productForm.ShowDialog();  //Product formu açılır
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSupplier supplierForm = new frmSupplier();
            supplierForm.ShowDialog();
        }
       
    }
}

