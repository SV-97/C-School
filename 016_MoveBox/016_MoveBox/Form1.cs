using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _016_MoveBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] X = new double[600];
            double[] Y = new double[600];
            for (int i = 0; i < X.Length; i++)
            {
                X[i] = i;
                Y[i] = 50.0*Math.Sin(0.1*X[i])+200;
            }
            for (int i = 0; i < 600; i++)
            {
                label1.Location = new Point(Convert.ToInt32(Math.Round(X[i])) , Convert.ToInt32(Math.Round(Y[i])));
                Thread.Sleep(10);
            }
        }
    }
}
