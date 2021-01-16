using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Had
{
    class CastHada : IDrawable
    {
        protected Point pozice;
        protected Brush barva = new SolidBrush(Color.Red);
        protected int velikost = 20;

        public Point Pozice
        {
            get { return pozice; }
        }


        public CastHada(int x, int y)
        {
            pozice = new Point(x, y);
        }

        public virtual void VykresliSe(Graphics g)
        {
            g.FillRectangle(barva,
               pozice.X * velikost,
               pozice.Y * velikost,
               velikost,
               velikost
               );
        }

    }
}
