using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _029_Methoden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public const double c = 2.9979e10;

        private double Energie(double m)
        {
            return m * Math.Pow(c, 2);
        }

        private void Energie_cbr(ref double e, double m)
        {
            e = Energie(m);
        }

        private void Square(ref int n)
        {
            n *= n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = $"{Energie(Convert.ToDouble(textBox1.Text))}";
            double energy = 0.0;
            Energie_cbr(ref energy, Convert.ToDouble(textBox1.Text));
            textBox1.Text = $"{energy}";
            for (int i = 0; i < 10; i++)
            {
                int j = i;
                Square(ref j);
                Console.WriteLine($"{j}");
            }
        }
    }
}
