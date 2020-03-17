using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _007_While
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val1 = Convert.ToInt32(textBox1.Text);
            int teiler = 2;
            button1.Text = "";
            
            while (val1 > 0)
            {
                button1.Text = Convert.ToString(val1 % teiler) + button1.Text;
                val1 = val1 / teiler;
            }
            
            int zähler = val1 / teiler;

            for (int i = 1; i < zähler; i++)
            {
                textBox2.Text = Convert.ToString(val1 % teiler) + textBox2.Text;
                val1 = val1 / teiler;
            }
        }
    }
}
