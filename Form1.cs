using Guna.UI2.WinForms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HublyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void usernameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (usernameTextBox.Text.Length < 5)
            {
                MessageBox.Show("Username must be more than 5 characters.", "error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                usernameTextBox.SelectAll();
                e.Cancel = true;
            }
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        private void guna2TextBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (guna2TextBox3.Text != string.Empty)
            {
                if (!IsValidEmail(guna2TextBox3.Text))
                {
                    MessageBox.Show("email is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox3.Focus();
                    e.Cancel = true;
                }
            }
        }

        private void passwordTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void guna2DateTimePicker1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int age = DateTime.Now.Year - guna2DateTimePicker1.Value.Year - (DateTime.Now.DayOfYear < guna2DateTimePicker1.Value.DayOfYear ? 1 : 0);
            if (age < 18)
            {
                MessageBox.Show("age should be 18 years old.", "title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            lengthPass.Show();
            capitalPass.Show();
            numPass.Show();

            if (passwordTextBox.Text.Any(char.IsUpper))
            {
                capitalPass.ForeColor = Color.Green;
            }
            else
            {
                capitalPass.ForeColor = Color.Red;
            }

            if (passwordTextBox.Text.Any(char.IsNumber))
            {
                numPass.ForeColor = Color.Green;
            }
            else
            {
                numPass.ForeColor = Color.Red;
            }

            if (passwordTextBox.Text.Length > 8)
            {
                lengthPass.ForeColor = Color.Green;
            }
            else
            {
                lengthPass.ForeColor = Color.Red;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var dateAndTimeOfClick = System.DateTime.Now;
            using (SqlConnection cn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
            {


                cn.Open();

                if (passwordTextBox.Text != string.Empty)
                {
                    SqlCommand cmd = new SqlCommand("select * from UserInfo where username='" + usernameTextBox.Text + "'", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username already exist please try another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into userInfo (username,password1, email, age, role1,profilePic, dateJoined,location1) values(@username,@password,@email,@age, @role, NULLIF(CONVERT(varbinary(max),@img), ''), @dateJoined, @location1)", cn);
                        cmd.Parameters.AddWithValue("username", usernameTextBox.Text);
                        cmd.Parameters.AddWithValue("email", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("password", passwordTextBox.Text);
                        int age = DateTime.Now.Year - guna2DateTimePicker1.Value.Year - (DateTime.Now.DayOfYear < guna2DateTimePicker1.Value.DayOfYear ? 1 : 0);
                        cmd.Parameters.AddWithValue("age", age);
                        cmd.Parameters.AddWithValue("dateJoined", dateAndTimeOfClick);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            cmd.Parameters.AddWithValue("role", "administrator");
                        }
                        else if (comboBox1.SelectedIndex == 1)
                        {
                            cmd.Parameters.AddWithValue("role", "employee");
                        }
                        cmd.Parameters.AddWithValue("@img", "");
                        cmd.Parameters.AddWithValue("@location1", guna2TextBox1.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Your account is created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        LoginPage form2 = new LoginPage();
                        form2.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Please fill in the password box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
        }
    }
}