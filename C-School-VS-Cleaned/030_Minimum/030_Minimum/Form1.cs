using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _030_Minimum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double min(params double[] list)
        {
            double minimum = list[0];
            foreach (var item in list)
            {
                if (item < minimum)
                {
                    minimum = item;
                }
            }
            return minimum;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = $"{min(5.0, 2.0, 3.0)}";
        }
    }
}
