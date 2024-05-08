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
    public partial class UserFiltering2 : Form
    {
        public User1 selectedUser;
        public UserFiltering2(User1 user)
        {
            InitializeComponent();
            selectedUser = user;
            guna2TextBox1.Text = selectedUser.Username;
            guna2TextBox2.Text = selectedUser.Age.ToString();
            guna2TextBox3.Text = selectedUser.Location.ToString();
            guna2ComboBox1.Text = selectedUser.Role.ToString();
        }

        private void UserFiltering2_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            //update event
            try
            {
                // Update the note's text in the application's memory
                selectedUser.Username = guna2TextBox1.Text;

                using (SqlConnection conn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
                {
                    conn.Open();

                    string query = "UPDATE UserInfo SET location1 = @text, role1=@role1 WHERE username = @title";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@text", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("@title", selectedUser.Username);
                        cmd.Parameters.AddWithValue("@role1", guna2ComboBox1.SelectedItem.ToString()); //check it

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("The user has been updated successfully!", "Update", MessageBoxButtons.OK);
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the note: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
