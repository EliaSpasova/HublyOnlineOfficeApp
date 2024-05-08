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
    public partial class Task : Form
    {
        public currentTask currentTask;
        public User1 authenticatedUser;
        public Task(currentTask CurrentTask, User1 user)
        {
            InitializeComponent();
            currentTask = CurrentTask;
            Title.Text = currentTask.Title;
            DescriptionTask.Text = currentTask.descriptionOfTask;
            Deadline.Text = "Deadline:" + currentTask.deadline.ToString();
            status.Text = currentTask.statusOfTask;

            this.authenticatedUser = user;

        }

        private void guna2Button1_Click(object sender, EventArgs e) //completed
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
            {
                conn.Open();

                string query = "UPDATE Tasks SET statusOfTask = @text WHERE taskID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@text", "completed");
                    cmd.Parameters.AddWithValue("@id", currentTask.ID);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("The note has been updated successfully!", "Update", MessageBoxButtons.OK);
            }

            this.Hide();
            DashboardAdministrator newS = new DashboardAdministrator(authenticatedUser);
            newS.Show();

        }

        private void guna2Button2_Click(object sender, EventArgs e) //back
        {
            this.Hide();
            DashboardAdministrator newS = new DashboardAdministrator(authenticatedUser);
            newS.Show();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this task?",
                                        "Confirm Delete!",
                                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
                    {
                        sqlCon.Open();
                        string query = "DELETE FROM Tasks WHERE Title = @TaskID";
                        using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                        {
                            // Assuming you have stored taskID in a hidden label or passed it to the form in some way
                            cmd.Parameters.AddWithValue("@TaskID", Title.Text); // Replace `labelTaskID.Text` with your task ID variable

                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Task deleted successfully.");
                                this.Close(); // Close the form, or navigate back to the task list
                            }
                            else
                            {
                                MessageBox.Show("Task not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting task: " + ex.Message);
                }
            }
            DashboardAdministrator administrator = new DashboardAdministrator(authenticatedUser);
            administrator.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
