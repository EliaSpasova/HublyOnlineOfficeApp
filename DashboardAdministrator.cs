using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HublyProject.authenticate;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HublyProject
{
    public partial class DashboardAdministrator : Form
    {
        public User1 authenticatedUser;
        public DashboardAdministrator(authenticate.User1 user)
        {
            InitializeComponent();
            this.authenticatedUser = user;
            guna2DataGridView1.RowTemplate.Height = 30;
            welcomeLabel.Text = $"Welcome, {authenticatedUser.Username}!";
            guna2HtmlLabel3.Text = $"{authenticatedUser.Username}";


            guna2DataGridView1.AutoGenerateColumns = true;

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
            {
                sqlCon.Open(); // Open SQL connection

                string baseQuery = $"SELECT Title,CreatedByUserID,statusOfTask,deadline FROM Tasks WHERE AssignedToUserID = {authenticatedUser.userID}";
                //Title,AssignedToUserID,CreatedByUserID,statusOfTask,deadline
                SqlCommand cmd = new SqlCommand(baseQuery, sqlCon);

                string chatsQuery = "SELECT Username from UserInfo";
                SqlCommand cmd2 = new SqlCommand(chatsQuery, sqlCon);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    adapter.Fill(ds);
                    guna2DataGridView1.DataSource = ds;
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd2))
                {
                    DataTable ds = new DataTable();
                    adapter.Fill(ds);
                    chatsGrid.DataSource = ds;
                }

            }

            byte[] pictute = imageUploader.GetUserProfilePicture(authenticatedUser.Username);
            guna2CirclePictureBox1.Image = imageUploader.ByteArrayToImage(pictute);

            if (authenticatedUser.Role == "administrator")
            {

            }
            else if (authenticatedUser.Role == "employee")
            {
                guna2Button3.Visible = false;
                guna2PictureBox4.Visible = false;
            }
        }

        private void ViewTasksButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            //add a task
            AddTask task = new AddTask(authenticatedUser);
            task.Show();

        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if assigned to user id = userID query
            //since the table Tasks is for all tasks - we will use a query to extract only the tasks assigned to the signed user


            //and when y0u click - open description etc...
            if (e.RowIndex >= 0) // Ensuring the click is on a valid row
            {
                // Assuming your DataGridView is set up to have the sandwich name in a specific column, adjust accordingly.
                if (guna2DataGridView1.CurrentCell.ColumnIndex.Equals(0))
                {
                    SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog= Hubly; Integrated Security=True;");
                    sqlCon.Open();
                    string name = guna2DataGridView1.CurrentCell.Value.ToString();
                    currentTask task = DatabaseManagerForTask.cuurentTaskMethod(name);

                    CurrentTaskContext.CurrentTask = task;
                    if (task != null)
                    {
                        // Display the username on Form5
                        this.Hide();
                        Task welcome = new Task(task, authenticatedUser);
                        welcome.Show();

                    }
                    sqlCon.Close();
                }
            }
        }

        private void chatsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //click on chat

            if (e.RowIndex >= 0) // Ensuring the click is on a valid row
            {
                // Assuming your DataGridView is set up to have the sandwich name in a specific column, adjust accordingly.
                if (chatsGrid.CurrentCell.ColumnIndex.Equals(0))
                {
                    SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog= Hubly; Integrated Security=True;");
                    sqlCon.Open();
                    string name = chatsGrid.CurrentCell.Value.ToString();
                    User1 task = DatabaseManager.RetrieveUserInformationForChats(name); //the receiver

                    CurrentUserContext.CurrentUser = task;
                    if (task != null)
                    {
                        // Display the username on Form5
                        this.Hide();
                        Chat welcome = new Chat(authenticatedUser, task);
                        welcome.Show();

                    }
                    sqlCon.Close();
                }
            }

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //calendar button
            Events event1 = new Events(authenticatedUser);
            event1.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            //administrator button
            UserFiltering user = new UserFiltering();

            user.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings(authenticatedUser);
            settings.ShowDialog();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void DashboardAdministrator_Load(object sender, EventArgs e)
        {

            if (authenticatedUser.Picture != null && authenticatedUser.Picture.Length > 0)
            {
                /* using (MemoryStream ms = new MemoryStream(authenticatedUser.Picture))
                 {
                     guna2CirclePictureBox1.Image = Image.FromStream(ms);
                 }
                */
                guna2CirclePictureBox1.Image = authenticatedUser.PictureImage;
            }
        }
    }
}
