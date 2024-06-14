using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelRo.Entities;

namespace ModelRo
{
    public partial class AddSmartphonesForm : Form
    {
        
        public List<Producer> producers;
        public Smartphone smartphone;

        #region Add Smartphones Form
        public AddSmartphonesForm(List<Producer> prod, Smartphone smartphone = null)
        {
            InitializeComponent();

            producers = prod;
            
            cbProd.Items.AddRange(producers.Select(p => p.Name).ToArray());
            nudId.Validating += nudId_Validating;
            tbModel.Validating += tbModel_Validating;
            nudUnits.Validating += nudUnits_Validating;
            nudPrice.Validating += nudPrice_Validating;
            dtpDate.Validating += dtpDate_Validating;
            cbProd.Validating += cbProd_Validating;
            if(smartphone != null)
            {
                nudId.Value = smartphone.Id;
                tbModel.Text = smartphone.Model;
                nudUnits.Value = smartphone.Units;
                nudPrice.Value = (decimal)smartphone.Price;
                dtpDate.Value = smartphone.ReleaseDate;
                cbProd.SelectedIndex = producers.FindIndex(p =>  p.Id == smartphone.ProducerId);
            }
        }
        #endregion

        #region Save Button
        private void btnSave_Click(object sender, EventArgs e)
        {
           if(ValidateChildren())
            {
                int id = (int)nudId.Value;
                string model = tbModel.Text;
                int units = (int)nudUnits.Value;
                double price = (double)nudPrice.Value;
                DateTime date = dtpDate.Value;
                int selectedIndex = cbProd.SelectedIndex;
                int prodId = producers[selectedIndex].Id;

                smartphone = new Smartphone(id, model, units, price, date, prodId);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Validating Error Provider
        private void nudId_Validating(object sender, CancelEventArgs e)
        {
            int val = 0;
            foreach(var smartphone in MainForm.smartphones)
            {
                if (nudId.Value == smartphone.Id)
                {
                    val = 1;
                    break;
                }
            }
            if(nudId.Value == 0 || val == 1)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudId, "Id is not valid");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void tbModel_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbModel.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(tbModel, "Model can not be empty");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void nudUnits_Validating(object sender, CancelEventArgs e)
        {
            if(nudUnits.Value == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudUnits, "Available units can not be 0");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void nudPrice_Validating(object sender, CancelEventArgs e)
        {
            if(nudPrice.Value == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudPrice, "Price can not be 0");
            }
            else 
            { 
                e.Cancel = false; 
            }  
        }

        private void dtpDate_Validating(object sender, CancelEventArgs e)
        {
            if(dtpDate.Value > DateTime.Now)
            {
                e.Cancel = true;
                errorProvider1.SetError(dtpDate, "Date is not valid");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void cbProd_Validating(object sender, CancelEventArgs e)
        {
            if(cbProd.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbProd, "Please select a producer");
            }
            else
            {
                e.Cancel = false;
            }
        }
        #endregion
    }
}
