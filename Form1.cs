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
        int count = 0; // Pocitadlo jidel

        public Form1()
        {
            InitializeComponent();
            progressBar1.Visible = false;
            int x = (canvas.Width / 20) / 2;
            int y = (canvas.Height / 20) / 2;
            had = new Had(x, y, canvas.Width / 20, canvas.Height / 20);
 
        }

        private void OnHadSnedlJidlo()
        {
            PremistiJidlo();
            Console.WriteLine(count);
            had.skore += (count % 5 == 0) ? progressBar1.Value : 1;
            lb_skore.Text = "" + had.skore;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
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
                if(count % 5 == 0 && count != 0)
                {
                    jidlo = new BonusoveJidlo(x, y);
                    progressBar1.Value = 100;
                    bonusovyTimer.Start();
                    count = 0;
                }
                else
                {
                    bonusovyTimer.Stop();
                    progressBar1.Visible = false;
                    jidlo = new Jidlo(x, y);
                }
                count++;
            }
        }
        private void OnHadUmrel()
        {
            herniTimer.Stop();
            DialogResult dr = MessageBox.Show(
                "Had umřel! Chcete spustit novou hru?",
                "Konec hry!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                this.Close();
                // Návrat do menu se vykona v From1_Closed
            }
            if (dr == DialogResult.Yes)
            {
                StartGame();
            }
        }
        private void StartGame()
        {
            int x = (canvas.Width / 20) / 2;
            int y = (canvas.Height / 20) / 2;
            had = new Had(x, y, canvas.Width / 20, canvas.Height / 20);
            PremistiJidlo();

            had.HadSnedlJidlo += OnHadSnedlJidlo;
            had.HadUmrel += OnHadUmrel;

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

        private void bonusovyTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value--;
            if (progressBar1.Value == 0)
            {
                bonusovyTimer.Stop();
                PremistiJidlo();             
            }
        }
    }
}
