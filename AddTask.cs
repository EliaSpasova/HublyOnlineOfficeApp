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
    public partial class AddTask : Form
    {
        public User1 AuthenticatedUser;
        public AddTask(User1 user)
        {
            InitializeComponent();
            AuthenticatedUser = user;
            guna2DateTimePicker1.Value = DateTime.Now;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string title = guna2TextBox1.Text.Trim();
            string assignedToUsername = guna2TextBox2.Text.Trim(); // Now expects a username
            string description = guna2TextBox3.Text.Trim();
            DateTime deadline = guna2DateTimePicker1.Value;

            if (title == "" || assignedToUsername == "" || description == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
                {
                    sqlCon.Open();

                    // Query to get the user ID from the username
                    string userIdQuery = "SELECT UserID FROM UserInfo WHERE username = @Username";
                    SqlCommand userIdCmd = new SqlCommand(userIdQuery, sqlCon);
                    userIdCmd.Parameters.AddWithValue("@Username", assignedToUsername);
                    object result = userIdCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Assigned user does not exist.");
                        return;
                    }
                    int assignedToUserId = Convert.ToInt32(result);

                    // Insert the new task
                    string query = @"
                INSERT INTO Tasks (AssignedToUserID, CreatedByUserID, Title, descriptionOfTask, statusOfTask, deadline)
                VALUES (@AssignedToUserID, @CreatedByUserID, @Title, @Description, 'incomplete', @Deadline)";

                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@AssignedToUserID", assignedToUserId);
                        cmd.Parameters.AddWithValue("@CreatedByUserID", AuthenticatedUser.userID);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Deadline", deadline);
                        cmd.Parameters.AddWithValue(@"Title", guna2TextBox1.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Task added successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding task: " + ex.Message);
            }
            DashboardAdministrator administrator = new DashboardAdministrator(AuthenticatedUser);
            administrator.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
            DashboardAdministrator adas = new DashboardAdministrator(AuthenticatedUser);
            adas.Show();
        }
    }
}
