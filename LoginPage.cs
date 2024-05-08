using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HublyProject.authenticate;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace HublyProject
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string user = usernameTextBox.Text;
            string pass = guna2TextBox1.Text;
            if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(pass))
            {
                // AuthenticateUser now returns a bool
                bool isAuthenticated = DatabaseManager.AuthenticateUser(user, pass);

                if (isAuthenticated)
                {
                    // Directly get the singleton User1 instance
                    User1 authenticatedUser = User1.GetInstance();

                    DashboardAdministrator window = new DashboardAdministrator(authenticatedUser);
                    this.Hide();
                    window.ShowDialog();



                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
