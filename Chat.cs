using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HublyProject.authenticate;

namespace HublyProject
{
    public partial class Chat : Form
    {
        public User1 userSender;
        public User1 userReceiver;
        public Chat(User1 userLogged, User1 userReceiver1)
        {

            userSender = userLogged;
            userReceiver = userReceiver1;
            InitializeComponent();
            nameOfReceiver.Text = userReceiver.Username;


        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            if (guna2TextBox1.Text == null)
            {
                MessageBox.Show("Type something and then send!", "Send a message", MessageBoxButtons.OK);
            }


            using (SqlConnection conn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog= Hubly; Integrated Security=True;"))
            {
                conn.Open();

                string query = "Insert into Chat (userReceiver, userSender, message1) values (@userReceiver,@userSender, @message1)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userReceiver", userReceiver.userID);
                cmd.Parameters.AddWithValue("@userSender", userSender.userID);
                cmd.Parameters.AddWithValue("@message1", guna2TextBox1.Text);
                cmd.ExecuteNonQuery();

                //create the messsage bubble
                MessageChat();
                guna2TextBox1.Clear();

            }

        }
        private void MessageChat()
        {
            flowLayoutPanel1.Controls.Clear();
            userControl11.Visible = true;
            userControl22.Visible = true;
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Chat ORDER BY messageID ASC", @"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog= Hubly; Integrated Security=True;");
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {


                    UserControl1[] userControl2s = new UserControl1[dt.Rows.Count];
                    UserControl2[] userControl3s = new UserControl2[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (userReceiver.userID == (int)row["userReceiver"] && userSender.userID == (int)row["userSender"])
                            {
                                userControl2s[i] = new UserControl1();
                                userControl2s[i].Dock = DockStyle.Top;
                                userControl2s[i].BringToFront();
                                userControl2s[i].Text = row["message1"].ToString();

                                flowLayoutPanel1.Controls.Add(userControl2s[i]);
                                flowLayoutPanel1.ScrollControlIntoView(userControl2s[i]);
                            }
                            else if (userSender.userID == (int)row["userReceiver"] && userReceiver.userID == (int)row["userSender"]) //smenqsh labels
                            {
                                userControl3s[i] = new UserControl2(userReceiver);
                                userControl3s[i].Dock = DockStyle.Top;
                                userControl3s[i].BringToFront();
                                userControl3s[i].Text = row["message1"].ToString();
                                userControl3s[i].Icon = guna2CirclePictureBox1.Image;

                                flowLayoutPanel1.Controls.Add(userControl3s[i]);
                                flowLayoutPanel1.ScrollControlIntoView(userControl3s[i]);

                            }
                        }
                    }
                }

            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardAdministrator dashboardAdministrator = new DashboardAdministrator(userSender);
            dashboardAdministrator.Show();

        }

        private void Chat_Load(object sender, EventArgs e)
        {
            byte[] img = imageUploader.GetUserProfilePicture(userReceiver.Username);
            userReceiver.Picture = img;
            if (userReceiver.Picture != null && userReceiver.Picture.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(userReceiver.Picture))
                {
                    guna2CirclePictureBox1.Image = Image.FromStream(ms);
                }
            }
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (5000); //5 sec instead of 10
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            MessageChat();
            //50:27 za snimka



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageChat();
        }

    }
}
