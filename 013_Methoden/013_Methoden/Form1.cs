using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _013_Methoden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Begruessung();
            int a = 100;
            int b = 200;
            MessageBox.Show(string.Format("a = {0}\nb = {1}", a, b));
            Swap(ref a, ref b);
            MessageBox.Show(string.Format("a = {0}\nb = {1}", a, b));
            int[] c = new int[] { 10, 21, 35, 24, 65, 76 };
            MessageBox.Show(Convert.ToString(Min(c)));
        }

        private void Begruessung()
        {
            MessageBox.Show("Hellas");
        }

        private void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        private int Min(params int[] vals)
        {
            int min = vals[0];
            foreach (var val in vals)
            {
                if (val < min)
                {
                    min = val;
                }
            }
            return min;
        }
    }
}
