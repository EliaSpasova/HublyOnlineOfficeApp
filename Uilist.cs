using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HublyProject
{
    internal class Uilist
    {
        public static int GetTextHeight(RichTextBox label1)
        {
            using(Graphics g = label1.CreateGraphics())
            {
                SizeF size = g.MeasureString(label1.Text, label1.Font, 495);
                return (int)Math.Ceiling(size.Height);
            }
        }
    }
}
