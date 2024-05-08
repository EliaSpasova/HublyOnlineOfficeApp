using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HublyProject
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; richTextBox1.Text = value; }

        }
        void AddHeight()
        {
            UserControl1 userControl1 = new UserControl1();
            userControl1.BringToFront();
            richTextBox1.Height = Uilist.GetTextHeight(richTextBox1) + 10;
            userControl1.Height = richTextBox1.Top + richTextBox1.Height;
            this.Height = userControl1.Bottom + 10;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Text;
            AddHeight();
        }
    }
}
