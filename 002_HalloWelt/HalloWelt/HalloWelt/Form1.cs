using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HalloWelt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            long a = 4;
            int b = 4;
            short c = 5;
            byte d = 6;
            double ergebnis;

            ergebnis = d / b * a; //4.0
            ergebnis = c + b * (d + 1); //33.0
            ergebnis = d / (c - 1) * b / 2; //2.0
            ergebnis = d % b; //2.0
            ergebnis = -c % b; //-1.0
            ergebnis = c++ % d; //5.0
        }
    }
}
