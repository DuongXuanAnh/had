using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Had
{
    class BonusoveJidlo : Jidlo
    {
        public BonusoveJidlo(int x, int y) : base(x, y)
        {
        }

        public override void VykresliSe(Graphics g)
        {
            g.FillEllipse(Brushes.BlueViolet, pozice.X * velikost, pozice.Y * velikost, velikost, velikost);
        }
    }
}
