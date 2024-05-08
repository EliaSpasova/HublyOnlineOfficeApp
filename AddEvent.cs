using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static HublyProject.authenticate;

namespace HublyProject
{
    public partial class AddEvent : Form
    {
        public User1 authenticatedUser;
        public Event currEvent;
        public AddEvent(User1 user)
        {
            InitializeComponent();
            authenticatedUser = user;
            currEvent = new Event();
        }

        private void AddEvent_Load(object sender, EventArgs e)
        {
            //date.Text = HublyProject.Events.static_month + "-" + UserControlDays.static_day + "-" + HublyProject.Events.static_year;
            date.Text = HublyProject.Events.static_year + "-" + HublyProject.Events.static_month + "-" + UserControlDays.static_day;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(titleOfEvent.Text) || string.IsNullOrEmpty(description.Text) ||
       string.IsNullOrEmpty(date.Text) || string.IsNullOrEmpty(location.Text) ||
       string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog= Hubly; Integrated Security=True;"))
                {
                    conn.Open();
                    string query = "Insert into Event1 (title, descriptionOfEvent, eventDate, locationOfEvent, userID, privacy) values (@title,@descriptionOfEvent, @eventDate, @locationOfEvent, @userID, @privacy)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", titleOfEvent.Text);
                        cmd.Parameters.AddWithValue("@descriptionOfEvent", description.Text);
                        cmd.Parameters.AddWithValue("@eventDate", date.Text);
                        cmd.Parameters.AddWithValue("@locationOfEvent", location.Text);
                        cmd.Parameters.AddWithValue("@userID", authenticatedUser.userID.ToString());
                        if (textBox1.Text == "private" || textBox1.Text == "public")
                        {

                            cmd.Parameters.AddWithValue("@privacy", textBox1.Text);
                        }
                        else
                        {
                            MessageBox.Show("Please write \"public/private\" in the box", "Error", MessageBoxButtons.OK);
                        }
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Event saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        currEvent.Title = titleOfEvent.Text;
                        currEvent.Description = description.Text;
                        currEvent.Location = location.Text;
                        currEvent.eventDate = Convert.ToDateTime(date.Text);
                        currEvent.userID = authenticatedUser.userID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the event: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
