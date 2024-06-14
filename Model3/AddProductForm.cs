using Model3.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model3
{
    public partial class AddProductForm : Form
    {
        public Product product;
        public List<Category> categories;
        public AddProductForm(List<Category> categ, Product product = null)
        {
            InitializeComponent();
            categories = categ;
            cbCategory.Items.AddRange(categories.Select(c=>c.Name).ToArray());
            nudId.Validating += nudId_Validating;
            tbName.Validating += tbName_Validating;
            nudUnits.Validating += nudUnits_Validating;
            nudPrice.Validating += nudPrice_Validating;
            cbCategory.Validating += cbCategory_Validating;

            if(product != null)
            {
                nudId.Value = product.Id;
                tbName.Text = product.Name;
                nudUnits.Value = product.Units;
                nudPrice.Value = (decimal)product.Price;
                cbCategory.SelectedIndex = categories.FindIndex(c=>c.Id==product.CategoryId);
            }
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = (int)nudId.Value;
            string name = tbName.Text;
            int units = (int)nudUnits.Value;
            double price = (double)nudPrice.Value;
            string category = cbCategory.Text;
            int CId = categories.Find(c => c.Name == category).Id;

            product = new Product(id, name, units, price, CId);
        }

        private void nudId_Validating(object sender, CancelEventArgs e)
        {
            int val = 0;
            foreach (var prod in MainForm.products)
            {
                if(nudId.Value == prod.Id)
                {
                    val = 1;
                    break;
                }
            }
            if(nudId.Value <= 0 || val == 1) 
            {
                e.Cancel = true;
                errorProvider1.SetError(nudId, "Invalid Id");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(nudId, "");
            }
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbName, "Please enter a product name");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(tbName, "");
            }
        }

        private void nudUnits_Validating(object sender, CancelEventArgs e)
        {
            if(nudUnits.Value <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudUnits, "Please insert a number of units available");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(nudUnits, "");
            }
        }

        private void nudPrice_Validating(object sender, CancelEventArgs e)
        {
            if(nudPrice.Value <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudPrice, "Please insert a price");
            }
            else
            {
                e.Cancel  = false;
                errorProvider1.SetError(nudPrice, "");
            }
        }

        private void cbCategory_Validating(object sender, CancelEventArgs e)
        {
            if(cbCategory.Items.Count == 0) 
            {
                e.Cancel = true;
                errorProvider1.SetError(cbCategory, "Please select a category");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbCategory, "");
            }
        }
    }
}
