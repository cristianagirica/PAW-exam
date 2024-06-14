using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelRo.Entities;
using System.IO;
using System.Data.SQLite;

namespace ModelRo
{
    public partial class MainForm : Form
    {
        private static string connectionString = "Data Source=C:\\Users\\Andra\\source\\repos\\ModelRo\\ModelRo\\database.db";
        public static string filePath = "C:\\Users\\Andra\\source\\repos\\ModelRo\\ModelRo\\Resources\\Producers.txt";
        private List<Producer> producers;
        public static List<Smartphone> smartphones;

        #region Main Form
        public MainForm()
        {
            InitializeComponent();
            smartphones = new List<Smartphone>();
            producers = LoadProducers(filePath) ?? new List<Producer>();
            LoadSmartphones();

            dgvSmartphones.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dgvSmartphones_RowHeaderMouseClick);
        }
        #endregion

        #region Load Producers from Text File
        public List<Producer> LoadProducers(string filePath)
        {
            List<Producer> producers = new List<Producer>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach(var line in lines)
                {
                    string[] parts = line.Split(',');
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    
                    producers.Add(new Producer(id, name));
                    
                }
            }
            else
            {
                MessageBox.Show("The file does not exist.");
            }
            return producers;
        }
        #endregion

        #region Data Base
        public void AddSmartphoneDB(Smartphone smartphone)
        {
            string query = "INSERT INTO Smartphones(Id, Model, Units, Price, Date, PId) " +
                           "VALUES (@Id, @Model, @Units, @Price, @Date, @PId)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", smartphone.Id);
                        cmd.Parameters.AddWithValue("@Model", smartphone.Model);
                        cmd.Parameters.AddWithValue("@Units", smartphone.Units);
                        cmd.Parameters.AddWithValue("@Price", smartphone.Price);
                        cmd.Parameters.AddWithValue("@Date", smartphone.ReleaseDate);
                        cmd.Parameters.AddWithValue("@PId", smartphone.ProducerId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
                
            }
            PopulateGridValue();
        }
        private void LoadSmartphones()
        {
            smartphones.Clear();
            string query = "SELECT * FROM Smartphones";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                using(SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("Id"));
                        string model = reader.GetString(reader.GetOrdinal("Model"));
                        int units = reader.GetInt32(reader.GetOrdinal("Units"));
                        double price = reader.GetDouble(reader.GetOrdinal("Price"));
                        DateTime date = reader.GetDateTime(reader.GetOrdinal("Date"));
                        int pid = reader.GetInt32(reader.GetOrdinal("PId"));


                        Smartphone smartphone = new Smartphone(id, model, units, price, date, pid);
                        smartphones.Add(smartphone);
                    }
                }
            }
            PopulateGridValue();

        }

        private void DeleteFromDB(Smartphone smartphone)
        {
            string query = "DELETE FROM Smartphones WHERE Id = @Id";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@Id", smartphone.Id);
                command.ExecuteNonQuery();

                
            }
            smartphones.Remove(smartphone);
        }
        #endregion

        #region Add Smartphone Button
        private void btnAddSmartphone_Click(object sender, EventArgs e)
        {
            AddSmartphonesForm form = new AddSmartphonesForm(producers);
            
            if(form.ShowDialog() == DialogResult.OK)
            {
                var smartphone = form.smartphone;
                AddSmartphoneDB(smartphone);
                LoadSmartphones();
            }
        }
        #endregion

        #region Data Grid View
        private void PopulateGridValue()
        {
            dgvSmartphones.Rows.Clear();
            string producer = "";
            int indexRow = 0;
            foreach(var smartphone in smartphones)
            {
                producer = producers.First(p => p.Id == smartphone.ProducerId).Name;
                indexRow = dgvSmartphones.Rows.Add(smartphone.Id.ToString(), smartphone.Model, smartphone.Units.ToString(),
                    smartphone.Price.ToString(), smartphone.ReleaseDate.ToString("dd/mm/yyyy"), producer);
                dgvSmartphones.Rows[indexRow].Tag = smartphone;
            }
        }

        private void dgvSmartphones_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvSmartphones.Rows[e.RowIndex].Selected = true;
            }
        }
        #endregion

        #region Context Tool Strip
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvSmartphones.SelectedRows.Count > 0 && dgvSmartphones.SelectedRows[0].Index != -1)
            {
                var item = dgvSmartphones.SelectedRows[0];
                var smartphone = (Smartphone)item.Tag;
                AddSmartphonesForm form = new AddSmartphonesForm(producers, smartphone);
                if(form.ShowDialog() == DialogResult.OK)
                {
                    DeleteFromDB(smartphone);
                    smartphone = form.smartphone;
                    AddSmartphoneDB(smartphone);
                    LoadSmartphones();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvSmartphones.SelectedRows.Count > 0)
            {
                var item = dgvSmartphones.SelectedRows[0];
                var smartphone = ( Smartphone)item.Tag;
                DeleteFromDB(smartphone);
                LoadSmartphones();
            }
        }
        #endregion

        #region Sort Combo Box
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            IComparer<Smartphone> comparer = null;
            switch(cbSort.SelectedIndex)
            {
                case 0:
                    comparer = new ReleaseDateComparer(); 
                    break;
                case 1:
                    comparer = new PriceComparer();
                    break;
            }
            smartphones.Sort(comparer);
            PopulateGridValue();
        }
        #endregion

        #region Total Available Units
        private void btnTot_Click(object sender, EventArgs e)
        {
            
            int totAv = 0;
            foreach(Smartphone smartphone in smartphones)
            {
                totAv += (int)smartphone;
            }
            MessageBox.Show($"Total available units: {totAv}");
        }
        #endregion
    }
}
