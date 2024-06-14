using Model2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Model2
{
    public partial class AddParticipantForm : Form
    {
        public Participant participant;
        public List<string> concerts;
        public AddParticipantForm(List<string> concerts, Participant participant = null)
        {
            InitializeComponent();

            foreach(var concert in concerts)
            {
                clbConcerts.Items.Add(concert);
            }
            nudId.Validating += nudId_Validating;
            tbName.Validating += tbName_Validating;
            tbEmail.Validating += tbEmail_Validating;
            dtpBirth.Validating += dtpBirth_Validating;
            clbConcerts.Validating += clbConcerts_Validating;

            if(participant != null)
            {
                nudId.Value = participant.Id;
                tbName.Text = participant.Name;
                tbEmail.Text = participant.Email;
                dtpBirth.Value = participant.BirthDate;
                foreach(var concert in participant.concerts)
                {
                    for(int i = 0; i < clbConcerts.Items.Count; i++)
                    {
                        if (concert.Equals(clbConcerts.Items[i])) ;
                        clbConcerts.SetItemChecked(i, true);
                    }
                }
                
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = (int)nudId.Value;
            string name = tbName.Text;
            string email = tbEmail.Text;
            DateTime date = dtpBirth.Value;
            List<string> list = new List<string>();
            foreach(var item in clbConcerts.CheckedItems)
            {
                list.Add(item.ToString());
            }
            participant = new Participant(id, name, email, date, list);
        }

        private void nudId_Validating(object sender, CancelEventArgs e)
        {
            int val = 0;
            foreach(var part in MainForm.participants)
            {
                if(nudId.Value == part.Id)
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
            }
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbName, "Name can not be empty");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            bool val = true;
            try
            {
                var addr = new MailAddress(tbEmail.Text);
                
            } catch (Exception ex)
            {
                val = false;
            }
            
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Email can not be empty");
            }
            else if (val == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Invalid email");
            }
            else
            {
                e.Cancel= false;
            }
        }

        private void dtpBirth_Validating(object sender, CancelEventArgs e)
        {
            if (dtpBirth.Value > new DateTime(2012, 6, 14))
            {
                e.Cancel = true;
                errorProvider1.SetError(dtpBirth, "The participant must be at least 12 years old");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void clbConcerts_Validating(object sender, CancelEventArgs e)
        {
            if(clbConcerts.CheckedItems.Count <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(clbConcerts, "Please select one or more concerts");
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
