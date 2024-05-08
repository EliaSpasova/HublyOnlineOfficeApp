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
using static HublyProject.authenticate;

namespace HublyProject
{
    public partial class EventInfo : Form
    {
        public Event currentEvent;
        public User1 authenticatedUser;
        private UserControlDays userControlDays; // Add this field
        public EventInfo(Event currEvent, User1 user, UserControlDays userControlDays)
        {
            InitializeComponent();
            currentEvent = currEvent;
            authenticatedUser = user;

            if (currentEvent.userID == authenticatedUser.userID)
            {
                guna2Button1.Visible = true;
                guna2Button2.Visible = true;
            }

            this.userControlDays = userControlDays;
            title.Text = currentEvent.Title;
            guna2TextBox1.Text = currentEvent.Description;
            label1.Text = currentEvent.Location;
            date.Text = currentEvent.eventDate.ToString();

        }

        private void EventInfo_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //delete event
            SqlConnection conn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;");
            conn.Open();
            string query = "DELETE FROM Event1 WHERE title ='" + currentEvent.Title + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("You successfully deleted this note!", "Deletion", MessageBoxButtons.OK);
            conn.Close();

            this.userControlDays.ClearEventInfo(); //NOOOOOOOO
            this.Hide();


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //update event
            try
            {
                // Update the note's text in the application's memory
                currentEvent.Description = guna2TextBox1.Text;

                using (SqlConnection conn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
                {
                    conn.Open();

                    string query = "UPDATE Event1 SET descriptionOfEvent = @text WHERE title = @title";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@text", guna2TextBox1.Text);
                        cmd.Parameters.AddWithValue("@title", currentEvent.Title);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("The note has been updated successfully!", "Update", MessageBoxButtons.OK);
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the note: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Events events = new Events(authenticatedUser);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
