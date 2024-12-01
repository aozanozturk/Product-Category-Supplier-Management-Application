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
    public partial class frmProduct : Form
    {
        private readonly IRepository<Product> productRepo;
        private readonly IRepository<Category> categoryRepo;
        private readonly IRepository<Supplier> supplierRepo;

        public frmProduct()
        {

            InitializeComponent();
            productRepo = new Repository<Product>();
            categoryRepo = new Repository<Category>();
            supplierRepo = new Repository<Supplier>();
            btnUpdateProduct.Enabled = false;//Butonlarý ilk baþta kapalý getiriyorum listeden ürün seçilince açýlýyor
            btnDeleteProduct.Enabled = false;
            nudUnitPrice.DecimalPlaces = 2;//Fiyatý gösteren numericupdownýn virgülden sonra 2 basamak göstermesini saðlar
            lstAddProductNames();
            ClearForm();
            CmbSupplier();
            CmbCategory();
        }

        public void lstAddProductNames()
        {
            List<Product> products = productRepo.GetAll();  //Product listesi


            lstProducts.DataSource = products;          //--ilk ToString ile isimleri yazdýrdým ama oradan verilere eriþemedim
            lstProducts.DisplayMember = "ProductName";  // Gösterilecek property
            lstProducts.ValueMember = "ProductID";     //Id ile iliþkilendiriyorum ki producta týkladýðýmda diðer bilgilere eriþebileyim
            lstProducts.SelectedIndex = -1;//Baþlangýçta hiçbir ürünün seçili olmamasýný saðlýyorum ki update ve delete butonlarý aktif olmasýn
        }

        public void CmbSupplier()
        {
            cmbSuppliers.DataSource = supplierRepo.GetAll(); //Supplierlarýn listesini çekiyorum
            cmbSuppliers.DisplayMember = "CompanyName";  // Gösterilecek olan property 
            cmbSuppliers.ValueMember = "SupplierId";
        }

        public void CmbCategory()
        {
            cmbCategory.DataSource = categoryRepo.GetAll(); //Category listesini çekiyorum
            cmbCategory.DisplayMember = "CategoryName";  // Gösterilecek olan property
            cmbCategory.ValueMember = "CategoryId"; //Id ile iliþkilendiriyorum ki productý girdiðimizde categoryidsi de olsun
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("You cant leave Product Name empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedSupplier = (Supplier)cmbSuppliers.SelectedItem;
            if (selectedSupplier == null)
            {
                MessageBox.Show("Please select a Supplier!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedCategory = (Category)cmbCategory.SelectedItem;
            if (selectedCategory == null)
            {
                MessageBox.Show("Please select a Category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int supplierId = selectedSupplier.SupplierId;

            int categoryId = selectedCategory.CategoryId;


            string supplierName = cmbSuppliers.Text;
            string categoryName = cmbCategory.Text;
            string quantityString = txtQuantity.Text;
            decimal quantity;
            if (string.IsNullOrWhiteSpace(quantityString))//Quantity girilip girilmediðini anlamak için 
            {
                MessageBox.Show("Please enter a Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal unitPrice = nudUnitPrice.Value;

            decimal unitsInStock = (short)nudUnitsInStock.Value;

            decimal unitsOnOrder = (short)nudUnitsOnOrder.Value;

            decimal reorderLevel = (short)nudReorderLevel.Value;

            bool discontinued = cbxDiscontinued.Checked;

            //Product adý daha önce var mý kontrol et
            bool productExists = productRepo.GetAll().Any(s => s.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (productExists)
            {
                MessageBox.Show("A product with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {

                var newProduct = new Product
                {
                    ProductName = productName,
                    SupplierId = supplierId,
                    CategoryId = categoryId,
                    QuantityPerUnit = quantityString,
                    UnitPrice = unitPrice,
                    UnitsInStock = (short)unitsInStock,
                    UnitsOnOrder = (short)unitsOnOrder,
                    ReorderLevel = (short)reorderLevel,
                    Discontinued = discontinued
                };


                bool result = productRepo.Create(newProduct);//Product oluþturuyoruz

                if (result)//Baþarýlýysa
                {

                    MessageBox.Show("Product Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstAddProductNames();
                    ClearForm();
                }
                else//Baþarýsýzsa
                {
                    MessageBox.Show("Error Occured While Adding New Product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An Error Occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)//Sadece harfler girilebilir
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }


        private void ClearForm()//Formu temizler
        {

            txtProductName.Clear();
            txtQuantity.Clear();
            cmbSuppliers.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            nudUnitPrice.Value = nudUnitPrice.Minimum;
            nudUnitsInStock.Value = nudUnitsInStock.Minimum;
            nudUnitsOnOrder.Value = nudUnitsOnOrder.Minimum;
            nudReorderLevel.Value = nudReorderLevel.Minimum;
            txtQuantity.Clear();
            cbxDiscontinued.Checked = false;
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex != -1)
            {
                //Seçilen ürünü alýyoruz
                var selectedProduct = lstProducts.SelectedItem as Product;

                if (selectedProduct != null)
                {
                    //Ürün bilgilerini forma doldur
                    txtProductName.Text = selectedProduct.ProductName;
                    txtQuantity.Text = selectedProduct.QuantityPerUnit;
                    nudUnitPrice.Value = (decimal)selectedProduct.UnitPrice;
                    nudUnitsInStock.Value = (short)selectedProduct.UnitsInStock;
                    nudUnitsOnOrder.Value = (short)selectedProduct.UnitsOnOrder;
                    nudReorderLevel.Value = (short)selectedProduct.ReorderLevel;
                    cbxDiscontinued.Checked = selectedProduct.Discontinued;

                    //Comboboxlarda seçili deðerleri idleriyle eþler
                    cmbSuppliers.SelectedValue = selectedProduct.SupplierId;
                    cmbCategory.SelectedValue = selectedProduct.CategoryId;

                    //Butonlarý aktifleþtirir
                    btnUpdateProduct.Enabled = true;
                    btnDeleteProduct.Enabled = true;
                }
            }
            else
            {
                //Eðer hiçbir ürün seçilmediyse butonlarý devre dýþý býrak
                btnUpdateProduct.Enabled = false;
                btnDeleteProduct.Enabled = false;


                ClearForm();
            }

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            //Ürün adý kontrolü
            string productName = txtProductName.Text;
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("You can't leave Product Name empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Supplier ve Category seçimi kontrolü
            var selectedSupplier = (Supplier)cmbSuppliers.SelectedItem;
            if (selectedSupplier == null)
            {
                MessageBox.Show("Please select a Supplier!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedCategory = (Category)cmbCategory.SelectedItem;
            if (selectedCategory == null)
            {
                MessageBox.Show("Please select a Category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //SupplierId ve CategoryId'yi al
            int supplierId = selectedSupplier.SupplierId;
            int categoryId = selectedCategory.CategoryId;

            //Quantity kontrolü
            string quantityString = txtQuantity.Text;
            decimal quantity;
            if (string.IsNullOrWhiteSpace(quantityString))
            {
                MessageBox.Show("Please enter a valid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal unitPrice = nudUnitPrice.Value;

            decimal unitsInStock = nudUnitsInStock.Value;

            decimal unitsOnOrder = nudUnitsOnOrder.Value;

            decimal reorderLevel = nudReorderLevel.Value;

            bool discontinued = cbxDiscontinued.Checked;

            int productId = (int)lstProducts.SelectedValue;

            //Product adý daha önce var mý kontrol et ama mevcut ürünü göz ardý et
            bool productExists = productRepo.GetAll()
                .Any(s => s.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase) && s.ProductId != productId); //Mevcut ürünü göz ardý et

            if (productExists)
            {
                MessageBox.Show("A product with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Ürünü idsine göre veritabanýndan al
                var existingProduct = productRepo.GetById(productId);

                if (existingProduct != null) //Ürün varsa
                {
                    //Veritabanýndan alýnan ürünü güncelle
                    existingProduct.ProductName = productName;
                    existingProduct.SupplierId = supplierId;
                    existingProduct.CategoryId = categoryId;
                    existingProduct.QuantityPerUnit = quantityString;
                    existingProduct.UnitPrice = unitPrice;
                    existingProduct.UnitsInStock = (short)unitsInStock;
                    existingProduct.UnitsOnOrder = (short)unitsOnOrder;
                    existingProduct.ReorderLevel = (short)reorderLevel;
                    existingProduct.Discontinued = discontinued;

                    bool result = productRepo.Update(existingProduct);

                    if (result)
                    {
                        MessageBox.Show("Product Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lstAddProductNames(); //Ürünler listesine yeni haliyle ekle
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Error Occurred While Updating Product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //Ürün yoksa
                {
                    MessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            var selectedProduct = lstProducts.SelectedItem as Product;

            if (selectedProduct != null)
            {
                //Onay isteme
                var confirmResult = MessageBox.Show("Are you sure you want to delete this product?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);//Soru soruyor ve cevaba göre siliyor yada silmiyor

                if (confirmResult == DialogResult.Yes)//Yes seçerse sil
                {

                    bool deleteResult = productRepo.Delete(selectedProduct);

                    if (deleteResult)
                    {
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //ListBoxý yeniden yükle
                        lstAddProductNames();
                    }
                    else //No seçerse error ver
                    {
                        MessageBox.Show("Error deleting the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCategory categoryForm = new frmCategory();//Category formu oluþturdum
            categoryForm.ShowDialog();  //Category formu açýlýyor


        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSupplier supplierForm = new frmSupplier();
            supplierForm.ShowDialog();
        }
    }
}
