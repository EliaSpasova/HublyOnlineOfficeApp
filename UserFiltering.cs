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

namespace HublyProject
{
    public partial class UserFiltering : Form
    {
        public User1 authenticatedUser;
        public UserFiltering()
        {
            InitializeComponent();

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensuring the click is on a valid row
            {
                // Assuming your DataGridView is set up to have the sandwich name in a specific column, adjust accordingly.
                if (guna2DataGridView1.CurrentCell.ColumnIndex.Equals(0))
                {
                    SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog= Hubly; Integrated Security=True;");
                    sqlCon.Open();
                    string name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    User1 task = DatabaseManager.RetrieveUserInformationForChats(name); //the receiver

                    CurrentUserContext.CurrentUser = task;
                    if (task != null)
                    {
                        // Display the username on Form5
                        this.Hide();
                        UserFiltering2 welcome = new UserFiltering2(task);
                        welcome.Show();

                    }
                    sqlCon.Close();
                }
            }
        }

        private void UserFiltering_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
            guna2ComboBox3.SelectedIndex = 0;
            guna2ComboBox4.SelectedIndex = 0;
        }

        private void filter_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
            {
                sqlCon.Open(); // Open SQL connection

                string baseQuery = "SELECT userID,username,age,email,role1,dateJoined,location1 FROM UserInfo WHERE 1 = 1";
                List<string> conditions = new List<string>();

                // Assuming your first item in the ComboBox is "Select" or similar and represents an unselected state.
                if (guna2ComboBox1.SelectedIndex > 0)
                {
                    conditions.Add("role1 = @role1");
                }

                // Handle age range filtering
                if (guna2ComboBox2.SelectedIndex > 0)
                {
                    string ageRange = guna2ComboBox2.SelectedItem.ToString();
                    switch (ageRange)
                    {
                        case "18-25":
                            conditions.Add("Age BETWEEN 18 AND 25");
                            break;
                        case "26-30":
                            conditions.Add("Age BETWEEN 26 AND 30");
                            break;
                        case "31-45":
                            conditions.Add("Age BETWEEN 31 AND 45");
                            break;
                        case "45+":
                            conditions.Add("Age >= 45");
                            break;
                    }
                }

                if (guna2ComboBox3.SelectedIndex > 0)
                {
                    conditions.Add("location1 = @location1");
                }

                // Handle date joined filtering
                if (guna2ComboBox4.SelectedIndex > 0)
                {
                    string registrationRange = guna2ComboBox4.SelectedItem.ToString();
                    DateTime now = DateTime.Now;
                    switch (registrationRange)
                    {
                        case "last 30 days":
                            conditions.Add("DateJoined >= @dateFromLast30Days");
                            break;
                        case "1-6 months ago":
                            conditions.Add("DateJoined >= @dateFrom6Months AND DateJoined < @dateTo6Months");
                            break;
                        case "6+ months ago":
                            conditions.Add("DateJoined < @dateFrom6MonthsAgo");
                            break;
                    }
                }

                // Append conditions to the base query if any
                if (conditions.Count > 0)
                {
                    baseQuery += " AND " + string.Join(" AND ", conditions);
                }

                SqlCommand cmd = new SqlCommand(baseQuery, sqlCon);

                // Only add parameters if the respective ComboBox is selected
                if (guna2ComboBox1.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@role1", guna2ComboBox1.SelectedItem.ToString());
                }

                // For Lettuce and Tomatoes, ensure their values are correctly mapped to "Yes" or "No"
                if (guna2ComboBox3.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@location1", guna2ComboBox3.SelectedItem.ToString());
                }

                // Add parameters for the date filters
                DateTime nowForParams = DateTime.Now;
                if (guna2ComboBox4.SelectedIndex > 0)
                {
                    string registrationRange = guna2ComboBox4.SelectedItem.ToString();
                    switch (registrationRange)
                    {
                        case "last 30 days":
                            cmd.Parameters.AddWithValue("@dateFromLast30Days", nowForParams.AddDays(-30));
                            break;
                        case "1-6 months ago":
                            cmd.Parameters.AddWithValue("@dateFrom6Months", nowForParams.AddMonths(-6));
                            cmd.Parameters.AddWithValue("@dateTo6Months", nowForParams.AddMonths(-1));
                            break;
                        case "6+ months ago":
                            cmd.Parameters.AddWithValue("@dateFrom6MonthsAgo", nowForParams.AddMonths(-6));
                            break;
                    }
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    guna2DataGridView1.DataSource = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                }
            }
        }
    }
}
