using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HublyProject.authenticate;

namespace HublyProject
{
    public partial class Events : Form
    {
        public User1 authenticatedUser;
        int month, year;

        public static int static_month, static_year;
        public Events(User1 user)
        {
            InitializeComponent();
            authenticatedUser = user;
            
        }

        private void Events_Load(object sender, EventArgs e)
        {
            displayDays();
        }
        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            //first day of the month
            DateTime startOfMonth = new DateTime(year, month, 1);

            //get the count of days of the month
            int days = DateTime.DaysInMonth(year, month);
            //convert the startofmonth to integer
            int daysOfTheWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;

            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            label8.Text = monthname + " " + year;
            static_month = month;
            static_year = year;
            //blank usercontrol
            for (int i = 1; i < daysOfTheWeek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                dayContainer.Controls.Add(ucblank);
            }


            //user control for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays(authenticatedUser);
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);

            }
        }

        private void nxtButton_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();
            month++;
            if (month == 13)
            {
                month = 1;
                year++;
            }
            static_month = month;
            static_year = year;

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            label8.Text = monthName + " " + year;
            int dayoftheweek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                dayContainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays(authenticatedUser);
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);
            }
        }

        private void prvsButton_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();
            month--;
            if (month == 0)
            {
                month = 12;
                year--;
            }
            static_month = month;
            static_year = year;
            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            label8.Text = monthName + " " + year;
            int dayoftheweek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                dayContainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays(authenticatedUser);
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardAdministrator d = new DashboardAdministrator(authenticatedUser);
            d.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayDays();
        }
    }
}
