using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Had
{
    public partial class Form1 : Form
    {
        Had had;

        public Form1()
        {
            InitializeComponent();
            int x = (canvas.Width / 20) / 2;
            int y = (canvas.Height / 20) / 2;
            had = new Had(x, y, canvas.Width / 20, canvas.Height / 20);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            had.VykresliSe(e.Graphics);
        }
    }
}
