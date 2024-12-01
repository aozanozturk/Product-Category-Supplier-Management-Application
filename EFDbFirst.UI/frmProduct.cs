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
            btnUpdateProduct.Enabled = false;//Butonlar� ilk ba�ta kapal� getiriyorum listeden �r�n se�ilince a��l�yor
            btnDeleteProduct.Enabled = false;
            nudUnitPrice.DecimalPlaces = 2;//Fiyat� g�steren numericupdown�n virg�lden sonra 2 basamak g�stermesini sa�lar
            lstAddProductNames();
            ClearForm();
            CmbSupplier();
            CmbCategory();
        }

        public void lstAddProductNames()
        {
            List<Product> products = productRepo.GetAll();  //Product listesi


            lstProducts.DataSource = products;          //--ilk ToString ile isimleri yazd�rd�m ama oradan verilere eri�emedim
            lstProducts.DisplayMember = "ProductName";  // G�sterilecek property
            lstProducts.ValueMember = "ProductID";     //Id ile ili�kilendiriyorum ki producta t�klad���mda di�er bilgilere eri�ebileyim
            lstProducts.SelectedIndex = -1;//Ba�lang��ta hi�bir �r�n�n se�ili olmamas�n� sa�l�yorum ki update ve delete butonlar� aktif olmas�n
        }

        public void CmbSupplier()
        {
            cmbSuppliers.DataSource = supplierRepo.GetAll(); //Supplierlar�n listesini �ekiyorum
            cmbSuppliers.DisplayMember = "CompanyName";  // G�sterilecek olan property 
            cmbSuppliers.ValueMember = "SupplierId";
        }

        public void CmbCategory()
        {
            cmbCategory.DataSource = categoryRepo.GetAll(); //Category listesini �ekiyorum
            cmbCategory.DisplayMember = "CategoryName";  // G�sterilecek olan property
            cmbCategory.ValueMember = "CategoryId"; //Id ile ili�kilendiriyorum ki product� girdi�imizde categoryidsi de olsun
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
            if (string.IsNullOrWhiteSpace(quantityString))//Quantity girilip girilmedi�ini anlamak i�in 
            {
                MessageBox.Show("Please enter a Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal unitPrice = nudUnitPrice.Value;

            decimal unitsInStock = (short)nudUnitsInStock.Value;

            decimal unitsOnOrder = (short)nudUnitsOnOrder.Value;

            decimal reorderLevel = (short)nudReorderLevel.Value;

            bool discontinued = cbxDiscontinued.Checked;

            //Product ad� daha �nce var m� kontrol et
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


                bool result = productRepo.Create(newProduct);//Product olu�turuyoruz

                if (result)//Ba�ar�l�ysa
                {

                    MessageBox.Show("Product Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstAddProductNames();
                    ClearForm();
                }
                else//Ba�ar�s�zsa
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
                //Se�ilen �r�n� al�yoruz
                var selectedProduct = lstProducts.SelectedItem as Product;

                if (selectedProduct != null)
                {
                    //�r�n bilgilerini forma doldur
                    txtProductName.Text = selectedProduct.ProductName;
                    txtQuantity.Text = selectedProduct.QuantityPerUnit;
                    nudUnitPrice.Value = (decimal)selectedProduct.UnitPrice;
                    nudUnitsInStock.Value = (short)selectedProduct.UnitsInStock;
                    nudUnitsOnOrder.Value = (short)selectedProduct.UnitsOnOrder;
                    nudReorderLevel.Value = (short)selectedProduct.ReorderLevel;
                    cbxDiscontinued.Checked = selectedProduct.Discontinued;

                    //Comboboxlarda se�ili de�erleri idleriyle e�ler
                    cmbSuppliers.SelectedValue = selectedProduct.SupplierId;
                    cmbCategory.SelectedValue = selectedProduct.CategoryId;

                    //Butonlar� aktifle�tirir
                    btnUpdateProduct.Enabled = true;
                    btnDeleteProduct.Enabled = true;
                }
            }
            else
            {
                //E�er hi�bir �r�n se�ilmediyse butonlar� devre d��� b�rak
                btnUpdateProduct.Enabled = false;
                btnDeleteProduct.Enabled = false;


                ClearForm();
            }

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            //�r�n ad� kontrol�
            string productName = txtProductName.Text;
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("You can't leave Product Name empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Supplier ve Category se�imi kontrol�
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

            //Quantity kontrol�
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

            //Product ad� daha �nce var m� kontrol et ama mevcut �r�n� g�z ard� et
            bool productExists = productRepo.GetAll()
                .Any(s => s.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase) && s.ProductId != productId); //Mevcut �r�n� g�z ard� et

            if (productExists)
            {
                MessageBox.Show("A product with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //�r�n� idsine g�re veritaban�ndan al
                var existingProduct = productRepo.GetById(productId);

                if (existingProduct != null) //�r�n varsa
                {
                    //Veritaban�ndan al�nan �r�n� g�ncelle
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
                        lstAddProductNames(); //�r�nler listesine yeni haliyle ekle
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Error Occurred While Updating Product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //�r�n yoksa
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
                                                     MessageBoxIcon.Question);//Soru soruyor ve cevaba g�re siliyor yada silmiyor

                if (confirmResult == DialogResult.Yes)//Yes se�erse sil
                {

                    bool deleteResult = productRepo.Delete(selectedProduct);

                    if (deleteResult)
                    {
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //ListBox� yeniden y�kle
                        lstAddProductNames();
                    }
                    else //No se�erse error ver
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
            frmCategory categoryForm = new frmCategory();//Category formu olu�turdum
            categoryForm.ShowDialog();  //Category formu a��l�yor


        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSupplier supplierForm = new frmSupplier();
            supplierForm.ShowDialog();
        }
    }
}
