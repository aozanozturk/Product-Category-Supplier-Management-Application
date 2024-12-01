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
    public partial class frmSupplier : Form
    {
        private readonly IRepository<Product> productRepo;
        private readonly IRepository<Category> categoryRepo;
        private readonly IRepository<Supplier> supplierRepo;
        public frmSupplier()
        {
            InitializeComponent();
            productRepo = new Repository<Product>();
            categoryRepo = new Repository<Category>();
            supplierRepo = new Repository<Supplier>();
            btnUpdateSupplier.Enabled = false;//Başta butonlar kapalı geliyor
            btnDeleteSupplier.Enabled = false;
            lstAddSupplierNames();
            lstSupplier.SelectedIndex = -1;//Hiçbir şey seçili gelmesin diye
            cmbCity.SelectedIndex = -1;
            cmbContactTitle.SelectedIndex = -1;
            cmbRegion.SelectedIndex = -1;
            cmbCountry.SelectedIndex = -1;
            CmbContactTitle();
            CmbCity();
            CmbCountry();
            CmbRegion();
        }
        public void lstAddSupplierNames()
        {
            List<Supplier> suppliers = supplierRepo.GetAll();  //Category listesi


            lstSupplier.DataSource = suppliers;
            lstSupplier.DisplayMember = "CompanyName";  //Gösterilecek property
            lstSupplier.ValueMember = "SupplierId";     //Id ile ilişkilendiriyorum ki categorye tıkladığımda diğer bilgilere erişebileyim
            lstSupplier.SelectedIndex = -1;//Başlangıçta hiçbir categorynin seçili olmamasını sağlıyorum ki update ve delete butonları aktif olmasın
        }
        public void CmbContactTitle()
        {
            //Supplierlardan Contacttitle bilgilerini alır ve null olmayanları seçer.Bazı ContactTitlelar nulldu o yüzden böyle yaptım
            var titles = supplierRepo.GetAll()
                                      .Where(s => !string.IsNullOrEmpty(s.ContactTitle))
                                      .Select(s => s.ContactTitle)
                                      .Distinct()
                                      .ToList();  //Listeye dönüştür
            cmbContactTitle.DataSource = titles;//ComboBoxa ekler
        }
        public void CmbCity()
        {
            cmbCity.DataSource = supplierRepo.GetAll(); //Supplierların listesini çekiyorum
            cmbCity.DisplayMember = "City";  // Gösterilecek olan property 
            cmbCity.ValueMember = "SupplierId";
        }
        public void CmbRegion()
        {
            //Supplierlardan Region bilgilerini alır ve null olmayanları seçer
            var regions = supplierRepo.GetAll()
                                      .Where(s => !string.IsNullOrEmpty(s.Region))
                                      .Select(s => s.Region)
                                      .Distinct()
                                      .ToList();  //Listeye dönüştür 
            cmbRegion.DataSource = regions;//ComboBoxa ekler
        }
        public void CmbCountry()
        {
            //Supplierlardan Country bilgilerini alır ve null olmayanları seçer
            var countries = supplierRepo.GetAll()
                                        .Where(s => !string.IsNullOrEmpty(s.Country))
                                        .Select(s => s.Country)
                                        .Distinct()
                                        .ToList();
            cmbCountry.DataSource = countries;//Comboboxa ekler
        }

        private void btnAddProductS_Click(object sender, EventArgs e)//Butona basınca Product formuna gider
        {
            this.Hide();
            frmProduct formProduct = new frmProduct();
            formProduct.ShowDialog();
        }

        private void btnAddCategoryS_Click(object sender, EventArgs e)//Butona basınca Category sayfasına gider
        {
            this.Hide();
            frmCategory formCategory = new frmCategory();
            formCategory.ShowDialog();
        }

        private void lstSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSupplier.SelectedIndex != -1)
            {
                //Seçilen Supplierı çekiyorum
                var selectedSupplier = lstSupplier.SelectedItem as Supplier;

                if (selectedSupplier != null)
                {
                    //Supplier bilgilerini forma doldur
                    txtCompanyName.Text = selectedSupplier.CompanyName;
                    txtContactName.Text = selectedSupplier.ContactName;
                    cmbContactTitle.Text = selectedSupplier.ContactTitle;
                    txtAddress.Text = selectedSupplier.Address;
                    cmbCity.Text = selectedSupplier.City;
                    cmbRegion.SelectedItem = selectedSupplier.Region;
                    cmbCountry.SelectedItem = selectedSupplier.Country;

                    
                    msktxtPhone.Text = selectedSupplier.Phone;
                    msktxtFax.Text = selectedSupplier.Fax;

                   
                    txtHomePage.Text = selectedSupplier.HomePage;

                    //Butonları aktifleştir
                    btnUpdateSupplier.Enabled = true;
                    btnDeleteSupplier.Enabled = true;
                }
            }
            else
            {
                //Eğer hiçbir Supplier seçilmediyse butonları devre dışı bırak
                btnUpdateSupplier.Enabled = false;
                btnDeleteSupplier.Enabled = false;

                //Formu temizle
                ClearForm();
            }
        }
        private void ClearForm()
        {
            txtCompanyName.Clear();
            txtContactName.Clear();
            txtAddress.Clear();
            cmbCity.SelectedIndex = -1;
            cmbContactTitle.SelectedIndex = -1;
            cmbRegion.SelectedIndex = -1;
            cmbCountry.SelectedIndex = -1;
            msktxtPhone.Clear();
            msktxtFax.Clear();
            txtHomePage.Clear();
        }

        private void btnCreateSupplier_Click(object sender, EventArgs e)
        {

            //TextBoxlardan ve ComboBoxlardan gelen verileri alır
            string companyName = txtCompanyName.Text;
            string contactName = txtContactName.Text;
            string contactTitle = cmbContactTitle.Text;
            string address = txtAddress.Text;
            string city = cmbCity.Text;
            string region = cmbRegion.SelectedItem?.ToString();
            string country = cmbCountry.SelectedItem?.ToString();
            string phone = msktxtPhone.Text;
            string fax = msktxtFax.Text;
            string homePage = txtHomePage.Text;

            //Alanların boş olup olmadığını kontrol edelim
            if (string.IsNullOrWhiteSpace(companyName))
            {
                MessageBox.Show("You can't leave Company Name empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(contactName))
            {
                MessageBox.Show("You can't leave Contact Name empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("You can't leave Address empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("You can't leave Phone empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Supplier adı daha önce var mı kontrol et
            bool supplierExists = supplierRepo.GetAll().Any(s => s.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));

            if (supplierExists)
            {
                MessageBox.Show("A supplier with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Yeni Supplier oluşturuyoruz
                var newSupplier = new Supplier
                {
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    Country = country,
                    Phone = phone,
                    Fax = fax,
                    HomePage = homePage
                };

                //Supplierı veritabanına ekle
                bool result = supplierRepo.Create(newSupplier);

                if (result)
                {
                    MessageBox.Show("Supplier Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstAddSupplierNames();  //Supplier listesini güncelle
                    ClearForm();  //Formu temizle
                }
                else
                {
                    MessageBox.Show("Error Occurred While Adding New Supplier!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCompanyName_KeyPress(object sender, KeyPressEventArgs e)//Sayı girişini engeller
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContactName_KeyPress(object sender, KeyPressEventArgs e)//Sayı girişini engeller
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHomePage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  //Sayıların girişini engeller
            }
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
           
            var selectedSupplier = lstSupplier.SelectedItem as Supplier;  //Burada ListBoxtan Supplierı alıyoruz

            //Seçilen Supplier yoksa işlem yapılmaz
            if (selectedSupplier == null)
            {
                MessageBox.Show("Please select a Supplier to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //TextBoxlardan ve ComboBoxlardan gelen verileri alalım
            string companyName = txtCompanyName.Text;
            string contactName = txtContactName.Text;
            string contactTitle = cmbContactTitle.Text;
            string address = txtAddress.Text;
            string city = cmbCity.Text;
            string region = cmbRegion.SelectedItem?.ToString();  //Region boş olabilir
            string country = cmbCountry.SelectedItem?.ToString();  //Country boş olabilir
            string phone = msktxtPhone.Text;
            string fax = msktxtFax.Text;
            string homePage = txtHomePage.Text;

            //Alanların boş olup olmadığını kontrol eder
            if (string.IsNullOrWhiteSpace(companyName))
            {
                MessageBox.Show("You can't leave Company Name empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(contactName))
            {
                MessageBox.Show("You can't leave Contact Name empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("You can't leave Address empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("You can't leave Phone empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Supplier adı daha önce var mı kontrol eder
            bool supplierExists = supplierRepo.GetAll().Any(s => s.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase) && s.SupplierId != selectedSupplier.SupplierId);

            if (supplierExists)
            {
                MessageBox.Show("A supplier with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Mevcut Supplierı idsine göre çeker
                var existingSupplier = supplierRepo.GetById(selectedSupplier.SupplierId); 

                if (existingSupplier != null)
                {
                    //Mevcut Supplierı günceller
                    existingSupplier.CompanyName = companyName;
                    existingSupplier.ContactName = contactName;
                    existingSupplier.ContactTitle = contactTitle;
                    existingSupplier.Address = address;
                    existingSupplier.City = city;
                    existingSupplier.Region = region;
                    existingSupplier.Country = country;
                    existingSupplier.Phone = phone;
                    existingSupplier.Fax = fax;
                    existingSupplier.HomePage = homePage;


                    bool result = supplierRepo.Update(existingSupplier);

                    if (result)
                    {
                        MessageBox.Show("Supplier Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lstAddSupplierNames();  //Supplier listesini güncelle
                        ClearForm();  //Formu temizle
                    }
                    else
                    {
                        MessageBox.Show("Error Occurred While Updating Supplier!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else//Supplier nullsa
                {
                    MessageBox.Show("Supplier not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {

            //Seçilen Supplierı alıyoruz
            var selectedSupplier = lstSupplier.SelectedItem as Supplier;

            //Eğer selectedSupplier null ise, kullanıcıya mesaj göster
            if (selectedSupplier == null)
            {
                MessageBox.Show("Please select a Supplier to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Silme işlemi için kullanıcıdan onay alalım
            var confirmResult = MessageBox.Show("Are you sure you want to delete this Supplier?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;  //Kullanıcı hayır seçerse silme iptal edilir
            }

            try
            {
                bool result = supplierRepo.Delete(selectedSupplier);  //Supplierı siliyoruz

                if (result)//Eğer başarılıysa
                {
                    MessageBox.Show("Supplier Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstAddSupplierNames();  //Supplier listesini güncelle
                    ClearForm();  //Formu temizle
                }
                else//Başarısızsa
                {
                    MessageBox.Show("Error Occurred While Deleting Supplier!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   }
}
