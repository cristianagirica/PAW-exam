using System;
using Exam1.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam1
{
    public partial class AddRegistrationForm : Form
    {
        private List<AccessPackage> AccessPackages;
        public Registration Registration { get; set; }

        public AddRegistrationForm(List<AccessPackage> accessPackages, Registration registration = null)
        {
            InitializeComponent();
            AccessPackages = accessPackages;
            cbAccessPackage.Items.AddRange(AccessPackages.Select(p => p.Name).ToArray());

            if(registration != null )
            {
                tbCompanyName.Text = registration.CompanyName;
                nudNoOfPasses.Value = registration.NoOfPasses;
                cbAccessPackage.SelectedIndex = accessPackages.FindIndex(p => p.Id == registration.AccessPackageId);
            }
        }

        private void AddRegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = tbCompanyName.Text;
            int noOfPasses = (int)nudNoOfPasses.Value;
            int selectedIndex = (int)cbAccessPackage.SelectedIndex;
            if(string.IsNullOrEmpty(name) )
            {
                MessageBox.Show("The name can not be empty");
                return;
            }
            if(selectedIndex < 0 )
            {
                MessageBox.Show("Please select an access package!");
                return;
            }
            int accessPackageId = AccessPackages[selectedIndex].Id;
            Registration = new Registration(name, noOfPasses, accessPackageId);

            Close();
        }
    }
}
