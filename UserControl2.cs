using Guna.UI2.WinForms;
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

namespace HublyProject
{
    public partial class UserControl2 : UserControl
    {
        public User1 userReceiver;
        public UserControl2(User1 user)
        {
            InitializeComponent();
            userReceiver = user;
            try
            {
                byte[] pictute = imageUploader.GetUserProfilePicture(userReceiver.Username);
                pictureBox1.Image = imageUploader.ByteArrayToImage(pictute);
            }
            catch (Exception e) { Console.WriteLine("No profile pic"); }





        }
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; richTextBox1.Text = value; }

        }
        private Image _icon;
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; AddHeight(); }
        }
        void AddHeight()
        {
            UserControl2 userControl1 = new UserControl2(userReceiver);
            userControl1.BringToFront();
            richTextBox1.Height = Uilist.GetTextHeight(richTextBox1) + 10;
            userControl1.Height = richTextBox1.Top + richTextBox1.Height;
            this.Height = userControl1.Bottom + 10;
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            AddHeight();
            richTextBox1.Text = Text;
        }
    }
}
