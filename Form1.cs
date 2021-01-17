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
    //C:\Users\david\source\repos\Had\Had
    public partial class Form1 : Form
    {
        Had had;
        Jidlo jidlo;
        Random random = new Random(); // Pro premistovani jidla

        public Form1()
        {
            InitializeComponent();
            int x = (canvas.Width / 20) / 2;
            int y = (canvas.Height / 20) / 2;
            had = new Had(x, y, canvas.Width / 20, canvas.Height / 20);
 
        }

        private void OnHadSnedlJidlo()
        {
            PremistiJidlo();
            had.skore++;
            lb_skore.Text = "" + had.skore;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            had.VykresliSe(e.Graphics);
            jidlo?.VykresliSe(e.Graphics);
        }

        private void herniTimer_Tick(object sender, EventArgs e)
        {
            had.PosunSe(jidlo);
            canvas.Refresh();
        }

        private void PremistiJidlo()
        {
            int x = random.Next(0, canvas.Width / 20);
            int y = random.Next(0, canvas.Height / 20);
            if (had.JsiNaTetoPozici(x, y))
            {
                PremistiJidlo();
            }
            else
            {
                jidlo = new Jidlo(x, y);
            }
        }

        private void StartGame()
        {
            int x = (canvas.Width / 20) / 2;
            int y = (canvas.Height / 20) / 2;
            had = new Had(x, y, canvas.Width / 20, canvas.Height / 20);
            PremistiJidlo();

            had.HadSnedlJidlo += OnHadSnedlJidlo;

            herniTimer.Start();
            canvas.Refresh();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                    StartGame();    
            }

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                had.ZmenSmer(Smer.Nahoru);

            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                had.ZmenSmer(Smer.Doleva);
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                had.ZmenSmer(Smer.Dolu);
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                had.ZmenSmer(Smer.Doprava);
            }
        }
    }
}
