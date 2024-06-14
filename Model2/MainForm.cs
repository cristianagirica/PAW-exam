using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Model2.Entities;
using System.Data.SQLite;
using static System.Net.Mime.MediaTypeNames;

namespace Model2
{
    public partial class MainForm : Form
    {
        public static string connectionString = "Data Source=C:\\Users\\Andra\\source\\repos\\Model2\\Model2\\DataBase.db";
        public static List<string> concerts;
        public static List<Participant> participants = new List<Participant>();
        public const string filePath = "C:\\Users\\Andra\\source\\repos\\Model2\\Model2\\Resources\\Concerts.txt";
        public MainForm()
        {
            InitializeComponent();
            concerts = ReadConcertList(filePath);
            LoadFromDataBase();
        }
        #region Read Concerts from Text File
        private List<string> ReadConcertList(string filePath)
        {
            List<string> conc = new List<string>();
            if(File.Exists(filePath)) 
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    conc.Add(line);
                }
            }
            return conc;
        }
        #endregion
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            AddParticipantForm form = new AddParticipantForm(concerts);

            if(form.ShowDialog() == DialogResult.OK)
            {
                Participant participant = form.participant;
                participants.Add(participant);
                AddToDataBase(participant);
            }
        }

        private void PopulateGridView()
        {
            dgvParticipants.Rows.Clear();
            
            int indexRow = 0;
            foreach (var participant in participants)
            {
                string list = "";
                foreach (var conc in participant.concerts)
                {
                    list += conc.ToString() + ", ";
                }
                if (list.EndsWith(", "))
                {
                    list = list.Substring(0, list.Length - 2);
                }
                indexRow = dgvParticipants.Rows.Add(participant.Id.ToString(), 
                    participant.Name, participant.Email, participant.BirthDate.ToString(), list);
                dgvParticipants.Rows[indexRow].Tag = participant;
            }
        }

        private void dgvParticipants_DoubleClick(object sender, EventArgs e)
        {
            if(dgvParticipants.SelectedRows.Count > 0)
            {
                var item = dgvParticipants.SelectedRows[0];
                var participant = (Participant)item.Tag;
                AddParticipantForm form = new AddParticipantForm(concerts, participant);
                participants.Remove(participant);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    participant = form.participant;
                    participants.Add(participant);
                    PopulateGridView();
                } else
                {
                    participants.Add(participant);
                }
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvParticipants.SelectedRows.Count > 0)
            {
                var item = dgvParticipants.SelectedRows[0];
                var participant = (Participant)item.Tag;
                participants.Remove(participant);
                DeleteFromDataBase(participant);
            }
        }

        private void btnParticipants_Click(object sender, EventArgs e)
        {
            int tot = 0;
            foreach( var participant in participants)
            {
                tot += (int)participant;
            }
            tbParticipants.Text = tot.ToString();
        }

        #region Data Base

        public void AddToDataBase(Participant participant)
        {
            string list = "";
            foreach (var concert in participant.concerts)
            {
                list += concert.ToString() + ", ";
            }
            if (list.EndsWith(", "))
            {
                list = list.Substring(0, list.Length - 2);
            }
            string query = "INSERT INTO Participants(Id, Name, Email, [Birth Date], Concerts) " +
                "VALUES (@Id, @Name, @Email, @Date, @Concerts)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@Id", participant.Id);
                        command.Parameters.AddWithValue("@Name", participant.Name);
                        command.Parameters.AddWithValue("@Email", participant.Email);
                        command.Parameters.AddWithValue("@Date", participant.BirthDate);
                        command.Parameters.AddWithValue("@Concerts", list);

                        command.ExecuteNonQuery();
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }

            }
            PopulateGridView();
        }

        public void LoadFromDataBase()
        {
            participants.Clear();
            string query = "SELECT * FROM Participants";

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
                        string email = reader.GetString(reader.GetOrdinal("Email"));
                        DateTime date = reader.GetDateTime(reader.GetOrdinal("Birth Date"));
                        string list = reader.GetString(reader.GetOrdinal("Concerts"));
                        List<string> conc = new List<string>();
                        string separator = ", ";
                        string[] parts = list.Split(new string[] { separator }, StringSplitOptions.None);
                        foreach (string part in parts)
                        {
                            conc.Add(part);
                        }
                        participants.Add(new Participant(id, name, email, date, conc));
                    }
                }
            }
            PopulateGridView();
        }

        public void DeleteFromDataBase(Participant participant)
        {
            string query = "DELETE FROM Participants WHERE Id = @Id";
            using(SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", participant.Id);
                cmd.ExecuteNonQuery();
            }
            PopulateGridView();
        }
        #endregion

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            IComparer<Participant> comparer = null;
            switch (cbSort.SelectedIndex)
            {
                case 0:
                    comparer = new NameComparer(); 
                    break;
                case 1:
                    comparer = new DateComparer();
                    break;
            }
            participants.Sort(comparer);
            PopulateGridView();
        }

        private void saveTextReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Text Report";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    using(StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach(Participant participant in participants)
                        {
                            writer.WriteLine($"Id: {participant.Id}");
                            writer.WriteLine($"Name: {participant.Name}");
                            writer.WriteLine($"Email: {participant.Email}");
                            writer.WriteLine($"Birth Date: {participant.BirthDate.ToShortDateString()}");
                            writer.WriteLine("Concerts: " + string.Join(", ", participant.concerts));
                            writer.WriteLine();
                        }
                        MessageBox.Show("File saved successfully");
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("An error occured in saving the files");
                }
        }

        
    }
}
