using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _035_RaumschiffÜbung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Transportschiff r = new Transportschiff();
            Console.WriteLine($"Besatzung: {r.Besatzung} mit {r.Laenge}x{r.Breite}");
            Console.WriteLine($"{r.KlassenName()}");

            Transportschiff r_2 = new Transportschiff();
            Transportschiff r_3 = new Transportschiff();
            Transportschiff r_4 = new Transportschiff();
            Console.WriteLine($"{Raumschiff.Instanzzaehler}");
        }
    }
}
