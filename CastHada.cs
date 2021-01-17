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

        Smer smer; // reálný
        Smer smerKeZmene;

        public Point Pozice
        {
            get { return pozice; }
        }


        public CastHada(int x, int y)
        {
            pozice = new Point(x, y);
            smer = Smer.Doprava;
            smerKeZmene = smer;
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

        public void ZmenSmer(Smer novySmer)
        {
                smerKeZmene = novySmer;
        }

        public void ZmenSmer(CastHada cast)
        {

            smerKeZmene = cast.smer;

        }

        public void PohniSe()
        {
            switch (smerKeZmene)
            {
                case Smer.Nahoru:
                    pozice.Y -= 1;
                    break;
                case Smer.Doprava:
                    pozice.X += 1;
                    break;
                case Smer.Dolu:
                    pozice.Y += 1;
                    break;
                case Smer.Doleva:
                    pozice.X -= 1;
                    break;
            }
            smer = smerKeZmene;
        }

    }
}
