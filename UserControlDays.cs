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
    public partial class UserControlDays : UserControl
    {
        public static string static_day;
        public User1 authenticatedUser;
        public Event currEvent;
        public UserControlDays(User1 user)
        {
            InitializeComponent();
            authenticatedUser = user;
            currEvent = new Event();
            
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            displayEvent();
            
        }

        public void days(int numdays)
        {
            label1.Text = numdays + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = label1.Text;
            timer1.Start();
            if (button1.Text != string.Empty)
            {
                MessageBox.Show("There's is already an event here. Try another day");
            }
            else
            {
                AddEvent form = new AddEvent(authenticatedUser);
                form.ShowDialog();
            }
        }


        public void displayEvent() //usercontrol load?
        {
          
            SqlConnection conn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog= Hubly; Integrated Security=True;");
            conn.Open();
            string sql = "select * from Event1 where eventDate = @date";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@date", HublyProject.Events.static_year + "-" + HublyProject.Events.static_month + "-" + label1.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                    
                //do it here
                currEvent.Title = reader["title"].ToString();
                currEvent.Description = reader["descriptionOfEvent"].ToString();
                currEvent.eventDate = Convert.ToDateTime(reader["eventDate"].ToString());
                currEvent.Location = reader["locationOfEvent"].ToString();
                currEvent.Privacy = reader["privacy"].ToString();
                currEvent.userID = Convert.ToInt32(reader["userID"].ToString());
            }
            if (currEvent == null)
            {

            }
            else if (currEvent.Privacy == "public")
            {
                button1.Text = currEvent.Title;
            }
            else if (currEvent.Privacy == "private" && currEvent.userID != authenticatedUser.userID)
            {
                button1.Text = "";
                currEvent = null;
            }
            else if(currEvent.Privacy == "private" && currEvent.userID == authenticatedUser.userID)
            {
                button1.Text = currEvent.Title;
            }

            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ako e null ili empty -> no event available
            if (button1.Text == string.Empty)
            {
                MessageBox.Show("No event here");
            }
            else
            {
                EventInfo eventInfo = new EventInfo(currEvent, authenticatedUser, this);
                eventInfo.ShowDialog();
            }
        }

        internal void ClearEventInfo()
        {
            currEvent = null;
            button1.Text = "";
        }
    }
}
