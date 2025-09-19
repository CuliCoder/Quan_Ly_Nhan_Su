using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace Quan_Ly_Nhan_Su.config
{
    internal class design
    {
        public static void paintBorder(Panel pn ,Color color,float width, int x1,int y1,int x2,int y2 )
        {
            pn.Paint += (Object sender, PaintEventArgs e) =>
            {
                Pen pen = new Pen(color, width);
                e.Graphics.DrawLine(pen,new Point(x1,y1), new Point(x2,y2));
            };
        }
    }
}
