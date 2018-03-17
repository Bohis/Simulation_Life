using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace VisualSimulationLife {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			greaf();
		}
		public void greaf() {
			Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Graphics h = Graphics.FromImage(bmp);
			Pen pen = new Pen(Color.Blue);
			Point point = new Point(10,10);
			Rectangle s = new Rectangle(2,2,7,7);
			Rectangle g = new Rectangle(12, 12, 7, 7);
			Brush f = Brushes.Black;
			h.FillRectangle(f,s);
			h.FillRectangle(f, g);

			//h.DrawRectangle(pen,1,1,100,100);
			h.DrawLine(pen,0,0,0,200);
			h.DrawLine(pen, 10, 0, 10, 200);
			h.DrawLine(pen, 20, 0, 20, 200);

			h.DrawLine(pen, 0, 0, 200, 0);
			h.DrawLine(pen, 0, 10, 200, 10);


			pictureBox1.Image = bmp;
		}
	}
}
