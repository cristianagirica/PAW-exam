using System;
using Exam1.Entities;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exam1.Properties;
using System.Xml.Serialization;
using System.Runtime.Remoting.Messaging;
using System.Linq.Expressions;

namespace Exam1
{
    public partial class MainForm : Form
    {
        private List<AccessPackage> accessPackages;
        private List<Registration> registrations;
        
        public MainForm()
        {
            InitializeComponent();
            accessPackages = LoadAccessPackages("C:\\Users\\Andra\\source\\repos\\Exam1\\Exam1\\Resources\\AccessPackages.txt");
            Registration.SetAccessPackages(accessPackages);

            registrations = LoadRegistrations("registrations.xml") ?? new List<Registration>();

            UpdateTotalCost();
            PopulateListView();
        }
        // Load the access packages from the xml file
        private List<AccessPackage> LoadAccessPackages(string FilePath)
        {
            List<AccessPackage> packages = new List<AccessPackage>();
            if(File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach(var line in lines)
                {
                    string[] parts = line.Split(',');
                    if(parts.Length == 3)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        double price = double.Parse(parts[2]);

                        packages.Add(new AccessPackage(id, name, price));
                    }
                }
            }
            else
            {
                MessageBox.Show("The file does not exist.");
            }
            return packages;
        }
        // populate the list view from the list registrations
        public void PopulateListView()
        {
            lvRegistrations.Items.Clear();
            if(registrations != null)
            {
                foreach (var registration in registrations)
                {
                    ListViewItem item = new ListViewItem(registration.CompanyName);
                    item.SubItems.Add(registration.NoOfPasses.ToString());
                    item.SubItems.Add(accessPackages.First(p => p.Id == registration.AccessPackageId).Name);
                    item.Tag = registration;

                    lvRegistrations.Items.Add(item);
                }
            }
            
        }

        // save registrations from the add registrations form
        private void SaveRegistrations(string filePath, List<Registration> registrations)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Registration>));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, registrations);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save registrations: {ex.Message}");
            }
        }

        // load registrations list
        private List<Registration> LoadRegistrations(string filePath)
        {
            if (!(File.Exists(filePath)))
            {
                return null;
            }
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Registration>));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return (List<Registration>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load registrations: {ex.Message}");
                return null;
            }

        }
        // add registration
        private void btnAddRegistration_Click(object sender, EventArgs e)
        {
            AddRegistrationForm form = new AddRegistrationForm(accessPackages);

            if(form.ShowDialog() == DialogResult.OK )
            {
                var reg = form.Registration;
                registrations.Add(reg);

                ListViewItem item = new ListViewItem(reg.CompanyName);
                item.SubItems.Add(reg.NoOfPasses.ToString());
                item.SubItems.Add(accessPackages.First(p => p.Id == reg.AccessPackageId).Name);
                item.Tag = reg;

                lvRegistrations.Items.Add(item);

                UpdateTotalCost();
                SaveRegistrations("registrations.xml", registrations);
            }
        }
        // Edit an item from the list view
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvRegistrations.SelectedItems.Count > 0)
            {
                var item = lvRegistrations.SelectedItems[0];
                var registration = (Registration)item.Tag;
                registrations.Remove(registration);

                var form = new AddRegistrationForm(accessPackages, registration);
                if(form.ShowDialog() == DialogResult.OK)
                {
                    registration = form.Registration;
                    registrations.Add(registration);
                    item.SubItems[0].Text = registration.CompanyName;
                    item.SubItems[1].Text = registration.NoOfPasses.ToString();
                    item.SubItems[2].Text = accessPackages.First(p => p.Id == registration.AccessPackageId).Name;
                    item.Tag = registration;

                    UpdateTotalCost();
                    SaveRegistrations("registrations.xml", registrations);
                }
            }
        }
        // delete an item from the list view
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvRegistrations.SelectedItems.Count > 0)
            {
                var item = lvRegistrations.SelectedItems[0];
                var registration = (Registration)item.Tag;  

                registrations.Remove(registration) ;
                lvRegistrations.Items.Remove(item);

                UpdateTotalCost();
                SaveRegistrations("registrations.xml", registrations);
            }
        }

        // update the total cost in the status strip

        private void UpdateTotalCost()
        {
            double totalCost = registrations.Sum(r => (double)r);
            toolStripStatusLabel1.Text = $"Total cost: ${totalCost:F2}";
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            IComparer<Registration> comparer = null;

            switch (cbSortBy.SelectedIndex)
            {
                case 0:
                    comparer = new AccessPackageComparer(accessPackages);
                    break;
                case 1:
                    comparer = new CompanyNameComparer();
                    break;
            }
            if (comparer != null)
            {
                registrations.Sort(comparer);
                PopulateListView();
            }
        }
    }
}
