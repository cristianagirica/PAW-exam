using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model3.Entities;
using System.IO;
using System.Data.SQLite;

namespace Model3
{
    public partial class MainForm : Form
    {
        private string connectionString = "Data Source=C:\\Users\\Andra\\source\\repos\\Model3\\Model3\\ProductsDatabase.db";
        public const string filePath = "C:\\Users\\Andra\\source\\repos\\Model3\\Model3\\Categories.txt";
        public List<Category> categories;
        public static List<Product> products = new List<Product>();
        public MainForm()
        {
            InitializeComponent();
            categories = LoadCategories(filePath) ?? new List<Category> ();
            LoadFromDataBase();
        }

        public List<Category> LoadCategories(string filePath)
        {
            List<Category> categories = new List<Category>();
            if(File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach(var line in lines)
                {
                    string[] parts = line.Split(',');
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    Category category = new Category(id, name);
                    categories.Add(category);
                }
            }
            return categories;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm form = new AddProductForm(categories);

            if(form.ShowDialog() == DialogResult.OK)
            {
                var product = form.product;
                products.Add(product);
                AddProductToDatabase(product);
            }
           
        }

        public void PopulateDataGridView()
        {
            dgvProducts.Rows.Clear ();
            string name = "";
            int indexRow = 0;
            foreach(var prod in products)
            {
                name = categories.Find(c=>c.Id == prod.CategoryId).Name;
                indexRow = dgvProducts.Rows.Add(prod.Id.ToString(), prod.Name, prod.Units.ToString(), 
                    prod.Price.ToString(), name);
                dgvProducts.Rows[indexRow].Tag = prod;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvProducts.SelectedRows.Count > 0)
            {
                var item = dgvProducts.SelectedRows[0];
                var prod = (Product)item.Tag;
                products.Remove(prod);
                AddProductForm form = new AddProductForm(categories, prod);
                if(form.ShowDialog() == DialogResult.OK)
                {
                    prod = form.product;

                }
                products.Add(prod);
                PopulateDataGridView();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvProducts.Rows.Count > 0)
            {
                var item = dgvProducts.SelectedRows[0];
                var prod = (Product)item.Tag;
                products.Remove(prod);
                DeleteFromDb(prod);
            }
        }

        private void totalPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double tot = 0;
            foreach(var prod in products)
            {
                tot += (double)prod;
            }
            MessageBox.Show($"Total price: {tot} $");

        }

        private void AddProductToDatabase(Product product)
        {
            string query = "INSERT INTO Products(Id, Name, Units, Price, CId) " +
                "VALUES(@Id, @Name, @Units, @Price, @CId)";
            using(SQLiteConnection  con = new SQLiteConnection(connectionString)) 
            { 
                con.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Units", product.Units);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@CId", product.CategoryId);

                    command.ExecuteNonQuery();
                }
            }
            PopulateDataGridView();
        }

        private void LoadFromDataBase()
        {
            products.Clear();
            string query = "SELECT * FROM Products";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("Id"));
                        string name = reader.GetString(reader.GetOrdinal("Name"));
                        int units = reader.GetInt32(reader.GetOrdinal("Units"));
                        double price = reader.GetDouble(reader.GetOrdinal("Price"));
                        int CId = reader.GetInt32(reader.GetOrdinal("CId"));

                        Product prod = new Product(id, name, units, price, CId);
                        products.Add(prod);
                    }
                }
            }
            PopulateDataGridView();
        }

        private void DeleteFromDb(Product product)
        {
            string query = "DELETE FROM Products WHERE Id = @Id";
            using(SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                using(SQLiteCommand command = new SQLiteCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.ExecuteNonQuery();
                }
            }
            PopulateDataGridView();
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IComparer<Product> comparer = new NameComparer();
            products.Sort(comparer);
            foreach(Product product in products)
            {
                DeleteFromDb(product);
            }
            foreach(Product product in products)
            {
                AddProductToDatabase(product);
            }
            PopulateDataGridView();
        }
    }
}
