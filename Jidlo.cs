using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Had
{
    class Jidlo : IDrawable
    {
        protected int velikost = 20;
        private Brush barva;
        protected Point pozice;

        public Point Pozice
        {
            get { return pozice; }
        }

        public Jidlo(int x, int y)
        {
            pozice = new Point(x, y);
            barva = new SolidBrush(Color.GreenYellow);
        }

        public virtual void VykresliSe(Graphics g)
        {
            g.FillRectangle(barva, pozice.X * velikost, pozice.Y * velikost, velikost, velikost);
        }
    }
}
