using Microsoft.VisualBasic.ApplicationServices;
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
using static HublyProject.imageUploader;

namespace HublyProject
{
    public partial class Settings : Form
    {
        public User1 authenticatedUser;
        public Settings(User1 user)
        {
            InitializeComponent();
            authenticatedUser = user;
            byte[] pictute = imageUploader.GetUserProfilePicture(authenticatedUser.Username);
            guna2CirclePictureBox1.Image = imageUploader.ByteArrayToImage(pictute);
            guna2TextBox1.Text = authenticatedUser.Location;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedImagePath = ofd.FileName;
                    Image selectedImage = Image.FromFile(selectedImagePath);
                    byte[] imageData = ImageToByteArray(selectedImage);

                    UploadImage(authenticatedUser.Username, imageData);
                    guna2CirclePictureBox1.Image = selectedImage;
                    authenticatedUser.PictureImage = selectedImage;
                    authenticatedUser.Picture = imageData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error uploading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardAdministrator adm = new DashboardAdministrator(authenticatedUser);
            adm.Show();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Update the note's text in the application's memory
                authenticatedUser.Location = guna2TextBox1.Text;

                using (SqlConnection conn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
                {
                    conn.Open();

                    string query = "UPDATE UserInfo SET location1 = @text WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@text", authenticatedUser.Location);
                        cmd.Parameters.AddWithValue("@username", authenticatedUser.Username);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("The note has been updated successfully!", "Update", MessageBoxButtons.OK);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the note: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
